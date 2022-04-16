import { Helpers_toKebabCase } from "../Utilities.fs.js";
import { Union } from "../../fable-library.3.7.9/Types.js";
import { tuple_type, list_type, class_type, union_type } from "../../fable-library.3.7.9/Reflection.js";
import { Percent$reflection, unitHelpers_lengthPercentageString } from "./Units.fs.js";
import { join, replace } from "../../fable-library.3.7.9/String.js";
import { PathMaster, UrlMaster, CssRuleWithNone$reflection, CssRuleWithNone, MasterTypeHelpers_stringifyICssValue } from "./MasterTypes.fs.js";
import { map } from "../../fable-library.3.7.9/List.js";

export class ClipPath_Geometry extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["MarginBox", "BorderBox", "PaddingBox", "ContentBox", "FillBox", "StrokeBox", "ViewBox"];
    }
    StringifyCss() {
        const this$ = this;
        return Helpers_toKebabCase(this$);
    }
}

export function ClipPath_Geometry$reflection() {
    return union_type("Fss.Types.ClipPath.Geometry", [], ClipPath_Geometry, () => [[], [], [], [], [], [], []]);
}

export class ClipPath_Inset extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["All", "HorizontalVertical", "TopHorizontalBottom", "TopRightBottomLeft"];
    }
    StringifyCss() {
        const this$ = this;
        switch (this$.tag) {
            case 1: {
                const b = this$.fields[1];
                const a = this$.fields[0];
                return `inset(${unitHelpers_lengthPercentageString(a)} ${unitHelpers_lengthPercentageString(b)})`;
            }
            case 2: {
                const c = this$.fields[2];
                const b_1 = this$.fields[1];
                const a_1 = this$.fields[0];
                return `inset(${unitHelpers_lengthPercentageString(a_1)} ${unitHelpers_lengthPercentageString(b_1)} ${unitHelpers_lengthPercentageString(c)})`;
            }
            case 3: {
                const d = this$.fields[3];
                const c_1 = this$.fields[2];
                const b_2 = this$.fields[1];
                const a_2 = this$.fields[0];
                return `inset(${unitHelpers_lengthPercentageString(a_2)} ${unitHelpers_lengthPercentageString(b_2)} ${unitHelpers_lengthPercentageString(c_1)} ${unitHelpers_lengthPercentageString(d)})`;
            }
            default: {
                const length = this$.fields[0];
                return `inset(${unitHelpers_lengthPercentageString(length)})`;
            }
        }
    }
}

export function ClipPath_Inset$reflection() {
    return union_type("Fss.Types.ClipPath.Inset", [], ClipPath_Inset, () => [[["Item", class_type("Fss.Types.ILengthPercentage")]], [["Item1", class_type("Fss.Types.ILengthPercentage")], ["Item2", class_type("Fss.Types.ILengthPercentage")]], [["Item1", class_type("Fss.Types.ILengthPercentage")], ["Item2", class_type("Fss.Types.ILengthPercentage")], ["Item3", class_type("Fss.Types.ILengthPercentage")]], [["Item1", class_type("Fss.Types.ILengthPercentage")], ["Item2", class_type("Fss.Types.ILengthPercentage")], ["Item3", class_type("Fss.Types.ILengthPercentage")], ["Item4", class_type("Fss.Types.ILengthPercentage")]]]);
}

export class ClipPath_Round extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["Round"];
    }
    StringifyCss() {
        const this$ = this;
        const lengths = this$.fields[1];
        const inset = this$.fields[0];
        const inset_1 = replace(MasterTypeHelpers_stringifyICssValue(inset), ")", "");
        const lengths_1 = join(" ", map(unitHelpers_lengthPercentageString, lengths));
        return `${inset_1} round ${lengths_1})`;
    }
}

export function ClipPath_Round$reflection() {
    return union_type("Fss.Types.ClipPath.Round", [], ClipPath_Round, () => [[["Item1", ClipPath_Inset$reflection()], ["Item2", list_type(class_type("Fss.Types.ILengthPercentage"))]]]);
}

export class ClipPath_Polygon extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["Polygon"];
    }
    StringifyCss() {
        const this$ = this;
        const ps = this$.fields[0];
        const polygons = join(", ", map((tupledArg) => {
            const x = tupledArg[0];
            const y = tupledArg[1];
            return `${unitHelpers_lengthPercentageString(x)} ${unitHelpers_lengthPercentageString(y)}`;
        }, ps));
        return `polygon(${polygons})`;
    }
}

export function ClipPath_Polygon$reflection() {
    return union_type("Fss.Types.ClipPath.Polygon", [], ClipPath_Polygon, () => [[["Item", list_type(tuple_type(Percent$reflection(), Percent$reflection()))]]]);
}

export class ClipPath_Circle extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["Circle", "CircleAt"];
    }
    StringifyCss() {
        const this$ = this;
        if (this$.tag === 1) {
            const y = this$.fields[2];
            const x = this$.fields[1];
            const size = this$.fields[0];
            return `circle(${unitHelpers_lengthPercentageString(size)} at ${unitHelpers_lengthPercentageString(x)} ${unitHelpers_lengthPercentageString(y)})`;
        }
        else {
            const c = this$.fields[0];
            return `circle(${unitHelpers_lengthPercentageString(c)})`;
        }
    }
}

export function ClipPath_Circle$reflection() {
    return union_type("Fss.Types.ClipPath.Circle", [], ClipPath_Circle, () => [[["Item", class_type("Fss.Types.ILengthPercentage")]], [["Item1", class_type("Fss.Types.ILengthPercentage")], ["Item2", class_type("Fss.Types.ILengthPercentage")], ["Item3", class_type("Fss.Types.ILengthPercentage")]]]);
}

export class ClipPath_Ellipse extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["Ellipse", "EllipseAt"];
    }
    StringifyCss() {
        const this$ = this;
        if (this$.tag === 1) {
            const y = this$.fields[2];
            const x = this$.fields[1];
            const size = this$.fields[0];
            return `ellipse(${unitHelpers_lengthPercentageString(size)} at ${unitHelpers_lengthPercentageString(x)} ${unitHelpers_lengthPercentageString(y)})`;
        }
        else {
            const e = this$.fields[0];
            return `ellipse(${unitHelpers_lengthPercentageString(e)})`;
        }
    }
}

export function ClipPath_Ellipse$reflection() {
    return union_type("Fss.Types.ClipPath.Ellipse", [], ClipPath_Ellipse, () => [[["Item", class_type("Fss.Types.ILengthPercentage")]], [["Item1", class_type("Fss.Types.ILengthPercentage")], ["Item2", class_type("Fss.Types.ILengthPercentage")], ["Item3", class_type("Fss.Types.ILengthPercentage")]]]);
}

export class ClipPathClasses_ClipPath extends CssRuleWithNone {
    constructor(property) {
        super(property);
        this.property_2 = property;
    }
}

export function ClipPathClasses_ClipPath$reflection() {
    return class_type("Fss.Types.ClipPathClasses.ClipPath", void 0, ClipPathClasses_ClipPath, CssRuleWithNone$reflection());
}

export function ClipPathClasses_ClipPath_$ctor_Z207A3CFB(property) {
    return new ClipPathClasses_ClipPath(property);
}

export function ClipPathClasses_ClipPath__url_Z721C83C5(this$, url) {
    const tupledArg = [this$.property_2, new UrlMaster(0, url)];
    return [tupledArg[0], tupledArg[1]];
}

export function ClipPathClasses_ClipPath__path_Z721C83C5(this$, path) {
    const tupledArg = [this$.property_2, new PathMaster(0, path)];
    return [tupledArg[0], tupledArg[1]];
}

export function ClipPathClasses_ClipPath__inset_Z498FEB3B(this$, inset) {
    const tupledArg = [this$.property_2, new ClipPath_Inset(0, inset)];
    return [tupledArg[0], tupledArg[1]];
}

export function ClipPathClasses_ClipPath__inset_3202B9A0(this$, horizontal, vertical) {
    const tupledArg = [this$.property_2, new ClipPath_Inset(1, horizontal, vertical)];
    return [tupledArg[0], tupledArg[1]];
}

export function ClipPathClasses_ClipPath__inset_Z3BD6069B(this$, top, horizontal, bottom) {
    const tupledArg = [this$.property_2, new ClipPath_Inset(2, top, horizontal, bottom)];
    return [tupledArg[0], tupledArg[1]];
}

export function ClipPathClasses_ClipPath__inset_ZE6CD40(this$, top, right, bottom, left) {
    const tupledArg = [this$.property_2, new ClipPath_Inset(3, top, right, bottom, left)];
    return [tupledArg[0], tupledArg[1]];
}

export function ClipPathClasses_ClipPath__inset_ZF45F716(this$, inset, round) {
    const tupledArg = [this$.property_2, new ClipPath_Round(0, new ClipPath_Inset(0, inset), round)];
    return [tupledArg[0], tupledArg[1]];
}

export function ClipPathClasses_ClipPath__inset_691482F(this$, horizontal, vertical, round) {
    const tupledArg = [this$.property_2, new ClipPath_Round(0, new ClipPath_Inset(1, horizontal, vertical), round)];
    return [tupledArg[0], tupledArg[1]];
}

export function ClipPathClasses_ClipPath__inset_3DA1838A(this$, top, horizontal, bottom, round) {
    const tupledArg = [this$.property_2, new ClipPath_Round(0, new ClipPath_Inset(2, top, horizontal, bottom), round)];
    return [tupledArg[0], tupledArg[1]];
}

export function ClipPathClasses_ClipPath__inset_Z6908D0B1(this$, top, right, bottom, left, round) {
    const tupledArg = [this$.property_2, new ClipPath_Round(0, new ClipPath_Inset(3, top, right, bottom, left), round)];
    return [tupledArg[0], tupledArg[1]];
}

export function ClipPathClasses_ClipPath__circle_Z498FEB3B(this$, circle) {
    const tupledArg = [this$.property_2, new ClipPath_Circle(0, circle)];
    return [tupledArg[0], tupledArg[1]];
}

export function ClipPathClasses_ClipPath__circleAt_Z3BD6069B(this$, circle, x, y) {
    const tupledArg = [this$.property_2, new ClipPath_Circle(1, circle, x, y)];
    return [tupledArg[0], tupledArg[1]];
}

export function ClipPathClasses_ClipPath__ellipse_Z498FEB3B(this$, ellipse) {
    const tupledArg = [this$.property_2, new ClipPath_Ellipse(0, ellipse)];
    return [tupledArg[0], tupledArg[1]];
}

export function ClipPathClasses_ClipPath__ellipseAt_Z3BD6069B(this$, ellipse, x, y) {
    const tupledArg = [this$.property_2, new ClipPath_Ellipse(1, ellipse, x, y)];
    return [tupledArg[0], tupledArg[1]];
}

export function ClipPathClasses_ClipPath__polygon_Z62DEF1BB(this$, points) {
    const tupledArg = [this$.property_2, new ClipPath_Polygon(0, points)];
    return [tupledArg[0], tupledArg[1]];
}

export function ClipPathClasses_ClipPath__get_marginBox(this$) {
    const tupledArg = [this$.property_2, new ClipPath_Geometry(0)];
    return [tupledArg[0], tupledArg[1]];
}

export function ClipPathClasses_ClipPath__get_borderBox(this$) {
    const tupledArg = [this$.property_2, new ClipPath_Geometry(1)];
    return [tupledArg[0], tupledArg[1]];
}

export function ClipPathClasses_ClipPath__get_paddingBox(this$) {
    const tupledArg = [this$.property_2, new ClipPath_Geometry(2)];
    return [tupledArg[0], tupledArg[1]];
}

export function ClipPathClasses_ClipPath__get_contentBox(this$) {
    const tupledArg = [this$.property_2, new ClipPath_Geometry(3)];
    return [tupledArg[0], tupledArg[1]];
}

export function ClipPathClasses_ClipPath__get_fillBox(this$) {
    const tupledArg = [this$.property_2, new ClipPath_Geometry(4)];
    return [tupledArg[0], tupledArg[1]];
}

export function ClipPathClasses_ClipPath__get_strokeBox(this$) {
    const tupledArg = [this$.property_2, new ClipPath_Geometry(5)];
    return [tupledArg[0], tupledArg[1]];
}

export function ClipPathClasses_ClipPath__get_viewBox(this$) {
    const tupledArg = [this$.property_2, new ClipPath_Geometry(6)];
    return [tupledArg[0], tupledArg[1]];
}

//# sourceMappingURL=ClipPath.fs.js.map
