import { createElement } from "react";
import { Page } from "./Page.js";
import { Page as Page_1 } from "../Pages.js";
import { empty } from "../fable_modules/fable-library.3.7.9/List.js";

export function Philosophy() {
    return createElement(Page, {
        page: new Page_1(2),
        styles: empty(),
    });
}

export default (() => createElement(Philosophy, null));

//# sourceMappingURL=Philosophy.js.map
