import { Observer } from "./Observable.js";
import { some, value } from "./Option.js";
import { Choice_tryValueIfChoice1Of2, Choice_tryValueIfChoice2Of2 } from "./Choice.js";
export class Event {
    constructor() {
        this.delegates = [];
    }
    Add(f) {
        this._addHandler(f);
    }
    get Publish() {
        return this;
    }
    Trigger(senderOrValue, valueOrUndefined) {
        let sender;
        let value;
        if (valueOrUndefined === undefined) {
            sender = null;
            value = senderOrValue;
        }
        else {
            sender = senderOrValue;
            value = valueOrUndefined;
        }
        this.delegates.forEach((f) => f.length === 1 ? f(value) : f(sender, value));
    }
    // IDelegateEvent<T> methods
    AddHandler(handler) {
        this._addHandler(handler);
    }
    RemoveHandler(handler) {
        this._removeHandler(handler);
    }
    // IObservable<T> methods
    Subscribe(arg) {
        const callback = typeof arg === "function"
            ? arg
            : arg.OnNext;
        this._addHandler(callback);
        return { Dispose: () => { this._removeHandler(callback); } };
    }
    _addHandler(f) {
        this.delegates.push(f);
    }
    _removeHandler(f) {
        const index = this.delegates.indexOf(f);
        if (index > -1) {
            this.delegates.splice(index, 1);
        }
    }
}
export function add(callback, sourceEvent) {
    if (sourceEvent instanceof Event) {
        sourceEvent.Add(callback);
    }
    else {
        sourceEvent.Subscribe(new Observer(callback));
    }
}
export function choose(chooser, sourceEvent) {
    const ev = new Event();
    add((t) => {
        const u = chooser(t);
        if (u != null) {
            ev.Trigger(value(u));
        }
    }, sourceEvent);
    return ev;
}
export function filter(predicate, sourceEvent) {
    return choose((x) => predicate(x) ? some(x) : undefined, sourceEvent);
}
export function map(mapping, sourceEvent) {
    const ev = new Event();
    add((t) => ev.Trigger(mapping(t)), sourceEvent);
    return ev;
}
export function merge(event1, event2) {
    const ev = new Event();
    const fn = (x) => ev.Trigger(x);
    add(fn, event1);
    add(fn, event2);
    return ev;
}
export function pairwise(sourceEvent) {
    const ev = new Event();
    let last;
    let haveLast = false;
    add((next) => {
        if (haveLast) {
            ev.Trigger([last, next]);
        }
        last = next;
        haveLast = true;
    }, sourceEvent);
    return ev;
}
export function partition(predicate, sourceEvent) {
    return [filter(predicate, sourceEvent), filter((x) => !predicate(x), sourceEvent)];
}
export function scan(collector, state, sourceEvent) {
    return map((t) => state = collector(state, t), sourceEvent);
}
export function split(splitter, sourceEvent) {
    return [
        choose((v) => Choice_tryValueIfChoice1Of2(splitter(v)), sourceEvent),
        choose((v) => Choice_tryValueIfChoice2Of2(splitter(v)), sourceEvent),
    ];
}
export function createEvent(addHandler, removeHandler) {
    return {
        AddHandler(h) { addHandler(h); },
        RemoveHandler(h) { removeHandler(h); },
        Subscribe(r) {
            const h = (_, args) => r.OnNext(args);
            addHandler(h);
            return {
                Dispose() { removeHandler(h); }
            };
        }
    };
}
export default Event;
