import { fss } from "../fable_modules/Fss-lib.Fable.1.0.1/FssFable.fs.js";
import { Custom } from "../fable_modules/Fss-lib.Core.1.0.2/css/Custom.fs.js";
import { singleton } from "../fable_modules/fable-library.3.7.9/List.js";
import { createElement } from "react";
import { Page } from "./Page.js";
import { Page as Page_1 } from "../Pages.js";

export function BasicUsage() {
    const borderStyle = fss(singleton(Custom("border", "4mm ridge rgba(170, 50, 220, .6)")));
    const styles = singleton(createElement("div", {
        className: borderStyle,
        children: "Border style made with custom escape hatch",
    }));
    return createElement(Page, {
        page: new Page_1(3),
        styles: styles,
    });
}

export default (() => createElement(BasicUsage, null));

//# sourceMappingURL=BasicUsage.js.map
