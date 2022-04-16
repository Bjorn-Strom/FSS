import { Helpers_toKebabCase } from "../Utilities.fs.js";
import { toString, Union } from "../../fable-library.3.7.9/Types.js";
import { class_type, union_type } from "../../fable-library.3.7.9/Reflection.js";
import { CssRuleWithAuto$reflection, CssRuleWithAuto, Normal, Auto, CssRuleWithValueFunctions$1$reflection, CssRuleWithValueFunctions$1, String$, MasterTypeHelpers_stringifyICssValue, CssRule$reflection, CssRule } from "./MasterTypes.fs.js";
import { unitHelpers_lengthPercentageString, unitHelpers_lengthPercentageToType } from "./Units.fs.js";
import { ColorClass_Color$reflection, ColorClass_Color } from "./Color.fs.js";
import { ImageClasses_ImageClass$reflection, ImageClasses_ImageClass } from "./Image.fs.js";

export class Background_Clip extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["BorderBox", "PaddingBox", "ContentBox", "Text"];
    }
    StringifyCss() {
        const this$ = this;
        return Helpers_toKebabCase(this$);
    }
}

export function Background_Clip$reflection() {
    return union_type("Fss.Types.Background.Clip", [], Background_Clip, () => [[], [], [], []]);
}

export class Background_Origin extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["BorderBox", "PaddingBox", "ContentBox"];
    }
    StringifyCss() {
        const this$ = this;
        return Helpers_toKebabCase(this$);
    }
}

export function Background_Origin$reflection() {
    return union_type("Fss.Types.Background.Origin", [], Background_Origin, () => [[], [], []]);
}

export class Background_Repeat extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["RepeatX", "RepeatY", "Repeat", "Space", "Round", "NoRepeat"];
    }
    StringifyCss() {
        const this$ = this;
        return Helpers_toKebabCase(this$);
    }
}

export function Background_Repeat$reflection() {
    return union_type("Fss.Types.Background.Repeat", [], Background_Repeat, () => [[], [], [], [], [], []]);
}

export class Background_Size extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["Cover", "Contain"];
    }
    StringifyCss() {
        const this$ = this;
        return toString(this$).toLocaleLowerCase();
    }
}

export function Background_Size$reflection() {
    return union_type("Fss.Types.Background.Size", [], Background_Size, () => [[], []]);
}

export class Background_Attachment extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["Scroll", "Fixed", "Local"];
    }
    StringifyCss() {
        const this$ = this;
        return toString(this$).toLocaleLowerCase();
    }
}

export function Background_Attachment$reflection() {
    return union_type("Fss.Types.Background.Attachment", [], Background_Attachment, () => [[], [], []]);
}

export class Background_Position extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["Top", "Bottom", "Left", "Right", "Center"];
    }
    StringifyCss() {
        const this$ = this;
        return toString(this$).toLocaleLowerCase();
    }
}

export function Background_Position$reflection() {
    return union_type("Fss.Types.Background.Position", [], Background_Position, () => [[], [], [], [], []]);
}

export class Background_BlendMode extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["Multiply", "Screen", "Overlay", "Darken", "Lighten", "ColorDodge", "ColorBurn", "HardLight", "SoftLight", "Difference", "Exclusion", "Hue", "Saturation", "Color", "Luminosity"];
    }
    StringifyCss() {
        const this$ = this;
        return Helpers_toKebabCase(this$);
    }
}

export function Background_BlendMode$reflection() {
    return union_type("Fss.Types.Background.BlendMode", [], Background_BlendMode, () => [[], [], [], [], [], [], [], [], [], [], [], [], [], [], []]);
}

export class Background_Isolation extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["Isolate"];
    }
    StringifyCss() {
        return "isolate";
    }
}

export function Background_Isolation$reflection() {
    return union_type("Fss.Types.Background.Isolation", [], Background_Isolation, () => [[]]);
}

export class Background_BoxDecorationBreak extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["Slice", "Clone"];
    }
    StringifyCss() {
        const this$ = this;
        return toString(this$).toLocaleLowerCase();
    }
}

export function Background_BoxDecorationBreak$reflection() {
    return union_type("Fss.Types.Background.BoxDecorationBreak", [], Background_BoxDecorationBreak, () => [[], []]);
}

export class BackgroundClasses_BackgroundClip extends CssRule {
    constructor(property) {
        super(property);
        this.property_1 = property;
    }
}

export function BackgroundClasses_BackgroundClip$reflection() {
    return class_type("Fss.Types.BackgroundClasses.BackgroundClip", void 0, BackgroundClasses_BackgroundClip, CssRule$reflection());
}

export function BackgroundClasses_BackgroundClip_$ctor_Z207A3CFB(property) {
    return new BackgroundClasses_BackgroundClip(property);
}

export function BackgroundClasses_BackgroundClip__value_101E461E(this$, clip) {
    const tupledArg = [this$.property_1, clip];
    return [tupledArg[0], tupledArg[1]];
}

export function BackgroundClasses_BackgroundClip__get_borderBox(this$) {
    const tupledArg = [this$.property_1, new Background_Clip(0)];
    return [tupledArg[0], tupledArg[1]];
}

export function BackgroundClasses_BackgroundClip__get_paddingBox(this$) {
    const tupledArg = [this$.property_1, new Background_Clip(1)];
    return [tupledArg[0], tupledArg[1]];
}

export function BackgroundClasses_BackgroundClip__get_contentBox(this$) {
    const tupledArg = [this$.property_1, new Background_Clip(2)];
    return [tupledArg[0], tupledArg[1]];
}

export function BackgroundClasses_BackgroundClip__get_text(this$) {
    const tupledArg = [this$.property_1, new Background_Clip(3)];
    return [tupledArg[0], tupledArg[1]];
}

export class BackgroundClasses_BackgroundOrigin extends CssRule {
    constructor(property) {
        super(property);
        this.property_1 = property;
    }
}

export function BackgroundClasses_BackgroundOrigin$reflection() {
    return class_type("Fss.Types.BackgroundClasses.BackgroundOrigin", void 0, BackgroundClasses_BackgroundOrigin, CssRule$reflection());
}

export function BackgroundClasses_BackgroundOrigin_$ctor_Z207A3CFB(property) {
    return new BackgroundClasses_BackgroundOrigin(property);
}

export function BackgroundClasses_BackgroundOrigin__value_Z7700C944(this$, origin) {
    const tupledArg = [this$.property_1, origin];
    return [tupledArg[0], tupledArg[1]];
}

export function BackgroundClasses_BackgroundOrigin__get_borderBox(this$) {
    const tupledArg = [this$.property_1, new Background_Origin(0)];
    return [tupledArg[0], tupledArg[1]];
}

export function BackgroundClasses_BackgroundOrigin__get_paddingBox(this$) {
    const tupledArg = [this$.property_1, new Background_Origin(1)];
    return [tupledArg[0], tupledArg[1]];
}

export function BackgroundClasses_BackgroundOrigin__get_contentBox(this$) {
    const tupledArg = [this$.property_1, new Background_Origin(2)];
    return [tupledArg[0], tupledArg[1]];
}

export class BackgroundClasses_BackgroundRepeat extends CssRule {
    constructor(property) {
        super(property);
        this.property_1 = property;
    }
}

export function BackgroundClasses_BackgroundRepeat$reflection() {
    return class_type("Fss.Types.BackgroundClasses.BackgroundRepeat", void 0, BackgroundClasses_BackgroundRepeat, CssRule$reflection());
}

export function BackgroundClasses_BackgroundRepeat_$ctor_Z207A3CFB(property) {
    return new BackgroundClasses_BackgroundRepeat(property);
}

export function BackgroundClasses_BackgroundRepeat__value_Z5959EF01(this$, repeat) {
    const tupledArg = [this$.property_1, repeat];
    return [tupledArg[0], tupledArg[1]];
}

export function BackgroundClasses_BackgroundRepeat__value_Z2231DFE0(this$, vertical, horizontal) {
    const repeat = new String$(0, `${MasterTypeHelpers_stringifyICssValue(vertical)} ${MasterTypeHelpers_stringifyICssValue(horizontal)}`);
    const tupledArg = [this$.property_1, repeat];
    return [tupledArg[0], tupledArg[1]];
}

export function BackgroundClasses_BackgroundRepeat__get_repeatX(this$) {
    const tupledArg = [this$.property_1, new Background_Repeat(0)];
    return [tupledArg[0], tupledArg[1]];
}

export function BackgroundClasses_BackgroundRepeat__get_repeatY(this$) {
    const tupledArg = [this$.property_1, new Background_Repeat(1)];
    return [tupledArg[0], tupledArg[1]];
}

export function BackgroundClasses_BackgroundRepeat__get_repeat(this$) {
    const tupledArg = [this$.property_1, new Background_Repeat(2)];
    return [tupledArg[0], tupledArg[1]];
}

export function BackgroundClasses_BackgroundRepeat__get_space(this$) {
    const tupledArg = [this$.property_1, new Background_Repeat(3)];
    return [tupledArg[0], tupledArg[1]];
}

export function BackgroundClasses_BackgroundRepeat__get_round(this$) {
    const tupledArg = [this$.property_1, new Background_Repeat(4)];
    return [tupledArg[0], tupledArg[1]];
}

export function BackgroundClasses_BackgroundRepeat__get_noRepeat(this$) {
    const tupledArg = [this$.property_1, new Background_Repeat(5)];
    return [tupledArg[0], tupledArg[1]];
}

export class BackgroundClasses_BackgroundSize extends CssRuleWithValueFunctions$1 {
    constructor(property) {
        super(property, ", ");
        this.property_2 = property;
    }
}

export function BackgroundClasses_BackgroundSize$reflection() {
    return class_type("Fss.Types.BackgroundClasses.BackgroundSize", void 0, BackgroundClasses_BackgroundSize, CssRuleWithValueFunctions$1$reflection(Background_Size$reflection()));
}

export function BackgroundClasses_BackgroundSize_$ctor_Z207A3CFB(property) {
    return new BackgroundClasses_BackgroundSize(property);
}

export function BackgroundClasses_BackgroundSize__value_Z498FEB3B(this$, size) {
    const tupledArg = [this$.property_2, unitHelpers_lengthPercentageToType(size)];
    return [tupledArg[0], tupledArg[1]];
}

export function BackgroundClasses_BackgroundSize__value_3202B9A0(this$, x, y) {
    const sizes = `${unitHelpers_lengthPercentageString(x)} ${unitHelpers_lengthPercentageString(y)}`;
    const tupledArg = [this$.property_2, new String$(0, sizes)];
    return [tupledArg[0], tupledArg[1]];
}

export function BackgroundClasses_BackgroundSize__get_auto(this$) {
    const tupledArg = [this$.property_2, new Auto(0)];
    return [tupledArg[0], tupledArg[1]];
}

export function BackgroundClasses_BackgroundSize__value_5205FE0(this$, horizontal, vertical) {
    const value = new String$(0, `${MasterTypeHelpers_stringifyICssValue(horizontal)} ${MasterTypeHelpers_stringifyICssValue(vertical)}`);
    const tupledArg = [this$.property_2, value];
    return [tupledArg[0], tupledArg[1]];
}

export function BackgroundClasses_BackgroundSize__get_cover(this$) {
    const tupledArg = [this$.property_2, new Background_Size(0)];
    return [tupledArg[0], tupledArg[1]];
}

export function BackgroundClasses_BackgroundSize__get_contain(this$) {
    const tupledArg = [this$.property_2, new Background_Size(1)];
    return [tupledArg[0], tupledArg[1]];
}

export class BackgroundClasses_BackgroundAttachment extends CssRule {
    constructor(property) {
        super(property);
        this.property_1 = property;
    }
}

export function BackgroundClasses_BackgroundAttachment$reflection() {
    return class_type("Fss.Types.BackgroundClasses.BackgroundAttachment", void 0, BackgroundClasses_BackgroundAttachment, CssRule$reflection());
}

export function BackgroundClasses_BackgroundAttachment_$ctor_Z207A3CFB(property) {
    return new BackgroundClasses_BackgroundAttachment(property);
}

export function BackgroundClasses_BackgroundAttachment__value_Z2FA57D4F(this$, attachment) {
    const tupledArg = [this$.property_1, attachment];
    return [tupledArg[0], tupledArg[1]];
}

export function BackgroundClasses_BackgroundAttachment__get_scroll(this$) {
    const tupledArg = [this$.property_1, new Background_Attachment(0)];
    return [tupledArg[0], tupledArg[1]];
}

export function BackgroundClasses_BackgroundAttachment__get_fixed$0027(this$) {
    const tupledArg = [this$.property_1, new Background_Attachment(1)];
    return [tupledArg[0], tupledArg[1]];
}

export function BackgroundClasses_BackgroundAttachment__get_local(this$) {
    const tupledArg = [this$.property_1, new Background_Attachment(2)];
    return [tupledArg[0], tupledArg[1]];
}

export class BackgroundClasses_BackgroundColor extends ColorClass_Color {
    constructor(property) {
        super(property);
    }
}

export function BackgroundClasses_BackgroundColor$reflection() {
    return class_type("Fss.Types.BackgroundClasses.BackgroundColor", void 0, BackgroundClasses_BackgroundColor, ColorClass_Color$reflection());
}

export function BackgroundClasses_BackgroundColor_$ctor_Z207A3CFB(property) {
    return new BackgroundClasses_BackgroundColor(property);
}

export class BackgroundClasses_BackgroundImage extends ImageClasses_ImageClass {
    constructor(property) {
        super(property);
    }
}

export function BackgroundClasses_BackgroundImage$reflection() {
    return class_type("Fss.Types.BackgroundClasses.BackgroundImage", void 0, BackgroundClasses_BackgroundImage, ImageClasses_ImageClass$reflection());
}

export function BackgroundClasses_BackgroundImage_$ctor_Z207A3CFB(property) {
    return new BackgroundClasses_BackgroundImage(property);
}

export class BackgroundClasses_BackgroundPosition extends CssRule {
    constructor(property) {
        super(property);
        this.property_1 = property;
    }
}

export function BackgroundClasses_BackgroundPosition$reflection() {
    return class_type("Fss.Types.BackgroundClasses.BackgroundPosition", void 0, BackgroundClasses_BackgroundPosition, CssRule$reflection());
}

export function BackgroundClasses_BackgroundPosition_$ctor_Z207A3CFB(property) {
    return new BackgroundClasses_BackgroundPosition(property);
}

export function BackgroundClasses_BackgroundPosition__value_Z498FEB3B(this$, position) {
    const tupledArg = [this$.property_1, unitHelpers_lengthPercentageToType(position)];
    return [tupledArg[0], tupledArg[1]];
}

export function BackgroundClasses_BackgroundPosition__value_3202B9A0(this$, x, y) {
    const value = new String$(0, `${unitHelpers_lengthPercentageString(x)} ${unitHelpers_lengthPercentageString(y)}`);
    const tupledArg = [this$.property_1, value];
    return [tupledArg[0], tupledArg[1]];
}

export function BackgroundClasses_BackgroundPosition__value_Z3BD6069B(this$, x, y, offset) {
    const position = `${unitHelpers_lengthPercentageString(x)} ${unitHelpers_lengthPercentageString(y)} ${unitHelpers_lengthPercentageString(offset)}`;
    const tupledArg = [this$.property_1, new String$(0, position)];
    return [tupledArg[0], tupledArg[1]];
}

export function BackgroundClasses_BackgroundPosition__value_ZE6CD40(this$, x, y, xOffset, yOffset) {
    const position = `${unitHelpers_lengthPercentageString(x)} ${unitHelpers_lengthPercentageString(y)} ${unitHelpers_lengthPercentageString(xOffset)} ${unitHelpers_lengthPercentageString(yOffset)}`;
    const tupledArg = [this$.property_1, new String$(0, position)];
    return [tupledArg[0], tupledArg[1]];
}

export function BackgroundClasses_BackgroundPosition__get_top(this$) {
    const tupledArg = [this$.property_1, new String$(0, "top")];
    return [tupledArg[0], tupledArg[1]];
}

export function BackgroundClasses_BackgroundPosition__get_bottom(this$) {
    const tupledArg = [this$.property_1, new String$(0, "bottom")];
    return [tupledArg[0], tupledArg[1]];
}

export function BackgroundClasses_BackgroundPosition__get_left(this$) {
    const tupledArg = [this$.property_1, new String$(0, "left")];
    return [tupledArg[0], tupledArg[1]];
}

export function BackgroundClasses_BackgroundPosition__get_right(this$) {
    const tupledArg = [this$.property_1, new String$(0, "right")];
    return [tupledArg[0], tupledArg[1]];
}

export function BackgroundClasses_BackgroundPosition__get_center(this$) {
    const tupledArg = [this$.property_1, new String$(0, "center")];
    return [tupledArg[0], tupledArg[1]];
}

export class BackgroundClasses_BackgroundBlendMode extends CssRuleWithValueFunctions$1 {
    constructor(property) {
        super(property, ", ");
        this.property_2 = property;
    }
}

export function BackgroundClasses_BackgroundBlendMode$reflection() {
    return class_type("Fss.Types.BackgroundClasses.BackgroundBlendMode", void 0, BackgroundClasses_BackgroundBlendMode, CssRuleWithValueFunctions$1$reflection(Background_BlendMode$reflection()));
}

export function BackgroundClasses_BackgroundBlendMode_$ctor_Z207A3CFB(property) {
    return new BackgroundClasses_BackgroundBlendMode(property);
}

export function BackgroundClasses_BackgroundBlendMode__get_normal(this$) {
    const tupledArg = [this$.property_2, new Normal(0)];
    return [tupledArg[0], tupledArg[1]];
}

export function BackgroundClasses_BackgroundBlendMode__get_multiply(this$) {
    const tupledArg = [this$.property_2, new Background_BlendMode(0)];
    return [tupledArg[0], tupledArg[1]];
}

export function BackgroundClasses_BackgroundBlendMode__get_screen(this$) {
    const tupledArg = [this$.property_2, new Background_BlendMode(1)];
    return [tupledArg[0], tupledArg[1]];
}

export function BackgroundClasses_BackgroundBlendMode__get_overlay(this$) {
    const tupledArg = [this$.property_2, new Background_BlendMode(2)];
    return [tupledArg[0], tupledArg[1]];
}

export function BackgroundClasses_BackgroundBlendMode__get_darken(this$) {
    const tupledArg = [this$.property_2, new Background_BlendMode(3)];
    return [tupledArg[0], tupledArg[1]];
}

export function BackgroundClasses_BackgroundBlendMode__get_lighten(this$) {
    const tupledArg = [this$.property_2, new Background_BlendMode(4)];
    return [tupledArg[0], tupledArg[1]];
}

export function BackgroundClasses_BackgroundBlendMode__get_colorDodge(this$) {
    const tupledArg = [this$.property_2, new Background_BlendMode(5)];
    return [tupledArg[0], tupledArg[1]];
}

export function BackgroundClasses_BackgroundBlendMode__get_colorBurn(this$) {
    const tupledArg = [this$.property_2, new Background_BlendMode(6)];
    return [tupledArg[0], tupledArg[1]];
}

export function BackgroundClasses_BackgroundBlendMode__get_hardLight(this$) {
    const tupledArg = [this$.property_2, new Background_BlendMode(7)];
    return [tupledArg[0], tupledArg[1]];
}

export function BackgroundClasses_BackgroundBlendMode__get_softLight(this$) {
    const tupledArg = [this$.property_2, new Background_BlendMode(8)];
    return [tupledArg[0], tupledArg[1]];
}

export function BackgroundClasses_BackgroundBlendMode__get_difference(this$) {
    const tupledArg = [this$.property_2, new Background_BlendMode(9)];
    return [tupledArg[0], tupledArg[1]];
}

export function BackgroundClasses_BackgroundBlendMode__get_exclusion(this$) {
    const tupledArg = [this$.property_2, new Background_BlendMode(10)];
    return [tupledArg[0], tupledArg[1]];
}

export function BackgroundClasses_BackgroundBlendMode__get_hue(this$) {
    const tupledArg = [this$.property_2, new Background_BlendMode(11)];
    return [tupledArg[0], tupledArg[1]];
}

export function BackgroundClasses_BackgroundBlendMode__get_saturation(this$) {
    const tupledArg = [this$.property_2, new Background_BlendMode(12)];
    return [tupledArg[0], tupledArg[1]];
}

export function BackgroundClasses_BackgroundBlendMode__get_color(this$) {
    const tupledArg = [this$.property_2, new Background_BlendMode(13)];
    return [tupledArg[0], tupledArg[1]];
}

export function BackgroundClasses_BackgroundBlendMode__get_luminosity(this$) {
    const tupledArg = [this$.property_2, new Background_BlendMode(14)];
    return [tupledArg[0], tupledArg[1]];
}

export class BackgroundClasses_Isolation extends CssRuleWithAuto {
    constructor(property) {
        super(property);
        this.property_2 = property;
    }
}

export function BackgroundClasses_Isolation$reflection() {
    return class_type("Fss.Types.BackgroundClasses.Isolation", void 0, BackgroundClasses_Isolation, CssRuleWithAuto$reflection());
}

export function BackgroundClasses_Isolation_$ctor_Z207A3CFB(property) {
    return new BackgroundClasses_Isolation(property);
}

export function BackgroundClasses_Isolation__value_Z127CA194(this$, isolation) {
    const tupledArg = [this$.property_2, isolation];
    return [tupledArg[0], tupledArg[1]];
}

export function BackgroundClasses_Isolation__get_isolate(this$) {
    const tupledArg = [this$.property_2, new Background_Isolation(0)];
    return [tupledArg[0], tupledArg[1]];
}

export class BackgroundClasses_BoxDecorationBreak extends CssRule {
    constructor(property) {
        super(property);
        this.property_1 = property;
    }
}

export function BackgroundClasses_BoxDecorationBreak$reflection() {
    return class_type("Fss.Types.BackgroundClasses.BoxDecorationBreak", void 0, BackgroundClasses_BoxDecorationBreak, CssRule$reflection());
}

export function BackgroundClasses_BoxDecorationBreak_$ctor_Z207A3CFB(property) {
    return new BackgroundClasses_BoxDecorationBreak(property);
}

export function BackgroundClasses_BoxDecorationBreak__value_Z18D60A0(this$, decorationBreak) {
    const tupledArg = [this$.property_1, decorationBreak];
    return [tupledArg[0], tupledArg[1]];
}

export function BackgroundClasses_BoxDecorationBreak__get_slice(this$) {
    const tupledArg = [this$.property_1, new Background_BoxDecorationBreak(0)];
    return [tupledArg[0], tupledArg[1]];
}

export function BackgroundClasses_BoxDecorationBreak__get_clone(this$) {
    const tupledArg = [this$.property_1, new Background_BoxDecorationBreak(1)];
    return [tupledArg[0], tupledArg[1]];
}

//# sourceMappingURL=Background.fs.js.map
