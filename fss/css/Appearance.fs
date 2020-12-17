namespace Fss

module AppearanceType =
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
        interface IAppearance

[<AutoOpen>]
module Appeareance =
    open AppearanceType

    let private appearanceToString (appearance: IAppearance) =
        match appearance with
        | :? Appearance as a -> Utilities.Helpers.duToKebab a
        | :? None -> GlobalValue.none
        | :? Auto -> GlobalValue.auto
        | _ -> "Unknown appearance"

    let private appearanceValue value = PropertyValue.cssValue Property.Appearance value
    let private appearanceValue' value =
        value
        |> appearanceToString
        |> appearanceValue

    type Appearance =
        static member Value (appearance: IAppearance) = appearance |> appearanceValue'
        static member PushButton = PushButton |> appearanceValue'
        static member SquareButton = SquareButton |> appearanceValue'
        static member Button = Button |> appearanceValue'
        static member ButtonBevel = ButtonBevel |> appearanceValue'
        static member Listbox = Listbox |> appearanceValue'
        static member Listitem = Listitem |> appearanceValue'
        static member Menulist = Menulist |> appearanceValue'
        static member MenulistButton = MenulistButton |> appearanceValue'
        static member MenulistText = MenulistText |> appearanceValue'
        static member MenulistTextfield = MenulistTextfield |> appearanceValue'
        static member Menupopup = Menupopup |> appearanceValue'
        static member ScrollbarbuttonUp = ScrollbarbuttonUp |> appearanceValue'
        static member ScrollbarbuttonDown = ScrollbarbuttonDown |> appearanceValue'
        static member ScrollbarbuttonLeft = ScrollbarbuttonLeft |> appearanceValue'
        static member ScrollbarbuttonRight = ScrollbarbuttonRight |> appearanceValue'
        static member ScrollbartrackHorizontal = ScrollbartrackHorizontal |> appearanceValue'
        static member ScrollbartrackVertical = ScrollbartrackVertical |> appearanceValue'
        static member ScrollbarthumbHorizontal = ScrollbarthumbHorizontal |> appearanceValue'
        static member ScrollbarthumbVertical = ScrollbarthumbVertical |> appearanceValue'
        static member ScrollbargripperHorizontal = ScrollbargripperHorizontal |> appearanceValue'
        static member ScrollbargripperVertical = ScrollbargripperVertical |> appearanceValue'
        static member SliderHorizontal = SliderHorizontal |> appearanceValue'
        static member SliderVertical = SliderVertical |> appearanceValue'
        static member SliderthumbHorizontal = SliderthumbHorizontal |> appearanceValue'
        static member SliderthumbVertical = SliderthumbVertical |> appearanceValue'
        static member Caret = Caret |> appearanceValue'
        static member Searchfield = Searchfield |> appearanceValue'
        static member SearchfieldDecoration = SearchfieldDecoration |> appearanceValue'
        static member SearchfieldResultsDecoration = SearchfieldResultsDecoration |> appearanceValue'
        static member SearchfieldResultsButton = SearchfieldResultsButton |> appearanceValue'
        static member SearchfieldCancelButton = SearchfieldCancelButton |> appearanceValue'
        static member Textfield = Textfield |> appearanceValue'
        static member Textarea = Textarea |> appearanceValue'
        static member Checkbox = Checkbox |> appearanceValue'
        static member CheckboxContainer = CheckboxContainer |> appearanceValue'
        static member CheckboxSmall = CheckboxSmall |> appearanceValue'
        static member Dialog = Dialog |> appearanceValue'
        static member Menuitem = Menuitem |> appearanceValue'
        static member Progressbar = Progressbar |> appearanceValue'
        static member Radio = Radio |> appearanceValue'
        static member RadioContainer = RadioContainer |> appearanceValue'
        static member RadioSmall = RadioSmall |> appearanceValue'
        static member Resizer = Resizer |> appearanceValue'
        static member Scrollbar = Scrollbar |> appearanceValue'
        static member Separator = Separator |> appearanceValue'
        static member Statusbar = Statusbar |> appearanceValue'
        static member Tab = Tab |> appearanceValue'
        static member Tabpanels = Tabpanels |> appearanceValue'
        static member TextfieldMultiline = TextfieldMultiline |> appearanceValue'
        static member Toolbar = Toolbar |> appearanceValue'
        static member Toolbarbutton = Toolbarbutton |> appearanceValue'
        static member Toolbox = Toolbox |> appearanceValue'
        static member MozMacUnifiedToolbar = MozMacUnifiedToolbar |> appearanceValue'
        static member MozWinBorderlessGlass = MozWinBorderlessGlass |> appearanceValue'
        static member MozWinBrowsertabbarToolbox = MozWinBrowsertabbarToolbox |> appearanceValue'
        static member MozWinCommunicationsToolbox = MozWinCommunicationsToolbox |> appearanceValue'
        static member MozWinGlass = MozWinGlass |> appearanceValue'
        static member MozWinMediaToolbox = MozWinMediaToolbox |> appearanceValue'
        static member Tooltip = Tooltip |> appearanceValue'
        static member Treeheadercell = Treeheadercell |> appearanceValue'
        static member Treeheadersortarrow = Treeheadersortarrow |> appearanceValue'
        static member Treeitem = Treeitem |> appearanceValue'
        static member Treetwisty = Treetwisty |> appearanceValue'
        static member Treetwistyopen = Treetwistyopen |> appearanceValue'
        static member Treeview = Treeview |> appearanceValue'
        static member Window = Window |> appearanceValue'

        static member Auto = Auto |> appearanceValue'
        static member None = None |> appearanceValue'

    let Appearance' (appearance: IAppearance) = appearance |> Appearance.Value
