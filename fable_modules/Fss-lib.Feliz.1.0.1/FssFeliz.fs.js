import { fss } from "../Fss-lib.Fable.1.0.1/FssFable.fs.js";
import { combine } from "../Fss-lib.Core.1.0.2/Functions.fs.js";
import { singleton, empty, ofArray } from "../fable-library.3.7.9/List.js";

export function Feliz_prop__prop_fss_Static_72C268A9(properties) {
    const className = fss(properties);
    return ["className", className];
}

export function Feliz_prop__prop_fssWithClass_Static(className, properties) {
    return ["className", combine(ofArray([className, fss(properties)]), empty())];
}

export function Feliz_prop__prop_fssCombine_Static(classNames, properties) {
    return ["className", combine(singleton(fss(properties)), classNames)];
}

//# sourceMappingURL=FssFeliz.fs.js.map
