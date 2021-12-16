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
            member this.Stringify() = Fss.Utilities.Helpers.toKebabCase this

    [<RequireQualifiedAccess>]
    module AppearanceClasses =
        type Appearance(property) =
            inherit CssRuleWithAutoNone(property)
            member this.pushButton = (property, PushButton) |> Rule
            member this.squareButton = (property, SquareButton) |> Rule
            member this.button = (property, Button) |> Rule
            member this.buttonBevel = (property, ButtonBevel) |> Rule
            member this.listbox = (property, Listbox) |> Rule
            member this.listitem = (property, Listitem) |> Rule
            member this.menulist = (property, Menulist) |> Rule
            member this.menulistButton = (property, MenulistButton) |> Rule
            member this.menulistText = (property, MenulistText) |> Rule
            member this.menulistTextfield = (property, MenulistTextfield) |> Rule
            member this.menupopup = (property, Menupopup) |> Rule
            member this.scrollbarbuttonUp = (property, ScrollbarbuttonUp) |> Rule
            member this.scrollbarbuttonDown = (property, ScrollbarbuttonDown) |> Rule
            member this.scrollbarbuttonLeft = (property, ScrollbarbuttonLeft) |> Rule
            member this.scrollbarbuttonRight = (property, ScrollbarbuttonRight) |> Rule

            member this.scrollbartrackHorizontal =
                (property, ScrollbartrackHorizontal) |> Rule

            member this.scrollbartrackVertical =
                (property, ScrollbartrackVertical) |> Rule

            member this.scrollbarthumbHorizontal =
                (property, ScrollbarthumbHorizontal) |> Rule

            member this.scrollbarthumbVertical =
                (property, ScrollbarthumbVertical) |> Rule

            member this.scrollbargripperHorizontal =
                (property, ScrollbargripperHorizontal) |> Rule

            member this.scrollbargripperVertical =
                (property, ScrollbargripperVertical) |> Rule

            member this.sliderHorizontal = (property, SliderHorizontal) |> Rule
            member this.sliderVertical = (property, SliderVertical) |> Rule

            member this.sliderthumbHorizontal =
                (property, SliderthumbHorizontal) |> Rule

            member this.sliderthumbVertical = (property, SliderthumbVertical) |> Rule
            member this.caret = (property, Caret) |> Rule
            member this.searchfield = (property, Searchfield) |> Rule

            member this.searchfieldDecoration =
                (property, SearchfieldDecoration) |> Rule

            member this.searchfieldResultsDecoration =
                (property, SearchfieldResultsDecoration) |> Rule

            member this.searchfieldResultsButton =
                (property, SearchfieldResultsButton) |> Rule

            member this.searchfieldCancelButton =
                (property, SearchfieldCancelButton) |> Rule

            member this.textfield = (property, Textfield) |> Rule
            member this.textarea = (property, Textarea) |> Rule
            member this.checkbox = (property, Checkbox) |> Rule
            member this.checkboxContainer = (property, CheckboxContainer) |> Rule
            member this.checkboxSmall = (property, CheckboxSmall) |> Rule
            member this.dialog = (property, Dialog) |> Rule
            member this.menuitem = (property, Menuitem) |> Rule
            member this.progressbar = (property, Progressbar) |> Rule
            member this.radio = (property, Radio) |> Rule
            member this.radioContainer = (property, RadioContainer) |> Rule
            member this.radioSmall = (property, RadioSmall) |> Rule
            member this.resizer = (property, Resizer) |> Rule
            member this.scrollbar = (property, Scrollbar) |> Rule
            member this.separator = (property, Separator) |> Rule
            member this.statusbar = (property, Statusbar) |> Rule
            member this.tab = (property, Tab) |> Rule
            member this.tabpanels = (property, Tabpanels) |> Rule
            member this.textfieldMultiline = (property, TextfieldMultiline) |> Rule
            member this.toolbar = (property, Toolbar) |> Rule
            member this.toolbarbutton = (property, Toolbarbutton) |> Rule
            member this.toolbox = (property, Toolbox) |> Rule
            member this.mozMacUnifiedToolbar = (property, MozMacUnifiedToolbar) |> Rule

            member this.mozWinBorderlessGlass =
                (property, MozWinBorderlessGlass) |> Rule

            member this.mozWinBrowsertabbarToolbox =
                (property, MozWinBrowsertabbarToolbox) |> Rule

            member this.mozWinCommunicationsToolbox =
                (property, MozWinCommunicationsToolbox) |> Rule

            member this.mozWinGlass = (property, MozWinGlass) |> Rule
            member this.mozWinMediaToolbox = (property, MozWinMediaToolbox) |> Rule
            member this.tooltip = (property, Tooltip) |> Rule
            member this.treeheadercell = (property, Treeheadercell) |> Rule
            member this.treeheadersortarrow = (property, Treeheadersortarrow) |> Rule
            member this.treeitem = (property, Treeitem) |> Rule
            member this.treetwisty = (property, Treetwisty) |> Rule
            member this.treetwistyopen = (property, Treetwistyopen) |> Rule
            member this.treeview = (property, Treeview) |> Rule
            member this.window = (property, Window) |> Rule
