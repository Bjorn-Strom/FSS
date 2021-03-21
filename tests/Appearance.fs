namespace FSSTests

open Fable.Mocha
open Fable.Core.JsInterop
open Utils
open Fss

module Appearance =
    let tests =
        testList "Appearance"
            [
                test
                    "Appearance push button"
                    [Appearance.PushButton]
                    ["appearance" ==> "push-button"]
                test
                    "Appearance square button"
                    [Appearance.SquareButton]
                    ["appearance" ==> "square-button"]
                test
                    "Appearance button"
                    [Appearance.Button]
                    ["appearance" ==> "button"]
                test
                    "Appearance button bevel"
                    [Appearance.ButtonBevel]
                    ["appearance" ==> "button-bevel"]
                test
                    "Appearance list-box"
                    [Appearance.Listbox]
                    ["appearance" ==> "listbox"]
                test
                    "Appearance list-item"
                    [Appearance.Listitem]
                    ["appearance" ==> "listitem"]
                test
                    "Appearance menulist"
                    [Appearance.Menulist]
                    ["appearance" ==> "menulist"]
                test
                    "Appearance menulist-button"
                    [Appearance.MenulistButton]
                    ["appearance" ==> "menulist-button"]
                test
                    "Appearance menulist-text"
                    [Appearance.MenulistText]
                    ["appearance" ==> "menulist-text"]
                test
                    "Appearance menulist-textfield"
                    [Appearance.MenulistTextfield]
                    ["appearance" ==> "menulist-textfield"]
                test
                    "Appearance menupopup"
                    [Appearance.Menupopup]
                    ["appearance" ==> "menupopup"]
                test
                    "Appearance scrollbarbutton-up"
                    [Appearance.ScrollbarbuttonUp]
                    ["appearance" ==> "scrollbarbutton-up"]
                test
                    "Appearance scrollbarbutton down"
                    [Appearance.ScrollbarbuttonDown]
                    ["appearance" ==> "scrollbarbutton-down"]
                test
                    "Appearance scrollbarbutton left"
                    [Appearance.ScrollbarbuttonLeft]
                    ["appearance" ==> "scrollbarbutton-left"]
                test
                    "Appearance scrollbarbutton"
                    [Appearance.ScrollbarbuttonRight]
                    ["appearance" ==> "scrollbarbutton-right"]
                test
                    "Appearance scrollbartrack-horizontal"
                    [Appearance.ScrollbartrackHorizontal]
                    ["appearance" ==> "scrollbartrack-horizontal"]
                test
                    "Appearance scrollbartrack-vertical"
                    [Appearance.ScrollbartrackVertical]
                    ["appearance" ==> "scrollbartrack-vertical"]
                test
                    "Appearance scrollbarthumb-horizontal"
                    [Appearance.ScrollbarthumbHorizontal]
                    ["appearance" ==> "scrollbarthumb-horizontal"]
                test
                    "Appearance scrollbarthumb-vertical"
                    [Appearance.ScrollbarthumbVertical]
                    ["appearance" ==> "scrollbarthumb-vertical"]
                test
                    "Appearance scrollbargripper-horizontal"
                    [Appearance.ScrollbargripperHorizontal]
                    ["appearance" ==> "scrollbargripper-horizontal"]
                test
                    "Appearance scrollbargripper-vertical"
                    [Appearance.ScrollbargripperVertical]
                    ["appearance" ==> "scrollbargripper-vertical"]
                test
                    "Appearance slider-horizontal"
                    [Appearance.SliderHorizontal]
                    ["appearance" ==> "slider-horizontal"]
                test
                    "Appearance slider-vertical"
                    [Appearance.SliderVertical]
                    ["appearance" ==> "slider-vertical"]
                test
                    "Appearance sliderthumb-horizontal"
                    [Appearance.SliderthumbHorizontal]
                    ["appearance" ==> "sliderthumb-horizontal"]
                test
                    "Appearance sliderthumb-vertical"
                    [Appearance.SliderthumbVertical]
                    ["appearance" ==> "sliderthumb-vertical"]
                test
                    "Appearance caret"
                    [Appearance.Caret]
                    ["appearance" ==> "caret"]
                test
                    "Appearance searchfield"
                    [Appearance.Searchfield]
                    ["appearance" ==> "searchfield"]
                test
                    "Appearance searchfield-decoration"
                    [Appearance.SearchfieldDecoration]
                    ["appearance" ==> "searchfield-decoration"]
                test
                    "Appearance searchfield-results-decoration"
                    [Appearance.SearchfieldResultsDecoration]
                    ["appearance" ==> "searchfield-results-decoration"]
                test
                    "Appearance searchfield-results-button"
                    [Appearance.SearchfieldResultsButton]
                    ["appearance" ==> "searchfield-results-button"]
                test
                    "Appearance searchfield-cancel-button"
                    [Appearance.SearchfieldCancelButton]
                    ["appearance" ==> "searchfield-cancel-button"]
                test
                    "Appearance textfield"
                    [Appearance.Textfield]
                    ["appearance" ==> "textfield"]
                test
                    "Appearance textarea"
                    [Appearance.Textarea]
                    ["appearance" ==> "textarea"]
                test
                    "Appearance checkbox"
                    [Appearance.Checkbox]
                    ["appearance" ==> "checkbox"]
                test
                    "Appearance checkbox-container"
                    [Appearance.CheckboxContainer]
                    ["appearance" ==> "checkbox-container"]
                test
                    "Appearance checkbox-small"
                    [Appearance.CheckboxSmall]
                    ["appearance" ==> "checkbox-small"]
                test
                    "Appearance dialog"
                    [Appearance.Dialog]
                    ["appearance" ==> "dialog"]
                test
                    "Appearance menuitem"
                    [Appearance.Menuitem]
                    ["appearance" ==> "menuitem"]
                test
                    "Appearance progressbar"
                    [Appearance.Progressbar]
                    ["appearance" ==> "progressbar"]
                test
                    "Appearance radio"
                    [Appearance.Radio]
                    ["appearance" ==> "radio"]
                test
                    "Appearance radio-container"
                    [Appearance.RadioContainer]
                    ["appearance" ==> "radio-container"]
                test
                    "Appearance radio-small"
                    [Appearance.RadioSmall]
                    ["appearance" ==> "radio-small"]
                test
                    "Appearance "
                    [Appearance.Resizer]
                    ["appearance" ==> "resizer"]
                test
                    "Appearance scrollbar"
                    [Appearance.Scrollbar]
                    ["appearance" ==> "scrollbar"]
                test
                    "Appearance separator"
                    [Appearance.Separator]
                    ["appearance" ==> "separator"]
                test
                    "Appearance statusbar"
                    [Appearance.Statusbar]
                    ["appearance" ==> "statusbar"]
                test
                    "Appearance tab"
                    [Appearance.Tab]
                    ["appearance" ==> "tab"]
                test
                    "Appearance tabpanels"
                    [Appearance.Tabpanels]
                    ["appearance" ==> "tabpanels"]
                test
                    "Appearance textfield-multiline"
                    [Appearance.TextfieldMultiline]
                    ["appearance" ==> "textfield-multiline"]
                test
                    "Appearance toolbar"
                    [Appearance.Toolbar]
                    ["appearance" ==> "toolbar"]
                test
                    "Appearance toolbarbutton"
                    [Appearance.Toolbarbutton]
                    ["appearance" ==> "toolbarbutton"]
                test
                    "Appearance toolbox"
                    [Appearance.Toolbox]
                    ["appearance" ==> "toolbox"]
                test
                    "Appearance moz-mac-unified-toolbar"
                    [Appearance.MozMacUnifiedToolbar]
                    ["appearance" ==> "moz-mac-unified-toolbar"]
                test
                    "Appearance moz-win-borderless-glass"
                    [Appearance.MozWinBorderlessGlass]
                    ["appearance" ==> "moz-win-borderless-glass"]
                test
                    "Appearance moz-win-browsertabbar-toolbox"
                    [Appearance.MozWinBrowsertabbarToolbox]
                    ["appearance" ==> "moz-win-browsertabbar-toolbox"]
                test
                    "Appearance moz-win-communications-toolbox"
                    [Appearance.MozWinCommunicationsToolbox]
                    ["appearance" ==> "moz-win-communications-toolbox"]
                test
                    "Appearance moz-win-glass"
                    [Appearance.MozWinGlass]
                    ["appearance" ==> "moz-win-glass"]
                test
                    "Appearance moz-win-media-toolbox"
                    [Appearance.MozWinMediaToolbox]
                    ["appearance" ==> "moz-win-media-toolbox"]
                test
                    "Appearance tooltip"
                    [Appearance.Tooltip]
                    ["appearance" ==> "tooltip"]
                test
                    "Appearance treeheadercell"
                    [Appearance.Treeheadercell]
                    ["appearance" ==> "treeheadercell"]
                test
                    "Appearance treeheadersortarrow"
                    [Appearance.Treeheadersortarrow]
                    ["appearance" ==> "treeheadersortarrow"]
                test
                    "Appearance treeitem"
                    [Appearance.Treeitem]
                    ["appearance" ==> "treeitem"]
                test
                    "Appearance treetwisty"
                    [Appearance.Treetwisty]
                    ["appearance" ==> "treetwisty"]
                test
                    "Appearance treetwistyopen"
                    [Appearance.Treetwistyopen]
                    ["appearance" ==> "treetwistyopen"]
                test
                    "Appearance treeview"
                    [Appearance.Treeview]
                    ["appearance" ==> "treeview"]
                test
                    "Appearance window"
                    [Appearance.Window]
                    ["appearance" ==> "window"]
                test
                    "Apperance none"
                    [Appearance.None]
                    ["appearance" ==> "none"]
                test
                    "Apperance auto"
                    [Appearance.Auto]
                    ["appearance" ==> "auto"]
            ]