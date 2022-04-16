import { Helpers_toKebabCase } from "../Utilities.fs.js";
import { toString, Union } from "../../fable-library.3.7.9/Types.js";
import { class_type, union_type } from "../../fable-library.3.7.9/Reflection.js";
import { Int, String$, Float, Auto } from "./MasterTypes.fs.js";
import { unitHelpers_lengthPercentageToType } from "./Units.fs.js";
import { ColorClass_Color$reflection, ColorClass_Color } from "./Color.fs.js";
import { join } from "../../fable-library.3.7.9/String.js";
import { map } from "../../fable-library.3.7.9/List.js";
import { int32ToString } from "../../fable-library.3.7.9/Util.js";

export class Svg_AlignmentBaseline extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["Baseline", "TextBottom", "TextBeforeEdge", "Middle", "Central", "TextTop", "TextAfterEdge", "Ideographic", "Alphabetic", "Hanging", "Mathematical", "Top", "Center", "Bottom"];
    }
    StringifyCss() {
        const this$ = this;
        return Helpers_toKebabCase(this$);
    }
}

export function Svg_AlignmentBaseline$reflection() {
    return union_type("Fss.Types.Svg.AlignmentBaseline", [], Svg_AlignmentBaseline, () => [[], [], [], [], [], [], [], [], [], [], [], [], [], []]);
}

export class Svg_BaselineShift extends Union {
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

export function Svg_BaselineShift$reflection() {
    return union_type("Fss.Types.Svg.BaselineShift", [], Svg_BaselineShift, () => [[], []]);
}

export class Svg_DominantBaseline extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["Ideographic", "Alphabetic", "Hanging", "Mathematical", "Central", "Middle", "TextAfterEdge", "TextBeforeEdge", "TextTop"];
    }
    StringifyCss() {
        const this$ = this;
        return Helpers_toKebabCase(this$);
    }
}

export function Svg_DominantBaseline$reflection() {
    return union_type("Fss.Types.Svg.DominantBaseline", [], Svg_DominantBaseline, () => [[], [], [], [], [], [], [], [], []]);
}

export class Svg_TextAnchor extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["Start", "Middle", "End"];
    }
    StringifyCss() {
        const this$ = this;
        return toString(this$).toLocaleLowerCase();
    }
}

export function Svg_TextAnchor$reflection() {
    return union_type("Fss.Types.Svg.TextAnchor", [], Svg_TextAnchor, () => [[], [], []]);
}

export class Svg_ClipRule extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["Nonzero", "Evenodd"];
    }
    StringifyCss() {
        const this$ = this;
        return toString(this$).toLocaleLowerCase();
    }
}

export function Svg_ClipRule$reflection() {
    return union_type("Fss.Types.Svg.ClipRule", [], Svg_ClipRule, () => [[], []]);
}

export class Svg_ColorInterpolation extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["Srgb", "LinearRgb"];
    }
    StringifyCss() {
        const this$ = this;
        return (this$.tag === 1) ? "linearRGB" : "sRGB";
    }
}

export function Svg_ColorInterpolation$reflection() {
    return union_type("Fss.Types.Svg.ColorInterpolation", [], Svg_ColorInterpolation, () => [[], []]);
}

export class Svg_ImageRendering extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["OptimizeSpeed", "OptimizeQuality"];
    }
    StringifyCss() {
        const this$ = this;
        return Helpers_toKebabCase(this$);
    }
}

export function Svg_ImageRendering$reflection() {
    return union_type("Fss.Types.Svg.ImageRendering", [], Svg_ImageRendering, () => [[], []]);
}

export class Svg_ShapeRendering extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["OptimizeSpeed", "CrispEdges", "GeometricPrecision"];
    }
    StringifyCss() {
        const this$ = this;
        return Helpers_toKebabCase(this$);
    }
}

export function Svg_ShapeRendering$reflection() {
    return union_type("Fss.Types.Svg.ShapeRendering", [], Svg_ShapeRendering, () => [[], [], []]);
}

export class Svg_StrokeLinecap extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["Butt", "Round", "Square"];
    }
    StringifyCss() {
        const this$ = this;
        return toString(this$).toLocaleLowerCase();
    }
}

export function Svg_StrokeLinecap$reflection() {
    return union_type("Fss.Types.Svg.StrokeLinecap", [], Svg_StrokeLinecap, () => [[], [], []]);
}

export class Svg_StrokeLinejoin extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["Arcs", "Bevel", "Miter", "MiterClip", "Round"];
    }
    StringifyCss() {
        const this$ = this;
        return Helpers_toKebabCase(this$);
    }
}

export function Svg_StrokeLinejoin$reflection() {
    return union_type("Fss.Types.Svg.StrokeLinejoin", [], Svg_StrokeLinejoin, () => [[], [], [], [], []]);
}

export class SvgClasses_AlignmentBaselineClass {
    constructor(property) {
        this.property = property;
    }
}

export function SvgClasses_AlignmentBaselineClass$reflection() {
    return class_type("Fss.Types.SvgClasses.AlignmentBaselineClass", void 0, SvgClasses_AlignmentBaselineClass);
}

export function SvgClasses_AlignmentBaselineClass_$ctor_Z207A3CFB(property) {
    return new SvgClasses_AlignmentBaselineClass(property);
}

export function SvgClasses_AlignmentBaselineClass__get_auto(this$) {
    const tupledArg = [this$.property, new Auto(0)];
    return [tupledArg[0], tupledArg[1]];
}

export function SvgClasses_AlignmentBaselineClass__get_baseline(this$) {
    const tupledArg = [this$.property, new Svg_AlignmentBaseline(0)];
    return [tupledArg[0], tupledArg[1]];
}

export function SvgClasses_AlignmentBaselineClass__get_textBottom(this$) {
    const tupledArg = [this$.property, new Svg_AlignmentBaseline(1)];
    return [tupledArg[0], tupledArg[1]];
}

export function SvgClasses_AlignmentBaselineClass__get_textBeforeEdge(this$) {
    const tupledArg = [this$.property, new Svg_AlignmentBaseline(2)];
    return [tupledArg[0], tupledArg[1]];
}

export function SvgClasses_AlignmentBaselineClass__get_middle(this$) {
    const tupledArg = [this$.property, new Svg_AlignmentBaseline(3)];
    return [tupledArg[0], tupledArg[1]];
}

export function SvgClasses_AlignmentBaselineClass__get_central(this$) {
    const tupledArg = [this$.property, new Svg_AlignmentBaseline(4)];
    return [tupledArg[0], tupledArg[1]];
}

export function SvgClasses_AlignmentBaselineClass__get_textTop(this$) {
    const tupledArg = [this$.property, new Svg_AlignmentBaseline(5)];
    return [tupledArg[0], tupledArg[1]];
}

export function SvgClasses_AlignmentBaselineClass__get_textAfterEdge(this$) {
    const tupledArg = [this$.property, new Svg_AlignmentBaseline(6)];
    return [tupledArg[0], tupledArg[1]];
}

export function SvgClasses_AlignmentBaselineClass__get_ideographic(this$) {
    const tupledArg = [this$.property, new Svg_AlignmentBaseline(7)];
    return [tupledArg[0], tupledArg[1]];
}

export function SvgClasses_AlignmentBaselineClass__get_alphabetic(this$) {
    const tupledArg = [this$.property, new Svg_AlignmentBaseline(8)];
    return [tupledArg[0], tupledArg[1]];
}

export function SvgClasses_AlignmentBaselineClass__get_hanging(this$) {
    const tupledArg = [this$.property, new Svg_AlignmentBaseline(9)];
    return [tupledArg[0], tupledArg[1]];
}

export function SvgClasses_AlignmentBaselineClass__get_mathematical(this$) {
    const tupledArg = [this$.property, new Svg_AlignmentBaseline(10)];
    return [tupledArg[0], tupledArg[1]];
}

export function SvgClasses_AlignmentBaselineClass__get_top(this$) {
    const tupledArg = [this$.property, new Svg_AlignmentBaseline(11)];
    return [tupledArg[0], tupledArg[1]];
}

export function SvgClasses_AlignmentBaselineClass__get_center(this$) {
    const tupledArg = [this$.property, new Svg_AlignmentBaseline(12)];
    return [tupledArg[0], tupledArg[1]];
}

export function SvgClasses_AlignmentBaselineClass__get_bottom(this$) {
    const tupledArg = [this$.property, new Svg_AlignmentBaseline(13)];
    return [tupledArg[0], tupledArg[1]];
}

export class SvgClasses_BaselineShift {
    constructor(property) {
        this.property = property;
    }
}

export function SvgClasses_BaselineShift$reflection() {
    return class_type("Fss.Types.SvgClasses.BaselineShift", void 0, SvgClasses_BaselineShift);
}

export function SvgClasses_BaselineShift_$ctor_Z207A3CFB(property) {
    return new SvgClasses_BaselineShift(property);
}

export function SvgClasses_BaselineShift__value_Z498FEB3B(this$, shift) {
    const tupledArg = [this$.property, unitHelpers_lengthPercentageToType(shift)];
    return [tupledArg[0], tupledArg[1]];
}

export function SvgClasses_BaselineShift__get_sub(this$) {
    const tupledArg = [this$.property, new Svg_BaselineShift(0)];
    return [tupledArg[0], tupledArg[1]];
}

export function SvgClasses_BaselineShift__get_super(this$) {
    const tupledArg = [this$.property, new Svg_BaselineShift(1)];
    return [tupledArg[0], tupledArg[1]];
}

export class SvgClasses_DominantBaseline {
    constructor(property) {
        this.property = property;
    }
}

export function SvgClasses_DominantBaseline$reflection() {
    return class_type("Fss.Types.SvgClasses.DominantBaseline", void 0, SvgClasses_DominantBaseline);
}

export function SvgClasses_DominantBaseline_$ctor_Z207A3CFB(property) {
    return new SvgClasses_DominantBaseline(property);
}

export function SvgClasses_DominantBaseline__get_ideographic(this$) {
    const tupledArg = [this$.property, new Svg_DominantBaseline(0)];
    return [tupledArg[0], tupledArg[1]];
}

export function SvgClasses_DominantBaseline__get_alphabetic(this$) {
    const tupledArg = [this$.property, new Svg_DominantBaseline(1)];
    return [tupledArg[0], tupledArg[1]];
}

export function SvgClasses_DominantBaseline__get_hanging(this$) {
    const tupledArg = [this$.property, new Svg_DominantBaseline(2)];
    return [tupledArg[0], tupledArg[1]];
}

export function SvgClasses_DominantBaseline__get_mathematical(this$) {
    const tupledArg = [this$.property, new Svg_DominantBaseline(3)];
    return [tupledArg[0], tupledArg[1]];
}

export function SvgClasses_DominantBaseline__get_central(this$) {
    const tupledArg = [this$.property, new Svg_DominantBaseline(4)];
    return [tupledArg[0], tupledArg[1]];
}

export function SvgClasses_DominantBaseline__get_middle(this$) {
    const tupledArg = [this$.property, new Svg_DominantBaseline(5)];
    return [tupledArg[0], tupledArg[1]];
}

export function SvgClasses_DominantBaseline__get_textAfterEdge(this$) {
    const tupledArg = [this$.property, new Svg_DominantBaseline(6)];
    return [tupledArg[0], tupledArg[1]];
}

export function SvgClasses_DominantBaseline__get_textBeforeEdge(this$) {
    const tupledArg = [this$.property, new Svg_DominantBaseline(7)];
    return [tupledArg[0], tupledArg[1]];
}

export function SvgClasses_DominantBaseline__get_textTop(this$) {
    const tupledArg = [this$.property, new Svg_DominantBaseline(8)];
    return [tupledArg[0], tupledArg[1]];
}

export class SvgClasses_TextAnchor {
    constructor(property) {
        this.property = property;
    }
}

export function SvgClasses_TextAnchor$reflection() {
    return class_type("Fss.Types.SvgClasses.TextAnchor", void 0, SvgClasses_TextAnchor);
}

export function SvgClasses_TextAnchor_$ctor_Z207A3CFB(property) {
    return new SvgClasses_TextAnchor(property);
}

export function SvgClasses_TextAnchor__get_start(this$) {
    const tupledArg = [this$.property, new Svg_TextAnchor(0)];
    return [tupledArg[0], tupledArg[1]];
}

export function SvgClasses_TextAnchor__get_middle(this$) {
    const tupledArg = [this$.property, new Svg_AlignmentBaseline(3)];
    return [tupledArg[0], tupledArg[1]];
}

export function SvgClasses_TextAnchor__get_end$0027(this$) {
    const tupledArg = [this$.property, new Svg_TextAnchor(2)];
    return [tupledArg[0], tupledArg[1]];
}

export class SvgClasses_ClipRule {
    constructor(property) {
        this.property = property;
    }
}

export function SvgClasses_ClipRule$reflection() {
    return class_type("Fss.Types.SvgClasses.ClipRule", void 0, SvgClasses_ClipRule);
}

export function SvgClasses_ClipRule_$ctor_Z207A3CFB(property) {
    return new SvgClasses_ClipRule(property);
}

export function SvgClasses_ClipRule__get_nonzero(this$) {
    const tupledArg = [this$.property, new Svg_ClipRule(0)];
    return [tupledArg[0], tupledArg[1]];
}

export function SvgClasses_ClipRule__get_evenodd(this$) {
    const tupledArg = [this$.property, new Svg_ClipRule(1)];
    return [tupledArg[0], tupledArg[1]];
}

export class SvgClasses_FloodColor extends ColorClass_Color {
    constructor(property) {
        super(property);
    }
}

export function SvgClasses_FloodColor$reflection() {
    return class_type("Fss.Types.SvgClasses.FloodColor", void 0, SvgClasses_FloodColor, ColorClass_Color$reflection());
}

export function SvgClasses_FloodColor_$ctor_Z207A3CFB(property) {
    return new SvgClasses_FloodColor(property);
}

export class SvgClasses_Opacity {
    constructor(property) {
        this.property = property;
    }
}

export function SvgClasses_Opacity$reflection() {
    return class_type("Fss.Types.SvgClasses.Opacity", void 0, SvgClasses_Opacity);
}

export function SvgClasses_Opacity_$ctor_Z207A3CFB(property) {
    return new SvgClasses_Opacity(property);
}

export function SvgClasses_Opacity__value_5E38073B(this$, opacity) {
    const value = (opacity > 1) ? 1 : ((opacity < 0) ? 0 : opacity);
    const tupledArg = [this$.property, new Float(0, value)];
    return [tupledArg[0], tupledArg[1]];
}

export class SvgClasses_LightingColor extends ColorClass_Color {
    constructor(property) {
        super(property);
    }
}

export function SvgClasses_LightingColor$reflection() {
    return class_type("Fss.Types.SvgClasses.LightingColor", void 0, SvgClasses_LightingColor, ColorClass_Color$reflection());
}

export function SvgClasses_LightingColor_$ctor_Z207A3CFB(property) {
    return new SvgClasses_LightingColor(property);
}

export class SvgClasses_StopColor extends ColorClass_Color {
    constructor(property) {
        super(property);
    }
}

export function SvgClasses_StopColor$reflection() {
    return class_type("Fss.Types.SvgClasses.StopColor", void 0, SvgClasses_StopColor, ColorClass_Color$reflection());
}

export function SvgClasses_StopColor_$ctor_Z207A3CFB(property) {
    return new SvgClasses_StopColor(property);
}

export class SvgClasses_ColorInterpolation {
    constructor(property) {
        this.property = property;
    }
}

export function SvgClasses_ColorInterpolation$reflection() {
    return class_type("Fss.Types.SvgClasses.ColorInterpolation", void 0, SvgClasses_ColorInterpolation);
}

export function SvgClasses_ColorInterpolation_$ctor_Z207A3CFB(property) {
    return new SvgClasses_ColorInterpolation(property);
}

export function SvgClasses_ColorInterpolation__get_auto(this$) {
    const tupledArg = [this$.property, new Auto(0)];
    return [tupledArg[0], tupledArg[1]];
}

export function SvgClasses_ColorInterpolation__get_sRGB(this$) {
    const tupledArg = [this$.property, new Svg_ColorInterpolation(0)];
    return [tupledArg[0], tupledArg[1]];
}

export function SvgClasses_ColorInterpolation__get_linearRGB(this$) {
    const tupledArg = [this$.property, new Svg_ColorInterpolation(1)];
    return [tupledArg[0], tupledArg[1]];
}

export class SvgClasses_Fill extends ColorClass_Color {
    constructor(property) {
        super(property);
    }
}

export function SvgClasses_Fill$reflection() {
    return class_type("Fss.Types.SvgClasses.Fill", void 0, SvgClasses_Fill, ColorClass_Color$reflection());
}

export function SvgClasses_Fill_$ctor_Z207A3CFB(property) {
    return new SvgClasses_Fill(property);
}

export class SvgClasses_ImageRendering {
    constructor(property) {
        this.property = property;
    }
}

export function SvgClasses_ImageRendering$reflection() {
    return class_type("Fss.Types.SvgClasses.ImageRendering", void 0, SvgClasses_ImageRendering);
}

export function SvgClasses_ImageRendering_$ctor_Z207A3CFB(property) {
    return new SvgClasses_ImageRendering(property);
}

export function SvgClasses_ImageRendering__get_auto(this$) {
    const tupledArg = [this$.property, new Auto(0)];
    return [tupledArg[0], tupledArg[1]];
}

export function SvgClasses_ImageRendering__get_optimizeSpeed(this$) {
    const tupledArg = [this$.property, new Svg_ImageRendering(0)];
    return [tupledArg[0], tupledArg[1]];
}

export function SvgClasses_ImageRendering__get_optimizeQuality(this$) {
    const tupledArg = [this$.property, new Svg_ImageRendering(1)];
    return [tupledArg[0], tupledArg[1]];
}

export class SvgClasses_ShapeRendering {
    constructor(property) {
        this.property = property;
    }
}

export function SvgClasses_ShapeRendering$reflection() {
    return class_type("Fss.Types.SvgClasses.ShapeRendering", void 0, SvgClasses_ShapeRendering);
}

export function SvgClasses_ShapeRendering_$ctor_Z207A3CFB(property) {
    return new SvgClasses_ShapeRendering(property);
}

export function SvgClasses_ShapeRendering__get_auto(this$) {
    const tupledArg = [this$.property, new Auto(0)];
    return [tupledArg[0], tupledArg[1]];
}

export function SvgClasses_ShapeRendering__get_optimizeSpeed(this$) {
    const tupledArg = [this$.property, new Svg_ImageRendering(0)];
    return [tupledArg[0], tupledArg[1]];
}

export function SvgClasses_ShapeRendering__get_crispEdges(this$) {
    const tupledArg = [this$.property, new Svg_ShapeRendering(1)];
    return [tupledArg[0], tupledArg[1]];
}

export function SvgClasses_ShapeRendering__get_geometricPrecision(this$) {
    const tupledArg = [this$.property, new Svg_ShapeRendering(2)];
    return [tupledArg[0], tupledArg[1]];
}

export class SvgClasses_Stroke extends ColorClass_Color {
    constructor(property) {
        super(property);
    }
}

export function SvgClasses_Stroke$reflection() {
    return class_type("Fss.Types.SvgClasses.Stroke", void 0, SvgClasses_Stroke, ColorClass_Color$reflection());
}

export function SvgClasses_Stroke_$ctor_Z207A3CFB(property) {
    return new SvgClasses_Stroke(property);
}

export class SvgClasses_StrokeDash {
    constructor(property) {
        this.property = property;
    }
}

export function SvgClasses_StrokeDash$reflection() {
    return class_type("Fss.Types.SvgClasses.StrokeDash", void 0, SvgClasses_StrokeDash);
}

export function SvgClasses_StrokeDash_$ctor_Z207A3CFB(property) {
    return new SvgClasses_StrokeDash(property);
}

export function SvgClasses_StrokeDash__value_Z3DDD5B6A(this$, dash) {
    const value = join(", ", map(int32ToString, dash));
    const tupledArg = [this$.property, new String$(0, value)];
    return [tupledArg[0], tupledArg[1]];
}

export class SvgClasses_StrokeLinecap {
    constructor(property) {
        this.property = property;
    }
}

export function SvgClasses_StrokeLinecap$reflection() {
    return class_type("Fss.Types.SvgClasses.StrokeLinecap", void 0, SvgClasses_StrokeLinecap);
}

export function SvgClasses_StrokeLinecap_$ctor_Z207A3CFB(property) {
    return new SvgClasses_StrokeLinecap(property);
}

export function SvgClasses_StrokeLinecap__get_butt(this$) {
    const tupledArg = [this$.property, new Svg_StrokeLinecap(0)];
    return [tupledArg[0], tupledArg[1]];
}

export function SvgClasses_StrokeLinecap__get_round(this$) {
    const tupledArg = [this$.property, new Svg_StrokeLinecap(1)];
    return [tupledArg[0], tupledArg[1]];
}

export function SvgClasses_StrokeLinecap__get_square(this$) {
    const tupledArg = [this$.property, new Svg_StrokeLinecap(2)];
    return [tupledArg[0], tupledArg[1]];
}

export class SvgClasses_StrokeLinejoin {
    constructor(property) {
        this.property = property;
    }
}

export function SvgClasses_StrokeLinejoin$reflection() {
    return class_type("Fss.Types.SvgClasses.StrokeLinejoin", void 0, SvgClasses_StrokeLinejoin);
}

export function SvgClasses_StrokeLinejoin_$ctor_Z207A3CFB(property) {
    return new SvgClasses_StrokeLinejoin(property);
}

export function SvgClasses_StrokeLinejoin__get_arcs(this$) {
    const tupledArg = [this$.property, new Svg_StrokeLinejoin(0)];
    return [tupledArg[0], tupledArg[1]];
}

export function SvgClasses_StrokeLinejoin__get_bevel(this$) {
    const tupledArg = [this$.property, new Svg_StrokeLinejoin(1)];
    return [tupledArg[0], tupledArg[1]];
}

export function SvgClasses_StrokeLinejoin__get_miter(this$) {
    const tupledArg = [this$.property, new Svg_StrokeLinejoin(2)];
    return [tupledArg[0], tupledArg[1]];
}

export function SvgClasses_StrokeLinejoin__get_miterClip(this$) {
    const tupledArg = [this$.property, new Svg_StrokeLinejoin(3)];
    return [tupledArg[0], tupledArg[1]];
}

export function SvgClasses_StrokeLinejoin__get_round(this$) {
    const tupledArg = [this$.property, new Svg_StrokeLinecap(1)];
    return [tupledArg[0], tupledArg[1]];
}

export class SvgClasses_StrokeMiterlimit {
    constructor(property) {
        this.property = property;
    }
}

export function SvgClasses_StrokeMiterlimit$reflection() {
    return class_type("Fss.Types.SvgClasses.StrokeMiterlimit", void 0, SvgClasses_StrokeMiterlimit);
}

export function SvgClasses_StrokeMiterlimit_$ctor_Z207A3CFB(property) {
    return new SvgClasses_StrokeMiterlimit(property);
}

export function SvgClasses_StrokeMiterlimit__value_Z524259A4(this$, limit) {
    const tupledArg = [this$.property, new Int(0, limit)];
    return [tupledArg[0], tupledArg[1]];
}

export class SvgClasses_StrokeWidth {
    constructor(property) {
        this.property = property;
    }
}

export function SvgClasses_StrokeWidth$reflection() {
    return class_type("Fss.Types.SvgClasses.StrokeWidth", void 0, SvgClasses_StrokeWidth);
}

export function SvgClasses_StrokeWidth_$ctor_Z207A3CFB(property) {
    return new SvgClasses_StrokeWidth(property);
}

export function SvgClasses_StrokeWidth__value_Z498FEB3B(this$, limit) {
    const tupledArg = [this$.property, unitHelpers_lengthPercentageToType(limit)];
    return [tupledArg[0], tupledArg[1]];
}

//# sourceMappingURL=Svg.fs.js.map
