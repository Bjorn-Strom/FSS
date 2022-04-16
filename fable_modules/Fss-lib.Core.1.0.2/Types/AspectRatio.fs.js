import { DividerMaster, Int, CssRule$reflection, CssRule } from "./MasterTypes.fs.js";
import { class_type } from "../../fable-library.3.7.9/Reflection.js";
import { int32ToString } from "../../fable-library.3.7.9/Util.js";

export class AspectRatio extends CssRule {
    constructor(property) {
        super(property);
        this.property_1 = property;
    }
}

export function AspectRatio$reflection() {
    return class_type("Fss.Types.AspectRatioClasses.AspectRatio", void 0, AspectRatio, CssRule$reflection());
}

export function AspectRatio_$ctor_Z207A3CFB(property) {
    return new AspectRatio(property);
}

export function AspectRatio__value_Z524259A4(this$, aspectRatio) {
    const tupledArg = [this$.property_1, new Int(0, aspectRatio)];
    return [tupledArg[0], tupledArg[1]];
}

export function AspectRatio__value_Z37302880(this$, width, height) {
    const tupledArg = [this$.property_1, new DividerMaster(0, int32ToString(width), int32ToString(height))];
    return [tupledArg[0], tupledArg[1]];
}

//# sourceMappingURL=AspectRatio.fs.js.map
