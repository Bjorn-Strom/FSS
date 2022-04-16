import { Union, toString } from "../../fable-library.3.7.9/Types.js";
import { class_type, union_type, string_type, float64_type, int32_type } from "../../fable-library.3.7.9/Reflection.js";
import { CssRule$reflection, CssRule } from "./MasterTypes.fs.js";

export class Color_Color extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["Black", "Silver", "Gray", "White", "Maroon", "Red", "Purple", "Fuchsia", "Green", "Lime", "Olive", "Yellow", "Navy", "Blue", "Teal", "Aqua", "Orange", "AliceBlue", "AntiqueWhite", "AquaMarine", "Azure", "Beige", "Bisque", "BlanchedAlmond", "BlueViolet", "Brown", "Burlywood", "CadetBlue", "Chartreuse", "Chocolate", "Coral", "CornflowerBlue", "Cornsilk", "Crimson", "Cyan", "DarkBlue", "DarkCyan", "DarkGoldenrod", "DarkGray", "DarkGreen", "DarkKhaki", "DarkMagenta", "DarkOliveGreen", "DarkOrange", "DarkOrchid", "DarkRed", "DarkSalmon", "DarkSeaGreen", "DarkSlateBlue", "DarkSlateGray", "DarkTurquoise", "DarkViolet", "DeepPink", "DeepSkyBlue", "DimGrey", "DodgerBlue", "FireBrick", "FloralWhite", "ForestGreen", "Gainsboro", "GhostWhite", "Gold", "Goldenrod", "GreenYellow", "Grey", "Honeydew", "HotPink", "IndianRed", "Indigo", "Ivory", "Khaki", "Lavender", "LavenderBlush", "LawnGreen", "LemonChiffon", "LightBlue", "LightCoral", "LightCyan", "LightGoldenrodYellow", "LightGray", "LightGreen", "LightGrey", "LightPink", "LightSalmon", "LightSeaGreen", "LightSkyBlue", "LightSlateGrey", "LightSteelBlue", "LightYellow", "LimeGreen", "Linen", "Magenta", "MediumAquamarine", "MediumBlue", "MediumOrchid", "MediumPurple", "MediumSeaGreen", "MediumSlateBlue", "MediumSpringGreen", "MediumTurquoise", "MediumVioletRed", "MidnightBlue", "MintCream", "MistyRose", "Moccasin", "NavajoWhite", "OldLace", "Olivedrab", "OrangeRed", "Orchid", "PaleGoldenrod", "PaleGreen", "PaleTurquoise", "PaleVioletred", "PapayaWhip", "Peachpuff", "Peru", "Pink", "Plum", "PowderBlue", "RosyBrown", "RoyalBlue", "SaddleBrown", "Salmon", "SandyBrown", "SeaGreen", "SeaShell", "Sienna", "SkyBlue", "SlateBlue", "SlateGray", "Snow", "SpringGreen", "SteelBlue", "Tan", "Thistle", "Tomato", "Turquoise", "Violet", "Wheat", "WhiteSmoke", "YellowGreen", "RebeccaPurple", "Transparent", "CurrentColor", "Rgb", "Rgba", "Hex", "Hsl", "Hsla"];
    }
    StringifyCss() {
        const this$ = this;
        switch (this$.tag) {
            case 145: {
                const red = this$.fields[0] | 0;
                const green = this$.fields[1] | 0;
                const blue = this$.fields[2] | 0;
                return `rgb(${red}, ${green}, ${blue})`;
            }
            case 146: {
                const red_1 = this$.fields[0] | 0;
                const green_1 = this$.fields[1] | 0;
                const blue_1 = this$.fields[2] | 0;
                const alpha = this$.fields[3];
                return `rgba(${red_1}, ${green_1}, ${blue_1}, ${alpha})`;
            }
            case 147: {
                const hex = this$.fields[0];
                return hex;
            }
            case 148: {
                const saturation = this$.fields[1] | 0;
                const lightness = this$.fields[2] | 0;
                const hue = this$.fields[0] | 0;
                return `hsl(${hue}, ${saturation}%, ${lightness}%)`;
            }
            case 149: {
                const saturation_1 = this$.fields[1] | 0;
                const lightness_1 = this$.fields[2] | 0;
                const hue_1 = this$.fields[0] | 0;
                const alpha_1 = this$.fields[3];
                return `hsla(${hue_1}, ${saturation_1}%, ${lightness_1}%, ${alpha_1})`;
            }
            default: {
                return toString(this$).toLocaleLowerCase();
            }
        }
    }
}

export function Color_Color$reflection() {
    return union_type("Fss.Types.Color.Color", [], Color_Color, () => [[], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [["Red", int32_type], ["Green", int32_type], ["Blue", int32_type]], [["Red", int32_type], ["Green", int32_type], ["Blue", int32_type], ["Alpha", float64_type]], [["Item", string_type]], [["Hue", int32_type], ["Saturation", int32_type], ["Lightness", int32_type]], [["Hue", int32_type], ["Saturation", int32_type], ["Lightness", int32_type], ["Alpha", float64_type]]]);
}

export class Color_ColorAdjust extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["Economy", "Exact"];
    }
    StringifyCss() {
        const this$ = this;
        return toString(this$).toLocaleLowerCase();
    }
}

export function Color_ColorAdjust$reflection() {
    return union_type("Fss.Types.Color.ColorAdjust", [], Color_ColorAdjust, () => [[], []]);
}

export function colorHelpers_hex(value) {
    return new Color_Color(147, (value.indexOf("#") === 0) ? value : (`#${value}`));
}

export class ColorClass_Color extends CssRule {
    constructor(property) {
        super(property);
        this.property_1 = property;
    }
}

export function ColorClass_Color$reflection() {
    return class_type("Fss.Types.ColorClass.Color", void 0, ColorClass_Color, CssRule$reflection());
}

export function ColorClass_Color_$ctor_Z207A3CFB(property) {
    return new ColorClass_Color(property);
}

export function ColorClass_Color__value_11789E6(this$, color) {
    const tupledArg = [this$.property_1, color];
    return [tupledArg[0], tupledArg[1]];
}

export function ColorClass_Color__get_black(this$) {
    const tupledArg = [this$.property_1, new Color_Color(0)];
    return [tupledArg[0], tupledArg[1]];
}

export function ColorClass_Color__get_silver(this$) {
    const tupledArg = [this$.property_1, new Color_Color(1)];
    return [tupledArg[0], tupledArg[1]];
}

export function ColorClass_Color__get_gray(this$) {
    const tupledArg = [this$.property_1, new Color_Color(2)];
    return [tupledArg[0], tupledArg[1]];
}

export function ColorClass_Color__get_white(this$) {
    const tupledArg = [this$.property_1, new Color_Color(3)];
    return [tupledArg[0], tupledArg[1]];
}

export function ColorClass_Color__get_maroon(this$) {
    const tupledArg = [this$.property_1, new Color_Color(4)];
    return [tupledArg[0], tupledArg[1]];
}

export function ColorClass_Color__get_red(this$) {
    const tupledArg = [this$.property_1, new Color_Color(5)];
    return [tupledArg[0], tupledArg[1]];
}

export function ColorClass_Color__get_purple(this$) {
    const tupledArg = [this$.property_1, new Color_Color(6)];
    return [tupledArg[0], tupledArg[1]];
}

export function ColorClass_Color__get_fuchsia(this$) {
    const tupledArg = [this$.property_1, new Color_Color(7)];
    return [tupledArg[0], tupledArg[1]];
}

export function ColorClass_Color__get_green(this$) {
    const tupledArg = [this$.property_1, new Color_Color(8)];
    return [tupledArg[0], tupledArg[1]];
}

export function ColorClass_Color__get_lime(this$) {
    const tupledArg = [this$.property_1, new Color_Color(9)];
    return [tupledArg[0], tupledArg[1]];
}

export function ColorClass_Color__get_olive(this$) {
    const tupledArg = [this$.property_1, new Color_Color(10)];
    return [tupledArg[0], tupledArg[1]];
}

export function ColorClass_Color__get_yellow(this$) {
    const tupledArg = [this$.property_1, new Color_Color(11)];
    return [tupledArg[0], tupledArg[1]];
}

export function ColorClass_Color__get_navy(this$) {
    const tupledArg = [this$.property_1, new Color_Color(12)];
    return [tupledArg[0], tupledArg[1]];
}

export function ColorClass_Color__get_blue(this$) {
    const tupledArg = [this$.property_1, new Color_Color(13)];
    return [tupledArg[0], tupledArg[1]];
}

export function ColorClass_Color__get_teal(this$) {
    const tupledArg = [this$.property_1, new Color_Color(14)];
    return [tupledArg[0], tupledArg[1]];
}

export function ColorClass_Color__get_aqua(this$) {
    const tupledArg = [this$.property_1, new Color_Color(15)];
    return [tupledArg[0], tupledArg[1]];
}

export function ColorClass_Color__get_orange(this$) {
    const tupledArg = [this$.property_1, new Color_Color(16)];
    return [tupledArg[0], tupledArg[1]];
}

export function ColorClass_Color__get_aliceBlue(this$) {
    const tupledArg = [this$.property_1, new Color_Color(17)];
    return [tupledArg[0], tupledArg[1]];
}

export function ColorClass_Color__get_antiqueWhite(this$) {
    const tupledArg = [this$.property_1, new Color_Color(18)];
    return [tupledArg[0], tupledArg[1]];
}

export function ColorClass_Color__get_aquaMarine(this$) {
    const tupledArg = [this$.property_1, new Color_Color(19)];
    return [tupledArg[0], tupledArg[1]];
}

export function ColorClass_Color__get_azure(this$) {
    const tupledArg = [this$.property_1, new Color_Color(20)];
    return [tupledArg[0], tupledArg[1]];
}

export function ColorClass_Color__get_beige(this$) {
    const tupledArg = [this$.property_1, new Color_Color(21)];
    return [tupledArg[0], tupledArg[1]];
}

export function ColorClass_Color__get_bisque(this$) {
    const tupledArg = [this$.property_1, new Color_Color(22)];
    return [tupledArg[0], tupledArg[1]];
}

export function ColorClass_Color__get_blanchedAlmond(this$) {
    const tupledArg = [this$.property_1, new Color_Color(23)];
    return [tupledArg[0], tupledArg[1]];
}

export function ColorClass_Color__get_blueViolet(this$) {
    const tupledArg = [this$.property_1, new Color_Color(24)];
    return [tupledArg[0], tupledArg[1]];
}

export function ColorClass_Color__get_brown(this$) {
    const tupledArg = [this$.property_1, new Color_Color(25)];
    return [tupledArg[0], tupledArg[1]];
}

export function ColorClass_Color__get_burlywood(this$) {
    const tupledArg = [this$.property_1, new Color_Color(26)];
    return [tupledArg[0], tupledArg[1]];
}

export function ColorClass_Color__get_cadetBlue(this$) {
    const tupledArg = [this$.property_1, new Color_Color(27)];
    return [tupledArg[0], tupledArg[1]];
}

export function ColorClass_Color__get_chartreuse(this$) {
    const tupledArg = [this$.property_1, new Color_Color(28)];
    return [tupledArg[0], tupledArg[1]];
}

export function ColorClass_Color__get_chocolate(this$) {
    const tupledArg = [this$.property_1, new Color_Color(29)];
    return [tupledArg[0], tupledArg[1]];
}

export function ColorClass_Color__get_coral(this$) {
    const tupledArg = [this$.property_1, new Color_Color(30)];
    return [tupledArg[0], tupledArg[1]];
}

export function ColorClass_Color__get_cornflowerBlue(this$) {
    const tupledArg = [this$.property_1, new Color_Color(31)];
    return [tupledArg[0], tupledArg[1]];
}

export function ColorClass_Color__get_cornsilk(this$) {
    const tupledArg = [this$.property_1, new Color_Color(32)];
    return [tupledArg[0], tupledArg[1]];
}

export function ColorClass_Color__get_crimson(this$) {
    const tupledArg = [this$.property_1, new Color_Color(33)];
    return [tupledArg[0], tupledArg[1]];
}

export function ColorClass_Color__get_cyan(this$) {
    const tupledArg = [this$.property_1, new Color_Color(34)];
    return [tupledArg[0], tupledArg[1]];
}

export function ColorClass_Color__get_darkBlue(this$) {
    const tupledArg = [this$.property_1, new Color_Color(35)];
    return [tupledArg[0], tupledArg[1]];
}

export function ColorClass_Color__get_darkCyan(this$) {
    const tupledArg = [this$.property_1, new Color_Color(36)];
    return [tupledArg[0], tupledArg[1]];
}

export function ColorClass_Color__get_darkGoldenrod(this$) {
    const tupledArg = [this$.property_1, new Color_Color(37)];
    return [tupledArg[0], tupledArg[1]];
}

export function ColorClass_Color__get_darkGray(this$) {
    const tupledArg = [this$.property_1, new Color_Color(38)];
    return [tupledArg[0], tupledArg[1]];
}

export function ColorClass_Color__get_darkGreen(this$) {
    const tupledArg = [this$.property_1, new Color_Color(39)];
    return [tupledArg[0], tupledArg[1]];
}

export function ColorClass_Color__get_darkKhaki(this$) {
    const tupledArg = [this$.property_1, new Color_Color(40)];
    return [tupledArg[0], tupledArg[1]];
}

export function ColorClass_Color__get_darkMagenta(this$) {
    const tupledArg = [this$.property_1, new Color_Color(41)];
    return [tupledArg[0], tupledArg[1]];
}

export function ColorClass_Color__get_darkOliveGreen(this$) {
    const tupledArg = [this$.property_1, new Color_Color(42)];
    return [tupledArg[0], tupledArg[1]];
}

export function ColorClass_Color__get_darkOrange(this$) {
    const tupledArg = [this$.property_1, new Color_Color(43)];
    return [tupledArg[0], tupledArg[1]];
}

export function ColorClass_Color__get_darkOrchid(this$) {
    const tupledArg = [this$.property_1, new Color_Color(44)];
    return [tupledArg[0], tupledArg[1]];
}

export function ColorClass_Color__get_darkRed(this$) {
    const tupledArg = [this$.property_1, new Color_Color(45)];
    return [tupledArg[0], tupledArg[1]];
}

export function ColorClass_Color__get_darkSalmon(this$) {
    const tupledArg = [this$.property_1, new Color_Color(46)];
    return [tupledArg[0], tupledArg[1]];
}

export function ColorClass_Color__get_darkSeaGreen(this$) {
    const tupledArg = [this$.property_1, new Color_Color(47)];
    return [tupledArg[0], tupledArg[1]];
}

export function ColorClass_Color__get_darkSlateBlue(this$) {
    const tupledArg = [this$.property_1, new Color_Color(48)];
    return [tupledArg[0], tupledArg[1]];
}

export function ColorClass_Color__get_darkSlateGray(this$) {
    const tupledArg = [this$.property_1, new Color_Color(49)];
    return [tupledArg[0], tupledArg[1]];
}

export function ColorClass_Color__get_darkTurquoise(this$) {
    const tupledArg = [this$.property_1, new Color_Color(50)];
    return [tupledArg[0], tupledArg[1]];
}

export function ColorClass_Color__get_darkViolet(this$) {
    const tupledArg = [this$.property_1, new Color_Color(51)];
    return [tupledArg[0], tupledArg[1]];
}

export function ColorClass_Color__get_deepPink(this$) {
    const tupledArg = [this$.property_1, new Color_Color(52)];
    return [tupledArg[0], tupledArg[1]];
}

export function ColorClass_Color__get_deepSkyBlue(this$) {
    const tupledArg = [this$.property_1, new Color_Color(53)];
    return [tupledArg[0], tupledArg[1]];
}

export function ColorClass_Color__get_dimGrey(this$) {
    const tupledArg = [this$.property_1, new Color_Color(54)];
    return [tupledArg[0], tupledArg[1]];
}

export function ColorClass_Color__get_dodgerBlue(this$) {
    const tupledArg = [this$.property_1, new Color_Color(55)];
    return [tupledArg[0], tupledArg[1]];
}

export function ColorClass_Color__get_fireBrick(this$) {
    const tupledArg = [this$.property_1, new Color_Color(56)];
    return [tupledArg[0], tupledArg[1]];
}

export function ColorClass_Color__get_floralWhite(this$) {
    const tupledArg = [this$.property_1, new Color_Color(57)];
    return [tupledArg[0], tupledArg[1]];
}

export function ColorClass_Color__get_forestGreen(this$) {
    const tupledArg = [this$.property_1, new Color_Color(58)];
    return [tupledArg[0], tupledArg[1]];
}

export function ColorClass_Color__get_gainsboro(this$) {
    const tupledArg = [this$.property_1, new Color_Color(59)];
    return [tupledArg[0], tupledArg[1]];
}

export function ColorClass_Color__get_ghostWhite(this$) {
    const tupledArg = [this$.property_1, new Color_Color(60)];
    return [tupledArg[0], tupledArg[1]];
}

export function ColorClass_Color__get_gold(this$) {
    const tupledArg = [this$.property_1, new Color_Color(61)];
    return [tupledArg[0], tupledArg[1]];
}

export function ColorClass_Color__get_goldenrod(this$) {
    const tupledArg = [this$.property_1, new Color_Color(62)];
    return [tupledArg[0], tupledArg[1]];
}

export function ColorClass_Color__get_greenYellow(this$) {
    const tupledArg = [this$.property_1, new Color_Color(63)];
    return [tupledArg[0], tupledArg[1]];
}

export function ColorClass_Color__get_grey(this$) {
    const tupledArg = [this$.property_1, new Color_Color(64)];
    return [tupledArg[0], tupledArg[1]];
}

export function ColorClass_Color__get_honeydew(this$) {
    const tupledArg = [this$.property_1, new Color_Color(65)];
    return [tupledArg[0], tupledArg[1]];
}

export function ColorClass_Color__get_hotPink(this$) {
    const tupledArg = [this$.property_1, new Color_Color(66)];
    return [tupledArg[0], tupledArg[1]];
}

export function ColorClass_Color__get_indianRed(this$) {
    const tupledArg = [this$.property_1, new Color_Color(67)];
    return [tupledArg[0], tupledArg[1]];
}

export function ColorClass_Color__get_indigo(this$) {
    const tupledArg = [this$.property_1, new Color_Color(68)];
    return [tupledArg[0], tupledArg[1]];
}

export function ColorClass_Color__get_ivory(this$) {
    const tupledArg = [this$.property_1, new Color_Color(69)];
    return [tupledArg[0], tupledArg[1]];
}

export function ColorClass_Color__get_khaki(this$) {
    const tupledArg = [this$.property_1, new Color_Color(70)];
    return [tupledArg[0], tupledArg[1]];
}

export function ColorClass_Color__get_lavender(this$) {
    const tupledArg = [this$.property_1, new Color_Color(71)];
    return [tupledArg[0], tupledArg[1]];
}

export function ColorClass_Color__get_lavenderBlush(this$) {
    const tupledArg = [this$.property_1, new Color_Color(72)];
    return [tupledArg[0], tupledArg[1]];
}

export function ColorClass_Color__get_lawnGreen(this$) {
    const tupledArg = [this$.property_1, new Color_Color(73)];
    return [tupledArg[0], tupledArg[1]];
}

export function ColorClass_Color__get_lemonChiffon(this$) {
    const tupledArg = [this$.property_1, new Color_Color(74)];
    return [tupledArg[0], tupledArg[1]];
}

export function ColorClass_Color__get_lightBlue(this$) {
    const tupledArg = [this$.property_1, new Color_Color(75)];
    return [tupledArg[0], tupledArg[1]];
}

export function ColorClass_Color__get_lightCoral(this$) {
    const tupledArg = [this$.property_1, new Color_Color(76)];
    return [tupledArg[0], tupledArg[1]];
}

export function ColorClass_Color__get_lightCyan(this$) {
    const tupledArg = [this$.property_1, new Color_Color(77)];
    return [tupledArg[0], tupledArg[1]];
}

export function ColorClass_Color__get_lightGoldenrodYellow(this$) {
    const tupledArg = [this$.property_1, new Color_Color(78)];
    return [tupledArg[0], tupledArg[1]];
}

export function ColorClass_Color__get_lightGray(this$) {
    const tupledArg = [this$.property_1, new Color_Color(79)];
    return [tupledArg[0], tupledArg[1]];
}

export function ColorClass_Color__get_lightGreen(this$) {
    const tupledArg = [this$.property_1, new Color_Color(80)];
    return [tupledArg[0], tupledArg[1]];
}

export function ColorClass_Color__get_lightGrey(this$) {
    const tupledArg = [this$.property_1, new Color_Color(81)];
    return [tupledArg[0], tupledArg[1]];
}

export function ColorClass_Color__get_lightPink(this$) {
    const tupledArg = [this$.property_1, new Color_Color(82)];
    return [tupledArg[0], tupledArg[1]];
}

export function ColorClass_Color__get_lightSalmon(this$) {
    const tupledArg = [this$.property_1, new Color_Color(83)];
    return [tupledArg[0], tupledArg[1]];
}

export function ColorClass_Color__get_lightSeaGreen(this$) {
    const tupledArg = [this$.property_1, new Color_Color(84)];
    return [tupledArg[0], tupledArg[1]];
}

export function ColorClass_Color__get_lightSkyBlue(this$) {
    const tupledArg = [this$.property_1, new Color_Color(85)];
    return [tupledArg[0], tupledArg[1]];
}

export function ColorClass_Color__get_lightSlateGrey(this$) {
    const tupledArg = [this$.property_1, new Color_Color(86)];
    return [tupledArg[0], tupledArg[1]];
}

export function ColorClass_Color__get_lightSteelBlue(this$) {
    const tupledArg = [this$.property_1, new Color_Color(87)];
    return [tupledArg[0], tupledArg[1]];
}

export function ColorClass_Color__get_lightYellow(this$) {
    const tupledArg = [this$.property_1, new Color_Color(88)];
    return [tupledArg[0], tupledArg[1]];
}

export function ColorClass_Color__get_limeGreen(this$) {
    const tupledArg = [this$.property_1, new Color_Color(89)];
    return [tupledArg[0], tupledArg[1]];
}

export function ColorClass_Color__get_linen(this$) {
    const tupledArg = [this$.property_1, new Color_Color(90)];
    return [tupledArg[0], tupledArg[1]];
}

export function ColorClass_Color__get_magenta(this$) {
    const tupledArg = [this$.property_1, new Color_Color(91)];
    return [tupledArg[0], tupledArg[1]];
}

export function ColorClass_Color__get_mediumAquamarine(this$) {
    const tupledArg = [this$.property_1, new Color_Color(92)];
    return [tupledArg[0], tupledArg[1]];
}

export function ColorClass_Color__get_mediumBlue(this$) {
    const tupledArg = [this$.property_1, new Color_Color(93)];
    return [tupledArg[0], tupledArg[1]];
}

export function ColorClass_Color__get_mediumOrchid(this$) {
    const tupledArg = [this$.property_1, new Color_Color(94)];
    return [tupledArg[0], tupledArg[1]];
}

export function ColorClass_Color__get_mediumPurple(this$) {
    const tupledArg = [this$.property_1, new Color_Color(95)];
    return [tupledArg[0], tupledArg[1]];
}

export function ColorClass_Color__get_mediumSeaGreen(this$) {
    const tupledArg = [this$.property_1, new Color_Color(96)];
    return [tupledArg[0], tupledArg[1]];
}

export function ColorClass_Color__get_mediumSlateBlue(this$) {
    const tupledArg = [this$.property_1, new Color_Color(97)];
    return [tupledArg[0], tupledArg[1]];
}

export function ColorClass_Color__get_mediumSpringGreen(this$) {
    const tupledArg = [this$.property_1, new Color_Color(98)];
    return [tupledArg[0], tupledArg[1]];
}

export function ColorClass_Color__get_mediumTurquoise(this$) {
    const tupledArg = [this$.property_1, new Color_Color(99)];
    return [tupledArg[0], tupledArg[1]];
}

export function ColorClass_Color__get_mediumVioletRed(this$) {
    const tupledArg = [this$.property_1, new Color_Color(100)];
    return [tupledArg[0], tupledArg[1]];
}

export function ColorClass_Color__get_midnightBlue(this$) {
    const tupledArg = [this$.property_1, new Color_Color(101)];
    return [tupledArg[0], tupledArg[1]];
}

export function ColorClass_Color__get_mintCream(this$) {
    const tupledArg = [this$.property_1, new Color_Color(102)];
    return [tupledArg[0], tupledArg[1]];
}

export function ColorClass_Color__get_mistyRose(this$) {
    const tupledArg = [this$.property_1, new Color_Color(103)];
    return [tupledArg[0], tupledArg[1]];
}

export function ColorClass_Color__get_moccasin(this$) {
    const tupledArg = [this$.property_1, new Color_Color(104)];
    return [tupledArg[0], tupledArg[1]];
}

export function ColorClass_Color__get_navajoWhite(this$) {
    const tupledArg = [this$.property_1, new Color_Color(105)];
    return [tupledArg[0], tupledArg[1]];
}

export function ColorClass_Color__get_oldLace(this$) {
    const tupledArg = [this$.property_1, new Color_Color(106)];
    return [tupledArg[0], tupledArg[1]];
}

export function ColorClass_Color__get_olivedrab(this$) {
    const tupledArg = [this$.property_1, new Color_Color(107)];
    return [tupledArg[0], tupledArg[1]];
}

export function ColorClass_Color__get_orangeRed(this$) {
    const tupledArg = [this$.property_1, new Color_Color(108)];
    return [tupledArg[0], tupledArg[1]];
}

export function ColorClass_Color__get_orchid(this$) {
    const tupledArg = [this$.property_1, new Color_Color(109)];
    return [tupledArg[0], tupledArg[1]];
}

export function ColorClass_Color__get_paleGoldenrod(this$) {
    const tupledArg = [this$.property_1, new Color_Color(110)];
    return [tupledArg[0], tupledArg[1]];
}

export function ColorClass_Color__get_paleGreen(this$) {
    const tupledArg = [this$.property_1, new Color_Color(111)];
    return [tupledArg[0], tupledArg[1]];
}

export function ColorClass_Color__get_paleTurquoise(this$) {
    const tupledArg = [this$.property_1, new Color_Color(112)];
    return [tupledArg[0], tupledArg[1]];
}

export function ColorClass_Color__get_paleVioletred(this$) {
    const tupledArg = [this$.property_1, new Color_Color(113)];
    return [tupledArg[0], tupledArg[1]];
}

export function ColorClass_Color__get_papayaWhip(this$) {
    const tupledArg = [this$.property_1, new Color_Color(114)];
    return [tupledArg[0], tupledArg[1]];
}

export function ColorClass_Color__get_peachpuff(this$) {
    const tupledArg = [this$.property_1, new Color_Color(115)];
    return [tupledArg[0], tupledArg[1]];
}

export function ColorClass_Color__get_peru(this$) {
    const tupledArg = [this$.property_1, new Color_Color(116)];
    return [tupledArg[0], tupledArg[1]];
}

export function ColorClass_Color__get_pink(this$) {
    const tupledArg = [this$.property_1, new Color_Color(117)];
    return [tupledArg[0], tupledArg[1]];
}

export function ColorClass_Color__get_plum(this$) {
    const tupledArg = [this$.property_1, new Color_Color(118)];
    return [tupledArg[0], tupledArg[1]];
}

export function ColorClass_Color__get_powderBlue(this$) {
    const tupledArg = [this$.property_1, new Color_Color(119)];
    return [tupledArg[0], tupledArg[1]];
}

export function ColorClass_Color__get_rosyBrown(this$) {
    const tupledArg = [this$.property_1, new Color_Color(120)];
    return [tupledArg[0], tupledArg[1]];
}

export function ColorClass_Color__get_royalBlue(this$) {
    const tupledArg = [this$.property_1, new Color_Color(121)];
    return [tupledArg[0], tupledArg[1]];
}

export function ColorClass_Color__get_saddleBrown(this$) {
    const tupledArg = [this$.property_1, new Color_Color(122)];
    return [tupledArg[0], tupledArg[1]];
}

export function ColorClass_Color__get_salmon(this$) {
    const tupledArg = [this$.property_1, new Color_Color(123)];
    return [tupledArg[0], tupledArg[1]];
}

export function ColorClass_Color__get_sandyBrown(this$) {
    const tupledArg = [this$.property_1, new Color_Color(124)];
    return [tupledArg[0], tupledArg[1]];
}

export function ColorClass_Color__get_seaGreen(this$) {
    const tupledArg = [this$.property_1, new Color_Color(125)];
    return [tupledArg[0], tupledArg[1]];
}

export function ColorClass_Color__get_seaShell(this$) {
    const tupledArg = [this$.property_1, new Color_Color(126)];
    return [tupledArg[0], tupledArg[1]];
}

export function ColorClass_Color__get_sienna(this$) {
    const tupledArg = [this$.property_1, new Color_Color(127)];
    return [tupledArg[0], tupledArg[1]];
}

export function ColorClass_Color__get_skyBlue(this$) {
    const tupledArg = [this$.property_1, new Color_Color(128)];
    return [tupledArg[0], tupledArg[1]];
}

export function ColorClass_Color__get_slateBlue(this$) {
    const tupledArg = [this$.property_1, new Color_Color(129)];
    return [tupledArg[0], tupledArg[1]];
}

export function ColorClass_Color__get_slateGray(this$) {
    const tupledArg = [this$.property_1, new Color_Color(130)];
    return [tupledArg[0], tupledArg[1]];
}

export function ColorClass_Color__get_snow(this$) {
    const tupledArg = [this$.property_1, new Color_Color(131)];
    return [tupledArg[0], tupledArg[1]];
}

export function ColorClass_Color__get_springGreen(this$) {
    const tupledArg = [this$.property_1, new Color_Color(132)];
    return [tupledArg[0], tupledArg[1]];
}

export function ColorClass_Color__get_steelBlue(this$) {
    const tupledArg = [this$.property_1, new Color_Color(133)];
    return [tupledArg[0], tupledArg[1]];
}

export function ColorClass_Color__get_tan(this$) {
    const tupledArg = [this$.property_1, new Color_Color(134)];
    return [tupledArg[0], tupledArg[1]];
}

export function ColorClass_Color__get_thistle(this$) {
    const tupledArg = [this$.property_1, new Color_Color(135)];
    return [tupledArg[0], tupledArg[1]];
}

export function ColorClass_Color__get_tomato(this$) {
    const tupledArg = [this$.property_1, new Color_Color(136)];
    return [tupledArg[0], tupledArg[1]];
}

export function ColorClass_Color__get_turquoise(this$) {
    const tupledArg = [this$.property_1, new Color_Color(137)];
    return [tupledArg[0], tupledArg[1]];
}

export function ColorClass_Color__get_violet(this$) {
    const tupledArg = [this$.property_1, new Color_Color(138)];
    return [tupledArg[0], tupledArg[1]];
}

export function ColorClass_Color__get_wheat(this$) {
    const tupledArg = [this$.property_1, new Color_Color(139)];
    return [tupledArg[0], tupledArg[1]];
}

export function ColorClass_Color__get_whiteSmoke(this$) {
    const tupledArg = [this$.property_1, new Color_Color(140)];
    return [tupledArg[0], tupledArg[1]];
}

export function ColorClass_Color__get_yellowGreen(this$) {
    const tupledArg = [this$.property_1, new Color_Color(141)];
    return [tupledArg[0], tupledArg[1]];
}

export function ColorClass_Color__get_rebeccaPurple(this$) {
    const tupledArg = [this$.property_1, new Color_Color(142)];
    return [tupledArg[0], tupledArg[1]];
}

export function ColorClass_Color__get_transparent(this$) {
    const tupledArg = [this$.property_1, new Color_Color(143)];
    return [tupledArg[0], tupledArg[1]];
}

export function ColorClass_Color__get_currentColor(this$) {
    const tupledArg = [this$.property_1, new Color_Color(144)];
    return [tupledArg[0], tupledArg[1]];
}

export function ColorClass_Color__rgb(this$, red, green, blue) {
    const tupledArg = [this$.property_1, new Color_Color(145, red, green, blue)];
    return [tupledArg[0], tupledArg[1]];
}

export function ColorClass_Color__rgba(this$, red, green, blue, alpha) {
    const tupledArg = [this$.property_1, new Color_Color(146, red, green, blue, alpha)];
    return [tupledArg[0], tupledArg[1]];
}

export function ColorClass_Color__hex_Z721C83C5(this$, value) {
    const tupledArg = [this$.property_1, colorHelpers_hex(value)];
    return [tupledArg[0], tupledArg[1]];
}

export function ColorClass_Color__hsl(this$, hue, saturation, lightness) {
    const tupledArg = [this$.property_1, new Color_Color(148, hue, saturation, lightness)];
    return [tupledArg[0], tupledArg[1]];
}

export function ColorClass_Color__hsla(this$, hue, saturation, lightness, alpha) {
    const tupledArg = [this$.property_1, new Color_Color(149, hue, saturation, lightness, alpha)];
    return [tupledArg[0], tupledArg[1]];
}

export class ColorClass_ColorAdjust extends CssRule {
    constructor(property) {
        super(property);
        this.property_1 = property;
    }
}

export function ColorClass_ColorAdjust$reflection() {
    return class_type("Fss.Types.ColorClass.ColorAdjust", void 0, ColorClass_ColorAdjust, CssRule$reflection());
}

export function ColorClass_ColorAdjust_$ctor_Z207A3CFB(property) {
    return new ColorClass_ColorAdjust(property);
}

export function ColorClass_ColorAdjust__value_Z21057965(this$, adjust) {
    const tupledArg = [this$.property_1, adjust];
    return [tupledArg[0], tupledArg[1]];
}

export function ColorClass_ColorAdjust__get_exact(this$) {
    const tupledArg = [this$.property_1, new Color_ColorAdjust(1)];
    return [tupledArg[0], tupledArg[1]];
}

export function ColorClass_ColorAdjust__get_economy(this$) {
    const tupledArg = [this$.property_1, new Color_ColorAdjust(0)];
    return [tupledArg[0], tupledArg[1]];
}

//# sourceMappingURL=Color.fs.js.map
