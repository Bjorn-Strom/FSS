import { toString, Union } from "../../fable-library.3.7.9/Types.js";
import { class_type, union_type } from "../../fable-library.3.7.9/Reflection.js";
import { Helpers_toKebabCase } from "../Utilities.fs.js";
import { Int, CssRuleWithAuto$reflection, CssRuleWithAuto, CssRuleWithNone$reflection, CssRuleWithNone, CssRule$reflection, CssRule } from "./MasterTypes.fs.js";
import { unitHelpers_CssRuleWithAutoLength$reflection, unitHelpers_CssRuleWithAutoLength, unitHelpers_CssRuleWithLength$reflection, unitHelpers_CssRuleWithLength, unitHelpers_CssRuleWithLengthNormal$reflection, unitHelpers_CssRuleWithLengthNormal } from "./Units.fs.js";
import { ColorClass_Color$reflection, ColorClass_Color } from "./Color.fs.js";

export class Column_Span extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["All"];
    }
    StringifyCss() {
        return "all";
    }
}

export function Column_Span$reflection() {
    return union_type("Fss.Types.Column.Span", [], Column_Span, () => [[]]);
}

export class Column_RuleWidth extends Union {
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

export function Column_RuleWidth$reflection() {
    return union_type("Fss.Types.Column.RuleWidth", [], Column_RuleWidth, () => [[], [], []]);
}

export class Column_RuleStyle extends Union {
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

export function Column_RuleStyle$reflection() {
    return union_type("Fss.Types.Column.RuleStyle", [], Column_RuleStyle, () => [[], [], [], [], [], [], [], [], []]);
}

export class Column_Fill extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["Balance", "BalanceAll"];
    }
    StringifyCss() {
        const this$ = this;
        return Helpers_toKebabCase(this$);
    }
}

export function Column_Fill$reflection() {
    return union_type("Fss.Types.Column.Fill", [], Column_Fill, () => [[], []]);
}

export class ColumnClasses_Columns extends CssRule {
    constructor(property) {
        super(property);
    }
}

export function ColumnClasses_Columns$reflection() {
    return class_type("Fss.Types.ColumnClasses.Columns", void 0, ColumnClasses_Columns, CssRule$reflection());
}

export function ColumnClasses_Columns_$ctor_Z207A3CFB(property) {
    return new ColumnClasses_Columns(property);
}

export class ColumnClasses_ColumnGap extends unitHelpers_CssRuleWithLengthNormal {
    constructor(property) {
        super(property);
    }
}

export function ColumnClasses_ColumnGap$reflection() {
    return class_type("Fss.Types.ColumnClasses.ColumnGap", void 0, ColumnClasses_ColumnGap, unitHelpers_CssRuleWithLengthNormal$reflection());
}

export function ColumnClasses_ColumnGap_$ctor_Z207A3CFB(property) {
    return new ColumnClasses_ColumnGap(property);
}

export class ColumnClasses_ColumnSpan extends CssRuleWithNone {
    constructor(property) {
        super(property);
        this.property_2 = property;
    }
}

export function ColumnClasses_ColumnSpan$reflection() {
    return class_type("Fss.Types.ColumnClasses.ColumnSpan", void 0, ColumnClasses_ColumnSpan, CssRuleWithNone$reflection());
}

export function ColumnClasses_ColumnSpan_$ctor_Z207A3CFB(property) {
    return new ColumnClasses_ColumnSpan(property);
}

export function ColumnClasses_ColumnSpan__get_all(this$) {
    const tupledArg = [this$.property_2, new Column_Span(0)];
    return [tupledArg[0], tupledArg[1]];
}

export class ColumnClasses_ColumnRule extends CssRule {
    constructor(property) {
        super(property);
    }
}

export function ColumnClasses_ColumnRule$reflection() {
    return class_type("Fss.Types.ColumnClasses.ColumnRule", void 0, ColumnClasses_ColumnRule, CssRule$reflection());
}

export function ColumnClasses_ColumnRule_$ctor_Z207A3CFB(property) {
    return new ColumnClasses_ColumnRule(property);
}

export class ColumnClasses_ColumnRuleWidth extends unitHelpers_CssRuleWithLength {
    constructor(property) {
        super(property);
        this.property_2 = property;
    }
}

export function ColumnClasses_ColumnRuleWidth$reflection() {
    return class_type("Fss.Types.ColumnClasses.ColumnRuleWidth", void 0, ColumnClasses_ColumnRuleWidth, unitHelpers_CssRuleWithLength$reflection());
}

export function ColumnClasses_ColumnRuleWidth_$ctor_Z207A3CFB(property) {
    return new ColumnClasses_ColumnRuleWidth(property);
}

export function ColumnClasses_ColumnRuleWidth__get_thin(this$) {
    const tupledArg = [this$.property_2, new Column_RuleWidth(0)];
    return [tupledArg[0], tupledArg[1]];
}

export function ColumnClasses_ColumnRuleWidth__get_medium(this$) {
    const tupledArg = [this$.property_2, new Column_RuleWidth(1)];
    return [tupledArg[0], tupledArg[1]];
}

export function ColumnClasses_ColumnRuleWidth__get_thick(this$) {
    const tupledArg = [this$.property_2, new Column_RuleWidth(2)];
    return [tupledArg[0], tupledArg[1]];
}

export class ColumnClasses_ColumnRuleStyle extends CssRuleWithNone {
    constructor(property) {
        super(property);
        this.property_2 = property;
    }
}

export function ColumnClasses_ColumnRuleStyle$reflection() {
    return class_type("Fss.Types.ColumnClasses.ColumnRuleStyle", void 0, ColumnClasses_ColumnRuleStyle, CssRuleWithNone$reflection());
}

export function ColumnClasses_ColumnRuleStyle_$ctor_Z207A3CFB(property) {
    return new ColumnClasses_ColumnRuleStyle(property);
}

export function ColumnClasses_ColumnRuleStyle__get_hidden(this$) {
    const tupledArg = [this$.property_2, new Column_RuleStyle(0)];
    return [tupledArg[0], tupledArg[1]];
}

export function ColumnClasses_ColumnRuleStyle__get_dotted(this$) {
    const tupledArg = [this$.property_2, new Column_RuleStyle(1)];
    return [tupledArg[0], tupledArg[1]];
}

export function ColumnClasses_ColumnRuleStyle__get_dashed(this$) {
    const tupledArg = [this$.property_2, new Column_RuleStyle(2)];
    return [tupledArg[0], tupledArg[1]];
}

export function ColumnClasses_ColumnRuleStyle__get_solid(this$) {
    const tupledArg = [this$.property_2, new Column_RuleStyle(3)];
    return [tupledArg[0], tupledArg[1]];
}

export function ColumnClasses_ColumnRuleStyle__get_double(this$) {
    const tupledArg = [this$.property_2, new Column_RuleStyle(4)];
    return [tupledArg[0], tupledArg[1]];
}

export function ColumnClasses_ColumnRuleStyle__get_groove(this$) {
    const tupledArg = [this$.property_2, new Column_RuleStyle(5)];
    return [tupledArg[0], tupledArg[1]];
}

export function ColumnClasses_ColumnRuleStyle__get_ridge(this$) {
    const tupledArg = [this$.property_2, new Column_RuleStyle(6)];
    return [tupledArg[0], tupledArg[1]];
}

export function ColumnClasses_ColumnRuleStyle__get_inset(this$) {
    const tupledArg = [this$.property_2, new Column_RuleStyle(7)];
    return [tupledArg[0], tupledArg[1]];
}

export function ColumnClasses_ColumnRuleStyle__get_outset(this$) {
    const tupledArg = [this$.property_2, new Column_RuleStyle(8)];
    return [tupledArg[0], tupledArg[1]];
}

export class ColumnClasses_ColumnRuleColor extends ColorClass_Color {
    constructor(property) {
        super(property);
    }
}

export function ColumnClasses_ColumnRuleColor$reflection() {
    return class_type("Fss.Types.ColumnClasses.ColumnRuleColor", void 0, ColumnClasses_ColumnRuleColor, ColorClass_Color$reflection());
}

export function ColumnClasses_ColumnRuleColor_$ctor_Z207A3CFB(property) {
    return new ColumnClasses_ColumnRuleColor(property);
}

export class ColumnClasses_ColumnCount extends CssRuleWithAuto {
    constructor(property) {
        super(property);
        this.property_2 = property;
    }
}

export function ColumnClasses_ColumnCount$reflection() {
    return class_type("Fss.Types.ColumnClasses.ColumnCount", void 0, ColumnClasses_ColumnCount, CssRuleWithAuto$reflection());
}

export function ColumnClasses_ColumnCount_$ctor_Z207A3CFB(property) {
    return new ColumnClasses_ColumnCount(property);
}

export function ColumnClasses_ColumnCount__value_Z524259A4(this$, count) {
    const tupledArg = [this$.property_2, new Int(0, count)];
    return [tupledArg[0], tupledArg[1]];
}

export class ColumnClasses_ColumnFill extends CssRuleWithAuto {
    constructor(property) {
        super(property);
        this.property_2 = property;
    }
}

export function ColumnClasses_ColumnFill$reflection() {
    return class_type("Fss.Types.ColumnClasses.ColumnFill", void 0, ColumnClasses_ColumnFill, CssRuleWithAuto$reflection());
}

export function ColumnClasses_ColumnFill_$ctor_Z207A3CFB(property) {
    return new ColumnClasses_ColumnFill(property);
}

export function ColumnClasses_ColumnFill__get_balance(this$) {
    const tupledArg = [this$.property_2, new Column_Fill(0)];
    return [tupledArg[0], tupledArg[1]];
}

export function ColumnClasses_ColumnFill__get_balanceAll(this$) {
    const tupledArg = [this$.property_2, new Column_Fill(1)];
    return [tupledArg[0], tupledArg[1]];
}

export class ColumnClasses_ColumnWidth extends unitHelpers_CssRuleWithAutoLength {
    constructor(property) {
        super(property);
    }
}

export function ColumnClasses_ColumnWidth$reflection() {
    return class_type("Fss.Types.ColumnClasses.ColumnWidth", void 0, ColumnClasses_ColumnWidth, unitHelpers_CssRuleWithAutoLength$reflection());
}

export function ColumnClasses_ColumnWidth_$ctor_Z207A3CFB(property) {
    return new ColumnClasses_ColumnWidth(property);
}

//# sourceMappingURL=Column.fs.js.map
