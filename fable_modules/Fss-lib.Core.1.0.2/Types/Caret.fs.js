import { ColorClass_Color$reflection, ColorClass_Color } from "./Color.fs.js";
import { class_type } from "../../fable-library.3.7.9/Reflection.js";
import { Auto } from "./MasterTypes.fs.js";

export class CaretColor extends ColorClass_Color {
    constructor(property) {
        super(property);
        this.property_2 = property;
    }
}

export function CaretColor$reflection() {
    return class_type("Fss.Types.CaretClasses.CaretColor", void 0, CaretColor, ColorClass_Color$reflection());
}

export function CaretColor_$ctor_Z207A3CFB(property) {
    return new CaretColor(property);
}

export function CaretColor__get_auto(this$) {
    const tupledArg = [this$.property_2, new Auto(0)];
    return [tupledArg[0], tupledArg[1]];
}

//# sourceMappingURL=Caret.fs.js.map
