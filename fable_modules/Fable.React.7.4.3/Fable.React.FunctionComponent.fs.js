import { class_type } from "../fable-library.3.7.9/Reflection.js";
import { value as value_1, defaultArg } from "../fable-library.3.7.9/Option.js";
import { int32ToString, curry } from "../fable-library.3.7.9/Util.js";
import { ReactElementTypeModule_memoWith } from "./Fable.React.Helpers.fs.js";
import * as react from "react";

export class Cache {
    constructor() {
    }
}

export function Cache$reflection() {
    return class_type("Fable.React.Cache", void 0, Cache);
}

export function Cache_$ctor() {
    return new Cache();
}

(() => {
    let cache;
    Cache.cache = ((cache = (new Map()), (typeof module === 'object'
&& typeof module.hot === 'object'
&& typeof module.hot.addStatusHandler === 'function'
? module.hot.addStatusHandler(status => { if (status === 'apply') (() => {
        cache.clear();
    })(); })
: void 0, cache)));
})();

export function Cache_GetOrAdd_Z3AD3E68D(key, valueFactory) {
    if (Cache.cache.has(key)) {
        return Cache.cache.get(key);
    }
    else {
        const v = valueFactory(key);
        Cache.cache.set(key, v);
        return v;
    }
}

export class FunctionComponent {
    constructor() {
    }
}

export function FunctionComponent$reflection() {
    return class_type("Fable.React.FunctionComponent", void 0, FunctionComponent);
}

export function FunctionComponent_Of_Z5A158BBF(render, displayName, memoizeWith, withKey, __callingMemberName, __callingSourceFile, __callingSourceLine) {
    const prepareRenderFunction = (_arg1) => {
        const displayName_1 = defaultArg(displayName, value_1(__callingMemberName));
        render.displayName = displayName_1;
        let elemType;
        if (curry(2, memoizeWith) == null) {
            elemType = ((value) => value)(render);
        }
        else {
            const areEqual = memoizeWith;
            const areEqual_1 = (x, y) => {
                if (!(typeof module === 'object'
&& typeof module.hot === 'object'
&& typeof module.hot.status === 'function'
&& module.hot.status() === 'apply')) {
                    return areEqual(x, y);
                }
                else {
                    return false;
                }
            };
            const memoElement = ReactElementTypeModule_memoWith(areEqual_1, render);
            memoElement.displayName = (("Memo(" + displayName_1) + ")");
            elemType = memoElement;
        }
        return (props) => {
            let props_1;
            if (withKey == null) {
                props_1 = props;
            }
            else {
                const f_1 = withKey;
                props.key = f_1(props);
                props_1 = props;
            }
            return react.createElement(elemType, props_1);
        };
    };
    const cacheKey = (value_1(__callingSourceFile) + "#L") + int32ToString(value_1(__callingSourceLine));
    return Cache_GetOrAdd_Z3AD3E68D(cacheKey, prepareRenderFunction);
}

//# sourceMappingURL=Fable.React.FunctionComponent.fs.js.map
