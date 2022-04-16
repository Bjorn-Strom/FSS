import { Union, toString } from "../../fable-library.3.7.9/Types.js";
import { class_type, union_type } from "../../fable-library.3.7.9/Reflection.js";
import { CssRuleWithAutoNone$reflection, CssRuleWithAutoNone } from "./MasterTypes.fs.js";

export class PointerEvents_PointerEvents extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["VisiblePainted", "VisibleFill", "VisibleStroke", "Visible", "Painted", "Stroke", "All"];
    }
    StringifyCss() {
        const this$ = this;
        return toString(this$).toLocaleLowerCase();
    }
}

export function PointerEvents_PointerEvents$reflection() {
    return union_type("Fss.Types.PointerEvents.PointerEvents", [], PointerEvents_PointerEvents, () => [[], [], [], [], [], [], []]);
}

export class PointerEventClasses_PointerEvent extends CssRuleWithAutoNone {
    constructor(property) {
        super(property);
        this.property_2 = property;
    }
}

export function PointerEventClasses_PointerEvent$reflection() {
    return class_type("Fss.Types.PointerEventClasses.PointerEvent", void 0, PointerEventClasses_PointerEvent, CssRuleWithAutoNone$reflection());
}

export function PointerEventClasses_PointerEvent_$ctor_Z207A3CFB(property) {
    return new PointerEventClasses_PointerEvent(property);
}

export function PointerEventClasses_PointerEvent__get_visiblePainted(this$) {
    const tupledArg = [this$.property_2, new PointerEvents_PointerEvents(0)];
    return [tupledArg[0], tupledArg[1]];
}

export function PointerEventClasses_PointerEvent__get_visibleFill(this$) {
    const tupledArg = [this$.property_2, new PointerEvents_PointerEvents(1)];
    return [tupledArg[0], tupledArg[1]];
}

export function PointerEventClasses_PointerEvent__get_visibleStroke(this$) {
    const tupledArg = [this$.property_2, new PointerEvents_PointerEvents(2)];
    return [tupledArg[0], tupledArg[1]];
}

export function PointerEventClasses_PointerEvent__get_visible(this$) {
    const tupledArg = [this$.property_2, new PointerEvents_PointerEvents(3)];
    return [tupledArg[0], tupledArg[1]];
}

export function PointerEventClasses_PointerEvent__get_painted(this$) {
    const tupledArg = [this$.property_2, new PointerEvents_PointerEvents(4)];
    return [tupledArg[0], tupledArg[1]];
}

export function PointerEventClasses_PointerEvent__get_stroke(this$) {
    const tupledArg = [this$.property_2, new PointerEvents_PointerEvents(5)];
    return [tupledArg[0], tupledArg[1]];
}

export function PointerEventClasses_PointerEvent__get_all(this$) {
    const tupledArg = [this$.property_2, new PointerEvents_PointerEvents(6)];
    return [tupledArg[0], tupledArg[1]];
}

//# sourceMappingURL=PointerEvents.fs.js.map
