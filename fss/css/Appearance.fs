namespace Fss

[<AutoOpen>]
module Appearance =
    let private appearanceToString (appearance: Types.IAppearance) =
        match appearance with
        | :? Types.Appearance as a -> Utilities.Helpers.duToKebab a
        | :? Types.None' -> Types.masterTypeHelpers.none
        | :? Types.Auto -> Types.masterTypeHelpers.auto
        | _ -> "Unknown appearance"

    let private appearanceValue value = Types.propertyHelpers.cssValue Types.Property.Appearance value
    let private appearanceValue' value =
        value
        |> appearanceToString
        |> appearanceValue

    type Appearance =
        static member Value (appearance: Types.IAppearance) = appearance |> appearanceValue'
        static member PushButton = Types.PushButton |> appearanceValue'
        static member SquareButton = Types.SquareButton |> appearanceValue'
        static member Button = Types.Button |> appearanceValue'
        static member ButtonBevel = Types.ButtonBevel |> appearanceValue'
        static member Listbox = Types.Listbox |> appearanceValue'
        static member Listitem = Types.Listitem |> appearanceValue'
        static member Menulist = Types.Menulist |> appearanceValue'
        static member MenulistButton = Types.MenulistButton |> appearanceValue'
        static member MenulistText = Types.MenulistText |> appearanceValue'
        static member MenulistTextfield = Types.MenulistTextfield |> appearanceValue'
        static member Menupopup = Types.Menupopup |> appearanceValue'
        static member ScrollbarbuttonUp = Types.ScrollbarbuttonUp |> appearanceValue'
        static member ScrollbarbuttonDown = Types.ScrollbarbuttonDown |> appearanceValue'
        static member ScrollbarbuttonLeft = Types.ScrollbarbuttonLeft |> appearanceValue'
        static member ScrollbarbuttonRight = Types.ScrollbarbuttonRight |> appearanceValue'
        static member ScrollbartrackHorizontal = Types.ScrollbartrackHorizontal |> appearanceValue'
        static member ScrollbartrackVertical = Types.ScrollbartrackVertical |> appearanceValue'
        static member ScrollbarthumbHorizontal = Types.ScrollbarthumbHorizontal |> appearanceValue'
        static member ScrollbarthumbVertical = Types.ScrollbarthumbVertical |> appearanceValue'
        static member ScrollbargripperHorizontal = Types.ScrollbargripperHorizontal |> appearanceValue'
        static member ScrollbargripperVertical = Types.ScrollbargripperVertical |> appearanceValue'
        static member SliderHorizontal = Types.SliderHorizontal |> appearanceValue'
        static member SliderVertical = Types.SliderVertical |> appearanceValue'
        static member SliderthumbHorizontal = Types.SliderthumbHorizontal |> appearanceValue'
        static member SliderthumbVertical = Types.SliderthumbVertical |> appearanceValue'
        static member Caret = Types.Caret |> appearanceValue'
        static member Searchfield = Types.Searchfield |> appearanceValue'
        static member SearchfieldDecoration = Types.SearchfieldDecoration |> appearanceValue'
        static member SearchfieldResultsDecoration = Types.SearchfieldResultsDecoration |> appearanceValue'
        static member SearchfieldResultsButton = Types.SearchfieldResultsButton |> appearanceValue'
        static member SearchfieldCancelButton = Types.SearchfieldCancelButton |> appearanceValue'
        static member Textfield = Types.Textfield |> appearanceValue'
        static member Textarea = Types.Textarea |> appearanceValue'
        static member Checkbox = Types.Checkbox |> appearanceValue'
        static member CheckboxContainer = Types.CheckboxContainer |> appearanceValue'
        static member CheckboxSmall = Types.CheckboxSmall |> appearanceValue'
        static member Dialog = Types.Dialog |> appearanceValue'
        static member Menuitem = Types.Menuitem |> appearanceValue'
        static member Progressbar = Types.Progressbar |> appearanceValue'
        static member Radio = Types.Radio |> appearanceValue'
        static member RadioContainer = Types.RadioContainer |> appearanceValue'
        static member RadioSmall = Types.RadioSmall |> appearanceValue'
        static member Resizer = Types.Resizer |> appearanceValue'
        static member Scrollbar = Types.Scrollbar |> appearanceValue'
        static member Separator = Types.Separator |> appearanceValue'
        static member Statusbar = Types.Statusbar |> appearanceValue'
        static member Tab = Types.Tab |> appearanceValue'
        static member Tabpanels = Types.Tabpanels |> appearanceValue'
        static member TextfieldMultiline = Types.TextfieldMultiline |> appearanceValue'
        static member Toolbar = Types.Toolbar |> appearanceValue'
        static member Toolbarbutton = Types.Toolbarbutton |> appearanceValue'
        static member Toolbox = Types.Toolbox |> appearanceValue'
        static member MozMacUnifiedToolbar = Types.MozMacUnifiedToolbar |> appearanceValue'
        static member MozWinBorderlessGlass = Types.MozWinBorderlessGlass |> appearanceValue'
        static member MozWinBrowsertabbarToolbox = Types.MozWinBrowsertabbarToolbox |> appearanceValue'
        static member MozWinCommunicationsToolbox = Types.MozWinCommunicationsToolbox |> appearanceValue'
        static member MozWinGlass = Types.MozWinGlass |> appearanceValue'
        static member MozWinMediaToolbox = Types.MozWinMediaToolbox |> appearanceValue'
        static member Tooltip = Types.Tooltip |> appearanceValue'
        static member Treeheadercell = Types.Treeheadercell |> appearanceValue'
        static member Treeheadersortarrow = Types.Treeheadersortarrow |> appearanceValue'
        static member Treeitem = Types.Treeitem |> appearanceValue'
        static member Treetwisty = Types.Treetwisty |> appearanceValue'
        static member Treetwistyopen = Types.Treetwistyopen |> appearanceValue'
        static member Treeview = Types.Treeview |> appearanceValue'
        static member Window = Types.Window |> appearanceValue'

        static member Auto = Types.Auto |> appearanceValue'
        static member None = Types.None' |> appearanceValue'

    /// <summary>Specifies platform native styling.</summary>
    /// <param name="appearance">
    ///     can be:
    ///     - <c> Appearance </c>
    ///     - <c> None </c>
    ///     - <c> Auto </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let Appearance' (appearance: Types.IAppearance) = appearance |> Appearance.Value
