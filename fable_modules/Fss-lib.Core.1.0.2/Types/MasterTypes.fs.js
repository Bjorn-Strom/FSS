import { Dictionary } from "../../fable-library.3.7.9/MutableMap.js";
import { int32ToString, structuralHash, equals } from "../../fable-library.3.7.9/Util.js";
import { addToDict, getItemFromDict } from "../../fable-library.3.7.9/MapUtil.js";
import { Helpers_toKebabCase } from "../Utilities.fs.js";
import { toString, Union } from "../../fable-library.3.7.9/Types.js";
import { list_type, tuple_type, class_type, int32_type, float64_type, string_type, union_type } from "../../fable-library.3.7.9/Reflection.js";
import { Html$reflection } from "./Html.fs.js";
import { join } from "../../fable-library.3.7.9/String.js";
import { map } from "../../fable-library.3.7.9/List.js";

export const MasterTypeHelpers_cache = new Dictionary([], {
    Equals: equals,
    GetHashCode: structuralHash,
});

export function MasterTypeHelpers_stringifyICssValue(cssValue) {
    if (MasterTypeHelpers_cache.has(cssValue)) {
        return getItemFromDict(MasterTypeHelpers_cache, cssValue);
    }
    else {
        const newValue = cssValue.StringifyCss();
        addToDict(MasterTypeHelpers_cache, cssValue, newValue);
        return newValue;
    }
}

export function MasterTypeHelpers_stringifyICounterValue(cssValue) {
    return cssValue.StringifyCounter();
}

export function MasterTypeHelpers_stringifyIFontFaceValue(cssValue) {
    return cssValue.StringifyFontFace();
}

export class Property_FontFaceProperty extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["AscentOverride", "DescentOverride", "FontDisplay", "FontFamily", "FontStretch", "FontStyle", "FontWeight", "FontVariant", "FontFeatureSettings", "FontVariationSettings", "LineGapOverride", "SizeAdjust", "Src", "UnicodeRange"];
    }
    StringifyCss() {
        const this$ = this;
        return Helpers_toKebabCase(this$);
    }
}

export function Property_FontFaceProperty$reflection() {
    return union_type("Fss.Types.Property.FontFaceProperty", [], Property_FontFaceProperty, () => [[], [], [], [], [], [], [], [], [], [], [], [], [], []]);
}

export class Property_CounterProperty extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["System", "Negative", "Prefix", "Suffix", "Range", "Pad", "Fallback", "Symbols", "AdditiveSymbols", "SpeakAs", "NameLabel"];
    }
    StringifyCss() {
        const this$ = this;
        return Helpers_toKebabCase(this$);
    }
}

export function Property_CounterProperty$reflection() {
    return union_type("Fss.Types.Property.CounterProperty", [], Property_CounterProperty, () => [[], [], [], [], [], [], [], [], [], [], []]);
}

export class Property_CssProperty extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["Appearance", "AlignContent", "AlignItems", "AlignSelf", "All", "AnimationDelay", "AnimationDirection", "AnimationDuration", "AnimationFillMode", "AnimationIterationCount", "AnimationName", "AnimationPlayState", "AnimationTimingFunction", "AspectRatio", "BackfaceVisibility", "BackgroundAttachment", "BackgroundBlendMode", "BackgroundClip", "BackgroundColor", "BackgroundImage", "BackgroundOrigin", "BackgroundPosition", "BackgroundRepeat", "BackgroundSize", "BackdropFilter", "Bleed", "Border", "BorderBottomColor", "BorderBottomLeftRadius", "BorderBottomRightRadius", "BorderBottomStyle", "BorderBottomWidth", "BorderBottom", "BorderCollapse", "BorderColor", "BorderImage", "BorderImageOutset", "BorderImageRepeat", "BorderImageSource", "BorderImageSlice", "BorderImageWidth", "BorderLeftColor", "BorderLeftStyle", "BorderLeftWidth", "BorderLeft", "BorderRadius", "BorderRightColor", "BorderRightStyle", "BorderRightWidth", "BorderRight", "BorderSpacing", "BorderStyle", "BorderTopColor", "BorderTopLeftRadius", "BorderTopRightRadius", "BorderTopStyle", "BorderTopWidth", "BorderTop", "BorderWidth", "BorderBlockColor", "Bottom", "BoxDecorationBreak", "BoxShadow", "BoxSizing", "BreakAfter", "BreakBefore", "BreakInside", "CaptionSide", "CaretColor", "Clear", "Clip", "ClipPath", "Color", "ColorAdjust", "Columns", "ColumnCount", "ColumnFill", "ColumnGap", "ColumnRule", "ColumnRuleColor", "ColumnRuleStyle", "ColumnRuleWidth", "ColumnSpan", "ColumnWidth", "Content", "CounterIncrement", "CounterReset", "CounterSet", "CueAfter", "CueBefore", "Cue", "Cursor", "Direction", "Display", "Elevation", "EmptyCells", "Filter", "Flex", "FlexBasis", "FlexDirection", "FontFeatureSettings", "FontVariationSettings", "FlexFlow", "FlexGrow", "FlexShrink", "FlexWrap", "Float", "FontFamily", "FontKerning", "FontLanguageOverride", "FontSizeAdjust", "FontSize", "FontStretch", "FontStyle", "FontDisplay", "FontSynthesis", "FontVariant", "FontVariantAlternates", "FontVariantCaps", "FontVariantEastAsian", "FontVariantLigatures", "FontVariantNumeric", "FontVariantPosition", "FontWeight", "Font", "GridArea", "GridAutoColumns", "GridAutoFlow", "GridAutoRows", "GridColumnEnd", "GridColumnStart", "GridColumn", "GridGap", "GridRowEnd", "GridRowGap", "GridColumnGap", "GridRowStart", "GridRow", "GridTemplateAreas", "GridTemplateColumns", "GridTemplateRows", "GridTemplate", "Grid", "HangingPunctuation", "Height", "Hyphens", "Isolation", "ImageRendering", "JustifyContent", "JustifyItems", "JustifySelf", "Left", "LetterSpacing", "LineBreak", "LineHeight", "ListStyle", "ListStyleImage", "ListStylePosition", "ListStyleType", "LineGapOverride", "MaskClip", "MaskComposite", "MaskImage", "MaskMode", "MaskOrigin", "MaskPosition", "MaskRepeat", "MaskSize", "MarginBottom", "MarginLeft", "MarginRight", "MarginTop", "Margin", "MarginInlineStart", "MarginInlineEnd", "MarginBlockStart", "MarginBlockEnd", "MarkerOffset", "Marks", "MaxHeight", "MaxWidth", "MinHeight", "MinWidth", "MixBlendMode", "NavUp", "NavDown", "NavLeft", "NavRight", "Opacity", "Order", "Orphans", "OutlineColor", "OutlineOffset", "OutlineStyle", "OutlineWidth", "Outline", "Overflow", "OverflowWrap", "OverflowX", "OverflowY", "ObjectFit", "ObjectPosition", "PaddingBottom", "PaddingLeft", "PaddingRight", "PaddingTop", "Padding", "PaddingInlineStart", "PaddingInlineEnd", "PaddingBlockStart", "PaddingBlockEnd", "Page", "PauseAfter", "PauseBefore", "Pause", "PaintOrder", "PointerEvents", "Perspective", "PerspectiveOrigin", "PitchRange", "Pitch", "PlaceContent", "PlaceItems", "PlaceSelf", "PlayDuring", "Position", "Quotes", "Resize", "RestAfter", "RestBefore", "Rest", "Richness", "Right", "Size", "SpeakHeader", "SpeakNumeral", "SpeakPunctuation", "Src", "Speak", "SpeechRate", "Stress", "ScrollBehavior", "ScrollMarginBottom", "ScrollMarginLeft", "ScrollMarginRight", "ScrollMarginTop", "ScrollMargin", "ScrollPaddingBottom", "ScrollPaddingLeft", "ScrollPaddingRight", "ScrollPaddingTop", "ScrollPadding", "ScrollSnapType", "ScrollSnapAlign", "ScrollSnapStop", "SizeAdjust", "OverscrollBehaviorX", "OverscrollBehaviorY", "TabSize", "TableLayout", "TextAlign", "TextAlignLast", "TextDecoration", "TextDecorationColor", "TextDecorationLine", "TextDecorationThickness", "TextDecorationSkip", "TextDecorationSkipInk", "TextDecorationStyle", "TextIndent", "TextOverflow", "TextShadow", "TextTransform", "TextEmphasis", "TextEmphasisColor", "TextEmphasisPosition", "TextEmphasisStyle", "TextUnderlineOffset", "TextUnderlinePosition", "TextSizeAdjust", "TextOrientation", "TextRendering", "TextJustify", "Top", "Transform", "TransformOrigin", "TransformStyle", "Transition", "TransitionDelay", "TransitionDuration", "TransitionProperty", "TransitionTimingFunction", "UnicodeBidi", "UnicodeRange", "UserSelect", "VerticalAlign", "Visibility", "VoiceBalance", "VoiceDuration", "VoiceFamily", "VoicePitch", "VoiceRange", "VoiceRate", "VoiceStress", "VoiceVolume", "Volume", "WhiteSpace", "Widows", "Width", "WillChange", "WordBreak", "WordSpacing", "WordWrap", "WritingMode", "ZIndex", "Active", "AnyLink", "Blank", "Checked", "Current", "Disabled", "Empty", "Enabled", "FirstChild", "FirstOfType", "Focus", "FocusVisible", "FocusWithin", "Future", "Hover", "Indeterminate", "Invalid", "InRange", "Lang", "LastChild", "LastOfType", "Link", "LocalLink", "NthChild", "NthLastChild", "NthLastOfType", "NthOfType", "OnlyChild", "OnlyOfType", "Optional", "OutOfRange", "Past", "Playing", "Paused", "PlaceholderShown", "ReadOnly", "ReadWrite", "Required", "Root", "Scope", "Target", "TargetWithin", "Valid", "Visited", "UserInvalid", "After", "Before", "FirstLetter", "FirstLine", "Selection", "Marker", "AlignmentBaseline", "BaselineShift", "DominantBaseline", "TextAnchor", "ClipRule", "FloodColor", "FloodOpacity", "LightingColor", "StopColor", "StopOpacity", "ColorInterpolation", "ColorInterpolationFilters", "Label", "Fill", "FillOpacity", "FillRule", "ShapeRendering", "Stroke", "StrokeOpacity", "StrokeDasharray", "StrokeDashoffset", "StrokeLinecap", "StrokeLinejoin", "StrokeMiterlimit", "StrokeWidth", "NameLabel", "AdjacentSibling", "GeneralSibling", "Child", "Descendant", "Custom", "Media"];
    }
    StringifyCss() {
        const this$ = this;
        switch (this$.tag) {
            case 333: {
                const l = this$.fields[0];
                return `lang(${l})`;
            }
            case 338: {
                const n = this$.fields[0];
                return `nth-child(${n})`;
            }
            case 339: {
                const n_1 = this$.fields[0];
                return `nth-last-child(${n_1})`;
            }
            case 341: {
                const n_2 = this$.fields[0];
                return `nth-of-type(${n_2})`;
            }
            case 340: {
                const n_3 = this$.fields[0];
                return `nth-last-of-type(${n_3})`;
            }
            case 392: {
                const html = this$.fields[0];
                return ` + ${toString(html).toLocaleLowerCase()}`;
            }
            case 393: {
                const html_1 = this$.fields[0];
                return ` ~ ${toString(html_1).toLocaleLowerCase()}`;
            }
            case 394: {
                const html_2 = this$.fields[0];
                return ` > ${toString(html_2).toLocaleLowerCase()}`;
            }
            case 395: {
                const html_3 = this$.fields[0];
                return ` ${toString(html_3).toLocaleLowerCase()}`;
            }
            case 396: {
                const c = this$.fields[0];
                return c.toLocaleLowerCase();
            }
            default: {
                return Helpers_toKebabCase(this$);
            }
        }
    }
}

export function Property_CssProperty$reflection() {
    return union_type("Fss.Types.Property.CssProperty", [], Property_CssProperty, () => [[], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [["Item", string_type]], [], [], [], [], [["Item", string_type]], [["Item", string_type]], [["Item", string_type]], [["Item", string_type]], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [["Item", Html$reflection()]], [["Item", Html$reflection()]], [["Item", Html$reflection()]], [["Item", Html$reflection()]], [["Item", string_type]], []]);
}

export class None$0027 extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["None\u0027"];
    }
    StringifyCss() {
        return "none";
    }
}

export function None$0027$reflection() {
    return union_type("Fss.Types.None\u0027", [], None$0027, () => [[]]);
}

export class Auto extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["Auto"];
    }
    StringifyFontFace() {
        const this$ = this;
        return MasterTypeHelpers_stringifyICssValue(this$);
    }
    StringifyCounter() {
        const this$ = this;
        return MasterTypeHelpers_stringifyICssValue(this$);
    }
    StringifyCss() {
        return "auto";
    }
}

export function Auto$reflection() {
    return union_type("Fss.Types.Auto", [], Auto, () => [[]]);
}

export class Normal extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["Normal"];
    }
    StringifyCss() {
        return "normal";
    }
    StringifyFontFace() {
        const this$ = this;
        return MasterTypeHelpers_stringifyICssValue(this$);
    }
}

export function Normal$reflection() {
    return union_type("Fss.Types.Normal", [], Normal, () => [[]]);
}

export class Float extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["Float"];
    }
    StringifyCss() {
        const this$ = this;
        const f = this$.fields[0];
        return f.toString();
    }
}

export function Float$reflection() {
    return union_type("Fss.Types.Float", [], Float, () => [[["Item", float64_type]]]);
}

export class Int extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["Int"];
    }
    StringifyFontFace() {
        const this$ = this;
        return MasterTypeHelpers_stringifyICssValue(this$);
    }
    StringifyCss() {
        const this$ = this;
        const i = this$.fields[0] | 0;
        return int32ToString(i);
    }
}

export function Int$reflection() {
    return union_type("Fss.Types.Int", [], Int, () => [[["Item", int32_type]]]);
}

export class Char extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["Char"];
    }
    StringifyCss() {
        const this$ = this;
        const c = this$.fields[0];
        return `'${c}'`;
    }
}

export function Char$reflection() {
    return union_type("Fss.Types.Char", [], Char, () => [[["Item", string_type]]]);
}

export class String$ extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["String"];
    }
    StringifyCounter() {
        const this$ = this;
        return MasterTypeHelpers_stringifyICssValue(this$);
    }
    StringifyFontFace() {
        const this$ = this;
        return MasterTypeHelpers_stringifyICssValue(this$);
    }
    StringifyCss() {
        const this$ = this;
        const s = this$.fields[0];
        return s;
    }
}

export function String$$reflection() {
    return union_type("Fss.Types.String", [], String$, () => [[["Item", string_type]]]);
}

export class Stringed extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["Stringed"];
    }
    StringifyFontFace() {
        const this$ = this;
        return MasterTypeHelpers_stringifyICssValue(this$);
    }
    StringifyCounter() {
        const this$ = this;
        return MasterTypeHelpers_stringifyICssValue(this$);
    }
    StringifyCss() {
        const this$ = this;
        const s = this$.fields[0];
        return `"${s}"`;
    }
}

export function Stringed$reflection() {
    return union_type("Fss.Types.Stringed", [], Stringed, () => [[["Item", string_type]]]);
}

export class NameLabel extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["NameLabel"];
    }
    StringifyCss() {
        const this$ = this;
        return NameLabel__Unwrap(this$);
    }
    StringifyCounter() {
        const this$ = this;
        return NameLabel__Unwrap(this$);
    }
}

export function NameLabel$reflection() {
    return union_type("Fss.Types.NameLabel", [], NameLabel, () => [[["Item", string_type]]]);
}

export function NameLabel__Unwrap(this$) {
    const n = this$.fields[0];
    return n;
}

export class CssRule {
    constructor(property) {
        this.property = property;
    }
}

export function CssRule$reflection() {
    return class_type("Fss.Types.CssRule", void 0, CssRule);
}

export function CssRule_$ctor_Z207A3CFB(property) {
    return new CssRule(property);
}

export class Keywords extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["Inherit", "Initial", "Unset", "Revert"];
    }
    StringifyCss() {
        const this$ = this;
        return toString(this$).toLocaleLowerCase();
    }
}

export function Keywords$reflection() {
    return union_type("Fss.Types.Keywords", [], Keywords, () => [[], [], [], []]);
}

export function CssRule__value_Z61D3073E(this$, keyword) {
    const tupledArg = [this$.property, keyword];
    return [tupledArg[0], tupledArg[1]];
}

export function CssRule__get_initial(this$) {
    const tupledArg = [this$.property, new Keywords(1)];
    return [tupledArg[0], tupledArg[1]];
}

export function CssRule__get_inherit$0027(this$) {
    const tupledArg = [this$.property, new Keywords(0)];
    return [tupledArg[0], tupledArg[1]];
}

export function CssRule__get_unset(this$) {
    const tupledArg = [this$.property, new Keywords(2)];
    return [tupledArg[0], tupledArg[1]];
}

export function CssRule__get_revert(this$) {
    const tupledArg = [this$.property, new Keywords(3)];
    return [tupledArg[0], tupledArg[1]];
}

export class ImportantMaster extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["ImportantMaster"];
    }
    StringifyCss() {
        const this$ = this;
        const value = this$.fields[0];
        return `${MasterTypeHelpers_stringifyICssValue(value)} !important`;
    }
}

export function ImportantMaster$reflection() {
    return union_type("Fss.Types.ImportantMaster", [], ImportantMaster, () => [[["Item", class_type("Fss.Types.ICssValue")]]]);
}

export class Pseudo extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["PseudoClassMaster", "PseudoElementMaster"];
    }
    StringifyCss() {
        const this$ = this;
        if (this$.tag === 1) {
            const ps_2 = this$.fields[0];
            const ps_3 = join("; ", map((tupledArg_1) => {
                const name_1 = tupledArg_1[0];
                const property_1 = tupledArg_1[1];
                return `${MasterTypeHelpers_stringifyICssValue(name_1)}: ${property_1.StringifyCss()}`;
            }, ps_2));
            return `${ps_3}`;
        }
        else {
            const ps = this$.fields[0];
            const ps_1 = join("; ", map((tupledArg) => {
                const name = tupledArg[0];
                const property = tupledArg[1];
                return `${MasterTypeHelpers_stringifyICssValue(name)}: ${property.StringifyCss()}`;
            }, ps));
            return `${ps_1}`;
        }
    }
}

export function Pseudo$reflection() {
    return union_type("Fss.Types.Pseudo", [], Pseudo, () => [[["Item", list_type(tuple_type(Property_CssProperty$reflection(), class_type("Fss.Types.ICssValue")))]], [["Item", list_type(tuple_type(Property_CssProperty$reflection(), class_type("Fss.Types.ICssValue")))]]]);
}

export function Pseudo__Unwrap(this$) {
    if (this$.tag === 1) {
        const p_1 = this$.fields[0];
        return p_1;
    }
    else {
        const p = this$.fields[0];
        return p;
    }
}

export class CombinatorMaster extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["CombinatorMaster"];
    }
    StringifyCss() {
        return "";
    }
}

export function CombinatorMaster$reflection() {
    return union_type("Fss.Types.CombinatorMaster", [], CombinatorMaster, () => [[["Item", list_type(tuple_type(Property_CssProperty$reflection(), class_type("Fss.Types.ICssValue")))]]]);
}

export function CombinatorMaster__Unwrap(this$) {
    const c = this$.fields[0];
    return c;
}

export class DividerMaster extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["DividerMaster"];
    }
    StringifyCss() {
        const this$ = this;
        const b = this$.fields[1];
        const a = this$.fields[0];
        return `${a} / ${b}`;
    }
}

export function DividerMaster$reflection() {
    return union_type("Fss.Types.DividerMaster", [], DividerMaster, () => [[["Item1", string_type], ["Item2", string_type]]]);
}

export class UrlMaster extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["UrlMaster"];
    }
    StringifyFontFace() {
        const this$ = this;
        return this$.StringifyCss();
    }
    StringifyCounter() {
        const this$ = this;
        return this$.StringifyCss();
    }
    StringifyCss() {
        const this$ = this;
        const u = this$.fields[0];
        return `url(${u})`;
    }
}

export function UrlMaster$reflection() {
    return union_type("Fss.Types.UrlMaster", [], UrlMaster, () => [[["Item", string_type]]]);
}

export class CustomMaster extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["CustomMaster"];
    }
    StringifyCss() {
        const this$ = this;
        const value = this$.fields[0];
        return value;
    }
}

export function CustomMaster$reflection() {
    return union_type("Fss.Types.CustomMaster", [], CustomMaster, () => [[["Item", string_type]]]);
}

export class PathMaster extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["PathMaster"];
    }
    StringifyCss() {
        const this$ = this;
        const p = this$.fields[0];
        return `path('${p}')`;
    }
}

export function PathMaster$reflection() {
    return union_type("Fss.Types.PathMaster", [], PathMaster, () => [[["Item", string_type]]]);
}

export class CssRuleWithAuto extends CssRule {
    constructor(property) {
        super(property);
        this.property_1 = property;
    }
}

export function CssRuleWithAuto$reflection() {
    return class_type("Fss.Types.CssRuleWithAuto", void 0, CssRuleWithAuto, CssRule$reflection());
}

export function CssRuleWithAuto_$ctor_Z207A3CFB(property) {
    return new CssRuleWithAuto(property);
}

export function CssRuleWithAuto__get_auto(this$) {
    const tupledArg = [this$.property_1, new Auto(0)];
    return [tupledArg[0], tupledArg[1]];
}

export class CssRuleWithNone extends CssRule {
    constructor(property) {
        super(property);
        this.property_1 = property;
    }
}

export function CssRuleWithNone$reflection() {
    return class_type("Fss.Types.CssRuleWithNone", void 0, CssRuleWithNone, CssRule$reflection());
}

export function CssRuleWithNone_$ctor_Z207A3CFB(property) {
    return new CssRuleWithNone(property);
}

export function CssRuleWithNone__get_none(this$) {
    const tupledArg = [this$.property_1, new None$0027(0)];
    return [tupledArg[0], tupledArg[1]];
}

export class CssRuleWithAutoNone extends CssRule {
    constructor(property) {
        super(property);
        this.property_1 = property;
    }
}

export function CssRuleWithAutoNone$reflection() {
    return class_type("Fss.Types.CssRuleWithAutoNone", void 0, CssRuleWithAutoNone, CssRule$reflection());
}

export function CssRuleWithAutoNone_$ctor_Z207A3CFB(property) {
    return new CssRuleWithAutoNone(property);
}

export function CssRuleWithAutoNone__get_auto(this$) {
    const tupledArg = [this$.property_1, new Auto(0)];
    return [tupledArg[0], tupledArg[1]];
}

export function CssRuleWithAutoNone__get_none(this$) {
    const tupledArg = [this$.property_1, new None$0027(0)];
    return [tupledArg[0], tupledArg[1]];
}

export class CssRuleWithNormal extends CssRule {
    constructor(property) {
        super(property);
        this.property_1 = property;
    }
}

export function CssRuleWithNormal$reflection() {
    return class_type("Fss.Types.CssRuleWithNormal", void 0, CssRuleWithNormal, CssRule$reflection());
}

export function CssRuleWithNormal_$ctor_Z207A3CFB(property) {
    return new CssRuleWithNormal(property);
}

export function CssRuleWithNormal__get_normal(this$) {
    const tupledArg = [this$.property_1, new Normal(0)];
    return [tupledArg[0], tupledArg[1]];
}

export class CssRuleWithNormalNone extends CssRuleWithNormal {
    constructor(property) {
        super(property);
        this.property_2 = property;
    }
}

export function CssRuleWithNormalNone$reflection() {
    return class_type("Fss.Types.CssRuleWithNormalNone", void 0, CssRuleWithNormalNone, CssRuleWithNormal$reflection());
}

export function CssRuleWithNormalNone_$ctor_Z207A3CFB(property) {
    return new CssRuleWithNormalNone(property);
}

export function CssRuleWithNormalNone__get_none(this$) {
    const tupledArg = [this$.property_2, new None$0027(0)];
    return [tupledArg[0], tupledArg[1]];
}

export class CssRuleWithAutoNormal extends CssRuleWithAuto {
    constructor(property) {
        super(property);
        this.property_2 = property;
    }
}

export function CssRuleWithAutoNormal$reflection() {
    return class_type("Fss.Types.CssRuleWithAutoNormal", void 0, CssRuleWithAutoNormal, CssRuleWithAuto$reflection());
}

export function CssRuleWithAutoNormal_$ctor_Z207A3CFB(property) {
    return new CssRuleWithAutoNormal(property);
}

export function CssRuleWithAutoNormal__get_normal(this$) {
    const tupledArg = [this$.property_2, new Normal(0)];
    return [tupledArg[0], tupledArg[1]];
}

export class CssRuleWithAutoNormalNone extends CssRuleWithAutoNone {
    constructor(property) {
        super(property);
        this.property_2 = property;
    }
}

export function CssRuleWithAutoNormalNone$reflection() {
    return class_type("Fss.Types.CssRuleWithAutoNormalNone", void 0, CssRuleWithAutoNormalNone, CssRuleWithAutoNone$reflection());
}

export function CssRuleWithAutoNormalNone_$ctor_Z207A3CFB(property) {
    return new CssRuleWithAutoNormalNone(property);
}

export function CssRuleWithAutoNormalNone__get_normal(this$) {
    const tupledArg = [this$.property_2, new Normal(0)];
    return [tupledArg[0], tupledArg[1]];
}

export class CssRuleWithValueFunctions$1 extends CssRule {
    constructor(property, seperator) {
        super(property);
        this.property_1 = property;
        this.seperator = seperator;
    }
}

export function CssRuleWithValueFunctions$1$reflection(gen0) {
    return class_type("Fss.Types.CssRuleWithValueFunctions`1", [gen0], CssRuleWithValueFunctions$1, CssRule$reflection());
}

export function CssRuleWithValueFunctions$1_$ctor_5DDD5F9E(property, seperator) {
    return new CssRuleWithValueFunctions$1(property, seperator);
}

export function CssRuleWithValueFunctions$1__value_2B595(this$, value) {
    const value_1 = MasterTypeHelpers_stringifyICssValue(value);
    const tupledArg = [this$.property_1, new String$(0, value_1)];
    return [tupledArg[0], tupledArg[1]];
}

export function CssRuleWithValueFunctions$1__value_Z38D79C61(this$, values) {
    const values_1 = join(this$.seperator, map(MasterTypeHelpers_stringifyICssValue, values));
    const tupledArg = [this$.property_1, new String$(0, values_1)];
    return [tupledArg[0], tupledArg[1]];
}

//# sourceMappingURL=MasterTypes.fs.js.map
