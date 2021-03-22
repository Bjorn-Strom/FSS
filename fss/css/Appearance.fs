namespace Fss

[<AutoOpen>]
module Appearance =
    let private appearanceToString (appearance: Types.IAppearance) =
        match appearance with
        | :? Types.Appearance.Appearance as a -> Utilities.Helpers.duToKebab a
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
        static member PushButton = Types.Appearance.PushButton |> appearanceValue'
        static member SquareButton = Types.Appearance.SquareButton |> appearanceValue'
        static member Button = Types.Appearance.Button |> appearanceValue'
        static member ButtonBevel = Types.Appearance.ButtonBevel |> appearanceValue'
        static member Listbox = Types.Appearance.Listbox |> appearanceValue'
        static member Listitem = Types.Appearance.Listitem |> appearanceValue'
        static member Menulist = Types.Appearance.Menulist |> appearanceValue'
        static member MenulistButton = Types.Appearance.MenulistButton |> appearanceValue'
        static member MenulistText = Types.Appearance.MenulistText |> appearanceValue'
        static member MenulistTextfield = Types.Appearance.MenulistTextfield |> appearanceValue'
        static member Menupopup = Types.Appearance.Menupopup |> appearanceValue'
        static member ScrollbarbuttonUp = Types.Appearance.ScrollbarbuttonUp |> appearanceValue'
        static member ScrollbarbuttonDown = Types.Appearance.ScrollbarbuttonDown |> appearanceValue'
        static member ScrollbarbuttonLeft = Types.Appearance.ScrollbarbuttonLeft |> appearanceValue'
        static member ScrollbarbuttonRight = Types.Appearance.ScrollbarbuttonRight |> appearanceValue'
        static member ScrollbartrackHorizontal = Types.Appearance.ScrollbartrackHorizontal |> appearanceValue'
        static member ScrollbartrackVertical = Types.Appearance.ScrollbartrackVertical |> appearanceValue'
        static member ScrollbarthumbHorizontal = Types.Appearance.ScrollbarthumbHorizontal |> appearanceValue'
        static member ScrollbarthumbVertical = Types.Appearance.ScrollbarthumbVertical |> appearanceValue'
        static member ScrollbargripperHorizontal = Types.Appearance.ScrollbargripperHorizontal |> appearanceValue'
        static member ScrollbargripperVertical = Types.Appearance.ScrollbargripperVertical |> appearanceValue'
        static member SliderHorizontal = Types.Appearance.SliderHorizontal |> appearanceValue'
        static member SliderVertical = Types.Appearance.SliderVertical |> appearanceValue'
        static member SliderthumbHorizontal = Types.Appearance.SliderthumbHorizontal |> appearanceValue'
        static member SliderthumbVertical = Types.Appearance.SliderthumbVertical |> appearanceValue'
        static member Caret = Types.Appearance.Caret |> appearanceValue'
        static member Searchfield = Types.Appearance.Searchfield |> appearanceValue'
        static member SearchfieldDecoration = Types.Appearance.SearchfieldDecoration |> appearanceValue'
        static member SearchfieldResultsDecoration = Types.Appearance.SearchfieldResultsDecoration |> appearanceValue'
        static member SearchfieldResultsButton = Types.Appearance.SearchfieldResultsButton |> appearanceValue'
        static member SearchfieldCancelButton = Types.Appearance.SearchfieldCancelButton |> appearanceValue'
        static member Textfield = Types.Appearance.Textfield |> appearanceValue'
        static member Textarea = Types.Appearance.Textarea |> appearanceValue'
        static member Checkbox = Types.Appearance.Checkbox |> appearanceValue'
        static member CheckboxContainer = Types.Appearance.CheckboxContainer |> appearanceValue'
        static member CheckboxSmall = Types.Appearance.CheckboxSmall |> appearanceValue'
        static member Dialog = Types.Appearance.Dialog |> appearanceValue'
        static member Menuitem = Types.Appearance.Menuitem |> appearanceValue'
        static member Progressbar = Types.Appearance.Progressbar |> appearanceValue'
        static member Radio = Types.Appearance.Radio |> appearanceValue'
        static member RadioContainer = Types.Appearance.RadioContainer |> appearanceValue'
        static member RadioSmall = Types.Appearance.RadioSmall |> appearanceValue'
        static member Resizer = Types.Appearance.Resizer |> appearanceValue'
        static member Scrollbar = Types.Appearance.Scrollbar |> appearanceValue'
        static member Separator = Types.Appearance.Separator |> appearanceValue'
        static member Statusbar = Types.Appearance.Statusbar |> appearanceValue'
        static member Tab = Types.Appearance.Tab |> appearanceValue'
        static member Tabpanels = Types.Appearance.Tabpanels |> appearanceValue'
        static member TextfieldMultiline = Types.Appearance.TextfieldMultiline |> appearanceValue'
        static member Toolbar = Types.Appearance.Toolbar |> appearanceValue'
        static member Toolbarbutton = Types.Appearance.Toolbarbutton |> appearanceValue'
        static member Toolbox = Types.Appearance.Toolbox |> appearanceValue'
        static member MozMacUnifiedToolbar = Types.Appearance.MozMacUnifiedToolbar |> appearanceValue'
        static member MozWinBorderlessGlass = Types.Appearance.MozWinBorderlessGlass |> appearanceValue'
        static member MozWinBrowsertabbarToolbox = Types.Appearance.MozWinBrowsertabbarToolbox |> appearanceValue'
        static member MozWinCommunicationsToolbox = Types.Appearance.MozWinCommunicationsToolbox |> appearanceValue'
        static member MozWinGlass = Types.Appearance.MozWinGlass |> appearanceValue'
        static member MozWinMediaToolbox = Types.Appearance.MozWinMediaToolbox |> appearanceValue'
        static member Tooltip = Types.Appearance.Tooltip |> appearanceValue'
        static member Treeheadercell = Types.Appearance.Treeheadercell |> appearanceValue'
        static member Treeheadersortarrow = Types.Appearance.Treeheadersortarrow |> appearanceValue'
        static member Treeitem = Types.Appearance.Treeitem |> appearanceValue'
        static member Treetwisty = Types.Appearance.Treetwisty |> appearanceValue'
        static member Treetwistyopen = Types.Appearance.Treetwistyopen |> appearanceValue'
        static member Treeview = Types.Appearance.Treeview |> appearanceValue'
        static member Window = Types.Appearance.Window |> appearanceValue'

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
