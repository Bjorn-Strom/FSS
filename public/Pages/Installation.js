import { createElement } from "react";
import { Page } from "./Page.js";
import { Page as Page_1 } from "../Pages.js";
import { empty } from "../fable_modules/fable-library.3.7.9/List.js";

export function Installation() {
    return createElement(Page, {
        page: new Page_1(1),
        styles: empty(),
    });
}

export default (() => createElement(Installation, null));

//# sourceMappingURL=Installation.js.map
