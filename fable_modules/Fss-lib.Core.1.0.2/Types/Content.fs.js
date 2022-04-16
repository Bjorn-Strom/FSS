import { Helpers_toKebabCase } from "../Utilities.fs.js";
import { Union } from "../../fable-library.3.7.9/Types.js";
import { Normal, MasterTypeHelpers_stringifyICssValue, String$, Stringed, Property_CounterProperty$reflection } from "./MasterTypes.fs.js";
import { class_type, union_type } from "../../fable-library.3.7.9/Reflection.js";
import { ImageClasses_ImageClass$reflection, ImageClasses_ImageClass } from "./Image.fs.js";
import { zip, map } from "../../fable-library.3.7.9/List.js";
import { join } from "../../fable-library.3.7.9/String.js";

export class Content_Content extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["OpenQuote", "CloseQuote", "NoOpenQuote", "NoCloseQuote", "Counter"];
    }
    StringifyCss() {
        const this$ = this;
        return Helpers_toKebabCase(this$);
    }
}

export function Content_Content$reflection() {
    return union_type("Fss.Types.Content.Content", [], Content_Content, () => [[], [], [], [], [["Item", Property_CounterProperty$reflection()]]]);
}

export class ContentClasses_Content extends ImageClasses_ImageClass {
    constructor(property) {
        super(property);
        this.property_3 = property;
    }
}

export function ContentClasses_Content$reflection() {
    return class_type("Fss.Types.ContentClasses.Content", void 0, ContentClasses_Content, ImageClasses_ImageClass$reflection());
}

export function ContentClasses_Content_$ctor_Z207A3CFB(property) {
    return new ContentClasses_Content(property);
}

export function ContentClasses_Content__value_Z721C83C5(this$, value) {
    const tupledArg = [this$.property_3, new Stringed(0, value)];
    return [tupledArg[0], tupledArg[1]];
}

export function ContentClasses_Content__counter_Z721C83C5(this$, counter) {
    const counter_1 = `counter(${counter})`;
    const tupledArg = [this$.property_3, new String$(0, counter_1)];
    return [tupledArg[0], tupledArg[1]];
}

export function ContentClasses_Content__counter_Z384F8060(this$, counter, separator) {
    const counter_1 = `counter(${counter})"${separator}"`;
    const tupledArg = [this$.property_3, new String$(0, counter_1)];
    return [tupledArg[0], tupledArg[1]];
}

export function ContentClasses_Content__counter_6AFA63E0(this$, counters, separators) {
    const separators_1 = map((s) => (`"${s}"`), separators);
    const counters_1 = join("", map((tupledArg) => {
        const c = tupledArg[0];
        const s_1 = tupledArg[1];
        return `counter(${c})${s_1}`;
    }, zip(counters, separators_1)));
    const tupledArg_1 = [this$.property_3, new String$(0, counters_1)];
    return [tupledArg_1[0], tupledArg_1[1]];
}

export function ContentClasses_Content__attribute_Z2EEF341A(this$, attribute) {
    const attribute_1 = `attr(${MasterTypeHelpers_stringifyICssValue(attribute)})`;
    const tupledArg = [this$.property_3, new String$(0, attribute_1)];
    return [tupledArg[0], tupledArg[1]];
}

export function ContentClasses_Content__get_normal(this$) {
    const tupledArg = [this$.property_3, new Normal(0)];
    return [tupledArg[0], tupledArg[1]];
}

export function ContentClasses_Content__get_openQuote(this$) {
    const tupledArg = [this$.property_3, new Content_Content(0)];
    return [tupledArg[0], tupledArg[1]];
}

export function ContentClasses_Content__get_closeQuote(this$) {
    const tupledArg = [this$.property_3, new Content_Content(1)];
    return [tupledArg[0], tupledArg[1]];
}

export function ContentClasses_Content__get_noOpenQuote(this$) {
    const tupledArg = [this$.property_3, new Content_Content(2)];
    return [tupledArg[0], tupledArg[1]];
}

export function ContentClasses_Content__get_noCloseQuote(this$) {
    const tupledArg = [this$.property_3, new Content_Content(3)];
    return [tupledArg[0], tupledArg[1]];
}

//# sourceMappingURL=Content.fs.js.map
