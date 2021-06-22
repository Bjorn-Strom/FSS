import { combine, fss } from "../fss/Functions.js";
import { singleton, empty, ofArray } from "../.fable/fable-library.3.1.15/List.js";

export function Feliz_prop__prop_fss_Static_Z3BB76C00(properties) {
    return ["className", fss(properties)];
}

export function Feliz_prop__prop_fssWithClassName_Static(className, properties) {
    return ["className", combine(ofArray([className, fss(properties)]), empty())];
}

export function Feliz_prop__prop_fssWithClassNames_Static(classNames, properties) {
    return ["className", combine(singleton(fss(properties)), classNames)];
}

