import { Int, CssRule$reflection, CssRule } from "./MasterTypes.fs.js";
import { class_type } from "../../fable-library.3.7.9/Reflection.js";

export class Typography extends CssRule {
    constructor(property) {
        super(property);
        this.property_1 = property;
    }
}

export function Typography$reflection() {
    return class_type("Fss.Types.TypographyClasses.Typography", void 0, Typography, CssRule$reflection());
}

export function Typography_$ctor_Z207A3CFB(property) {
    return new Typography(property);
}

export function Typography__value_Z524259A4(this$, value) {
    const tupledArg = [this$.property_1, new Int(0, value)];
    return [tupledArg[0], tupledArg[1]];
}

//# sourceMappingURL=Typography.fs.js.map
