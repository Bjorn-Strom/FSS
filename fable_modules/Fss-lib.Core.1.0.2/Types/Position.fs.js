import { Union, toString } from "../../fable-library.3.7.9/Types.js";
import { class_type, union_type } from "../../fable-library.3.7.9/Reflection.js";
import { Helpers_toKebabCase } from "../Utilities.fs.js";
import { CssRuleWithAuto$reflection, CssRuleWithAuto, CssRuleWithNone$reflection, CssRuleWithNone, CssRule$reflection, CssRule } from "./MasterTypes.fs.js";
import { unitHelpers_CssRuleWithLength$reflection, unitHelpers_CssRuleWithLength, unitHelpers_CssRuleWithAutoLength$reflection, unitHelpers_CssRuleWithAutoLength } from "./Units.fs.js";

export class Position_Position extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["Static", "Relative", "Absolute", "Sticky", "Fixed"];
    }
    StringifyCss() {
        const this$ = this;
        return toString(this$).toLocaleLowerCase();
    }
}

export function Position_Position$reflection() {
    return union_type("Fss.Types.Position.Position", [], Position_Position, () => [[], [], [], [], []]);
}

export class Position_VerticalAlign extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["Baseline", "Sub", "Super", "TextTop", "TextBottom", "Middle", "Top", "Bottom"];
    }
    StringifyCss() {
        const this$ = this;
        return Helpers_toKebabCase(this$);
    }
}

export function Position_VerticalAlign$reflection() {
    return union_type("Fss.Types.Position.VerticalAlign", [], Position_VerticalAlign, () => [[], [], [], [], [], [], [], []]);
}

export class Position_Float extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["Left", "Right", "InlineStart", "InlineEnd"];
    }
    StringifyCss() {
        const this$ = this;
        return Helpers_toKebabCase(this$);
    }
}

export function Position_Float$reflection() {
    return union_type("Fss.Types.Position.Float", [], Position_Float, () => [[], [], [], []]);
}

export class Position_BoxSizing extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["ContentBox", "BorderBox"];
    }
    StringifyCss() {
        const this$ = this;
        return Helpers_toKebabCase(this$);
    }
}

export function Position_BoxSizing$reflection() {
    return union_type("Fss.Types.Position.BoxSizing", [], Position_BoxSizing, () => [[], []]);
}

export class Position_Direction extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["Rtl", "Ltr"];
    }
    StringifyCss() {
        const this$ = this;
        return toString(this$).toLocaleLowerCase();
    }
}

export function Position_Direction$reflection() {
    return union_type("Fss.Types.Position.Direction", [], Position_Direction, () => [[], []]);
}

export class Position_Break extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["Avoid", "Always", "All", "AvoidPage", "Page", "Left", "Right", "Recto", "Verso", "AvoidColumn", "Column", "AvoidRegion", "Region"];
    }
    StringifyCss() {
        const this$ = this;
        return Helpers_toKebabCase(this$);
    }
}

export function Position_Break$reflection() {
    return union_type("Fss.Types.Position.Break", [], Position_Break, () => [[], [], [], [], [], [], [], [], [], [], [], [], []]);
}

export class Position_BreakInside extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["Avoid", "AvoidPage", "AvoidColumn", "AvoidRegion"];
    }
    StringifyCss() {
        const this$ = this;
        return Helpers_toKebabCase(this$);
    }
}

export function Position_BreakInside$reflection() {
    return union_type("Fss.Types.Position.BreakInside", [], Position_BreakInside, () => [[], [], [], []]);
}

export class PositionClasses_Position extends CssRule {
    constructor(property) {
        super(property);
        this.property_1 = property;
    }
}

export function PositionClasses_Position$reflection() {
    return class_type("Fss.Types.PositionClasses.Position", void 0, PositionClasses_Position, CssRule$reflection());
}

export function PositionClasses_Position_$ctor_Z207A3CFB(property) {
    return new PositionClasses_Position(property);
}

export function PositionClasses_Position__get_static$0027(this$) {
    const tupledArg = [this$.property_1, new Position_Position(0)];
    return [tupledArg[0], tupledArg[1]];
}

export function PositionClasses_Position__get_relative(this$) {
    const tupledArg = [this$.property_1, new Position_Position(1)];
    return [tupledArg[0], tupledArg[1]];
}

export function PositionClasses_Position__get_absolute(this$) {
    const tupledArg = [this$.property_1, new Position_Position(2)];
    return [tupledArg[0], tupledArg[1]];
}

export function PositionClasses_Position__get_sticky(this$) {
    const tupledArg = [this$.property_1, new Position_Position(3)];
    return [tupledArg[0], tupledArg[1]];
}

export function PositionClasses_Position__get_fixed$0027(this$) {
    const tupledArg = [this$.property_1, new Position_Position(4)];
    return [tupledArg[0], tupledArg[1]];
}

export class PositionClasses_TopRightBottomLeft extends unitHelpers_CssRuleWithAutoLength {
    constructor(property) {
        super(property);
    }
}

export function PositionClasses_TopRightBottomLeft$reflection() {
    return class_type("Fss.Types.PositionClasses.TopRightBottomLeft", void 0, PositionClasses_TopRightBottomLeft, unitHelpers_CssRuleWithAutoLength$reflection());
}

export function PositionClasses_TopRightBottomLeft_$ctor_Z207A3CFB(property) {
    return new PositionClasses_TopRightBottomLeft(property);
}

export class PositionClasses_VerticalAlign extends unitHelpers_CssRuleWithLength {
    constructor(property) {
        super(property);
        this.property_2 = property;
    }
}

export function PositionClasses_VerticalAlign$reflection() {
    return class_type("Fss.Types.PositionClasses.VerticalAlign", void 0, PositionClasses_VerticalAlign, unitHelpers_CssRuleWithLength$reflection());
}

export function PositionClasses_VerticalAlign_$ctor_Z207A3CFB(property) {
    return new PositionClasses_VerticalAlign(property);
}

export function PositionClasses_VerticalAlign__get_baseline(this$) {
    const tupledArg = [this$.property_2, new Position_VerticalAlign(0)];
    return [tupledArg[0], tupledArg[1]];
}

export function PositionClasses_VerticalAlign__get_sub(this$) {
    const tupledArg = [this$.property_2, new Position_VerticalAlign(1)];
    return [tupledArg[0], tupledArg[1]];
}

export function PositionClasses_VerticalAlign__get_super(this$) {
    const tupledArg = [this$.property_2, new Position_VerticalAlign(2)];
    return [tupledArg[0], tupledArg[1]];
}

export function PositionClasses_VerticalAlign__get_textTop(this$) {
    const tupledArg = [this$.property_2, new Position_VerticalAlign(3)];
    return [tupledArg[0], tupledArg[1]];
}

export function PositionClasses_VerticalAlign__get_textBottom(this$) {
    const tupledArg = [this$.property_2, new Position_VerticalAlign(4)];
    return [tupledArg[0], tupledArg[1]];
}

export function PositionClasses_VerticalAlign__get_middle(this$) {
    const tupledArg = [this$.property_2, new Position_VerticalAlign(5)];
    return [tupledArg[0], tupledArg[1]];
}

export function PositionClasses_VerticalAlign__get_top(this$) {
    const tupledArg = [this$.property_2, new Position_VerticalAlign(6)];
    return [tupledArg[0], tupledArg[1]];
}

export function PositionClasses_VerticalAlign__get_bottom(this$) {
    const tupledArg = [this$.property_2, new Position_VerticalAlign(7)];
    return [tupledArg[0], tupledArg[1]];
}

export class PositionClasses_Float extends CssRuleWithNone {
    constructor(property) {
        super(property);
        this.property_2 = property;
    }
}

export function PositionClasses_Float$reflection() {
    return class_type("Fss.Types.PositionClasses.Float", void 0, PositionClasses_Float, CssRuleWithNone$reflection());
}

export function PositionClasses_Float_$ctor_Z207A3CFB(property) {
    return new PositionClasses_Float(property);
}

export function PositionClasses_Float__get_left(this$) {
    const tupledArg = [this$.property_2, new Position_Float(0)];
    return [tupledArg[0], tupledArg[1]];
}

export function PositionClasses_Float__get_right(this$) {
    const tupledArg = [this$.property_2, new Position_Float(1)];
    return [tupledArg[0], tupledArg[1]];
}

export function PositionClasses_Float__get_inlineStart(this$) {
    const tupledArg = [this$.property_2, new Position_Float(2)];
    return [tupledArg[0], tupledArg[1]];
}

export function PositionClasses_Float__get_inlineEnd(this$) {
    const tupledArg = [this$.property_2, new Position_Float(3)];
    return [tupledArg[0], tupledArg[1]];
}

export class PositionClasses_BoxSizing extends CssRule {
    constructor(property) {
        super(property);
        this.property_1 = property;
    }
}

export function PositionClasses_BoxSizing$reflection() {
    return class_type("Fss.Types.PositionClasses.BoxSizing", void 0, PositionClasses_BoxSizing, CssRule$reflection());
}

export function PositionClasses_BoxSizing_$ctor_Z207A3CFB(property) {
    return new PositionClasses_BoxSizing(property);
}

export function PositionClasses_BoxSizing__get_borderBox(this$) {
    const tupledArg = [this$.property_1, new Position_BoxSizing(1)];
    return [tupledArg[0], tupledArg[1]];
}

export function PositionClasses_BoxSizing__get_contentBox(this$) {
    const tupledArg = [this$.property_1, new Position_BoxSizing(0)];
    return [tupledArg[0], tupledArg[1]];
}

export class PositionClasses_Direction extends CssRule {
    constructor(property) {
        super(property);
        this.property_1 = property;
    }
}

export function PositionClasses_Direction$reflection() {
    return class_type("Fss.Types.PositionClasses.Direction", void 0, PositionClasses_Direction, CssRule$reflection());
}

export function PositionClasses_Direction_$ctor_Z207A3CFB(property) {
    return new PositionClasses_Direction(property);
}

export function PositionClasses_Direction__get_rtl(this$) {
    const tupledArg = [this$.property_1, new Position_Direction(0)];
    return [tupledArg[0], tupledArg[1]];
}

export function PositionClasses_Direction__get_ltr(this$) {
    const tupledArg = [this$.property_1, new Position_Direction(1)];
    return [tupledArg[0], tupledArg[1]];
}

export class PositionClasses_Break extends CssRuleWithAuto {
    constructor(property) {
        super(property);
        this.property_2 = property;
    }
}

export function PositionClasses_Break$reflection() {
    return class_type("Fss.Types.PositionClasses.Break", void 0, PositionClasses_Break, CssRuleWithAuto$reflection());
}

export function PositionClasses_Break_$ctor_Z207A3CFB(property) {
    return new PositionClasses_Break(property);
}

export function PositionClasses_Break__get_avoid(this$) {
    const tupledArg = [this$.property_2, new Position_Break(0)];
    return [tupledArg[0], tupledArg[1]];
}

export function PositionClasses_Break__get_always(this$) {
    const tupledArg = [this$.property_2, new Position_Break(1)];
    return [tupledArg[0], tupledArg[1]];
}

export function PositionClasses_Break__get_all(this$) {
    const tupledArg = [this$.property_2, new Position_Break(2)];
    return [tupledArg[0], tupledArg[1]];
}

export function PositionClasses_Break__get_avoidPage(this$) {
    const tupledArg = [this$.property_2, new Position_Break(3)];
    return [tupledArg[0], tupledArg[1]];
}

export function PositionClasses_Break__get_page(this$) {
    const tupledArg = [this$.property_2, new Position_Break(4)];
    return [tupledArg[0], tupledArg[1]];
}

export function PositionClasses_Break__get_left(this$) {
    const tupledArg = [this$.property_2, new Position_Float(0)];
    return [tupledArg[0], tupledArg[1]];
}

export function PositionClasses_Break__get_right(this$) {
    const tupledArg = [this$.property_2, new Position_Float(1)];
    return [tupledArg[0], tupledArg[1]];
}

export function PositionClasses_Break__get_recto(this$) {
    const tupledArg = [this$.property_2, new Position_Break(7)];
    return [tupledArg[0], tupledArg[1]];
}

export function PositionClasses_Break__get_verso(this$) {
    const tupledArg = [this$.property_2, new Position_Break(8)];
    return [tupledArg[0], tupledArg[1]];
}

export function PositionClasses_Break__get_avoidColumn(this$) {
    const tupledArg = [this$.property_2, new Position_Break(9)];
    return [tupledArg[0], tupledArg[1]];
}

export function PositionClasses_Break__get_column(this$) {
    const tupledArg = [this$.property_2, new Position_Break(10)];
    return [tupledArg[0], tupledArg[1]];
}

export function PositionClasses_Break__get_avoidRegion(this$) {
    const tupledArg = [this$.property_2, new Position_Break(11)];
    return [tupledArg[0], tupledArg[1]];
}

export function PositionClasses_Break__get_region(this$) {
    const tupledArg = [this$.property_2, new Position_Break(12)];
    return [tupledArg[0], tupledArg[1]];
}

export class PositionClasses_BreakInside extends CssRuleWithAuto {
    constructor(property) {
        super(property);
        this.property_2 = property;
    }
}

export function PositionClasses_BreakInside$reflection() {
    return class_type("Fss.Types.PositionClasses.BreakInside", void 0, PositionClasses_BreakInside, CssRuleWithAuto$reflection());
}

export function PositionClasses_BreakInside_$ctor_Z207A3CFB(property) {
    return new PositionClasses_BreakInside(property);
}

export function PositionClasses_BreakInside__get_avoid(this$) {
    const tupledArg = [this$.property_2, new Position_Break(0)];
    return [tupledArg[0], tupledArg[1]];
}

export function PositionClasses_BreakInside__get_avoidPage(this$) {
    const tupledArg = [this$.property_2, new Position_Break(3)];
    return [tupledArg[0], tupledArg[1]];
}

export function PositionClasses_BreakInside__get_avoidColumn(this$) {
    const tupledArg = [this$.property_2, new Position_Break(9)];
    return [tupledArg[0], tupledArg[1]];
}

export function PositionClasses_BreakInside__get_avoidRegion(this$) {
    const tupledArg = [this$.property_2, new Position_Break(11)];
    return [tupledArg[0], tupledArg[1]];
}

export class WritingMode_WritingMode extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["HorizontalTb", "VerticalRl", "VerticalLr"];
    }
    StringifyCss() {
        const this$ = this;
        return Helpers_toKebabCase(this$);
    }
}

export function WritingMode_WritingMode$reflection() {
    return union_type("Fss.Types.WritingMode.WritingMode", [], WritingMode_WritingMode, () => [[], [], []]);
}

export class WritingModeClasses_WritingMode extends CssRule {
    constructor(property) {
        super(property);
        this.property_1 = property;
    }
}

export function WritingModeClasses_WritingMode$reflection() {
    return class_type("Fss.Types.WritingModeClasses.WritingMode", void 0, WritingModeClasses_WritingMode, CssRule$reflection());
}

export function WritingModeClasses_WritingMode_$ctor_Z207A3CFB(property) {
    return new WritingModeClasses_WritingMode(property);
}

export function WritingModeClasses_WritingMode__get_horizontalTb(this$) {
    const tupledArg = [this$.property_1, new WritingMode_WritingMode(0)];
    return [tupledArg[0], tupledArg[1]];
}

export function WritingModeClasses_WritingMode__get_verticalRl(this$) {
    const tupledArg = [this$.property_1, new WritingMode_WritingMode(1)];
    return [tupledArg[0], tupledArg[1]];
}

export function WritingModeClasses_WritingMode__get_verticalLr(this$) {
    const tupledArg = [this$.property_1, new WritingMode_WritingMode(2)];
    return [tupledArg[0], tupledArg[1]];
}

//# sourceMappingURL=Position.fs.js.map
