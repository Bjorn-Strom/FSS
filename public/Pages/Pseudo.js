import { fss } from "../fable_modules/Fss-lib.Fable.1.0.1/FssFable.fs.js";
import { ContentCss_Content, Label_Label } from "../fable_modules/Fss-lib.Core.1.0.2/css/Content.fs.js";
import { unitHelpers_CssRuleWithLength__value_Z498FEB3B, unitHelpers_CssRuleWithAutoLength__value_Z498FEB3B, unitHelpers_DirectionalLength__value_Z498FEB3B } from "../fable_modules/Fss-lib.Core.1.0.2/Types/Units.fs.js";
import { px } from "../fable_modules/Fss-lib.Core.1.0.2/Functions.fs.js";
import { Padding } from "../fable_modules/Fss-lib.Core.1.0.2/css/Padding.fs.js";
import { Height, Width } from "../fable_modules/Fss-lib.Core.1.0.2/css/ContentSize.fs.js";
import { ColorClass_Color__get_black, ColorClass_Color__get_chartreuse, ColorClass_Color__get_white, ColorClass_Color__get_orangeRed } from "../fable_modules/Fss-lib.Core.1.0.2/Types/Color.fs.js";
import { BackgroundColor } from "../fable_modules/Fss-lib.Core.1.0.2/css/Background.fs.js";
import { FontSize } from "../fable_modules/Fss-lib.Core.1.0.2/css/Font.fs.js";
import { BorderRadius } from "../fable_modules/Fss-lib.Core.1.0.2/css/Border.fs.js";
import { Color } from "../fable_modules/Fss-lib.Core.1.0.2/css/Color.fs.js";
import { Hover } from "../fable_modules/Fss-lib.Core.1.0.2/css/PseudoClass.fs.js";
import { ofArray } from "../fable_modules/fable-library.3.7.9/List.js";
import { ContentClasses_Content__value_Z721C83C5 } from "../fable_modules/Fss-lib.Core.1.0.2/Types/Content.fs.js";
import { DisplayClasses_DisplayClass__get_inlineBlock } from "../fable_modules/Fss-lib.Core.1.0.2/Types/Display.fs.js";
import { Display } from "../fable_modules/Fss-lib.Core.1.0.2/css/Display.fs.js";
import { After, Before } from "../fable_modules/Fss-lib.Core.1.0.2/css/PseudoElement.fs.js";
import { createElement } from "react";
import { Page } from "./Page.js";
import { Page as Page_1 } from "../Pages.js";

export function Pseudo() {
    const hoverStyle = fss(ofArray([Label_Label("Hover Style"), unitHelpers_DirectionalLength__value_Z498FEB3B(Padding, px(40)), unitHelpers_CssRuleWithAutoLength__value_Z498FEB3B(Width, px(100)), ColorClass_Color__get_orangeRed(BackgroundColor), unitHelpers_CssRuleWithLength__value_Z498FEB3B(FontSize, px(20)), unitHelpers_DirectionalLength__value_Z498FEB3B(BorderRadius, px(5)), ColorClass_Color__get_white(Color), Hover(ofArray([ColorClass_Color__get_chartreuse(BackgroundColor), ColorClass_Color__get_black(Color)]))]));
    let beforeAndAfter_1;
    const beforeAndAfter = ofArray([ContentClasses_Content__value_Z721C83C5(ContentCss_Content, ""), DisplayClasses_DisplayClass__get_inlineBlock(Display), ColorClass_Color__get_orangeRed(BackgroundColor), unitHelpers_CssRuleWithAutoLength__value_Z498FEB3B(Width, px(10)), unitHelpers_CssRuleWithAutoLength__value_Z498FEB3B(Height, px(10))]);
    beforeAndAfter_1 = fss(ofArray([Label_Label("Before And After"), Before(beforeAndAfter), After(beforeAndAfter)]));
    const styles = ofArray([createElement("div", {
        className: hoverStyle,
        children: "Hover me!",
    }), createElement("div", {
        className: beforeAndAfter_1,
        children: " Some content surrounded by stuff ",
    })]);
    return createElement(Page, {
        page: new Page_1(5),
        styles: styles,
    });
}

export default (() => createElement(Pseudo, null));

