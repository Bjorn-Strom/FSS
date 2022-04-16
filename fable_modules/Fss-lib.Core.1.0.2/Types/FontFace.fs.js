import { toString, Union } from "../../fable-library.3.7.9/Types.js";
import { class_type, union_type, string_type } from "../../fable-library.3.7.9/Reflection.js";
import { Stringed, Normal, Int, Auto, MasterTypeHelpers_stringifyIFontFaceValue, String$, UrlMaster, MasterTypeHelpers_stringifyICssValue } from "./MasterTypes.fs.js";
import { Angle$reflection } from "./Units.fs.js";
import { Helpers_toKebabCase } from "../Utilities.fs.js";
import { join } from "../../fable-library.3.7.9/String.js";
import { map } from "../../fable-library.3.7.9/List.js";

export class FontFace_Format extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["Truetype", "Opentype", "EmpbeddedOpentype", "Woff", "Woff2", "Svg"];
    }
    StringifyFontFace() {
        const this$ = this;
        switch (this$.tag) {
            case 1: {
                const url_1 = this$.fields[0];
                return `url(${url_1}) format('opentype')`;
            }
            case 2: {
                const url_2 = this$.fields[0];
                return `url(${url_2}) format('empedded-opentype')`;
            }
            case 3: {
                const url_3 = this$.fields[0];
                return `url(${url_3}) format('woff')`;
            }
            case 4: {
                const url_4 = this$.fields[0];
                return `url(${url_4}) format('woff2')`;
            }
            case 5: {
                const url_5 = this$.fields[0];
                return `url(${url_5}) format('svg')`;
            }
            default: {
                const url = this$.fields[0];
                return `url(${url}) format('truetype')`;
            }
        }
    }
}

export function FontFace_Format$reflection() {
    return union_type("Fss.Types.FontFace.Format", [], FontFace_Format, () => [[["Item", string_type]], [["Item", string_type]], [["Item", string_type]], [["Item", string_type]], [["Item", string_type]], [["Item", string_type]]]);
}

export class FontFace_Display extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["Block", "Swap", "Fallback", "Optional"];
    }
    StringifyFontFace() {
        const this$ = this;
        return toString(this$).toLocaleLowerCase();
    }
}

export function FontFace_Display$reflection() {
    return union_type("Fss.Types.FontFace.Display", [], FontFace_Display, () => [[], [], [], []]);
}

export class FontFace_Style extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["Normal", "Italic", "Oblique", "ObliqueAngle", "ObliqueAngleRange"];
    }
    StringifyFontFace() {
        const this$ = this;
        switch (this$.tag) {
            case 3: {
                const angle = this$.fields[0];
                return `oblique ${MasterTypeHelpers_stringifyICssValue(angle)}`;
            }
            case 4: {
                const range = this$.fields[1];
                const angle_1 = this$.fields[0];
                return `oblique ${MasterTypeHelpers_stringifyICssValue(angle_1)} ${MasterTypeHelpers_stringifyICssValue(range)}`;
            }
            default: {
                return toString(this$).toLocaleLowerCase();
            }
        }
    }
}

export function FontFace_Style$reflection() {
    return union_type("Fss.Types.FontFace.Style", [], FontFace_Style, () => [[], [], [], [["Item", Angle$reflection()]], [["Item1", Angle$reflection()], ["Item2", Angle$reflection()]]]);
}

export class FontFace_Stretch extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["UltraCondensed", "ExtraCondensed", "Condensed", "SemiCondensed", "Normal", "SemiExpanded", "Expanded", "ExtraExpanded", "UltraExpanded"];
    }
    StringifyFontFace() {
        const this$ = this;
        return Helpers_toKebabCase(this$);
    }
}

export function FontFace_Stretch$reflection() {
    return union_type("Fss.Types.FontFace.Stretch", [], FontFace_Stretch, () => [[], [], [], [], [], [], [], [], []]);
}

export class FontFaceClasses_Src {
    constructor(property) {
        this.property = property;
    }
}

export function FontFaceClasses_Src$reflection() {
    return class_type("Fss.Types.FontFaceClasses.Src", void 0, FontFaceClasses_Src);
}

export function FontFaceClasses_Src_$ctor_9401DF4(property) {
    return new FontFaceClasses_Src(property);
}

export function FontFaceClasses_Src__url_Z721C83C5(this$, url) {
    const tupledArg = [this$.property, new UrlMaster(0, url)];
    return [tupledArg[0], tupledArg[1]];
}

export function FontFaceClasses_Src__truetype_Z721C83C5(this$, url) {
    const tupledArg = [this$.property, new FontFace_Format(0, url)];
    return [tupledArg[0], tupledArg[1]];
}

export function FontFaceClasses_Src__opentype_Z721C83C5(this$, url) {
    const tupledArg = [this$.property, new FontFace_Format(1, url)];
    return [tupledArg[0], tupledArg[1]];
}

export function FontFaceClasses_Src__empbeddedOpentype_Z721C83C5(this$, url) {
    const tupledArg = [this$.property, new FontFace_Format(2, url)];
    return [tupledArg[0], tupledArg[1]];
}

export function FontFaceClasses_Src__woff_Z721C83C5(this$, url) {
    const tupledArg = [this$.property, new FontFace_Format(3, url)];
    return [tupledArg[0], tupledArg[1]];
}

export function FontFaceClasses_Src__woff2_Z721C83C5(this$, url) {
    const tupledArg = [this$.property, new FontFace_Format(4, url)];
    return [tupledArg[0], tupledArg[1]];
}

export function FontFaceClasses_Src__svg_Z721C83C5(this$, url) {
    const tupledArg = [this$.property, new FontFace_Format(5, url)];
    return [tupledArg[0], tupledArg[1]];
}

export function FontFaceClasses_Src__sources_1334CEF1(this$, urls) {
    const value = new String$(0, join(", ", map((x) => MasterTypeHelpers_stringifyICssValue(new UrlMaster(0, x)), urls)));
    const tupledArg = [this$.property, value];
    return [tupledArg[0], tupledArg[1]];
}

export function FontFaceClasses_Src__sources_Z23FD7E63(this$, formatUrls) {
    const value = new String$(0, join(", ", map(MasterTypeHelpers_stringifyIFontFaceValue, formatUrls)));
    const tupledArg = [this$.property, value];
    return [tupledArg[0], tupledArg[1]];
}

export class FontFaceClasses_FontDisplay {
    constructor(property) {
        this.property = property;
    }
}

export function FontFaceClasses_FontDisplay$reflection() {
    return class_type("Fss.Types.FontFaceClasses.FontDisplay", void 0, FontFaceClasses_FontDisplay);
}

export function FontFaceClasses_FontDisplay_$ctor_9401DF4(property) {
    return new FontFaceClasses_FontDisplay(property);
}

export function FontFaceClasses_FontDisplay__get_auto(this$) {
    const tupledArg = [this$.property, new Auto(0)];
    return [tupledArg[0], tupledArg[1]];
}

export function FontFaceClasses_FontDisplay__get_block(this$) {
    const tupledArg = [this$.property, new FontFace_Display(0)];
    return [tupledArg[0], tupledArg[1]];
}

export function FontFaceClasses_FontDisplay__get_swap(this$) {
    const tupledArg = [this$.property, new FontFace_Display(1)];
    return [tupledArg[0], tupledArg[1]];
}

export function FontFaceClasses_FontDisplay__get_fallback(this$) {
    const tupledArg = [this$.property, new FontFace_Display(2)];
    return [tupledArg[0], tupledArg[1]];
}

export function FontFaceClasses_FontDisplay__get_optional(this$) {
    const tupledArg = [this$.property, new FontFace_Display(3)];
    return [tupledArg[0], tupledArg[1]];
}

export class FontFaceClasses_FontStyle {
    constructor(property) {
        this.property = property;
    }
}

export function FontFaceClasses_FontStyle$reflection() {
    return class_type("Fss.Types.FontFaceClasses.FontStyle", void 0, FontFaceClasses_FontStyle);
}

export function FontFaceClasses_FontStyle_$ctor_9401DF4(property) {
    return new FontFaceClasses_FontStyle(property);
}

export function FontFaceClasses_FontStyle__get_normal(this$) {
    const tupledArg = [this$.property, new FontFace_Style(0)];
    return [tupledArg[0], tupledArg[1]];
}

export function FontFaceClasses_FontStyle__get_italic(this$) {
    const tupledArg = [this$.property, new FontFace_Style(1)];
    return [tupledArg[0], tupledArg[1]];
}

export function FontFaceClasses_FontStyle__get_oblique(this$) {
    const tupledArg = [this$.property, new FontFace_Style(2)];
    return [tupledArg[0], tupledArg[1]];
}

export function FontFaceClasses_FontStyle__obliqueAngle_CEE3389(this$, angle) {
    const tupledArg = [this$.property, new FontFace_Style(3, angle)];
    return [tupledArg[0], tupledArg[1]];
}

export function FontFaceClasses_FontStyle__obliqueAngleRange_Z59A568E0(this$, angle, range) {
    const tupledArg = [this$.property, new FontFace_Style(4, angle, range)];
    return [tupledArg[0], tupledArg[1]];
}

export class FontFaceClasses_FontStretch {
    constructor(property) {
        this.property = property;
    }
}

export function FontFaceClasses_FontStretch$reflection() {
    return class_type("Fss.Types.FontFaceClasses.FontStretch", void 0, FontFaceClasses_FontStretch);
}

export function FontFaceClasses_FontStretch_$ctor_9401DF4(property) {
    return new FontFaceClasses_FontStretch(property);
}

export function FontFaceClasses_FontStretch__value_2D904CD3(this$, stretch) {
    const tupledArg = [this$.property, stretch];
    return [tupledArg[0], tupledArg[1]];
}

export function FontFaceClasses_FontStretch__value_1FA41A59(this$, stretch) {
    const value = new String$(0, join(" ", map(MasterTypeHelpers_stringifyICssValue, stretch)));
    const tupledArg = [this$.property, value];
    return [tupledArg[0], tupledArg[1]];
}

export function FontFaceClasses_FontStretch__get_ultraCondensed(this$) {
    const tupledArg = [this$.property, new FontFace_Stretch(0)];
    return [tupledArg[0], tupledArg[1]];
}

export function FontFaceClasses_FontStretch__get_extraCondensed(this$) {
    const tupledArg = [this$.property, new FontFace_Stretch(1)];
    return [tupledArg[0], tupledArg[1]];
}

export function FontFaceClasses_FontStretch__get_condensed(this$) {
    const tupledArg = [this$.property, new FontFace_Stretch(2)];
    return [tupledArg[0], tupledArg[1]];
}

export function FontFaceClasses_FontStretch__get_semiCondensed(this$) {
    const tupledArg = [this$.property, new FontFace_Stretch(3)];
    return [tupledArg[0], tupledArg[1]];
}

export function FontFaceClasses_FontStretch__get_normal(this$) {
    const tupledArg = [this$.property, new FontFace_Style(0)];
    return [tupledArg[0], tupledArg[1]];
}

export function FontFaceClasses_FontStretch__get_semiExpanded(this$) {
    const tupledArg = [this$.property, new FontFace_Stretch(5)];
    return [tupledArg[0], tupledArg[1]];
}

export function FontFaceClasses_FontStretch__get_expanded(this$) {
    const tupledArg = [this$.property, new FontFace_Stretch(6)];
    return [tupledArg[0], tupledArg[1]];
}

export function FontFaceClasses_FontStretch__get_extraExpanded(this$) {
    const tupledArg = [this$.property, new FontFace_Stretch(7)];
    return [tupledArg[0], tupledArg[1]];
}

export function FontFaceClasses_FontStretch__get_ultraExpanded(this$) {
    const tupledArg = [this$.property, new FontFace_Stretch(8)];
    return [tupledArg[0], tupledArg[1]];
}

export class FontFaceClasses_FontWeight {
    constructor(property) {
        this.property = property;
    }
}

export function FontFaceClasses_FontWeight$reflection() {
    return class_type("Fss.Types.FontFaceClasses.FontWeight", void 0, FontFaceClasses_FontWeight);
}

export function FontFaceClasses_FontWeight_$ctor_9401DF4(property) {
    return new FontFaceClasses_FontWeight(property);
}

export function FontFaceClasses_FontWeight__value_Z524259A4(this$, weight) {
    const tupledArg = [this$.property, new Int(0, weight)];
    return [tupledArg[0], tupledArg[1]];
}

export function FontFaceClasses_FontWeight__get_normal(this$) {
    const tupledArg = [this$.property, new Normal(0)];
    return [tupledArg[0], tupledArg[1]];
}

export function FontFaceClasses_FontWeight__get_bold(this$) {
    const tupledArg = [this$.property, new String$(0, "Bold")];
    return [tupledArg[0], tupledArg[1]];
}

export class FontFaceClasses_SizeAdjust {
    constructor(property) {
        this.property = property;
    }
}

export function FontFaceClasses_SizeAdjust$reflection() {
    return class_type("Fss.Types.FontFaceClasses.SizeAdjust", void 0, FontFaceClasses_SizeAdjust);
}

export function FontFaceClasses_SizeAdjust_$ctor_9401DF4(property) {
    return new FontFaceClasses_SizeAdjust(property);
}

export function FontFaceClasses_SizeAdjust__value_2D904CD3(this$, adjust) {
    const tupledArg = [this$.property, adjust];
    return [tupledArg[0], tupledArg[1]];
}

export class FontFaceClasses_UnicodeRange {
    constructor(property) {
        this.property = property;
    }
}

export function FontFaceClasses_UnicodeRange$reflection() {
    return class_type("Fss.Types.FontFaceClasses.UnicodeRange", void 0, FontFaceClasses_UnicodeRange);
}

export function FontFaceClasses_UnicodeRange_$ctor_9401DF4(property) {
    return new FontFaceClasses_UnicodeRange(property);
}

export function FontFaceClasses_UnicodeRange__value_Z721C83C5(this$, range) {
    const tupledArg = [this$.property, new String$(0, range)];
    return [tupledArg[0], tupledArg[1]];
}

export function FontFaceClasses_UnicodeRange__value_1334CEF1(this$, ranges) {
    const value = join(", ", ranges);
    const tupledArg = [this$.property, new String$(0, value)];
    return [tupledArg[0], tupledArg[1]];
}

export class FontFaceClasses_LineGapOverride {
    constructor(property) {
        this.property = property;
    }
}

export function FontFaceClasses_LineGapOverride$reflection() {
    return class_type("Fss.Types.FontFaceClasses.LineGapOverride", void 0, FontFaceClasses_LineGapOverride);
}

export function FontFaceClasses_LineGapOverride_$ctor_9401DF4(property) {
    return new FontFaceClasses_LineGapOverride(property);
}

export function FontFaceClasses_LineGapOverride__get_normal(this$) {
    const tupledArg = [this$.property, new FontFace_Style(0)];
    return [tupledArg[0], tupledArg[1]];
}

export function FontFaceClasses_LineGapOverride__value_2D904CD3(this$, adjust) {
    const tupledArg = [this$.property, adjust];
    return [tupledArg[0], tupledArg[1]];
}

function FontFaceClasses_variationToString(setting, axis) {
    return `'${setting}' ${axis}`;
}

export class FontFaceClasses_FontVariationSettings {
    constructor(property) {
        this.property = property;
    }
}

export function FontFaceClasses_FontVariationSettings$reflection() {
    return class_type("Fss.Types.FontFaceClasses.FontVariationSettings", void 0, FontFaceClasses_FontVariationSettings);
}

export function FontFaceClasses_FontVariationSettings_$ctor_9401DF4(property) {
    return new FontFaceClasses_FontVariationSettings(property);
}

export function FontFaceClasses_FontVariationSettings__get_normal(this$) {
    const tupledArg = [this$.property, new FontFace_Style(0)];
    return [tupledArg[0], tupledArg[1]];
}

export function FontFaceClasses_FontVariationSettings__value_146B04A0(this$, setting, axis) {
    const tupledArg = [this$.property, new String$(0, FontFaceClasses_variationToString(setting, axis))];
    return [tupledArg[0], tupledArg[1]];
}

export function FontFaceClasses_FontVariationSettings__value_Z3483FB7B(this$, settings) {
    const value = new String$(0, join(", ", map((tupledArg) => FontFaceClasses_variationToString(tupledArg[0], tupledArg[1]), settings)));
    const tupledArg_1 = [this$.property, value];
    return [tupledArg_1[0], tupledArg_1[1]];
}

export class FontFaceClasses_AscentDescentOverride {
    constructor(property) {
        this.property = property;
    }
}

export function FontFaceClasses_AscentDescentOverride$reflection() {
    return class_type("Fss.Types.FontFaceClasses.AscentDescentOverride", void 0, FontFaceClasses_AscentDescentOverride);
}

export function FontFaceClasses_AscentDescentOverride_$ctor_9401DF4(property) {
    return new FontFaceClasses_AscentDescentOverride(property);
}

export function FontFaceClasses_AscentDescentOverride__get_normal(this$) {
    const tupledArg = [this$.property, new FontFace_Style(0)];
    return [tupledArg[0], tupledArg[1]];
}

export function FontFaceClasses_AscentDescentOverride__value_2D904CD3(this$, adjust) {
    const tupledArg = [this$.property, adjust];
    return [tupledArg[0], tupledArg[1]];
}

export class FontFaceClasses_FontFamily {
    constructor(property) {
        this.property = property;
    }
}

export function FontFaceClasses_FontFamily$reflection() {
    return class_type("Fss.Types.FontFaceClasses.FontFamily", void 0, FontFaceClasses_FontFamily);
}

export function FontFaceClasses_FontFamily_$ctor_9401DF4(property) {
    return new FontFaceClasses_FontFamily(property);
}

export function FontFaceClasses_FontFamily__ident_Z721C83C5(this$, ident) {
    const tupledArg = [this$.property, new String$(0, ident)];
    return [tupledArg[0], tupledArg[1]];
}

export function FontFaceClasses_FontFamily__string_Z721C83C5(this$, string) {
    const tupledArg = [this$.property, new Stringed(0, string)];
    return [tupledArg[0], tupledArg[1]];
}

//# sourceMappingURL=FontFace.fs.js.map
