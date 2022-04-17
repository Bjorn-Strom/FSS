import { fss, keyframes } from "../fable_modules/Fss-lib.Fable.1.0.1/FssFable.fs.js";
import { frame } from "../fable_modules/Fss-lib.Core.1.0.2/css/Keyframes.fs.js";
import { SvgClasses_StrokeWidth__value_Z498FEB3B, SvgClasses_StrokeDash__value_Z3DDD5B6A } from "../fable_modules/Fss-lib.Core.1.0.2/Types/Svg.fs.js";
import { ofArray, singleton } from "../fable_modules/fable-library.3.7.9/List.js";
import { StrokeDasharray, StrokeWidth, Stroke, StrokeDashoffset } from "../fable_modules/Fss-lib.Core.1.0.2/css/Svg.fs.js";
import { logo } from "../Logo.js";
import { ColorClass_Color__get_black } from "../fable_modules/Fss-lib.Core.1.0.2/Types/Color.fs.js";
import { sec, px } from "../fable_modules/Fss-lib.Core.1.0.2/Functions.fs.js";
import { AnimationClasses_AnimationFillMode__get_forwards, AnimationClasses_AnimationTimingFunction__get_linear, AnimationClasses_AnimationName__value_Z721C83C5 } from "../fable_modules/Fss-lib.Core.1.0.2/Types/Animation.fs.js";
import { AnimationFillMode, AnimationTimingFunction, AnimationDuration, AnimationName } from "../fable_modules/Fss-lib.Core.1.0.2/css/Animation.fs.js";
import { CssRuleWithValueFunctions$1__value_2B595 } from "../fable_modules/Fss-lib.Core.1.0.2/Types/MasterTypes.fs.js";
import { createElement } from "react";
import { Page } from "./Page.js";
import { Page as Page_1 } from "../Pages.js";

export function Svg() {
    const logoAnimation = keyframes(singleton(frame(100, singleton(SvgClasses_StrokeDash__value_Z3DDD5B6A(StrokeDashoffset, singleton(0))))));
    const styles = singleton(logo(256, 256, fss(ofArray([ColorClass_Color__get_black(Stroke), SvgClasses_StrokeWidth__value_Z498FEB3B(StrokeWidth, px(4)), SvgClasses_StrokeDash__value_Z3DDD5B6A(StrokeDashoffset, singleton(1000)), SvgClasses_StrokeDash__value_Z3DDD5B6A(StrokeDasharray, singleton(1000)), AnimationClasses_AnimationName__value_Z721C83C5(AnimationName, logoAnimation), CssRuleWithValueFunctions$1__value_2B595(AnimationDuration, sec(5)), AnimationClasses_AnimationTimingFunction__get_linear(AnimationTimingFunction), AnimationClasses_AnimationFillMode__get_forwards(AnimationFillMode)]))));
    return createElement(Page, {
        page: new Page_1(16),
        styles: styles,
    });
}

export default (() => createElement(Svg, null));

