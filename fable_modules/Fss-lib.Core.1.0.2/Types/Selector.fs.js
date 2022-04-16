import { class_type } from "../../fable-library.3.7.9/Reflection.js";
import { CombinatorMaster, Property_CssProperty } from "./MasterTypes.fs.js";

export class Selector {
    constructor() {
    }
}

export function Selector$reflection() {
    return class_type("Fss.Types.SelectorClasses.Selector", void 0, Selector);
}

export function Selector_adjacentSibling(html, rules) {
    const tupledArg = [new Property_CssProperty(392, html), new CombinatorMaster(0, rules)];
    return [tupledArg[0], tupledArg[1]];
}

export function Selector_generalSibling(html, rules) {
    const tupledArg = [new Property_CssProperty(393, html), new CombinatorMaster(0, rules)];
    return [tupledArg[0], tupledArg[1]];
}

export function Selector_child(html, rules) {
    const tupledArg = [new Property_CssProperty(394, html), new CombinatorMaster(0, rules)];
    return [tupledArg[0], tupledArg[1]];
}

export function Selector_descendant(html, rules) {
    const tupledArg = [new Property_CssProperty(395, html), new CombinatorMaster(0, rules)];
    return [tupledArg[0], tupledArg[1]];
}

//# sourceMappingURL=Selector.fs.js.map
