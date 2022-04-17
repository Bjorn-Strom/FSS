import { fss } from "../fable_modules/Fss-lib.Fable.1.0.1/FssFable.fs.js";
import { Label_Label } from "../fable_modules/Fss-lib.Core.1.0.2/css/Content.fs.js";
import { ColorClass_Color__get_orangeRed, ColorClass_Color__get_yellowGreen, ColorClass_Color__get_green, ColorClass_Color__get_red } from "../fable_modules/Fss-lib.Core.1.0.2/Types/Color.fs.js";
import { BackgroundColor } from "../fable_modules/Fss-lib.Core.1.0.2/css/Background.fs.js";
import { TransitionProperty__get_all, TransitionDuration__value_74CCD5DD, TransitionProperty__get_backgroundColor } from "../fable_modules/Fss-lib.Core.1.0.2/Types/Transition.fs.js";
import { TransitionTimingFunction, TransitionDuration, TransitionProperty } from "../fable_modules/Fss-lib.Core.1.0.2/css/Transition.fs.js";
import { pct, ms, px, sec } from "../fable_modules/Fss-lib.Core.1.0.2/Functions.fs.js";
import { AnimationClasses_AnimationTimingFunction__get_linear, AnimationClasses_AnimationTimingFunction__get_ease } from "../fable_modules/Fss-lib.Core.1.0.2/Types/Animation.fs.js";
import { Hover } from "../fable_modules/Fss-lib.Core.1.0.2/css/PseudoClass.fs.js";
import { ofArray, singleton } from "../fable_modules/fable-library.3.7.9/List.js";
import { unitHelpers_DirectionalLength__value_Z498FEB3B, unitHelpers_CssRuleWithAutoLength__value_Z498FEB3B } from "../fable_modules/Fss-lib.Core.1.0.2/Types/Units.fs.js";
import { Height, Width } from "../fable_modules/Fss-lib.Core.1.0.2/css/ContentSize.fs.js";
import { BorderRadius } from "../fable_modules/Fss-lib.Core.1.0.2/css/Border.fs.js";
import { createElement } from "react";
import { Page } from "./Page.js";
import { Page as Page_1 } from "../Pages.js";

export function Transition() {
    const colorTransition = fss(ofArray([Label_Label("Color Transition"), ColorClass_Color__get_red(BackgroundColor), TransitionProperty__get_backgroundColor(TransitionProperty), TransitionDuration__value_74CCD5DD(TransitionDuration, sec(2.5)), AnimationClasses_AnimationTimingFunction__get_ease(TransitionTimingFunction), Hover(singleton(ColorClass_Color__get_green(BackgroundColor)))]));
    const sizeAndColor = fss(ofArray([Label_Label("Size and Color"), unitHelpers_CssRuleWithAutoLength__value_Z498FEB3B(Width, px(40)), unitHelpers_CssRuleWithAutoLength__value_Z498FEB3B(Height, px(40)), ColorClass_Color__get_yellowGreen(BackgroundColor), TransitionProperty__get_all(TransitionProperty), AnimationClasses_AnimationTimingFunction__get_linear(TransitionTimingFunction), TransitionDuration__value_74CCD5DD(TransitionDuration, ms(500)), Hover(ofArray([unitHelpers_DirectionalLength__value_Z498FEB3B(BorderRadius, pct(100)), ColorClass_Color__get_orangeRed(BackgroundColor)]))]));
    const styles = ofArray([createElement("div", {
        className: colorTransition,
        children: "Hover me",
    }), createElement("div", {
        className: sizeAndColor,
    })]);
    return createElement(Page, {
        page: new Page_1(8),
        styles: styles,
    });
}

export default (() => createElement(Transition, null));

//# sourceMappingURL=Transition.js.map
