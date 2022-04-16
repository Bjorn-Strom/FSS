import { Result_MapError, Result_Map, FSharpResult$2 } from "../fable-library.3.7.9/Choice.js";
import { class_type } from "../fable-library.3.7.9/Reflection.js";
import { equals, disposeSafe, getEnumerator } from "../fable-library.3.7.9/Util.js";

export function reject(reason) {
    return Promise.reject(reason);
}

export function result(a) {
    return a.then(((arg) => (new FSharpResult$2(0, arg))),((arg_1) => (new FSharpResult$2(1, arg_1))));
}

export function mapResult(fn, a) {
    return a.then((result_1) => Result_Map(fn, result_1));
}

export function bindResult(fn, a) {
    return a.then((a_1) => {
        if (a_1.tag === 1) {
            const e = a_1.fields[0];
            return Promise.resolve(new FSharpResult$2(1, e));
        }
        else {
            const a_2 = a_1.fields[0];
            return result(fn(a_2));
        }
    });
}

export function mapResultError(fn, a) {
    return a.then((result_1) => Result_MapError(fn, result_1));
}

export function tap(fn, a) {
    return a.then((x) => {
        fn(x);
        return x;
    });
}

export class PromiseBuilder {
    constructor() {
    }
}

export function PromiseBuilder$reflection() {
    return class_type("Promise.PromiseBuilder", void 0, PromiseBuilder);
}

export function PromiseBuilder_$ctor() {
    return new PromiseBuilder();
}

export function PromiseBuilder__For_1565554B(x, seq, body) {
    let p = Promise.resolve(undefined);
    const enumerator = getEnumerator(seq);
    try {
        while (enumerator["System.Collections.IEnumerator.MoveNext"]()) {
            const a = enumerator["System.Collections.Generic.IEnumerator`1.get_Current"]();
            p = (p.then(() => body(a)));
        }
    }
    finally {
        disposeSafe(enumerator);
    }
    return p;
}

export function PromiseBuilder__While_2044D34(x, guard, p) {
    if (guard()) {
        return p.then(() => PromiseBuilder__While_2044D34(x, guard, p));
    }
    else {
        return Promise.resolve(undefined);
    }
}

export function PromiseBuilder__TryFinally_7D49A2FD(x, p, compensation) {
    return p.then(((x_1) => {
        compensation();
        return x_1;
    }),((er) => {
        compensation();
        throw er;
    }));
}

export function PromiseBuilder__Delay_62FBFDE1(x, generator) {
    return {
        then: (f1, f2) => {
            try {
                return generator().then(f1, f2);
            }
            catch (er) {
                if (equals(f2, null)) {
                    return Promise.reject(er);
                }
                else {
                    try {
                        return Promise.resolve(f2(er));
                    }
                    catch (er_1) {
                        return Promise.reject(er_1);
                    }
                }
            }
        },
        catch: (f) => {
            try {
                return generator().catch(f);
            }
            catch (er_2) {
                try {
                    return Promise.resolve(f(er_2));
                }
                catch (er_3) {
                    return Promise.reject(er_3);
                }
            }
        },
    };
}

export function PromiseBuilder__Run_212F1D4B(x, p) {
    return new Promise((success, fail) => {
        try {
            const p_1 = Promise.resolve(p);
            p_1.then(success, fail);
        }
        catch (er) {
            fail(er);
        }
    });
}

export function PromiseBuilder__Using_74F7E79D(x, resource, binder) {
    return PromiseBuilder__TryFinally_7D49A2FD(x, binder(resource), () => {
        let copyOfStruct = resource;
        disposeSafe(copyOfStruct);
    });
}

//# sourceMappingURL=Promise.fs.js.map
