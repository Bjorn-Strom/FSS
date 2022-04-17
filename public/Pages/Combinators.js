import { fss } from "../fable_modules/Fss-lib.Fable.1.0.1/FssFable.fs.js";
import { Label_Label } from "../fable_modules/Fss-lib.Core.1.0.2/css/Content.fs.js";
import { op_BangTwiddle, op_BangPlus, op_BangGreater, op_Dereference } from "../fable_modules/Fss-lib.Core.1.0.2/css/Selector.fs.js";
import { Html } from "../fable_modules/Fss-lib.Core.1.0.2/Types/Html.fs.js";
import { ColorClass_Color__get_red } from "../fable_modules/Fss-lib.Core.1.0.2/Types/Color.fs.js";
import { Color } from "../fable_modules/Fss-lib.Core.1.0.2/css/Color.fs.js";
import { ofArray, singleton } from "../fable_modules/fable-library.3.7.9/List.js";
import { createElement } from "react";
import { createObj } from "../fable_modules/fable-library.3.7.9/Util.js";
import { Interop_reactApi } from "../fable_modules/Feliz.1.57.0/Interop.fs.js";
import { Page } from "./Page.js";
import { Page as Page_1 } from "../Pages.js";

export function Combinators() {
    let elems, children, elems_1, children_2, elems_3, elems_2, elems_5, elems_4, children_6;
    const descendantCombinator = fss(ofArray([Label_Label("Descendant"), op_Dereference(new Html(74), singleton(ColorClass_Color__get_red(Color)))]));
    const childCombinator = fss(ofArray([Label_Label("Child"), op_BangGreater(new Html(74), singleton(ColorClass_Color__get_red(Color)))]));
    const directCombinator = fss(ofArray([Label_Label("Direct"), op_BangPlus(new Html(74), singleton(ColorClass_Color__get_red(Color)))]));
    const adjacentCombinator = fss(ofArray([Label_Label("Adjacent"), op_BangTwiddle(new Html(74), singleton(ColorClass_Color__get_red(Color)))]));
    const styles = ofArray([createElement("div", createObj(ofArray([["className", descendantCombinator], (elems = [createElement("p", {
        children: ["Text in a paragraph and therefore red"],
    }), "Text outside of paragraph", (children = singleton(createElement("p", {
        children: ["Text in paragraph in div and red"],
    })), createElement("div", {
        children: Interop_reactApi.Children.toArray(Array.from(children)),
    }))], ["children", Interop_reactApi.Children.toArray(Array.from(elems))])]))), createElement("div", createObj(ofArray([["className", childCombinator], (elems_1 = [createElement("p", {
        children: ["Text in a paragraph and therefore red"],
    }), "Text outside of paragraph", (children_2 = singleton(createElement("p", {
        children: ["Text in paragraph in div and not red"],
    })), createElement("div", {
        children: Interop_reactApi.Children.toArray(Array.from(children_2)),
    }))], ["children", Interop_reactApi.Children.toArray(Array.from(elems_1))])]))), createElement("div", createObj(singleton((elems_3 = [createElement("div", createObj(ofArray([["className", directCombinator], (elems_2 = [createElement("p", {
        children: Interop_reactApi.Children.toArray(["Text in paragraph in div "]),
    })], ["children", Interop_reactApi.Children.toArray(Array.from(elems_2))])]))), createElement("p", {
        children: ["Text in a paragraph and after the div with the combinator so is red"],
    }), createElement("p", {
        children: ["Text in a paragraph but not after div with the combinator so is not red"],
    })], ["children", Interop_reactApi.Children.toArray(Array.from(elems_3))])))), createElement("div", createObj(singleton((elems_5 = [createElement("div", createObj(ofArray([["className", adjacentCombinator], (elems_4 = [createElement("p", {
        children: "Text in paragraph in div ",
    })], ["children", Interop_reactApi.Children.toArray(Array.from(elems_4))])]))), createElement("p", {
        children: ["Text in a paragraph and after the div with the combinator so is red"],
    }), createElement("p", {
        children: ["Text in a paragraph and after the div with the combinator so is red"],
    }), (children_6 = singleton(createElement("p", {
        children: ["Text in a paragraph inside another div, paragraph is not directly after div with the combinator so is not red"],
    })), createElement("div", {
        children: Interop_reactApi.Children.toArray(Array.from(children_6)),
    }))], ["children", Interop_reactApi.Children.toArray(Array.from(elems_5))]))))]);
    return createElement(Page, {
        page: new Page_1(10),
        styles: styles,
    });
}

export default (() => createElement(Combinators, null));

//# sourceMappingURL=Combinators.js.map
