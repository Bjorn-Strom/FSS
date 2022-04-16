import { Helpers_toKebabCase } from "../Utilities.fs.js";
import { toString, Union } from "../../fable-library.3.7.9/Types.js";
import { list_type, tuple_type, class_type, string_type, union_type } from "../../fable-library.3.7.9/Reflection.js";
import { CssRuleWithAuto$reflection, CssRuleWithAuto, String$, CssRule$reflection, CssRule, CssRuleWithNone$reflection, CssRuleWithNone, Stringed, UrlMaster, Stringed$reflection, MasterTypeHelpers_stringifyICssValue } from "./MasterTypes.fs.js";
import { map, fold } from "../../fable-library.3.7.9/List.js";
import { Percent$reflection, Angle$reflection, unitHelpers_lengthPercentageString } from "./Units.fs.js";
import { join } from "../../fable-library.3.7.9/String.js";
import { Color_Color$reflection } from "./Color.fs.js";

export class Image_Side extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["ClosestSide", "ClosestCorner", "FarthestSide", "FarthestCorner"];
    }
    StringifyCss() {
        const this$ = this;
        return Helpers_toKebabCase(this$);
    }
}

export function Image_Side$reflection() {
    return union_type("Fss.Types.Image.Side", [], Image_Side, () => [[], [], [], []]);
}

export class Image_Shape extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["Circle", "Ellipse"];
    }
    StringifyCss() {
        const this$ = this;
        return toString(this$).toLocaleLowerCase();
    }
}

export function Image_Shape$reflection() {
    return union_type("Fss.Types.Image.Shape", [], Image_Shape, () => [[], []]);
}

export class Image_ObjectFit extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["Fill", "Contain", "Cover", "ScaleDown"];
    }
    StringifyCss() {
        const this$ = this;
        return Helpers_toKebabCase(this$);
    }
}

export function Image_ObjectFit$reflection() {
    return union_type("Fss.Types.Image.ObjectFit", [], Image_ObjectFit, () => [[], [], [], []]);
}

export class Image_Rendering extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["CrispEdges", "Pixelated"];
    }
    StringifyCss() {
        const this$ = this;
        return Helpers_toKebabCase(this$);
    }
}

export function Image_Rendering$reflection() {
    return union_type("Fss.Types.Image.Rendering", [], Image_Rendering, () => [[], []]);
}

export class Image_Image extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["Url", "UrlAlt", "LinearGradient", "LinearGradients", "RepeatingLinearGradient", "RepeatingLinearGradients", "RadialGradient", "RadialGradients", "RepeatingRadialGradient", "RepeatingRadialGradients", "ConicGradientAngle", "ConicGradientPercent", "RepeatingConicGradientAngle", "RepeatingConicGradientPercent"];
    }
    StringifyCounter() {
        const this$ = this;
        return MasterTypeHelpers_stringifyICssValue(this$);
    }
    StringifyCss() {
        const this$ = this;
        const gradientToString = (gradients) => fold((acc, tupledArg) => {
            const color = tupledArg[0];
            const length = tupledArg[1];
            return `${acc}, ${MasterTypeHelpers_stringifyICssValue(color)} ${unitHelpers_lengthPercentageString(length)}`;
        }, "", gradients);
        const gradientAngleToString = (gradients_1) => fold((acc_1, tupledArg_1) => {
            const color_1 = tupledArg_1[0];
            const angle = tupledArg_1[1];
            return `${acc_1}, ${MasterTypeHelpers_stringifyICssValue(color_1)} ${MasterTypeHelpers_stringifyICssValue(angle)}`;
        }, "", gradients_1);
        const gradientPercentToString = (gradients_2) => fold((acc_2, tupledArg_2) => {
            const color_2 = tupledArg_2[0];
            const length_1 = tupledArg_2[1];
            return `${acc_2}, ${MasterTypeHelpers_stringifyICssValue(color_2)} ${MasterTypeHelpers_stringifyICssValue(length_1)}`;
        }, "", gradients_2);
        const linearGradientToString = (tupledArg_3) => {
            const angle_1 = tupledArg_3[0];
            const gradients_3 = tupledArg_3[1];
            return `linear-gradient(${MasterTypeHelpers_stringifyICssValue(angle_1)}${gradientToString(gradients_3)})`;
        };
        const linearGradientsToString = (gradients_4) => join(", ", map((tupledArg_4) => linearGradientToString([tupledArg_4[0], tupledArg_4[1]]), gradients_4));
        const repeatingLinearGradient = (tupledArg_5) => {
            const angle_2 = tupledArg_5[0];
            const gradients_5 = tupledArg_5[1];
            return `repeating-linear-gradient(${MasterTypeHelpers_stringifyICssValue(angle_2)}${gradientToString(gradients_5)})`;
        };
        const repeatingLinearGradients = (gradients_6) => join(", ", map((tupledArg_6) => repeatingLinearGradient([tupledArg_6[0], tupledArg_6[1]]), gradients_6));
        const radialGradientToString = (tupledArg_7) => {
            let copyOfStruct;
            const shape = tupledArg_7[0];
            const side = tupledArg_7[1];
            const x = tupledArg_7[2];
            const y = tupledArg_7[3];
            const gradients_7 = tupledArg_7[4];
            return `radial-gradient(${((copyOfStruct = shape, toString(copyOfStruct))).toLocaleLowerCase()} ${MasterTypeHelpers_stringifyICssValue(side)} at ${MasterTypeHelpers_stringifyICssValue(x)} ${MasterTypeHelpers_stringifyICssValue(y)}${gradientToString(gradients_7)})`;
        };
        const radialGradientsToString = (gradients_8) => join(", ", map((tupledArg_8) => radialGradientToString([tupledArg_8[0], tupledArg_8[1], tupledArg_8[2], tupledArg_8[3], tupledArg_8[4]]), gradients_8));
        const repeatingRadialGradientToString = (tupledArg_9) => {
            let copyOfStruct_1;
            const shape_1 = tupledArg_9[0];
            const side_1 = tupledArg_9[1];
            const x_1 = tupledArg_9[2];
            const y_1 = tupledArg_9[3];
            const gradients_9 = tupledArg_9[4];
            return `repeating-radial-gradient(${((copyOfStruct_1 = shape_1, toString(copyOfStruct_1))).toLocaleLowerCase()} ${MasterTypeHelpers_stringifyICssValue(side_1)} at ${MasterTypeHelpers_stringifyICssValue(x_1)} ${MasterTypeHelpers_stringifyICssValue(y_1)}${gradientToString(gradients_9)})`;
        };
        const repeatingRadialGradientsToString = (gradients_10) => join(", ", map((tupledArg_10) => repeatingRadialGradientToString([tupledArg_10[0], tupledArg_10[1], tupledArg_10[2], tupledArg_10[3], tupledArg_10[4]]), gradients_10));
        const conicGradientAngleToString = (tupledArg_11) => {
            const angle_3 = tupledArg_11[0];
            const x_2 = tupledArg_11[1];
            const y_2 = tupledArg_11[2];
            const gradients_11 = tupledArg_11[3];
            return `conic-gradient(from ${MasterTypeHelpers_stringifyICssValue(angle_3)} at ${MasterTypeHelpers_stringifyICssValue(x_2)} ${MasterTypeHelpers_stringifyICssValue(y_2)}${gradientAngleToString(gradients_11)})`;
        };
        const conicGradientPercentToString = (tupledArg_12) => {
            const angle_4 = tupledArg_12[0];
            const x_3 = tupledArg_12[1];
            const y_3 = tupledArg_12[2];
            const gradients_12 = tupledArg_12[3];
            return `conic-gradient(from ${MasterTypeHelpers_stringifyICssValue(angle_4)} at ${MasterTypeHelpers_stringifyICssValue(x_3)} ${MasterTypeHelpers_stringifyICssValue(y_3)}${gradientPercentToString(gradients_12)})`;
        };
        const repeatingConicGradientAngleToString = (tupledArg_13) => {
            const angle_5 = tupledArg_13[0];
            const x_4 = tupledArg_13[1];
            const y_4 = tupledArg_13[2];
            const gradients_13 = tupledArg_13[3];
            return `repeating-conic-gradient(from ${MasterTypeHelpers_stringifyICssValue(angle_5)} at ${MasterTypeHelpers_stringifyICssValue(x_4)} ${MasterTypeHelpers_stringifyICssValue(y_4)}${gradientAngleToString(gradients_13)})`;
        };
        const repeatingConicGradientPercentToString = (tupledArg_14) => {
            const angle_6 = tupledArg_14[0];
            const x_5 = tupledArg_14[1];
            const y_5 = tupledArg_14[2];
            const gradients_14 = tupledArg_14[3];
            return `repeating-conic-gradient(from ${MasterTypeHelpers_stringifyICssValue(angle_6)} at ${MasterTypeHelpers_stringifyICssValue(x_5)} ${MasterTypeHelpers_stringifyICssValue(y_5)}${gradientPercentToString(gradients_14)})`;
        };
        switch (this$.tag) {
            case 1: {
                const u_1 = this$.fields[0];
                const a = this$.fields[1];
                return `url(${u_1}) / ${MasterTypeHelpers_stringifyICssValue(a)}`;
            }
            case 2: {
                const gradients_15 = this$.fields[1];
                const angle_7 = this$.fields[0];
                const tupledArg_15 = [angle_7, gradients_15];
                return linearGradientToString([tupledArg_15[0], tupledArg_15[1]]);
            }
            case 3: {
                const gradients_16 = this$.fields[0];
                return linearGradientsToString(gradients_16);
            }
            case 4: {
                const gradients_17 = this$.fields[1];
                const angle_8 = this$.fields[0];
                const tupledArg_16 = [angle_8, gradients_17];
                return repeatingLinearGradient([tupledArg_16[0], tupledArg_16[1]]);
            }
            case 5: {
                const gradients_18 = this$.fields[0];
                return repeatingLinearGradients(gradients_18);
            }
            case 6: {
                const y_6 = this$.fields[3];
                const x_6 = this$.fields[2];
                const side_2 = this$.fields[1];
                const shape_2 = this$.fields[0];
                const gradients_19 = this$.fields[4];
                const tupledArg_17 = [shape_2, side_2, x_6, y_6, gradients_19];
                return radialGradientToString([tupledArg_17[0], tupledArg_17[1], tupledArg_17[2], tupledArg_17[3], tupledArg_17[4]]);
            }
            case 7: {
                const gradients_20 = this$.fields[0];
                return radialGradientsToString(gradients_20);
            }
            case 8: {
                const y_7 = this$.fields[3];
                const x_7 = this$.fields[2];
                const side_3 = this$.fields[1];
                const shape_3 = this$.fields[0];
                const gradients_21 = this$.fields[4];
                const tupledArg_18 = [shape_3, side_3, x_7, y_7, gradients_21];
                return repeatingRadialGradientToString([tupledArg_18[0], tupledArg_18[1], tupledArg_18[2], tupledArg_18[3], tupledArg_18[4]]);
            }
            case 9: {
                const gradients_22 = this$.fields[0];
                return repeatingRadialGradientsToString(gradients_22);
            }
            case 10: {
                const y_8 = this$.fields[2];
                const x_8 = this$.fields[1];
                const gradients_23 = this$.fields[3];
                const angle_9 = this$.fields[0];
                const tupledArg_19 = [angle_9, x_8, y_8, gradients_23];
                return conicGradientAngleToString([tupledArg_19[0], tupledArg_19[1], tupledArg_19[2], tupledArg_19[3]]);
            }
            case 11: {
                const y_9 = this$.fields[2];
                const x_9 = this$.fields[1];
                const gradients_24 = this$.fields[3];
                const angle_10 = this$.fields[0];
                const tupledArg_20 = [angle_10, x_9, y_9, gradients_24];
                return conicGradientPercentToString([tupledArg_20[0], tupledArg_20[1], tupledArg_20[2], tupledArg_20[3]]);
            }
            case 12: {
                const y_10 = this$.fields[2];
                const x_10 = this$.fields[1];
                const gradients_25 = this$.fields[3];
                const angle_11 = this$.fields[0];
                const tupledArg_21 = [angle_11, x_10, y_10, gradients_25];
                return repeatingConicGradientAngleToString([tupledArg_21[0], tupledArg_21[1], tupledArg_21[2], tupledArg_21[3]]);
            }
            case 13: {
                const y_11 = this$.fields[2];
                const x_11 = this$.fields[1];
                const gradients_26 = this$.fields[3];
                const angle_12 = this$.fields[0];
                const tupledArg_22 = [angle_12, x_11, y_11, gradients_26];
                return repeatingConicGradientPercentToString([tupledArg_22[0], tupledArg_22[1], tupledArg_22[2], tupledArg_22[3]]);
            }
            default: {
                const u = this$.fields[0];
                return `url(${u})`;
            }
        }
    }
}

export function Image_Image$reflection() {
    return union_type("Fss.Types.Image.Image", [], Image_Image, () => [[["Item", string_type]], [["Item1", string_type], ["Item2", Stringed$reflection()]], [["Item1", Angle$reflection()], ["Item2", list_type(tuple_type(Color_Color$reflection(), class_type("Fss.Types.ILengthPercentage")))]], [["Item", list_type(tuple_type(Angle$reflection(), list_type(tuple_type(Color_Color$reflection(), class_type("Fss.Types.ILengthPercentage")))))]], [["Item1", Angle$reflection()], ["Item2", list_type(tuple_type(Color_Color$reflection(), class_type("Fss.Types.ILengthPercentage")))]], [["Item", list_type(tuple_type(Angle$reflection(), list_type(tuple_type(Color_Color$reflection(), class_type("Fss.Types.ILengthPercentage")))))]], [["Item1", Image_Shape$reflection()], ["Item2", Image_Side$reflection()], ["Item3", Percent$reflection()], ["Item4", Percent$reflection()], ["Item5", list_type(tuple_type(Color_Color$reflection(), class_type("Fss.Types.ILengthPercentage")))]], [["Item", list_type(tuple_type(Image_Shape$reflection(), Image_Side$reflection(), Percent$reflection(), Percent$reflection(), list_type(tuple_type(Color_Color$reflection(), class_type("Fss.Types.ILengthPercentage")))))]], [["Item1", Image_Shape$reflection()], ["Item2", Image_Side$reflection()], ["Item3", Percent$reflection()], ["Item4", Percent$reflection()], ["Item5", list_type(tuple_type(Color_Color$reflection(), class_type("Fss.Types.ILengthPercentage")))]], [["Item", list_type(tuple_type(Image_Shape$reflection(), Image_Side$reflection(), Percent$reflection(), Percent$reflection(), list_type(tuple_type(Color_Color$reflection(), class_type("Fss.Types.ILengthPercentage")))))]], [["Item1", Angle$reflection()], ["Item2", Percent$reflection()], ["Item3", Percent$reflection()], ["Item4", list_type(tuple_type(Color_Color$reflection(), Angle$reflection()))]], [["Item1", Angle$reflection()], ["Item2", Percent$reflection()], ["Item3", Percent$reflection()], ["Item4", list_type(tuple_type(Color_Color$reflection(), Percent$reflection()))]], [["Item1", Angle$reflection()], ["Item2", Percent$reflection()], ["Item3", Percent$reflection()], ["Item4", list_type(tuple_type(Color_Color$reflection(), Angle$reflection()))]], [["Item1", Angle$reflection()], ["Item2", Percent$reflection()], ["Item3", Percent$reflection()], ["Item4", list_type(tuple_type(Color_Color$reflection(), Percent$reflection()))]]]);
}

export class ImageClasses_Image {
    constructor() {
    }
}

export function ImageClasses_Image$reflection() {
    return class_type("Fss.Types.ImageClasses.Image", void 0, ImageClasses_Image);
}

export function ImageClasses_Image_url_Z721C83C5(url) {
    return new UrlMaster(0, url);
}

export function ImageClasses_Image_urlAlt_Z384F8060(url, alt) {
    return new Image_Image(1, url, new Stringed(0, alt));
}

export function ImageClasses_Image_linearGradient_2BE92E00(gradients) {
    const tupledArg = gradients;
    return new Image_Image(2, tupledArg[0], tupledArg[1]);
}

export function ImageClasses_Image_linearGradients_Z62CFBBB6(gradients) {
    return new Image_Image(3, gradients);
}

export function ImageClasses_Image_repeatingLinearGradient_2BE92E00(gradients) {
    const tupledArg = gradients;
    return new Image_Image(4, tupledArg[0], tupledArg[1]);
}

export function ImageClasses_Image_repeatingLinearGradients_Z62CFBBB6(gradients) {
    return new Image_Image(5, gradients);
}

export function ImageClasses_Image_radialGradient_64449692(shape, size, x, y, gradients) {
    return new Image_Image(6, shape, size, x, y, gradients);
}

export function ImageClasses_Image_radialGradients_544747B8(gradients) {
    return new Image_Image(7, gradients);
}

export function ImageClasses_Image_repeatingRadialGradient_64449692(shape, size, x, y, gradients) {
    return new Image_Image(8, shape, size, x, y, gradients);
}

export function ImageClasses_Image_conicGradient_Z516D4DFD(angle, x, y, gradients) {
    return new Image_Image(10, angle, x, y, gradients);
}

export function ImageClasses_Image_conicGradient_C015F99(angle, x, y, gradients) {
    return new Image_Image(11, angle, x, y, gradients);
}

export function ImageClasses_Image_repeatingConicGradient_Z516D4DFD(angle, x, y, gradients) {
    return new Image_Image(12, angle, x, y, gradients);
}

export function ImageClasses_Image_repeatingConicGradient_C015F99(angle, x, y, gradients) {
    return new Image_Image(13, angle, x, y, gradients);
}

export class ImageClasses_ImageClass extends CssRuleWithNone {
    constructor(property) {
        super(property);
        this.property_2 = property;
    }
}

export function ImageClasses_ImageClass$reflection() {
    return class_type("Fss.Types.ImageClasses.ImageClass", void 0, ImageClasses_ImageClass, CssRuleWithNone$reflection());
}

export function ImageClasses_ImageClass_$ctor_Z207A3CFB(property) {
    return new ImageClasses_ImageClass(property);
}

export function ImageClasses_ImageClass__url_Z721C83C5(this$, url) {
    const tupledArg = [this$.property_2, ImageClasses_Image_url_Z721C83C5(url)];
    return [tupledArg[0], tupledArg[1]];
}

export function ImageClasses_ImageClass__url_Z384F8060(this$, url, alt) {
    const tupledArg = [this$.property_2, ImageClasses_Image_urlAlt_Z384F8060(url, alt)];
    return [tupledArg[0], tupledArg[1]];
}

export function ImageClasses_ImageClass__linearGradient_2BE92E00(this$, gradients) {
    const tupledArg = [this$.property_2, ImageClasses_Image_linearGradient_2BE92E00(gradients)];
    return [tupledArg[0], tupledArg[1]];
}

export function ImageClasses_ImageClass__linearGradients_Z62CFBBB6(this$, gradients) {
    const tupledArg = [this$.property_2, ImageClasses_Image_linearGradients_Z62CFBBB6(gradients)];
    return [tupledArg[0], tupledArg[1]];
}

export function ImageClasses_ImageClass__repeatingLinearGradient_2BE92E00(this$, gradients) {
    let tupledArg;
    const tupledArg_1 = [this$.property_2, (tupledArg = gradients, new Image_Image(4, tupledArg[0], tupledArg[1]))];
    return [tupledArg_1[0], tupledArg_1[1]];
}

export function ImageClasses_ImageClass__repeatingLinearGradients_Z62CFBBB6(this$, gradients) {
    const tupledArg = [this$.property_2, new Image_Image(5, gradients)];
    return [tupledArg[0], tupledArg[1]];
}

export function ImageClasses_ImageClass__radialGradient_64449692(this$, shape, size, x, y, gradients) {
    const tupledArg = [this$.property_2, new Image_Image(6, shape, size, x, y, gradients)];
    return [tupledArg[0], tupledArg[1]];
}

export function ImageClasses_ImageClass__radialGradients_544747B8(this$, gradients) {
    const tupledArg = [this$.property_2, new Image_Image(7, gradients)];
    return [tupledArg[0], tupledArg[1]];
}

export function ImageClasses_ImageClass__repeatingRadialGradient_64449692(this$, shape, size, x, y, gradients) {
    const tupledArg = [this$.property_2, new Image_Image(8, shape, size, x, y, gradients)];
    return [tupledArg[0], tupledArg[1]];
}

export function ImageClasses_ImageClass__conicGradient_Z516D4DFD(this$, angle, x, y, gradients) {
    const tupledArg = [this$.property_2, new Image_Image(10, angle, x, y, gradients)];
    return [tupledArg[0], tupledArg[1]];
}

export function ImageClasses_ImageClass__conicGradient_C015F99(this$, angle, x, y, gradients) {
    const tupledArg = [this$.property_2, new Image_Image(11, angle, x, y, gradients)];
    return [tupledArg[0], tupledArg[1]];
}

export function ImageClasses_ImageClass__repeatingConicGradient_Z516D4DFD(this$, angle, x, y, gradients) {
    const tupledArg = [this$.property_2, new Image_Image(12, angle, x, y, gradients)];
    return [tupledArg[0], tupledArg[1]];
}

export function ImageClasses_ImageClass__repeatingConicGradient_C015F99(this$, angle, x, y, gradients) {
    const tupledArg = [this$.property_2, new Image_Image(13, angle, x, y, gradients)];
    return [tupledArg[0], tupledArg[1]];
}

export class ImageClasses_ObjectFit extends CssRuleWithNone {
    constructor(property) {
        super(property);
        this.property_2 = property;
    }
}

export function ImageClasses_ObjectFit$reflection() {
    return class_type("Fss.Types.ImageClasses.ObjectFit", void 0, ImageClasses_ObjectFit, CssRuleWithNone$reflection());
}

export function ImageClasses_ObjectFit_$ctor_Z207A3CFB(property) {
    return new ImageClasses_ObjectFit(property);
}

export function ImageClasses_ObjectFit__get_fill(this$) {
    const tupledArg = [this$.property_2, new Image_ObjectFit(0)];
    return [tupledArg[0], tupledArg[1]];
}

export function ImageClasses_ObjectFit__get_contain(this$) {
    const tupledArg = [this$.property_2, new Image_ObjectFit(1)];
    return [tupledArg[0], tupledArg[1]];
}

export function ImageClasses_ObjectFit__get_cover(this$) {
    const tupledArg = [this$.property_2, new Image_ObjectFit(2)];
    return [tupledArg[0], tupledArg[1]];
}

export function ImageClasses_ObjectFit__get_scaleDown(this$) {
    const tupledArg = [this$.property_2, new Image_ObjectFit(3)];
    return [tupledArg[0], tupledArg[1]];
}

export class ImageClasses_ObjectPosition extends CssRule {
    constructor(property) {
        super(property);
        this.property_1 = property;
    }
}

export function ImageClasses_ObjectPosition$reflection() {
    return class_type("Fss.Types.ImageClasses.ObjectPosition", void 0, ImageClasses_ObjectPosition, CssRule$reflection());
}

export function ImageClasses_ObjectPosition_$ctor_Z207A3CFB(property) {
    return new ImageClasses_ObjectPosition(property);
}

export function ImageClasses_ObjectPosition__value_3202B9A0(this$, x, y) {
    const value = new String$(0, `${unitHelpers_lengthPercentageString(x)} ${unitHelpers_lengthPercentageString(y)}`);
    const tupledArg = [this$.property_1, value];
    return [tupledArg[0], tupledArg[1]];
}

export class ImageClasses_ImageRendering extends CssRuleWithAuto {
    constructor(property) {
        super(property);
        this.property_2 = property;
    }
}

export function ImageClasses_ImageRendering$reflection() {
    return class_type("Fss.Types.ImageClasses.ImageRendering", void 0, ImageClasses_ImageRendering, CssRuleWithAuto$reflection());
}

export function ImageClasses_ImageRendering_$ctor_Z207A3CFB(property) {
    return new ImageClasses_ImageRendering(property);
}

export function ImageClasses_ImageRendering__get_crispEdges(this$) {
    const tupledArg = [this$.property_2, new Image_Rendering(0)];
    return [tupledArg[0], tupledArg[1]];
}

export function ImageClasses_ImageRendering__get_pixelated(this$) {
    const tupledArg = [this$.property_2, new Image_Rendering(1)];
    return [tupledArg[0], tupledArg[1]];
}

//# sourceMappingURL=Image.fs.js.map
