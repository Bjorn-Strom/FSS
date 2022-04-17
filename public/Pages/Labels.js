import { fss } from "../fable_modules/Fss-lib.Fable.1.0.1/FssFable.fs.js";
import { ColorClass_Color__get_hotPink, ColorClass_Color__get_red } from "../fable_modules/Fss-lib.Core.1.0.2/Types/Color.fs.js";
import { Color } from "../fable_modules/Fss-lib.Core.1.0.2/css/Color.fs.js";
import { ofArray, singleton } from "../fable_modules/fable-library.3.7.9/List.js";
import { Label_Label } from "../fable_modules/Fss-lib.Core.1.0.2/css/Content.fs.js";
import { createElement } from "react";
import { Interop_reactApi } from "../fable_modules/Feliz.1.57.0/Interop.fs.js";
import { Page } from "./Page.js";
import { Page as Page_1 } from "../Pages.js";

export function Labels() {
    let children;
    const styleWithoutLabel = fss(singleton(ColorClass_Color__get_red(Color)));
    const styleWithLabel = fss(ofArray([Label_Label("Style With Label"), ColorClass_Color__get_hotPink(Color), Label_Label("HotPinkLabel")]));
    const styles = singleton((children = ofArray([createElement("div", {
        className: styleWithoutLabel,
        children: styleWithoutLabel,
    }), createElement("div", {
        className: styleWithLabel,
        children: styleWithLabel,
    })]), createElement("div", {
        children: Interop_reactApi.Children.toArray(Array.from(children)),
    })));
    return createElement(Page, {
        page: new Page_1(7),
        styles: styles,
    });
}

export default (() => createElement(Labels, null));

//# sourceMappingURL=Labels.js.map
