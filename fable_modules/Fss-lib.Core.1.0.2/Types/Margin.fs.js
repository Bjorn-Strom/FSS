import { unitHelpers_DirectionalLength$reflection, unitHelpers_DirectionalLength, unitHelpers_CssRuleWithAutoLength$reflection, unitHelpers_CssRuleWithAutoLength } from "./Units.fs.js";
import { class_type } from "../../fable-library.3.7.9/Reflection.js";
import { Auto } from "./MasterTypes.fs.js";

export class MarginDirection extends unitHelpers_CssRuleWithAutoLength {
    constructor(property) {
        super(property);
    }
}

export function MarginDirection$reflection() {
    return class_type("Fss.Types.MarginClasses.MarginDirection", void 0, MarginDirection, unitHelpers_CssRuleWithAutoLength$reflection());
}

export function MarginDirection_$ctor_Z207A3CFB(property) {
    return new MarginDirection(property);
}

export class Margin extends unitHelpers_DirectionalLength {
    constructor(property) {
        super(property);
        this.property_2 = property;
    }
}

export function Margin$reflection() {
    return class_type("Fss.Types.MarginClasses.Margin", void 0, Margin, unitHelpers_DirectionalLength$reflection());
}

export function Margin_$ctor_Z207A3CFB(property) {
    return new Margin(property);
}

export function Margin__get_auto(this$) {
    const tupledArg = [this$.property_2, new Auto(0)];
    return [tupledArg[0], tupledArg[1]];
}

//# sourceMappingURL=Margin.fs.js.map
