import { Angle$reflection, Percent$reflection, Length$reflection, unitHelpers_lengthPercentageString } from "./Units.fs.js";
import { UrlMaster, CssRuleWithNone$reflection, CssRuleWithNone, MasterTypeHelpers_stringifyICssValue } from "./MasterTypes.fs.js";
import { join } from "../../fable-library.3.7.9/String.js";
import { map } from "../../fable-library.3.7.9/List.js";
import { Union } from "../../fable-library.3.7.9/Types.js";
import { Color_Color$reflection } from "./Color.fs.js";
import { class_type, union_type, list_type } from "../../fable-library.3.7.9/Reflection.js";

export class Filter_Filter extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["Blur", "Brightness", "Contrast", "DropShadow", "DropShadowInvert", "Grayscale", "HueRotate", "Invert", "Opacity", "Saturate", "Sepia", "Filters"];
    }
    StringifyCss() {
        const this$ = this;
        switch (this$.tag) {
            case 1: {
                const brightness = this$.fields[0];
                return `brightness(${unitHelpers_lengthPercentageString(brightness)})`;
            }
            case 2: {
                const contrast = this$.fields[0];
                return `contrast(${unitHelpers_lengthPercentageString(contrast)})`;
            }
            case 3: {
                const y = this$.fields[1];
                const x = this$.fields[0];
                const color = this$.fields[3];
                const blur_1 = this$.fields[2];
                return `drop-shadow(${unitHelpers_lengthPercentageString(x)} ${unitHelpers_lengthPercentageString(y)} ${unitHelpers_lengthPercentageString(blur_1)} ${MasterTypeHelpers_stringifyICssValue(color)})`;
            }
            case 4: {
                const y_1 = this$.fields[1];
                const x_1 = this$.fields[0];
                const invert = this$.fields[4];
                const color_1 = this$.fields[3];
                const blur_2 = this$.fields[2];
                return `drop-shadow(${unitHelpers_lengthPercentageString(x_1)} ${unitHelpers_lengthPercentageString(y_1)} ${unitHelpers_lengthPercentageString(blur_2)} ${MasterTypeHelpers_stringifyICssValue(color_1)}) invert(${unitHelpers_lengthPercentageString(invert)})`;
            }
            case 5: {
                const grayscale = this$.fields[0];
                return `grayscale(${unitHelpers_lengthPercentageString(grayscale)})`;
            }
            case 6: {
                const contrast_1 = this$.fields[0];
                return `hue-rotate(${MasterTypeHelpers_stringifyICssValue(contrast_1)})`;
            }
            case 7: {
                const invert_1 = this$.fields[0];
                return `invert(${unitHelpers_lengthPercentageString(invert_1)})`;
            }
            case 8: {
                const opacity = this$.fields[0];
                return `opacity(${unitHelpers_lengthPercentageString(opacity)})`;
            }
            case 9: {
                const saturate = this$.fields[0];
                return `saturate(${unitHelpers_lengthPercentageString(saturate)})`;
            }
            case 10: {
                const sepia = this$.fields[0];
                return `sepia(${unitHelpers_lengthPercentageString(sepia)})`;
            }
            case 11: {
                const filters = this$.fields[0];
                return join(" ", map(MasterTypeHelpers_stringifyICssValue, filters));
            }
            default: {
                const blur = this$.fields[0];
                return `blur(${unitHelpers_lengthPercentageString(blur)})`;
            }
        }
    }
}

export function Filter_Filter$reflection() {
    return union_type("Fss.Types.Filter.Filter", [], Filter_Filter, () => [[["Item", Length$reflection()]], [["Item", Percent$reflection()]], [["Item", Percent$reflection()]], [["Item1", Length$reflection()], ["Item2", Length$reflection()], ["Item3", Length$reflection()], ["Item4", Color_Color$reflection()]], [["Item1", Length$reflection()], ["Item2", Length$reflection()], ["Item3", Length$reflection()], ["Item4", Color_Color$reflection()], ["Item5", Percent$reflection()]], [["Item", Percent$reflection()]], [["Item", Angle$reflection()]], [["Item", Percent$reflection()]], [["Item", Percent$reflection()]], [["Item", Percent$reflection()]], [["Item", Percent$reflection()]], [["Item", list_type(Filter_Filter$reflection())]]]);
}

export class FilterClasses_FilterClass extends CssRuleWithNone {
    constructor(property) {
        super(property);
        this.property_2 = property;
    }
}

export function FilterClasses_FilterClass$reflection() {
    return class_type("Fss.Types.FilterClasses.FilterClass", void 0, FilterClasses_FilterClass, CssRuleWithNone$reflection());
}

export function FilterClasses_FilterClass_$ctor_Z207A3CFB(property) {
    return new FilterClasses_FilterClass(property);
}

export function FilterClasses_FilterClass__value_Z566F34B4(this$, filters) {
    const tupledArg = [this$.property_2, new Filter_Filter(11, filters)];
    return [tupledArg[0], tupledArg[1]];
}

export function FilterClasses_FilterClass__url_Z721C83C5(this$, url) {
    const tupledArg = [this$.property_2, new UrlMaster(0, url)];
    return [tupledArg[0], tupledArg[1]];
}

export function FilterClasses_FilterClass__blur_Z5C52D00C(this$, blur) {
    const tupledArg = [this$.property_2, new Filter_Filter(0, blur)];
    return [tupledArg[0], tupledArg[1]];
}

export function FilterClasses_FilterClass__brightness_2D904CD3(this$, brightness) {
    const tupledArg = [this$.property_2, new Filter_Filter(1, brightness)];
    return [tupledArg[0], tupledArg[1]];
}

export function FilterClasses_FilterClass__contrast_2D904CD3(this$, contrast) {
    const tupledArg = [this$.property_2, new Filter_Filter(2, contrast)];
    return [tupledArg[0], tupledArg[1]];
}

export function FilterClasses_FilterClass__dropShadow_Z259E9AEE(this$, x, y, blur, color) {
    const tupledArg = [this$.property_2, new Filter_Filter(3, x, y, blur, color)];
    return [tupledArg[0], tupledArg[1]];
}

export function FilterClasses_FilterClass__dropShadow_B1E4B81(this$, x, y, blur, color, invert) {
    const tupledArg = [this$.property_2, new Filter_Filter(4, x, y, blur, color, invert)];
    return [tupledArg[0], tupledArg[1]];
}

export function FilterClasses_FilterClass__grayscale_2D904CD3(this$, grayscale) {
    const tupledArg = [this$.property_2, new Filter_Filter(5, grayscale)];
    return [tupledArg[0], tupledArg[1]];
}

export function FilterClasses_FilterClass__hueRotate_CEE3389(this$, hueRotate) {
    const tupledArg = [this$.property_2, new Filter_Filter(6, hueRotate)];
    return [tupledArg[0], tupledArg[1]];
}

export function FilterClasses_FilterClass__invert_2D904CD3(this$, invert) {
    const tupledArg = [this$.property_2, new Filter_Filter(7, invert)];
    return [tupledArg[0], tupledArg[1]];
}

export function FilterClasses_FilterClass__opacity_2D904CD3(this$, opacity) {
    const tupledArg = [this$.property_2, new Filter_Filter(8, opacity)];
    return [tupledArg[0], tupledArg[1]];
}

export function FilterClasses_FilterClass__saturate_2D904CD3(this$, saturate) {
    const tupledArg = [this$.property_2, new Filter_Filter(9, saturate)];
    return [tupledArg[0], tupledArg[1]];
}

export function FilterClasses_FilterClass__sepia_2D904CD3(this$, sepia) {
    const tupledArg = [this$.property_2, new Filter_Filter(10, sepia)];
    return [tupledArg[0], tupledArg[1]];
}

//# sourceMappingURL=Filter.fs.js.map
