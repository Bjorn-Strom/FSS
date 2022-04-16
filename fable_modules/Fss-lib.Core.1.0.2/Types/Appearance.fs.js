import { Helpers_toKebabCase } from "../Utilities.fs.js";
import { Union } from "../../fable-library.3.7.9/Types.js";
import { class_type, union_type } from "../../fable-library.3.7.9/Reflection.js";
import { CssRuleWithAutoNone$reflection, CssRuleWithAutoNone } from "./MasterTypes.fs.js";

export class Appearance_Appearance extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["PushButton", "SquareButton", "Button", "ButtonBevel", "Listbox", "Listitem", "Menulist", "MenulistButton", "MenulistText", "MenulistTextfield", "Menupopup", "ScrollbarbuttonUp", "ScrollbarbuttonDown", "ScrollbarbuttonLeft", "ScrollbarbuttonRight", "ScrollbartrackHorizontal", "ScrollbartrackVertical", "ScrollbarthumbHorizontal", "ScrollbarthumbVertical", "ScrollbargripperHorizontal", "ScrollbargripperVertical", "SliderHorizontal", "SliderVertical", "SliderthumbHorizontal", "SliderthumbVertical", "Caret", "Searchfield", "SearchfieldDecoration", "SearchfieldResultsDecoration", "SearchfieldResultsButton", "SearchfieldCancelButton", "Textfield", "Textarea", "Checkbox", "CheckboxContainer", "CheckboxSmall", "Dialog", "Menuitem", "Progressbar", "Radio", "RadioContainer", "RadioSmall", "Resizer", "Scrollbar", "Separator", "Statusbar", "Tab", "Tabpanels", "TextfieldMultiline", "Toolbar", "Toolbarbutton", "Toolbox", "MozMacUnifiedToolbar", "MozWinBorderlessGlass", "MozWinBrowsertabbarToolbox", "MozWinCommunicationsToolbox", "MozWinGlass", "MozWinMediaToolbox", "Tooltip", "Treeheadercell", "Treeheadersortarrow", "Treeitem", "Treetwisty", "Treetwistyopen", "Treeview", "Window"];
    }
    StringifyCss() {
        const this$ = this;
        return Helpers_toKebabCase(this$);
    }
}

export function Appearance_Appearance$reflection() {
    return union_type("Fss.Types.Appearance.Appearance", [], Appearance_Appearance, () => [[], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], []]);
}

export class AppearanceClasses_Appearance extends CssRuleWithAutoNone {
    constructor(property) {
        super(property);
        this.property_2 = property;
    }
}

export function AppearanceClasses_Appearance$reflection() {
    return class_type("Fss.Types.AppearanceClasses.Appearance", void 0, AppearanceClasses_Appearance, CssRuleWithAutoNone$reflection());
}

export function AppearanceClasses_Appearance_$ctor_Z207A3CFB(property) {
    return new AppearanceClasses_Appearance(property);
}

export function AppearanceClasses_Appearance__get_pushButton(this$) {
    const tupledArg = [this$.property_2, new Appearance_Appearance(0)];
    return [tupledArg[0], tupledArg[1]];
}

export function AppearanceClasses_Appearance__get_squareButton(this$) {
    const tupledArg = [this$.property_2, new Appearance_Appearance(1)];
    return [tupledArg[0], tupledArg[1]];
}

export function AppearanceClasses_Appearance__get_button(this$) {
    const tupledArg = [this$.property_2, new Appearance_Appearance(2)];
    return [tupledArg[0], tupledArg[1]];
}

export function AppearanceClasses_Appearance__get_buttonBevel(this$) {
    const tupledArg = [this$.property_2, new Appearance_Appearance(3)];
    return [tupledArg[0], tupledArg[1]];
}

export function AppearanceClasses_Appearance__get_listbox(this$) {
    const tupledArg = [this$.property_2, new Appearance_Appearance(4)];
    return [tupledArg[0], tupledArg[1]];
}

export function AppearanceClasses_Appearance__get_listitem(this$) {
    const tupledArg = [this$.property_2, new Appearance_Appearance(5)];
    return [tupledArg[0], tupledArg[1]];
}

export function AppearanceClasses_Appearance__get_menulist(this$) {
    const tupledArg = [this$.property_2, new Appearance_Appearance(6)];
    return [tupledArg[0], tupledArg[1]];
}

export function AppearanceClasses_Appearance__get_menulistButton(this$) {
    const tupledArg = [this$.property_2, new Appearance_Appearance(7)];
    return [tupledArg[0], tupledArg[1]];
}

export function AppearanceClasses_Appearance__get_menulistText(this$) {
    const tupledArg = [this$.property_2, new Appearance_Appearance(8)];
    return [tupledArg[0], tupledArg[1]];
}

export function AppearanceClasses_Appearance__get_menulistTextfield(this$) {
    const tupledArg = [this$.property_2, new Appearance_Appearance(9)];
    return [tupledArg[0], tupledArg[1]];
}

export function AppearanceClasses_Appearance__get_menupopup(this$) {
    const tupledArg = [this$.property_2, new Appearance_Appearance(10)];
    return [tupledArg[0], tupledArg[1]];
}

export function AppearanceClasses_Appearance__get_scrollbarbuttonUp(this$) {
    const tupledArg = [this$.property_2, new Appearance_Appearance(11)];
    return [tupledArg[0], tupledArg[1]];
}

export function AppearanceClasses_Appearance__get_scrollbarbuttonDown(this$) {
    const tupledArg = [this$.property_2, new Appearance_Appearance(12)];
    return [tupledArg[0], tupledArg[1]];
}

export function AppearanceClasses_Appearance__get_scrollbarbuttonLeft(this$) {
    const tupledArg = [this$.property_2, new Appearance_Appearance(13)];
    return [tupledArg[0], tupledArg[1]];
}

export function AppearanceClasses_Appearance__get_scrollbarbuttonRight(this$) {
    const tupledArg = [this$.property_2, new Appearance_Appearance(14)];
    return [tupledArg[0], tupledArg[1]];
}

export function AppearanceClasses_Appearance__get_scrollbartrackHorizontal(this$) {
    const tupledArg = [this$.property_2, new Appearance_Appearance(15)];
    return [tupledArg[0], tupledArg[1]];
}

export function AppearanceClasses_Appearance__get_scrollbartrackVertical(this$) {
    const tupledArg = [this$.property_2, new Appearance_Appearance(16)];
    return [tupledArg[0], tupledArg[1]];
}

export function AppearanceClasses_Appearance__get_scrollbarthumbHorizontal(this$) {
    const tupledArg = [this$.property_2, new Appearance_Appearance(17)];
    return [tupledArg[0], tupledArg[1]];
}

export function AppearanceClasses_Appearance__get_scrollbarthumbVertical(this$) {
    const tupledArg = [this$.property_2, new Appearance_Appearance(18)];
    return [tupledArg[0], tupledArg[1]];
}

export function AppearanceClasses_Appearance__get_scrollbargripperHorizontal(this$) {
    const tupledArg = [this$.property_2, new Appearance_Appearance(19)];
    return [tupledArg[0], tupledArg[1]];
}

export function AppearanceClasses_Appearance__get_scrollbargripperVertical(this$) {
    const tupledArg = [this$.property_2, new Appearance_Appearance(20)];
    return [tupledArg[0], tupledArg[1]];
}

export function AppearanceClasses_Appearance__get_sliderHorizontal(this$) {
    const tupledArg = [this$.property_2, new Appearance_Appearance(21)];
    return [tupledArg[0], tupledArg[1]];
}

export function AppearanceClasses_Appearance__get_sliderVertical(this$) {
    const tupledArg = [this$.property_2, new Appearance_Appearance(22)];
    return [tupledArg[0], tupledArg[1]];
}

export function AppearanceClasses_Appearance__get_sliderthumbHorizontal(this$) {
    const tupledArg = [this$.property_2, new Appearance_Appearance(23)];
    return [tupledArg[0], tupledArg[1]];
}

export function AppearanceClasses_Appearance__get_sliderthumbVertical(this$) {
    const tupledArg = [this$.property_2, new Appearance_Appearance(24)];
    return [tupledArg[0], tupledArg[1]];
}

export function AppearanceClasses_Appearance__get_caret(this$) {
    const tupledArg = [this$.property_2, new Appearance_Appearance(25)];
    return [tupledArg[0], tupledArg[1]];
}

export function AppearanceClasses_Appearance__get_searchfield(this$) {
    const tupledArg = [this$.property_2, new Appearance_Appearance(26)];
    return [tupledArg[0], tupledArg[1]];
}

export function AppearanceClasses_Appearance__get_searchfieldDecoration(this$) {
    const tupledArg = [this$.property_2, new Appearance_Appearance(27)];
    return [tupledArg[0], tupledArg[1]];
}

export function AppearanceClasses_Appearance__get_searchfieldResultsDecoration(this$) {
    const tupledArg = [this$.property_2, new Appearance_Appearance(28)];
    return [tupledArg[0], tupledArg[1]];
}

export function AppearanceClasses_Appearance__get_searchfieldResultsButton(this$) {
    const tupledArg = [this$.property_2, new Appearance_Appearance(29)];
    return [tupledArg[0], tupledArg[1]];
}

export function AppearanceClasses_Appearance__get_searchfieldCancelButton(this$) {
    const tupledArg = [this$.property_2, new Appearance_Appearance(30)];
    return [tupledArg[0], tupledArg[1]];
}

export function AppearanceClasses_Appearance__get_textfield(this$) {
    const tupledArg = [this$.property_2, new Appearance_Appearance(31)];
    return [tupledArg[0], tupledArg[1]];
}

export function AppearanceClasses_Appearance__get_textarea(this$) {
    const tupledArg = [this$.property_2, new Appearance_Appearance(32)];
    return [tupledArg[0], tupledArg[1]];
}

export function AppearanceClasses_Appearance__get_checkbox(this$) {
    const tupledArg = [this$.property_2, new Appearance_Appearance(33)];
    return [tupledArg[0], tupledArg[1]];
}

export function AppearanceClasses_Appearance__get_checkboxContainer(this$) {
    const tupledArg = [this$.property_2, new Appearance_Appearance(34)];
    return [tupledArg[0], tupledArg[1]];
}

export function AppearanceClasses_Appearance__get_checkboxSmall(this$) {
    const tupledArg = [this$.property_2, new Appearance_Appearance(35)];
    return [tupledArg[0], tupledArg[1]];
}

export function AppearanceClasses_Appearance__get_dialog(this$) {
    const tupledArg = [this$.property_2, new Appearance_Appearance(36)];
    return [tupledArg[0], tupledArg[1]];
}

export function AppearanceClasses_Appearance__get_menuitem(this$) {
    const tupledArg = [this$.property_2, new Appearance_Appearance(37)];
    return [tupledArg[0], tupledArg[1]];
}

export function AppearanceClasses_Appearance__get_progressbar(this$) {
    const tupledArg = [this$.property_2, new Appearance_Appearance(38)];
    return [tupledArg[0], tupledArg[1]];
}

export function AppearanceClasses_Appearance__get_radio(this$) {
    const tupledArg = [this$.property_2, new Appearance_Appearance(39)];
    return [tupledArg[0], tupledArg[1]];
}

export function AppearanceClasses_Appearance__get_radioContainer(this$) {
    const tupledArg = [this$.property_2, new Appearance_Appearance(40)];
    return [tupledArg[0], tupledArg[1]];
}

export function AppearanceClasses_Appearance__get_radioSmall(this$) {
    const tupledArg = [this$.property_2, new Appearance_Appearance(41)];
    return [tupledArg[0], tupledArg[1]];
}

export function AppearanceClasses_Appearance__get_resizer(this$) {
    const tupledArg = [this$.property_2, new Appearance_Appearance(42)];
    return [tupledArg[0], tupledArg[1]];
}

export function AppearanceClasses_Appearance__get_scrollbar(this$) {
    const tupledArg = [this$.property_2, new Appearance_Appearance(43)];
    return [tupledArg[0], tupledArg[1]];
}

export function AppearanceClasses_Appearance__get_separator(this$) {
    const tupledArg = [this$.property_2, new Appearance_Appearance(44)];
    return [tupledArg[0], tupledArg[1]];
}

export function AppearanceClasses_Appearance__get_statusbar(this$) {
    const tupledArg = [this$.property_2, new Appearance_Appearance(45)];
    return [tupledArg[0], tupledArg[1]];
}

export function AppearanceClasses_Appearance__get_tab(this$) {
    const tupledArg = [this$.property_2, new Appearance_Appearance(46)];
    return [tupledArg[0], tupledArg[1]];
}

export function AppearanceClasses_Appearance__get_tabpanels(this$) {
    const tupledArg = [this$.property_2, new Appearance_Appearance(47)];
    return [tupledArg[0], tupledArg[1]];
}

export function AppearanceClasses_Appearance__get_textfieldMultiline(this$) {
    const tupledArg = [this$.property_2, new Appearance_Appearance(48)];
    return [tupledArg[0], tupledArg[1]];
}

export function AppearanceClasses_Appearance__get_toolbar(this$) {
    const tupledArg = [this$.property_2, new Appearance_Appearance(49)];
    return [tupledArg[0], tupledArg[1]];
}

export function AppearanceClasses_Appearance__get_toolbarbutton(this$) {
    const tupledArg = [this$.property_2, new Appearance_Appearance(50)];
    return [tupledArg[0], tupledArg[1]];
}

export function AppearanceClasses_Appearance__get_toolbox(this$) {
    const tupledArg = [this$.property_2, new Appearance_Appearance(51)];
    return [tupledArg[0], tupledArg[1]];
}

export function AppearanceClasses_Appearance__get_mozMacUnifiedToolbar(this$) {
    const tupledArg = [this$.property_2, new Appearance_Appearance(52)];
    return [tupledArg[0], tupledArg[1]];
}

export function AppearanceClasses_Appearance__get_mozWinBorderlessGlass(this$) {
    const tupledArg = [this$.property_2, new Appearance_Appearance(53)];
    return [tupledArg[0], tupledArg[1]];
}

export function AppearanceClasses_Appearance__get_mozWinBrowsertabbarToolbox(this$) {
    const tupledArg = [this$.property_2, new Appearance_Appearance(54)];
    return [tupledArg[0], tupledArg[1]];
}

export function AppearanceClasses_Appearance__get_mozWinCommunicationsToolbox(this$) {
    const tupledArg = [this$.property_2, new Appearance_Appearance(55)];
    return [tupledArg[0], tupledArg[1]];
}

export function AppearanceClasses_Appearance__get_mozWinGlass(this$) {
    const tupledArg = [this$.property_2, new Appearance_Appearance(56)];
    return [tupledArg[0], tupledArg[1]];
}

export function AppearanceClasses_Appearance__get_mozWinMediaToolbox(this$) {
    const tupledArg = [this$.property_2, new Appearance_Appearance(57)];
    return [tupledArg[0], tupledArg[1]];
}

export function AppearanceClasses_Appearance__get_tooltip(this$) {
    const tupledArg = [this$.property_2, new Appearance_Appearance(58)];
    return [tupledArg[0], tupledArg[1]];
}

export function AppearanceClasses_Appearance__get_treeheadercell(this$) {
    const tupledArg = [this$.property_2, new Appearance_Appearance(59)];
    return [tupledArg[0], tupledArg[1]];
}

export function AppearanceClasses_Appearance__get_treeheadersortarrow(this$) {
    const tupledArg = [this$.property_2, new Appearance_Appearance(60)];
    return [tupledArg[0], tupledArg[1]];
}

export function AppearanceClasses_Appearance__get_treeitem(this$) {
    const tupledArg = [this$.property_2, new Appearance_Appearance(61)];
    return [tupledArg[0], tupledArg[1]];
}

export function AppearanceClasses_Appearance__get_treetwisty(this$) {
    const tupledArg = [this$.property_2, new Appearance_Appearance(62)];
    return [tupledArg[0], tupledArg[1]];
}

export function AppearanceClasses_Appearance__get_treetwistyopen(this$) {
    const tupledArg = [this$.property_2, new Appearance_Appearance(63)];
    return [tupledArg[0], tupledArg[1]];
}

export function AppearanceClasses_Appearance__get_treeview(this$) {
    const tupledArg = [this$.property_2, new Appearance_Appearance(64)];
    return [tupledArg[0], tupledArg[1]];
}

export function AppearanceClasses_Appearance__get_window(this$) {
    const tupledArg = [this$.property_2, new Appearance_Appearance(65)];
    return [tupledArg[0], tupledArg[1]];
}

//# sourceMappingURL=Appearance.fs.js.map
