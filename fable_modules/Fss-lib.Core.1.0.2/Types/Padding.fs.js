import { unitHelpers_DirectionalLength$reflection, unitHelpers_DirectionalLength, unitHelpers_CssRuleWithAutoLength$reflection, unitHelpers_CssRuleWithAutoLength } from "./Units.fs.js";
import { class_type } from "../../fable-library.3.7.9/Reflection.js";
import { Auto } from "./MasterTypes.fs.js";

export class PaddingDirection extends unitHelpers_CssRuleWithAutoLength {
    constructor(property) {
        super(property);
    }
}

export function PaddingDirection$reflection() {
    return class_type("Fss.Types.PaddingClasses.PaddingDirection", void 0, PaddingDirection, unitHelpers_CssRuleWithAutoLength$reflection());
}

export function PaddingDirection_$ctor_Z207A3CFB(property) {
    return new PaddingDirection(property);
}

export class Padding extends unitHelpers_DirectionalLength {
    constructor(property) {
        super(property);
        this.property_2 = property;
    }
}

export function Padding$reflection() {
    return class_type("Fss.Types.PaddingClasses.Padding", void 0, Padding, unitHelpers_DirectionalLength$reflection());
}

export function Padding_$ctor_Z207A3CFB(property) {
    return new Padding(property);
}

export function Padding__get_auto(this$) {
    const tupledArg = [this$.property_2, new Auto(0)];
    return [tupledArg[0], tupledArg[1]];
}

//# sourceMappingURL=Padding.fs.js.map
