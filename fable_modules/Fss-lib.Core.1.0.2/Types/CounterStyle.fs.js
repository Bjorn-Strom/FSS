import { Union, toString } from "../../fable-library.3.7.9/Types.js";
import { class_type, list_type, tuple_type, union_type, string_type, int32_type } from "../../fable-library.3.7.9/Reflection.js";
import { CssRuleWithNone$reflection, CssRuleWithNone, String$, Auto, Property_CounterProperty, Stringed, MasterTypeHelpers_stringifyICounterValue, Stringed$reflection, MasterTypeHelpers_stringifyICssValue } from "./MasterTypes.fs.js";
import { int32ToString } from "../../fable-library.3.7.9/Util.js";
import { join } from "../../fable-library.3.7.9/String.js";
import { singleton, map } from "../../fable-library.3.7.9/List.js";
import { Helpers_toKebabCase } from "../Utilities.fs.js";
import { Image_Image, ImageClasses_Image_linearGradients_Z62CFBBB6, ImageClasses_Image_linearGradient_2BE92E00, ImageClasses_Image_url_Z721C83C5, Image_Image$reflection } from "./Image.fs.js";

export class Counter_System extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["Cyclic", "Numeric", "Alphabetic", "Symbolic", "Additive", "Fixed", "FixedValue", "Extends"];
    }
    StringifyCounter() {
        const this$ = this;
        switch (this$.tag) {
            case 6: {
                const value = this$.fields[0] | 0;
                return `fixed ${value}`;
            }
            case 7: {
                const extends$ = this$.fields[0];
                return `extends ${extends$}`;
            }
            default: {
                return toString(this$).toLocaleLowerCase();
            }
        }
    }
}

export function Counter_System$reflection() {
    return union_type("Fss.Types.Counter.System", [], Counter_System, () => [[], [], [], [], [], [], [["Item", int32_type]], [["Item", string_type]]]);
}

export class Counter_Negative extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["One", "Two"];
    }
    StringifyCounter() {
        const this$ = this;
        if (this$.tag === 1) {
            const b = this$.fields[1];
            const a = this$.fields[0];
            return `${MasterTypeHelpers_stringifyICssValue(a)} ${MasterTypeHelpers_stringifyICssValue(b)}`;
        }
        else {
            const s = this$.fields[0];
            return MasterTypeHelpers_stringifyICssValue(s);
        }
    }
}

export function Counter_Negative$reflection() {
    return union_type("Fss.Types.Counter.Negative", [], Counter_Negative, () => [[["Item", Stringed$reflection()]], [["Item1", Stringed$reflection()], ["Item2", Stringed$reflection()]]]);
}

export class Counter_Range extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["Infinite", "Range\u0027", "Ranges"];
    }
    StringifyCounter() {
        const this$ = this;
        switch (this$.tag) {
            case 1: {
                const i = this$.fields[0] | 0;
                return int32ToString(i);
            }
            case 2: {
                const is = this$.fields[0];
                return join(", ", map((tupledArg) => {
                    const a = tupledArg[0];
                    const b = tupledArg[1];
                    return `${MasterTypeHelpers_stringifyICounterValue(a)} ${MasterTypeHelpers_stringifyICounterValue(b)}`;
                }, is));
            }
            default: {
                return "infinite";
            }
        }
    }
}

export function Counter_Range$reflection() {
    return union_type("Fss.Types.Counter.Range", [], Counter_Range, () => [[], [["Item", int32_type]], [["Item", list_type(tuple_type(Counter_Range$reflection(), Counter_Range$reflection()))]]]);
}

export class Counter_PadType extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["PadType"];
    }
    StringifyCounter() {
        const this$ = this;
        const value = this$.fields[1];
        const pad = this$.fields[0] | 0;
        return `${pad} ${MasterTypeHelpers_stringifyICssValue(value)}`;
    }
}

export function Counter_PadType$reflection() {
    return union_type("Fss.Types.Counter.PadType", [], Counter_PadType, () => [[["Item1", int32_type], ["Item2", Stringed$reflection()]]]);
}

export class Counter_Fallback extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["LowerAlpha", "CustomGangnamStyle"];
    }
    StringifyCounter() {
        const this$ = this;
        return Helpers_toKebabCase(this$);
    }
}

export function Counter_Fallback$reflection() {
    return union_type("Fss.Types.Counter.Fallback", [], Counter_Fallback, () => [[], []]);
}

export class Counter_Symbols extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["String", "Strings", "Images"];
    }
    StringifyCounter() {
        const this$ = this;
        switch (this$.tag) {
            case 1: {
                const s_1 = this$.fields[0];
                return join(" ", map(MasterTypeHelpers_stringifyICssValue, map((arg0) => (new Stringed(0, arg0)), s_1)));
            }
            case 2: {
                const is = this$.fields[0];
                return join(" ", map(MasterTypeHelpers_stringifyICssValue, is));
            }
            default: {
                const s = this$.fields[0];
                return s;
            }
        }
    }
}

export function Counter_Symbols$reflection() {
    return union_type("Fss.Types.Counter.Symbols", [], Counter_Symbols, () => [[["Item", string_type]], [["Item", list_type(string_type)]], [["Item", list_type(Image_Image$reflection())]]]);
}

export class Counter_AdditiveSymbols extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["AdditiveSymbols"];
    }
    StringifyCounter() {
        const this$ = this;
        const s = this$.fields[0];
        return join(" ", s);
    }
}

export function Counter_AdditiveSymbols$reflection() {
    return union_type("Fss.Types.Counter.AdditiveSymbols", [], Counter_AdditiveSymbols, () => [[["Item", list_type(string_type)]]]);
}

export class Counter_SpeakAs extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["Auto", "Bullets", "Numbers", "Words", "SpellOut", "Value"];
    }
    StringifyCounter() {
        const this$ = this;
        if (this$.tag === 5) {
            const v = this$.fields[0];
            return v;
        }
        else {
            return Helpers_toKebabCase(this$);
        }
    }
}

export function Counter_SpeakAs$reflection() {
    return union_type("Fss.Types.Counter.SpeakAs", [], Counter_SpeakAs, () => [[], [], [], [], [], [["Item", string_type]]]);
}

export class CounterClasses_SystemClass {
    constructor() {
    }
}

export function CounterClasses_SystemClass$reflection() {
    return class_type("Fss.Types.CounterClasses.SystemClass", void 0, CounterClasses_SystemClass);
}

export function CounterClasses_SystemClass_$ctor() {
    return new CounterClasses_SystemClass();
}

export function CounterClasses_SystemClass__get_cyclic(this$) {
    const tupledArg = [new Property_CounterProperty(0), new Counter_System(0)];
    return [tupledArg[0], tupledArg[1]];
}

export function CounterClasses_SystemClass__get_numeric(this$) {
    const tupledArg = [new Property_CounterProperty(0), new Counter_System(1)];
    return [tupledArg[0], tupledArg[1]];
}

export function CounterClasses_SystemClass__get_alphabetic(this$) {
    const tupledArg = [new Property_CounterProperty(0), new Counter_System(2)];
    return [tupledArg[0], tupledArg[1]];
}

export function CounterClasses_SystemClass__get_symbolic(this$) {
    const tupledArg = [new Property_CounterProperty(0), new Counter_System(3)];
    return [tupledArg[0], tupledArg[1]];
}

export function CounterClasses_SystemClass__get_additive(this$) {
    const tupledArg = [new Property_CounterProperty(0), new Counter_System(4)];
    return [tupledArg[0], tupledArg[1]];
}

export function CounterClasses_SystemClass__get_fixed$0027(this$) {
    const tupledArg = [new Property_CounterProperty(0), new Counter_System(5)];
    return [tupledArg[0], tupledArg[1]];
}

export function CounterClasses_SystemClass__fixedValue_Z524259A4(this$, value) {
    const tupledArg = [new Property_CounterProperty(0), new Counter_System(6, value)];
    return [tupledArg[0], tupledArg[1]];
}

export function CounterClasses_SystemClass__extends_Z721C83C5(this$, extends$) {
    const tupledArg = [new Property_CounterProperty(0), new Counter_System(7, extends$)];
    return [tupledArg[0], tupledArg[1]];
}

export class CounterClasses_NegativeClass {
    constructor() {
    }
}

export function CounterClasses_NegativeClass$reflection() {
    return class_type("Fss.Types.CounterClasses.NegativeClass", void 0, CounterClasses_NegativeClass);
}

export function CounterClasses_NegativeClass_$ctor() {
    return new CounterClasses_NegativeClass();
}

export function CounterClasses_NegativeClass__value_Z721C83C5(this$, negative) {
    const tupledArg = [new Property_CounterProperty(1), new Counter_Negative(0, new Stringed(0, negative))];
    return [tupledArg[0], tupledArg[1]];
}

export function CounterClasses_NegativeClass__value_Z384F8060(this$, one, two) {
    const tupledArg = [new Property_CounterProperty(1), new Counter_Negative(1, new Stringed(0, one), new Stringed(0, two))];
    return [tupledArg[0], tupledArg[1]];
}

export class CounterClasses_CounterImage {
    constructor(property) {
        this.property = property;
    }
}

export function CounterClasses_CounterImage$reflection() {
    return class_type("Fss.Types.CounterClasses.CounterImage", void 0, CounterClasses_CounterImage);
}

export function CounterClasses_CounterImage_$ctor_Z237A0E4E(property) {
    return new CounterClasses_CounterImage(property);
}

export function CounterClasses_CounterImage__url_Z721C83C5(this$, url) {
    const tupledArg = [this$.property, ImageClasses_Image_url_Z721C83C5(url)];
    return [tupledArg[0], tupledArg[1]];
}

export function CounterClasses_CounterImage__linearGradient_2BE92E00(this$, gradients) {
    const tupledArg = [this$.property, ImageClasses_Image_linearGradient_2BE92E00(gradients)];
    return [tupledArg[0], tupledArg[1]];
}

export function CounterClasses_CounterImage__linearGradients_Z62CFBBB6(this$, gradients) {
    const tupledArg = [this$.property, ImageClasses_Image_linearGradients_Z62CFBBB6(gradients)];
    return [tupledArg[0], tupledArg[1]];
}

export function CounterClasses_CounterImage__repeatingLinearGradient_2BE92E00(this$, gradients) {
    let tupledArg;
    const tupledArg_1 = [this$.property, (tupledArg = gradients, new Image_Image(4, tupledArg[0], tupledArg[1]))];
    return [tupledArg_1[0], tupledArg_1[1]];
}

export function CounterClasses_CounterImage__repeatingLinearGradients_Z62CFBBB6(this$, gradients) {
    const tupledArg = [this$.property, new Image_Image(5, gradients)];
    return [tupledArg[0], tupledArg[1]];
}

export function CounterClasses_CounterImage__radialGradient_64449692(this$, shape, size, x, y, gradients) {
    const tupledArg = [this$.property, new Image_Image(6, shape, size, x, y, gradients)];
    return [tupledArg[0], tupledArg[1]];
}

export function CounterClasses_CounterImage__radialGradients_544747B8(this$, gradients) {
    const tupledArg = [this$.property, new Image_Image(7, gradients)];
    return [tupledArg[0], tupledArg[1]];
}

export function CounterClasses_CounterImage__repeatingRadialGradient_64449692(this$, shape, size, x, y, gradients) {
    const tupledArg = [this$.property, new Image_Image(8, shape, size, x, y, gradients)];
    return [tupledArg[0], tupledArg[1]];
}

export function CounterClasses_CounterImage__conicGradient_Z516D4DFD(this$, angle, x, y, gradients) {
    const tupledArg = [this$.property, new Image_Image(10, angle, x, y, gradients)];
    return [tupledArg[0], tupledArg[1]];
}

export function CounterClasses_CounterImage__conicGradient_C015F99(this$, angle, x, y, gradients) {
    const tupledArg = [this$.property, new Image_Image(11, angle, x, y, gradients)];
    return [tupledArg[0], tupledArg[1]];
}

export function CounterClasses_CounterImage__repeatingConicGradient_Z516D4DFD(this$, angle, x, y, gradients) {
    const tupledArg = [this$.property, new Image_Image(12, angle, x, y, gradients)];
    return [tupledArg[0], tupledArg[1]];
}

export function CounterClasses_CounterImage__repeatingConicGradient_C015F99(this$, angle, x, y, gradients) {
    const tupledArg = [this$.property, new Image_Image(13, angle, x, y, gradients)];
    return [tupledArg[0], tupledArg[1]];
}

export class CounterClasses_FixClass extends CounterClasses_CounterImage {
    constructor(property) {
        super(property);
        this.property_1 = property;
    }
}

export function CounterClasses_FixClass$reflection() {
    return class_type("Fss.Types.CounterClasses.FixClass", void 0, CounterClasses_FixClass, CounterClasses_CounterImage$reflection());
}

export function CounterClasses_FixClass_$ctor_Z237A0E4E(property) {
    return new CounterClasses_FixClass(property);
}

export function CounterClasses_FixClass__value_Z721C83C5(this$, fix) {
    const tupledArg = [this$.property_1, new Stringed(0, fix)];
    return [tupledArg[0], tupledArg[1]];
}

export class CounterClasses_RangeClass {
    constructor() {
    }
}

export function CounterClasses_RangeClass$reflection() {
    return class_type("Fss.Types.CounterClasses.RangeClass", void 0, CounterClasses_RangeClass);
}

export function CounterClasses_RangeClass_$ctor() {
    return new CounterClasses_RangeClass();
}

export function CounterClasses_RangeClass__get_auto(this$) {
    const tupledArg = [new Property_CounterProperty(4), new Auto(0)];
    return [tupledArg[0], tupledArg[1]];
}

export function CounterClasses_RangeClass__value_Z37302880(this$, a, b) {
    const tupledArg = [new Property_CounterProperty(4), new Counter_Range(2, singleton([new Counter_Range(1, a), new Counter_Range(1, b)]))];
    return [tupledArg[0], tupledArg[1]];
}

export function CounterClasses_RangeClass__value_Z20E6C5FB(this$, range) {
    const tupledArg = [new Property_CounterProperty(4), new Counter_Range(2, range)];
    return [tupledArg[0], tupledArg[1]];
}

export class CounterClasses_PadClass {
    constructor() {
    }
}

export function CounterClasses_PadClass$reflection() {
    return class_type("Fss.Types.CounterClasses.PadClass", void 0, CounterClasses_PadClass);
}

export function CounterClasses_PadClass_$ctor() {
    return new CounterClasses_PadClass();
}

export function CounterClasses_PadClass__value_Z176EF219(this$, pad, value) {
    const pad_1 = new Counter_PadType(0, pad, new Stringed(0, value));
    const tupledArg = [new Property_CounterProperty(5), pad_1];
    return [tupledArg[0], tupledArg[1]];
}

export class CounterClasses_SymbolsClass extends CounterClasses_CounterImage {
    constructor() {
        super(new Property_CounterProperty(7));
    }
}

export function CounterClasses_SymbolsClass$reflection() {
    return class_type("Fss.Types.CounterClasses.SymbolsClass", void 0, CounterClasses_SymbolsClass, CounterClasses_CounterImage$reflection());
}

export function CounterClasses_SymbolsClass_$ctor() {
    return new CounterClasses_SymbolsClass();
}

export function CounterClasses_SymbolsClass__value_Z721C83C5(this$, symbols) {
    const tupledArg = [new Property_CounterProperty(7), new String$(0, symbols)];
    return [tupledArg[0], tupledArg[1]];
}

export function CounterClasses_SymbolsClass__value_1334CEF1(this$, symbols) {
    const symbols_1 = join(" ", map((s) => (`"${s}"`), symbols));
    const tupledArg = [new Property_CounterProperty(7), new String$(0, symbols_1)];
    return [tupledArg[0], tupledArg[1]];
}

export function CounterClasses_SymbolsClass__value_304C0A8C(this$, images) {
    const images_1 = join(" ", map(MasterTypeHelpers_stringifyICssValue, images));
    const tupledArg = [new Property_CounterProperty(7), new String$(0, images_1)];
    return [tupledArg[0], tupledArg[1]];
}

export class CounterClasses_AdditiveSymbolsClass {
    constructor() {
    }
}

export function CounterClasses_AdditiveSymbolsClass$reflection() {
    return class_type("Fss.Types.CounterClasses.AdditiveSymbolsClass", void 0, CounterClasses_AdditiveSymbolsClass);
}

export function CounterClasses_AdditiveSymbolsClass_$ctor() {
    return new CounterClasses_AdditiveSymbolsClass();
}

export function CounterClasses_AdditiveSymbolsClass__value_1334CEF1(this$, symbols) {
    const tupledArg = [new Property_CounterProperty(7), new Counter_AdditiveSymbols(0, symbols)];
    return [tupledArg[0], tupledArg[1]];
}

export class CounterClasses_SpeakAsClass {
    constructor() {
    }
}

export function CounterClasses_SpeakAsClass$reflection() {
    return class_type("Fss.Types.CounterClasses.SpeakAsClass", void 0, CounterClasses_SpeakAsClass);
}

export function CounterClasses_SpeakAsClass_$ctor() {
    return new CounterClasses_SpeakAsClass();
}

export function CounterClasses_SpeakAsClass__get_auto(this$) {
    const tupledArg = [new Property_CounterProperty(9), new Auto(0)];
    return [tupledArg[0], tupledArg[1]];
}

export function CounterClasses_SpeakAsClass__get_bullets(this$) {
    const tupledArg = [new Property_CounterProperty(9), new Counter_SpeakAs(1)];
    return [tupledArg[0], tupledArg[1]];
}

export function CounterClasses_SpeakAsClass__get_numbers(this$) {
    const tupledArg = [new Property_CounterProperty(9), new Counter_SpeakAs(2)];
    return [tupledArg[0], tupledArg[1]];
}

export function CounterClasses_SpeakAsClass__get_words(this$) {
    const tupledArg = [new Property_CounterProperty(9), new Counter_SpeakAs(3)];
    return [tupledArg[0], tupledArg[1]];
}

export function CounterClasses_SpeakAsClass__get_spellOut(this$) {
    const tupledArg = [new Property_CounterProperty(9), new Counter_SpeakAs(4)];
    return [tupledArg[0], tupledArg[1]];
}

export function CounterClasses_SpeakAsClass__value_Z721C83C5(this$, ident) {
    const tupledArg = [new Property_CounterProperty(9), new Counter_SpeakAs(5, ident)];
    return [tupledArg[0], tupledArg[1]];
}

export class CounterClasses_FallbackClass {
    constructor() {
    }
}

export function CounterClasses_FallbackClass$reflection() {
    return class_type("Fss.Types.CounterClasses.FallbackClass", void 0, CounterClasses_FallbackClass);
}

export function CounterClasses_FallbackClass_$ctor() {
    return new CounterClasses_FallbackClass();
}

export function CounterClasses_FallbackClass__get_lowerAlpha(this$) {
    const tupledArg = [new Property_CounterProperty(6), new Counter_Fallback(0)];
    return [tupledArg[0], tupledArg[1]];
}

export function CounterClasses_FallbackClass__get_customGangnamStyle(this$) {
    const tupledArg = [new Property_CounterProperty(6), new Counter_Fallback(1)];
    return [tupledArg[0], tupledArg[1]];
}

export class CounterClasses_CounterReset extends CssRuleWithNone {
    constructor(property) {
        super(property);
        this.property_2 = property;
    }
}

export function CounterClasses_CounterReset$reflection() {
    return class_type("Fss.Types.CounterClasses.CounterReset", void 0, CounterClasses_CounterReset, CssRuleWithNone$reflection());
}

export function CounterClasses_CounterReset_$ctor_Z207A3CFB(property) {
    return new CounterClasses_CounterReset(property);
}

export function CounterClasses_CounterReset__value_Z721C83C5(this$, counter) {
    const tupledArg = [this$.property_2, new String$(0, counter)];
    return [tupledArg[0], tupledArg[1]];
}

export function CounterClasses_CounterReset__value_Z18115A39(this$, counter, value) {
    const value_1 = `${counter} ${value}`;
    const tupledArg = [this$.property_2, new String$(0, value_1)];
    return [tupledArg[0], tupledArg[1]];
}

export function CounterClasses_CounterReset__reversed_Z721C83C5(this$, counter) {
    const value = `reversed(${counter})`;
    const tupledArg = [this$.property_2, new String$(0, value)];
    return [tupledArg[0], tupledArg[1]];
}

export function CounterClasses_CounterReset__reversed_Z18115A39(this$, counter, value) {
    const value_1 = `reversed(${counter}) ${value}`;
    const tupledArg = [this$.property_2, new String$(0, value_1)];
    return [tupledArg[0], tupledArg[1]];
}

export class CounterClasses_CounterSet extends CssRuleWithNone {
    constructor(property) {
        super(property);
        this.property_2 = property;
    }
}

export function CounterClasses_CounterSet$reflection() {
    return class_type("Fss.Types.CounterClasses.CounterSet", void 0, CounterClasses_CounterSet, CssRuleWithNone$reflection());
}

export function CounterClasses_CounterSet_$ctor_Z207A3CFB(property) {
    return new CounterClasses_CounterSet(property);
}

export function CounterClasses_CounterSet__value_Z721C83C5(this$, counter) {
    const tupledArg = [this$.property_2, new String$(0, counter)];
    return [tupledArg[0], tupledArg[1]];
}

export function CounterClasses_CounterSet__value_Z18115A39(this$, counter, value) {
    const value_1 = `${counter} ${value}`;
    const tupledArg = [this$.property_2, new String$(0, value_1)];
    return [tupledArg[0], tupledArg[1]];
}

export class CounterClasses_CounterIncrement extends CssRuleWithNone {
    constructor(property) {
        super(property);
        this.property_2 = property;
    }
}

export function CounterClasses_CounterIncrement$reflection() {
    return class_type("Fss.Types.CounterClasses.CounterIncrement", void 0, CounterClasses_CounterIncrement, CssRuleWithNone$reflection());
}

export function CounterClasses_CounterIncrement_$ctor_Z207A3CFB(property) {
    return new CounterClasses_CounterIncrement(property);
}

export function CounterClasses_CounterIncrement__value_Z721C83C5(this$, counter) {
    const tupledArg = [this$.property_2, new String$(0, counter)];
    return [tupledArg[0], tupledArg[1]];
}

export function CounterClasses_CounterIncrement__value_Z18115A39(this$, counter, value) {
    const value_1 = `${counter} ${value}`;
    const tupledArg = [this$.property_2, new String$(0, value_1)];
    return [tupledArg[0], tupledArg[1]];
}

//# sourceMappingURL=CounterStyle.fs.js.map
