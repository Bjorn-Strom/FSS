import { Union, toString } from "../../fable-library.3.7.9/Types.js";
import { class_type, union_type } from "../../fable-library.3.7.9/Reflection.js";
import { CssRuleWithNone$reflection, CssRuleWithNone, CssRule$reflection, CssRule } from "./MasterTypes.fs.js";
import { ColorClass_Color$reflection, ColorClass_Color } from "./Color.fs.js";
import { unitHelpers_CssRuleWithLength$reflection, unitHelpers_CssRuleWithLength } from "./Units.fs.js";

export class Outline_Width extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["Thin", "Medium", "Thick"];
    }
    StringifyCss() {
        const this$ = this;
        return toString(this$).toLocaleLowerCase();
    }
}

export function Outline_Width$reflection() {
    return union_type("Fss.Types.Outline.Width", [], Outline_Width, () => [[], [], []]);
}

export class Outline_Style extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["Hidden", "Dotted", "Dashed", "Solid", "Double", "Groove", "Ridge", "Inset", "Outset"];
    }
    StringifyCss() {
        const this$ = this;
        return toString(this$).toLocaleLowerCase();
    }
}

export function Outline_Style$reflection() {
    return union_type("Fss.Types.Outline.Style", [], Outline_Style, () => [[], [], [], [], [], [], [], [], []]);
}

export class OutlineClasses_Outline extends CssRule {
    constructor(property) {
        super(property);
    }
}

export function OutlineClasses_Outline$reflection() {
    return class_type("Fss.Types.OutlineClasses.Outline", void 0, OutlineClasses_Outline, CssRule$reflection());
}

export function OutlineClasses_Outline_$ctor_Z207A3CFB(property) {
    return new OutlineClasses_Outline(property);
}

export class OutlineClasses_OutlineColor extends ColorClass_Color {
    constructor(property) {
        super(property);
    }
}

export function OutlineClasses_OutlineColor$reflection() {
    return class_type("Fss.Types.OutlineClasses.OutlineColor", void 0, OutlineClasses_OutlineColor, ColorClass_Color$reflection());
}

export function OutlineClasses_OutlineColor_$ctor_Z207A3CFB(property) {
    return new OutlineClasses_OutlineColor(property);
}

export class OutlineClasses_OutlineWidth extends unitHelpers_CssRuleWithLength {
    constructor(property) {
        super(property);
        this.property_2 = property;
    }
}

export function OutlineClasses_OutlineWidth$reflection() {
    return class_type("Fss.Types.OutlineClasses.OutlineWidth", void 0, OutlineClasses_OutlineWidth, unitHelpers_CssRuleWithLength$reflection());
}

export function OutlineClasses_OutlineWidth_$ctor_Z207A3CFB(property) {
    return new OutlineClasses_OutlineWidth(property);
}

export function OutlineClasses_OutlineWidth__get_thin(this$) {
    const tupledArg = [this$.property_2, new Outline_Width(0)];
    return [tupledArg[0], tupledArg[1]];
}

export function OutlineClasses_OutlineWidth__get_medium(this$) {
    const tupledArg = [this$.property_2, new Outline_Width(1)];
    return [tupledArg[0], tupledArg[1]];
}

export function OutlineClasses_OutlineWidth__get_thick(this$) {
    const tupledArg = [this$.property_2, new Outline_Width(2)];
    return [tupledArg[0], tupledArg[1]];
}

export class OutlineClasses_OutlineStyle extends CssRuleWithNone {
    constructor(property) {
        super(property);
        this.property_2 = property;
    }
}

export function OutlineClasses_OutlineStyle$reflection() {
    return class_type("Fss.Types.OutlineClasses.OutlineStyle", void 0, OutlineClasses_OutlineStyle, CssRuleWithNone$reflection());
}

export function OutlineClasses_OutlineStyle_$ctor_Z207A3CFB(property) {
    return new OutlineClasses_OutlineStyle(property);
}

export function OutlineClasses_OutlineStyle__get_hidden(this$) {
    const tupledArg = [this$.property_2, new Outline_Style(0)];
    return [tupledArg[0], tupledArg[1]];
}

export function OutlineClasses_OutlineStyle__get_dotted(this$) {
    const tupledArg = [this$.property_2, new Outline_Style(1)];
    return [tupledArg[0], tupledArg[1]];
}

export function OutlineClasses_OutlineStyle__get_dashed(this$) {
    const tupledArg = [this$.property_2, new Outline_Style(2)];
    return [tupledArg[0], tupledArg[1]];
}

export function OutlineClasses_OutlineStyle__get_solid(this$) {
    const tupledArg = [this$.property_2, new Outline_Style(3)];
    return [tupledArg[0], tupledArg[1]];
}

export function OutlineClasses_OutlineStyle__get_double(this$) {
    const tupledArg = [this$.property_2, new Outline_Style(4)];
    return [tupledArg[0], tupledArg[1]];
}

export function OutlineClasses_OutlineStyle__get_groove(this$) {
    const tupledArg = [this$.property_2, new Outline_Style(5)];
    return [tupledArg[0], tupledArg[1]];
}

export function OutlineClasses_OutlineStyle__get_ridge(this$) {
    const tupledArg = [this$.property_2, new Outline_Style(6)];
    return [tupledArg[0], tupledArg[1]];
}

export function OutlineClasses_OutlineStyle__get_inset(this$) {
    const tupledArg = [this$.property_2, new Outline_Style(7)];
    return [tupledArg[0], tupledArg[1]];
}

export function OutlineClasses_OutlineStyle__get_outset(this$) {
    const tupledArg = [this$.property_2, new Outline_Style(8)];
    return [tupledArg[0], tupledArg[1]];
}

export class OutlineClasses_OutlineOffset extends unitHelpers_CssRuleWithLength {
    constructor(property) {
        super(property);
    }
}

export function OutlineClasses_OutlineOffset$reflection() {
    return class_type("Fss.Types.OutlineClasses.OutlineOffset", void 0, OutlineClasses_OutlineOffset, unitHelpers_CssRuleWithLength$reflection());
}

export function OutlineClasses_OutlineOffset_$ctor_Z207A3CFB(property) {
    return new OutlineClasses_OutlineOffset(property);
}

//# sourceMappingURL=Outline.fs.js.map
