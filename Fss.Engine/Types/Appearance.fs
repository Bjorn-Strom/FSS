namespace Fss

namespace Fss.FssTypes

[<RequireQualifiedAccess>]
module Appearance =
    type Appearance =
        | PushButton
        | SquareButton
        | Button
        | ButtonBevel
        | Listbox
        | Listitem
        | Menulist
        | MenulistButton
        | MenulistText
        | MenulistTextfield
        | Menupopup
        | ScrollbarbuttonUp
        | ScrollbarbuttonDown
        | ScrollbarbuttonLeft
        | ScrollbarbuttonRight
        | ScrollbartrackHorizontal
        | ScrollbartrackVertical
        | ScrollbarthumbHorizontal
        | ScrollbarthumbVertical
        | ScrollbargripperHorizontal
        | ScrollbargripperVertical
        | SliderHorizontal
        | SliderVertical
        | SliderthumbHorizontal
        | SliderthumbVertical
        | Caret
        | Searchfield
        | SearchfieldDecoration
        | SearchfieldResultsDecoration
        | SearchfieldResultsButton
        | SearchfieldCancelButton
        | Textfield
        | Textarea
        | Checkbox
        | CheckboxContainer
        | CheckboxSmall
        | Dialog
        | Menuitem
        | Progressbar
        | Radio
        | RadioContainer
        | RadioSmall
        | Resizer
        | Scrollbar
        | Separator
        | Statusbar
        | Tab
        | Tabpanels
        | TextfieldMultiline
        | Toolbar
        | Toolbarbutton
        | Toolbox
        | MozMacUnifiedToolbar
        | MozWinBorderlessGlass
        | MozWinBrowsertabbarToolbox
        | MozWinCommunicationsToolbox
        | MozWinGlass
        | MozWinMediaToolbox
        | Tooltip
        | Treeheadercell
        | Treeheadersortarrow
        | Treeitem
        | Treetwisty
        | Treetwistyopen
        | Treeview
        | Window
        interface ICssValue with
            member this.StringifyCss() = Fss.Utilities.Helpers.toKebabCase this

[<RequireQualifiedAccess>]
module AppearanceClasses =
    type Appearance(property) =
        inherit CssRuleWithAutoNone(property)
        member this.pushButton = (property, Appearance.PushButton) |> Rule
        member this.squareButton = (property, Appearance.SquareButton) |> Rule
        member this.button = (property, Appearance.Button) |> Rule
        member this.buttonBevel = (property, Appearance.ButtonBevel) |> Rule
        member this.listbox = (property, Appearance.Listbox) |> Rule
        member this.listitem = (property, Appearance.Listitem) |> Rule
        member this.menulist = (property, Appearance.Menulist) |> Rule
        member this.menulistButton = (property, Appearance.MenulistButton) |> Rule
        member this.menulistText = (property, Appearance.MenulistText) |> Rule
        member this.menulistTextfield = (property, Appearance.MenulistTextfield) |> Rule
        member this.menupopup = (property, Appearance.Menupopup) |> Rule
        member this.scrollbarbuttonUp = (property, Appearance.ScrollbarbuttonUp) |> Rule
        member this.scrollbarbuttonDown = (property, Appearance.ScrollbarbuttonDown) |> Rule
        member this.scrollbarbuttonLeft = (property, Appearance.ScrollbarbuttonLeft) |> Rule
        member this.scrollbarbuttonRight = (property, Appearance.ScrollbarbuttonRight) |> Rule

        member this.scrollbartrackHorizontal =
            (property, Appearance.ScrollbartrackHorizontal) |> Rule

        member this.scrollbartrackVertical =
            (property, Appearance.ScrollbartrackVertical) |> Rule

        member this.scrollbarthumbHorizontal =
            (property, Appearance.ScrollbarthumbHorizontal) |> Rule

        member this.scrollbarthumbVertical =
            (property, Appearance.ScrollbarthumbVertical) |> Rule

        member this.scrollbargripperHorizontal =
            (property, Appearance.ScrollbargripperHorizontal) |> Rule

        member this.scrollbargripperVertical =
            (property, Appearance.ScrollbargripperVertical) |> Rule

        member this.sliderHorizontal = (property, Appearance.SliderHorizontal) |> Rule
        member this.sliderVertical = (property, Appearance.SliderVertical) |> Rule

        member this.sliderthumbHorizontal =
            (property, Appearance.SliderthumbHorizontal) |> Rule

        member this.sliderthumbVertical = (property, Appearance.SliderthumbVertical) |> Rule
        member this.caret = (property, Appearance.Caret) |> Rule
        member this.searchfield = (property, Appearance.Searchfield) |> Rule

        member this.searchfieldDecoration =
            (property, Appearance.SearchfieldDecoration) |> Rule

        member this.searchfieldResultsDecoration =
            (property, Appearance.SearchfieldResultsDecoration) |> Rule

        member this.searchfieldResultsButton =
            (property, Appearance.SearchfieldResultsButton) |> Rule

        member this.searchfieldCancelButton =
            (property, Appearance.SearchfieldCancelButton) |> Rule

        member this.textfield = (property, Appearance.Textfield) |> Rule
        member this.textarea = (property, Appearance.Textarea) |> Rule
        member this.checkbox = (property, Appearance.Checkbox) |> Rule
        member this.checkboxContainer = (property, Appearance.CheckboxContainer) |> Rule
        member this.checkboxSmall = (property, Appearance.CheckboxSmall) |> Rule
        member this.dialog = (property, Appearance.Dialog) |> Rule
        member this.menuitem = (property, Appearance.Menuitem) |> Rule
        member this.progressbar = (property, Appearance.Progressbar) |> Rule
        member this.radio = (property, Appearance.Radio) |> Rule
        member this.radioContainer = (property, Appearance.RadioContainer) |> Rule
        member this.radioSmall = (property, Appearance.RadioSmall) |> Rule
        member this.resizer = (property, Appearance.Resizer) |> Rule
        member this.scrollbar = (property, Appearance.Scrollbar) |> Rule
        member this.separator = (property, Appearance.Separator) |> Rule
        member this.statusbar = (property, Appearance.Statusbar) |> Rule
        member this.tab = (property, Appearance.Tab) |> Rule
        member this.tabpanels = (property, Appearance.Tabpanels) |> Rule
        member this.textfieldMultiline = (property, Appearance.TextfieldMultiline) |> Rule
        member this.toolbar = (property, Appearance.Toolbar) |> Rule
        member this.toolbarbutton = (property, Appearance.Toolbarbutton) |> Rule
        member this.toolbox = (property, Appearance.Toolbox) |> Rule
        member this.mozMacUnifiedToolbar = (property, Appearance.MozMacUnifiedToolbar) |> Rule

        member this.mozWinBorderlessGlass =
            (property, Appearance.MozWinBorderlessGlass) |> Rule

        member this.mozWinBrowsertabbarToolbox =
            (property, Appearance.MozWinBrowsertabbarToolbox) |> Rule

        member this.mozWinCommunicationsToolbox =
            (property, Appearance.MozWinCommunicationsToolbox) |> Rule

        member this.mozWinGlass = (property, Appearance.MozWinGlass) |> Rule
        member this.mozWinMediaToolbox = (property, Appearance.MozWinMediaToolbox) |> Rule
        member this.tooltip = (property, Appearance.Tooltip) |> Rule
        member this.treeheadercell = (property, Appearance.Treeheadercell) |> Rule
        member this.treeheadersortarrow = (property, Appearance.Treeheadersortarrow) |> Rule
        member this.treeitem = (property, Appearance.Treeitem) |> Rule
        member this.treetwisty = (property, Appearance.Treetwisty) |> Rule
        member this.treetwistyopen = (property, Appearance.Treetwistyopen) |> Rule
        member this.treeview = (property, Appearance.Treeview) |> Rule
        member this.window = (property, Appearance.Window) |> Rule
