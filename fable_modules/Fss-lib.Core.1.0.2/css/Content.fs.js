import { ContentClasses_Content_$ctor_Z207A3CFB } from "../Types/Content.fs.js";
import { NameLabel, Property_CssProperty } from "../Types/MasterTypes.fs.js";
import { replace } from "../../fable-library.3.7.9/String.js";

export const ContentCss_Content = ContentClasses_Content_$ctor_Z207A3CFB(new Property_CssProperty(84));

export function Label_Label(label) {
    const tupledArg = [new Property_CssProperty(391), new NameLabel(0, replace(label, " ", ""))];
    return [tupledArg[0], tupledArg[1]];
}

//# sourceMappingURL=Content.fs.js.map
