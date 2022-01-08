namespace FSSTests

open Fet
open Utils
open Fss

module AppearanceTests =
    let tests =
        testList "Appearance"
            [
                testCase
                    "Appearance push button"
                    [Appearance.pushButton]
                    "{ appearance: push-button; }"
                testCase
                    "Appearance square button"
                    [Appearance.squareButton]
                    "{ appearance: square-button; }"
                testCase
                    "Appearance button"
                    [Appearance.button]
                    "{ appearance: button; }"
                testCase
                    "Appearance button bevel"
                    [Appearance.buttonBevel]
                    "{ appearance: button-bevel; }"
                testCase
                    "Appearance list-box"
                    [Appearance.listbox]
                    "{ appearance: listbox; }"
                testCase
                    "Appearance list-item"
                    [Appearance.listitem]
                    "{ appearance: listitem; }"
                testCase
                    "Appearance menulist"
                    [Appearance.menulist]
                    "{ appearance: menulist; }"
                testCase
                    "Appearance menulist-button"
                    [Appearance.menulistButton]
                    "{ appearance: menulist-button; }"
                testCase
                    "Appearance menulist-text"
                    [Appearance.menulistText]
                    "{ appearance: menulist-text; }"
                testCase
                    "Appearance menulist-textfield"
                    [Appearance.menulistTextfield]
                    "{ appearance: menulist-textfield; }"
                testCase
                    "Appearance menupopup"
                    [Appearance.menupopup]
                    "{ appearance: menupopup; }"
                testCase
                    "Appearance scrollbarbutton-up"
                    [Appearance.scrollbarbuttonUp]
                    "{ appearance: scrollbarbutton-up; }"
                testCase
                    "Appearance scrollbarbutton down"
                    [Appearance.scrollbarbuttonDown]
                    "{ appearance: scrollbarbutton-down; }"
                testCase
                    "Appearance scrollbarbutton left"
                    [Appearance.scrollbarbuttonLeft]
                    "{ appearance: scrollbarbutton-left; }"
                testCase
                    "Appearance scrollbarbutton"
                    [Appearance.scrollbarbuttonRight]
                    "{ appearance: scrollbarbutton-right; }"
                testCase
                    "Appearance scrollbartrack-horizontal"
                    [Appearance.scrollbartrackHorizontal]
                    "{ appearance: scrollbartrack-horizontal; }"
                testCase
                    "Appearance scrollbartrack-vertical"
                    [Appearance.scrollbartrackVertical]
                    "{ appearance: scrollbartrack-vertical; }"
                testCase
                    "Appearance scrollbarthumb-horizontal"
                    [Appearance.scrollbarthumbHorizontal]
                    "{ appearance: scrollbarthumb-horizontal; }"
                testCase
                    "Appearance scrollbarthumb-vertical"
                    [Appearance.scrollbarthumbVertical]
                    "{ appearance: scrollbarthumb-vertical; }"
                testCase
                    "Appearance scrollbargripper-horizontal"
                    [Appearance.scrollbargripperHorizontal]
                    "{ appearance: scrollbargripper-horizontal; }"
                testCase
                    "Appearance scrollbargripper-vertical"
                    [Appearance.scrollbargripperVertical]
                    "{ appearance: scrollbargripper-vertical; }"
                testCase
                    "Appearance slider-horizontal"
                    [Appearance.sliderHorizontal]
                    "{ appearance: slider-horizontal; }"
                testCase
                    "Appearance slider-vertical"
                    [Appearance.sliderVertical]
                    "{ appearance: slider-vertical; }"
                testCase
                    "Appearance sliderthumb-horizontal"
                    [Appearance.sliderthumbHorizontal]
                    "{ appearance: sliderthumb-horizontal; }"
                testCase
                    "Appearance sliderthumb-vertical"
                    [Appearance.sliderthumbVertical]
                    "{ appearance: sliderthumb-vertical; }"
                testCase
                    "Appearance caret"
                    [Appearance.caret]
                    "{ appearance: caret; }"
                testCase
                    "Appearance searchfield"
                    [Appearance.searchfield]
                    "{ appearance: searchfield; }"
                testCase
                    "Appearance searchfield-decoration"
                    [Appearance.searchfieldDecoration]
                    "{ appearance: searchfield-decoration; }"
                testCase
                    "Appearance searchfield-results-decoration"
                    [Appearance.searchfieldResultsDecoration]
                    "{ appearance: searchfield-results-decoration; }"
                testCase
                    "Appearance searchfield-results-button"
                    [Appearance.searchfieldResultsButton]
                    "{ appearance: searchfield-results-button; }"
                testCase
                    "Appearance searchfield-cancel-button"
                    [Appearance.searchfieldCancelButton]
                    "{ appearance: searchfield-cancel-button; }"
                testCase
                    "Appearance textfield"
                    [Appearance.textfield]
                    "{ appearance: textfield; }"
                testCase
                    "Appearance textarea"
                    [Appearance.textarea]
                    "{ appearance: textarea; }"
                testCase
                    "Appearance checkbox"
                    [Appearance.checkbox]
                    "{ appearance: checkbox; }"
                testCase
                    "Appearance checkbox-container"
                    [Appearance.checkboxContainer]
                    "{ appearance: checkbox-container; }"
                testCase
                    "Appearance checkbox-small"
                    [Appearance.checkboxSmall]
                    "{ appearance: checkbox-small; }"
                testCase
                    "Appearance dialog"
                    [Appearance.dialog]
                    "{ appearance: dialog; }"
                testCase
                    "Appearance menuitem"
                    [Appearance.menuitem]
                    "{ appearance: menuitem; }"
                testCase
                    "Appearance progressbar"
                    [Appearance.progressbar]
                    "{ appearance: progressbar; }"
                testCase
                    "Appearance radio"
                    [Appearance.radio]
                    "{ appearance: radio; }"
                testCase
                    "Appearance radio-container"
                    [Appearance.radioContainer]
                    "{ appearance: radio-container; }"
                testCase
                    "Appearance radio-small"
                    [Appearance.radioSmall]
                    "{ appearance: radio-small; }"
                testCase
                    "Appearance "
                    [Appearance.resizer]
                    "{ appearance: resizer; }"
                testCase
                    "Appearance scrollbar"
                    [Appearance.scrollbar]
                    "{ appearance: scrollbar; }"
                testCase
                    "Appearance separator"
                    [Appearance.separator]
                    "{ appearance: separator; }"
                testCase
                    "Appearance statusbar"
                    [Appearance.statusbar]
                    "{ appearance: statusbar; }"
                testCase
                    "Appearance tab"
                    [Appearance.tab]
                    "{ appearance: tab; }"
                testCase
                    "Appearance tabpanels"
                    [Appearance.tabpanels]
                    "{ appearance: tabpanels; }"
                testCase
                    "Appearance textfield-multiline"
                    [Appearance.textfieldMultiline]
                    "{ appearance: textfield-multiline; }"
                testCase
                    "Appearance toolbar"
                    [Appearance.toolbar]
                    "{ appearance: toolbar; }"
                testCase
                    "Appearance toolbarbutton"
                    [Appearance.toolbarbutton]
                    "{ appearance: toolbarbutton; }"
                testCase
                    "Appearance toolbox"
                    [Appearance.toolbox]
                    "{ appearance: toolbox; }"
                testCase
                    "Appearance moz-mac-unified-toolbar"
                    [Appearance.mozMacUnifiedToolbar]
                    "{ appearance: moz-mac-unified-toolbar; }"
                testCase
                    "Appearance moz-win-borderless-glass"
                    [Appearance.mozWinBorderlessGlass]
                    "{ appearance: moz-win-borderless-glass; }"
                testCase
                    "Appearance moz-win-browsertabbar-toolbox"
                    [Appearance.mozWinBrowsertabbarToolbox]
                    "{ appearance: moz-win-browsertabbar-toolbox; }"
                testCase
                    "Appearance moz-win-communications-toolbox"
                    [Appearance.mozWinCommunicationsToolbox]
                    "{ appearance: moz-win-communications-toolbox; }"
                testCase
                    "Appearance moz-win-glass"
                    [Appearance.mozWinGlass]
                    "{ appearance: moz-win-glass; }"
                testCase
                    "Appearance moz-win-media-toolbox"
                    [Appearance.mozWinMediaToolbox]
                    "{ appearance: moz-win-media-toolbox; }"
                testCase
                    "Appearance tooltip"
                    [Appearance.tooltip]
                    "{ appearance: tooltip; }"
                testCase
                    "Appearance treeheadercell"
                    [Appearance.treeheadercell]
                    "{ appearance: treeheadercell; }"
                testCase
                    "Appearance treeheadersortarrow"
                    [Appearance.treeheadersortarrow]
                    "{ appearance: treeheadersortarrow; }"
                testCase
                    "Appearance treeitem"
                    [Appearance.treeitem]
                    "{ appearance: treeitem; }"
                testCase
                    "Appearance treetwisty"
                    [Appearance.treetwisty]
                    "{ appearance: treetwisty; }"
                testCase
                    "Appearance treetwistyopen"
                    [Appearance.treetwistyopen]
                    "{ appearance: treetwistyopen; }"
                testCase
                    "Appearance treeview"
                    [Appearance.treeview]
                    "{ appearance: treeview; }"
                testCase
                    "Appearance window"
                    [Appearance.window]
                    "{ appearance: window; }"
                testCase
                    "Apperance none"
                    [Appearance.none]
                    "{ appearance: none; }"
                testCase
                    "Apperance auto"
                    [Appearance.auto]
                    "{ appearance: auto; }"
                testCase
                    "Apperance inherit"
                    [Appearance.inherit']
                    "{ appearance: inherit; }"
                testCase
                    "Apperance initial"
                    [Appearance.initial]
                    "{ appearance: initial; }"
                testCase
                    "Apperance unset"
                    [Appearance.unset]
                    "{ appearance: unset; }"
                testCase
                    "Apperance revert"
                    [Appearance.revert]
                    "{ appearance: revert; }"
            ]