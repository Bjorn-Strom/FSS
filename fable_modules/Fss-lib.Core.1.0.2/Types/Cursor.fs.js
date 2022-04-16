import { Helpers_toKebabCase } from "../Utilities.fs.js";
import { Union } from "../../fable-library.3.7.9/Types.js";
import { class_type, union_type } from "../../fable-library.3.7.9/Reflection.js";
import { String$, UrlMaster, CssRuleWithAutoNone$reflection, CssRuleWithAutoNone } from "./MasterTypes.fs.js";

export class Cursor_Cursor extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["Default", "ContextMenu", "Help", "Pointer", "Progress", "Wait", "Cell", "Crosshair", "Text", "VerticalText", "Alias", "Copy", "Move", "NoDrop", "NotAllowed", "AllScroll", "ColResize", "RowResize", "NResize", "EResize", "SResize", "WResize", "NsResize", "EwResize", "NeResize", "NwResize", "SeResize", "SwResize", "NeswResize", "NwseResize"];
    }
    StringifyCss() {
        const this$ = this;
        return Helpers_toKebabCase(this$);
    }
}

export function Cursor_Cursor$reflection() {
    return union_type("Fss.Types.Cursor.Cursor", [], Cursor_Cursor, () => [[], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], []]);
}

export class CursorClasses_CursorParent extends CssRuleWithAutoNone {
    constructor(property) {
        super(property);
        this.property_2 = property;
    }
}

export function CursorClasses_CursorParent$reflection() {
    return class_type("Fss.Types.CursorClasses.CursorParent", void 0, CursorClasses_CursorParent, CssRuleWithAutoNone$reflection());
}

export function CursorClasses_CursorParent_$ctor_Z207A3CFB(property) {
    return new CursorClasses_CursorParent(property);
}

export function CursorClasses_CursorParent__value_Z721C83C5(this$, url) {
    const tupledArg = [this$.property_2, new UrlMaster(0, url)];
    return [tupledArg[0], tupledArg[1]];
}

export function CursorClasses_CursorParent__value_ZF6CC49A(this$, cursor) {
    const tupledArg = [this$.property_2, cursor];
    return [tupledArg[0], tupledArg[1]];
}

export function CursorClasses_CursorParent__url_Z721C83C5(this$, url) {
    const tupledArg = [this$.property_2, new UrlMaster(0, url)];
    return [tupledArg[0], tupledArg[1]];
}

export function CursorClasses_CursorParent__url_487EF8FB(this$, url, x, y) {
    const value = `url(${url}) ${x} ${y}`;
    const tupledArg = [this$.property_2, new String$(0, value)];
    return [tupledArg[0], tupledArg[1]];
}

export function CursorClasses_CursorParent__get_default$0027(this$) {
    const tupledArg = [this$.property_2, new Cursor_Cursor(0)];
    return [tupledArg[0], tupledArg[1]];
}

export function CursorClasses_CursorParent__get_contextMenu(this$) {
    const tupledArg = [this$.property_2, new Cursor_Cursor(1)];
    return [tupledArg[0], tupledArg[1]];
}

export function CursorClasses_CursorParent__get_help(this$) {
    const tupledArg = [this$.property_2, new Cursor_Cursor(2)];
    return [tupledArg[0], tupledArg[1]];
}

export function CursorClasses_CursorParent__get_pointer(this$) {
    const tupledArg = [this$.property_2, new Cursor_Cursor(3)];
    return [tupledArg[0], tupledArg[1]];
}

export function CursorClasses_CursorParent__get_progress(this$) {
    const tupledArg = [this$.property_2, new Cursor_Cursor(4)];
    return [tupledArg[0], tupledArg[1]];
}

export function CursorClasses_CursorParent__get_wait(this$) {
    const tupledArg = [this$.property_2, new Cursor_Cursor(5)];
    return [tupledArg[0], tupledArg[1]];
}

export function CursorClasses_CursorParent__get_cell(this$) {
    const tupledArg = [this$.property_2, new Cursor_Cursor(6)];
    return [tupledArg[0], tupledArg[1]];
}

export function CursorClasses_CursorParent__get_crosshair(this$) {
    const tupledArg = [this$.property_2, new Cursor_Cursor(7)];
    return [tupledArg[0], tupledArg[1]];
}

export function CursorClasses_CursorParent__get_text(this$) {
    const tupledArg = [this$.property_2, new Cursor_Cursor(8)];
    return [tupledArg[0], tupledArg[1]];
}

export function CursorClasses_CursorParent__get_verticalText(this$) {
    const tupledArg = [this$.property_2, new Cursor_Cursor(9)];
    return [tupledArg[0], tupledArg[1]];
}

export function CursorClasses_CursorParent__get_alias(this$) {
    const tupledArg = [this$.property_2, new Cursor_Cursor(10)];
    return [tupledArg[0], tupledArg[1]];
}

export function CursorClasses_CursorParent__get_copy(this$) {
    const tupledArg = [this$.property_2, new Cursor_Cursor(11)];
    return [tupledArg[0], tupledArg[1]];
}

export function CursorClasses_CursorParent__get_move(this$) {
    const tupledArg = [this$.property_2, new Cursor_Cursor(12)];
    return [tupledArg[0], tupledArg[1]];
}

export function CursorClasses_CursorParent__get_noDrop(this$) {
    const tupledArg = [this$.property_2, new Cursor_Cursor(13)];
    return [tupledArg[0], tupledArg[1]];
}

export function CursorClasses_CursorParent__get_notAllowed(this$) {
    const tupledArg = [this$.property_2, new Cursor_Cursor(14)];
    return [tupledArg[0], tupledArg[1]];
}

export function CursorClasses_CursorParent__get_allScroll(this$) {
    const tupledArg = [this$.property_2, new Cursor_Cursor(15)];
    return [tupledArg[0], tupledArg[1]];
}

export function CursorClasses_CursorParent__get_colResize(this$) {
    const tupledArg = [this$.property_2, new Cursor_Cursor(16)];
    return [tupledArg[0], tupledArg[1]];
}

export function CursorClasses_CursorParent__get_rowResize(this$) {
    const tupledArg = [this$.property_2, new Cursor_Cursor(17)];
    return [tupledArg[0], tupledArg[1]];
}

export function CursorClasses_CursorParent__get_nResize(this$) {
    const tupledArg = [this$.property_2, new Cursor_Cursor(18)];
    return [tupledArg[0], tupledArg[1]];
}

export function CursorClasses_CursorParent__get_eResize(this$) {
    const tupledArg = [this$.property_2, new Cursor_Cursor(19)];
    return [tupledArg[0], tupledArg[1]];
}

export function CursorClasses_CursorParent__get_sResize(this$) {
    const tupledArg = [this$.property_2, new Cursor_Cursor(20)];
    return [tupledArg[0], tupledArg[1]];
}

export function CursorClasses_CursorParent__get_wResize(this$) {
    const tupledArg = [this$.property_2, new Cursor_Cursor(21)];
    return [tupledArg[0], tupledArg[1]];
}

export function CursorClasses_CursorParent__get_nsResize(this$) {
    const tupledArg = [this$.property_2, new Cursor_Cursor(22)];
    return [tupledArg[0], tupledArg[1]];
}

export function CursorClasses_CursorParent__get_ewResize(this$) {
    const tupledArg = [this$.property_2, new Cursor_Cursor(23)];
    return [tupledArg[0], tupledArg[1]];
}

export function CursorClasses_CursorParent__get_neResize(this$) {
    const tupledArg = [this$.property_2, new Cursor_Cursor(24)];
    return [tupledArg[0], tupledArg[1]];
}

export function CursorClasses_CursorParent__get_nwResize(this$) {
    const tupledArg = [this$.property_2, new Cursor_Cursor(25)];
    return [tupledArg[0], tupledArg[1]];
}

export function CursorClasses_CursorParent__get_seResize(this$) {
    const tupledArg = [this$.property_2, new Cursor_Cursor(26)];
    return [tupledArg[0], tupledArg[1]];
}

export function CursorClasses_CursorParent__get_swResize(this$) {
    const tupledArg = [this$.property_2, new Cursor_Cursor(27)];
    return [tupledArg[0], tupledArg[1]];
}

export function CursorClasses_CursorParent__get_neswResize(this$) {
    const tupledArg = [this$.property_2, new Cursor_Cursor(28)];
    return [tupledArg[0], tupledArg[1]];
}

export function CursorClasses_CursorParent__get_nwseResize(this$) {
    const tupledArg = [this$.property_2, new Cursor_Cursor(29)];
    return [tupledArg[0], tupledArg[1]];
}

//# sourceMappingURL=Cursor.fs.js.map
