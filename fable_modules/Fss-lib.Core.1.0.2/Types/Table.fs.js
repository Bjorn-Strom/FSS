import { Helpers_toKebabCase } from "../Utilities.fs.js";
import { toString, Union } from "../../fable-library.3.7.9/Types.js";
import { class_type, union_type } from "../../fable-library.3.7.9/Reflection.js";
import { CssRuleWithAuto$reflection, CssRuleWithAuto, CssRule$reflection, CssRule } from "./MasterTypes.fs.js";

export class Table_CaptionSide extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["Top", "Bottom", "Left", "Right", "TopOutside", "BottomOutside"];
    }
    StringifyCss() {
        const this$ = this;
        return Helpers_toKebabCase(this$);
    }
}

export function Table_CaptionSide$reflection() {
    return union_type("Fss.Types.Table.CaptionSide", [], Table_CaptionSide, () => [[], [], [], [], [], []]);
}

export class Table_EmptyCells extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["Show", "Hide"];
    }
    StringifyCss() {
        const this$ = this;
        return toString(this$).toLocaleLowerCase();
    }
}

export function Table_EmptyCells$reflection() {
    return union_type("Fss.Types.Table.EmptyCells", [], Table_EmptyCells, () => [[], []]);
}

export class Table_Layout extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["Fixed"];
    }
    StringifyCss() {
        return "fixed";
    }
}

export function Table_Layout$reflection() {
    return union_type("Fss.Types.Table.Layout", [], Table_Layout, () => [[]]);
}

export class TableClasses_CaptionSide extends CssRule {
    constructor(property) {
        super(property);
        this.property_1 = property;
    }
}

export function TableClasses_CaptionSide$reflection() {
    return class_type("Fss.Types.TableClasses.CaptionSide", void 0, TableClasses_CaptionSide, CssRule$reflection());
}

export function TableClasses_CaptionSide_$ctor_Z207A3CFB(property) {
    return new TableClasses_CaptionSide(property);
}

export function TableClasses_CaptionSide__get_top(this$) {
    const tupledArg = [this$.property_1, new Table_CaptionSide(0)];
    return [tupledArg[0], tupledArg[1]];
}

export function TableClasses_CaptionSide__get_bottom(this$) {
    const tupledArg = [this$.property_1, new Table_CaptionSide(1)];
    return [tupledArg[0], tupledArg[1]];
}

export function TableClasses_CaptionSide__get_left(this$) {
    const tupledArg = [this$.property_1, new Table_CaptionSide(2)];
    return [tupledArg[0], tupledArg[1]];
}

export function TableClasses_CaptionSide__get_right(this$) {
    const tupledArg = [this$.property_1, new Table_CaptionSide(3)];
    return [tupledArg[0], tupledArg[1]];
}

export function TableClasses_CaptionSide__get_topOutside(this$) {
    const tupledArg = [this$.property_1, new Table_CaptionSide(4)];
    return [tupledArg[0], tupledArg[1]];
}

export function TableClasses_CaptionSide__get_bottomOutside(this$) {
    const tupledArg = [this$.property_1, new Table_CaptionSide(5)];
    return [tupledArg[0], tupledArg[1]];
}

export class TableClasses_EmptyCells extends CssRule {
    constructor(property) {
        super(property);
        this.property_1 = property;
    }
}

export function TableClasses_EmptyCells$reflection() {
    return class_type("Fss.Types.TableClasses.EmptyCells", void 0, TableClasses_EmptyCells, CssRule$reflection());
}

export function TableClasses_EmptyCells_$ctor_Z207A3CFB(property) {
    return new TableClasses_EmptyCells(property);
}

export function TableClasses_EmptyCells__get_show(this$) {
    const tupledArg = [this$.property_1, new Table_EmptyCells(0)];
    return [tupledArg[0], tupledArg[1]];
}

export function TableClasses_EmptyCells__get_hide(this$) {
    const tupledArg = [this$.property_1, new Table_EmptyCells(1)];
    return [tupledArg[0], tupledArg[1]];
}

export class TableClasses_TableLayout extends CssRuleWithAuto {
    constructor(property) {
        super(property);
        this.property_2 = property;
    }
}

export function TableClasses_TableLayout$reflection() {
    return class_type("Fss.Types.TableClasses.TableLayout", void 0, TableClasses_TableLayout, CssRuleWithAuto$reflection());
}

export function TableClasses_TableLayout_$ctor_Z207A3CFB(property) {
    return new TableClasses_TableLayout(property);
}

export function TableClasses_TableLayout__get_fixed$0027(this$) {
    const tupledArg = [this$.property_2, new Table_Layout(0)];
    return [tupledArg[0], tupledArg[1]];
}

//# sourceMappingURL=Table.fs.js.map
