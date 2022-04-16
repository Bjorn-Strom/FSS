import { toString, Union } from "../../fable-library.3.7.9/Types.js";
import { class_type, union_type } from "../../fable-library.3.7.9/Reflection.js";
import { CssRuleWithNormal$reflection, CssRuleWithNormal, CssRuleWithNone$reflection, CssRuleWithNone, CssRuleWithAutoNone$reflection, CssRuleWithAutoNone, Auto, CssRuleWithAuto$reflection, CssRuleWithAuto, MasterTypeHelpers_stringifyICssValue } from "./MasterTypes.fs.js";
import { unitHelpers_CssRuleWithLength$reflection, unitHelpers_CssRuleWithLength, unitHelpers_DirectionalLength$reflection, unitHelpers_DirectionalLength } from "./Units.fs.js";

export class Scroll_ScrollBehavior extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["Smooth"];
    }
    StringifyCss() {
        return "smooth";
    }
}

export function Scroll_ScrollBehavior$reflection() {
    return union_type("Fss.Types.Scroll.ScrollBehavior", [], Scroll_ScrollBehavior, () => [[]]);
}

export class Scroll_OverscrollBehavior extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["Contain"];
    }
    StringifyCss() {
        return "contain";
    }
}

export function Scroll_OverscrollBehavior$reflection() {
    return union_type("Fss.Types.Scroll.OverscrollBehavior", [], Scroll_OverscrollBehavior, () => [[]]);
}

export class Scroll_SnapType extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["X", "Y", "Block", "Inline", "Both"];
    }
    StringifyCss() {
        const this$ = this;
        return toString(this$).toLocaleLowerCase();
    }
}

export function Scroll_SnapType$reflection() {
    return union_type("Fss.Types.Scroll.SnapType", [], Scroll_SnapType, () => [[], [], [], [], []]);
}

export class Scroll_Viewport extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["Mandatory", "Proximity"];
    }
    StringifyCss() {
        const this$ = this;
        if (this$.tag === 1) {
            const s_1 = this$.fields[0];
            return `${MasterTypeHelpers_stringifyICssValue(s_1)} proximity`;
        }
        else {
            const s = this$.fields[0];
            return `${MasterTypeHelpers_stringifyICssValue(s)} mandatory`;
        }
    }
}

export function Scroll_Viewport$reflection() {
    return union_type("Fss.Types.Scroll.Viewport", [], Scroll_Viewport, () => [[["Item", Scroll_SnapType$reflection()]], [["Item", Scroll_SnapType$reflection()]]]);
}

export class Scroll_SnapAlign extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["Start", "End", "Center", "Double"];
    }
    StringifyCss() {
        const this$ = this;
        if (this$.tag === 3) {
            const second = this$.fields[1];
            const first = this$.fields[0];
            return `${MasterTypeHelpers_stringifyICssValue(first)} ${MasterTypeHelpers_stringifyICssValue(second)}`;
        }
        else {
            return toString(this$).toLocaleLowerCase();
        }
    }
}

export function Scroll_SnapAlign$reflection() {
    return union_type("Fss.Types.Scroll.SnapAlign", [], Scroll_SnapAlign, () => [[], [], [], [["Item1", Scroll_SnapAlign$reflection()], ["Item2", Scroll_SnapAlign$reflection()]]]);
}

export class Scroll_SnapStop extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["Normal", "Always"];
    }
    StringifyCss() {
        const this$ = this;
        return toString(this$).toLocaleLowerCase();
    }
}

export function Scroll_SnapStop$reflection() {
    return union_type("Fss.Types.Scroll.SnapStop", [], Scroll_SnapStop, () => [[], []]);
}

export class ScrollClasses_ScrollBehavior extends CssRuleWithAuto {
    constructor(property) {
        super(property);
        this.property_2 = property;
    }
}

export function ScrollClasses_ScrollBehavior$reflection() {
    return class_type("Fss.Types.ScrollClasses.ScrollBehavior", void 0, ScrollClasses_ScrollBehavior, CssRuleWithAuto$reflection());
}

export function ScrollClasses_ScrollBehavior_$ctor_Z207A3CFB(property) {
    return new ScrollClasses_ScrollBehavior(property);
}

export function ScrollClasses_ScrollBehavior__get_smooth(this$) {
    const tupledArg = [this$.property_2, new Scroll_ScrollBehavior(0)];
    return [tupledArg[0], tupledArg[1]];
}

export class ScrollClasses_ScrollMargin extends unitHelpers_DirectionalLength {
    constructor(property) {
        super(property);
    }
}

export function ScrollClasses_ScrollMargin$reflection() {
    return class_type("Fss.Types.ScrollClasses.ScrollMargin", void 0, ScrollClasses_ScrollMargin, unitHelpers_DirectionalLength$reflection());
}

export function ScrollClasses_ScrollMargin_$ctor_Z207A3CFB(property) {
    return new ScrollClasses_ScrollMargin(property);
}

export class ScrollClasses_ScrollMarginDirection extends unitHelpers_CssRuleWithLength {
    constructor(property) {
        super(property);
    }
}

export function ScrollClasses_ScrollMarginDirection$reflection() {
    return class_type("Fss.Types.ScrollClasses.ScrollMarginDirection", void 0, ScrollClasses_ScrollMarginDirection, unitHelpers_CssRuleWithLength$reflection());
}

export function ScrollClasses_ScrollMarginDirection_$ctor_Z207A3CFB(property) {
    return new ScrollClasses_ScrollMarginDirection(property);
}

export class ScrollClasses_ScrollPadding extends unitHelpers_DirectionalLength {
    constructor(property) {
        super(property);
        this.property_2 = property;
    }
}

export function ScrollClasses_ScrollPadding$reflection() {
    return class_type("Fss.Types.ScrollClasses.ScrollPadding", void 0, ScrollClasses_ScrollPadding, unitHelpers_DirectionalLength$reflection());
}

export function ScrollClasses_ScrollPadding_$ctor_Z207A3CFB(property) {
    return new ScrollClasses_ScrollPadding(property);
}

export function ScrollClasses_ScrollPadding__get_auto(this$) {
    return [this$.property_2, new Auto(0)];
}

export class ScrollClasses_ScrollPaddingDirection extends unitHelpers_CssRuleWithLength {
    constructor(property) {
        super(property);
    }
}

export function ScrollClasses_ScrollPaddingDirection$reflection() {
    return class_type("Fss.Types.ScrollClasses.ScrollPaddingDirection", void 0, ScrollClasses_ScrollPaddingDirection, unitHelpers_CssRuleWithLength$reflection());
}

export function ScrollClasses_ScrollPaddingDirection_$ctor_Z207A3CFB(property) {
    return new ScrollClasses_ScrollPaddingDirection(property);
}

export class ScrollClasses_OverScrollBehavior extends CssRuleWithAutoNone {
    constructor(property) {
        super(property);
        this.property_2 = property;
    }
}

export function ScrollClasses_OverScrollBehavior$reflection() {
    return class_type("Fss.Types.ScrollClasses.OverScrollBehavior", void 0, ScrollClasses_OverScrollBehavior, CssRuleWithAutoNone$reflection());
}

export function ScrollClasses_OverScrollBehavior_$ctor_Z207A3CFB(property) {
    return new ScrollClasses_OverScrollBehavior(property);
}

export function ScrollClasses_OverScrollBehavior__get_contain(this$) {
    const tupledArg = [this$.property_2, new Scroll_OverscrollBehavior(0)];
    return [tupledArg[0], tupledArg[1]];
}

export class ScrollClasses_ScrollSnapType extends CssRuleWithNone {
    constructor(property) {
        super(property);
        this.property_2 = property;
    }
}

export function ScrollClasses_ScrollSnapType$reflection() {
    return class_type("Fss.Types.ScrollClasses.ScrollSnapType", void 0, ScrollClasses_ScrollSnapType, CssRuleWithNone$reflection());
}

export function ScrollClasses_ScrollSnapType_$ctor_Z207A3CFB(property) {
    return new ScrollClasses_ScrollSnapType(property);
}

export function ScrollClasses_ScrollSnapType__get_x(this$) {
    const tupledArg = [this$.property_2, new Scroll_SnapType(0)];
    return [tupledArg[0], tupledArg[1]];
}

export function ScrollClasses_ScrollSnapType__get_y(this$) {
    const tupledArg = [this$.property_2, new Scroll_SnapType(1)];
    return [tupledArg[0], tupledArg[1]];
}

export function ScrollClasses_ScrollSnapType__get_block(this$) {
    const tupledArg = [this$.property_2, new Scroll_SnapType(2)];
    return [tupledArg[0], tupledArg[1]];
}

export function ScrollClasses_ScrollSnapType__get_inline$0027(this$) {
    const tupledArg = [this$.property_2, new Scroll_SnapType(3)];
    return [tupledArg[0], tupledArg[1]];
}

export function ScrollClasses_ScrollSnapType__get_both(this$) {
    const tupledArg = [this$.property_2, new Scroll_SnapType(4)];
    return [tupledArg[0], tupledArg[1]];
}

export function ScrollClasses_ScrollSnapType__mandatory_Z471DD321(this$, snapType) {
    const tupledArg = [this$.property_2, new Scroll_Viewport(0, snapType)];
    return [tupledArg[0], tupledArg[1]];
}

export function ScrollClasses_ScrollSnapType__proximity_Z471DD321(this$, snapType) {
    const tupledArg = [this$.property_2, new Scroll_Viewport(1, snapType)];
    return [tupledArg[0], tupledArg[1]];
}

export class ScrollClasses_ScrollSnapAlign extends CssRuleWithNone {
    constructor(property) {
        super(property);
        this.property_2 = property;
    }
}

export function ScrollClasses_ScrollSnapAlign$reflection() {
    return class_type("Fss.Types.ScrollClasses.ScrollSnapAlign", void 0, ScrollClasses_ScrollSnapAlign, CssRuleWithNone$reflection());
}

export function ScrollClasses_ScrollSnapAlign_$ctor_Z207A3CFB(property) {
    return new ScrollClasses_ScrollSnapAlign(property);
}

export function ScrollClasses_ScrollSnapAlign__value_Z4A95CAC0(this$, first, second) {
    const tupledArg = [this$.property_2, new Scroll_SnapAlign(3, first, second)];
    return [tupledArg[0], tupledArg[1]];
}

export function ScrollClasses_ScrollSnapAlign__get_start(this$) {
    const tupledArg = [this$.property_2, new Scroll_SnapAlign(0)];
    return [tupledArg[0], tupledArg[1]];
}

export function ScrollClasses_ScrollSnapAlign__get_end$0027(this$) {
    const tupledArg = [this$.property_2, new Scroll_SnapAlign(1)];
    return [tupledArg[0], tupledArg[1]];
}

export function ScrollClasses_ScrollSnapAlign__get_center(this$) {
    const tupledArg = [this$.property_2, new Scroll_SnapAlign(2)];
    return [tupledArg[0], tupledArg[1]];
}

export class ScrollClasses_ScrollSnapStop extends CssRuleWithNormal {
    constructor(property) {
        super(property);
        this.property_2 = property;
    }
}

export function ScrollClasses_ScrollSnapStop$reflection() {
    return class_type("Fss.Types.ScrollClasses.ScrollSnapStop", void 0, ScrollClasses_ScrollSnapStop, CssRuleWithNormal$reflection());
}

export function ScrollClasses_ScrollSnapStop_$ctor_Z207A3CFB(property) {
    return new ScrollClasses_ScrollSnapStop(property);
}

export function ScrollClasses_ScrollSnapStop__get_always(this$) {
    const tupledArg = [this$.property_2, new Scroll_SnapStop(1)];
    return [tupledArg[0], tupledArg[1]];
}

//# sourceMappingURL=Scroll.fs.js.map
