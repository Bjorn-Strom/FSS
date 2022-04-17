import { unitHelpers_DirectionalLength__value_Z498FEB3B, unitHelpers_CssRuleWithAutoLength__value_Z498FEB3B } from "../fable_modules/Fss-lib.Core.1.0.2/Types/Units.fs.js";
import { rad, rgba, turn, pct, hex, deg, px } from "../fable_modules/Fss-lib.Core.1.0.2/Functions.fs.js";
import { Height, Width } from "../fable_modules/Fss-lib.Core.1.0.2/css/ContentSize.fs.js";
import { ofArray } from "../fable_modules/fable-library.3.7.9/List.js";
import { fss } from "../fable_modules/Fss-lib.Fable.1.0.1/FssFable.fs.js";
import { singleton, append, delay, toList } from "../fable_modules/fable-library.3.7.9/Seq.js";
import { Label_Label } from "../fable_modules/Fss-lib.Core.1.0.2/css/Content.fs.js";
import { ImageClasses_ImageClass__repeatingConicGradient_C015F99, ImageClasses_ImageClass__conicGradient_Z516D4DFD, ImageClasses_ImageClass__repeatingRadialGradient_64449692, Image_Side, Image_Shape, ImageClasses_ImageClass__radialGradient_64449692, ImageClasses_ImageClass__repeatingLinearGradients_Z62CFBBB6, ImageClasses_ImageClass__repeatingLinearGradient_2BE92E00, ImageClasses_ImageClass__linearGradient_2BE92E00 } from "../fable_modules/Fss-lib.Core.1.0.2/Types/Image.fs.js";
import { BackgroundSize, BackgroundImage } from "../fable_modules/Fss-lib.Core.1.0.2/css/Background.fs.js";
import { ColorClass_Color__get_black, Color_Color } from "../fable_modules/Fss-lib.Core.1.0.2/Types/Color.fs.js";
import { BorderWidth, BorderStyle, BorderColor, BorderRadius } from "../fable_modules/Fss-lib.Core.1.0.2/css/Border.fs.js";
import { BackgroundClasses_BackgroundSize__value_3202B9A0 } from "../fable_modules/Fss-lib.Core.1.0.2/Types/Background.fs.js";
import { BorderClasses_BorderStyleParent__get_solid } from "../fable_modules/Fss-lib.Core.1.0.2/Types/Border.fs.js";
import { createElement } from "react";
import { createObj } from "../fable_modules/fable-library.3.7.9/Util.js";
import { DisplayClasses_DisplayClass__get_flex } from "../fable_modules/Fss-lib.Core.1.0.2/Types/Display.fs.js";
import { Display } from "../fable_modules/Fss-lib.Core.1.0.2/css/Display.fs.js";
import { Interop_reactApi } from "../fable_modules/Feliz.1.57.0/Interop.fs.js";
import { Page } from "./Page.js";
import { Page as Page_1 } from "../Pages.js";

export function BackgroundImages() {
    let elems, elems_1, elems_2, elems_3, elems_4, elems_5;
    const box = ofArray([unitHelpers_CssRuleWithAutoLength__value_Z498FEB3B(Width, px(200)), unitHelpers_CssRuleWithAutoLength__value_Z498FEB3B(Height, px(200))]);
    const linearGradientStyle1 = fss(toList(delay(() => append(singleton(Label_Label("Linear gradient style 1")), delay(() => append(box, delay(() => singleton(ImageClasses_ImageClass__linearGradient_2BE92E00(BackgroundImage, [deg(0), ofArray([[hex("e66465"), pct(0)], [hex("9198e5"), pct(100)]])])))))))));
    const linearGradientStyle2 = fss(toList(delay(() => append(box, delay(() => append(singleton(Label_Label("Linear gradient style 2")), delay(() => singleton(ImageClasses_ImageClass__linearGradient_2BE92E00(BackgroundImage, [turn(0.25), ofArray([[hex("3f87a6"), pct(0)], [hex("ebf8e1"), pct(50)], [hex("f69d3c"), pct(100)]])])))))))));
    const linearGradientStyle3 = fss(toList(delay(() => append(box, delay(() => append(singleton(Label_Label("Linear gradient style 3")), delay(() => singleton(ImageClasses_ImageClass__linearGradient_2BE92E00(BackgroundImage, [deg(270), ofArray([[hex("333"), pct(0)], [hex("333"), pct(50)], [hex("eee"), pct(75)], [hex("333"), pct(75)]])])))))))));
    const repeatingLinearGradientStyle1 = fss(toList(delay(() => append(box, delay(() => append(singleton(Label_Label("Repeating Linear gradient style 1")), delay(() => singleton(ImageClasses_ImageClass__repeatingLinearGradient_2BE92E00(BackgroundImage, [deg(0), ofArray([[hex("e66465"), px(0)], [hex("e66465"), px(20)], [hex("9198e5"), px(20)], [hex("9198e5"), px(25)]])])))))))));
    const repeatingLinearGradientStyle2 = fss(toList(delay(() => append(box, delay(() => append(singleton(Label_Label("Repeating Linear gradient style 2")), delay(() => singleton(ImageClasses_ImageClass__repeatingLinearGradient_2BE92E00(BackgroundImage, [deg(45), ofArray([[hex("3f87a6"), px(0)], [hex("ebf8e1"), px(15)], [hex("f69d3c"), px(20)]])])))))))));
    const repeatingLinearGradientsStyle3 = fss(toList(delay(() => append(box, delay(() => singleton(ImageClasses_ImageClass__repeatingLinearGradients_Z62CFBBB6(BackgroundImage, ofArray([[deg(217), ofArray([[rgba(255, 0, 0, 0.8), pct(0)], [rgba(255, 0, 0, 0), pct(70)]])], [deg(127), ofArray([[rgba(0, 255, 0, 0.8), pct(0)], [rgba(0, 255, 0, 0), pct(70)]])], [deg(336), ofArray([[rgba(0, 0, 255, 0.8), pct(0)], [rgba(0, 0, 255, 0), pct(70)]])]]))))))));
    const radialGradientStyle1 = fss(toList(delay(() => append(box, delay(() => append(singleton(Label_Label("Radial Gradient style 1")), delay(() => singleton(ImageClasses_ImageClass__radialGradient_64449692(BackgroundImage, new Image_Shape(1), new Image_Side(3), pct(50), pct(50), ofArray([[hex("e66465"), pct(0)], [hex("9198e5"), pct(100)]]))))))))));
    const radialGradientStyle2 = fss(toList(delay(() => append(singleton(Label_Label("Radial Gradient style 2")), delay(() => append(box, delay(() => singleton(ImageClasses_ImageClass__radialGradient_64449692(BackgroundImage, new Image_Shape(1), new Image_Side(0), pct(50), pct(50), ofArray([[hex("3f87a6"), pct(0)], [hex("ebf8e1"), pct(50)], [hex("f69d3c"), pct(100)]]))))))))));
    const radialGradientStyle3 = fss(toList(delay(() => append(box, delay(() => append(singleton(Label_Label("Radial Gradient style 3")), delay(() => singleton(ImageClasses_ImageClass__radialGradient_64449692(BackgroundImage, new Image_Shape(0), new Image_Side(3), pct(100), pct(50), ofArray([[hex("333"), pct(0)], [hex("333"), pct(50)], [hex("eee"), pct(75)], [hex("333"), pct(75)]]))))))))));
    const repeatingRadialGradientStyle1 = fss(toList(delay(() => append(singleton(Label_Label("Repeating Radial Gradient style 1")), delay(() => append(box, delay(() => singleton(ImageClasses_ImageClass__repeatingRadialGradient_64449692(BackgroundImage, new Image_Shape(1), new Image_Side(3), pct(50), pct(50), ofArray([[hex("e66465"), pct(0)], [hex("9198e5"), pct(20)]]))))))))));
    const repeatingRadialGradientStyle2 = fss(toList(delay(() => append(singleton(Label_Label("Repeating Radial Gradient style 2")), delay(() => append(box, delay(() => singleton(ImageClasses_ImageClass__repeatingRadialGradient_64449692(BackgroundImage, new Image_Shape(1), new Image_Side(0), pct(50), pct(50), ofArray([[hex("3f87a6"), pct(0)], [hex("ebf8e1"), pct(50)], [hex("f69d3c"), pct(100)]]))))))))));
    const repeatingRadialGradientStyle3 = fss(toList(delay(() => append(singleton(Label_Label("Repeating Radial Gradient style 3")), delay(() => append(box, delay(() => singleton(ImageClasses_ImageClass__repeatingRadialGradient_64449692(BackgroundImage, new Image_Shape(0), new Image_Side(3), pct(100), pct(50), ofArray([[hex("333"), px(0)], [hex("333"), px(10)], [hex("eee"), px(10)], [hex("eee"), px(20)]]))))))))));
    const conicGradientStyle1 = fss(toList(delay(() => append(singleton(Label_Label("Conic gradient style 1")), delay(() => append(box, delay(() => singleton(ImageClasses_ImageClass__conicGradient_Z516D4DFD(BackgroundImage, deg(0), pct(50), pct(50), ofArray([[new Color_Color(5), deg(0)], [new Color_Color(16), deg(90)], [new Color_Color(11), deg(180)], [new Color_Color(8), deg(270)], [new Color_Color(13), deg(360)]]))))))))));
    const conicGradientStyle2 = fss(toList(delay(() => append(singleton(Label_Label("Conic gradient style 2")), delay(() => append(box, delay(() => singleton(ImageClasses_ImageClass__conicGradient_Z516D4DFD(BackgroundImage, rad(3.1416), pct(10), pct(50), ofArray([[hex("#e66465"), deg(0)], [hex("#9198e5"), deg(360)]]))))))))));
    const conicGradientStyle3 = fss(toList(delay(() => append(singleton(Label_Label("Conic gradient style 3")), delay(() => append(box, delay(() => singleton(ImageClasses_ImageClass__conicGradient_Z516D4DFD(BackgroundImage, deg(0), pct(50), pct(50), ofArray([[new Color_Color(5), deg(6)], [new Color_Color(16), deg(6)], [new Color_Color(16), deg(18)], [new Color_Color(11), deg(18)], [new Color_Color(11), deg(45)], [new Color_Color(8), deg(45)], [new Color_Color(8), deg(110)], [new Color_Color(13), deg(110)], [new Color_Color(13), deg(200)], [new Color_Color(6), deg(200)]]))))))))));
    const conicGradientStyle4 = fss(toList(delay(() => append(singleton(Label_Label("Conic gradient style 4")), delay(() => append(box, delay(() => append(singleton(unitHelpers_DirectionalLength__value_Z498FEB3B(BorderRadius, px(200))), delay(() => singleton(ImageClasses_ImageClass__conicGradient_Z516D4DFD(BackgroundImage, deg(0), pct(50), pct(50), ofArray([[new Color_Color(11), deg(360 / 6)], [new Color_Color(9), deg((360 / 6) * 2)], [new Color_Color(13), deg((360 / 6) * 3)], [new Color_Color(138), deg((360 / 6) * 4)], [new Color_Color(5), deg((360 / 6) * 5)], [new Color_Color(11), deg((360 / 6) * 6)]]))))))))))));
    const repeatingConicGradientStyle = fss(toList(delay(() => append(singleton(Label_Label("Repeating conic gradient style")), delay(() => append(box, delay(() => append(singleton(BackgroundClasses_BackgroundSize__value_3202B9A0(BackgroundSize, px(50), px(50))), delay(() => append(singleton(ColorClass_Color__get_black(BorderColor)), delay(() => append(singleton(BorderClasses_BorderStyleParent__get_solid(BorderStyle)), delay(() => append(singleton(unitHelpers_DirectionalLength__value_Z498FEB3B(BorderWidth, px(1))), delay(() => singleton(ImageClasses_ImageClass__repeatingConicGradient_C015F99(BackgroundImage, deg(0), pct(50), pct(50), ofArray([[new Color_Color(3), pct(0)], [new Color_Color(3), pct(25)], [new Color_Color(0), pct(25)], [new Color_Color(0), pct(50)]]))))))))))))))))));
    const styles = ofArray([createElement("div", createObj(ofArray([["className", fss(ofArray([Label_Label("Flex 1"), DisplayClasses_DisplayClass__get_flex(Display)]))], (elems = [createElement("div", {
        className: linearGradientStyle1,
    }), createElement("div", {
        className: linearGradientStyle2,
    }), createElement("div", {
        className: linearGradientStyle3,
    })], ["children", Interop_reactApi.Children.toArray(Array.from(elems))])]))), createElement("div", createObj(ofArray([["className", fss(ofArray([Label_Label("Flex 2"), DisplayClasses_DisplayClass__get_flex(Display)]))], (elems_1 = [createElement("div", {
        className: repeatingLinearGradientStyle1,
    }), createElement("div", {
        className: repeatingLinearGradientStyle2,
    }), createElement("div", {
        className: repeatingLinearGradientsStyle3,
    })], ["children", Interop_reactApi.Children.toArray(Array.from(elems_1))])]))), createElement("div", createObj(ofArray([["className", fss(ofArray([Label_Label("Flex 3"), DisplayClasses_DisplayClass__get_flex(Display)]))], (elems_2 = [createElement("div", {
        className: radialGradientStyle1,
    }), createElement("div", {
        className: radialGradientStyle2,
    }), createElement("div", {
        className: radialGradientStyle3,
    })], ["children", Interop_reactApi.Children.toArray(Array.from(elems_2))])]))), createElement("div", createObj(ofArray([["className", fss(ofArray([Label_Label("Flex 4"), DisplayClasses_DisplayClass__get_flex(Display)]))], (elems_3 = [createElement("div", {
        className: repeatingRadialGradientStyle1,
    }), createElement("div", {
        className: repeatingRadialGradientStyle2,
    }), createElement("div", {
        className: repeatingRadialGradientStyle3,
    })], ["children", Interop_reactApi.Children.toArray(Array.from(elems_3))])]))), createElement("div", createObj(ofArray([["className", fss(ofArray([Label_Label("Flex 1"), DisplayClasses_DisplayClass__get_flex(Display)]))], (elems_4 = [createElement("div", {
        className: conicGradientStyle1,
    }), createElement("div", {
        className: conicGradientStyle2,
    }), createElement("div", {
        className: conicGradientStyle3,
    }), createElement("div", {
        className: conicGradientStyle4,
    })], ["children", Interop_reactApi.Children.toArray(Array.from(elems_4))])]))), createElement("div", createObj(ofArray([["className", fss(ofArray([Label_Label("Flex 1"), DisplayClasses_DisplayClass__get_flex(Display)]))], (elems_5 = [createElement("div", {
        className: repeatingConicGradientStyle,
    })], ["children", Interop_reactApi.Children.toArray(Array.from(elems_5))])])))]);
    return createElement(Page, {
        page: new Page_1(15),
        styles: styles,
    });
}

export default (() => createElement(BackgroundImages, null));

//# sourceMappingURL=BackgroundImages.js.map
