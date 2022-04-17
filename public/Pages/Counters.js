import { fss, counterStyle } from "../fable_modules/Fss-lib.Fable.1.0.1/FssFable.fs.js";
import { CounterClasses_CounterIncrement__value_Z721C83C5, CounterClasses_CounterReset__value_Z721C83C5, CounterClasses_FixClass__value_Z721C83C5, CounterClasses_SymbolsClass__value_1334CEF1, CounterClasses_SystemClass__get_fixed$0027 } from "../fable_modules/Fss-lib.Core.1.0.2/Types/CounterStyle.fs.js";
import { CounterIncrement, CounterReset, CounterLabel, Suffix, Symbols, System } from "../fable_modules/Fss-lib.Core.1.0.2/css/CounterStyle.fs.js";
import { singleton, ofArray } from "../fable_modules/fable-library.3.7.9/List.js";
import { ContentCss_Content, Label_Label } from "../fable_modules/Fss-lib.Core.1.0.2/css/Content.fs.js";
import { ListStyleClasses_ListStyleType__value_Z721C83C5 } from "../fable_modules/Fss-lib.Core.1.0.2/Types/ListStyle.fs.js";
import { ListStyleType } from "../fable_modules/Fss-lib.Core.1.0.2/css/ListStyle.fs.js";
import { FontClasses_FontWeight__value_Z524259A4, FontClasses_FontFamily__value_Z721C83C5 } from "../fable_modules/Fss-lib.Core.1.0.2/Types/Font.fs.js";
import { FontWeight, FontFamily } from "../fable_modules/Fss-lib.Core.1.0.2/css/Font.fs.js";
import { ColorClass_Color__hex_Z721C83C5 } from "../fable_modules/Fss-lib.Core.1.0.2/Types/Color.fs.js";
import { Color } from "../fable_modules/Fss-lib.Core.1.0.2/css/Color.fs.js";
import { unitHelpers_CssRuleWithAutoLength__value_Z498FEB3B, unitHelpers_CssRuleWithLength__value_Z498FEB3B, unitHelpers_DirectionalLength__value_3202B9A0, unitHelpers_DirectionalLength__value_Z3BD6069B } from "../fable_modules/Fss-lib.Core.1.0.2/Types/Units.fs.js";
import { em, px } from "../fable_modules/Fss-lib.Core.1.0.2/Functions.fs.js";
import { MarginRight, Margin } from "../fable_modules/Fss-lib.Core.1.0.2/css/Margin.fs.js";
import { Padding } from "../fable_modules/Fss-lib.Core.1.0.2/css/Padding.fs.js";
import { singleton as singleton_1, append, delay, toList } from "../fable_modules/fable-library.3.7.9/Seq.js";
import { BackgroundColor } from "../fable_modules/Fss-lib.Core.1.0.2/css/Background.fs.js";
import { Before } from "../fable_modules/Fss-lib.Core.1.0.2/css/PseudoElement.fs.js";
import { ContentClasses_Content__counter_6AFA63E0, ContentClasses_Content__counter_Z384F8060 } from "../fable_modules/Fss-lib.Core.1.0.2/Types/Content.fs.js";
import { TextIndent } from "../fable_modules/Fss-lib.Core.1.0.2/css/Text.fs.js";
import { createElement } from "react";
import { createObj } from "../fable_modules/fable-library.3.7.9/Util.js";
import { Interop_reactApi } from "../fable_modules/Feliz.1.57.0/Interop.fs.js";
import { Page } from "./Page.js";
import { Page as Page_1 } from "../Pages.js";

export function Counters() {
    let elems, elems_1;
    const mozillaExampleCounter = counterStyle(ofArray([CounterClasses_SystemClass__get_fixed$0027(System), CounterClasses_SymbolsClass__value_1334CEF1(Symbols, ofArray(["Ⓐ", "Ⓑ", "Ⓒ", "Ⓓ", "Ⓔ", "Ⓕ", "Ⓖ", "Ⓗ", "Ⓘ", "Ⓙ", "Ⓚ", "Ⓛ", "Ⓜ", "Ⓝ", "Ⓞ", "Ⓟ", "Ⓠ", "Ⓡ", "Ⓢ", "Ⓣ", "Ⓤ", "Ⓥ", "Ⓦ", "Ⓧ", "Ⓨ", "Ⓩ"])), CounterClasses_FixClass__value_Z721C83C5(Suffix, " ")]));
    const mozillaExampleStyle = fss(ofArray([Label_Label("Mozilla Example Style"), ListStyleClasses_ListStyleType__value_Z721C83C5(ListStyleType, mozillaExampleCounter)]));
    const indexCounter = counterStyle(singleton(CounterLabel("indexCounter")));
    const subCounter = counterStyle(singleton(CounterLabel("subCounter")));
    const sectionStyle = fss(ofArray([Label_Label("Section"), FontClasses_FontFamily__value_Z721C83C5(FontFamily, "Roboto, sans-serif"), CounterClasses_CounterReset__value_Z721C83C5(CounterReset, indexCounter)]));
    const commonBefore = ofArray([FontClasses_FontWeight__value_Z524259A4(FontWeight, 500), ColorClass_Color__hex_Z721C83C5(Color, "48f")]);
    const commonStyle = ofArray([unitHelpers_DirectionalLength__value_Z3BD6069B(Margin, px(0), px(0), px(1)), unitHelpers_DirectionalLength__value_3202B9A0(Padding, px(5), px(10))]);
    const count = fss(toList(delay(() => append(singleton_1(Label_Label("Count")), delay(() => append(commonStyle, delay(() => append(singleton_1(CounterClasses_CounterReset__value_Z721C83C5(CounterReset, subCounter)), delay(() => append(singleton_1(CounterClasses_CounterIncrement__value_Z721C83C5(CounterIncrement, indexCounter)), delay(() => append(singleton_1(ColorClass_Color__hex_Z721C83C5(BackgroundColor, "#222426")), delay(() => singleton_1(Before(toList(delay(() => append(commonBefore, delay(() => singleton_1(ContentClasses_Content__counter_Z384F8060(ContentCss_Content, indexCounter, ". ")))))))))))))))))))));
    const sub = fss(toList(delay(() => append(singleton_1(Label_Label("Sub")), delay(() => append(commonStyle, delay(() => append(singleton_1(CounterClasses_CounterIncrement__value_Z721C83C5(CounterIncrement, subCounter)), delay(() => append(singleton_1(unitHelpers_CssRuleWithLength__value_Z498FEB3B(TextIndent, em(1))), delay(() => append(singleton_1(ColorClass_Color__hex_Z721C83C5(Color, "BDB7AF")), delay(() => singleton_1(Before(toList(delay(() => append(commonBefore, delay(() => append(singleton_1(ContentClasses_Content__counter_6AFA63E0(ContentCss_Content, ofArray([indexCounter, subCounter]), ofArray([".", "."]))), delay(() => singleton_1(unitHelpers_CssRuleWithAutoLength__value_Z498FEB3B(MarginRight, px(5))))))))))))))))))))))));
    const styles = ofArray([createElement("ul", createObj(ofArray([["className", mozillaExampleStyle], (elems = [createElement("li", {
        children: ["one"],
    }), createElement("li", {
        children: ["two"],
    }), createElement("li", {
        children: ["three"],
    }), createElement("li", {
        children: ["four"],
    }), createElement("li", {
        children: ["five"],
    }), createElement("li", {
        children: ["one"],
    }), createElement("li", {
        children: ["two"],
    }), createElement("li", {
        children: ["three"],
    }), createElement("li", {
        children: ["four"],
    }), createElement("li", {
        children: ["five"],
    }), createElement("li", {
        children: ["one"],
    }), createElement("li", {
        children: ["two"],
    }), createElement("li", {
        children: ["three"],
    }), createElement("li", {
        children: ["four"],
    }), createElement("li", {
        children: ["five"],
    }), createElement("li", {
        children: ["one"],
    }), createElement("li", {
        children: ["two"],
    }), createElement("li", {
        children: ["three"],
    }), createElement("li", {
        children: ["four"],
    }), createElement("li", {
        children: ["five"],
    }), createElement("li", {
        children: ["one"],
    }), createElement("li", {
        children: ["two"],
    }), createElement("li", {
        children: ["three"],
    }), createElement("li", {
        children: ["four"],
    }), createElement("li", {
        children: ["five"],
    }), createElement("li", {
        children: ["one"],
    }), createElement("li", {
        children: ["two"],
    }), createElement("li", {
        children: ["three"],
    }), createElement("li", {
        children: ["four"],
    }), createElement("li", {
        children: ["five"],
    })], ["children", Interop_reactApi.Children.toArray(Array.from(elems))])]))), createElement("section", createObj(ofArray([["className", sectionStyle], (elems_1 = [createElement("p", {
        className: count,
        children: "Item",
    }), createElement("p", {
        className: count,
        children: "Item",
    }), createElement("p", {
        className: count,
        children: "Item",
    }), createElement("p", {
        className: sub,
        children: "Sub-Item",
    }), createElement("p", {
        className: sub,
        children: "Sub-Item",
    }), createElement("p", {
        className: sub,
        children: "Sub-Item",
    }), createElement("p", {
        className: count,
        children: "Item",
    }), createElement("p", {
        className: count,
        children: "Item",
    }), createElement("p", {
        className: sub,
        children: "Sub-Item",
    }), createElement("p", {
        className: sub,
        children: "Sub-Item",
    }), createElement("p", {
        className: count,
        children: "Item",
    }), createElement("p", {
        className: sub,
        children: "Sub-Item",
    }), createElement("p", {
        className: count,
        children: "Item",
    }), createElement("p", {
        className: sub,
        children: "Sub-Item",
    }), createElement("p", {
        className: sub,
        children: "Sub-Item",
    })], ["children", Interop_reactApi.Children.toArray(Array.from(elems_1))])])))]);
    return createElement(Page, {
        page: new Page_1(13),
        styles: styles,
    });
}

export default (() => createElement(Counters, null));

