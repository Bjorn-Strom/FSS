import { Property_CssProperty, Property_CssProperty$reflection, MasterTypeHelpers_stringifyICssValue } from "./MasterTypes.fs.js";
import { Union, toString } from "../../fable-library.3.7.9/Types.js";
import { tuple_type, class_type, list_type, int32_type, bool_type, union_type } from "../../fable-library.3.7.9/Reflection.js";
import { Helpers_toKebabCase } from "../Utilities.fs.js";
import { Resolution$reflection, Length$reflection, unitHelpers_lengthPercentageString } from "./Units.fs.js";

export class Media_Device extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["Screen", "Speech", "Print", "All", "Not", "Only"];
    }
    StringifyCss() {
        const this$ = this;
        switch (this$.tag) {
            case 4: {
                const d = this$.fields[0];
                return `not ${MasterTypeHelpers_stringifyICssValue(d)}`;
            }
            case 5: {
                const d_1 = this$.fields[0];
                return `only ${MasterTypeHelpers_stringifyICssValue(d_1)}`;
            }
            default: {
                return toString(this$).toLocaleLowerCase();
            }
        }
    }
}

export function Media_Device$reflection() {
    return union_type("Fss.Types.Media.Device", [], Media_Device, () => [[], [], [], [], [["Item", Media_Device$reflection()]], [["Item", Media_Device$reflection()]]]);
}

export class Media_Pointer extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["Course", "Fine", "None"];
    }
}

export function Media_Pointer$reflection() {
    return union_type("Fss.Types.Media.Pointer", [], Media_Pointer, () => [[], [], []]);
}

export class Media_ColorGamut extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["SRGB", "P3", "REC2020"];
    }
}

export function Media_ColorGamut$reflection() {
    return union_type("Fss.Types.Media.ColorGamut", [], Media_ColorGamut, () => [[], [], []]);
}

export class Media_DisplayMode extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["Fullscreen", "Standalone", "MinimalUi", "Browser"];
    }
    toString() {
        const this$ = this;
        return Helpers_toKebabCase(this$);
    }
}

export function Media_DisplayMode$reflection() {
    return union_type("Fss.Types.Media.DisplayMode", [], Media_DisplayMode, () => [[], [], [], []]);
}

export class Media_LightLevel extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["Dim", "Washed"];
    }
}

export function Media_LightLevel$reflection() {
    return union_type("Fss.Types.Media.LightLevel", [], Media_LightLevel, () => [[], []]);
}

export class Media_Orientation extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["Landscape", "Portrait"];
    }
}

export function Media_Orientation$reflection() {
    return union_type("Fss.Types.Media.Orientation", [], Media_Orientation, () => [[], []]);
}

export class Media_OverflowBlock extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["None", "Scrolled", "OptionalPaged", "Paged"];
    }
}

export function Media_OverflowBlock$reflection() {
    return union_type("Fss.Types.Media.OverflowBlock", [], Media_OverflowBlock, () => [[], [], [], []]);
}

export class Media_ColorScheme extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["Light", "Dark"];
    }
}

export function Media_ColorScheme$reflection() {
    return union_type("Fss.Types.Media.ColorScheme", [], Media_ColorScheme, () => [[], []]);
}

export class Media_Contrast extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["NoPreference", "High", "Low"];
    }
}

export function Media_Contrast$reflection() {
    return union_type("Fss.Types.Media.Contrast", [], Media_Contrast, () => [[], [], []]);
}

export class Media_Scan extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["Interlace", "Progressive"];
    }
}

export function Media_Scan$reflection() {
    return union_type("Fss.Types.Media.Scan", [], Media_Scan, () => [[], []]);
}

export class Media_Scripting extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["None", "InitialOnly", "Enabled"];
    }
}

export function Media_Scripting$reflection() {
    return union_type("Fss.Types.Media.Scripting", [], Media_Scripting, () => [[], [], []]);
}

export class Media_Update extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["None", "Slow", "Fast"];
    }
}

export function Media_Update$reflection() {
    return union_type("Fss.Types.Media.Update", [], Media_Update, () => [[], [], []]);
}

export class Media_Feature extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["AnyHover", "AnyPointer", "AspectRatio", "MinAspectRatio", "MaxAspectRatio", "Color", "MinColor", "MaxColor", "ColorGamut", "ColorIndex", "MinColorIndex", "MaxColorIndex", "DisplayMode", "ForcedColors", "Grid", "Height", "MinHeight", "MaxHeight", "Width", "MinWidth", "MaxWidth", "Hover", "InvertedColors", "LightLevel", "Monochrome", "MinMonochrome", "MaxMonochrome", "Orientation", "OverflowBlock", "OverflowInline", "Pointer", "PrefersColorScheme", "PrefersContrast", "PrefersReducedMotion", "PrefersReducedTransparency", "Resolution", "MinResolution", "MaxResolution", "Scan", "Scripting", "Update"];
    }
    toString() {
        const this$ = this;
        switch (this$.tag) {
            case 1: {
                const pointer = this$.fields[0];
                return `any-pointer: ${toString(pointer).toLocaleLowerCase()}`;
            }
            case 2: {
                const y = this$.fields[1] | 0;
                const x = this$.fields[0] | 0;
                return `aspect-ratio: ${x}/${y}`;
            }
            case 3: {
                const y_1 = this$.fields[1] | 0;
                const x_1 = this$.fields[0] | 0;
                return `min-aspect-ratio: ${x_1}/${y_1}`;
            }
            case 4: {
                const y_2 = this$.fields[1] | 0;
                const x_2 = this$.fields[0] | 0;
                return `max-aspect-ratio ${x_2}/${y_2}`;
            }
            case 5: {
                return "color";
            }
            case 6: {
                const int = this$.fields[0] | 0;
                return `min-color: ${int}`;
            }
            case 7: {
                const int_1 = this$.fields[0] | 0;
                return `max-color: ${int_1}`;
            }
            case 8: {
                const colorGamut = this$.fields[0];
                return `color-gamut: ${toString(colorGamut)}`;
            }
            case 9: {
                const int_2 = this$.fields[0] | 0;
                return `color-index: ${int_2}`;
            }
            case 10: {
                const int_3 = this$.fields[0] | 0;
                return `min-color-index: ${int_3}`;
            }
            case 11: {
                const int_4 = this$.fields[0] | 0;
                return `max-color-index: ${int_4}`;
            }
            case 12: {
                const displayMode = this$.fields[0];
                return `display-mode: ${displayMode}`;
            }
            case 13: {
                const bool_1 = this$.fields[0];
                return `forced-colors: ${bool_1}`;
            }
            case 14: {
                const bool_2 = this$.fields[0];
                return `grid: ${toString(bool_2).toLocaleLowerCase()}`;
            }
            case 15: {
                const length = this$.fields[0];
                return `height: ${unitHelpers_lengthPercentageString(length)}`;
            }
            case 16: {
                const length_1 = this$.fields[0];
                return `min-height: ${unitHelpers_lengthPercentageString(length_1)}`;
            }
            case 17: {
                const length_2 = this$.fields[0];
                return `max-height: ${unitHelpers_lengthPercentageString(length_2)}`;
            }
            case 18: {
                const length_3 = this$.fields[0];
                return `width: ${unitHelpers_lengthPercentageString(length_3)}`;
            }
            case 19: {
                const length_4 = this$.fields[0];
                return `min-width: ${unitHelpers_lengthPercentageString(length_4)}`;
            }
            case 20: {
                const length_5 = this$.fields[0];
                return `max-width: ${unitHelpers_lengthPercentageString(length_5)}`;
            }
            case 21: {
                const bool_3 = this$.fields[0];
                return `hover: ${bool_3}`;
            }
            case 22: {
                const bool_4 = this$.fields[0];
                return `inverted-colors: ${bool_4}`;
            }
            case 23: {
                const lightLevel = this$.fields[0];
                return `light-level: ${toString(lightLevel).toLocaleLowerCase()}`;
            }
            case 24: {
                const int_5 = this$.fields[0] | 0;
                return `monochrome: ${int_5}`;
            }
            case 25: {
                const int_6 = this$.fields[0] | 0;
                return `min-monochrome: ${int_6}`;
            }
            case 26: {
                const int_7 = this$.fields[0] | 0;
                return `max-monochrome: ${int_7}`;
            }
            case 27: {
                const orientation = this$.fields[0];
                return `orientation: ${toString(orientation).toLocaleLowerCase()}`;
            }
            case 28: {
                const overflowBlock = this$.fields[0];
                return `overflow-block: ${Helpers_toKebabCase(overflowBlock)}`;
            }
            case 29: {
                const bool_5 = this$.fields[0];
                return `overflow-inline: ${bool_5}`;
            }
            case 30: {
                const pointer_1 = this$.fields[0];
                return `pointer: ${toString(pointer_1).toLocaleLowerCase()}`;
            }
            case 31: {
                const colorScheme = this$.fields[0];
                return `preferred-color-scheme: ${toString(colorScheme).toLocaleLowerCase()}`;
            }
            case 32: {
                const contrast = this$.fields[0];
                return `contrast: ${Helpers_toKebabCase(contrast)}`;
            }
            case 33: {
                const bool_6 = this$.fields[0];
                return `prefers-reduced-motion: ${bool_6}`;
            }
            case 34: {
                const bool_7 = this$.fields[0];
                return `prefers-reduced-transparency: ${bool_7}`;
            }
            case 35: {
                const resolution = this$.fields[0];
                return `resolution: ${MasterTypeHelpers_stringifyICssValue(resolution)}`;
            }
            case 36: {
                const resolution_1 = this$.fields[0];
                return `min-resolution: ${MasterTypeHelpers_stringifyICssValue(resolution_1)}`;
            }
            case 37: {
                const resolution_2 = this$.fields[0];
                return `max-resolution: ${MasterTypeHelpers_stringifyICssValue(resolution_2)}`;
            }
            case 38: {
                const scan = this$.fields[0];
                return `scan: ${toString(scan).toLocaleLowerCase()}`;
            }
            case 39: {
                const scripting = this$.fields[0];
                return `scripting: ${Helpers_toKebabCase(scripting)}`;
            }
            case 40: {
                const update = this$.fields[0];
                return `update: ${toString(update).toLocaleLowerCase()}`;
            }
            default: {
                const bool = this$.fields[0];
                return `any-hover: ${bool}`;
            }
        }
    }
}

export function Media_Feature$reflection() {
    return union_type("Fss.Types.Media.Feature", [], Media_Feature, () => [[["Item", bool_type]], [["Item", Media_Pointer$reflection()]], [["Item1", int32_type], ["Item2", int32_type]], [["Item1", int32_type], ["Item2", int32_type]], [["Item1", int32_type], ["Item2", int32_type]], [], [["Item", int32_type]], [["Item", int32_type]], [["Item", Media_ColorGamut$reflection()]], [["Item", int32_type]], [["Item", int32_type]], [["Item", int32_type]], [["Item", Media_DisplayMode$reflection()]], [["Item", bool_type]], [["Item", bool_type]], [["Item", Length$reflection()]], [["Item", Length$reflection()]], [["Item", Length$reflection()]], [["Item", Length$reflection()]], [["Item", Length$reflection()]], [["Item", Length$reflection()]], [["Item", bool_type]], [["Item", bool_type]], [["Item", Media_LightLevel$reflection()]], [["Item", int32_type]], [["Item", int32_type]], [["Item", int32_type]], [["Item", Media_Orientation$reflection()]], [["Item", Media_OverflowBlock$reflection()]], [["Item", bool_type]], [["Item", Media_Pointer$reflection()]], [["Item", Media_ColorScheme$reflection()]], [["Item", Media_Contrast$reflection()]], [["Item", bool_type]], [["Item", bool_type]], [["Item", Resolution$reflection()]], [["Item", Resolution$reflection()]], [["Item", Resolution$reflection()]], [["Item", Media_Scan$reflection()]], [["Item", Media_Scripting$reflection()]], [["Item", Media_Update$reflection()]]]);
}

export class Media_MediaQuery extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["MediaQuery", "MediaQueryFor"];
    }
    StringifyCss() {
        return "";
    }
}

export function Media_MediaQuery$reflection() {
    return union_type("Fss.Types.Media.MediaQuery", [], Media_MediaQuery, () => [[["Item1", list_type(Media_Feature$reflection())], ["Item2", list_type(tuple_type(Property_CssProperty$reflection(), class_type("Fss.Types.ICssValue")))]], [["Item1", Media_Device$reflection()], ["Item2", list_type(Media_Feature$reflection())], ["Item3", list_type(tuple_type(Property_CssProperty$reflection(), class_type("Fss.Types.ICssValue")))]]]);
}

export class MediaClasses_Media {
    constructor() {
    }
}

export function MediaClasses_Media$reflection() {
    return class_type("Fss.Types.MediaClasses.Media", void 0, MediaClasses_Media);
}

export function MediaClasses_Media_$ctor() {
    return new MediaClasses_Media();
}

export function MediaClasses_Media__query(this$, features, rules) {
    const tupledArg = [new Property_CssProperty(397), new Media_MediaQuery(0, features, rules)];
    return [tupledArg[0], tupledArg[1]];
}

export function MediaClasses_Media__queryFor(this$, device, features, rules) {
    const tupledArg = [new Property_CssProperty(397), new Media_MediaQuery(1, device, features, rules)];
    return [tupledArg[0], tupledArg[1]];
}

//# sourceMappingURL=Media.fs.js.map
