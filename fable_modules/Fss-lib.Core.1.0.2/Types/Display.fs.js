import { Helpers_toKebabCase } from "../Utilities.fs.js";
import { Union } from "../../fable-library.3.7.9/Types.js";
import { class_type, union_type } from "../../fable-library.3.7.9/Reflection.js";
import { CssRuleWithNone$reflection, CssRuleWithNone } from "./MasterTypes.fs.js";

export class Display_Display extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["Inline", "InlineBlock", "Block", "RunIn", "Flex", "Grid", "FlowRoot", "Table", "TableCell", "TableColumn", "TableColumnGroup", "TableHeaderGroup", "TableRowGroup", "TableFooterGroup", "TableRow", "TableCaption"];
    }
    StringifyCss() {
        const this$ = this;
        return Helpers_toKebabCase(this$);
    }
}

export function Display_Display$reflection() {
    return union_type("Fss.Types.Display.Display", [], Display_Display, () => [[], [], [], [], [], [], [], [], [], [], [], [], [], [], [], []]);
}

export class DisplayClasses_DisplayClass extends CssRuleWithNone {
    constructor(property) {
        super(property);
        this.property_2 = property;
    }
}

export function DisplayClasses_DisplayClass$reflection() {
    return class_type("Fss.Types.DisplayClasses.DisplayClass", void 0, DisplayClasses_DisplayClass, CssRuleWithNone$reflection());
}

export function DisplayClasses_DisplayClass_$ctor_Z207A3CFB(property) {
    return new DisplayClasses_DisplayClass(property);
}

export function DisplayClasses_DisplayClass__value_Z5164641A(this$, display) {
    const tupledArg = [this$.property_2, display];
    return [tupledArg[0], tupledArg[1]];
}

export function DisplayClasses_DisplayClass__get_inline$0027(this$) {
    const tupledArg = [this$.property_2, new Display_Display(0)];
    return [tupledArg[0], tupledArg[1]];
}

export function DisplayClasses_DisplayClass__get_inlineBlock(this$) {
    const tupledArg = [this$.property_2, new Display_Display(1)];
    return [tupledArg[0], tupledArg[1]];
}

export function DisplayClasses_DisplayClass__get_block(this$) {
    const tupledArg = [this$.property_2, new Display_Display(2)];
    return [tupledArg[0], tupledArg[1]];
}

export function DisplayClasses_DisplayClass__get_runIn(this$) {
    const tupledArg = [this$.property_2, new Display_Display(3)];
    return [tupledArg[0], tupledArg[1]];
}

export function DisplayClasses_DisplayClass__get_flex(this$) {
    const tupledArg = [this$.property_2, new Display_Display(4)];
    return [tupledArg[0], tupledArg[1]];
}

export function DisplayClasses_DisplayClass__get_grid(this$) {
    const tupledArg = [this$.property_2, new Display_Display(5)];
    return [tupledArg[0], tupledArg[1]];
}

export function DisplayClasses_DisplayClass__get_flowRoot(this$) {
    const tupledArg = [this$.property_2, new Display_Display(6)];
    return [tupledArg[0], tupledArg[1]];
}

export function DisplayClasses_DisplayClass__get_table(this$) {
    const tupledArg = [this$.property_2, new Display_Display(7)];
    return [tupledArg[0], tupledArg[1]];
}

export function DisplayClasses_DisplayClass__get_tableCell(this$) {
    const tupledArg = [this$.property_2, new Display_Display(8)];
    return [tupledArg[0], tupledArg[1]];
}

export function DisplayClasses_DisplayClass__get_tableColumn(this$) {
    const tupledArg = [this$.property_2, new Display_Display(9)];
    return [tupledArg[0], tupledArg[1]];
}

export function DisplayClasses_DisplayClass__get_tableColumnGroup(this$) {
    const tupledArg = [this$.property_2, new Display_Display(10)];
    return [tupledArg[0], tupledArg[1]];
}

export function DisplayClasses_DisplayClass__get_tableHeaderGroup(this$) {
    const tupledArg = [this$.property_2, new Display_Display(11)];
    return [tupledArg[0], tupledArg[1]];
}

export function DisplayClasses_DisplayClass__get_tableRowGroup(this$) {
    const tupledArg = [this$.property_2, new Display_Display(12)];
    return [tupledArg[0], tupledArg[1]];
}

export function DisplayClasses_DisplayClass__get_tableFooterGroup(this$) {
    const tupledArg = [this$.property_2, new Display_Display(13)];
    return [tupledArg[0], tupledArg[1]];
}

export function DisplayClasses_DisplayClass__get_tableRow(this$) {
    const tupledArg = [this$.property_2, new Display_Display(14)];
    return [tupledArg[0], tupledArg[1]];
}

export function DisplayClasses_DisplayClass__get_tableCaption(this$) {
    const tupledArg = [this$.property_2, new Display_Display(15)];
    return [tupledArg[0], tupledArg[1]];
}

//# sourceMappingURL=Display.fs.js.map
