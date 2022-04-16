import { Union, toString } from "../../fable-library.3.7.9/Types.js";
import { class_type, union_type } from "../../fable-library.3.7.9/Reflection.js";
import { ColorClass_Color$reflection, ColorClass_Color } from "./Color.fs.js";
import { unitHelpers_lengthPercentageString, unitHelpers_lengthPercentageToType, unitHelpers_DirectionalLength$reflection, unitHelpers_DirectionalLength } from "./Units.fs.js";
import { None$0027, Auto, Float, MasterTypeHelpers_stringifyICssValue, String$, CssRule$reflection, CssRule, CssRuleWithNone$reflection, CssRuleWithNone } from "./MasterTypes.fs.js";

export class Border_Width extends Union {
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

export function Border_Width$reflection() {
    return union_type("Fss.Types.Border.Width", [], Border_Width, () => [[], [], []]);
}

export class Border_Style extends Union {
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

export function Border_Style$reflection() {
    return union_type("Fss.Types.Border.Style", [], Border_Style, () => [[], [], [], [], [], [], [], [], []]);
}

export class Border_Collapse extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["Collapse", "Separate"];
    }
    StringifyCss() {
        const this$ = this;
        return toString(this$).toLocaleLowerCase();
    }
}

export function Border_Collapse$reflection() {
    return union_type("Fss.Types.Border.Collapse", [], Border_Collapse, () => [[], []]);
}

export class Border_ImageRepeat extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["Stretch", "Repeat", "Round", "Space"];
    }
    StringifyCss() {
        const this$ = this;
        return toString(this$).toLocaleLowerCase();
    }
}

export function Border_ImageRepeat$reflection() {
    return union_type("Fss.Types.Border.ImageRepeat", [], Border_ImageRepeat, () => [[], [], [], []]);
}

export class BorderClasses_BorderColorParent extends ColorClass_Color {
    constructor(property) {
        super(property);
        this.property_2 = property;
    }
}

export function BorderClasses_BorderColorParent$reflection() {
    return class_type("Fss.Types.BorderClasses.BorderColorParent", void 0, BorderClasses_BorderColorParent, ColorClass_Color$reflection());
}

export function BorderClasses_BorderColorParent_$ctor_Z207A3CFB(property) {
    return new BorderClasses_BorderColorParent(property);
}

export function BorderClasses_BorderColorParent__value_11789E6(this$, color) {
    const tupledArg = [this$.property_2, color];
    return [tupledArg[0], tupledArg[1]];
}

export class BorderClasses_BorderWidthParent extends unitHelpers_DirectionalLength {
    constructor(property) {
        super(property);
        this.property_2 = property;
    }
}

export function BorderClasses_BorderWidthParent$reflection() {
    return class_type("Fss.Types.BorderClasses.BorderWidthParent", void 0, BorderClasses_BorderWidthParent, unitHelpers_DirectionalLength$reflection());
}

export function BorderClasses_BorderWidthParent_$ctor_Z207A3CFB(property) {
    return new BorderClasses_BorderWidthParent(property);
}

export function BorderClasses_BorderWidthParent__value_Z21899574(this$, width) {
    const tupledArg = [this$.property_2, width];
    return [tupledArg[0], tupledArg[1]];
}

export function BorderClasses_BorderWidthParent__get_thin(this$) {
    const tupledArg = [this$.property_2, new Border_Width(0)];
    return [tupledArg[0], tupledArg[1]];
}

export function BorderClasses_BorderWidthParent__get_medium(this$) {
    const tupledArg = [this$.property_2, new Border_Width(1)];
    return [tupledArg[0], tupledArg[1]];
}

export function BorderClasses_BorderWidthParent__get_thick(this$) {
    const tupledArg = [this$.property_2, new Border_Width(2)];
    return [tupledArg[0], tupledArg[1]];
}

export class BorderClasses_BorderStyleParent extends CssRuleWithNone {
    constructor(property) {
        super(property);
        this.property_2 = property;
    }
}

export function BorderClasses_BorderStyleParent$reflection() {
    return class_type("Fss.Types.BorderClasses.BorderStyleParent", void 0, BorderClasses_BorderStyleParent, CssRuleWithNone$reflection());
}

export function BorderClasses_BorderStyleParent_$ctor_Z207A3CFB(property) {
    return new BorderClasses_BorderStyleParent(property);
}

export function BorderClasses_BorderStyleParent__value_Z21D05303(this$, style) {
    const tupledArg = [this$.property_2, style];
    return [tupledArg[0], tupledArg[1]];
}

export function BorderClasses_BorderStyleParent__get_hidden(this$) {
    const tupledArg = [this$.property_2, new Border_Style(0)];
    return [tupledArg[0], tupledArg[1]];
}

export function BorderClasses_BorderStyleParent__get_dotted(this$) {
    const tupledArg = [this$.property_2, new Border_Style(1)];
    return [tupledArg[0], tupledArg[1]];
}

export function BorderClasses_BorderStyleParent__get_dashed(this$) {
    const tupledArg = [this$.property_2, new Border_Style(2)];
    return [tupledArg[0], tupledArg[1]];
}

export function BorderClasses_BorderStyleParent__get_solid(this$) {
    const tupledArg = [this$.property_2, new Border_Style(3)];
    return [tupledArg[0], tupledArg[1]];
}

export function BorderClasses_BorderStyleParent__get_double(this$) {
    const tupledArg = [this$.property_2, new Border_Style(4)];
    return [tupledArg[0], tupledArg[1]];
}

export function BorderClasses_BorderStyleParent__get_groove(this$) {
    const tupledArg = [this$.property_2, new Border_Style(5)];
    return [tupledArg[0], tupledArg[1]];
}

export function BorderClasses_BorderStyleParent__get_ridge(this$) {
    const tupledArg = [this$.property_2, new Border_Style(6)];
    return [tupledArg[0], tupledArg[1]];
}

export function BorderClasses_BorderStyleParent__get_inset(this$) {
    const tupledArg = [this$.property_2, new Border_Style(7)];
    return [tupledArg[0], tupledArg[1]];
}

export function BorderClasses_BorderStyleParent__get_outset(this$) {
    const tupledArg = [this$.property_2, new Border_Style(8)];
    return [tupledArg[0], tupledArg[1]];
}

export class BorderClasses_BorderRadiusParent extends CssRule {
    constructor(property) {
        super(property);
        this.property_1 = property;
    }
}

export function BorderClasses_BorderRadiusParent$reflection() {
    return class_type("Fss.Types.BorderClasses.BorderRadiusParent", void 0, BorderClasses_BorderRadiusParent, CssRule$reflection());
}

export function BorderClasses_BorderRadiusParent_$ctor_Z207A3CFB(property) {
    return new BorderClasses_BorderRadiusParent(property);
}

export function BorderClasses_BorderRadiusParent__value_Z498FEB3B(this$, radius) {
    const tupledArg = [this$.property_1, unitHelpers_lengthPercentageToType(radius)];
    return [tupledArg[0], tupledArg[1]];
}

export class BorderClasses_BorderWidth extends BorderClasses_BorderWidthParent {
    constructor(property) {
        super(property);
    }
}

export function BorderClasses_BorderWidth$reflection() {
    return class_type("Fss.Types.BorderClasses.BorderWidth", void 0, BorderClasses_BorderWidth, BorderClasses_BorderWidthParent$reflection());
}

export function BorderClasses_BorderWidth_$ctor_Z207A3CFB(property) {
    return new BorderClasses_BorderWidth(property);
}

export class BorderClasses_BorderRadius extends unitHelpers_DirectionalLength {
    constructor(property) {
        super(property);
    }
}

export function BorderClasses_BorderRadius$reflection() {
    return class_type("Fss.Types.BorderClasses.BorderRadius", void 0, BorderClasses_BorderRadius, unitHelpers_DirectionalLength$reflection());
}

export function BorderClasses_BorderRadius_$ctor_Z207A3CFB(property) {
    return new BorderClasses_BorderRadius(property);
}

export class BorderClasses_BorderRadiusEdge extends CssRule {
    constructor(property) {
        super(property);
        this.property_1 = property;
    }
}

export function BorderClasses_BorderRadiusEdge$reflection() {
    return class_type("Fss.Types.BorderClasses.BorderRadiusEdge", void 0, BorderClasses_BorderRadiusEdge, CssRule$reflection());
}

export function BorderClasses_BorderRadiusEdge_$ctor_Z207A3CFB(property) {
    return new BorderClasses_BorderRadiusEdge(property);
}

export function BorderClasses_BorderRadiusEdge__value_Z498FEB3B(this$, radiusEdge) {
    const tupledArg = [this$.property_1, unitHelpers_lengthPercentageToType(radiusEdge)];
    return [tupledArg[0], tupledArg[1]];
}

export function BorderClasses_BorderRadiusEdge__value_3202B9A0(this$, horizontal, vertical) {
    const value = new String$(0, `${unitHelpers_lengthPercentageString(horizontal)} ${unitHelpers_lengthPercentageString(vertical)}`);
    const tupledArg = [this$.property_1, value];
    return [tupledArg[0], tupledArg[1]];
}

export class BorderClasses_BorderStyle extends BorderClasses_BorderStyleParent {
    constructor(property) {
        super(property);
        this.property_3 = property;
    }
}

export function BorderClasses_BorderStyle$reflection() {
    return class_type("Fss.Types.BorderClasses.BorderStyle", void 0, BorderClasses_BorderStyle, BorderClasses_BorderStyleParent$reflection());
}

export function BorderClasses_BorderStyle_$ctor_Z207A3CFB(property) {
    return new BorderClasses_BorderStyle(property);
}

export function BorderClasses_BorderStyle__value_7A0AE060(this$, topAndBottom, leftAndRight) {
    const value = new String$(0, `${MasterTypeHelpers_stringifyICssValue(topAndBottom)} ${MasterTypeHelpers_stringifyICssValue(leftAndRight)}`);
    const tupledArg = [this$.property_3, value];
    return [tupledArg[0], tupledArg[1]];
}

export function BorderClasses_BorderStyle__value_6549409D(this$, top, leftAndRight, bottom) {
    const value = new String$(0, `${MasterTypeHelpers_stringifyICssValue(top)} ${MasterTypeHelpers_stringifyICssValue(leftAndRight)} ${MasterTypeHelpers_stringifyICssValue(bottom)}`);
    const tupledArg = [this$.property_3, value];
    return [tupledArg[0], tupledArg[1]];
}

export function BorderClasses_BorderStyle__value_Z2FA10740(this$, top, right, bottom, left) {
    const value = new String$(0, `${MasterTypeHelpers_stringifyICssValue(top)} ${MasterTypeHelpers_stringifyICssValue(right)} ${MasterTypeHelpers_stringifyICssValue(bottom)} ${MasterTypeHelpers_stringifyICssValue(left)}`);
    const tupledArg = [this$.property_3, value];
    return [tupledArg[0], tupledArg[1]];
}

export class BorderClasses_BorderCollapse extends CssRule {
    constructor(property) {
        super(property);
        this.property_1 = property;
    }
}

export function BorderClasses_BorderCollapse$reflection() {
    return class_type("Fss.Types.BorderClasses.BorderCollapse", void 0, BorderClasses_BorderCollapse, CssRule$reflection());
}

export function BorderClasses_BorderCollapse_$ctor_Z207A3CFB(property) {
    return new BorderClasses_BorderCollapse(property);
}

export function BorderClasses_BorderCollapse__value_Z5C12C4DF(this$, collapse) {
    const tupledArg = [this$.property_1, collapse];
    return [tupledArg[0], tupledArg[1]];
}

export function BorderClasses_BorderCollapse__get_collapse(this$) {
    const tupledArg = [this$.property_1, new Border_Collapse(0)];
    return [tupledArg[0], tupledArg[1]];
}

export function BorderClasses_BorderCollapse__get_separate(this$) {
    const tupledArg = [this$.property_1, new Border_Collapse(1)];
    return [tupledArg[0], tupledArg[1]];
}

export class BorderClasses_BorderImageOutset extends unitHelpers_DirectionalLength {
    constructor(property) {
        super(property);
        this.property_2 = property;
    }
}

export function BorderClasses_BorderImageOutset$reflection() {
    return class_type("Fss.Types.BorderClasses.BorderImageOutset", void 0, BorderClasses_BorderImageOutset, unitHelpers_DirectionalLength$reflection());
}

export function BorderClasses_BorderImageOutset_$ctor_Z207A3CFB(property) {
    return new BorderClasses_BorderImageOutset(property);
}

export function BorderClasses_BorderImageOutset__value_5E38073B(this$, imageOutset) {
    const tupledArg = [this$.property_2, new Float(0, imageOutset)];
    return [tupledArg[0], tupledArg[1]];
}

export function BorderClasses_BorderImageOutset__value_7B00E9A0(this$, vertical, horizontal) {
    const value = new String$(0, `${vertical} ${horizontal}`);
    const tupledArg = [this$.property_2, value];
    return [tupledArg[0], tupledArg[1]];
}

export class BorderClasses_BorderImageRepeat extends CssRule {
    constructor(property) {
        super(property);
        this.property_1 = property;
    }
}

export function BorderClasses_BorderImageRepeat$reflection() {
    return class_type("Fss.Types.BorderClasses.BorderImageRepeat", void 0, BorderClasses_BorderImageRepeat, CssRule$reflection());
}

export function BorderClasses_BorderImageRepeat_$ctor_Z207A3CFB(property) {
    return new BorderClasses_BorderImageRepeat(property);
}

export function BorderClasses_BorderImageRepeat__value_1D8A297A(this$, imageRepeat) {
    const tupledArg = [this$.property_1, imageRepeat];
    return [tupledArg[0], tupledArg[1]];
}

export function BorderClasses_BorderImageRepeat__value_Z2CBA8E40(this$, vertical, horizontal) {
    const value = new String$(0, `${MasterTypeHelpers_stringifyICssValue(vertical)} ${MasterTypeHelpers_stringifyICssValue(horizontal)}`);
    const tupledArg = [this$.property_1, value];
    return [tupledArg[0], tupledArg[1]];
}

export function BorderClasses_BorderImageRepeat__get_stretch(this$) {
    const tupledArg = [this$.property_1, new Border_ImageRepeat(0)];
    return [tupledArg[0], tupledArg[1]];
}

export function BorderClasses_BorderImageRepeat__get_repeat(this$) {
    const tupledArg = [this$.property_1, new Border_ImageRepeat(1)];
    return [tupledArg[0], tupledArg[1]];
}

export function BorderClasses_BorderImageRepeat__get_round(this$) {
    const tupledArg = [this$.property_1, new Border_ImageRepeat(2)];
    return [tupledArg[0], tupledArg[1]];
}

export function BorderClasses_BorderImageRepeat__get_space(this$) {
    const tupledArg = [this$.property_1, new Border_ImageRepeat(3)];
    return [tupledArg[0], tupledArg[1]];
}

export class BorderClasses_BorderImageSlice extends unitHelpers_DirectionalLength {
    constructor(Property) {
        super(Property);
    }
}

export function BorderClasses_BorderImageSlice$reflection() {
    return class_type("Fss.Types.BorderClasses.BorderImageSlice", void 0, BorderClasses_BorderImageSlice, unitHelpers_DirectionalLength$reflection());
}

export function BorderClasses_BorderImageSlice_$ctor_Z207A3CFB(Property) {
    return new BorderClasses_BorderImageSlice(Property);
}

export class BorderClasses_BorderColor extends BorderClasses_BorderColorParent {
    constructor(property) {
        super(property);
        this.property_3 = property;
    }
}

export function BorderClasses_BorderColor$reflection() {
    return class_type("Fss.Types.BorderClasses.BorderColor", void 0, BorderClasses_BorderColor, BorderClasses_BorderColorParent$reflection());
}

export function BorderClasses_BorderColor_$ctor_Z207A3CFB(property) {
    return new BorderClasses_BorderColor(property);
}

export function BorderClasses_BorderColor__value_251F4F40(this$, vertical, horizontal) {
    const value = new String$(0, `${MasterTypeHelpers_stringifyICssValue(vertical)} ${MasterTypeHelpers_stringifyICssValue(horizontal)}`);
    const tupledArg = [this$.property_3, value];
    return [tupledArg[0], tupledArg[1]];
}

export function BorderClasses_BorderColor__value_Z37E1415A(this$, top, horizontal, bottom) {
    const value = new String$(0, `${MasterTypeHelpers_stringifyICssValue(top)} ${MasterTypeHelpers_stringifyICssValue(horizontal)} ${MasterTypeHelpers_stringifyICssValue(bottom)}`);
    const tupledArg = [this$.property_3, value];
    return [tupledArg[0], tupledArg[1]];
}

export function BorderClasses_BorderColor__value_Z351EE580(this$, top, right, bottom, left) {
    const value = new String$(0, `${MasterTypeHelpers_stringifyICssValue(top)} ${MasterTypeHelpers_stringifyICssValue(right)} ${MasterTypeHelpers_stringifyICssValue(bottom)} ${MasterTypeHelpers_stringifyICssValue(left)}`);
    const tupledArg = [this$.property_3, value];
    return [tupledArg[0], tupledArg[1]];
}

export class BorderClasses_BorderSpacing extends CssRule {
    constructor(property) {
        super(property);
        this.property_1 = property;
    }
}

export function BorderClasses_BorderSpacing$reflection() {
    return class_type("Fss.Types.BorderClasses.BorderSpacing", void 0, BorderClasses_BorderSpacing, CssRule$reflection());
}

export function BorderClasses_BorderSpacing_$ctor_Z207A3CFB(property) {
    return new BorderClasses_BorderSpacing(property);
}

export function BorderClasses_BorderSpacing__value_Z498FEB3B(this$, spacing) {
    const tupledArg = [this$.property_1, unitHelpers_lengthPercentageToType(spacing)];
    return [tupledArg[0], tupledArg[1]];
}

export function BorderClasses_BorderSpacing__value_3202B9A0(this$, horizontal, vertical) {
    const value = new String$(0, `${unitHelpers_lengthPercentageString(horizontal)} ${unitHelpers_lengthPercentageString(vertical)}`);
    const tupledArg = [this$.property_1, value];
    return [tupledArg[0], tupledArg[1]];
}

export class BorderClasses_BorderImageWidth extends unitHelpers_DirectionalLength {
    constructor(property) {
        super(property);
        this.property_2 = property;
    }
}

export function BorderClasses_BorderImageWidth$reflection() {
    return class_type("Fss.Types.BorderClasses.BorderImageWidth", void 0, BorderClasses_BorderImageWidth, unitHelpers_DirectionalLength$reflection());
}

export function BorderClasses_BorderImageWidth_$ctor_Z207A3CFB(property) {
    return new BorderClasses_BorderImageWidth(property);
}

export function BorderClasses_BorderImageWidth__value_5E38073B(this$, imageWidth) {
    const tupledArg = [this$.property_2, new Float(0, imageWidth)];
    return [tupledArg[0], tupledArg[1]];
}

export function BorderClasses_BorderImageWidth__value_3202B9A0(this$, vertical, horizontal) {
    const value = new String$(0, `${unitHelpers_lengthPercentageString(vertical)} ${unitHelpers_lengthPercentageString(horizontal)}`);
    const tupledArg = [this$.property_2, value];
    return [tupledArg[0], tupledArg[1]];
}

export function BorderClasses_BorderImageWidth__get_auto(this$) {
    const tupledArg = [this$.property_2, new Auto(0)];
    return [tupledArg[0], tupledArg[1]];
}

export class BorderClasses_Border extends CssRule {
    constructor(property) {
        super(property);
        this.property_1 = property;
    }
}

export function BorderClasses_Border$reflection() {
    return class_type("Fss.Types.BorderClasses.Border", void 0, BorderClasses_Border, CssRule$reflection());
}

export function BorderClasses_Border_$ctor_Z207A3CFB(property) {
    return new BorderClasses_Border(property);
}

export function BorderClasses_Border__value_D272445(this$, border) {
    const tupledArg = [this$.property_1, border];
    return [tupledArg[0], tupledArg[1]];
}

export function BorderClasses_Border__get_none(this$) {
    const tupledArg = [this$.property_1, new None$0027(0)];
    return [tupledArg[0], tupledArg[1]];
}

//# sourceMappingURL=Border.fs.js.map
