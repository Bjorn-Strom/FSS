import { Helpers_toKebabCase } from "../Utilities.fs.js";
import { toString, Union } from "../../fable-library.3.7.9/Types.js";
import { class_type, string_type, union_type } from "../../fable-library.3.7.9/Reflection.js";
import { CssRuleWithNormalNone$reflection, CssRuleWithNormalNone, CssRule$reflection, CssRule, CssRuleWithAutoNormal$reflection, CssRuleWithAutoNormal, Float, Int, CssRuleWithAutoNormalNone$reflection, CssRuleWithAutoNormalNone, Stringed, CssRuleWithNormal$reflection, CssRuleWithNormal, String$, MasterTypeHelpers_stringifyICssValue, CssRuleWithNone$reflection, CssRuleWithNone } from "./MasterTypes.fs.js";
import { interpolate, toText, join } from "../../fable-library.3.7.9/String.js";
import { map } from "../../fable-library.3.7.9/List.js";
import { unitHelpers_CssRuleWithLengthNormal$reflection, unitHelpers_CssRuleWithLengthNormal, unitHelpers_CssRuleWithLength$reflection, unitHelpers_CssRuleWithLength } from "./Units.fs.js";

export class Font_Size extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["XxSmall", "XSmall", "Small", "Medium", "Large", "XLarge", "XxLarge", "XxxLarge", "Smaller", "Larger"];
    }
    StringifyCss() {
        const this$ = this;
        return Helpers_toKebabCase(this$);
    }
}

export function Font_Size$reflection() {
    return union_type("Fss.Types.Font.Size", [], Font_Size, () => [[], [], [], [], [], [], [], [], [], []]);
}

export class Font_Style extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["Italic", "Oblique"];
    }
    StringifyCss() {
        const this$ = this;
        return toString(this$).toLocaleLowerCase();
    }
}

export function Font_Style$reflection() {
    return union_type("Fss.Types.Font.Style", [], Font_Style, () => [[], []]);
}

export class Font_Stretch extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["SemiCondensed", "Condensed", "ExtraCondensed", "UltraCondensed", "SemiExpanded", "Expanded", "ExtraExpanded", "UltraExpanded"];
    }
    StringifyCss() {
        const this$ = this;
        return Helpers_toKebabCase(this$);
    }
}

export function Font_Stretch$reflection() {
    return union_type("Fss.Types.Font.Stretch", [], Font_Stretch, () => [[], [], [], [], [], [], [], []]);
}

export class Font_Weight extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["Bold", "Lighter", "Bolder"];
    }
    StringifyCss() {
        const this$ = this;
        return toString(this$).toLocaleLowerCase();
    }
}

export function Font_Weight$reflection() {
    return union_type("Fss.Types.Font.Weight", [], Font_Weight, () => [[], [], []]);
}

export class Font_SettingSwitch extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["On", "Off"];
    }
}

export function Font_SettingSwitch$reflection() {
    return union_type("Fss.Types.Font.SettingSwitch", [], Font_SettingSwitch, () => [[], []]);
}

export class Font_FeatureSetting extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["Liga", "Dlig", "Onum", "Lnum", "Tnum", "Zero", "Frac", "Sups", "Subs", "Smcp", "C2sc", "Case", "Hlig", "Calt", "Swsh", "Hist", "Ss", "Kern", "Locl", "Rlig", "Medi", "Init", "Isol", "Fina", "Mark", "Mkmk"];
    }
    StringifyCss() {
        const this$ = this;
        return toString(this$).toLocaleLowerCase();
    }
}

export function Font_FeatureSetting$reflection() {
    return union_type("Fss.Types.Font.FeatureSetting", [], Font_FeatureSetting, () => [[], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], []]);
}

export class Font_VariantNumeric extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["Ordinal", "SlashedZero", "LiningNums", "OldstyleNums", "ProportionalNums", "TabularNums", "DiagonalFractions", "StackedFractions"];
    }
    StringifyCss() {
        const this$ = this;
        return Helpers_toKebabCase(this$);
    }
}

export function Font_VariantNumeric$reflection() {
    return union_type("Fss.Types.Font.VariantNumeric", [], Font_VariantNumeric, () => [[], [], [], [], [], [], [], []]);
}

export class Font_VariantCaps extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["SmallCaps", "AllSmallCaps", "PetiteCaps", "AllPetiteCaps", "Unicase", "TitlingCaps"];
    }
    StringifyCss() {
        const this$ = this;
        return Helpers_toKebabCase(this$);
    }
}

export function Font_VariantCaps$reflection() {
    return union_type("Fss.Types.Font.VariantCaps", [], Font_VariantCaps, () => [[], [], [], [], [], []]);
}

export class Font_VariantEastAsian extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["Ruby", "Jis78", "Jis83", "Jis90", "Jis04", "Simplified", "Traditional", "FullWidth", "ProportionalWidth"];
    }
    StringifyCss() {
        const this$ = this;
        return Helpers_toKebabCase(this$);
    }
}

export function Font_VariantEastAsian$reflection() {
    return union_type("Fss.Types.Font.VariantEastAsian", [], Font_VariantEastAsian, () => [[], [], [], [], [], [], [], [], []]);
}

export class Font_VariantLigature extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["CommonLigatures", "NoCommonLigatures", "DiscretionaryLigatures", "NoDiscretionaryLigatures", "HistoricalLigatures", "NoHistoricalLigatures", "Contextual", "NoContextual"];
    }
    StringifyCss() {
        const this$ = this;
        return Helpers_toKebabCase(this$);
    }
}

export function Font_VariantLigature$reflection() {
    return union_type("Fss.Types.Font.VariantLigature", [], Font_VariantLigature, () => [[], [], [], [], [], [], [], []]);
}

export class Font_Name extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["Name"];
    }
}

export function Font_Name$reflection() {
    return union_type("Fss.Types.Font.Name", [], Font_Name, () => [[["Item", string_type]]]);
}

export class Font_Family extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["Serif", "SansSerif", "Monospace", "Cursive"];
    }
    StringifyCss() {
        const this$ = this;
        return Helpers_toKebabCase(this$);
    }
}

export function Font_Family$reflection() {
    return union_type("Fss.Types.Font.Family", [], Font_Family, () => [[], [], [], []]);
}

export class Font_LineBreak extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["Loose", "Strict", "Anywhere"];
    }
    StringifyCss() {
        const this$ = this;
        return toString(this$).toLocaleLowerCase();
    }
}

export function Font_LineBreak$reflection() {
    return union_type("Fss.Types.Font.LineBreak", [], Font_LineBreak, () => [[], [], []]);
}

export class Font_Synthesis extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["Weight", "Style", "SmallCaps"];
    }
    StringifyCss() {
        const this$ = this;
        return Helpers_toKebabCase(this$);
    }
}

export function Font_Synthesis$reflection() {
    return union_type("Fss.Types.Font.Synthesis", [], Font_Synthesis, () => [[], [], []]);
}

export class Font_VariantPosition extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["Sub", "Super"];
    }
    StringifyCss() {
        const this$ = this;
        return toString(this$).toLocaleLowerCase();
    }
}

export function Font_VariantPosition$reflection() {
    return union_type("Fss.Types.Font.VariantPosition", [], Font_VariantPosition, () => [[], []]);
}

export class FontClasses_FontSynthesis extends CssRuleWithNone {
    constructor(property) {
        super(property);
        this.property_2 = property;
    }
}

export function FontClasses_FontSynthesis$reflection() {
    return class_type("Fss.Types.FontClasses.FontSynthesis", void 0, FontClasses_FontSynthesis, CssRuleWithNone$reflection());
}

export function FontClasses_FontSynthesis_$ctor_Z207A3CFB(property) {
    return new FontClasses_FontSynthesis(property);
}

export function FontClasses_FontSynthesis__value_4963FB8B(this$, synthesis) {
    const synthesis_1 = join(" ", map(MasterTypeHelpers_stringifyICssValue, synthesis));
    const tupledArg = [this$.property_2, new String$(0, synthesis_1)];
    return [tupledArg[0], tupledArg[1]];
}

export function FontClasses_FontSynthesis__get_weight(this$) {
    const tupledArg = [this$.property_2, new Font_Synthesis(0)];
    return [tupledArg[0], tupledArg[1]];
}

export function FontClasses_FontSynthesis__get_style(this$) {
    const tupledArg = [this$.property_2, new Font_Synthesis(1)];
    return [tupledArg[0], tupledArg[1]];
}

export function FontClasses_FontSynthesis__get_smallCaps(this$) {
    const tupledArg = [this$.property_2, new Font_VariantCaps(0)];
    return [tupledArg[0], tupledArg[1]];
}

export class FontClasses_FontLanguageOverride extends CssRuleWithNormal {
    constructor(property) {
        super(property);
        this.property_2 = property;
    }
}

export function FontClasses_FontLanguageOverride$reflection() {
    return class_type("Fss.Types.FontClasses.FontLanguageOverride", void 0, FontClasses_FontLanguageOverride, CssRuleWithNormal$reflection());
}

export function FontClasses_FontLanguageOverride_$ctor_Z207A3CFB(property) {
    return new FontClasses_FontLanguageOverride(property);
}

export function FontClasses_FontLanguageOverride__value_Z721C83C5(this$, languageOverride) {
    const tupledArg = [this$.property_2, new Stringed(0, languageOverride)];
    return [tupledArg[0], tupledArg[1]];
}

export class FontClasses_FontKerning extends CssRuleWithAutoNormalNone {
    constructor(property) {
        super(property);
    }
}

export function FontClasses_FontKerning$reflection() {
    return class_type("Fss.Types.FontClasses.FontKerning", void 0, FontClasses_FontKerning, CssRuleWithAutoNormalNone$reflection());
}

export function FontClasses_FontKerning_$ctor_Z207A3CFB(property) {
    return new FontClasses_FontKerning(property);
}

export class FontClasses_FontSize extends unitHelpers_CssRuleWithLength {
    constructor(property) {
        super(property);
        this.property_2 = property;
    }
}

export function FontClasses_FontSize$reflection() {
    return class_type("Fss.Types.FontClasses.FontSize", void 0, FontClasses_FontSize, unitHelpers_CssRuleWithLength$reflection());
}

export function FontClasses_FontSize_$ctor_Z207A3CFB(property) {
    return new FontClasses_FontSize(property);
}

export function FontClasses_FontSize__get_xxSmall(this$) {
    const tupledArg = [this$.property_2, new Font_Size(0)];
    return [tupledArg[0], tupledArg[1]];
}

export function FontClasses_FontSize__get_xSmall(this$) {
    const tupledArg = [this$.property_2, new Font_Size(1)];
    return [tupledArg[0], tupledArg[1]];
}

export function FontClasses_FontSize__get_small(this$) {
    const tupledArg = [this$.property_2, new Font_Size(2)];
    return [tupledArg[0], tupledArg[1]];
}

export function FontClasses_FontSize__get_medium(this$) {
    const tupledArg = [this$.property_2, new Font_Size(3)];
    return [tupledArg[0], tupledArg[1]];
}

export function FontClasses_FontSize__get_large(this$) {
    const tupledArg = [this$.property_2, new Font_Size(4)];
    return [tupledArg[0], tupledArg[1]];
}

export function FontClasses_FontSize__get_xLarge(this$) {
    const tupledArg = [this$.property_2, new Font_Size(5)];
    return [tupledArg[0], tupledArg[1]];
}

export function FontClasses_FontSize__get_xxLarge(this$) {
    const tupledArg = [this$.property_2, new Font_Size(6)];
    return [tupledArg[0], tupledArg[1]];
}

export function FontClasses_FontSize__get_xxxLarge(this$) {
    const tupledArg = [this$.property_2, new Font_Size(7)];
    return [tupledArg[0], tupledArg[1]];
}

export function FontClasses_FontSize__get_smaller(this$) {
    const tupledArg = [this$.property_2, new Font_Size(8)];
    return [tupledArg[0], tupledArg[1]];
}

export function FontClasses_FontSize__get_larger(this$) {
    const tupledArg = [this$.property_2, new Font_Size(9)];
    return [tupledArg[0], tupledArg[1]];
}

export class FontClasses_FontStretch extends unitHelpers_CssRuleWithLengthNormal {
    constructor(property) {
        super(property);
        this.property_3 = property;
    }
}

export function FontClasses_FontStretch$reflection() {
    return class_type("Fss.Types.FontClasses.FontStretch", void 0, FontClasses_FontStretch, unitHelpers_CssRuleWithLengthNormal$reflection());
}

export function FontClasses_FontStretch_$ctor_Z207A3CFB(property) {
    return new FontClasses_FontStretch(property);
}

export function FontClasses_FontStretch__get_semiCondensed(this$) {
    const tupledArg = [this$.property_3, new Font_Stretch(0)];
    return [tupledArg[0], tupledArg[1]];
}

export function FontClasses_FontStretch__get_condensed(this$) {
    const tupledArg = [this$.property_3, new Font_Stretch(1)];
    return [tupledArg[0], tupledArg[1]];
}

export function FontClasses_FontStretch__get_extraCondensed(this$) {
    const tupledArg = [this$.property_3, new Font_Stretch(2)];
    return [tupledArg[0], tupledArg[1]];
}

export function FontClasses_FontStretch__get_ultraCondensed(this$) {
    const tupledArg = [this$.property_3, new Font_Stretch(3)];
    return [tupledArg[0], tupledArg[1]];
}

export function FontClasses_FontStretch__get_semiExpanded(this$) {
    const tupledArg = [this$.property_3, new Font_Stretch(4)];
    return [tupledArg[0], tupledArg[1]];
}

export function FontClasses_FontStretch__get_expanded(this$) {
    const tupledArg = [this$.property_3, new Font_Stretch(5)];
    return [tupledArg[0], tupledArg[1]];
}

export function FontClasses_FontStretch__get_extraExpanded(this$) {
    const tupledArg = [this$.property_3, new Font_Stretch(6)];
    return [tupledArg[0], tupledArg[1]];
}

export function FontClasses_FontStretch__get_ultraExpanded(this$) {
    const tupledArg = [this$.property_3, new Font_Stretch(7)];
    return [tupledArg[0], tupledArg[1]];
}

export class FontClasses_FontStyle extends CssRuleWithNormal {
    constructor(property) {
        super(property);
        this.property_2 = property;
    }
}

export function FontClasses_FontStyle$reflection() {
    return class_type("Fss.Types.FontClasses.FontStyle", void 0, FontClasses_FontStyle, CssRuleWithNormal$reflection());
}

export function FontClasses_FontStyle_$ctor_Z207A3CFB(property) {
    return new FontClasses_FontStyle(property);
}

export function FontClasses_FontStyle__oblique_CEE3389(this$, angle) {
    const angle_1 = `oblique ${MasterTypeHelpers_stringifyICssValue(angle)}`;
    const tupledArg = [this$.property_2, new String$(0, angle_1)];
    return [tupledArg[0], tupledArg[1]];
}

export function FontClasses_FontStyle__get_italic(this$) {
    const tupledArg = [this$.property_2, new Font_Style(0)];
    return [tupledArg[0], tupledArg[1]];
}

export class FontClasses_FontWeight extends CssRuleWithNormal {
    constructor(property) {
        super(property);
        this.property_2 = property;
    }
}

export function FontClasses_FontWeight$reflection() {
    return class_type("Fss.Types.FontClasses.FontWeight", void 0, FontClasses_FontWeight, CssRuleWithNormal$reflection());
}

export function FontClasses_FontWeight_$ctor_Z207A3CFB(property) {
    return new FontClasses_FontWeight(property);
}

export function FontClasses_FontWeight__value_Z524259A4(this$, weight) {
    const tupledArg = [this$.property_2, new Int(0, weight)];
    return [tupledArg[0], tupledArg[1]];
}

export function FontClasses_FontWeight__get_bold(this$) {
    const tupledArg = [this$.property_2, new Font_Weight(0)];
    return [tupledArg[0], tupledArg[1]];
}

export function FontClasses_FontWeight__get_lighter(this$) {
    const tupledArg = [this$.property_2, new Font_Weight(1)];
    return [tupledArg[0], tupledArg[1]];
}

export function FontClasses_FontWeight__get_bolder(this$) {
    const tupledArg = [this$.property_2, new Font_Weight(2)];
    return [tupledArg[0], tupledArg[1]];
}

export class FontClasses_LineHeight extends unitHelpers_CssRuleWithLengthNormal {
    constructor(property) {
        super(property);
        this.property_3 = property;
    }
}

export function FontClasses_LineHeight$reflection() {
    return class_type("Fss.Types.FontClasses.LineHeight", void 0, FontClasses_LineHeight, unitHelpers_CssRuleWithLengthNormal$reflection());
}

export function FontClasses_LineHeight_$ctor_Z207A3CFB(property) {
    return new FontClasses_LineHeight(property);
}

export function FontClasses_LineHeight__value_5E38073B(this$, height) {
    const tupledArg = [this$.property_3, new Float(0, height)];
    return [tupledArg[0], tupledArg[1]];
}

export function FontClasses_LineHeight__get_bold(this$) {
    const tupledArg = [this$.property_3, new Font_Weight(0)];
    return [tupledArg[0], tupledArg[1]];
}

export function FontClasses_LineHeight__get_lighter(this$) {
    const tupledArg = [this$.property_3, new Font_Weight(1)];
    return [tupledArg[0], tupledArg[1]];
}

export function FontClasses_LineHeight__get_bolder(this$) {
    const tupledArg = [this$.property_3, new Font_Weight(2)];
    return [tupledArg[0], tupledArg[1]];
}

export class FontClasses_LineBreak extends CssRuleWithAutoNormal {
    constructor(property) {
        super(property);
        this.property_3 = property;
    }
}

export function FontClasses_LineBreak$reflection() {
    return class_type("Fss.Types.FontClasses.LineBreak", void 0, FontClasses_LineBreak, CssRuleWithAutoNormal$reflection());
}

export function FontClasses_LineBreak_$ctor_Z207A3CFB(property) {
    return new FontClasses_LineBreak(property);
}

export function FontClasses_LineBreak__get_loose(this$) {
    const tupledArg = [this$.property_3, new Font_LineBreak(0)];
    return [tupledArg[0], tupledArg[1]];
}

export function FontClasses_LineBreak__get_strict(this$) {
    const tupledArg = [this$.property_3, new Font_LineBreak(1)];
    return [tupledArg[0], tupledArg[1]];
}

export function FontClasses_LineBreak__get_anywhere(this$) {
    const tupledArg = [this$.property_3, new Font_LineBreak(2)];
    return [tupledArg[0], tupledArg[1]];
}

export class FontClasses_LetterSpacing extends unitHelpers_CssRuleWithLengthNormal {
    constructor(property) {
        super(property);
    }
}

export function FontClasses_LetterSpacing$reflection() {
    return class_type("Fss.Types.FontClasses.LetterSpacing", void 0, FontClasses_LetterSpacing, unitHelpers_CssRuleWithLengthNormal$reflection());
}

export function FontClasses_LetterSpacing_$ctor_Z207A3CFB(property) {
    return new FontClasses_LetterSpacing(property);
}

export class FontClasses_FontFamily extends CssRule {
    constructor(property) {
        super(property);
        this.property_1 = property;
    }
}

export function FontClasses_FontFamily$reflection() {
    return class_type("Fss.Types.FontClasses.FontFamily", void 0, FontClasses_FontFamily, CssRule$reflection());
}

export function FontClasses_FontFamily_$ctor_Z207A3CFB(property) {
    return new FontClasses_FontFamily(property);
}

export function FontClasses_FontFamily__value_Z721C83C5(this$, family) {
    const tupledArg = [this$.property_1, new String$(0, family)];
    return [tupledArg[0], tupledArg[1]];
}

export function FontClasses_FontFamily__value_Z7B4D0BD7(this$, families) {
    const families_1 = join(", ", map(MasterTypeHelpers_stringifyICssValue, families));
    const tupledArg = [this$.property_1, new String$(0, families_1)];
    return [tupledArg[0], tupledArg[1]];
}

export function FontClasses_FontFamily__get_serif(this$) {
    const tupledArg = [this$.property_1, new Font_Family(0)];
    return [tupledArg[0], tupledArg[1]];
}

export function FontClasses_FontFamily__get_sansSerif(this$) {
    const tupledArg = [this$.property_1, new Font_Family(1)];
    return [tupledArg[0], tupledArg[1]];
}

export function FontClasses_FontFamily__get_monospace(this$) {
    const tupledArg = [this$.property_1, new Font_Family(2)];
    return [tupledArg[0], tupledArg[1]];
}

export function FontClasses_FontFamily__get_cursive(this$) {
    const tupledArg = [this$.property_1, new Font_Family(3)];
    return [tupledArg[0], tupledArg[1]];
}

export class FontClasses_FontFeatureSettings extends CssRuleWithNormal {
    constructor(property) {
        super(property);
        this.property_2 = property;
    }
}

export function FontClasses_FontFeatureSettings$reflection() {
    return class_type("Fss.Types.FontClasses.FontFeatureSettings", void 0, FontClasses_FontFeatureSettings, CssRuleWithNormal$reflection());
}

export function FontClasses_FontFeatureSettings_$ctor_Z207A3CFB(property) {
    return new FontClasses_FontFeatureSettings(property);
}

export function FontClasses_FontFeatureSettings__liga_1505(this$, switch$) {
    const tupledArg = [this$.property_2, new String$(0, ((switch$_1) => FontClasses_FontFeatureSettings__settingToString(this$, new Font_FeatureSetting(0), switch$_1))(switch$))];
    return [tupledArg[0], tupledArg[1]];
}

export function FontClasses_FontFeatureSettings__dlig_1505(this$, switch$) {
    const tupledArg = [this$.property_2, new String$(0, ((switch$_1) => FontClasses_FontFeatureSettings__settingToString(this$, new Font_FeatureSetting(1), switch$_1))(switch$))];
    return [tupledArg[0], tupledArg[1]];
}

export function FontClasses_FontFeatureSettings__onum_1505(this$, switch$) {
    const tupledArg = [this$.property_2, new String$(0, ((switch$_1) => FontClasses_FontFeatureSettings__settingToString(this$, new Font_FeatureSetting(2), switch$_1))(switch$))];
    return [tupledArg[0], tupledArg[1]];
}

export function FontClasses_FontFeatureSettings__lnum_1505(this$, switch$) {
    const tupledArg = [this$.property_2, new String$(0, ((switch$_1) => FontClasses_FontFeatureSettings__settingToString(this$, new Font_FeatureSetting(3), switch$_1))(switch$))];
    return [tupledArg[0], tupledArg[1]];
}

export function FontClasses_FontFeatureSettings__tnum_1505(this$, switch$) {
    const tupledArg = [this$.property_2, new String$(0, ((switch$_1) => FontClasses_FontFeatureSettings__settingToString(this$, new Font_FeatureSetting(4), switch$_1))(switch$))];
    return [tupledArg[0], tupledArg[1]];
}

export function FontClasses_FontFeatureSettings__zero_1505(this$, switch$) {
    const tupledArg = [this$.property_2, new String$(0, ((switch$_1) => FontClasses_FontFeatureSettings__settingToString(this$, new Font_FeatureSetting(5), switch$_1))(switch$))];
    return [tupledArg[0], tupledArg[1]];
}

export function FontClasses_FontFeatureSettings__frac_1505(this$, switch$) {
    const tupledArg = [this$.property_2, new String$(0, ((switch$_1) => FontClasses_FontFeatureSettings__settingToString(this$, new Font_FeatureSetting(6), switch$_1))(switch$))];
    return [tupledArg[0], tupledArg[1]];
}

export function FontClasses_FontFeatureSettings__sups_1505(this$, switch$) {
    const tupledArg = [this$.property_2, new String$(0, ((switch$_1) => FontClasses_FontFeatureSettings__settingToString(this$, new Font_FeatureSetting(7), switch$_1))(switch$))];
    return [tupledArg[0], tupledArg[1]];
}

export function FontClasses_FontFeatureSettings__subs_1505(this$, switch$) {
    const tupledArg = [this$.property_2, new String$(0, ((switch$_1) => FontClasses_FontFeatureSettings__settingToString(this$, new Font_FeatureSetting(8), switch$_1))(switch$))];
    return [tupledArg[0], tupledArg[1]];
}

export function FontClasses_FontFeatureSettings__smcp_1505(this$, switch$) {
    const tupledArg = [this$.property_2, new String$(0, ((switch$_1) => FontClasses_FontFeatureSettings__settingToString(this$, new Font_FeatureSetting(9), switch$_1))(switch$))];
    return [tupledArg[0], tupledArg[1]];
}

export function FontClasses_FontFeatureSettings__c2sc_1505(this$, switch$) {
    const tupledArg = [this$.property_2, new String$(0, ((switch$_1) => FontClasses_FontFeatureSettings__settingToString(this$, new Font_FeatureSetting(10), switch$_1))(switch$))];
    return [tupledArg[0], tupledArg[1]];
}

export function FontClasses_FontFeatureSettings__case_1505(this$, switch$) {
    const tupledArg = [this$.property_2, new String$(0, ((switch$_1) => FontClasses_FontFeatureSettings__settingToString(this$, new Font_FeatureSetting(11), switch$_1))(switch$))];
    return [tupledArg[0], tupledArg[1]];
}

export function FontClasses_FontFeatureSettings__hlig_1505(this$, switch$) {
    const tupledArg = [this$.property_2, new String$(0, ((switch$_1) => FontClasses_FontFeatureSettings__settingToString(this$, new Font_FeatureSetting(12), switch$_1))(switch$))];
    return [tupledArg[0], tupledArg[1]];
}

export function FontClasses_FontFeatureSettings__calt_1505(this$, switch$) {
    const tupledArg = [this$.property_2, new String$(0, ((switch$_1) => FontClasses_FontFeatureSettings__settingToString(this$, new Font_FeatureSetting(13), switch$_1))(switch$))];
    return [tupledArg[0], tupledArg[1]];
}

export function FontClasses_FontFeatureSettings__swsh_1505(this$, switch$) {
    const tupledArg = [this$.property_2, new String$(0, ((switch$_1) => FontClasses_FontFeatureSettings__settingToString(this$, new Font_FeatureSetting(14), switch$_1))(switch$))];
    return [tupledArg[0], tupledArg[1]];
}

export function FontClasses_FontFeatureSettings__hist_1505(this$, switch$) {
    const tupledArg = [this$.property_2, new String$(0, ((switch$_1) => FontClasses_FontFeatureSettings__settingToString(this$, new Font_FeatureSetting(15), switch$_1))(switch$))];
    return [tupledArg[0], tupledArg[1]];
}

export function FontClasses_FontFeatureSettings__ss_Z11E6453(this$, value, switch$) {
    const value_1 = toText(interpolate("\"ss%02i%P()\" %s%P()", [value, toString(switch$)]));
    const tupledArg = [this$.property_2, new String$(0, value_1)];
    return [tupledArg[0], tupledArg[1]];
}

export function FontClasses_FontFeatureSettings__kern_1505(this$, switch$) {
    const tupledArg = [this$.property_2, new String$(0, ((switch$_1) => FontClasses_FontFeatureSettings__settingToString(this$, new Font_FeatureSetting(17), switch$_1))(switch$))];
    return [tupledArg[0], tupledArg[1]];
}

export function FontClasses_FontFeatureSettings__locl_1505(this$, switch$) {
    const tupledArg = [this$.property_2, new String$(0, ((switch$_1) => FontClasses_FontFeatureSettings__settingToString(this$, new Font_FeatureSetting(18), switch$_1))(switch$))];
    return [tupledArg[0], tupledArg[1]];
}

export function FontClasses_FontFeatureSettings__rlig_1505(this$, switch$) {
    const tupledArg = [this$.property_2, new String$(0, ((switch$_1) => FontClasses_FontFeatureSettings__settingToString(this$, new Font_FeatureSetting(19), switch$_1))(switch$))];
    return [tupledArg[0], tupledArg[1]];
}

export function FontClasses_FontFeatureSettings__medi_1505(this$, switch$) {
    const tupledArg = [this$.property_2, new String$(0, ((switch$_1) => FontClasses_FontFeatureSettings__settingToString(this$, new Font_FeatureSetting(20), switch$_1))(switch$))];
    return [tupledArg[0], tupledArg[1]];
}

export function FontClasses_FontFeatureSettings__init_1505(this$, switch$) {
    const tupledArg = [this$.property_2, new String$(0, ((switch$_1) => FontClasses_FontFeatureSettings__settingToString(this$, new Font_FeatureSetting(21), switch$_1))(switch$))];
    return [tupledArg[0], tupledArg[1]];
}

export function FontClasses_FontFeatureSettings__isol_1505(this$, switch$) {
    const tupledArg = [this$.property_2, new String$(0, ((switch$_1) => FontClasses_FontFeatureSettings__settingToString(this$, new Font_FeatureSetting(22), switch$_1))(switch$))];
    return [tupledArg[0], tupledArg[1]];
}

export function FontClasses_FontFeatureSettings__fina_1505(this$, switch$) {
    const tupledArg = [this$.property_2, new String$(0, ((switch$_1) => FontClasses_FontFeatureSettings__settingToString(this$, new Font_FeatureSetting(23), switch$_1))(switch$))];
    return [tupledArg[0], tupledArg[1]];
}

export function FontClasses_FontFeatureSettings__mark_1505(this$, switch$) {
    const tupledArg = [this$.property_2, new String$(0, ((switch$_1) => FontClasses_FontFeatureSettings__settingToString(this$, new Font_FeatureSetting(24), switch$_1))(switch$))];
    return [tupledArg[0], tupledArg[1]];
}

export function FontClasses_FontFeatureSettings__mkmk_1505(this$, switch$) {
    const tupledArg = [this$.property_2, new String$(0, ((switch$_1) => FontClasses_FontFeatureSettings__settingToString(this$, new Font_FeatureSetting(25), switch$_1))(switch$))];
    return [tupledArg[0], tupledArg[1]];
}

function FontClasses_FontFeatureSettings__settingToString(this$, value, switch$) {
    return `"${MasterTypeHelpers_stringifyICssValue(value)}" ${switch$}`;
}

export class FontClasses_FontVariantNumeric extends CssRuleWithNormal {
    constructor(property) {
        super(property);
        this.property_2 = property;
    }
}

export function FontClasses_FontVariantNumeric$reflection() {
    return class_type("Fss.Types.FontClasses.FontVariantNumeric", void 0, FontClasses_FontVariantNumeric, CssRuleWithNormal$reflection());
}

export function FontClasses_FontVariantNumeric_$ctor_Z207A3CFB(property) {
    return new FontClasses_FontVariantNumeric(property);
}

export function FontClasses_FontVariantNumeric__get_ordinal(this$) {
    const tupledArg = [this$.property_2, new Font_VariantNumeric(0)];
    return [tupledArg[0], tupledArg[1]];
}

export function FontClasses_FontVariantNumeric__get_slashedZero(this$) {
    const tupledArg = [this$.property_2, new Font_VariantNumeric(1)];
    return [tupledArg[0], tupledArg[1]];
}

export function FontClasses_FontVariantNumeric__get_liningNums(this$) {
    const tupledArg = [this$.property_2, new Font_VariantNumeric(2)];
    return [tupledArg[0], tupledArg[1]];
}

export function FontClasses_FontVariantNumeric__get_oldstyleNums(this$) {
    const tupledArg = [this$.property_2, new Font_VariantNumeric(3)];
    return [tupledArg[0], tupledArg[1]];
}

export function FontClasses_FontVariantNumeric__get_proportionalNums(this$) {
    const tupledArg = [this$.property_2, new Font_VariantNumeric(4)];
    return [tupledArg[0], tupledArg[1]];
}

export function FontClasses_FontVariantNumeric__get_tabularNums(this$) {
    const tupledArg = [this$.property_2, new Font_VariantNumeric(5)];
    return [tupledArg[0], tupledArg[1]];
}

export function FontClasses_FontVariantNumeric__get_diagonalFractions(this$) {
    const tupledArg = [this$.property_2, new Font_VariantNumeric(6)];
    return [tupledArg[0], tupledArg[1]];
}

export function FontClasses_FontVariantNumeric__get_stackedFractions(this$) {
    const tupledArg = [this$.property_2, new Font_VariantNumeric(7)];
    return [tupledArg[0], tupledArg[1]];
}

export class FontClasses_FontVariantCaps extends CssRuleWithNormal {
    constructor(property) {
        super(property);
        this.property_2 = property;
    }
}

export function FontClasses_FontVariantCaps$reflection() {
    return class_type("Fss.Types.FontClasses.FontVariantCaps", void 0, FontClasses_FontVariantCaps, CssRuleWithNormal$reflection());
}

export function FontClasses_FontVariantCaps_$ctor_Z207A3CFB(property) {
    return new FontClasses_FontVariantCaps(property);
}

export function FontClasses_FontVariantCaps__get_smallCaps(this$) {
    const tupledArg = [this$.property_2, new Font_VariantCaps(0)];
    return [tupledArg[0], tupledArg[1]];
}

export function FontClasses_FontVariantCaps__get_allSmallCaps(this$) {
    const tupledArg = [this$.property_2, new Font_VariantCaps(1)];
    return [tupledArg[0], tupledArg[1]];
}

export function FontClasses_FontVariantCaps__get_petiteCaps(this$) {
    const tupledArg = [this$.property_2, new Font_VariantCaps(2)];
    return [tupledArg[0], tupledArg[1]];
}

export function FontClasses_FontVariantCaps__get_allPetiteCaps(this$) {
    const tupledArg = [this$.property_2, new Font_VariantCaps(3)];
    return [tupledArg[0], tupledArg[1]];
}

export function FontClasses_FontVariantCaps__get_unicase(this$) {
    const tupledArg = [this$.property_2, new Font_VariantCaps(4)];
    return [tupledArg[0], tupledArg[1]];
}

export function FontClasses_FontVariantCaps__get_titlingCaps(this$) {
    const tupledArg = [this$.property_2, new Font_VariantCaps(5)];
    return [tupledArg[0], tupledArg[1]];
}

export class FontClasses_FontVariantEastAsian extends CssRuleWithNormal {
    constructor(property) {
        super(property);
        this.property_2 = property;
    }
}

export function FontClasses_FontVariantEastAsian$reflection() {
    return class_type("Fss.Types.FontClasses.FontVariantEastAsian", void 0, FontClasses_FontVariantEastAsian, CssRuleWithNormal$reflection());
}

export function FontClasses_FontVariantEastAsian_$ctor_Z207A3CFB(property) {
    return new FontClasses_FontVariantEastAsian(property);
}

export function FontClasses_FontVariantEastAsian__get_ruby(this$) {
    const tupledArg = [this$.property_2, new Font_VariantEastAsian(0)];
    return [tupledArg[0], tupledArg[1]];
}

export function FontClasses_FontVariantEastAsian__get_jis78(this$) {
    const tupledArg = [this$.property_2, new Font_VariantEastAsian(1)];
    return [tupledArg[0], tupledArg[1]];
}

export function FontClasses_FontVariantEastAsian__get_jis83(this$) {
    const tupledArg = [this$.property_2, new Font_VariantEastAsian(2)];
    return [tupledArg[0], tupledArg[1]];
}

export function FontClasses_FontVariantEastAsian__get_jis90(this$) {
    const tupledArg = [this$.property_2, new Font_VariantEastAsian(3)];
    return [tupledArg[0], tupledArg[1]];
}

export function FontClasses_FontVariantEastAsian__get_jis04(this$) {
    const tupledArg = [this$.property_2, new Font_VariantEastAsian(4)];
    return [tupledArg[0], tupledArg[1]];
}

export function FontClasses_FontVariantEastAsian__get_simplified(this$) {
    const tupledArg = [this$.property_2, new Font_VariantEastAsian(5)];
    return [tupledArg[0], tupledArg[1]];
}

export function FontClasses_FontVariantEastAsian__get_traditional(this$) {
    const tupledArg = [this$.property_2, new Font_VariantEastAsian(6)];
    return [tupledArg[0], tupledArg[1]];
}

export function FontClasses_FontVariantEastAsian__get_fullWidth(this$) {
    const tupledArg = [this$.property_2, new Font_VariantEastAsian(7)];
    return [tupledArg[0], tupledArg[1]];
}

export function FontClasses_FontVariantEastAsian__get_proportionalWidth(this$) {
    const tupledArg = [this$.property_2, new Font_VariantEastAsian(8)];
    return [tupledArg[0], tupledArg[1]];
}

export class FontClasses_FontVariantLigatures extends CssRuleWithNormalNone {
    constructor(property) {
        super(property);
        this.property_3 = property;
    }
}

export function FontClasses_FontVariantLigatures$reflection() {
    return class_type("Fss.Types.FontClasses.FontVariantLigatures", void 0, FontClasses_FontVariantLigatures, CssRuleWithNormalNone$reflection());
}

export function FontClasses_FontVariantLigatures_$ctor_Z207A3CFB(property) {
    return new FontClasses_FontVariantLigatures(property);
}

export function FontClasses_FontVariantLigatures__get_commonLigatures(this$) {
    const tupledArg = [this$.property_3, new Font_VariantLigature(0)];
    return [tupledArg[0], tupledArg[1]];
}

export function FontClasses_FontVariantLigatures__get_noCommonLigatures(this$) {
    const tupledArg = [this$.property_3, new Font_VariantLigature(1)];
    return [tupledArg[0], tupledArg[1]];
}

export function FontClasses_FontVariantLigatures__get_discretionaryLigatures(this$) {
    const tupledArg = [this$.property_3, new Font_VariantLigature(2)];
    return [tupledArg[0], tupledArg[1]];
}

export function FontClasses_FontVariantLigatures__get_noDiscretionaryLigatures(this$) {
    const tupledArg = [this$.property_3, new Font_VariantLigature(3)];
    return [tupledArg[0], tupledArg[1]];
}

export function FontClasses_FontVariantLigatures__get_historicalLigatures(this$) {
    const tupledArg = [this$.property_3, new Font_VariantLigature(4)];
    return [tupledArg[0], tupledArg[1]];
}

export function FontClasses_FontVariantLigatures__get_noHistoricalLigatures(this$) {
    const tupledArg = [this$.property_3, new Font_VariantLigature(5)];
    return [tupledArg[0], tupledArg[1]];
}

export function FontClasses_FontVariantLigatures__get_contextual(this$) {
    const tupledArg = [this$.property_3, new Font_VariantLigature(6)];
    return [tupledArg[0], tupledArg[1]];
}

export function FontClasses_FontVariantLigatures__get_noContextual(this$) {
    const tupledArg = [this$.property_3, new Font_VariantLigature(7)];
    return [tupledArg[0], tupledArg[1]];
}

export class FontClasses_FontVariantPosition extends CssRule {
    constructor(property) {
        super(property);
        this.property_1 = property;
    }
}

export function FontClasses_FontVariantPosition$reflection() {
    return class_type("Fss.Types.FontClasses.FontVariantPosition", void 0, FontClasses_FontVariantPosition, CssRule$reflection());
}

export function FontClasses_FontVariantPosition_$ctor_Z207A3CFB(property) {
    return new FontClasses_FontVariantPosition(property);
}

export function FontClasses_FontVariantPosition__get_sub(this$) {
    const tupledArg = [this$.property_1, new Font_VariantPosition(0)];
    return [tupledArg[0], tupledArg[1]];
}

export function FontClasses_FontVariantPosition__get_super(this$) {
    const tupledArg = [this$.property_1, new Font_VariantPosition(1)];
    return [tupledArg[0], tupledArg[1]];
}

//# sourceMappingURL=Font.fs.js.map
