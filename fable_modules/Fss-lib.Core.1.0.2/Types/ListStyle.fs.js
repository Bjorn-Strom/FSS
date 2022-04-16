import { Union, toString } from "../../fable-library.3.7.9/Types.js";
import { class_type, union_type } from "../../fable-library.3.7.9/Reflection.js";
import { Helpers_toKebabCase } from "../Utilities.fs.js";
import { Char, String$, CssRule$reflection, CssRule, CssRuleWithNone$reflection, CssRuleWithNone } from "./MasterTypes.fs.js";
import { ImageClasses_ImageClass$reflection, ImageClasses_ImageClass } from "./Image.fs.js";

export class ListStyle_Position extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["Inside", "Outside"];
    }
    StringifyCss() {
        const this$ = this;
        return toString(this$).toLocaleLowerCase();
    }
}

export function ListStyle_Position$reflection() {
    return union_type("Fss.Types.ListStyle.Position", [], ListStyle_Position, () => [[], []]);
}

export class ListStyle_Type extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["Disc", "Circle", "Square", "Decimal", "CjkDecimal", "DecimalLeadingZero", "LowerRoman", "UpperRoman", "LowerGreek", "LowerAlpha", "LowerLatin", "UpperAlpha", "UpperLatin", "ArabicIndic", "Armenian", "Bengali", "Cambodian", "CjkEarthlyBranch", "CjkHeavenlyStem", "CjkIdeographic", "Devanagari", "EthiopicNumeric", "Georgian", "Gujarati", "Gurmukhi", "Hebrew", "Hiragana", "HiraganaIroha", "JapaneseFormal", "JapaneseInformal", "Kannada", "Katakana", "KatakanaIroha", "Khmer", "KoreanHangulFormal", "KoreanHanjaFormal", "KoreanHanjaInformal", "Lao", "LowerArmenian", "Malayalam", "Mongolian", "Myanmar", "Oriya", "Persian", "SimpChineseFormal", "SimpChineseInformal", "Tamil", "Telugu", "Thai", "Tibetan", "TradChineseFormal", "TradChineseInformal", "UpperArmenian", "DisclosureOpen", "DisclosureClosed"];
    }
    StringifyCss() {
        const this$ = this;
        return Helpers_toKebabCase(this$);
    }
}

export function ListStyle_Type$reflection() {
    return union_type("Fss.Types.ListStyle.Type", [], ListStyle_Type, () => [[], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], []]);
}

export class ListStyleClasses_ListStyle extends CssRuleWithNone {
    constructor(property) {
        super(property);
    }
}

export function ListStyleClasses_ListStyle$reflection() {
    return class_type("Fss.Types.ListStyleClasses.ListStyle", void 0, ListStyleClasses_ListStyle, CssRuleWithNone$reflection());
}

export function ListStyleClasses_ListStyle_$ctor_Z207A3CFB(property) {
    return new ListStyleClasses_ListStyle(property);
}

export class ListStyleClasses_ListStyleImage extends ImageClasses_ImageClass {
    constructor(property) {
        super(property);
    }
}

export function ListStyleClasses_ListStyleImage$reflection() {
    return class_type("Fss.Types.ListStyleClasses.ListStyleImage", void 0, ListStyleClasses_ListStyleImage, ImageClasses_ImageClass$reflection());
}

export function ListStyleClasses_ListStyleImage_$ctor_Z207A3CFB(property) {
    return new ListStyleClasses_ListStyleImage(property);
}

export class ListStyleClasses_ListStylePosition extends CssRule {
    constructor(property) {
        super(property);
        this.property_1 = property;
    }
}

export function ListStyleClasses_ListStylePosition$reflection() {
    return class_type("Fss.Types.ListStyleClasses.ListStylePosition", void 0, ListStyleClasses_ListStylePosition, CssRule$reflection());
}

export function ListStyleClasses_ListStylePosition_$ctor_Z207A3CFB(property) {
    return new ListStyleClasses_ListStylePosition(property);
}

export function ListStyleClasses_ListStylePosition__get_inside(this$) {
    const tupledArg = [this$.property_1, new ListStyle_Position(0)];
    return [tupledArg[0], tupledArg[1]];
}

export function ListStyleClasses_ListStylePosition__get_outside(this$) {
    const tupledArg = [this$.property_1, new ListStyle_Position(1)];
    return [tupledArg[0], tupledArg[1]];
}

export class ListStyleClasses_ListStyleType extends CssRuleWithNone {
    constructor(property) {
        super(property);
        this.property_2 = property;
    }
}

export function ListStyleClasses_ListStyleType$reflection() {
    return class_type("Fss.Types.ListStyleClasses.ListStyleType", void 0, ListStyleClasses_ListStyleType, CssRuleWithNone$reflection());
}

export function ListStyleClasses_ListStyleType_$ctor_Z207A3CFB(property) {
    return new ListStyleClasses_ListStyleType(property);
}

export function ListStyleClasses_ListStyleType__value_Z721C83C5(this$, value) {
    const tupledArg = [this$.property_2, new String$(0, value)];
    return [tupledArg[0], tupledArg[1]];
}

export function ListStyleClasses_ListStyleType__string_Z721C83C5(this$, value) {
    const tupledArg = [this$.property_2, new Char(0, value)];
    return [tupledArg[0], tupledArg[1]];
}

export function ListStyleClasses_ListStyleType__get_disc(this$) {
    const tupledArg = [this$.property_2, new ListStyle_Type(0)];
    return [tupledArg[0], tupledArg[1]];
}

export function ListStyleClasses_ListStyleType__get_circle(this$) {
    const tupledArg = [this$.property_2, new ListStyle_Type(1)];
    return [tupledArg[0], tupledArg[1]];
}

export function ListStyleClasses_ListStyleType__get_square(this$) {
    const tupledArg = [this$.property_2, new ListStyle_Type(2)];
    return [tupledArg[0], tupledArg[1]];
}

export function ListStyleClasses_ListStyleType__get_decimal(this$) {
    const tupledArg = [this$.property_2, new ListStyle_Type(3)];
    return [tupledArg[0], tupledArg[1]];
}

export function ListStyleClasses_ListStyleType__get_cjkDecimal(this$) {
    const tupledArg = [this$.property_2, new ListStyle_Type(4)];
    return [tupledArg[0], tupledArg[1]];
}

export function ListStyleClasses_ListStyleType__get_decimalLeadingZero(this$) {
    const tupledArg = [this$.property_2, new ListStyle_Type(5)];
    return [tupledArg[0], tupledArg[1]];
}

export function ListStyleClasses_ListStyleType__get_lowerRoman(this$) {
    const tupledArg = [this$.property_2, new ListStyle_Type(6)];
    return [tupledArg[0], tupledArg[1]];
}

export function ListStyleClasses_ListStyleType__get_upperRoman(this$) {
    const tupledArg = [this$.property_2, new ListStyle_Type(7)];
    return [tupledArg[0], tupledArg[1]];
}

export function ListStyleClasses_ListStyleType__get_lowerGreek(this$) {
    const tupledArg = [this$.property_2, new ListStyle_Type(8)];
    return [tupledArg[0], tupledArg[1]];
}

export function ListStyleClasses_ListStyleType__get_lowerAlpha(this$) {
    const tupledArg = [this$.property_2, new ListStyle_Type(9)];
    return [tupledArg[0], tupledArg[1]];
}

export function ListStyleClasses_ListStyleType__get_lowerLatin(this$) {
    const tupledArg = [this$.property_2, new ListStyle_Type(10)];
    return [tupledArg[0], tupledArg[1]];
}

export function ListStyleClasses_ListStyleType__get_upperAlpha(this$) {
    const tupledArg = [this$.property_2, new ListStyle_Type(11)];
    return [tupledArg[0], tupledArg[1]];
}

export function ListStyleClasses_ListStyleType__get_upperLatin(this$) {
    const tupledArg = [this$.property_2, new ListStyle_Type(12)];
    return [tupledArg[0], tupledArg[1]];
}

export function ListStyleClasses_ListStyleType__get_arabicIndic(this$) {
    const tupledArg = [this$.property_2, new ListStyle_Type(13)];
    return [tupledArg[0], tupledArg[1]];
}

export function ListStyleClasses_ListStyleType__get_armenian(this$) {
    const tupledArg = [this$.property_2, new ListStyle_Type(14)];
    return [tupledArg[0], tupledArg[1]];
}

export function ListStyleClasses_ListStyleType__get_bengali(this$) {
    const tupledArg = [this$.property_2, new ListStyle_Type(15)];
    return [tupledArg[0], tupledArg[1]];
}

export function ListStyleClasses_ListStyleType__get_cambodian(this$) {
    const tupledArg = [this$.property_2, new ListStyle_Type(16)];
    return [tupledArg[0], tupledArg[1]];
}

export function ListStyleClasses_ListStyleType__get_cjkEarthlyBranch(this$) {
    const tupledArg = [this$.property_2, new ListStyle_Type(17)];
    return [tupledArg[0], tupledArg[1]];
}

export function ListStyleClasses_ListStyleType__get_cjkHeavenlyStem(this$) {
    const tupledArg = [this$.property_2, new ListStyle_Type(18)];
    return [tupledArg[0], tupledArg[1]];
}

export function ListStyleClasses_ListStyleType__get_cjkIdeographic(this$) {
    const tupledArg = [this$.property_2, new ListStyle_Type(19)];
    return [tupledArg[0], tupledArg[1]];
}

export function ListStyleClasses_ListStyleType__get_devanagari(this$) {
    const tupledArg = [this$.property_2, new ListStyle_Type(20)];
    return [tupledArg[0], tupledArg[1]];
}

export function ListStyleClasses_ListStyleType__get_ethiopicNumeric(this$) {
    const tupledArg = [this$.property_2, new ListStyle_Type(21)];
    return [tupledArg[0], tupledArg[1]];
}

export function ListStyleClasses_ListStyleType__get_georgian(this$) {
    const tupledArg = [this$.property_2, new ListStyle_Type(22)];
    return [tupledArg[0], tupledArg[1]];
}

export function ListStyleClasses_ListStyleType__get_gujarati(this$) {
    const tupledArg = [this$.property_2, new ListStyle_Type(23)];
    return [tupledArg[0], tupledArg[1]];
}

export function ListStyleClasses_ListStyleType__get_gurmukhi(this$) {
    const tupledArg = [this$.property_2, new ListStyle_Type(24)];
    return [tupledArg[0], tupledArg[1]];
}

export function ListStyleClasses_ListStyleType__get_hebrew(this$) {
    const tupledArg = [this$.property_2, new ListStyle_Type(25)];
    return [tupledArg[0], tupledArg[1]];
}

export function ListStyleClasses_ListStyleType__get_hiragana(this$) {
    const tupledArg = [this$.property_2, new ListStyle_Type(26)];
    return [tupledArg[0], tupledArg[1]];
}

export function ListStyleClasses_ListStyleType__get_hiraganaIroha(this$) {
    const tupledArg = [this$.property_2, new ListStyle_Type(27)];
    return [tupledArg[0], tupledArg[1]];
}

export function ListStyleClasses_ListStyleType__get_japaneseFormal(this$) {
    const tupledArg = [this$.property_2, new ListStyle_Type(28)];
    return [tupledArg[0], tupledArg[1]];
}

export function ListStyleClasses_ListStyleType__get_japaneseInformal(this$) {
    const tupledArg = [this$.property_2, new ListStyle_Type(29)];
    return [tupledArg[0], tupledArg[1]];
}

export function ListStyleClasses_ListStyleType__get_kannada(this$) {
    const tupledArg = [this$.property_2, new ListStyle_Type(30)];
    return [tupledArg[0], tupledArg[1]];
}

export function ListStyleClasses_ListStyleType__get_katakana(this$) {
    const tupledArg = [this$.property_2, new ListStyle_Type(31)];
    return [tupledArg[0], tupledArg[1]];
}

export function ListStyleClasses_ListStyleType__get_katakanaIroha(this$) {
    const tupledArg = [this$.property_2, new ListStyle_Type(32)];
    return [tupledArg[0], tupledArg[1]];
}

export function ListStyleClasses_ListStyleType__get_khmer(this$) {
    const tupledArg = [this$.property_2, new ListStyle_Type(33)];
    return [tupledArg[0], tupledArg[1]];
}

export function ListStyleClasses_ListStyleType__get_koreanHangulFormal(this$) {
    const tupledArg = [this$.property_2, new ListStyle_Type(34)];
    return [tupledArg[0], tupledArg[1]];
}

export function ListStyleClasses_ListStyleType__get_koreanHanjaFormal(this$) {
    const tupledArg = [this$.property_2, new ListStyle_Type(35)];
    return [tupledArg[0], tupledArg[1]];
}

export function ListStyleClasses_ListStyleType__get_koreanHanjaInformal(this$) {
    const tupledArg = [this$.property_2, new ListStyle_Type(36)];
    return [tupledArg[0], tupledArg[1]];
}

export function ListStyleClasses_ListStyleType__get_lao(this$) {
    const tupledArg = [this$.property_2, new ListStyle_Type(37)];
    return [tupledArg[0], tupledArg[1]];
}

export function ListStyleClasses_ListStyleType__get_lowerArmenian(this$) {
    const tupledArg = [this$.property_2, new ListStyle_Type(38)];
    return [tupledArg[0], tupledArg[1]];
}

export function ListStyleClasses_ListStyleType__get_malayalam(this$) {
    const tupledArg = [this$.property_2, new ListStyle_Type(39)];
    return [tupledArg[0], tupledArg[1]];
}

export function ListStyleClasses_ListStyleType__get_mongolian(this$) {
    const tupledArg = [this$.property_2, new ListStyle_Type(40)];
    return [tupledArg[0], tupledArg[1]];
}

export function ListStyleClasses_ListStyleType__get_myanmar(this$) {
    const tupledArg = [this$.property_2, new ListStyle_Type(41)];
    return [tupledArg[0], tupledArg[1]];
}

export function ListStyleClasses_ListStyleType__get_oriya(this$) {
    const tupledArg = [this$.property_2, new ListStyle_Type(42)];
    return [tupledArg[0], tupledArg[1]];
}

export function ListStyleClasses_ListStyleType__get_persian(this$) {
    const tupledArg = [this$.property_2, new ListStyle_Type(43)];
    return [tupledArg[0], tupledArg[1]];
}

export function ListStyleClasses_ListStyleType__get_simpChineseFormal(this$) {
    const tupledArg = [this$.property_2, new ListStyle_Type(44)];
    return [tupledArg[0], tupledArg[1]];
}

export function ListStyleClasses_ListStyleType__get_simpChineseInformal(this$) {
    const tupledArg = [this$.property_2, new ListStyle_Type(45)];
    return [tupledArg[0], tupledArg[1]];
}

export function ListStyleClasses_ListStyleType__get_tamil(this$) {
    const tupledArg = [this$.property_2, new ListStyle_Type(46)];
    return [tupledArg[0], tupledArg[1]];
}

export function ListStyleClasses_ListStyleType__get_telugu(this$) {
    const tupledArg = [this$.property_2, new ListStyle_Type(47)];
    return [tupledArg[0], tupledArg[1]];
}

export function ListStyleClasses_ListStyleType__get_thai(this$) {
    const tupledArg = [this$.property_2, new ListStyle_Type(48)];
    return [tupledArg[0], tupledArg[1]];
}

export function ListStyleClasses_ListStyleType__get_tibetan(this$) {
    const tupledArg = [this$.property_2, new ListStyle_Type(49)];
    return [tupledArg[0], tupledArg[1]];
}

export function ListStyleClasses_ListStyleType__get_tradChineseFormal(this$) {
    const tupledArg = [this$.property_2, new ListStyle_Type(50)];
    return [tupledArg[0], tupledArg[1]];
}

export function ListStyleClasses_ListStyleType__get_tradChineseInformal(this$) {
    const tupledArg = [this$.property_2, new ListStyle_Type(51)];
    return [tupledArg[0], tupledArg[1]];
}

export function ListStyleClasses_ListStyleType__get_upperArmenian(this$) {
    const tupledArg = [this$.property_2, new ListStyle_Type(52)];
    return [tupledArg[0], tupledArg[1]];
}

export function ListStyleClasses_ListStyleType__get_disclosureOpen(this$) {
    const tupledArg = [this$.property_2, new ListStyle_Type(53)];
    return [tupledArg[0], tupledArg[1]];
}

export function ListStyleClasses_ListStyleType__get_disclosureClosed(this$) {
    const tupledArg = [this$.property_2, new ListStyle_Type(54)];
    return [tupledArg[0], tupledArg[1]];
}

//# sourceMappingURL=ListStyle.fs.js.map
