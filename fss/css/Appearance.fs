namespace Fss

[<AutoOpen>]
module Appearance =
    let private appearanceToString (appearance: FssTypes.IAppearance) =
        match appearance with
        | :? FssTypes.Appearance.Appearance as a -> Utilities.Helpers.duToKebab a
        | :? FssTypes.None' -> FssTypes.masterTypeHelpers.none
        | :? FssTypes.Auto -> FssTypes.masterTypeHelpers.auto
        | _ -> "Unknown appearance"

    let private appearanceValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.Appearance value
    let private appearanceValue' value =
        value
        |> appearanceToString
        |> appearanceValue

    type Appearance =
        static member Value (appearance: FssTypes.IAppearance) = appearance |> appearanceValue'
        static member PushButton = FssTypes.Appearance.PushButton |> appearanceValue'
        static member SquareButton = FssTypes.Appearance.SquareButton |> appearanceValue'
        static member Button = FssTypes.Appearance.Button |> appearanceValue'
        static member ButtonBevel = FssTypes.Appearance.ButtonBevel |> appearanceValue'
        static member Listbox = FssTypes.Appearance.Listbox |> appearanceValue'
        static member Listitem = FssTypes.Appearance.Listitem |> appearanceValue'
        static member Menulist = FssTypes.Appearance.Menulist |> appearanceValue'
        static member MenulistButton = FssTypes.Appearance.MenulistButton |> appearanceValue'
        static member MenulistText = FssTypes.Appearance.MenulistText |> appearanceValue'
        static member MenulistTextfield = FssTypes.Appearance.MenulistTextfield |> appearanceValue'
        static member Menupopup = FssTypes.Appearance.Menupopup |> appearanceValue'
        static member ScrollbarbuttonUp = FssTypes.Appearance.ScrollbarbuttonUp |> appearanceValue'
        static member ScrollbarbuttonDown = FssTypes.Appearance.ScrollbarbuttonDown |> appearanceValue'
        static member ScrollbarbuttonLeft = FssTypes.Appearance.ScrollbarbuttonLeft |> appearanceValue'
        static member ScrollbarbuttonRight = FssTypes.Appearance.ScrollbarbuttonRight |> appearanceValue'
        static member ScrollbartrackHorizontal = FssTypes.Appearance.ScrollbartrackHorizontal |> appearanceValue'
        static member ScrollbartrackVertical = FssTypes.Appearance.ScrollbartrackVertical |> appearanceValue'
        static member ScrollbarthumbHorizontal = FssTypes.Appearance.ScrollbarthumbHorizontal |> appearanceValue'
        static member ScrollbarthumbVertical = FssTypes.Appearance.ScrollbarthumbVertical |> appearanceValue'
        static member ScrollbargripperHorizontal = FssTypes.Appearance.ScrollbargripperHorizontal |> appearanceValue'
        static member ScrollbargripperVertical = FssTypes.Appearance.ScrollbargripperVertical |> appearanceValue'
        static member SliderHorizontal = FssTypes.Appearance.SliderHorizontal |> appearanceValue'
        static member SliderVertical = FssTypes.Appearance.SliderVertical |> appearanceValue'
        static member SliderthumbHorizontal = FssTypes.Appearance.SliderthumbHorizontal |> appearanceValue'
        static member SliderthumbVertical = FssTypes.Appearance.SliderthumbVertical |> appearanceValue'
        static member Caret = FssTypes.Appearance.Caret |> appearanceValue'
        static member Searchfield = FssTypes.Appearance.Searchfield |> appearanceValue'
        static member SearchfieldDecoration = FssTypes.Appearance.SearchfieldDecoration |> appearanceValue'
        static member SearchfieldResultsDecoration = FssTypes.Appearance.SearchfieldResultsDecoration |> appearanceValue'
        static member SearchfieldResultsButton = FssTypes.Appearance.SearchfieldResultsButton |> appearanceValue'
        static member SearchfieldCancelButton = FssTypes.Appearance.SearchfieldCancelButton |> appearanceValue'
        static member Textfield = FssTypes.Appearance.Textfield |> appearanceValue'
        static member Textarea = FssTypes.Appearance.Textarea |> appearanceValue'
        static member Checkbox = FssTypes.Appearance.Checkbox |> appearanceValue'
        static member CheckboxContainer = FssTypes.Appearance.CheckboxContainer |> appearanceValue'
        static member CheckboxSmall = FssTypes.Appearance.CheckboxSmall |> appearanceValue'
        static member Dialog = FssTypes.Appearance.Dialog |> appearanceValue'
        static member Menuitem = FssTypes.Appearance.Menuitem |> appearanceValue'
        static member Progressbar = FssTypes.Appearance.Progressbar |> appearanceValue'
        static member Radio = FssTypes.Appearance.Radio |> appearanceValue'
        static member RadioContainer = FssTypes.Appearance.RadioContainer |> appearanceValue'
        static member RadioSmall = FssTypes.Appearance.RadioSmall |> appearanceValue'
        static member Resizer = FssTypes.Appearance.Resizer |> appearanceValue'
        static member Scrollbar = FssTypes.Appearance.Scrollbar |> appearanceValue'
        static member Separator = FssTypes.Appearance.Separator |> appearanceValue'
        static member Statusbar = FssTypes.Appearance.Statusbar |> appearanceValue'
        static member Tab = FssTypes.Appearance.Tab |> appearanceValue'
        static member Tabpanels = FssTypes.Appearance.Tabpanels |> appearanceValue'
        static member TextfieldMultiline = FssTypes.Appearance.TextfieldMultiline |> appearanceValue'
        static member Toolbar = FssTypes.Appearance.Toolbar |> appearanceValue'
        static member Toolbarbutton = FssTypes.Appearance.Toolbarbutton |> appearanceValue'
        static member Toolbox = FssTypes.Appearance.Toolbox |> appearanceValue'
        static member MozMacUnifiedToolbar = FssTypes.Appearance.MozMacUnifiedToolbar |> appearanceValue'
        static member MozWinBorderlessGlass = FssTypes.Appearance.MozWinBorderlessGlass |> appearanceValue'
        static member MozWinBrowsertabbarToolbox = FssTypes.Appearance.MozWinBrowsertabbarToolbox |> appearanceValue'
        static member MozWinCommunicationsToolbox = FssTypes.Appearance.MozWinCommunicationsToolbox |> appearanceValue'
        static member MozWinGlass = FssTypes.Appearance.MozWinGlass |> appearanceValue'
        static member MozWinMediaToolbox = FssTypes.Appearance.MozWinMediaToolbox |> appearanceValue'
        static member Tooltip = FssTypes.Appearance.Tooltip |> appearanceValue'
        static member Treeheadercell = FssTypes.Appearance.Treeheadercell |> appearanceValue'
        static member Treeheadersortarrow = FssTypes.Appearance.Treeheadersortarrow |> appearanceValue'
        static member Treeitem = FssTypes.Appearance.Treeitem |> appearanceValue'
        static member Treetwisty = FssTypes.Appearance.Treetwisty |> appearanceValue'
        static member Treetwistyopen = FssTypes.Appearance.Treetwistyopen |> appearanceValue'
        static member Treeview = FssTypes.Appearance.Treeview |> appearanceValue'
        static member Window = FssTypes.Appearance.Window |> appearanceValue'

        static member Auto = FssTypes.Auto |> appearanceValue'
        static member None = FssTypes.None' |> appearanceValue'

    /// <summary>Specifies platform native styling.</summary>
    /// <param name="appearance">
    ///     can be:
    ///     - <c> Appearance </c>
    ///     - <c> None </c>
    ///     - <c> Auto </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let Appearance' (appearance: FssTypes.IAppearance) = appearance |> Appearance.Value
