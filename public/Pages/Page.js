import { useFeliz_React__React_useState_Static_1505 } from "../fable_modules/Feliz.1.57.0/React.fs.js";
import { useuseFetchStore } from "../Store.js";
import { createElement } from "react";
import { markdownAndExamples } from "../Markdown.js";

export function Page(pageInputProps) {
    const styles = pageInputProps.styles;
    const page = pageInputProps.page;
    const patternInput = useFeliz_React__React_useState_Static_1505(void 0);
    const state = patternInput[0];
    const setState = patternInput[1];
    useuseFetchStore(page, setState);
    if (state == null) {
        return createElement("p", {
            children: ["Fetching..."],
        });
    }
    else {
        const documentation = state[1];
        return markdownAndExamples(documentation, styles);
    }
}

//# sourceMappingURL=Page.js.map
