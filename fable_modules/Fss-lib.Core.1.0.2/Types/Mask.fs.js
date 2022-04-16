import { Helpers_toKebabCase } from "../Utilities.fs.js";
import { toString, Union } from "../../fable-library.3.7.9/Types.js";
import { class_type, union_type } from "../../fable-library.3.7.9/Reflection.js";
import { String$, MasterTypeHelpers_stringifyICssValue, CssRule$reflection, CssRule } from "./MasterTypes.fs.js";
import { ImageClasses_ImageClass$reflection, ImageClasses_ImageClass } from "./Image.fs.js";
import { join } from "../../fable-library.3.7.9/String.js";
import { map } from "../../fable-library.3.7.9/List.js";
import { unitHelpers_CssRuleWithAutoLength$reflection, unitHelpers_CssRuleWithAutoLength, unitHelpers_lengthPercentageString } from "./Units.fs.js";

export class Mask_Clip extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["ContentBox", "PaddingBox", "BorderBox", "MarginBox", "FillBox", "StrokeBox", "ViewBox", "NoClip", "Border", "Padding", "Content", "Text"];
    }
    StringifyCss() {
        const this$ = this;
        return Helpers_toKebabCase(this$);
    }
}

export function Mask_Clip$reflection() {
    return union_type("Fss.Types.Mask.Clip", [], Mask_Clip, () => [[], [], [], [], [], [], [], [], [], [], [], []]);
}

export class Mask_Composite extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["Add", "Subtract", "Intersect", "Exclude"];
    }
    StringifyCss() {
        const this$ = this;
        return toString(this$).toLocaleLowerCase();
    }
}

export function Mask_Composite$reflection() {
    return union_type("Fss.Types.Mask.Composite", [], Mask_Composite, () => [[], [], [], []]);
}

export class Mask_Mode extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["Alpha", "Luminance", "MatchSource"];
    }
    StringifyCss() {
        const this$ = this;
        return Helpers_toKebabCase(this$);
    }
}

export function Mask_Mode$reflection() {
    return union_type("Fss.Types.Mask.Mode", [], Mask_Mode, () => [[], [], []]);
}

export class Mask_Origin extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["ContentBox", "PaddingBox", "BorderBox", "MarginBox", "FillBox", "StrokeBox", "ViewBox", "Content", "Padding", "Border"];
    }
    StringifyCss() {
        const this$ = this;
        return Helpers_toKebabCase(this$);
    }
}

export function Mask_Origin$reflection() {
    return union_type("Fss.Types.Mask.Origin", [], Mask_Origin, () => [[], [], [], [], [], [], [], [], [], []]);
}

export class Mask_Repeat extends Union {
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

export function Mask_Repeat$reflection() {
    return union_type("Fss.Types.Mask.Repeat", [], Mask_Repeat, () => [[], [], [], [], [], []]);
}

export class Mask_Size extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["Contain", "Cover"];
    }
    StringifyCss() {
        const this$ = this;
        return toString(this$).toLocaleLowerCase();
    }
}

export function Mask_Size$reflection() {
    return union_type("Fss.Types.Mask.Size", [], Mask_Size, () => [[], []]);
}

export class MaskClasses_MaskClip extends CssRule {
    constructor(property) {
        super(property);
        this.property_1 = property;
    }
}

export function MaskClasses_MaskClip$reflection() {
    return class_type("Fss.Types.MaskClasses.MaskClip", void 0, MaskClasses_MaskClip, CssRule$reflection());
}

export function MaskClasses_MaskClip_$ctor_Z207A3CFB(property) {
    return new MaskClasses_MaskClip(property);
}

export function MaskClasses_MaskClip__get_contentBox(this$) {
    const tupledArg = [this$.property_1, new Mask_Clip(0)];
    return [tupledArg[0], tupledArg[1]];
}

export function MaskClasses_MaskClip__get_paddingBox(this$) {
    const tupledArg = [this$.property_1, new Mask_Clip(1)];
    return [tupledArg[0], tupledArg[1]];
}

export function MaskClasses_MaskClip__get_borderBox(this$) {
    const tupledArg = [this$.property_1, new Mask_Clip(2)];
    return [tupledArg[0], tupledArg[1]];
}

export function MaskClasses_MaskClip__get_marginBox(this$) {
    const tupledArg = [this$.property_1, new Mask_Clip(3)];
    return [tupledArg[0], tupledArg[1]];
}

export function MaskClasses_MaskClip__get_fillBox(this$) {
    const tupledArg = [this$.property_1, new Mask_Clip(4)];
    return [tupledArg[0], tupledArg[1]];
}

export function MaskClasses_MaskClip__get_strokeBox(this$) {
    const tupledArg = [this$.property_1, new Mask_Clip(5)];
    return [tupledArg[0], tupledArg[1]];
}

export function MaskClasses_MaskClip__get_viewBox(this$) {
    const tupledArg = [this$.property_1, new Mask_Clip(6)];
    return [tupledArg[0], tupledArg[1]];
}

export function MaskClasses_MaskClip__get_noClip(this$) {
    const tupledArg = [this$.property_1, new Mask_Clip(7)];
    return [tupledArg[0], tupledArg[1]];
}

export function MaskClasses_MaskClip__get_border(this$) {
    const tupledArg = [this$.property_1, new Mask_Clip(8)];
    return [tupledArg[0], tupledArg[1]];
}

export function MaskClasses_MaskClip__get_padding(this$) {
    const tupledArg = [this$.property_1, new Mask_Clip(9)];
    return [tupledArg[0], tupledArg[1]];
}

export function MaskClasses_MaskClip__get_content(this$) {
    const tupledArg = [this$.property_1, new Mask_Clip(10)];
    return [tupledArg[0], tupledArg[1]];
}

export function MaskClasses_MaskClip__get_text(this$) {
    const tupledArg = [this$.property_1, new Mask_Clip(11)];
    return [tupledArg[0], tupledArg[1]];
}

export class MaskClasses_MaskComposite extends CssRule {
    constructor(property) {
        super(property);
        this.property_1 = property;
    }
}

export function MaskClasses_MaskComposite$reflection() {
    return class_type("Fss.Types.MaskClasses.MaskComposite", void 0, MaskClasses_MaskComposite, CssRule$reflection());
}

export function MaskClasses_MaskComposite_$ctor_Z207A3CFB(property) {
    return new MaskClasses_MaskComposite(property);
}

export function MaskClasses_MaskComposite__get_add(this$) {
    const tupledArg = [this$.property_1, new Mask_Composite(0)];
    return [tupledArg[0], tupledArg[1]];
}

export function MaskClasses_MaskComposite__get_subtract(this$) {
    const tupledArg = [this$.property_1, new Mask_Composite(1)];
    return [tupledArg[0], tupledArg[1]];
}

export function MaskClasses_MaskComposite__get_intersect(this$) {
    const tupledArg = [this$.property_1, new Mask_Composite(2)];
    return [tupledArg[0], tupledArg[1]];
}

export function MaskClasses_MaskComposite__get_exclude(this$) {
    const tupledArg = [this$.property_1, new Mask_Composite(3)];
    return [tupledArg[0], tupledArg[1]];
}

export class MaskClasses_MaskImage extends ImageClasses_ImageClass {
    constructor(property) {
        super(property);
    }
}

export function MaskClasses_MaskImage$reflection() {
    return class_type("Fss.Types.MaskClasses.MaskImage", void 0, MaskClasses_MaskImage, ImageClasses_ImageClass$reflection());
}

export function MaskClasses_MaskImage_$ctor_Z207A3CFB(property) {
    return new MaskClasses_MaskImage(property);
}

export class MaskClasses_MaskMode extends CssRule {
    constructor(property) {
        super(property);
        this.property_1 = property;
    }
}

export function MaskClasses_MaskMode$reflection() {
    return class_type("Fss.Types.MaskClasses.MaskMode", void 0, MaskClasses_MaskMode, CssRule$reflection());
}

export function MaskClasses_MaskMode_$ctor_Z207A3CFB(property) {
    return new MaskClasses_MaskMode(property);
}

export function MaskClasses_MaskMode__value_6243385B(this$, modes) {
    const value = join(", ", map(MasterTypeHelpers_stringifyICssValue, modes));
    const tupledArg = [this$.property_1, new String$(0, value)];
    return [tupledArg[0], tupledArg[1]];
}

export function MaskClasses_MaskMode__get_alpha(this$) {
    const tupledArg = [this$.property_1, new Mask_Mode(0)];
    return [tupledArg[0], tupledArg[1]];
}

export function MaskClasses_MaskMode__get_luminance(this$) {
    const tupledArg = [this$.property_1, new Mask_Mode(1)];
    return [tupledArg[0], tupledArg[1]];
}

export function MaskClasses_MaskMode__get_matchSource(this$) {
    const tupledArg = [this$.property_1, new Mask_Mode(2)];
    return [tupledArg[0], tupledArg[1]];
}

export class MaskClasses_MaskOrigin extends CssRule {
    constructor(property) {
        super(property);
        this.property_1 = property;
    }
}

export function MaskClasses_MaskOrigin$reflection() {
    return class_type("Fss.Types.MaskClasses.MaskOrigin", void 0, MaskClasses_MaskOrigin, CssRule$reflection());
}

export function MaskClasses_MaskOrigin_$ctor_Z207A3CFB(property) {
    return new MaskClasses_MaskOrigin(property);
}

export function MaskClasses_MaskOrigin__value_Z693C6BD4(this$, origins) {
    const value = join(", ", map(MasterTypeHelpers_stringifyICssValue, origins));
    const tupledArg = [this$.property_1, new String$(0, value)];
    return [tupledArg[0], tupledArg[1]];
}

export function MaskClasses_MaskOrigin__get_contentBox(this$) {
    const tupledArg = [this$.property_1, new Mask_Clip(0)];
    return [tupledArg[0], tupledArg[1]];
}

export function MaskClasses_MaskOrigin__get_paddingBox(this$) {
    const tupledArg = [this$.property_1, new Mask_Clip(1)];
    return [tupledArg[0], tupledArg[1]];
}

export function MaskClasses_MaskOrigin__get_borderBox(this$) {
    const tupledArg = [this$.property_1, new Mask_Clip(2)];
    return [tupledArg[0], tupledArg[1]];
}

export function MaskClasses_MaskOrigin__get_marginBox(this$) {
    const tupledArg = [this$.property_1, new Mask_Clip(3)];
    return [tupledArg[0], tupledArg[1]];
}

export function MaskClasses_MaskOrigin__get_fillBox(this$) {
    const tupledArg = [this$.property_1, new Mask_Clip(4)];
    return [tupledArg[0], tupledArg[1]];
}

export function MaskClasses_MaskOrigin__get_strokeBox(this$) {
    const tupledArg = [this$.property_1, new Mask_Clip(5)];
    return [tupledArg[0], tupledArg[1]];
}

export function MaskClasses_MaskOrigin__get_viewBox(this$) {
    const tupledArg = [this$.property_1, new Mask_Clip(6)];
    return [tupledArg[0], tupledArg[1]];
}

export function MaskClasses_MaskOrigin__get_content(this$) {
    const tupledArg = [this$.property_1, new Mask_Clip(10)];
    return [tupledArg[0], tupledArg[1]];
}

export function MaskClasses_MaskOrigin__get_padding(this$) {
    const tupledArg = [this$.property_1, new Mask_Clip(9)];
    return [tupledArg[0], tupledArg[1]];
}

export function MaskClasses_MaskOrigin__get_border(this$) {
    const tupledArg = [this$.property_1, new Mask_Clip(8)];
    return [tupledArg[0], tupledArg[1]];
}

export class MaskClasses_MaskPosition extends CssRule {
    constructor(property) {
        super(property);
        this.property_1 = property;
    }
}

export function MaskClasses_MaskPosition$reflection() {
    return class_type("Fss.Types.MaskClasses.MaskPosition", void 0, MaskClasses_MaskPosition, CssRule$reflection());
}

export function MaskClasses_MaskPosition_$ctor_Z207A3CFB(property) {
    return new MaskClasses_MaskPosition(property);
}

export function MaskClasses_MaskPosition__value_3202B9A0(this$, x, y) {
    const value = new String$(0, `${unitHelpers_lengthPercentageString(x)} ${unitHelpers_lengthPercentageString(y)}`);
    const tupledArg = [this$.property_1, value];
    return [tupledArg[0], tupledArg[1]];
}

export function MaskClasses_MaskPosition__value_431DAB45(this$, values) {
    const value = join(", ", map((tupledArg) => {
        const x = tupledArg[0];
        const y = tupledArg[1];
        return `${unitHelpers_lengthPercentageString(x)} ${unitHelpers_lengthPercentageString(y)}`;
    }, values));
    const tupledArg_1 = [this$.property_1, new String$(0, value)];
    return [tupledArg_1[0], tupledArg_1[1]];
}

export class MaskClasses_MaskRepeat extends CssRule {
    constructor(property) {
        super(property);
        this.property_1 = property;
    }
}

export function MaskClasses_MaskRepeat$reflection() {
    return class_type("Fss.Types.MaskClasses.MaskRepeat", void 0, MaskClasses_MaskRepeat, CssRule$reflection());
}

export function MaskClasses_MaskRepeat_$ctor_Z207A3CFB(property) {
    return new MaskClasses_MaskRepeat(property);
}

export function MaskClasses_MaskRepeat__value_25E8B8A0(this$, x, y) {
    const value = new String$(0, `${MasterTypeHelpers_stringifyICssValue(x)} ${MasterTypeHelpers_stringifyICssValue(y)}`);
    const tupledArg = [this$.property_1, value];
    return [tupledArg[0], tupledArg[1]];
}

export function MaskClasses_MaskRepeat__value_Z2A09893B(this$, values) {
    const value = join(", ", map((tupledArg) => {
        const x = tupledArg[0];
        const y = tupledArg[1];
        return `${MasterTypeHelpers_stringifyICssValue(x)} ${MasterTypeHelpers_stringifyICssValue(y)}`;
    }, values));
    const tupledArg_1 = [this$.property_1, new String$(0, value)];
    return [tupledArg_1[0], tupledArg_1[1]];
}

export function MaskClasses_MaskRepeat__get_repeatX(this$) {
    const tupledArg = [this$.property_1, new Mask_Repeat(0)];
    return [tupledArg[0], tupledArg[1]];
}

export function MaskClasses_MaskRepeat__get_repeatY(this$) {
    const tupledArg = [this$.property_1, new Mask_Repeat(1)];
    return [tupledArg[0], tupledArg[1]];
}

export function MaskClasses_MaskRepeat__get_repeat(this$) {
    const tupledArg = [this$.property_1, new Mask_Repeat(2)];
    return [tupledArg[0], tupledArg[1]];
}

export function MaskClasses_MaskRepeat__get_space(this$) {
    const tupledArg = [this$.property_1, new Mask_Repeat(3)];
    return [tupledArg[0], tupledArg[1]];
}

export function MaskClasses_MaskRepeat__get_round(this$) {
    const tupledArg = [this$.property_1, new Mask_Repeat(4)];
    return [tupledArg[0], tupledArg[1]];
}

export function MaskClasses_MaskRepeat__get_noRepeat(this$) {
    const tupledArg = [this$.property_1, new Mask_Repeat(5)];
    return [tupledArg[0], tupledArg[1]];
}

export class MaskClasses_MaskSize extends unitHelpers_CssRuleWithAutoLength {
    constructor(property) {
        super(property);
        this.property_3 = property;
    }
}

export function MaskClasses_MaskSize$reflection() {
    return class_type("Fss.Types.MaskClasses.MaskSize", void 0, MaskClasses_MaskSize, unitHelpers_CssRuleWithAutoLength$reflection());
}

export function MaskClasses_MaskSize_$ctor_Z207A3CFB(property) {
    return new MaskClasses_MaskSize(property);
}

export function MaskClasses_MaskSize__get_contain(this$) {
    const tupledArg = [this$.property_3, new Mask_Size(0)];
    return [tupledArg[0], tupledArg[1]];
}

export function MaskClasses_MaskSize__get_cover(this$) {
    const tupledArg = [this$.property_3, new Mask_Size(1)];
    return [tupledArg[0], tupledArg[1]];
}

export function MaskClasses_MaskSize__value_3202B9A0(this$, x, y) {
    const value = new String$(0, `${unitHelpers_lengthPercentageString(x)} ${unitHelpers_lengthPercentageString(y)}`);
    const tupledArg = [this$.property_3, value];
    return [tupledArg[0], tupledArg[1]];
}

export function MaskClasses_MaskSize__value_74C8A58F(this$, values) {
    const value = join(", ", map(unitHelpers_lengthPercentageString, values));
    const tupledArg = [this$.property_3, new String$(0, value)];
    return [tupledArg[0], tupledArg[1]];
}

//# sourceMappingURL=Mask.fs.js.map
