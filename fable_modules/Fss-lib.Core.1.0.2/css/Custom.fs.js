import { CustomMaster, Property_CssProperty } from "../Types/MasterTypes.fs.js";

export function Custom(key, value) {
    const tupledArg = [new Property_CssProperty(396, key), new CustomMaster(0, value)];
    return [tupledArg[0], tupledArg[1]];
}

//# sourceMappingURL=Custom.fs.js.map
