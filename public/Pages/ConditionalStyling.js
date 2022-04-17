import { Union } from "../fable_modules/fable-library.3.7.9/Types.js";
import { union_type } from "../fable_modules/fable-library.3.7.9/Reflection.js";
import { fss } from "../fable_modules/Fss-lib.Fable.1.0.1/FssFable.fs.js";
import { singleton, append, delay, toList } from "../fable_modules/fable-library.3.7.9/Seq.js";
import { unitHelpers_CssRuleWithAutoLength__value_Z498FEB3B } from "../fable_modules/Fss-lib.Core.1.0.2/Types/Units.fs.js";
import { px } from "../fable_modules/Fss-lib.Core.1.0.2/Functions.fs.js";
import { Width, Height } from "../fable_modules/Fss-lib.Core.1.0.2/css/ContentSize.fs.js";
import { createElement } from "react";
import { createObj } from "../fable_modules/fable-library.3.7.9/Util.js";
import { Interop_reactApi } from "../fable_modules/Feliz.1.57.0/Interop.fs.js";
import { singleton as singleton_1 } from "../fable_modules/fable-library.3.7.9/List.js";
import { Page } from "./Page.js";
import { Page as Page_1 } from "../Pages.js";

export class ButtonSize extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["Small", "Big"];
    }
}

export function ButtonSize$reflection() {
    return union_type("Page.ConditionalStyling.ButtonSize", [], ButtonSize, () => [[], []]);
}

export function ConditionalStyling() {
    let elems;
    const buttonStyle = (buttonType) => fss(toList(delay(() => ((buttonType.tag === 0) ? append(singleton(unitHelpers_CssRuleWithAutoLength__value_Z498FEB3B(Height, px(40))), delay(() => singleton(unitHelpers_CssRuleWithAutoLength__value_Z498FEB3B(Width, px(40))))) : append(singleton(unitHelpers_CssRuleWithAutoLength__value_Z498FEB3B(Height, px(80))), delay(() => singleton(unitHelpers_CssRuleWithAutoLength__value_Z498FEB3B(Width, px(80)))))))));
    const styles = singleton_1(createElement("div", createObj(singleton_1((elems = [createElement("button", {
        className: buttonStyle(new ButtonSize(0)),
        children: "Small",
    }), createElement("button", {
        className: buttonStyle(new ButtonSize(1)),
        children: "Big",
    })], ["children", Interop_reactApi.Children.toArray(Array.from(elems))])))));
    return createElement(Page, {
        page: new Page_1(4),
        styles: styles,
    });
}

export default (() => createElement(ConditionalStyling, null));

//# sourceMappingURL=ConditionalStyling.js.map
