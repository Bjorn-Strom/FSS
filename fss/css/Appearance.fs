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
        static member value (appearance: FssTypes.IAppearance) = appearance |> appearanceValue'
        static member pushButton = FssTypes.Appearance.PushButton |> appearanceValue'
        static member squareButton = FssTypes.Appearance.SquareButton |> appearanceValue'
        static member button = FssTypes.Appearance.Button |> appearanceValue'
        static member buttonBevel = FssTypes.Appearance.ButtonBevel |> appearanceValue'
        static member listbox = FssTypes.Appearance.Listbox |> appearanceValue'
        static member listitem = FssTypes.Appearance.Listitem |> appearanceValue'
        static member menulist = FssTypes.Appearance.Menulist |> appearanceValue'
        static member menulistButton = FssTypes.Appearance.MenulistButton |> appearanceValue'
        static member menulistText = FssTypes.Appearance.MenulistText |> appearanceValue'
        static member menulistTextfield = FssTypes.Appearance.MenulistTextfield |> appearanceValue'
        static member menupopup = FssTypes.Appearance.Menupopup |> appearanceValue'
        static member scrollbarbuttonUp = FssTypes.Appearance.ScrollbarbuttonUp |> appearanceValue'
        static member scrollbarbuttonDown = FssTypes.Appearance.ScrollbarbuttonDown |> appearanceValue'
        static member scrollbarbuttonLeft = FssTypes.Appearance.ScrollbarbuttonLeft |> appearanceValue'
        static member scrollbarbuttonRight = FssTypes.Appearance.ScrollbarbuttonRight |> appearanceValue'
        static member scrollbartrackHorizontal = FssTypes.Appearance.ScrollbartrackHorizontal |> appearanceValue'
        static member scrollbartrackVertical = FssTypes.Appearance.ScrollbartrackVertical |> appearanceValue'
        static member scrollbarthumbHorizontal = FssTypes.Appearance.ScrollbarthumbHorizontal |> appearanceValue'
        static member scrollbarthumbVertical = FssTypes.Appearance.ScrollbarthumbVertical |> appearanceValue'
        static member scrollbargripperHorizontal = FssTypes.Appearance.ScrollbargripperHorizontal |> appearanceValue'
        static member scrollbargripperVertical = FssTypes.Appearance.ScrollbargripperVertical |> appearanceValue'
        static member sliderHorizontal = FssTypes.Appearance.SliderHorizontal |> appearanceValue'
        static member sliderVertical = FssTypes.Appearance.SliderVertical |> appearanceValue'
        static member sliderthumbHorizontal = FssTypes.Appearance.SliderthumbHorizontal |> appearanceValue'
        static member sliderthumbVertical = FssTypes.Appearance.SliderthumbVertical |> appearanceValue'
        static member caret = FssTypes.Appearance.Caret |> appearanceValue'
        static member searchfield = FssTypes.Appearance.Searchfield |> appearanceValue'
        static member searchfieldDecoration = FssTypes.Appearance.SearchfieldDecoration |> appearanceValue'
        static member searchfieldResultsDecoration = FssTypes.Appearance.SearchfieldResultsDecoration |> appearanceValue'
        static member searchfieldResultsButton = FssTypes.Appearance.SearchfieldResultsButton |> appearanceValue'
        static member searchfieldCancelButton = FssTypes.Appearance.SearchfieldCancelButton |> appearanceValue'
        static member textfield = FssTypes.Appearance.Textfield |> appearanceValue'
        static member textarea = FssTypes.Appearance.Textarea |> appearanceValue'
        static member checkbox = FssTypes.Appearance.Checkbox |> appearanceValue'
        static member checkboxContainer = FssTypes.Appearance.CheckboxContainer |> appearanceValue'
        static member checkboxSmall = FssTypes.Appearance.CheckboxSmall |> appearanceValue'
        static member dialog = FssTypes.Appearance.Dialog |> appearanceValue'
        static member menuitem = FssTypes.Appearance.Menuitem |> appearanceValue'
        static member progressbar = FssTypes.Appearance.Progressbar |> appearanceValue'
        static member radio = FssTypes.Appearance.Radio |> appearanceValue'
        static member radioContainer = FssTypes.Appearance.RadioContainer |> appearanceValue'
        static member radioSmall = FssTypes.Appearance.RadioSmall |> appearanceValue'
        static member resizer = FssTypes.Appearance.Resizer |> appearanceValue'
        static member scrollbar = FssTypes.Appearance.Scrollbar |> appearanceValue'
        static member separator = FssTypes.Appearance.Separator |> appearanceValue'
        static member statusbar = FssTypes.Appearance.Statusbar |> appearanceValue'
        static member tab = FssTypes.Appearance.Tab |> appearanceValue'
        static member tabpanels = FssTypes.Appearance.Tabpanels |> appearanceValue'
        static member textfieldMultiline = FssTypes.Appearance.TextfieldMultiline |> appearanceValue'
        static member toolbar = FssTypes.Appearance.Toolbar |> appearanceValue'
        static member toolbarbutton = FssTypes.Appearance.Toolbarbutton |> appearanceValue'
        static member toolbox = FssTypes.Appearance.Toolbox |> appearanceValue'
        static member mozMacUnifiedToolbar = FssTypes.Appearance.MozMacUnifiedToolbar |> appearanceValue'
        static member mozWinBorderlessGlass = FssTypes.Appearance.MozWinBorderlessGlass |> appearanceValue'
        static member mozWinBrowsertabbarToolbox = FssTypes.Appearance.MozWinBrowsertabbarToolbox |> appearanceValue'
        static member mozWinCommunicationsToolbox = FssTypes.Appearance.MozWinCommunicationsToolbox |> appearanceValue'
        static member mozWinGlass = FssTypes.Appearance.MozWinGlass |> appearanceValue'
        static member mozWinMediaToolbox = FssTypes.Appearance.MozWinMediaToolbox |> appearanceValue'
        static member tooltip = FssTypes.Appearance.Tooltip |> appearanceValue'
        static member treeheadercell = FssTypes.Appearance.Treeheadercell |> appearanceValue'
        static member treeheadersortarrow = FssTypes.Appearance.Treeheadersortarrow |> appearanceValue'
        static member treeitem = FssTypes.Appearance.Treeitem |> appearanceValue'
        static member treetwisty = FssTypes.Appearance.Treetwisty |> appearanceValue'
        static member treetwistyopen = FssTypes.Appearance.Treetwistyopen |> appearanceValue'
        static member treeview = FssTypes.Appearance.Treeview |> appearanceValue'
        static member window = FssTypes.Appearance.Window |> appearanceValue'

        static member auto = FssTypes.Auto |> appearanceValue'
        static member none = FssTypes.None' |> appearanceValue'

    /// <summary>Specifies platform native styling.</summary>
    /// <param name="appearance">
    ///     can be:
    ///     - <c> Appearance </c>
    ///     - <c> None </c>
    ///     - <c> Auto </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let Appearance' (appearance: FssTypes.IAppearance) = appearance |> Appearance.value
