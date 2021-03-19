namespace Fss
open FssTypes

[<AutoOpen>]
module Appeareance =
    let private appearanceToString (appearance: IAppearance) =
        match appearance with
        | :? Appearance.Appearance as a -> Utilities.Helpers.duToKebab a
        | :? None' -> GlobalValue.none
        | :? Auto -> GlobalValue.auto
        | _ -> "Unknown appearance"

    let private appearanceValue value = PropertyValue.cssValue Property.Appearance value
    let private appearanceValue' value =
        value
        |> appearanceToString
        |> appearanceValue

    type Appearance =
        static member Value (appearance: IAppearance) = appearance |> appearanceValue'
        static member PushButton = Appearance.PushButton |> appearanceValue'
        static member SquareButton = Appearance.SquareButton |> appearanceValue'
        static member Button = Appearance.Button |> appearanceValue'
        static member ButtonBevel = Appearance.ButtonBevel |> appearanceValue'
        static member Listbox = Appearance.Listbox |> appearanceValue'
        static member Listitem = Appearance.Listitem |> appearanceValue'
        static member Menulist = Appearance.Menulist |> appearanceValue'
        static member MenulistButton = Appearance.MenulistButton |> appearanceValue'
        static member MenulistText = Appearance.MenulistText |> appearanceValue'
        static member MenulistTextfield = Appearance.MenulistTextfield |> appearanceValue'
        static member Menupopup = Appearance.Menupopup |> appearanceValue'
        static member ScrollbarbuttonUp = Appearance.ScrollbarbuttonUp |> appearanceValue'
        static member ScrollbarbuttonDown = Appearance.ScrollbarbuttonDown |> appearanceValue'
        static member ScrollbarbuttonLeft = Appearance.ScrollbarbuttonLeft |> appearanceValue'
        static member ScrollbarbuttonRight = Appearance.ScrollbarbuttonRight |> appearanceValue'
        static member ScrollbartrackHorizontal = Appearance.ScrollbartrackHorizontal |> appearanceValue'
        static member ScrollbartrackVertical = Appearance.ScrollbartrackVertical |> appearanceValue'
        static member ScrollbarthumbHorizontal = Appearance.ScrollbarthumbHorizontal |> appearanceValue'
        static member ScrollbarthumbVertical = Appearance.ScrollbarthumbVertical |> appearanceValue'
        static member ScrollbargripperHorizontal = Appearance.ScrollbargripperHorizontal |> appearanceValue'
        static member ScrollbargripperVertical = Appearance.ScrollbargripperVertical |> appearanceValue'
        static member SliderHorizontal = Appearance.SliderHorizontal |> appearanceValue'
        static member SliderVertical = Appearance.SliderVertical |> appearanceValue'
        static member SliderthumbHorizontal = Appearance.SliderthumbHorizontal |> appearanceValue'
        static member SliderthumbVertical = Appearance.SliderthumbVertical |> appearanceValue'
        static member Caret = Appearance.Caret |> appearanceValue'
        static member Searchfield = Appearance.Searchfield |> appearanceValue'
        static member SearchfieldDecoration = Appearance.SearchfieldDecoration |> appearanceValue'
        static member SearchfieldResultsDecoration = Appearance.SearchfieldResultsDecoration |> appearanceValue'
        static member SearchfieldResultsButton = Appearance.SearchfieldResultsButton |> appearanceValue'
        static member SearchfieldCancelButton = Appearance.SearchfieldCancelButton |> appearanceValue'
        static member Textfield = Appearance.Textfield |> appearanceValue'
        static member Textarea = Appearance.Textarea |> appearanceValue'
        static member Checkbox = Appearance.Checkbox |> appearanceValue'
        static member CheckboxContainer = Appearance.CheckboxContainer |> appearanceValue'
        static member CheckboxSmall = Appearance.CheckboxSmall |> appearanceValue'
        static member Dialog = Appearance.Dialog |> appearanceValue'
        static member Menuitem = Appearance.Menuitem |> appearanceValue'
        static member Progressbar = Appearance.Progressbar |> appearanceValue'
        static member Radio = Appearance.Radio |> appearanceValue'
        static member RadioContainer = Appearance.RadioContainer |> appearanceValue'
        static member RadioSmall = Appearance.RadioSmall |> appearanceValue'
        static member Resizer = Appearance.Resizer |> appearanceValue'
        static member Scrollbar = Appearance.Scrollbar |> appearanceValue'
        static member Separator = Appearance.Separator |> appearanceValue'
        static member Statusbar = Appearance.Statusbar |> appearanceValue'
        static member Tab = Appearance.Tab |> appearanceValue'
        static member Tabpanels = Appearance.Tabpanels |> appearanceValue'
        static member TextfieldMultiline = Appearance.TextfieldMultiline |> appearanceValue'
        static member Toolbar = Appearance.Toolbar |> appearanceValue'
        static member Toolbarbutton = Appearance.Toolbarbutton |> appearanceValue'
        static member Toolbox = Appearance.Toolbox |> appearanceValue'
        static member MozMacUnifiedToolbar = Appearance.MozMacUnifiedToolbar |> appearanceValue'
        static member MozWinBorderlessGlass = Appearance.MozWinBorderlessGlass |> appearanceValue'
        static member MozWinBrowsertabbarToolbox = Appearance.MozWinBrowsertabbarToolbox |> appearanceValue'
        static member MozWinCommunicationsToolbox = Appearance.MozWinCommunicationsToolbox |> appearanceValue'
        static member MozWinGlass = Appearance.MozWinGlass |> appearanceValue'
        static member MozWinMediaToolbox = Appearance.MozWinMediaToolbox |> appearanceValue'
        static member Tooltip = Appearance.Tooltip |> appearanceValue'
        static member Treeheadercell = Appearance.Treeheadercell |> appearanceValue'
        static member Treeheadersortarrow = Appearance.Treeheadersortarrow |> appearanceValue'
        static member Treeitem = Appearance.Treeitem |> appearanceValue'
        static member Treetwisty = Appearance.Treetwisty |> appearanceValue'
        static member Treetwistyopen = Appearance.Treetwistyopen |> appearanceValue'
        static member Treeview = Appearance.Treeview |> appearanceValue'
        static member Window = Appearance.Window |> appearanceValue'

        static member Auto = Auto |> appearanceValue'
        static member None = None' |> appearanceValue'

    /// <summary>Specifies platform native styling.</summary>
    /// <param name="appearance">
    ///     can be:
    ///     - <c> Appearance </c>
    ///     - <c> None </c>
    ///     - <c> Auto </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let Appearance' (appearance: IAppearance) = appearance |> Appearance.Value
