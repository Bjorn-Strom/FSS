import { Helpers_toKebabCase } from "../Utilities.fs.js";
import { toString, Union } from "../../fable-library.3.7.9/Types.js";
import { class_type, union_type } from "../../fable-library.3.7.9/Reflection.js";
import { ColorClass_Color$reflection, ColorClass_Color, Color_Color$reflection } from "./Color.fs.js";
import { CssRuleWithNormal$reflection, CssRuleWithNormal, Int, CssRuleWithAuto$reflection, CssRuleWithAuto, Char, Stringed, CssRuleWithAutoNone$reflection, CssRuleWithAutoNone, String$, MasterTypeHelpers_stringifyICssValue, CssRuleWithNone$reflection, CssRuleWithNone, CssRule$reflection, CssRule } from "./MasterTypes.fs.js";
import { join } from "../../fable-library.3.7.9/String.js";
import { map } from "../../fable-library.3.7.9/List.js";
import { unitHelpers_CssRuleWithAutoLengthNone$reflection, unitHelpers_CssRuleWithAutoLengthNone, unitHelpers_lengthPercentageString, unitHelpers_CssRuleWithLength$reflection, unitHelpers_CssRuleWithLength, unitHelpers_CssRuleWithAutoLength$reflection, unitHelpers_CssRuleWithAutoLength } from "./Units.fs.js";

export class Text_Align extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["Left", "Right", "Center", "Justify", "JustifyAll", "Start", "End", "MatchParent"];
    }
    StringifyCss() {
        const this$ = this;
        return Helpers_toKebabCase(this$);
    }
}

export function Text_Align$reflection() {
    return union_type("Fss.Types.Text.Align", [], Text_Align, () => [[], [], [], [], [], [], [], []]);
}

export class Text_AlignLast extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["Start", "End", "Left", "Right", "Center", "Justify"];
    }
    StringifyCss() {
        const this$ = this;
        return toString(this$).toLocaleLowerCase();
    }
}

export function Text_AlignLast$reflection() {
    return union_type("Fss.Types.Text.AlignLast", [], Text_AlignLast, () => [[], [], [], [], [], []]);
}

export class Text_DecorationLine extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["Overline", "Underline", "LineThrough", "Blink"];
    }
    StringifyCss() {
        const this$ = this;
        return Helpers_toKebabCase(this$);
    }
}

export function Text_DecorationLine$reflection() {
    return union_type("Fss.Types.Text.DecorationLine", [], Text_DecorationLine, () => [[], [], [], []]);
}

export class Text_DecorationThickness extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["FromFont"];
    }
    StringifyCss() {
        return "from-font";
    }
}

export function Text_DecorationThickness$reflection() {
    return union_type("Fss.Types.Text.DecorationThickness", [], Text_DecorationThickness, () => [[]]);
}

export class Text_DecorationStyle extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["Solid", "Double", "Dotted", "Dashed", "Wavy"];
    }
    StringifyCss() {
        const this$ = this;
        return toString(this$).toLocaleLowerCase();
    }
}

export function Text_DecorationStyle$reflection() {
    return union_type("Fss.Types.Text.DecorationStyle", [], Text_DecorationStyle, () => [[], [], [], [], []]);
}

export class Text_DecorationSkip extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["Objects", "Spaces", "Edges", "BoxDecoration", "LeadingSpaces", "TrailingSpaces"];
    }
    StringifyCss() {
        const this$ = this;
        return Helpers_toKebabCase(this$);
    }
}

export function Text_DecorationSkip$reflection() {
    return union_type("Fss.Types.Text.DecorationSkip", [], Text_DecorationSkip, () => [[], [], [], [], [], []]);
}

export class Text_DecorationSkipInk extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["All"];
    }
    StringifyCss() {
        return "all";
    }
}

export function Text_DecorationSkipInk$reflection() {
    return union_type("Fss.Types.Text.DecorationSkipInk", [], Text_DecorationSkipInk, () => [[]]);
}

export class Text_Transform extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["Capitalize", "Uppercase", "Lowercase", "FullWidth", "FullSizeKana"];
    }
    StringifyCss() {
        const this$ = this;
        return Helpers_toKebabCase(this$);
    }
}

export function Text_Transform$reflection() {
    return union_type("Fss.Types.Text.Transform", [], Text_Transform, () => [[], [], [], [], []]);
}

export class Text_Indent extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["Hanging", "EachLine"];
    }
    StringifyCss() {
        const this$ = this;
        return Helpers_toKebabCase(this$);
    }
}

export function Text_Indent$reflection() {
    return union_type("Fss.Types.Text.Indent", [], Text_Indent, () => [[], []]);
}

export class Text_Overflow extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["Clip", "Ellipsis"];
    }
    StringifyCss() {
        const this$ = this;
        return toString(this$).toLocaleLowerCase();
    }
}

export function Text_Overflow$reflection() {
    return union_type("Fss.Types.Text.Overflow", [], Text_Overflow, () => [[], []]);
}

export class Text_EmphasisPosition extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["Over", "Under", "Right", "Left"];
    }
    StringifyCss() {
        const this$ = this;
        return toString(this$).toLocaleLowerCase();
    }
}

export function Text_EmphasisPosition$reflection() {
    return union_type("Fss.Types.Text.EmphasisPosition", [], Text_EmphasisPosition, () => [[], [], [], []]);
}

export class Text_EmphasisStyle extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["Filled", "Open", "Dot", "Circle", "DoubleCircle", "Triangle", "FilledSesame", "OpenSesame"];
    }
    StringifyCss() {
        const this$ = this;
        switch (this$.tag) {
            case 6: {
                return "filled sesame";
            }
            case 7: {
                return "open sesame";
            }
            default: {
                return Helpers_toKebabCase(this$);
            }
        }
    }
}

export function Text_EmphasisStyle$reflection() {
    return union_type("Fss.Types.Text.EmphasisStyle", [], Text_EmphasisStyle, () => [[], [], [], [], [], [], [], []]);
}

export class Text_UnderlinePosition extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["FromFont", "Under", "Left", "Right", "AutoPos", "Above", "Below"];
    }
    StringifyCss() {
        const this$ = this;
        return Helpers_toKebabCase(this$);
    }
}

export function Text_UnderlinePosition$reflection() {
    return union_type("Fss.Types.Text.UnderlinePosition", [], Text_UnderlinePosition, () => [[], [], [], [], [], [], []]);
}

export class Text_EmphasisColor extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["TextEmphasisColor"];
    }
    StringifyCss() {
        const this$ = this;
        return toString(this$).toLocaleLowerCase();
    }
}

export function Text_EmphasisColor$reflection() {
    return union_type("Fss.Types.Text.EmphasisColor", [], Text_EmphasisColor, () => [[["Item", Color_Color$reflection()]]]);
}

export class Text_Hyphens extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["Manual"];
    }
    StringifyCss() {
        return "manual";
    }
}

export function Text_Hyphens$reflection() {
    return union_type("Fss.Types.Text.Hyphens", [], Text_Hyphens, () => [[]]);
}

export class Text_Orientation extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["Mixed", "Upright", "SidewaysRight", "Sideways", "UseGlyphOrientation"];
    }
    StringifyCss() {
        const this$ = this;
        return Helpers_toKebabCase(this$);
    }
}

export function Text_Orientation$reflection() {
    return union_type("Fss.Types.Text.Orientation", [], Text_Orientation, () => [[], [], [], [], []]);
}

export class Text_Rendering extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["OptimizeSpeed", "OptimizeLegibility", "GeometricPrecision"];
    }
    StringifyCss() {
        const this$ = this;
        return Helpers_toKebabCase(this$);
    }
}

export function Text_Rendering$reflection() {
    return union_type("Fss.Types.Text.Rendering", [], Text_Rendering, () => [[], [], []]);
}

export class Text_Justify extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["InterWord", "InterCharacter"];
    }
    StringifyCss() {
        const this$ = this;
        return Helpers_toKebabCase(this$);
    }
}

export function Text_Justify$reflection() {
    return union_type("Fss.Types.Text.Justify", [], Text_Justify, () => [[], []]);
}

export class Text_WhiteSpace extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["Nowrap", "Pre", "PreWrap", "PreLine", "BreakSpaces"];
    }
    StringifyCss() {
        const this$ = this;
        return Helpers_toKebabCase(this$);
    }
}

export function Text_WhiteSpace$reflection() {
    return union_type("Fss.Types.Text.WhiteSpace", [], Text_WhiteSpace, () => [[], [], [], [], []]);
}

export class Text_UserSelect extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["Text", "Contain", "All", "Element"];
    }
    StringifyCss() {
        const this$ = this;
        return toString(this$).toLocaleLowerCase();
    }
}

export function Text_UserSelect$reflection() {
    return union_type("Fss.Types.Text.UserSelect", [], Text_UserSelect, () => [[], [], [], []]);
}

export class Text_HangingPunctuation extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["First", "Last", "ForceEnd", "AllowEnd"];
    }
    StringifyCss() {
        const this$ = this;
        return Helpers_toKebabCase(this$);
    }
}

export function Text_HangingPunctuation$reflection() {
    return union_type("Fss.Types.Text.HangingPunctuation", [], Text_HangingPunctuation, () => [[], [], [], []]);
}

export class TextClasses_TextAlign extends CssRule {
    constructor(property) {
        super(property);
        this.property_1 = property;
    }
}

export function TextClasses_TextAlign$reflection() {
    return class_type("Fss.Types.TextClasses.TextAlign", void 0, TextClasses_TextAlign, CssRule$reflection());
}

export function TextClasses_TextAlign_$ctor_Z207A3CFB(property) {
    return new TextClasses_TextAlign(property);
}

export function TextClasses_TextAlign__get_left(this$) {
    const tupledArg = [this$.property_1, new Text_Align(0)];
    return [tupledArg[0], tupledArg[1]];
}

export function TextClasses_TextAlign__get_right(this$) {
    const tupledArg = [this$.property_1, new Text_Align(1)];
    return [tupledArg[0], tupledArg[1]];
}

export function TextClasses_TextAlign__get_center(this$) {
    const tupledArg = [this$.property_1, new Text_Align(2)];
    return [tupledArg[0], tupledArg[1]];
}

export function TextClasses_TextAlign__get_justify(this$) {
    const tupledArg = [this$.property_1, new Text_Align(3)];
    return [tupledArg[0], tupledArg[1]];
}

export function TextClasses_TextAlign__get_justifyAll(this$) {
    const tupledArg = [this$.property_1, new Text_Align(4)];
    return [tupledArg[0], tupledArg[1]];
}

export function TextClasses_TextAlign__get_start(this$) {
    const tupledArg = [this$.property_1, new Text_Align(5)];
    return [tupledArg[0], tupledArg[1]];
}

export function TextClasses_TextAlign__get_end$0027(this$) {
    const tupledArg = [this$.property_1, new Text_Align(6)];
    return [tupledArg[0], tupledArg[1]];
}

export function TextClasses_TextAlign__get_matchParent(this$) {
    const tupledArg = [this$.property_1, new Text_Align(7)];
    return [tupledArg[0], tupledArg[1]];
}

export class TextClasses_TextDecoration extends CssRuleWithNone {
    constructor(property) {
        super(property);
    }
}

export function TextClasses_TextDecoration$reflection() {
    return class_type("Fss.Types.TextClasses.TextDecoration", void 0, TextClasses_TextDecoration, CssRuleWithNone$reflection());
}

export function TextClasses_TextDecoration_$ctor_Z207A3CFB(property) {
    return new TextClasses_TextDecoration(property);
}

export class TextClasses_TextDecorationLine extends CssRuleWithNone {
    constructor(property) {
        super(property);
        this.property_2 = property;
    }
}

export function TextClasses_TextDecorationLine$reflection() {
    return class_type("Fss.Types.TextClasses.TextDecorationLine", void 0, TextClasses_TextDecorationLine, CssRuleWithNone$reflection());
}

export function TextClasses_TextDecorationLine_$ctor_Z207A3CFB(property) {
    return new TextClasses_TextDecorationLine(property);
}

export function TextClasses_TextDecorationLine__value_6A082DFD(this$, decorations) {
    const decorations_1 = join(" ", map(MasterTypeHelpers_stringifyICssValue, decorations));
    const tupledArg = [this$.property_2, new String$(0, decorations_1)];
    return [tupledArg[0], tupledArg[1]];
}

export function TextClasses_TextDecorationLine__get_overline(this$) {
    const tupledArg = [this$.property_2, new Text_DecorationLine(0)];
    return [tupledArg[0], tupledArg[1]];
}

export function TextClasses_TextDecorationLine__get_underline(this$) {
    const tupledArg = [this$.property_2, new Text_DecorationLine(1)];
    return [tupledArg[0], tupledArg[1]];
}

export function TextClasses_TextDecorationLine__get_lineThrough(this$) {
    const tupledArg = [this$.property_2, new Text_DecorationLine(2)];
    return [tupledArg[0], tupledArg[1]];
}

export function TextClasses_TextDecorationLine__get_blink(this$) {
    const tupledArg = [this$.property_2, new Text_DecorationLine(3)];
    return [tupledArg[0], tupledArg[1]];
}

export class TextClasses_TextDecorationSkip extends CssRuleWithNone {
    constructor(property) {
        super(property);
        this.property_2 = property;
    }
}

export function TextClasses_TextDecorationSkip$reflection() {
    return class_type("Fss.Types.TextClasses.TextDecorationSkip", void 0, TextClasses_TextDecorationSkip, CssRuleWithNone$reflection());
}

export function TextClasses_TextDecorationSkip_$ctor_Z207A3CFB(property) {
    return new TextClasses_TextDecorationSkip(property);
}

export function TextClasses_TextDecorationSkip__value_6B7F0312(this$, decorations) {
    const decorations_1 = join(" ", map(MasterTypeHelpers_stringifyICssValue, decorations));
    const tupledArg = [this$.property_2, new String$(0, decorations_1)];
    return [tupledArg[0], tupledArg[1]];
}

export function TextClasses_TextDecorationSkip__get_objects(this$) {
    const tupledArg = [this$.property_2, new Text_DecorationSkip(0)];
    return [tupledArg[0], tupledArg[1]];
}

export function TextClasses_TextDecorationSkip__get_spaces(this$) {
    const tupledArg = [this$.property_2, new Text_DecorationSkip(1)];
    return [tupledArg[0], tupledArg[1]];
}

export function TextClasses_TextDecorationSkip__get_edges(this$) {
    const tupledArg = [this$.property_2, new Text_DecorationSkip(2)];
    return [tupledArg[0], tupledArg[1]];
}

export function TextClasses_TextDecorationSkip__get_boxDecoration(this$) {
    const tupledArg = [this$.property_2, new Text_DecorationSkip(3)];
    return [tupledArg[0], tupledArg[1]];
}

export function TextClasses_TextDecorationSkip__get_leadingSpaces(this$) {
    const tupledArg = [this$.property_2, new Text_DecorationSkip(4)];
    return [tupledArg[0], tupledArg[1]];
}

export function TextClasses_TextDecorationSkip__get_trailingSpaces(this$) {
    const tupledArg = [this$.property_2, new Text_DecorationSkip(5)];
    return [tupledArg[0], tupledArg[1]];
}

export class TextClasses_TextDecorationThickness extends unitHelpers_CssRuleWithAutoLength {
    constructor(property) {
        super(property);
        this.property_3 = property;
    }
}

export function TextClasses_TextDecorationThickness$reflection() {
    return class_type("Fss.Types.TextClasses.TextDecorationThickness", void 0, TextClasses_TextDecorationThickness, unitHelpers_CssRuleWithAutoLength$reflection());
}

export function TextClasses_TextDecorationThickness_$ctor_Z207A3CFB(property) {
    return new TextClasses_TextDecorationThickness(property);
}

export function TextClasses_TextDecorationThickness__get_fromFont(this$) {
    const tupledArg = [this$.property_3, new Text_DecorationThickness(0)];
    return [tupledArg[0], tupledArg[1]];
}

export class TextClasses_TextDecorationStyle extends CssRule {
    constructor(property) {
        super(property);
        this.property_1 = property;
    }
}

export function TextClasses_TextDecorationStyle$reflection() {
    return class_type("Fss.Types.TextClasses.TextDecorationStyle", void 0, TextClasses_TextDecorationStyle, CssRule$reflection());
}

export function TextClasses_TextDecorationStyle_$ctor_Z207A3CFB(property) {
    return new TextClasses_TextDecorationStyle(property);
}

export function TextClasses_TextDecorationStyle__get_solid(this$) {
    const tupledArg = [this$.property_1, new Text_DecorationStyle(0)];
    return [tupledArg[0], tupledArg[1]];
}

export function TextClasses_TextDecorationStyle__get_double(this$) {
    const tupledArg = [this$.property_1, new Text_DecorationStyle(1)];
    return [tupledArg[0], tupledArg[1]];
}

export function TextClasses_TextDecorationStyle__get_dotted(this$) {
    const tupledArg = [this$.property_1, new Text_DecorationStyle(2)];
    return [tupledArg[0], tupledArg[1]];
}

export function TextClasses_TextDecorationStyle__get_dashed(this$) {
    const tupledArg = [this$.property_1, new Text_DecorationStyle(3)];
    return [tupledArg[0], tupledArg[1]];
}

export function TextClasses_TextDecorationStyle__get_wavy(this$) {
    const tupledArg = [this$.property_1, new Text_DecorationStyle(4)];
    return [tupledArg[0], tupledArg[1]];
}

export class TextClasses_TextDecorationSkipInk extends CssRuleWithAutoNone {
    constructor(property) {
        super(property);
        this.property_2 = property;
    }
}

export function TextClasses_TextDecorationSkipInk$reflection() {
    return class_type("Fss.Types.TextClasses.TextDecorationSkipInk", void 0, TextClasses_TextDecorationSkipInk, CssRuleWithAutoNone$reflection());
}

export function TextClasses_TextDecorationSkipInk_$ctor_Z207A3CFB(property) {
    return new TextClasses_TextDecorationSkipInk(property);
}

export function TextClasses_TextDecorationSkipInk__get_all(this$) {
    const tupledArg = [this$.property_2, new Text_DecorationSkipInk(0)];
    return [tupledArg[0], tupledArg[1]];
}

export class TextClasses_TextTransform extends CssRuleWithNone {
    constructor(property) {
        super(property);
        this.property_2 = property;
    }
}

export function TextClasses_TextTransform$reflection() {
    return class_type("Fss.Types.TextClasses.TextTransform", void 0, TextClasses_TextTransform, CssRuleWithNone$reflection());
}

export function TextClasses_TextTransform_$ctor_Z207A3CFB(property) {
    return new TextClasses_TextTransform(property);
}

export function TextClasses_TextTransform__get_capitalize(this$) {
    const tupledArg = [this$.property_2, new Text_Transform(0)];
    return [tupledArg[0], tupledArg[1]];
}

export function TextClasses_TextTransform__get_uppercase(this$) {
    const tupledArg = [this$.property_2, new Text_Transform(1)];
    return [tupledArg[0], tupledArg[1]];
}

export function TextClasses_TextTransform__get_lowercase(this$) {
    const tupledArg = [this$.property_2, new Text_Transform(2)];
    return [tupledArg[0], tupledArg[1]];
}

export function TextClasses_TextTransform__get_fullWidth(this$) {
    const tupledArg = [this$.property_2, new Text_Transform(3)];
    return [tupledArg[0], tupledArg[1]];
}

export function TextClasses_TextTransform__get_fullSizeKana(this$) {
    const tupledArg = [this$.property_2, new Text_Transform(4)];
    return [tupledArg[0], tupledArg[1]];
}

export class TextClasses_TextIndent extends unitHelpers_CssRuleWithLength {
    constructor(property) {
        super(property);
        this.property_2 = property;
    }
}

export function TextClasses_TextIndent$reflection() {
    return class_type("Fss.Types.TextClasses.TextIndent", void 0, TextClasses_TextIndent, unitHelpers_CssRuleWithLength$reflection());
}

export function TextClasses_TextIndent_$ctor_Z207A3CFB(property) {
    return new TextClasses_TextIndent(property);
}

export function TextClasses_TextIndent__hanging_Z498FEB3B(this$, value) {
    const value_1 = `${unitHelpers_lengthPercentageString(value)} ${MasterTypeHelpers_stringifyICssValue(new Text_Indent(0))}`;
    const tupledArg = [this$.property_2, new String$(0, value_1)];
    return [tupledArg[0], tupledArg[1]];
}

export function TextClasses_TextIndent__eachLine_Z498FEB3B(this$, value) {
    const value_1 = `${unitHelpers_lengthPercentageString(value)} ${MasterTypeHelpers_stringifyICssValue(new Text_Indent(1))}`;
    const tupledArg = [this$.property_2, new String$(0, value_1)];
    return [tupledArg[0], tupledArg[1]];
}

export function TextClasses_TextIndent__hangingEachLine_Z498FEB3B(this$, value) {
    const value_1 = `${unitHelpers_lengthPercentageString(value)} ${MasterTypeHelpers_stringifyICssValue(new Text_Indent(0))} ${MasterTypeHelpers_stringifyICssValue(new Text_Indent(1))}`;
    const tupledArg = [this$.property_2, new String$(0, value_1)];
    return [tupledArg[0], tupledArg[1]];
}

export class TextClasses_TextShadow extends CssRule {
    constructor(property) {
        super(property);
        this.property_1 = property;
    }
}

export function TextClasses_TextShadow$reflection() {
    return class_type("Fss.Types.TextClasses.TextShadow", void 0, TextClasses_TextShadow, CssRule$reflection());
}

export function TextClasses_TextShadow_$ctor_Z207A3CFB(property) {
    return new TextClasses_TextShadow(property);
}

export function TextClasses_TextShadow__value_Z259E9AEE(this$, xOffset, yOffset, blurRadius, color) {
    let value;
    const tupledArg_1 = [xOffset, yOffset, blurRadius, color];
    const tupledArg = [tupledArg_1[0], tupledArg_1[1], tupledArg_1[2], tupledArg_1[3]];
    value = TextClasses_TextShadow__stringify_3C68FBC0(this$, tupledArg[0], tupledArg[1], tupledArg[2], tupledArg[3]);
    const tupledArg_2 = [this$.property_1, new String$(0, value)];
    return [tupledArg_2[0], tupledArg_2[1]];
}

export function TextClasses_TextShadow__value_1F546CD7(this$, shadows) {
    const value = join(", ", map((tupledArg_1) => {
        const tupledArg = [tupledArg_1[0], tupledArg_1[1], tupledArg_1[2], tupledArg_1[3]];
        return TextClasses_TextShadow__stringify_3C68FBC0(this$, tupledArg[0], tupledArg[1], tupledArg[2], tupledArg[3]);
    }, shadows));
    const tupledArg_2 = [this$.property_1, new String$(0, value)];
    return [tupledArg_2[0], tupledArg_2[1]];
}

function TextClasses_TextShadow__stringify_3C68FBC0(this$, x, y, blur, color) {
    return `${MasterTypeHelpers_stringifyICssValue(x)} ${MasterTypeHelpers_stringifyICssValue(y)} ${MasterTypeHelpers_stringifyICssValue(blur)} ${MasterTypeHelpers_stringifyICssValue(color)}`;
}

export class TextClasses_TextOverflow extends CssRule {
    constructor(property) {
        super(property);
        this.property_1 = property;
    }
}

export function TextClasses_TextOverflow$reflection() {
    return class_type("Fss.Types.TextClasses.TextOverflow", void 0, TextClasses_TextOverflow, CssRule$reflection());
}

export function TextClasses_TextOverflow_$ctor_Z207A3CFB(property) {
    return new TextClasses_TextOverflow(property);
}

export function TextClasses_TextOverflow__get_clip(this$) {
    const tupledArg = [this$.property_1, new Text_Overflow(0)];
    return [tupledArg[0], tupledArg[1]];
}

export function TextClasses_TextOverflow__get_ellipsis(this$) {
    const tupledArg = [this$.property_1, new Text_Overflow(1)];
    return [tupledArg[0], tupledArg[1]];
}

export function TextClasses_TextOverflow__value_Z721C83C5(this$, overflow) {
    const tupledArg = [this$.property_1, new Stringed(0, overflow)];
    return [tupledArg[0], tupledArg[1]];
}

export class TextClasses_TextEmphasis extends CssRuleWithNone {
    constructor(property) {
        super(property);
    }
}

export function TextClasses_TextEmphasis$reflection() {
    return class_type("Fss.Types.TextClasses.TextEmphasis", void 0, TextClasses_TextEmphasis, CssRuleWithNone$reflection());
}

export function TextClasses_TextEmphasis_$ctor_Z207A3CFB(property) {
    return new TextClasses_TextEmphasis(property);
}

export class TextClasses_TextEmphasisPosition extends CssRule {
    constructor(property) {
        super(property);
        this.property_1 = property;
    }
}

export function TextClasses_TextEmphasisPosition$reflection() {
    return class_type("Fss.Types.TextClasses.TextEmphasisPosition", void 0, TextClasses_TextEmphasisPosition, CssRule$reflection());
}

export function TextClasses_TextEmphasisPosition_$ctor_Z207A3CFB(property) {
    return new TextClasses_TextEmphasisPosition(property);
}

export function TextClasses_TextEmphasisPosition__value_Z2C137CC0(this$, x, y) {
    const value = new String$(0, `${MasterTypeHelpers_stringifyICssValue(x)} ${MasterTypeHelpers_stringifyICssValue(y)}`);
    const tupledArg = [this$.property_1, value];
    return [tupledArg[0], tupledArg[1]];
}

export class TextClasses_TextEmphasisStyle extends CssRule {
    constructor(property) {
        super(property);
        this.property_1 = property;
    }
}

export function TextClasses_TextEmphasisStyle$reflection() {
    return class_type("Fss.Types.TextClasses.TextEmphasisStyle", void 0, TextClasses_TextEmphasisStyle, CssRule$reflection());
}

export function TextClasses_TextEmphasisStyle_$ctor_Z207A3CFB(property) {
    return new TextClasses_TextEmphasisStyle(property);
}

export function TextClasses_TextEmphasisStyle__value_Z721C83C5(this$, style) {
    const tupledArg = [this$.property_1, new Char(0, style)];
    return [tupledArg[0], tupledArg[1]];
}

export function TextClasses_TextEmphasisStyle__get_filled(this$) {
    const tupledArg = [this$.property_1, new Text_EmphasisStyle(0)];
    return [tupledArg[0], tupledArg[1]];
}

export function TextClasses_TextEmphasisStyle__get_open$0027(this$) {
    const tupledArg = [this$.property_1, new Text_EmphasisStyle(1)];
    return [tupledArg[0], tupledArg[1]];
}

export function TextClasses_TextEmphasisStyle__get_dot(this$) {
    const tupledArg = [this$.property_1, new Text_EmphasisStyle(2)];
    return [tupledArg[0], tupledArg[1]];
}

export function TextClasses_TextEmphasisStyle__get_circle(this$) {
    const tupledArg = [this$.property_1, new Text_EmphasisStyle(3)];
    return [tupledArg[0], tupledArg[1]];
}

export function TextClasses_TextEmphasisStyle__get_doubleCircle(this$) {
    const tupledArg = [this$.property_1, new Text_EmphasisStyle(4)];
    return [tupledArg[0], tupledArg[1]];
}

export function TextClasses_TextEmphasisStyle__get_triangle(this$) {
    const tupledArg = [this$.property_1, new Text_EmphasisStyle(5)];
    return [tupledArg[0], tupledArg[1]];
}

export function TextClasses_TextEmphasisStyle__get_filledSesame(this$) {
    const tupledArg = [this$.property_1, new Text_EmphasisStyle(6)];
    return [tupledArg[0], tupledArg[1]];
}

export function TextClasses_TextEmphasisStyle__get_openSesame(this$) {
    const tupledArg = [this$.property_1, new Text_EmphasisStyle(7)];
    return [tupledArg[0], tupledArg[1]];
}

export class TextClasses_TextUnderlinePosition extends CssRuleWithAuto {
    constructor(property) {
        super(property);
        this.property_2 = property;
    }
}

export function TextClasses_TextUnderlinePosition$reflection() {
    return class_type("Fss.Types.TextClasses.TextUnderlinePosition", void 0, TextClasses_TextUnderlinePosition, CssRuleWithAuto$reflection());
}

export function TextClasses_TextUnderlinePosition_$ctor_Z207A3CFB(property) {
    return new TextClasses_TextUnderlinePosition(property);
}

export function TextClasses_TextUnderlinePosition__value_35979180(this$, x, y) {
    const value = new String$(0, `${MasterTypeHelpers_stringifyICssValue(x)} ${MasterTypeHelpers_stringifyICssValue(y)}`);
    const tupledArg = [this$.property_2, value];
    return [tupledArg[0], tupledArg[1]];
}

export function TextClasses_TextUnderlinePosition__get_fromFont(this$) {
    const tupledArg = [this$.property_2, new Text_DecorationThickness(0)];
    return [tupledArg[0], tupledArg[1]];
}

export function TextClasses_TextUnderlinePosition__get_under(this$) {
    const tupledArg = [this$.property_2, new Text_EmphasisPosition(1)];
    return [tupledArg[0], tupledArg[1]];
}

export function TextClasses_TextUnderlinePosition__get_left(this$) {
    const tupledArg = [this$.property_2, new Text_Align(0)];
    return [tupledArg[0], tupledArg[1]];
}

export function TextClasses_TextUnderlinePosition__get_right(this$) {
    const tupledArg = [this$.property_2, new Text_Align(1)];
    return [tupledArg[0], tupledArg[1]];
}

export function TextClasses_TextUnderlinePosition__get_autoPos(this$) {
    const tupledArg = [this$.property_2, new Text_UnderlinePosition(4)];
    return [tupledArg[0], tupledArg[1]];
}

export function TextClasses_TextUnderlinePosition__get_above(this$) {
    const tupledArg = [this$.property_2, new Text_UnderlinePosition(5)];
    return [tupledArg[0], tupledArg[1]];
}

export function TextClasses_TextUnderlinePosition__get_below(this$) {
    const tupledArg = [this$.property_2, new Text_UnderlinePosition(6)];
    return [tupledArg[0], tupledArg[1]];
}

export class TextClasses_TextUnderlineOffset extends unitHelpers_CssRuleWithAutoLength {
    constructor(property) {
        super(property);
    }
}

export function TextClasses_TextUnderlineOffset$reflection() {
    return class_type("Fss.Types.TextClasses.TextUnderlineOffset", void 0, TextClasses_TextUnderlineOffset, unitHelpers_CssRuleWithAutoLength$reflection());
}

export function TextClasses_TextUnderlineOffset_$ctor_Z207A3CFB(property) {
    return new TextClasses_TextUnderlineOffset(property);
}

export class TextClasses_Quotes extends CssRuleWithAutoNone {
    constructor(property) {
        super(property);
        this.property_2 = property;
    }
}

export function TextClasses_Quotes$reflection() {
    return class_type("Fss.Types.TextClasses.Quotes", void 0, TextClasses_Quotes, CssRuleWithAutoNone$reflection());
}

export function TextClasses_Quotes_$ctor_Z207A3CFB(property) {
    return new TextClasses_Quotes(property);
}

export function TextClasses_Quotes__value_1334CEF1(this$, quotes) {
    const quotes_1 = join(" ", map((x) => (`"${x}"`), quotes));
    const tupledArg = [this$.property_2, new String$(0, quotes_1)];
    return [tupledArg[0], tupledArg[1]];
}

export class TextClasses_Hyphens extends CssRuleWithAutoNone {
    constructor(property) {
        super(property);
        this.property_2 = property;
    }
}

export function TextClasses_Hyphens$reflection() {
    return class_type("Fss.Types.TextClasses.Hyphens", void 0, TextClasses_Hyphens, CssRuleWithAutoNone$reflection());
}

export function TextClasses_Hyphens_$ctor_Z207A3CFB(property) {
    return new TextClasses_Hyphens(property);
}

export function TextClasses_Hyphens__get_manual(this$) {
    const tupledArg = [this$.property_2, new Text_Hyphens(0)];
    return [tupledArg[0], tupledArg[1]];
}

export class TextClasses_TextDecorationColor extends ColorClass_Color {
    constructor(property) {
        super(property);
    }
}

export function TextClasses_TextDecorationColor$reflection() {
    return class_type("Fss.Types.TextClasses.TextDecorationColor", void 0, TextClasses_TextDecorationColor, ColorClass_Color$reflection());
}

export function TextClasses_TextDecorationColor_$ctor_Z207A3CFB(property) {
    return new TextClasses_TextDecorationColor(property);
}

export class TextClasses_TextEmphasisColor extends ColorClass_Color {
    constructor(property) {
        super(property);
    }
}

export function TextClasses_TextEmphasisColor$reflection() {
    return class_type("Fss.Types.TextClasses.TextEmphasisColor", void 0, TextClasses_TextEmphasisColor, ColorClass_Color$reflection());
}

export function TextClasses_TextEmphasisColor_$ctor_Z207A3CFB(property) {
    return new TextClasses_TextEmphasisColor(property);
}

export class TextClasses_TextSizeAdjust extends unitHelpers_CssRuleWithAutoLengthNone {
    constructor(property) {
        super(property);
    }
}

export function TextClasses_TextSizeAdjust$reflection() {
    return class_type("Fss.Types.TextClasses.TextSizeAdjust", void 0, TextClasses_TextSizeAdjust, unitHelpers_CssRuleWithAutoLengthNone$reflection());
}

export function TextClasses_TextSizeAdjust_$ctor_Z207A3CFB(property) {
    return new TextClasses_TextSizeAdjust(property);
}

export class TextClasses_TabSize extends unitHelpers_CssRuleWithLength {
    constructor(property) {
        super(property);
        this.property_2 = property;
    }
}

export function TextClasses_TabSize$reflection() {
    return class_type("Fss.Types.TextClasses.TabSize", void 0, TextClasses_TabSize, unitHelpers_CssRuleWithLength$reflection());
}

export function TextClasses_TabSize_$ctor_Z207A3CFB(property) {
    return new TextClasses_TabSize(property);
}

export function TextClasses_TabSize__value_Z524259A4(this$, size) {
    const tupledArg = [this$.property_2, new Int(0, size)];
    return [tupledArg[0], tupledArg[1]];
}

export class TextClasses_TextOrientation extends CssRule {
    constructor(property) {
        super(property);
        this.property_1 = property;
    }
}

export function TextClasses_TextOrientation$reflection() {
    return class_type("Fss.Types.TextClasses.TextOrientation", void 0, TextClasses_TextOrientation, CssRule$reflection());
}

export function TextClasses_TextOrientation_$ctor_Z207A3CFB(property) {
    return new TextClasses_TextOrientation(property);
}

export function TextClasses_TextOrientation__value_Z524259A4(this$, size) {
    const tupledArg = [this$.property_1, new Int(0, size)];
    return [tupledArg[0], tupledArg[1]];
}

export function TextClasses_TextOrientation__get_mixed(this$) {
    const tupledArg = [this$.property_1, new Text_Orientation(0)];
    return [tupledArg[0], tupledArg[1]];
}

export function TextClasses_TextOrientation__get_upright(this$) {
    const tupledArg = [this$.property_1, new Text_Orientation(1)];
    return [tupledArg[0], tupledArg[1]];
}

export function TextClasses_TextOrientation__get_sidewaysRight(this$) {
    const tupledArg = [this$.property_1, new Text_Orientation(2)];
    return [tupledArg[0], tupledArg[1]];
}

export function TextClasses_TextOrientation__get_sideways(this$) {
    const tupledArg = [this$.property_1, new Text_Orientation(3)];
    return [tupledArg[0], tupledArg[1]];
}

export function TextClasses_TextOrientation__get_useGlyphOrientation(this$) {
    const tupledArg = [this$.property_1, new Text_Orientation(4)];
    return [tupledArg[0], tupledArg[1]];
}

export class TextClasses_TextRendering extends CssRuleWithAuto {
    constructor(property) {
        super(property);
        this.property_2 = property;
    }
}

export function TextClasses_TextRendering$reflection() {
    return class_type("Fss.Types.TextClasses.TextRendering", void 0, TextClasses_TextRendering, CssRuleWithAuto$reflection());
}

export function TextClasses_TextRendering_$ctor_Z207A3CFB(property) {
    return new TextClasses_TextRendering(property);
}

export function TextClasses_TextRendering__get_optimizeSpeed(this$) {
    const tupledArg = [this$.property_2, new Text_Rendering(0)];
    return [tupledArg[0], tupledArg[1]];
}

export function TextClasses_TextRendering__get_optimizeLegibility(this$) {
    const tupledArg = [this$.property_2, new Text_Rendering(1)];
    return [tupledArg[0], tupledArg[1]];
}

export function TextClasses_TextRendering__get_geometricPrecision(this$) {
    const tupledArg = [this$.property_2, new Text_Rendering(2)];
    return [tupledArg[0], tupledArg[1]];
}

export class TextClasses_TextJustify extends CssRuleWithAutoNone {
    constructor(property) {
        super(property);
        this.property_2 = property;
    }
}

export function TextClasses_TextJustify$reflection() {
    return class_type("Fss.Types.TextClasses.TextJustify", void 0, TextClasses_TextJustify, CssRuleWithAutoNone$reflection());
}

export function TextClasses_TextJustify_$ctor_Z207A3CFB(property) {
    return new TextClasses_TextJustify(property);
}

export function TextClasses_TextJustify__get_interWord(this$) {
    const tupledArg = [this$.property_2, new Text_Justify(0)];
    return [tupledArg[0], tupledArg[1]];
}

export function TextClasses_TextJustify__get_interCharacter(this$) {
    const tupledArg = [this$.property_2, new Text_Justify(1)];
    return [tupledArg[0], tupledArg[1]];
}

export class TextClasses_WhiteSpace extends CssRuleWithNormal {
    constructor(property) {
        super(property);
        this.property_2 = property;
    }
}

export function TextClasses_WhiteSpace$reflection() {
    return class_type("Fss.Types.TextClasses.WhiteSpace", void 0, TextClasses_WhiteSpace, CssRuleWithNormal$reflection());
}

export function TextClasses_WhiteSpace_$ctor_Z207A3CFB(property) {
    return new TextClasses_WhiteSpace(property);
}

export function TextClasses_WhiteSpace__get_nowrap(this$) {
    const tupledArg = [this$.property_2, new Text_WhiteSpace(0)];
    return [tupledArg[0], tupledArg[1]];
}

export function TextClasses_WhiteSpace__get_pre(this$) {
    const tupledArg = [this$.property_2, new Text_WhiteSpace(1)];
    return [tupledArg[0], tupledArg[1]];
}

export function TextClasses_WhiteSpace__get_preWrap(this$) {
    const tupledArg = [this$.property_2, new Text_WhiteSpace(2)];
    return [tupledArg[0], tupledArg[1]];
}

export function TextClasses_WhiteSpace__get_preLine(this$) {
    const tupledArg = [this$.property_2, new Text_WhiteSpace(3)];
    return [tupledArg[0], tupledArg[1]];
}

export function TextClasses_WhiteSpace__get_breakSpaces(this$) {
    const tupledArg = [this$.property_2, new Text_WhiteSpace(4)];
    return [tupledArg[0], tupledArg[1]];
}

export class TextClasses_UserSelect extends CssRuleWithAutoNone {
    constructor(property) {
        super(property);
        this.property_2 = property;
    }
}

export function TextClasses_UserSelect$reflection() {
    return class_type("Fss.Types.TextClasses.UserSelect", void 0, TextClasses_UserSelect, CssRuleWithAutoNone$reflection());
}

export function TextClasses_UserSelect_$ctor_Z207A3CFB(property) {
    return new TextClasses_UserSelect(property);
}

export function TextClasses_UserSelect__get_text(this$) {
    const tupledArg = [this$.property_2, new Text_UserSelect(0)];
    return [tupledArg[0], tupledArg[1]];
}

export function TextClasses_UserSelect__get_contain(this$) {
    const tupledArg = [this$.property_2, new Text_UserSelect(1)];
    return [tupledArg[0], tupledArg[1]];
}

export function TextClasses_UserSelect__get_all(this$) {
    const tupledArg = [this$.property_2, new Text_DecorationSkipInk(0)];
    return [tupledArg[0], tupledArg[1]];
}

export function TextClasses_UserSelect__get_element(this$) {
    const tupledArg = [this$.property_2, new Text_UserSelect(3)];
    return [tupledArg[0], tupledArg[1]];
}

export class TextClasses_HangingPunctuationClass extends CssRuleWithNone {
    constructor(property) {
        super(property);
        this.property_2 = property;
    }
}

export function TextClasses_HangingPunctuationClass$reflection() {
    return class_type("Fss.Types.TextClasses.HangingPunctuationClass", void 0, TextClasses_HangingPunctuationClass, CssRuleWithNone$reflection());
}

export function TextClasses_HangingPunctuationClass_$ctor_Z207A3CFB(property) {
    return new TextClasses_HangingPunctuationClass(property);
}

export function TextClasses_HangingPunctuationClass__value_Z26E3135B(this$, punctuations) {
    const punctuations_1 = join(" ", map(MasterTypeHelpers_stringifyICssValue, punctuations));
    const tupledArg = [this$.property_2, new String$(0, punctuations_1)];
    return [tupledArg[0], tupledArg[1]];
}

export function TextClasses_HangingPunctuationClass__get_first(this$) {
    const tupledArg = [this$.property_2, new Text_HangingPunctuation(0)];
    return [tupledArg[0], tupledArg[1]];
}

export function TextClasses_HangingPunctuationClass__get_last(this$) {
    const tupledArg = [this$.property_2, new Text_HangingPunctuation(1)];
    return [tupledArg[0], tupledArg[1]];
}

export function TextClasses_HangingPunctuationClass__get_forceEnd(this$) {
    const tupledArg = [this$.property_2, new Text_HangingPunctuation(2)];
    return [tupledArg[0], tupledArg[1]];
}

export function TextClasses_HangingPunctuationClass__get_allowEnd(this$) {
    const tupledArg = [this$.property_2, new Text_HangingPunctuation(3)];
    return [tupledArg[0], tupledArg[1]];
}

//# sourceMappingURL=Text.fs.js.map
