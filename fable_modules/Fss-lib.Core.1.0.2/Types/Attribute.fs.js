import { Helpers_toKebabCase } from "../Utilities.fs.js";
import { Union } from "../../fable-library.3.7.9/Types.js";
import { union_type } from "../../fable-library.3.7.9/Reflection.js";

export class Attribute extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["Property", "Attribute", "Map", "Style", "Class", "ClassList", "Id", "Title", "Hidden", "Type", "Value", "Checked", "Placeholder", "Selected", "Accept", "AcceptCharset", "Action", "Autocomplete", "Autofocus", "Disabled", "Enctype", "List", "Maxlength", "Minlength", "Method", "Multiple", "Name", "Novalidate", "Pattern", "Readonly", "Required", "Size", "For", "Form", "Max", "Min", "Step", "Cols", "Rows", "Wrap", "Href", "Target", "Download", "Hreflang", "Media", "Ping", "Rel", "Ismap", "Usemap", "Shape", "Coords", "Src", "Height", "Width", "Alt", "Autoplay", "Controls", "Loop", "Preload", "Poster", "Default", "Kind", "Srclang", "Sandbox", "Srcdoc", "Reversed", "Start", "Align", "Colspan", "Rowspan", "Headers", "Scope", "Accesskey", "Contenteditable", "Contextmenu", "Dir", "Draggable", "Dropzone", "Itemprop", "Lang", "Spellcheck", "Tabindex", "Cite", "Datetime", "Pubdate", "Manifest"];
    }
    StringifyCss() {
        const this$ = this;
        return Helpers_toKebabCase(this$);
    }
}

export function Attribute$reflection() {
    return union_type("Fss.Types.Attribute.Attribute", [], Attribute, () => [[], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], []]);
}

//# sourceMappingURL=Attribute.fs.js.map
