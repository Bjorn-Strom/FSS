import { createElement } from "react";
import { Page } from "./Page.js";
import { Page as Page_1 } from "../Pages.js";
import { empty } from "../fable_modules/fable-library.3.7.9/List.js";

export function GlobalStyles() {
    return createElement(Page, {
        page: new Page_1(12),
        styles: empty(),
    });
}

export default (() => createElement(GlobalStyles, null));

//# sourceMappingURL=GlobalStyles.js.map
