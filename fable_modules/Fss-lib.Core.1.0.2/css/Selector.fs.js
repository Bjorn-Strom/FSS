import { Selector_descendant, Selector_child, Selector_generalSibling, Selector_adjacentSibling } from "../Types/Selector.fs.js";

export function op_BangPlus(html, rules) {
    return Selector_adjacentSibling(html, rules);
}

export function op_BangTwiddle(html, rules) {
    return Selector_generalSibling(html, rules);
}

export function op_BangGreater(html, rules) {
    return Selector_child(html, rules);
}

export function op_Dereference(html, rules) {
    return Selector_descendant(html, rules);
}

//# sourceMappingURL=Selector.fs.js.map
