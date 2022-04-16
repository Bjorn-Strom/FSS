import { Union } from "../../fable-library.3.7.9/Types.js";
import { union_type } from "../../fable-library.3.7.9/Reflection.js";

export class Html extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["A", "All", "Abbr", "Acronym", "Address", "Applet", "Area", "Article", "Aside", "Audio", "B", "Base", "Basefont", "Bdo", "Big", "Blockquote", "Body", "Br", "Button", "Canvas", "Caption", "Center", "Cite", "Code", "Col", "Colgroup", "Datalist", "Dd", "Del", "Dfn", "Div", "Dl", "Dt", "Em", "Embed", "Fieldset", "Figcaption", "Figure", "Font", "Footer", "Form", "Frame", "Frameset", "Head", "Header", "H1", "H2", "H3", "H4", "H5", "H6", "Hr", "Html", "I", "Iframe", "Img", "Input", "Ins", "Kbd", "Label", "Legend", "Li", "Link", "Main", "Map", "Mark", "Meta", "Meter", "Nav", "Noscript", "Object", "Ol", "Optgroup", "Option", "P", "Param", "Pre", "Progress", "Q", "S", "Samp", "Script", "Section", "Select", "Small", "Source", "Span", "Strike", "Strong", "Style", "Sub", "Sup", "Table", "Tbody", "Td", "Textarea", "Tfoot", "Th", "Thead", "Time", "Title", "Tr", "U", "Ul", "Var", "Video", "Wbr"];
    }
}

export function Html$reflection() {
    return union_type("Fss.Types.Html.Html", [], Html, () => [[], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], []]);
}

//# sourceMappingURL=Html.fs.js.map
