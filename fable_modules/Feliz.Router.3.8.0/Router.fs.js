import { split, trimEnd, isNullOrWhiteSpace, substring, join, endsWith } from "../fable-library.3.7.9/String.js";
import { ofArray, singleton, collect, empty, head, tail, isEmpty, reverse, map } from "../fable-library.3.7.9/List.js";
import { equalsWith } from "../fable-library.3.7.9/Array.js";
import { useReact_useCallbackRef_7C4B0DD6, React_memo_62A0F746 } from "../Feliz.1.57.0/React.fs.js";
import { defaultArg } from "../fable-library.3.7.9/Option.js";
import { useReact_useEffect_Z5ECA432F, React_createDisposable_3A5B6456, useReact_useCallbackRef_7C4B0DD6 as useReact_useCallbackRef_7C4B0DD6_1, useReact_useMemo_CF4EA67 } from "../Feliz.1.57.0/React.fs.js";
import { Impl_createRemoveOptions, Impl_adjustPassive } from "../Feliz.UseListener.0.6.3/Listener.fs.js";
import { tryParse } from "../fable-library.3.7.9/Int32.js";
import { FSharpRef } from "../fable-library.3.7.9/Types.js";
import { tryParse as tryParse_1, fromInt } from "../fable-library.3.7.9/Long.js";
import { tryParse as tryParse_2 } from "../fable-library.3.7.9/Guid.js";
import { tryParse as tryParse_3 } from "../fable-library.3.7.9/Double.js";
import { tryParse as tryParse_4 } from "../fable-library.3.7.9/Decimal.js";
import Decimal from "../fable-library.3.7.9/Decimal.js";
import { map as map_1, delay, toList } from "../fable-library.3.7.9/Seq.js";

export function RouterModule_String_$007CPrefix$007C(prefix, str) {
    if (str.indexOf(prefix) === 0) {
        return str;
    }
    else {
        return void 0;
    }
}

export function RouterModule_String_$007CSuffix$007C(suffix, str) {
    if (endsWith(str, suffix)) {
        return str;
    }
    else {
        return void 0;
    }
}

export function RouterModule_encodeQueryString(queryStringPairs) {
    const _arg1 = join("\u0026", map((tupledArg) => {
        const key = tupledArg[0];
        const value = tupledArg[1];
        return join("=", [encodeURIComponent(key), encodeURIComponent(value)]);
    }, queryStringPairs));
    if (_arg1 === "") {
        return "";
    }
    else {
        const pairs = _arg1;
        return "?" + pairs;
    }
}

export function RouterModule_encodeQueryStringInts(queryStringIntPairs) {
    const _arg1 = join("\u0026", map((tupledArg) => {
        const key = tupledArg[0];
        const value = tupledArg[1] | 0;
        return join("=", [encodeURIComponent(key), value]);
    }, queryStringIntPairs));
    if (_arg1 === "") {
        return "";
    }
    else {
        const pairs = _arg1;
        return "?" + pairs;
    }
}

function RouterModule_normalizeRoute(routeMode) {
    if (routeMode === 1) {
        return (_arg1) => {
            let activePatternResult13114, path, activePatternResult13115, path_1, activePatternResult13116, path_2, path_3;
            return (activePatternResult13114 = RouterModule_String_$007CPrefix$007C("/", _arg1), (activePatternResult13114 != null) ? ((path = activePatternResult13114, "#" + path)) : ((activePatternResult13115 = RouterModule_String_$007CPrefix$007C("#/", _arg1), (activePatternResult13115 != null) ? ((path_1 = activePatternResult13115, path_1)) : ((activePatternResult13116 = RouterModule_String_$007CPrefix$007C("#", _arg1), (activePatternResult13116 != null) ? ((path_2 = activePatternResult13116, "#/" + substring(path_2, 1, path_2.length - 1))) : ((path_3 = _arg1, "#/" + path_3)))))));
        };
    }
    else {
        return (_arg2) => {
            let activePatternResult13119, path_4, path_5;
            return (activePatternResult13119 = RouterModule_String_$007CPrefix$007C("/", _arg2), (activePatternResult13119 != null) ? ((path_4 = activePatternResult13119, path_4)) : ((path_5 = _arg2, "/" + path_5)));
        };
    }
}

export function RouterModule_encodeParts(xs, routeMode) {
    return RouterModule_normalizeRoute(routeMode)(join("/", map((part) => {
        if (((part.indexOf("?") >= 0) ? true : (part.indexOf("#") === 0)) ? true : (part.indexOf("/") === 0)) {
            return part;
        }
        else {
            return encodeURIComponent(part);
        }
    }, xs)));
}

export function RouterModule_trySeparateLast(xs) {
    const matchValue = reverse(xs);
    if (!isEmpty(matchValue)) {
        if (isEmpty(tail(matchValue))) {
            const single = head(matchValue);
            return [empty(), single];
        }
        else {
            const list_1 = matchValue;
            return [reverse(tail(list_1)), head(list_1)];
        }
    }
    else {
        return void 0;
    }
}

export function RouterModule_nav(xs, mode, routeMode) {
    if (mode === 1) {
        history.pushState(void 0, "", RouterModule_encodeParts(xs, routeMode));
    }
    else {
        history.replaceState(void 0, "", RouterModule_encodeParts(xs, routeMode));
    }
    const ev = document.createEvent("CustomEvent");
    ev.initEvent("CUSTOM_NAVIGATION_EVENT", true, true);
    window.dispatchEvent(ev);
}

export function RouterModule_urlSegments(path, mode) {
    return collect((segment) => {
        if (isNullOrWhiteSpace(segment)) {
            return empty();
        }
        else {
            const segment_1 = trimEnd(segment, "#");
            if (segment_1 === "?") {
                return empty();
            }
            else if (RouterModule_String_$007CPrefix$007C("?", segment_1) != null) {
                return singleton(segment_1);
            }
            else {
                const matchValue = segment_1.split("?");
                if ((!equalsWith((x, y) => (x === y), matchValue, null)) && (matchValue.length === 1)) {
                    const value = matchValue[0];
                    return singleton(decodeURIComponent(value));
                }
                else if ((!equalsWith((x_1, y_1) => (x_1 === y_1), matchValue, null)) && (matchValue.length === 2)) {
                    if (matchValue[1] === "") {
                        const value_1 = matchValue[0];
                        return singleton(decodeURIComponent(value_1));
                    }
                    else {
                        const value_2 = matchValue[0];
                        const query = matchValue[1];
                        return ofArray([decodeURIComponent(value_2), "?" + query]);
                    }
                }
                else {
                    return empty();
                }
            }
        }
    }, ofArray(split((RouterModule_String_$007CPrefix$007C("#", path) != null) ? substring(path, 1, path.length - 1) : ((mode === 1) ? ((RouterModule_String_$007CSuffix$007C("#", path) != null) ? "" : ((RouterModule_String_$007CSuffix$007C("#/", path) != null) ? "" : path)) : path), ["/"], null, 0)));
}

export function RouterModule_onUrlChange(routeMode, urlChanged, ev) {
    return urlChanged(RouterModule_urlSegments((routeMode === 2) ? (window.location.pathname + window.location.search) : window.location.hash, routeMode));
}

export const RouterModule_router = React_memo_62A0F746((input) => {
    const onChange = useReact_useCallbackRef_7C4B0DD6((ev) => {
        const urlChanged = defaultArg(input.onUrlChanged, (value) => {
        });
        const routeMode = defaultArg(input.hashMode, 1) | 0;
        RouterModule_onUrlChange(routeMode, urlChanged, ev);
    });
    if (((window.navigator.userAgent).indexOf("Trident") >= 0) ? true : ((window.navigator.userAgent).indexOf("MSIE") >= 0)) {
        const eventType = "hashchange";
        const action_1 = (arg00) => {
            onChange(arg00);
        };
        const options_1 = void 0;
        const addOptions = useReact_useMemo_CF4EA67(() => Impl_adjustPassive(options_1), [options_1]);
        const removeOptions = useReact_useMemo_CF4EA67(() => Impl_createRemoveOptions(options_1), [options_1]);
        const fn = useReact_useMemo_CF4EA67(() => ((arg) => {
            action_1(arg);
        }), [action_1]);
        const listener = useReact_useCallbackRef_7C4B0DD6_1(() => {
            if (addOptions == null) {
                window.addEventListener(eventType, fn);
            }
            else {
                const options_1_1 = addOptions;
                window.addEventListener(eventType, fn, options_1_1);
            }
            return React_createDisposable_3A5B6456(() => {
                if (removeOptions == null) {
                    window.removeEventListener(eventType, fn);
                }
                else {
                    const options_2 = removeOptions;
                    window.removeEventListener(eventType, fn, options_2);
                }
            });
        });
        useReact_useEffect_Z5ECA432F(listener);
    }
    else {
        const eventType_1 = "popstate";
        const action_3 = onChange;
        const options_4 = void 0;
        const addOptions_1 = useReact_useMemo_CF4EA67(() => Impl_adjustPassive(options_4), [options_4]);
        const removeOptions_1 = useReact_useMemo_CF4EA67(() => Impl_createRemoveOptions(options_4), [options_4]);
        const fn_1 = useReact_useMemo_CF4EA67(() => ((arg_1) => {
            action_3(arg_1);
        }), [action_3]);
        const listener_1 = useReact_useCallbackRef_7C4B0DD6_1(() => {
            if (addOptions_1 == null) {
                window.addEventListener(eventType_1, fn_1);
            }
            else {
                const options_1_2 = addOptions_1;
                window.addEventListener(eventType_1, fn_1, options_1_2);
            }
            return React_createDisposable_3A5B6456(() => {
                if (removeOptions_1 == null) {
                    window.removeEventListener(eventType_1, fn_1);
                }
                else {
                    const options_2_1 = removeOptions_1;
                    window.removeEventListener(eventType_1, fn_1, options_2_1);
                }
            });
        });
        useReact_useEffect_Z5ECA432F(listener_1);
    }
    const eventType_2 = "CUSTOM_NAVIGATION_EVENT";
    const action_4 = onChange;
    const options_5 = void 0;
    const addOptions_2 = useReact_useMemo_CF4EA67(() => Impl_adjustPassive(options_5), [options_5]);
    const removeOptions_2 = useReact_useMemo_CF4EA67(() => Impl_createRemoveOptions(options_5), [options_5]);
    const fn_2 = useReact_useMemo_CF4EA67(() => ((arg_2) => {
        action_4(arg_2);
    }), [action_4]);
    const listener_2 = useReact_useCallbackRef_7C4B0DD6_1(() => {
        if (addOptions_2 == null) {
            window.addEventListener(eventType_2, fn_2);
        }
        else {
            const options_1_3 = addOptions_2;
            window.addEventListener(eventType_2, fn_2, options_1_3);
        }
        return React_createDisposable_3A5B6456(() => {
            if (removeOptions_2 == null) {
                window.removeEventListener(eventType_2, fn_2);
            }
            else {
                const options_2_2 = removeOptions_2;
                window.removeEventListener(eventType_2, fn_2, options_2_2);
            }
        });
    });
    useReact_useEffect_Z5ECA432F(listener_2);
    const matchValue = input.application;
    if (matchValue == null) {
        return null;
    }
    else {
        const elem = matchValue;
        return elem;
    }
});

export function Route_$007CInt$007C_$007C(input) {
    let matchValue;
    let outArg = 0;
    matchValue = [tryParse(input, 511, false, 32, new FSharpRef(() => outArg, (v) => {
        outArg = (v | 0);
    })), outArg];
    if (matchValue[0]) {
        const value = matchValue[1] | 0;
        return value;
    }
    else {
        return void 0;
    }
}

export function Route_$007CInt64$007C_$007C(input) {
    let matchValue;
    let outArg = fromInt(0);
    matchValue = [tryParse_1(input, 511, false, 64, new FSharpRef(() => outArg, (v) => {
        outArg = v;
    })), outArg];
    if (matchValue[0]) {
        const value = matchValue[1];
        return value;
    }
    else {
        return void 0;
    }
}

export function Route_$007CGuid$007C_$007C(input) {
    let matchValue;
    let outArg = "00000000-0000-0000-0000-000000000000";
    matchValue = [tryParse_2(input, new FSharpRef(() => outArg, (v) => {
        outArg = v;
    })), outArg];
    if (matchValue[0]) {
        const value = matchValue[1];
        return value;
    }
    else {
        return void 0;
    }
}

export function Route_$007CNumber$007C_$007C(input) {
    let matchValue;
    let outArg = 0;
    matchValue = [tryParse_3(input, new FSharpRef(() => outArg, (v) => {
        outArg = v;
    })), outArg];
    if (matchValue[0]) {
        const value = matchValue[1];
        return value;
    }
    else {
        return void 0;
    }
}

export function Route_$007CDecimal$007C_$007C(input) {
    let matchValue;
    let outArg = new Decimal(0);
    matchValue = [tryParse_4(input, new FSharpRef(() => outArg, (v) => {
        outArg = v;
    })), outArg];
    if (matchValue[0]) {
        const value = matchValue[1];
        return value;
    }
    else {
        return void 0;
    }
}

export function Route_$007CBool$007C_$007C(input) {
    const matchValue = input.toLocaleLowerCase();
    switch (matchValue) {
        case "1":
        case "true": {
            return true;
        }
        case "0":
        case "false": {
            return false;
        }
        case "": {
            return true;
        }
        default: {
            return void 0;
        }
    }
}

export function Route_$007CQuery$007C_$007C(input) {
    try {
        const urlParams = new URLSearchParams(input);
        return toList(delay(() => map_1((entry) => [entry[0], entry[1]], urlParams.entries())));
    }
    catch (matchValue) {
        return void 0;
    }
}

//# sourceMappingURL=Router.fs.js.map
