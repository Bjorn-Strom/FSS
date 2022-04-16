import { CssRule$reflection, CssRule, String$, CssRuleWithNone$reflection, CssRuleWithNone, MasterTypeHelpers_stringifyICssValue } from "./MasterTypes.fs.js";
import { unitHelpers_CssRuleWithLength$reflection, unitHelpers_CssRuleWithLength, Angle$reflection, Length$reflection, unitHelpers_lengthPercentageString } from "./Units.fs.js";
import { toString, Union } from "../../fable-library.3.7.9/Types.js";
import { union_type, class_type, int32_type, float64_type } from "../../fable-library.3.7.9/Reflection.js";
import { join } from "../../fable-library.3.7.9/String.js";
import { map } from "../../fable-library.3.7.9/List.js";

export class Transform_Transform extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["Matrix", "Matrix3D", "Perspective", "Rotate", "Rotate3D", "RotateX", "RotateY", "RotateZ", "Translate", "Translate2", "Translate3D", "TranslateX", "TranslateY", "TranslateZ", "Scale", "Scale2", "Scale3D", "ScaleX", "ScaleY", "ScaleZ", "Skew", "Skew2", "SkewX", "SkewY"];
    }
    StringifyCss() {
        const this$ = this;
        switch (this$.tag) {
            case 1: {
                const d4 = this$.fields[15];
                const d3 = this$.fields[11] | 0;
                const d2 = this$.fields[7] | 0;
                const d1 = this$.fields[3] | 0;
                const c4 = this$.fields[14];
                const c3 = this$.fields[10] | 0;
                const c2 = this$.fields[6] | 0;
                const c1 = this$.fields[2] | 0;
                const b4 = this$.fields[13];
                const b3 = this$.fields[9] | 0;
                const b2 = this$.fields[5] | 0;
                const b1 = this$.fields[1] | 0;
                const a4 = this$.fields[12];
                const a3 = this$.fields[8] | 0;
                const a2 = this$.fields[4] | 0;
                const a1 = this$.fields[0] | 0;
                return `matrix3d(${a1}, ${b1}, ${c1}, ${d1}, ${a2}, ${b2}, ${c2}, ${d2}, ${a3}, ${b3}, ${c3}, ${d3}, ${a4}, ${b4}, ${c4}, ${d4})`;
            }
            case 2: {
                const size = this$.fields[0];
                return `perspective(${MasterTypeHelpers_stringifyICssValue(size)})`;
            }
            case 3: {
                const angle = this$.fields[0];
                return `rotate(${MasterTypeHelpers_stringifyICssValue(angle)})`;
            }
            case 4: {
                const c_1 = this$.fields[2];
                const b_1 = this$.fields[1];
                const angle_1 = this$.fields[3];
                const a_1 = this$.fields[0];
                return `rotate3d(${a_1}, ${b_1}, ${c_1}, ${MasterTypeHelpers_stringifyICssValue(angle_1)})`;
            }
            case 5: {
                const angle_2 = this$.fields[0];
                return `rotateX(${MasterTypeHelpers_stringifyICssValue(angle_2)})`;
            }
            case 6: {
                const angle_3 = this$.fields[0];
                return `rotateY(${MasterTypeHelpers_stringifyICssValue(angle_3)})`;
            }
            case 7: {
                const angle_4 = this$.fields[0];
                return `rotateZ(${MasterTypeHelpers_stringifyICssValue(angle_4)})`;
            }
            case 8: {
                const size_1 = this$.fields[0];
                return `translate(${unitHelpers_lengthPercentageString(size_1)})`;
            }
            case 9: {
                const sy = this$.fields[1];
                const sx = this$.fields[0];
                return `translate(${unitHelpers_lengthPercentageString(sx)}, ${unitHelpers_lengthPercentageString(sy)})`;
            }
            case 10: {
                const size3 = this$.fields[2];
                const size2 = this$.fields[1];
                const size1 = this$.fields[0];
                return `translate3d(${unitHelpers_lengthPercentageString(size1)}, ${unitHelpers_lengthPercentageString(size2)}, ${unitHelpers_lengthPercentageString(size3)})`;
            }
            case 11: {
                const size_2 = this$.fields[0];
                return `translateX(${unitHelpers_lengthPercentageString(size_2)})`;
            }
            case 12: {
                const size_3 = this$.fields[0];
                return `translateY(${unitHelpers_lengthPercentageString(size_3)})`;
            }
            case 13: {
                const size_4 = this$.fields[0];
                return `translateZ(${unitHelpers_lengthPercentageString(size_4)})`;
            }
            case 14: {
                const n = this$.fields[0];
                return `scale(${n})`;
            }
            case 15: {
                const sy_1 = this$.fields[1];
                const sx_1 = this$.fields[0];
                return `scale(${sx_1}, ${sy_1})`;
            }
            case 16: {
                const n3 = this$.fields[2];
                const n2 = this$.fields[1];
                const n1 = this$.fields[0];
                return `scale3d(${n1}, ${n2}, ${n3})`;
            }
            case 17: {
                const n_1 = this$.fields[0];
                return `scaleX(${n_1})`;
            }
            case 18: {
                const n_2 = this$.fields[0];
                return `scaleY(${n_2})`;
            }
            case 19: {
                const n_3 = this$.fields[0];
                return `scaleZ(${n_3})`;
            }
            case 20: {
                const a_2 = this$.fields[0];
                return `skew(${MasterTypeHelpers_stringifyICssValue(a_2)})`;
            }
            case 21: {
                const ay = this$.fields[1];
                const ax = this$.fields[0];
                return `skew(${MasterTypeHelpers_stringifyICssValue(ax)}, ${MasterTypeHelpers_stringifyICssValue(ay)})`;
            }
            case 22: {
                const a_3 = this$.fields[0];
                return `skewX(${MasterTypeHelpers_stringifyICssValue(a_3)})`;
            }
            case 23: {
                const a_4 = this$.fields[0];
                return `skewY(${MasterTypeHelpers_stringifyICssValue(a_4)})`;
            }
            default: {
                const f = this$.fields[5];
                const e = this$.fields[4];
                const d = this$.fields[3];
                const c = this$.fields[2];
                const b = this$.fields[1];
                const a = this$.fields[0];
                return `matrix(${a}, ${b}, ${c}, ${d}, ${e}, ${f})`;
            }
        }
    }
}

export function Transform_Transform$reflection() {
    return union_type("Fss.Types.Transform.Transform", [], Transform_Transform, () => [[["Item1", float64_type], ["Item2", float64_type], ["Item3", float64_type], ["Item4", float64_type], ["Item5", float64_type], ["Item6", float64_type]], [["Item1", int32_type], ["Item2", int32_type], ["Item3", int32_type], ["Item4", int32_type], ["Item5", int32_type], ["Item6", int32_type], ["Item7", int32_type], ["Item8", int32_type], ["Item9", int32_type], ["Item10", int32_type], ["Item11", int32_type], ["Item12", int32_type], ["Item13", float64_type], ["Item14", float64_type], ["Item15", float64_type], ["Item16", float64_type]], [["Item", Length$reflection()]], [["Item", Angle$reflection()]], [["Item1", float64_type], ["Item2", float64_type], ["Item3", float64_type], ["Item4", Angle$reflection()]], [["Item", Angle$reflection()]], [["Item", Angle$reflection()]], [["Item", Angle$reflection()]], [["Item", class_type("Fss.Types.ILengthPercentage")]], [["Item1", class_type("Fss.Types.ILengthPercentage")], ["Item2", class_type("Fss.Types.ILengthPercentage")]], [["Item1", class_type("Fss.Types.ILengthPercentage")], ["Item2", class_type("Fss.Types.ILengthPercentage")], ["Item3", class_type("Fss.Types.ILengthPercentage")]], [["Item", class_type("Fss.Types.ILengthPercentage")]], [["Item", class_type("Fss.Types.ILengthPercentage")]], [["Item", class_type("Fss.Types.ILengthPercentage")]], [["Item", float64_type]], [["Item1", float64_type], ["Item2", float64_type]], [["Item1", float64_type], ["Item2", float64_type], ["Item3", float64_type]], [["Item", float64_type]], [["Item", float64_type]], [["Item", float64_type]], [["Item", Angle$reflection()]], [["Item1", Angle$reflection()], ["Item2", Angle$reflection()]], [["Item", Angle$reflection()]], [["Item", Angle$reflection()]]]);
}

export class Transform_Origin extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["Top", "Left", "Right", "Bottom", "Center"];
    }
    StringifyCss() {
        const this$ = this;
        return toString(this$).toLocaleLowerCase();
    }
}

export function Transform_Origin$reflection() {
    return union_type("Fss.Types.Transform.Origin", [], Transform_Origin, () => [[], [], [], [], []]);
}

export class Transform_Style extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["Flat", "Preserve3d"];
    }
    StringifyCss() {
        const this$ = this;
        return toString(this$).toLocaleLowerCase();
    }
}

export function Transform_Style$reflection() {
    return union_type("Fss.Types.Transform.Style", [], Transform_Style, () => [[], []]);
}

export class TransformClasses_TransformClass extends CssRuleWithNone {
    constructor(property) {
        super(property);
        this.property_2 = property;
    }
}

export function TransformClasses_TransformClass$reflection() {
    return class_type("Fss.Types.TransformClasses.TransformClass", void 0, TransformClasses_TransformClass, CssRuleWithNone$reflection());
}

export function TransformClasses_TransformClass_$ctor_Z207A3CFB(property) {
    return new TransformClasses_TransformClass(property);
}

export function TransformClasses_TransformClass__value_ZF56B0F4(this$, transforms) {
    const transforms_1 = join(" ", map(MasterTypeHelpers_stringifyICssValue, transforms));
    const tupledArg = [this$.property_2, new String$(0, transforms_1)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransformClasses_TransformClass__matrix_76A78260(this$, a, b, c, d, tx, ty) {
    return new Transform_Transform(0, a, b, c, d, tx, ty);
}

export function TransformClasses_TransformClass__matrix3D_Z4F721840(this$, a1, b1, c1, d1, a2, b2, c2, d2, a3, b3, c3, d3, a4, b4, c4, d4) {
    return new Transform_Transform(1, a1, b1, c1, d1, a2, b2, c2, d2, a3, b3, c3, d3, a4, b4, c4, d4);
}

export function TransformClasses_TransformClass__perspective_Z5C52D00C(this$, length) {
    return new Transform_Transform(2, length);
}

export function TransformClasses_TransformClass__rotate_CEE3389(this$, angle) {
    return new Transform_Transform(3, angle);
}

export function TransformClasses_TransformClass__rotate3D_25075E72(this$, x, y, z, a) {
    return new Transform_Transform(4, x, y, z, a);
}

export function TransformClasses_TransformClass__rotateX_CEE3389(this$, angle) {
    return new Transform_Transform(5, angle);
}

export function TransformClasses_TransformClass__rotateY_CEE3389(this$, angle) {
    return new Transform_Transform(6, angle);
}

export function TransformClasses_TransformClass__rotateZ_CEE3389(this$, angle) {
    return new Transform_Transform(7, angle);
}

export function TransformClasses_TransformClass__translate_Z498FEB3B(this$, length) {
    return new Transform_Transform(8, length);
}

export function TransformClasses_TransformClass__translate_3202B9A0(this$, a, b) {
    return new Transform_Transform(9, a, b);
}

export function TransformClasses_TransformClass__translate3D_Z3BD6069B(this$, a, b, c) {
    return new Transform_Transform(10, a, b, c);
}

export function TransformClasses_TransformClass__translateX_Z498FEB3B(this$, length) {
    return new Transform_Transform(11, length);
}

export function TransformClasses_TransformClass__translateY_Z498FEB3B(this$, length) {
    return new Transform_Transform(12, length);
}

export function TransformClasses_TransformClass__translateZ_Z498FEB3B(this$, length) {
    return new Transform_Transform(13, length);
}

export function TransformClasses_TransformClass__scale_5E38073B(this$, scale) {
    return new Transform_Transform(14, scale);
}

export function TransformClasses_TransformClass__scale_7B00E9A0(this$, a, b) {
    return new Transform_Transform(15, a, b);
}

export function TransformClasses_TransformClass__scale3D_Z7AD9E565(this$, a, b, c) {
    return new Transform_Transform(16, a, b, c);
}

export function TransformClasses_TransformClass__scaleX_5E38073B(this$, scale) {
    return new Transform_Transform(17, scale);
}

export function TransformClasses_TransformClass__scaleY_5E38073B(this$, scale) {
    return new Transform_Transform(18, scale);
}

export function TransformClasses_TransformClass__scaleZ_5E38073B(this$, scale) {
    return new Transform_Transform(19, scale);
}

export function TransformClasses_TransformClass__skew_CEE3389(this$, angle) {
    return new Transform_Transform(20, angle);
}

export function TransformClasses_TransformClass__skew_Z59A568E0(this$, a, b) {
    return new Transform_Transform(21, a, b);
}

export function TransformClasses_TransformClass__skewX_CEE3389(this$, angle) {
    return new Transform_Transform(22, angle);
}

export function TransformClasses_TransformClass__skewY_CEE3389(this$, angle) {
    return new Transform_Transform(23, angle);
}

export class TransformClasses_TransformOrigin extends unitHelpers_CssRuleWithLength {
    constructor(property) {
        super(property);
        this.property_2 = property;
    }
}

export function TransformClasses_TransformOrigin$reflection() {
    return class_type("Fss.Types.TransformClasses.TransformOrigin", void 0, TransformClasses_TransformOrigin, unitHelpers_CssRuleWithLength$reflection());
}

export function TransformClasses_TransformOrigin_$ctor_Z207A3CFB(property) {
    return new TransformClasses_TransformOrigin(property);
}

export function TransformClasses_TransformOrigin__value_3202B9A0(this$, x, y) {
    const value = new String$(0, `${unitHelpers_lengthPercentageString(x)} ${unitHelpers_lengthPercentageString(y)}`);
    const tupledArg = [this$.property_2, value];
    return [tupledArg[0], tupledArg[1]];
}

export function TransformClasses_TransformOrigin__value_Z3BD6069B(this$, x, y, z) {
    const value = new String$(0, `${unitHelpers_lengthPercentageString(x)} ${unitHelpers_lengthPercentageString(y)} ${unitHelpers_lengthPercentageString(z)}`);
    const tupledArg = [this$.property_2, value];
    return [tupledArg[0], tupledArg[1]];
}

export function TransformClasses_TransformOrigin__get_top(this$) {
    const tupledArg = [this$.property_2, new Transform_Origin(0)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransformClasses_TransformOrigin__get_left(this$) {
    const tupledArg = [this$.property_2, new Transform_Origin(1)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransformClasses_TransformOrigin__get_right(this$) {
    const tupledArg = [this$.property_2, new Transform_Origin(2)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransformClasses_TransformOrigin__get_bottom(this$) {
    const tupledArg = [this$.property_2, new Transform_Origin(3)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransformClasses_TransformOrigin__get_center(this$) {
    const tupledArg = [this$.property_2, new Transform_Origin(4)];
    return [tupledArg[0], tupledArg[1]];
}

export class TransformClasses_TransformStyle extends CssRule {
    constructor(property) {
        super(property);
        this.property_1 = property;
    }
}

export function TransformClasses_TransformStyle$reflection() {
    return class_type("Fss.Types.TransformClasses.TransformStyle", void 0, TransformClasses_TransformStyle, CssRule$reflection());
}

export function TransformClasses_TransformStyle_$ctor_Z207A3CFB(property) {
    return new TransformClasses_TransformStyle(property);
}

export function TransformClasses_TransformStyle__get_flat(this$) {
    const tupledArg = [this$.property_1, new Transform_Style(0)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransformClasses_TransformStyle__get_preserve3d(this$) {
    const tupledArg = [this$.property_1, new Transform_Style(1)];
    return [tupledArg[0], tupledArg[1]];
}

//# sourceMappingURL=Transform.fs.js.map
