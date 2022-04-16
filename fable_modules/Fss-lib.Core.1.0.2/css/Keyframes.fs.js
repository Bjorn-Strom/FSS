import { Union } from "../../fable-library.3.7.9/Types.js";
import { union_type, list_type, tuple_type, class_type, int32_type } from "../../fable-library.3.7.9/Reflection.js";
import { Property_CssProperty$reflection } from "../Types/MasterTypes.fs.js";

export class Keyframes extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["Frame", "Frames"];
    }
}

export function Keyframes$reflection() {
    return union_type("Fss.Keyframes.Keyframes", [], Keyframes, () => [[["Item1", int32_type], ["Item2", list_type(tuple_type(Property_CssProperty$reflection(), class_type("Fss.Types.ICssValue")))]], [["Item1", list_type(int32_type)], ["Item2", list_type(tuple_type(Property_CssProperty$reflection(), class_type("Fss.Types.ICssValue")))]]]);
}

export function frame(f, properties) {
    const tupledArg = [f, properties];
    return new Keyframes(0, tupledArg[0], tupledArg[1]);
}

export function frames(f, properties) {
    const tupledArg = [f, properties];
    return new Keyframes(1, tupledArg[0], tupledArg[1]);
}

//# sourceMappingURL=Keyframes.fs.js.map
