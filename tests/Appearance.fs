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
                    [Appearance.pushButton]
                    ["appearance" ==> "push-button"]
                test
                    "Appearance square button"
                    [Appearance.squareButton]
                    ["appearance" ==> "square-button"]
                test
                    "Appearance button"
                    [Appearance.button]
                    ["appearance" ==> "button"]
                test
                    "Appearance button bevel"
                    [Appearance.buttonBevel]
                    ["appearance" ==> "button-bevel"]
                test
                    "Appearance list-box"
                    [Appearance.listbox]
                    ["appearance" ==> "listbox"]
                test
                    "Appearance list-item"
                    [Appearance.listitem]
                    ["appearance" ==> "listitem"]
                test
                    "Appearance menulist"
                    [Appearance.menulist]
                    ["appearance" ==> "menulist"]
                test
                    "Appearance menulist-button"
                    [Appearance.menulistButton]
                    ["appearance" ==> "menulist-button"]
                test
                    "Appearance menulist-text"
                    [Appearance.menulistText]
                    ["appearance" ==> "menulist-text"]
                test
                    "Appearance menulist-textfield"
                    [Appearance.menulistTextfield]
                    ["appearance" ==> "menulist-textfield"]
                test
                    "Appearance menupopup"
                    [Appearance.menupopup]
                    ["appearance" ==> "menupopup"]
                test
                    "Appearance scrollbarbutton-up"
                    [Appearance.scrollbarbuttonUp]
                    ["appearance" ==> "scrollbarbutton-up"]
                test
                    "Appearance scrollbarbutton down"
                    [Appearance.scrollbarbuttonDown]
                    ["appearance" ==> "scrollbarbutton-down"]
                test
                    "Appearance scrollbarbutton left"
                    [Appearance.scrollbarbuttonLeft]
                    ["appearance" ==> "scrollbarbutton-left"]
                test
                    "Appearance scrollbarbutton"
                    [Appearance.scrollbarbuttonRight]
                    ["appearance" ==> "scrollbarbutton-right"]
                test
                    "Appearance scrollbartrack-horizontal"
                    [Appearance.scrollbartrackHorizontal]
                    ["appearance" ==> "scrollbartrack-horizontal"]
                test
                    "Appearance scrollbartrack-vertical"
                    [Appearance.scrollbartrackVertical]
                    ["appearance" ==> "scrollbartrack-vertical"]
                test
                    "Appearance scrollbarthumb-horizontal"
                    [Appearance.scrollbarthumbHorizontal]
                    ["appearance" ==> "scrollbarthumb-horizontal"]
                test
                    "Appearance scrollbarthumb-vertical"
                    [Appearance.scrollbarthumbVertical]
                    ["appearance" ==> "scrollbarthumb-vertical"]
                test
                    "Appearance scrollbargripper-horizontal"
                    [Appearance.scrollbargripperHorizontal]
                    ["appearance" ==> "scrollbargripper-horizontal"]
                test
                    "Appearance scrollbargripper-vertical"
                    [Appearance.scrollbargripperVertical]
                    ["appearance" ==> "scrollbargripper-vertical"]
                test
                    "Appearance slider-horizontal"
                    [Appearance.sliderHorizontal]
                    ["appearance" ==> "slider-horizontal"]
                test
                    "Appearance slider-vertical"
                    [Appearance.sliderVertical]
                    ["appearance" ==> "slider-vertical"]
                test
                    "Appearance sliderthumb-horizontal"
                    [Appearance.sliderthumbHorizontal]
                    ["appearance" ==> "sliderthumb-horizontal"]
                test
                    "Appearance sliderthumb-vertical"
                    [Appearance.sliderthumbVertical]
                    ["appearance" ==> "sliderthumb-vertical"]
                test
                    "Appearance caret"
                    [Appearance.caret]
                    ["appearance" ==> "caret"]
                test
                    "Appearance searchfield"
                    [Appearance.searchfield]
                    ["appearance" ==> "searchfield"]
                test
                    "Appearance searchfield-decoration"
                    [Appearance.searchfieldDecoration]
                    ["appearance" ==> "searchfield-decoration"]
                test
                    "Appearance searchfield-results-decoration"
                    [Appearance.searchfieldResultsDecoration]
                    ["appearance" ==> "searchfield-results-decoration"]
                test
                    "Appearance searchfield-results-button"
                    [Appearance.searchfieldResultsButton]
                    ["appearance" ==> "searchfield-results-button"]
                test
                    "Appearance searchfield-cancel-button"
                    [Appearance.searchfieldCancelButton]
                    ["appearance" ==> "searchfield-cancel-button"]
                test
                    "Appearance textfield"
                    [Appearance.textfield]
                    ["appearance" ==> "textfield"]
                test
                    "Appearance textarea"
                    [Appearance.textarea]
                    ["appearance" ==> "textarea"]
                test
                    "Appearance checkbox"
                    [Appearance.checkbox]
                    ["appearance" ==> "checkbox"]
                test
                    "Appearance checkbox-container"
                    [Appearance.checkboxContainer]
                    ["appearance" ==> "checkbox-container"]
                test
                    "Appearance checkbox-small"
                    [Appearance.checkboxSmall]
                    ["appearance" ==> "checkbox-small"]
                test
                    "Appearance dialog"
                    [Appearance.dialog]
                    ["appearance" ==> "dialog"]
                test
                    "Appearance menuitem"
                    [Appearance.menuitem]
                    ["appearance" ==> "menuitem"]
                test
                    "Appearance progressbar"
                    [Appearance.progressbar]
                    ["appearance" ==> "progressbar"]
                test
                    "Appearance radio"
                    [Appearance.radio]
                    ["appearance" ==> "radio"]
                test
                    "Appearance radio-container"
                    [Appearance.radioContainer]
                    ["appearance" ==> "radio-container"]
                test
                    "Appearance radio-small"
                    [Appearance.radioSmall]
                    ["appearance" ==> "radio-small"]
                test
                    "Appearance "
                    [Appearance.resizer]
                    ["appearance" ==> "resizer"]
                test
                    "Appearance scrollbar"
                    [Appearance.scrollbar]
                    ["appearance" ==> "scrollbar"]
                test
                    "Appearance separator"
                    [Appearance.separator]
                    ["appearance" ==> "separator"]
                test
                    "Appearance statusbar"
                    [Appearance.statusbar]
                    ["appearance" ==> "statusbar"]
                test
                    "Appearance tab"
                    [Appearance.tab]
                    ["appearance" ==> "tab"]
                test
                    "Appearance tabpanels"
                    [Appearance.tabpanels]
                    ["appearance" ==> "tabpanels"]
                test
                    "Appearance textfield-multiline"
                    [Appearance.textfieldMultiline]
                    ["appearance" ==> "textfield-multiline"]
                test
                    "Appearance toolbar"
                    [Appearance.toolbar]
                    ["appearance" ==> "toolbar"]
                test
                    "Appearance toolbarbutton"
                    [Appearance.toolbarbutton]
                    ["appearance" ==> "toolbarbutton"]
                test
                    "Appearance toolbox"
                    [Appearance.toolbox]
                    ["appearance" ==> "toolbox"]
                test
                    "Appearance moz-mac-unified-toolbar"
                    [Appearance.mozMacUnifiedToolbar]
                    ["appearance" ==> "moz-mac-unified-toolbar"]
                test
                    "Appearance moz-win-borderless-glass"
                    [Appearance.mozWinBorderlessGlass]
                    ["appearance" ==> "moz-win-borderless-glass"]
                test
                    "Appearance moz-win-browsertabbar-toolbox"
                    [Appearance.mozWinBrowsertabbarToolbox]
                    ["appearance" ==> "moz-win-browsertabbar-toolbox"]
                test
                    "Appearance moz-win-communications-toolbox"
                    [Appearance.mozWinCommunicationsToolbox]
                    ["appearance" ==> "moz-win-communications-toolbox"]
                test
                    "Appearance moz-win-glass"
                    [Appearance.mozWinGlass]
                    ["appearance" ==> "moz-win-glass"]
                test
                    "Appearance moz-win-media-toolbox"
                    [Appearance.mozWinMediaToolbox]
                    ["appearance" ==> "moz-win-media-toolbox"]
                test
                    "Appearance tooltip"
                    [Appearance.tooltip]
                    ["appearance" ==> "tooltip"]
                test
                    "Appearance treeheadercell"
                    [Appearance.treeheadercell]
                    ["appearance" ==> "treeheadercell"]
                test
                    "Appearance treeheadersortarrow"
                    [Appearance.treeheadersortarrow]
                    ["appearance" ==> "treeheadersortarrow"]
                test
                    "Appearance treeitem"
                    [Appearance.treeitem]
                    ["appearance" ==> "treeitem"]
                test
                    "Appearance treetwisty"
                    [Appearance.treetwisty]
                    ["appearance" ==> "treetwisty"]
                test
                    "Appearance treetwistyopen"
                    [Appearance.treetwistyopen]
                    ["appearance" ==> "treetwistyopen"]
                test
                    "Appearance treeview"
                    [Appearance.treeview]
                    ["appearance" ==> "treeview"]
                test
                    "Appearance window"
                    [Appearance.window]
                    ["appearance" ==> "window"]
                test
                    "Apperance none"
                    [Appearance.none]
                    ["appearance" ==> "none"]
                test
                    "Apperance auto"
                    [Appearance.auto]
                    ["appearance" ==> "auto"]
            ]