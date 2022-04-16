import { Union } from "../fable-library.3.7.9/Types.js";
import { class_type, union_type, int32_type, array_type } from "../fable-library.3.7.9/Reflection.js";
import { fill } from "../fable-library.3.7.9/Array.js";
import { comparePrimitives, max } from "../fable-library.3.7.9/Util.js";
import { some } from "../fable-library.3.7.9/Option.js";
import { singleton, collect, take, skip, append, delay } from "../fable-library.3.7.9/Seq.js";
import { rangeDouble } from "../fable-library.3.7.9/Range.js";

export class RingState$1 extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["Writable", "ReadWritable"];
    }
}

export function RingState$1$reflection(gen0) {
    return union_type("Elmish.RingState`1", [gen0], RingState$1, () => [[["wx", array_type(gen0)], ["ix", int32_type]], [["rw", array_type(gen0)], ["wix", int32_type], ["rix", int32_type]]]);
}

export class RingBuffer$1 {
    constructor(size) {
        this.state = (new RingState$1(0, fill(new Array(max(comparePrimitives, size, 10)), 0, max(comparePrimitives, size, 10), null), 0));
    }
}

export function RingBuffer$1$reflection(gen0) {
    return class_type("Elmish.RingBuffer`1", [gen0], RingBuffer$1);
}

export function RingBuffer$1_$ctor_Z524259A4(size) {
    return new RingBuffer$1(size);
}

export function RingBuffer$1__Pop(__) {
    const matchValue = __.state;
    if (matchValue.tag === 1) {
        const wix = matchValue.fields[1] | 0;
        const rix = matchValue.fields[2] | 0;
        const items = matchValue.fields[0];
        const rix$0027 = ((rix + 1) % items.length) | 0;
        if (rix$0027 === wix) {
            __.state = (new RingState$1(0, items, wix));
        }
        else {
            __.state = (new RingState$1(1, items, wix, rix$0027));
        }
        return some(items[rix]);
    }
    else {
        return void 0;
    }
}

export function RingBuffer$1__Push_2B595(__, item) {
    const matchValue = __.state;
    if (matchValue.tag === 1) {
        const wix_1 = matchValue.fields[1] | 0;
        const rix = matchValue.fields[2] | 0;
        const items_1 = matchValue.fields[0];
        items_1[wix_1] = item;
        const wix$0027 = ((wix_1 + 1) % items_1.length) | 0;
        if (wix$0027 === rix) {
            __.state = (new RingState$1(1, RingBuffer$1__doubleSize(__, rix, items_1), items_1.length, 0));
        }
        else {
            __.state = (new RingState$1(1, items_1, wix$0027, rix));
        }
    }
    else {
        const ix = matchValue.fields[1] | 0;
        const items = matchValue.fields[0];
        items[ix] = item;
        const wix = ((ix + 1) % items.length) | 0;
        __.state = (new RingState$1(1, items, wix, ix));
    }
}

function RingBuffer$1__doubleSize(this$, ix, items) {
    return Array.from(delay(() => append(skip(ix, items), delay(() => append(take(ix, items), delay(() => collect((matchValue) => singleton(null), rangeDouble(0, 1, items.length))))))));
}

//# sourceMappingURL=ring.fs.js.map
