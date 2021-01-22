namespace Fss

[<RequireQualifiedAccess>]
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
    let private appearanceToString (appearance: IAppearance) =
        match appearance with
        | :? AppearanceType.Appearance as a -> Utilities.Helpers.duToKebab a
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
        static member PushButton = AppearanceType.PushButton |> appearanceValue'
        static member SquareButton = AppearanceType.SquareButton |> appearanceValue'
        static member Button = AppearanceType.Button |> appearanceValue'
        static member ButtonBevel = AppearanceType.ButtonBevel |> appearanceValue'
        static member Listbox = AppearanceType.Listbox |> appearanceValue'
        static member Listitem = AppearanceType.Listitem |> appearanceValue'
        static member Menulist = AppearanceType.Menulist |> appearanceValue'
        static member MenulistButton = AppearanceType.MenulistButton |> appearanceValue'
        static member MenulistText = AppearanceType.MenulistText |> appearanceValue'
        static member MenulistTextfield = AppearanceType.MenulistTextfield |> appearanceValue'
        static member Menupopup = AppearanceType.Menupopup |> appearanceValue'
        static member ScrollbarbuttonUp = AppearanceType.ScrollbarbuttonUp |> appearanceValue'
        static member ScrollbarbuttonDown = AppearanceType.ScrollbarbuttonDown |> appearanceValue'
        static member ScrollbarbuttonLeft = AppearanceType.ScrollbarbuttonLeft |> appearanceValue'
        static member ScrollbarbuttonRight = AppearanceType.ScrollbarbuttonRight |> appearanceValue'
        static member ScrollbartrackHorizontal = AppearanceType.ScrollbartrackHorizontal |> appearanceValue'
        static member ScrollbartrackVertical = AppearanceType.ScrollbartrackVertical |> appearanceValue'
        static member ScrollbarthumbHorizontal = AppearanceType.ScrollbarthumbHorizontal |> appearanceValue'
        static member ScrollbarthumbVertical = AppearanceType.ScrollbarthumbVertical |> appearanceValue'
        static member ScrollbargripperHorizontal = AppearanceType.ScrollbargripperHorizontal |> appearanceValue'
        static member ScrollbargripperVertical = AppearanceType.ScrollbargripperVertical |> appearanceValue'
        static member SliderHorizontal = AppearanceType.SliderHorizontal |> appearanceValue'
        static member SliderVertical = AppearanceType.SliderVertical |> appearanceValue'
        static member SliderthumbHorizontal = AppearanceType.SliderthumbHorizontal |> appearanceValue'
        static member SliderthumbVertical = AppearanceType.SliderthumbVertical |> appearanceValue'
        static member Caret = AppearanceType.Caret |> appearanceValue'
        static member Searchfield = AppearanceType.Searchfield |> appearanceValue'
        static member SearchfieldDecoration = AppearanceType.SearchfieldDecoration |> appearanceValue'
        static member SearchfieldResultsDecoration = AppearanceType.SearchfieldResultsDecoration |> appearanceValue'
        static member SearchfieldResultsButton = AppearanceType.SearchfieldResultsButton |> appearanceValue'
        static member SearchfieldCancelButton = AppearanceType.SearchfieldCancelButton |> appearanceValue'
        static member Textfield = AppearanceType.Textfield |> appearanceValue'
        static member Textarea = AppearanceType.Textarea |> appearanceValue'
        static member Checkbox = AppearanceType.Checkbox |> appearanceValue'
        static member CheckboxContainer = AppearanceType.CheckboxContainer |> appearanceValue'
        static member CheckboxSmall = AppearanceType.CheckboxSmall |> appearanceValue'
        static member Dialog = AppearanceType.Dialog |> appearanceValue'
        static member Menuitem = AppearanceType.Menuitem |> appearanceValue'
        static member Progressbar = AppearanceType.Progressbar |> appearanceValue'
        static member Radio = AppearanceType.Radio |> appearanceValue'
        static member RadioContainer = AppearanceType.RadioContainer |> appearanceValue'
        static member RadioSmall = AppearanceType.RadioSmall |> appearanceValue'
        static member Resizer = AppearanceType.Resizer |> appearanceValue'
        static member Scrollbar = AppearanceType.Scrollbar |> appearanceValue'
        static member Separator = AppearanceType.Separator |> appearanceValue'
        static member Statusbar = AppearanceType.Statusbar |> appearanceValue'
        static member Tab = AppearanceType.Tab |> appearanceValue'
        static member Tabpanels = AppearanceType.Tabpanels |> appearanceValue'
        static member TextfieldMultiline = AppearanceType.TextfieldMultiline |> appearanceValue'
        static member Toolbar = AppearanceType.Toolbar |> appearanceValue'
        static member Toolbarbutton = AppearanceType.Toolbarbutton |> appearanceValue'
        static member Toolbox = AppearanceType.Toolbox |> appearanceValue'
        static member MozMacUnifiedToolbar = AppearanceType.MozMacUnifiedToolbar |> appearanceValue'
        static member MozWinBorderlessGlass = AppearanceType.MozWinBorderlessGlass |> appearanceValue'
        static member MozWinBrowsertabbarToolbox = AppearanceType.MozWinBrowsertabbarToolbox |> appearanceValue'
        static member MozWinCommunicationsToolbox = AppearanceType.MozWinCommunicationsToolbox |> appearanceValue'
        static member MozWinGlass = AppearanceType.MozWinGlass |> appearanceValue'
        static member MozWinMediaToolbox = AppearanceType.MozWinMediaToolbox |> appearanceValue'
        static member Tooltip = AppearanceType.Tooltip |> appearanceValue'
        static member Treeheadercell = AppearanceType.Treeheadercell |> appearanceValue'
        static member Treeheadersortarrow = AppearanceType.Treeheadersortarrow |> appearanceValue'
        static member Treeitem = AppearanceType.Treeitem |> appearanceValue'
        static member Treetwisty = AppearanceType.Treetwisty |> appearanceValue'
        static member Treetwistyopen = AppearanceType.Treetwistyopen |> appearanceValue'
        static member Treeview = AppearanceType.Treeview |> appearanceValue'
        static member Window = AppearanceType.Window |> appearanceValue'

        static member Auto = Auto |> appearanceValue'
        static member None = None |> appearanceValue'

    /// <summary>Specifies platform native styling.</summary>
    /// <param name="appearance">
    ///     can be:
    ///     - <c> Appearance </c>
    ///     - <c> None </c>
    ///     - <c> Auto </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let Appearance' (appearance: IAppearance) = appearance |> Appearance.Value
