import { Union, toString } from "../../fable-library.3.7.9/Types.js";
import { class_type, union_type } from "../../fable-library.3.7.9/Reflection.js";
import { Normal, CssRuleWithValueFunctions$1$reflection, CssRuleWithValueFunctions$1, Int, CssRuleWithAuto$reflection, CssRuleWithAuto, Float, CssRule$reflection, CssRule } from "./MasterTypes.fs.js";

export class Visibility_Visibility extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["Visible", "Hidden", "Collapse"];
    }
    StringifyCss() {
        const this$ = this;
        return toString(this$).toLocaleLowerCase();
    }
}

export function Visibility_Visibility$reflection() {
    return union_type("Fss.Types.Visibility.Visibility", [], Visibility_Visibility, () => [[], [], []]);
}

export class Visibility_BackfaceVisibility extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["Visible", "Hidden"];
    }
    StringifyCss() {
        const this$ = this;
        return toString(this$).toLocaleLowerCase();
    }
}

export function Visibility_BackfaceVisibility$reflection() {
    return union_type("Fss.Types.Visibility.BackfaceVisibility", [], Visibility_BackfaceVisibility, () => [[], []]);
}

export class VisibilityClasses_Visibility extends CssRule {
    constructor(property) {
        super(property);
        this.property_1 = property;
    }
}

export function VisibilityClasses_Visibility$reflection() {
    return class_type("Fss.Types.VisibilityClasses.Visibility", void 0, VisibilityClasses_Visibility, CssRule$reflection());
}

export function VisibilityClasses_Visibility_$ctor_Z207A3CFB(property) {
    return new VisibilityClasses_Visibility(property);
}

export function VisibilityClasses_Visibility__get_visible(this$) {
    const tupledArg = [this$.property_1, new Visibility_Visibility(0)];
    return [tupledArg[0], tupledArg[1]];
}

export function VisibilityClasses_Visibility__get_hidden(this$) {
    const tupledArg = [this$.property_1, new Visibility_Visibility(1)];
    return [tupledArg[0], tupledArg[1]];
}

export function VisibilityClasses_Visibility__get_collapse(this$) {
    const tupledArg = [this$.property_1, new Visibility_Visibility(2)];
    return [tupledArg[0], tupledArg[1]];
}

export class VisibilityClasses_Opacity extends CssRule {
    constructor(property) {
        super(property);
        this.property_1 = property;
    }
}

export function VisibilityClasses_Opacity$reflection() {
    return class_type("Fss.Types.VisibilityClasses.Opacity", void 0, VisibilityClasses_Opacity, CssRule$reflection());
}

export function VisibilityClasses_Opacity_$ctor_Z207A3CFB(property) {
    return new VisibilityClasses_Opacity(property);
}

export function VisibilityClasses_Opacity__value_5E38073B(this$, opacity) {
    const value = (opacity > 1) ? 1 : ((opacity < 0) ? 0 : opacity);
    const tupledArg = [this$.property_1, new Float(0, value)];
    return [tupledArg[0], tupledArg[1]];
}

export function VisibilityClasses_Opacity__value_2D904CD3(this$, opacity) {
    const tupledArg = [this$.property_1, opacity];
    return [tupledArg[0], tupledArg[1]];
}

export class VisibilityClasses_ZIndex extends CssRuleWithAuto {
    constructor(property) {
        super(property);
        this.property_2 = property;
    }
}

export function VisibilityClasses_ZIndex$reflection() {
    return class_type("Fss.Types.VisibilityClasses.ZIndex", void 0, VisibilityClasses_ZIndex, CssRuleWithAuto$reflection());
}

export function VisibilityClasses_ZIndex_$ctor_Z207A3CFB(property) {
    return new VisibilityClasses_ZIndex(property);
}

export function VisibilityClasses_ZIndex__value_Z524259A4(this$, zindex) {
    const tupledArg = [this$.property_2, new Int(0, zindex)];
    return [tupledArg[0], tupledArg[1]];
}

export class PaintOrder_PaintOrder extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["Stroke", "Markers", "Fill"];
    }
    StringifyCss() {
        const this$ = this;
        return toString(this$).toLocaleLowerCase();
    }
}

export function PaintOrder_PaintOrder$reflection() {
    return union_type("Fss.Types.PaintOrder.PaintOrder", [], PaintOrder_PaintOrder, () => [[], [], []]);
}

export class PaintOrderClasses_PaintOrderClass extends CssRuleWithValueFunctions$1 {
    constructor(property) {
        super(property, " ");
        this.property_2 = property;
    }
}

export function PaintOrderClasses_PaintOrderClass$reflection() {
    return class_type("Fss.Types.PaintOrderClasses.PaintOrderClass", void 0, PaintOrderClasses_PaintOrderClass, CssRuleWithValueFunctions$1$reflection(PaintOrder_PaintOrder$reflection()));
}

export function PaintOrderClasses_PaintOrderClass_$ctor_Z207A3CFB(property) {
    return new PaintOrderClasses_PaintOrderClass(property);
}

export function PaintOrderClasses_PaintOrderClass__get_stroke(this$) {
    const tupledArg = [this$.property_2, new PaintOrder_PaintOrder(0)];
    return [tupledArg[0], tupledArg[1]];
}

export function PaintOrderClasses_PaintOrderClass__get_markers(this$) {
    const tupledArg = [this$.property_2, new PaintOrder_PaintOrder(1)];
    return [tupledArg[0], tupledArg[1]];
}

export function PaintOrderClasses_PaintOrderClass__get_fill(this$) {
    const tupledArg = [this$.property_2, new PaintOrder_PaintOrder(2)];
    return [tupledArg[0], tupledArg[1]];
}

export function PaintOrderClasses_PaintOrderClass__get_normal(this$) {
    const tupledArg = [this$.property_2, new Normal(0)];
    return [tupledArg[0], tupledArg[1]];
}

//# sourceMappingURL=Visibility.fs.js.map
