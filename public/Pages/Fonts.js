import { fontFace, fontFaces, fss } from "../fable_modules/Fss-lib.Fable.1.0.1/FssFable.fs.js";
import { Label_Label } from "../fable_modules/Fss-lib.Core.1.0.2/css/Content.fs.js";
import { FontClasses_FontWeight__get_bold, FontClasses_FontFamily__value_Z721C83C5 } from "../fable_modules/Fss-lib.Core.1.0.2/Types/Font.fs.js";
import { FontWeight as FontWeight_1, FontSize, FontFamily } from "../fable_modules/Fss-lib.Core.1.0.2/css/Font.fs.js";
import { unitHelpers_CssRuleWithLength__value_Z498FEB3B } from "../fable_modules/Fss-lib.Core.1.0.2/Types/Units.fs.js";
import { px } from "../fable_modules/Fss-lib.Core.1.0.2/Functions.fs.js";
import { ofArray } from "../fable_modules/fable-library.3.7.9/List.js";
import { FontFace_Format, FontFaceClasses_Src__sources_Z23FD7E63, FontFaceClasses_FontWeight__get_normal, FontFaceClasses_FontDisplay__get_swap, FontFaceClasses_FontStyle__get_normal, FontFaceClasses_FontWeight__get_bold, FontFaceClasses_Src__truetype_Z721C83C5 } from "../fable_modules/Fss-lib.Core.1.0.2/Types/FontFace.fs.js";
import { FontDisplay, FontStyle, FontWeight, Src } from "../fable_modules/Fss-lib.Core.1.0.2/css/FontFace.fs.js";
import { createElement } from "react";
import { Interop_reactApi } from "../fable_modules/Feliz.1.57.0/Interop.fs.js";
import { Page } from "./Page.js";
import { Page as Page_1 } from "../Pages.js";

export function Fonts() {
    let children;
    const grapeNutsStyle = fss(ofArray([Label_Label("Grape Nuts Style"), FontClasses_FontFamily__value_Z721C83C5(FontFamily, "grapeNuts"), unitHelpers_CssRuleWithLength__value_Z498FEB3B(FontSize, px(24))]));
    const droidSerifFont = fontFaces("DroidSerif", ofArray([ofArray([FontFaceClasses_Src__truetype_Z721C83C5(Src, "https://rawgit.com/google/fonts/master/ufl/ubuntu/Ubuntu-Bold.ttf"), FontFaceClasses_FontWeight__get_bold(FontWeight), FontFaceClasses_FontStyle__get_normal(FontStyle), FontFaceClasses_FontDisplay__get_swap(FontDisplay)]), ofArray([FontFaceClasses_Src__truetype_Z721C83C5(Src, "https://rawgit.com/google/fonts/master/ufl/ubuntumono/UbuntuMono-Italic.ttf"), FontFaceClasses_FontWeight__get_normal(FontWeight), FontFaceClasses_FontStyle__get_normal(FontStyle), FontFaceClasses_FontDisplay__get_swap(FontDisplay)])]));
    const modernaFont = fontFace("moderna", ofArray([FontFaceClasses_Src__sources_Z23FD7E63(Src, ofArray([new FontFace_Format(4, "https://s3-us-west-2.amazonaws.com/s.cdpn.io/133207/moderna_-webfont.woff2"), new FontFace_Format(3, "https://s3-us-west-2.amazonaws.com/s.cdpn.io/133207/moderna_-webfont.woff"), new FontFace_Format(0, "https://s3-us-west-2.amazonaws.com/s.cdpn.io/133207/moderna_-webfont.ttf"), new FontFace_Format(5, "https://s3-us-west-2.amazonaws.com/s.cdpn.io/133207/moderna_-webfont.svg")])), FontFaceClasses_FontWeight__get_normal(FontWeight), FontFaceClasses_FontStyle__get_normal(FontStyle), FontFaceClasses_FontDisplay__get_swap(FontDisplay)]));
    const droidSerif = fss(ofArray([Label_Label("Droid Serif"), FontClasses_FontFamily__value_Z721C83C5(FontFamily, droidSerifFont)]));
    const droidSerifBold = fss(ofArray([Label_Label("Droid Serif Bold"), FontClasses_FontFamily__value_Z721C83C5(FontFamily, droidSerifFont), FontClasses_FontWeight__get_bold(FontWeight_1)]));
    const moderna = fss(ofArray([Label_Label("Moderna"), FontClasses_FontFamily__value_Z721C83C5(FontFamily, modernaFont)]));
    const styles = ofArray([createElement("p", {
        className: grapeNutsStyle,
        children: "This font is Grape Nuts, some nice text this huh?",
    }), (children = ofArray([createElement("p", {
        children: "Droid serif",
        className: droidSerif,
    }), createElement("p", {
        children: "Droid serif bold",
        className: droidSerifBold,
    }), createElement("p", {
        children: "Moderna",
        className: moderna,
    })]), createElement("div", {
        children: Interop_reactApi.Children.toArray(Array.from(children)),
    }))]);
    return createElement(Page, {
        page: new Page_1(14),
        styles: styles,
    });
}

export default (() => createElement(Fonts, null));

