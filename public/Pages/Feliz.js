import { keyframes } from "../fable_modules/Fss-lib.Fable.1.0.1/FssFable.fs.js";
import { frame, frames } from "../fable_modules/Fss-lib.Core.1.0.2/css/Keyframes.fs.js";
import { singleton, ofArray } from "../fable_modules/fable-library.3.7.9/List.js";
import { TransformClasses_TransformClass__translate3D_Z3BD6069B, TransformClasses_TransformClass__value_ZF56B0F4 } from "../fable_modules/Fss-lib.Core.1.0.2/Types/Transform.fs.js";
import { sec, px } from "../fable_modules/Fss-lib.Core.1.0.2/Functions.fs.js";
import { Transform } from "../fable_modules/Fss-lib.Core.1.0.2/css/Transform.fs.js";
import { createElement } from "react";
import { createObj } from "../fable_modules/fable-library.3.7.9/Util.js";
import { Feliz_prop__prop_fss_Static_72C268A9 } from "../fable_modules/Fss-lib.Feliz.1.0.1/FssFeliz.fs.js";
import { ColorClass_Color__get_blue, ColorClass_Color__get_red } from "../fable_modules/Fss-lib.Core.1.0.2/Types/Color.fs.js";
import { BackgroundColor } from "../fable_modules/Fss-lib.Core.1.0.2/css/Background.fs.js";
import { unitHelpers_CssRuleWithAutoLength__value_Z498FEB3B } from "../fable_modules/Fss-lib.Core.1.0.2/Types/Units.fs.js";
import { Height, Width } from "../fable_modules/Fss-lib.Core.1.0.2/css/ContentSize.fs.js";
import { Hover } from "../fable_modules/Fss-lib.Core.1.0.2/css/PseudoClass.fs.js";
import { AnimationClasses_AnimationIterationCount__get_infinite, AnimationClasses_AnimationTimingFunction__get_easeInOut, AnimationClasses_AnimationName__value_Z721C83C5 } from "../fable_modules/Fss-lib.Core.1.0.2/Types/Animation.fs.js";
import { AnimationIterationCount, AnimationTimingFunction, AnimationDuration, AnimationName } from "../fable_modules/Fss-lib.Core.1.0.2/css/Animation.fs.js";
import { CssRuleWithValueFunctions$1__value_2B595 } from "../fable_modules/Fss-lib.Core.1.0.2/Types/MasterTypes.fs.js";
import { Page } from "./Page.js";
import { Page as Page_1 } from "../Pages.js";

export function Feliz() {
    const bounceFrames = keyframes(ofArray([frames(ofArray([0, 20, 53, 80, 100]), singleton(TransformClasses_TransformClass__value_ZF56B0F4(Transform, singleton(TransformClasses_TransformClass__translate3D_Z3BD6069B(Transform, px(0), px(0), px(0)))))), frames(ofArray([40, 43]), singleton(TransformClasses_TransformClass__value_ZF56B0F4(Transform, singleton(TransformClasses_TransformClass__translate3D_Z3BD6069B(Transform, px(0), px(-30), px(0)))))), frame(70, singleton(TransformClasses_TransformClass__value_ZF56B0F4(Transform, singleton(TransformClasses_TransformClass__translate3D_Z3BD6069B(Transform, px(0), px(-15), px(0)))))), frame(90, singleton(TransformClasses_TransformClass__value_ZF56B0F4(Transform, singleton(TransformClasses_TransformClass__translate3D_Z3BD6069B(Transform, px(0), px(-4), px(0))))))]));
    const box = createElement("div", createObj(singleton(Feliz_prop__prop_fss_Static_72C268A9(ofArray([ColorClass_Color__get_red(BackgroundColor), unitHelpers_CssRuleWithAutoLength__value_Z498FEB3B(Width, px(200)), unitHelpers_CssRuleWithAutoLength__value_Z498FEB3B(Height, px(200)), Hover(singleton(ColorClass_Color__get_blue(BackgroundColor)))])))));
    const bounceBox = createElement("div", createObj(singleton(Feliz_prop__prop_fss_Static_72C268A9(ofArray([ColorClass_Color__get_red(BackgroundColor), unitHelpers_CssRuleWithAutoLength__value_Z498FEB3B(Width, px(200)), unitHelpers_CssRuleWithAutoLength__value_Z498FEB3B(Height, px(200)), Hover(singleton(ColorClass_Color__get_blue(BackgroundColor))), AnimationClasses_AnimationName__value_Z721C83C5(AnimationName, bounceFrames), CssRuleWithValueFunctions$1__value_2B595(AnimationDuration, sec(1)), AnimationClasses_AnimationTimingFunction__get_easeInOut(AnimationTimingFunction), AnimationClasses_AnimationIterationCount__get_infinite(AnimationIterationCount)])))));
    const styles = ofArray([box, bounceBox]);
    return createElement(Page, {
        page: new Page_1(19),
        styles: styles,
    });
}

export default (() => createElement(Feliz, null));

//# sourceMappingURL=Feliz.js.map
