import { Helpers_toKebabCase } from "../Utilities.fs.js";
import { Union } from "../../fable-library.3.7.9/Types.js";
import { class_type, union_type } from "../../fable-library.3.7.9/Reflection.js";
import { Float, Int, CssRuleWithNormal$reflection, CssRuleWithNormal, CssRule$reflection, CssRule } from "./MasterTypes.fs.js";
import { unitHelpers_CssRuleWithAutoLength$reflection, unitHelpers_CssRuleWithAutoLength } from "./Units.fs.js";

export class Flex_AlignContent extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["Start", "End", "FlexStart", "FlexEnd", "Center", "Baseline", "FirstBaseline", "LastBaseline", "Stretch", "Safe", "Unsafe", "SpaceBetween", "SpaceAround", "SpaceEvenly"];
    }
    StringifyCss() {
        const this$ = this;
        return Helpers_toKebabCase(this$);
    }
}

export function Flex_AlignContent$reflection() {
    return union_type("Fss.Types.Flex.AlignContent", [], Flex_AlignContent, () => [[], [], [], [], [], [], [], [], [], [], [], [], [], []]);
}

export class Flex_AlignItems extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["Start", "End", "FlexStart", "FlexEnd", "Center", "Baseline", "FirstBaseline", "LastBaseline", "Stretch", "Safe", "Unsafe", "SelfStart", "SelfEnd"];
    }
    StringifyCss() {
        const this$ = this;
        return Helpers_toKebabCase(this$);
    }
}

export function Flex_AlignItems$reflection() {
    return union_type("Fss.Types.Flex.AlignItems", [], Flex_AlignItems, () => [[], [], [], [], [], [], [], [], [], [], [], [], []]);
}

export class Flex_AlignSelf extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["Start", "End", "FlexStart", "FlexEnd", "Center", "Baseline", "FirstBaseline", "LastBaseline", "Stretch", "Safe", "Unsafe", "SelfStart", "SelfEnd"];
    }
    StringifyCss() {
        const this$ = this;
        return Helpers_toKebabCase(this$);
    }
}

export function Flex_AlignSelf$reflection() {
    return union_type("Fss.Types.Flex.AlignSelf", [], Flex_AlignSelf, () => [[], [], [], [], [], [], [], [], [], [], [], [], []]);
}

export class Flex_JustifyContent extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["Start", "End", "FlexStart", "FlexEnd", "Center", "Baseline", "FirstBaseline", "LastBaseline", "Stretch", "Safe", "Unsafe", "SpaceBetween", "SpaceAround", "SpaceEvenly", "Left", "Right"];
    }
    StringifyCss() {
        const this$ = this;
        return Helpers_toKebabCase(this$);
    }
}

export function Flex_JustifyContent$reflection() {
    return union_type("Fss.Types.Flex.JustifyContent", [], Flex_JustifyContent, () => [[], [], [], [], [], [], [], [], [], [], [], [], [], [], [], []]);
}

export class Flex_JustifyItems extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["Start", "End", "FlexStart", "FlexEnd", "Center", "Baseline", "FirstBaseline", "LastBaseline", "Stretch", "Safe", "Unsafe", "Left", "Right", "SelfStart", "SelfEnd", "Legacy"];
    }
    StringifyCss() {
        const this$ = this;
        return Helpers_toKebabCase(this$);
    }
}

export function Flex_JustifyItems$reflection() {
    return union_type("Fss.Types.Flex.JustifyItems", [], Flex_JustifyItems, () => [[], [], [], [], [], [], [], [], [], [], [], [], [], [], [], []]);
}

export class Flex_JustifySelf extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["Start", "End", "FlexStart", "FlexEnd", "Center", "Baseline", "FirstBaseline", "LastBaseline", "Stretch", "Safe", "Unsafe", "SelfStart", "SelfEnd"];
    }
    StringifyCss() {
        const this$ = this;
        return Helpers_toKebabCase(this$);
    }
}

export function Flex_JustifySelf$reflection() {
    return union_type("Fss.Types.Flex.JustifySelf", [], Flex_JustifySelf, () => [[], [], [], [], [], [], [], [], [], [], [], [], []]);
}

export class Flex_Wrap extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["NoWrap", "Wrap", "WrapReverse"];
    }
    StringifyCss() {
        const this$ = this;
        return Helpers_toKebabCase(this$);
    }
}

export function Flex_Wrap$reflection() {
    return union_type("Fss.Types.Flex.Wrap", [], Flex_Wrap, () => [[], [], []]);
}

export class Flex_Direction extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["Row", "RowReverse", "Column", "ColumnReverse"];
    }
    StringifyCss() {
        const this$ = this;
        return Helpers_toKebabCase(this$);
    }
}

export function Flex_Direction$reflection() {
    return union_type("Fss.Types.Flex.Direction", [], Flex_Direction, () => [[], [], [], []]);
}

export class Flex_Basis extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["Fill", "MaxContent", "MinContent", "FitContent", "Content"];
    }
    StringifyCss() {
        const this$ = this;
        return Helpers_toKebabCase(this$);
    }
}

export function Flex_Basis$reflection() {
    return union_type("Fss.Types.Flex.Basis", [], Flex_Basis, () => [[], [], [], [], []]);
}

export class FlexClasses_FlexDirection extends CssRule {
    constructor(property) {
        super(property);
        this.property_1 = property;
    }
}

export function FlexClasses_FlexDirection$reflection() {
    return class_type("Fss.Types.FlexClasses.FlexDirection", void 0, FlexClasses_FlexDirection, CssRule$reflection());
}

export function FlexClasses_FlexDirection_$ctor_Z207A3CFB(property) {
    return new FlexClasses_FlexDirection(property);
}

export function FlexClasses_FlexDirection__value_784E2ED4(this$, direction) {
    const tupledArg = [this$.property_1, direction];
    return [tupledArg[0], tupledArg[1]];
}

export function FlexClasses_FlexDirection__get_row(this$) {
    const tupledArg = [this$.property_1, new Flex_Direction(0)];
    return [tupledArg[0], tupledArg[1]];
}

export function FlexClasses_FlexDirection__get_rowReverse(this$) {
    const tupledArg = [this$.property_1, new Flex_Direction(1)];
    return [tupledArg[0], tupledArg[1]];
}

export function FlexClasses_FlexDirection__get_column(this$) {
    const tupledArg = [this$.property_1, new Flex_Direction(2)];
    return [tupledArg[0], tupledArg[1]];
}

export function FlexClasses_FlexDirection__get_columnReverse(this$) {
    const tupledArg = [this$.property_1, new Flex_Direction(3)];
    return [tupledArg[0], tupledArg[1]];
}

export class FlexClasses_FlexWrap extends CssRule {
    constructor(property) {
        super(property);
        this.property_1 = property;
    }
}

export function FlexClasses_FlexWrap$reflection() {
    return class_type("Fss.Types.FlexClasses.FlexWrap", void 0, FlexClasses_FlexWrap, CssRule$reflection());
}

export function FlexClasses_FlexWrap_$ctor_Z207A3CFB(property) {
    return new FlexClasses_FlexWrap(property);
}

export function FlexClasses_FlexWrap__value_59243825(this$, wrap) {
    const tupledArg = [this$.property_1, wrap];
    return [tupledArg[0], tupledArg[1]];
}

export function FlexClasses_FlexWrap__get_noWrap(this$) {
    const tupledArg = [this$.property_1, new Flex_Wrap(0)];
    return [tupledArg[0], tupledArg[1]];
}

export function FlexClasses_FlexWrap__get_wrap(this$) {
    const tupledArg = [this$.property_1, new Flex_Wrap(1)];
    return [tupledArg[0], tupledArg[1]];
}

export function FlexClasses_FlexWrap__get_wrapReverse(this$) {
    const tupledArg = [this$.property_1, new Flex_Wrap(2)];
    return [tupledArg[0], tupledArg[1]];
}

export class FlexClasses_FlexBasis extends unitHelpers_CssRuleWithAutoLength {
    constructor(property) {
        super(property);
        this.property_3 = property;
    }
}

export function FlexClasses_FlexBasis$reflection() {
    return class_type("Fss.Types.FlexClasses.FlexBasis", void 0, FlexClasses_FlexBasis, unitHelpers_CssRuleWithAutoLength$reflection());
}

export function FlexClasses_FlexBasis_$ctor_Z207A3CFB(property) {
    return new FlexClasses_FlexBasis(property);
}

export function FlexClasses_FlexBasis__get_fill(this$) {
    const tupledArg = [this$.property_3, new Flex_Basis(0)];
    return [tupledArg[0], tupledArg[1]];
}

export function FlexClasses_FlexBasis__get_maxContent(this$) {
    const tupledArg = [this$.property_3, new Flex_Basis(1)];
    return [tupledArg[0], tupledArg[1]];
}

export function FlexClasses_FlexBasis__get_minContent(this$) {
    const tupledArg = [this$.property_3, new Flex_Basis(2)];
    return [tupledArg[0], tupledArg[1]];
}

export function FlexClasses_FlexBasis__get_fitContent(this$) {
    const tupledArg = [this$.property_3, new Flex_Basis(3)];
    return [tupledArg[0], tupledArg[1]];
}

export function FlexClasses_FlexBasis__get_content(this$) {
    const tupledArg = [this$.property_3, new Flex_Basis(4)];
    return [tupledArg[0], tupledArg[1]];
}

export class FlexClasses_JustifyContent extends CssRuleWithNormal {
    constructor(property) {
        super(property);
        this.property_2 = property;
    }
}

export function FlexClasses_JustifyContent$reflection() {
    return class_type("Fss.Types.FlexClasses.JustifyContent", void 0, FlexClasses_JustifyContent, CssRuleWithNormal$reflection());
}

export function FlexClasses_JustifyContent_$ctor_Z207A3CFB(property) {
    return new FlexClasses_JustifyContent(property);
}

export function FlexClasses_JustifyContent__get_start(this$) {
    const tupledArg = [this$.property_2, new Flex_JustifyContent(0)];
    return [tupledArg[0], tupledArg[1]];
}

export function FlexClasses_JustifyContent__get_end$0027(this$) {
    const tupledArg = [this$.property_2, new Flex_JustifyContent(1)];
    return [tupledArg[0], tupledArg[1]];
}

export function FlexClasses_JustifyContent__get_flexStart(this$) {
    const tupledArg = [this$.property_2, new Flex_JustifyContent(2)];
    return [tupledArg[0], tupledArg[1]];
}

export function FlexClasses_JustifyContent__get_flexEnd(this$) {
    const tupledArg = [this$.property_2, new Flex_JustifyContent(3)];
    return [tupledArg[0], tupledArg[1]];
}

export function FlexClasses_JustifyContent__get_center(this$) {
    const tupledArg = [this$.property_2, new Flex_JustifyContent(4)];
    return [tupledArg[0], tupledArg[1]];
}

export function FlexClasses_JustifyContent__get_baseline(this$) {
    const tupledArg = [this$.property_2, new Flex_JustifyContent(5)];
    return [tupledArg[0], tupledArg[1]];
}

export function FlexClasses_JustifyContent__get_firstBaseline(this$) {
    const tupledArg = [this$.property_2, new Flex_JustifyContent(6)];
    return [tupledArg[0], tupledArg[1]];
}

export function FlexClasses_JustifyContent__get_lastBaseline(this$) {
    const tupledArg = [this$.property_2, new Flex_JustifyContent(7)];
    return [tupledArg[0], tupledArg[1]];
}

export function FlexClasses_JustifyContent__get_stretch(this$) {
    const tupledArg = [this$.property_2, new Flex_JustifyContent(8)];
    return [tupledArg[0], tupledArg[1]];
}

export function FlexClasses_JustifyContent__get_safe(this$) {
    const tupledArg = [this$.property_2, new Flex_JustifyContent(9)];
    return [tupledArg[0], tupledArg[1]];
}

export function FlexClasses_JustifyContent__get_unsafe(this$) {
    const tupledArg = [this$.property_2, new Flex_JustifyContent(10)];
    return [tupledArg[0], tupledArg[1]];
}

export function FlexClasses_JustifyContent__get_spaceBetween(this$) {
    const tupledArg = [this$.property_2, new Flex_JustifyContent(11)];
    return [tupledArg[0], tupledArg[1]];
}

export function FlexClasses_JustifyContent__get_spaceAround(this$) {
    const tupledArg = [this$.property_2, new Flex_JustifyContent(12)];
    return [tupledArg[0], tupledArg[1]];
}

export function FlexClasses_JustifyContent__get_spaceEvenly(this$) {
    const tupledArg = [this$.property_2, new Flex_JustifyContent(13)];
    return [tupledArg[0], tupledArg[1]];
}

export function FlexClasses_JustifyContent__get_left(this$) {
    const tupledArg = [this$.property_2, new Flex_JustifyContent(14)];
    return [tupledArg[0], tupledArg[1]];
}

export function FlexClasses_JustifyContent__get_right(this$) {
    const tupledArg = [this$.property_2, new Flex_JustifyContent(15)];
    return [tupledArg[0], tupledArg[1]];
}

export class FlexClasses_JustifySelf extends CssRuleWithNormal {
    constructor(property) {
        super(property);
        this.property_2 = property;
    }
}

export function FlexClasses_JustifySelf$reflection() {
    return class_type("Fss.Types.FlexClasses.JustifySelf", void 0, FlexClasses_JustifySelf, CssRuleWithNormal$reflection());
}

export function FlexClasses_JustifySelf_$ctor_Z207A3CFB(property) {
    return new FlexClasses_JustifySelf(property);
}

export function FlexClasses_JustifySelf__get_start(this$) {
    const tupledArg = [this$.property_2, new Flex_JustifySelf(0)];
    return [tupledArg[0], tupledArg[1]];
}

export function FlexClasses_JustifySelf__get_end$0027(this$) {
    const tupledArg = [this$.property_2, new Flex_JustifySelf(1)];
    return [tupledArg[0], tupledArg[1]];
}

export function FlexClasses_JustifySelf__get_flexStart(this$) {
    const tupledArg = [this$.property_2, new Flex_JustifySelf(2)];
    return [tupledArg[0], tupledArg[1]];
}

export function FlexClasses_JustifySelf__get_flexEnd(this$) {
    const tupledArg = [this$.property_2, new Flex_JustifySelf(3)];
    return [tupledArg[0], tupledArg[1]];
}

export function FlexClasses_JustifySelf__get_center(this$) {
    const tupledArg = [this$.property_2, new Flex_JustifySelf(4)];
    return [tupledArg[0], tupledArg[1]];
}

export function FlexClasses_JustifySelf__get_baseline(this$) {
    const tupledArg = [this$.property_2, new Flex_JustifySelf(5)];
    return [tupledArg[0], tupledArg[1]];
}

export function FlexClasses_JustifySelf__get_firstBaseline(this$) {
    const tupledArg = [this$.property_2, new Flex_JustifySelf(6)];
    return [tupledArg[0], tupledArg[1]];
}

export function FlexClasses_JustifySelf__get_lastBaseline(this$) {
    const tupledArg = [this$.property_2, new Flex_JustifySelf(7)];
    return [tupledArg[0], tupledArg[1]];
}

export function FlexClasses_JustifySelf__get_stretch(this$) {
    const tupledArg = [this$.property_2, new Flex_JustifySelf(8)];
    return [tupledArg[0], tupledArg[1]];
}

export function FlexClasses_JustifySelf__get_safe(this$) {
    const tupledArg = [this$.property_2, new Flex_JustifySelf(9)];
    return [tupledArg[0], tupledArg[1]];
}

export function FlexClasses_JustifySelf__get_unsafe(this$) {
    const tupledArg = [this$.property_2, new Flex_JustifySelf(10)];
    return [tupledArg[0], tupledArg[1]];
}

export function FlexClasses_JustifySelf__get_selfStart(this$) {
    const tupledArg = [this$.property_2, new Flex_JustifySelf(11)];
    return [tupledArg[0], tupledArg[1]];
}

export function FlexClasses_JustifySelf__get_selfEnd(this$) {
    const tupledArg = [this$.property_2, new Flex_JustifySelf(12)];
    return [tupledArg[0], tupledArg[1]];
}

export class FlexClasses_JustifyItems extends CssRuleWithNormal {
    constructor(property) {
        super(property);
        this.property_2 = property;
    }
}

export function FlexClasses_JustifyItems$reflection() {
    return class_type("Fss.Types.FlexClasses.JustifyItems", void 0, FlexClasses_JustifyItems, CssRuleWithNormal$reflection());
}

export function FlexClasses_JustifyItems_$ctor_Z207A3CFB(property) {
    return new FlexClasses_JustifyItems(property);
}

export function FlexClasses_JustifyItems__get_start(this$) {
    const tupledArg = [this$.property_2, new Flex_JustifyItems(0)];
    return [tupledArg[0], tupledArg[1]];
}

export function FlexClasses_JustifyItems__get_end$0027(this$) {
    const tupledArg = [this$.property_2, new Flex_JustifyItems(1)];
    return [tupledArg[0], tupledArg[1]];
}

export function FlexClasses_JustifyItems__get_flexStart(this$) {
    const tupledArg = [this$.property_2, new Flex_JustifyItems(2)];
    return [tupledArg[0], tupledArg[1]];
}

export function FlexClasses_JustifyItems__get_flexEnd(this$) {
    const tupledArg = [this$.property_2, new Flex_JustifyItems(3)];
    return [tupledArg[0], tupledArg[1]];
}

export function FlexClasses_JustifyItems__get_center(this$) {
    const tupledArg = [this$.property_2, new Flex_JustifyItems(4)];
    return [tupledArg[0], tupledArg[1]];
}

export function FlexClasses_JustifyItems__get_baseline(this$) {
    const tupledArg = [this$.property_2, new Flex_JustifyItems(5)];
    return [tupledArg[0], tupledArg[1]];
}

export function FlexClasses_JustifyItems__get_firstBaseline(this$) {
    const tupledArg = [this$.property_2, new Flex_JustifyItems(6)];
    return [tupledArg[0], tupledArg[1]];
}

export function FlexClasses_JustifyItems__get_lastBaseline(this$) {
    const tupledArg = [this$.property_2, new Flex_JustifyItems(7)];
    return [tupledArg[0], tupledArg[1]];
}

export function FlexClasses_JustifyItems__get_stretch(this$) {
    const tupledArg = [this$.property_2, new Flex_JustifyItems(8)];
    return [tupledArg[0], tupledArg[1]];
}

export function FlexClasses_JustifyItems__get_safe(this$) {
    const tupledArg = [this$.property_2, new Flex_JustifyItems(9)];
    return [tupledArg[0], tupledArg[1]];
}

export function FlexClasses_JustifyItems__get_unsafe(this$) {
    const tupledArg = [this$.property_2, new Flex_JustifyItems(10)];
    return [tupledArg[0], tupledArg[1]];
}

export function FlexClasses_JustifyItems__get_left(this$) {
    const tupledArg = [this$.property_2, new Flex_JustifyItems(11)];
    return [tupledArg[0], tupledArg[1]];
}

export function FlexClasses_JustifyItems__get_right(this$) {
    const tupledArg = [this$.property_2, new Flex_JustifyItems(12)];
    return [tupledArg[0], tupledArg[1]];
}

export function FlexClasses_JustifyItems__get_selfStart(this$) {
    const tupledArg = [this$.property_2, new Flex_JustifyItems(13)];
    return [tupledArg[0], tupledArg[1]];
}

export function FlexClasses_JustifyItems__get_selfEnd(this$) {
    const tupledArg = [this$.property_2, new Flex_JustifyItems(14)];
    return [tupledArg[0], tupledArg[1]];
}

export function FlexClasses_JustifyItems__get_legacy(this$) {
    const tupledArg = [this$.property_2, new Flex_JustifyItems(15)];
    return [tupledArg[0], tupledArg[1]];
}

export class FlexClasses_AlignSelf extends CssRuleWithNormal {
    constructor(property) {
        super(property);
        this.property_2 = property;
    }
}

export function FlexClasses_AlignSelf$reflection() {
    return class_type("Fss.Types.FlexClasses.AlignSelf", void 0, FlexClasses_AlignSelf, CssRuleWithNormal$reflection());
}

export function FlexClasses_AlignSelf_$ctor_Z207A3CFB(property) {
    return new FlexClasses_AlignSelf(property);
}

export function FlexClasses_AlignSelf__get_start(this$) {
    const tupledArg = [this$.property_2, new Flex_AlignSelf(0)];
    return [tupledArg[0], tupledArg[1]];
}

export function FlexClasses_AlignSelf__get_end$0027(this$) {
    const tupledArg = [this$.property_2, new Flex_AlignSelf(1)];
    return [tupledArg[0], tupledArg[1]];
}

export function FlexClasses_AlignSelf__get_flexStart(this$) {
    const tupledArg = [this$.property_2, new Flex_AlignSelf(2)];
    return [tupledArg[0], tupledArg[1]];
}

export function FlexClasses_AlignSelf__get_flexEnd(this$) {
    const tupledArg = [this$.property_2, new Flex_AlignSelf(3)];
    return [tupledArg[0], tupledArg[1]];
}

export function FlexClasses_AlignSelf__get_center(this$) {
    const tupledArg = [this$.property_2, new Flex_AlignSelf(4)];
    return [tupledArg[0], tupledArg[1]];
}

export function FlexClasses_AlignSelf__get_baseline(this$) {
    const tupledArg = [this$.property_2, new Flex_AlignSelf(5)];
    return [tupledArg[0], tupledArg[1]];
}

export function FlexClasses_AlignSelf__get_firstBaseline(this$) {
    const tupledArg = [this$.property_2, new Flex_AlignSelf(6)];
    return [tupledArg[0], tupledArg[1]];
}

export function FlexClasses_AlignSelf__get_lastBaseline(this$) {
    const tupledArg = [this$.property_2, new Flex_AlignSelf(7)];
    return [tupledArg[0], tupledArg[1]];
}

export function FlexClasses_AlignSelf__get_stretch(this$) {
    const tupledArg = [this$.property_2, new Flex_AlignSelf(8)];
    return [tupledArg[0], tupledArg[1]];
}

export function FlexClasses_AlignSelf__get_safe(this$) {
    const tupledArg = [this$.property_2, new Flex_AlignSelf(9)];
    return [tupledArg[0], tupledArg[1]];
}

export function FlexClasses_AlignSelf__get_unsafe(this$) {
    const tupledArg = [this$.property_2, new Flex_AlignSelf(10)];
    return [tupledArg[0], tupledArg[1]];
}

export function FlexClasses_AlignSelf__get_selfStart(this$) {
    const tupledArg = [this$.property_2, new Flex_AlignSelf(11)];
    return [tupledArg[0], tupledArg[1]];
}

export function FlexClasses_AlignSelf__get_selfEnd(this$) {
    const tupledArg = [this$.property_2, new Flex_AlignSelf(12)];
    return [tupledArg[0], tupledArg[1]];
}

export class FlexClasses_AlignItems extends CssRuleWithNormal {
    constructor(property) {
        super(property);
        this.property_2 = property;
    }
}

export function FlexClasses_AlignItems$reflection() {
    return class_type("Fss.Types.FlexClasses.AlignItems", void 0, FlexClasses_AlignItems, CssRuleWithNormal$reflection());
}

export function FlexClasses_AlignItems_$ctor_Z207A3CFB(property) {
    return new FlexClasses_AlignItems(property);
}

export function FlexClasses_AlignItems__get_start(this$) {
    const tupledArg = [this$.property_2, new Flex_AlignItems(0)];
    return [tupledArg[0], tupledArg[1]];
}

export function FlexClasses_AlignItems__get_end$0027(this$) {
    const tupledArg = [this$.property_2, new Flex_AlignItems(1)];
    return [tupledArg[0], tupledArg[1]];
}

export function FlexClasses_AlignItems__get_flexStart(this$) {
    const tupledArg = [this$.property_2, new Flex_AlignItems(2)];
    return [tupledArg[0], tupledArg[1]];
}

export function FlexClasses_AlignItems__get_flexEnd(this$) {
    const tupledArg = [this$.property_2, new Flex_AlignItems(3)];
    return [tupledArg[0], tupledArg[1]];
}

export function FlexClasses_AlignItems__get_center(this$) {
    const tupledArg = [this$.property_2, new Flex_AlignItems(4)];
    return [tupledArg[0], tupledArg[1]];
}

export function FlexClasses_AlignItems__get_baseline(this$) {
    const tupledArg = [this$.property_2, new Flex_AlignItems(5)];
    return [tupledArg[0], tupledArg[1]];
}

export function FlexClasses_AlignItems__get_firstBaseline(this$) {
    const tupledArg = [this$.property_2, new Flex_AlignItems(6)];
    return [tupledArg[0], tupledArg[1]];
}

export function FlexClasses_AlignItems__get_lastBaseline(this$) {
    const tupledArg = [this$.property_2, new Flex_AlignItems(7)];
    return [tupledArg[0], tupledArg[1]];
}

export function FlexClasses_AlignItems__get_stretch(this$) {
    const tupledArg = [this$.property_2, new Flex_AlignItems(8)];
    return [tupledArg[0], tupledArg[1]];
}

export function FlexClasses_AlignItems__get_safe(this$) {
    const tupledArg = [this$.property_2, new Flex_AlignItems(9)];
    return [tupledArg[0], tupledArg[1]];
}

export function FlexClasses_AlignItems__get_unsafe(this$) {
    const tupledArg = [this$.property_2, new Flex_AlignItems(10)];
    return [tupledArg[0], tupledArg[1]];
}

export function FlexClasses_AlignItems__get_selfStart(this$) {
    const tupledArg = [this$.property_2, new Flex_AlignItems(11)];
    return [tupledArg[0], tupledArg[1]];
}

export function FlexClasses_AlignItems__get_selfEnd(this$) {
    const tupledArg = [this$.property_2, new Flex_AlignItems(12)];
    return [tupledArg[0], tupledArg[1]];
}

export class FlexClasses_AlignContent extends CssRuleWithNormal {
    constructor(property) {
        super(property);
        this.property_2 = property;
    }
}

export function FlexClasses_AlignContent$reflection() {
    return class_type("Fss.Types.FlexClasses.AlignContent", void 0, FlexClasses_AlignContent, CssRuleWithNormal$reflection());
}

export function FlexClasses_AlignContent_$ctor_Z207A3CFB(property) {
    return new FlexClasses_AlignContent(property);
}

export function FlexClasses_AlignContent__get_start(this$) {
    const tupledArg = [this$.property_2, new Flex_AlignContent(0)];
    return [tupledArg[0], tupledArg[1]];
}

export function FlexClasses_AlignContent__get_end$0027(this$) {
    const tupledArg = [this$.property_2, new Flex_AlignContent(1)];
    return [tupledArg[0], tupledArg[1]];
}

export function FlexClasses_AlignContent__get_flexStart(this$) {
    const tupledArg = [this$.property_2, new Flex_AlignContent(2)];
    return [tupledArg[0], tupledArg[1]];
}

export function FlexClasses_AlignContent__get_flexEnd(this$) {
    const tupledArg = [this$.property_2, new Flex_AlignContent(3)];
    return [tupledArg[0], tupledArg[1]];
}

export function FlexClasses_AlignContent__get_center(this$) {
    const tupledArg = [this$.property_2, new Flex_AlignContent(4)];
    return [tupledArg[0], tupledArg[1]];
}

export function FlexClasses_AlignContent__get_baseline(this$) {
    const tupledArg = [this$.property_2, new Flex_AlignContent(5)];
    return [tupledArg[0], tupledArg[1]];
}

export function FlexClasses_AlignContent__get_firstBaseline(this$) {
    const tupledArg = [this$.property_2, new Flex_AlignContent(6)];
    return [tupledArg[0], tupledArg[1]];
}

export function FlexClasses_AlignContent__get_lastBaseline(this$) {
    const tupledArg = [this$.property_2, new Flex_AlignContent(7)];
    return [tupledArg[0], tupledArg[1]];
}

export function FlexClasses_AlignContent__get_stretch(this$) {
    const tupledArg = [this$.property_2, new Flex_AlignContent(8)];
    return [tupledArg[0], tupledArg[1]];
}

export function FlexClasses_AlignContent__get_safe(this$) {
    const tupledArg = [this$.property_2, new Flex_AlignContent(9)];
    return [tupledArg[0], tupledArg[1]];
}

export function FlexClasses_AlignContent__get_unsafe(this$) {
    const tupledArg = [this$.property_2, new Flex_AlignContent(10)];
    return [tupledArg[0], tupledArg[1]];
}

export function FlexClasses_AlignContent__get_spaceBetween(this$) {
    const tupledArg = [this$.property_2, new Flex_AlignContent(11)];
    return [tupledArg[0], tupledArg[1]];
}

export function FlexClasses_AlignContent__get_spaceAround(this$) {
    const tupledArg = [this$.property_2, new Flex_AlignContent(12)];
    return [tupledArg[0], tupledArg[1]];
}

export function FlexClasses_AlignContent__get_spaceEvenly(this$) {
    const tupledArg = [this$.property_2, new Flex_AlignContent(13)];
    return [tupledArg[0], tupledArg[1]];
}

export class FlexClasses_Order extends CssRule {
    constructor(property) {
        super(property);
        this.property_1 = property;
    }
}

export function FlexClasses_Order$reflection() {
    return class_type("Fss.Types.FlexClasses.Order", void 0, FlexClasses_Order, CssRule$reflection());
}

export function FlexClasses_Order_$ctor_Z207A3CFB(property) {
    return new FlexClasses_Order(property);
}

export function FlexClasses_Order__value_Z524259A4(this$, order) {
    const tupledArg = [this$.property_1, new Int(0, order)];
    return [tupledArg[0], tupledArg[1]];
}

export class FlexClasses_FlexShrinkGrow extends CssRule {
    constructor(property) {
        super(property);
        this.property_1 = property;
    }
}

export function FlexClasses_FlexShrinkGrow$reflection() {
    return class_type("Fss.Types.FlexClasses.FlexShrinkGrow", void 0, FlexClasses_FlexShrinkGrow, CssRule$reflection());
}

export function FlexClasses_FlexShrinkGrow_$ctor_Z207A3CFB(property) {
    return new FlexClasses_FlexShrinkGrow(property);
}

export function FlexClasses_FlexShrinkGrow__value_5E38073B(this$, grow) {
    const tupledArg = [this$.property_1, new Float(0, grow)];
    return [tupledArg[0], tupledArg[1]];
}

//# sourceMappingURL=Flex.fs.js.map
