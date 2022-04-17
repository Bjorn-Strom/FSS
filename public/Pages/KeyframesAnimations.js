import { fss, keyframes } from "../fable_modules/Fss-lib.Fable.1.0.1/FssFable.fs.js";
import { frame, frames } from "../fable_modules/Fss-lib.Core.1.0.2/css/Keyframes.fs.js";
import { singleton, ofArray } from "../fable_modules/fable-library.3.7.9/List.js";
import { TransformClasses_TransformClass__translate3D_Z3BD6069B, TransformClasses_TransformClass__value_ZF56B0F4 } from "../fable_modules/Fss-lib.Core.1.0.2/Types/Transform.fs.js";
import { sec, px } from "../fable_modules/Fss-lib.Core.1.0.2/Functions.fs.js";
import { Transform } from "../fable_modules/Fss-lib.Core.1.0.2/css/Transform.fs.js";
import { ColorClass_Color__get_blue, ColorClass_Color__get_green, ColorClass_Color__get_red } from "../fable_modules/Fss-lib.Core.1.0.2/Types/Color.fs.js";
import { BackgroundColor } from "../fable_modules/Fss-lib.Core.1.0.2/css/Background.fs.js";
import { Label_Label } from "../fable_modules/Fss-lib.Core.1.0.2/css/Content.fs.js";
import { Animation_IterationCount, AnimationClasses_AnimationIterationCount__value_46D9DA4E, AnimationClasses_AnimationName__value_1334CEF1, AnimationClasses_AnimationIterationCount__get_infinite, AnimationClasses_AnimationTimingFunction__get_easeInOut, AnimationClasses_AnimationName__value_Z721C83C5 } from "../fable_modules/Fss-lib.Core.1.0.2/Types/Animation.fs.js";
import { AnimationIterationCount, AnimationTimingFunction, AnimationDuration, AnimationName } from "../fable_modules/Fss-lib.Core.1.0.2/css/Animation.fs.js";
import { CssRuleWithValueFunctions$1__value_Z38D79C61, CssRuleWithValueFunctions$1__value_2B595 } from "../fable_modules/Fss-lib.Core.1.0.2/Types/MasterTypes.fs.js";
import { TimingFunction_Timing } from "../fable_modules/Fss-lib.Core.1.0.2/Types/TimingFunction.fs.js";
import { createElement } from "react";
import { Interop_reactApi } from "../fable_modules/Feliz.1.57.0/Interop.fs.js";
import { Page } from "./Page.js";
import { Page as Page_1 } from "../Pages.js";

export function KeyframesAnimations() {
    let children;
    const bounceFrames = keyframes(ofArray([frames(ofArray([0, 20, 53, 80, 100]), singleton(TransformClasses_TransformClass__value_ZF56B0F4(Transform, singleton(TransformClasses_TransformClass__translate3D_Z3BD6069B(Transform, px(0), px(0), px(0)))))), frames(ofArray([40, 43]), singleton(TransformClasses_TransformClass__value_ZF56B0F4(Transform, singleton(TransformClasses_TransformClass__translate3D_Z3BD6069B(Transform, px(0), px(-30), px(0)))))), frame(70, singleton(TransformClasses_TransformClass__value_ZF56B0F4(Transform, singleton(TransformClasses_TransformClass__translate3D_Z3BD6069B(Transform, px(0), px(-15), px(0)))))), frame(90, singleton(TransformClasses_TransformClass__value_ZF56B0F4(Transform, singleton(TransformClasses_TransformClass__translate3D_Z3BD6069B(Transform, px(0), px(-4), px(0))))))]));
    const backgroundColorFrames = keyframes(ofArray([frame(0, singleton(ColorClass_Color__get_red(BackgroundColor))), frame(30, singleton(ColorClass_Color__get_green(BackgroundColor))), frame(60, singleton(ColorClass_Color__get_blue(BackgroundColor))), frame(100, singleton(ColorClass_Color__get_red(BackgroundColor)))]));
    const bounceAnimation = fss(ofArray([Label_Label("Bounce Animation"), AnimationClasses_AnimationName__value_Z721C83C5(AnimationName, bounceFrames), CssRuleWithValueFunctions$1__value_2B595(AnimationDuration, sec(1)), AnimationClasses_AnimationTimingFunction__get_easeInOut(AnimationTimingFunction), AnimationClasses_AnimationIterationCount__get_infinite(AnimationIterationCount)]));
    const bouncyColor = fss(ofArray([Label_Label("Bouncy Color"), AnimationClasses_AnimationName__value_1334CEF1(AnimationName, ofArray([bounceFrames, backgroundColorFrames])), CssRuleWithValueFunctions$1__value_Z38D79C61(AnimationDuration, ofArray([sec(1), sec(5)])), CssRuleWithValueFunctions$1__value_Z38D79C61(AnimationTimingFunction, ofArray([new TimingFunction_Timing(3), new TimingFunction_Timing(0)])), AnimationClasses_AnimationIterationCount__value_46D9DA4E(AnimationIterationCount, ofArray([new Animation_IterationCount(0), new Animation_IterationCount(1, 3)]))]));
    const styles = singleton((children = ofArray([createElement("div", {
        className: bounceAnimation,
        children: "Bouncy bounce",
    }), createElement("div", {
        className: bouncyColor,
        children: "Bouncy color",
    })]), createElement("div", {
        children: Interop_reactApi.Children.toArray(Array.from(children)),
    })));
    return createElement(Page, {
        page: new Page_1(9),
        styles: styles,
    });
}

export default (() => createElement(KeyframesAnimations, null));

