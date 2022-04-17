import { Label_Label } from "../fable_modules/Fss-lib.Core.1.0.2/css/Content.fs.js";
import { ColorClass_Color__get_red, ColorClass_Color__get_turquoise, ColorClass_Color__get_darkGreen } from "../fable_modules/Fss-lib.Core.1.0.2/Types/Color.fs.js";
import { BackgroundColor } from "../fable_modules/Fss-lib.Core.1.0.2/css/Background.fs.js";
import { Color } from "../fable_modules/Fss-lib.Core.1.0.2/css/Color.fs.js";
import { singleton, append, ofArray } from "../fable_modules/fable-library.3.7.9/List.js";
import { createElement } from "react";
import { fss } from "../fable_modules/Fss-lib.Fable.1.0.1/FssFable.fs.js";
import { Interop_reactApi } from "../fable_modules/Feliz.1.57.0/Interop.fs.js";
import { Page } from "./Page.js";
import { Page as Page_1 } from "../Pages.js";

export function Composition() {
    let children;
    const baseStyle = ofArray([Label_Label("Base Style"), ColorClass_Color__get_darkGreen(BackgroundColor), ColorClass_Color__get_turquoise(Color)]);
    const danger = ofArray([Label_Label("Danger"), ColorClass_Color__get_red(Color)]);
    const styles = singleton((children = ofArray([createElement("div", {
        className: fss(baseStyle),
        children: "This will be turquoise",
    }), createElement("div", {
        className: fss(append(danger, baseStyle)),
        children: "This will be also be turquoise since the base styles overwrite the danger styles.",
    }), createElement("div", {
        className: fss(append(baseStyle, danger)),
        children: "This will be red",
    })]), createElement("div", {
        children: Interop_reactApi.Children.toArray(Array.from(children)),
    })));
    return createElement(Page, {
        page: new Page_1(6),
        styles: styles,
    });
}

export default (() => createElement(Composition, null));

//# sourceMappingURL=Composition.js.map
