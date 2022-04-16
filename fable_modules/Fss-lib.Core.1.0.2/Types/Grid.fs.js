import { Union, toString } from "../../fable-library.3.7.9/Types.js";
import { list_type, class_type, string_type, int32_type, union_type } from "../../fable-library.3.7.9/Reflection.js";
import { Helpers_toKebabCase } from "../Utilities.fs.js";
import { Percent$reflection, Length$reflection, unitHelpers_lengthPercentageToType, Fraction$reflection, unitHelpers_lengthPercentageString } from "./Units.fs.js";
import { CssRuleWithNone$reflection, CssRuleWithNone, CssRule$reflection, CssRule, CssRuleWithAutoNone$reflection, CssRuleWithAutoNone, CssRuleWithNormal$reflection, CssRuleWithNormal, DividerMaster, Int, String$, CssRuleWithAuto$reflection, CssRuleWithAuto, MasterTypeHelpers_stringifyICssValue } from "./MasterTypes.fs.js";
import { ContentSizeClasses_ContentSize$reflection, ContentSizeClasses_ContentSize, ContentSize_ContentSize, ContentSize_ContentSize$reflection } from "./ContentSize.fs.js";
import { join } from "../../fable-library.3.7.9/String.js";
import { fold, map } from "../../fable-library.3.7.9/List.js";
import { int32ToString } from "../../fable-library.3.7.9/Util.js";

export class Grid_GridAutoFlow extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["Row", "Column", "Dense", "RowDense", "ColumnDense"];
    }
    StringifyCss() {
        const this$ = this;
        switch (this$.tag) {
            case 3: {
                return "row dense";
            }
            case 4: {
                return "column dense";
            }
            default: {
                return toString(this$).toLocaleLowerCase();
            }
        }
    }
}

export function Grid_GridAutoFlow$reflection() {
    return union_type("Fss.Types.Grid.GridAutoFlow", [], Grid_GridAutoFlow, () => [[], [], [], [], []]);
}

export class Grid_GridTemplate extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["Subgrid", "Masonry"];
    }
    StringifyCss() {
        const this$ = this;
        return toString(this$).toLocaleLowerCase();
    }
}

export function Grid_GridTemplate$reflection() {
    return union_type("Fss.Types.Grid.GridTemplate", [], Grid_GridTemplate, () => [[], []]);
}

export class Grid_GridPosition extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["Value", "Ident", "IdentValue", "ValueIdentSpan", "Span"];
    }
    StringifyCss() {
        const this$ = this;
        return toString(this$).toLocaleLowerCase();
    }
}

export function Grid_GridPosition$reflection() {
    return union_type("Fss.Types.Grid.GridPosition", [], Grid_GridPosition, () => [[["Item", int32_type]], [["Item", string_type]], [["Item1", string_type], ["Item2", int32_type]], [["Item1", int32_type], ["Item2", string_type]], [["Item", string_type]]]);
}

export class Grid_RepeatType extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["AutoFill", "AutoFit"];
    }
    StringifyCss() {
        const this$ = this;
        return Helpers_toKebabCase(this$);
    }
}

export function Grid_RepeatType$reflection() {
    return union_type("Fss.Types.Grid.RepeatType", [], Grid_RepeatType, () => [[], []]);
}

export class Grid_MinMaxHelper extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["MinMax1", "MinMax2", "MinMax3", "MinMax4", "MinMax5", "MinMax6"];
    }
    StringifyCss() {
        const this$ = this;
        const minmaxValue = (a, b) => (`minmax(${a}, ${b})`);
        switch (this$.tag) {
            case 1: {
                const lengthPercentage2 = this$.fields[1];
                const lengthPercentage1 = this$.fields[0];
                return minmaxValue(unitHelpers_lengthPercentageString(lengthPercentage1), unitHelpers_lengthPercentageString(lengthPercentage2));
            }
            case 2: {
                const lengthPercentage_1 = this$.fields[0];
                const contentSize = this$.fields[1];
                return minmaxValue(unitHelpers_lengthPercentageString(lengthPercentage_1), MasterTypeHelpers_stringifyICssValue(contentSize));
            }
            case 3: {
                const lengthPercentage_2 = this$.fields[1];
                const contentSize_1 = this$.fields[0];
                return minmaxValue(MasterTypeHelpers_stringifyICssValue(contentSize_1), unitHelpers_lengthPercentageString(lengthPercentage_2));
            }
            case 4: {
                const contentSize2 = this$.fields[1];
                const contentSize1 = this$.fields[0];
                return minmaxValue(MasterTypeHelpers_stringifyICssValue(contentSize1), MasterTypeHelpers_stringifyICssValue(contentSize2));
            }
            case 5: {
                const fraction_1 = this$.fields[1];
                const contentSize_2 = this$.fields[0];
                return minmaxValue(MasterTypeHelpers_stringifyICssValue(contentSize_2), MasterTypeHelpers_stringifyICssValue(fraction_1));
            }
            default: {
                const lengthPercentage = this$.fields[0];
                const fraction = this$.fields[1];
                return minmaxValue(unitHelpers_lengthPercentageString(lengthPercentage), MasterTypeHelpers_stringifyICssValue(fraction));
            }
        }
    }
}

export function Grid_MinMaxHelper$reflection() {
    return union_type("Fss.Types.Grid.MinMaxHelper", [], Grid_MinMaxHelper, () => [[["Item1", class_type("Fss.Types.ILengthPercentage")], ["Item2", Fraction$reflection()]], [["Item1", class_type("Fss.Types.ILengthPercentage")], ["Item2", class_type("Fss.Types.ILengthPercentage")]], [["Item1", class_type("Fss.Types.ILengthPercentage")], ["Item2", ContentSize_ContentSize$reflection()]], [["Item1", ContentSize_ContentSize$reflection()], ["Item2", class_type("Fss.Types.ILengthPercentage")]], [["Item1", ContentSize_ContentSize$reflection()], ["Item2", ContentSize_ContentSize$reflection()]], [["Item1", ContentSize_ContentSize$reflection()], ["Item2", Fraction$reflection()]]]);
}

export class Grid_MinMax {
    constructor() {
    }
}

export function Grid_MinMax$reflection() {
    return class_type("Fss.Types.Grid.MinMax", void 0, Grid_MinMax);
}

export function Grid_MinMax_MinMax_Z1B4A27B9(min, max) {
    return new Grid_MinMaxHelper(0, min, max);
}

export function Grid_MinMax_MinMax_3202B9A0(min, max) {
    return new Grid_MinMaxHelper(1, min, max);
}

export function Grid_MinMax_MinMax_Z19A3727D(min, max) {
    return new Grid_MinMaxHelper(2, min, max);
}

export function Grid_MinMax_MinMax_11822963(min, max) {
    return new Grid_MinMaxHelper(3, min, max);
}

export function Grid_MinMax_MinMax_Z3A23E2C0(min, max) {
    return new Grid_MinMaxHelper(4, min, max);
}

export function Grid_MinMax_MinMax_Z38CAB77C(min, max) {
    return new Grid_MinMaxHelper(5, min, max);
}

export class Grid_RepeatHelper extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["Repeat1", "Repeat2", "Repeat3", "Repeat4", "Repeat5", "Repeat6", "Repeat7", "Repeat8", "Repeat9"];
    }
    StringifyCss() {
        const this$ = this;
        const repeatValue = (a, b) => (`repeat(${a}, ${b})`);
        switch (this$.tag) {
            case 1: {
                const value_1 = this$.fields[0] | 0;
                const fraction = this$.fields[1];
                return repeatValue(value_1, MasterTypeHelpers_stringifyICssValue(fraction));
            }
            case 2: {
                const value_2 = this$.fields[0] | 0;
                const contentSize = this$.fields[1];
                return repeatValue(value_2, MasterTypeHelpers_stringifyICssValue(contentSize));
            }
            case 3: {
                const value_3 = this$.fields[0] | 0;
                const contentSizes = this$.fields[1];
                return repeatValue(value_3, join(" ", map(MasterTypeHelpers_stringifyICssValue, contentSizes)));
            }
            case 4: {
                const value_4 = this$.fields[0] | 0;
                const lengthPercentages = this$.fields[1];
                return repeatValue(value_4, join(" ", map(unitHelpers_lengthPercentageString, lengthPercentages)));
            }
            case 5: {
                const repeat = this$.fields[0];
                const fraction_1 = this$.fields[1];
                return repeatValue(MasterTypeHelpers_stringifyICssValue(repeat), MasterTypeHelpers_stringifyICssValue(fraction_1));
            }
            case 6: {
                const repeat_1 = this$.fields[0];
                const lengthPercentage = this$.fields[1];
                return repeatValue(MasterTypeHelpers_stringifyICssValue(repeat_1), unitHelpers_lengthPercentageString(lengthPercentage));
            }
            case 7: {
                const repeat_2 = this$.fields[0];
                const contentSize_1 = this$.fields[1];
                return repeatValue(MasterTypeHelpers_stringifyICssValue(repeat_2), MasterTypeHelpers_stringifyICssValue(contentSize_1));
            }
            case 8: {
                const value_5 = this$.fields[0] | 0;
                const minMax = this$.fields[1];
                return repeatValue(value_5, MasterTypeHelpers_stringifyICssValue(minMax));
            }
            default: {
                const value = this$.fields[0] | 0;
                const length = this$.fields[1];
                return repeatValue(value, unitHelpers_lengthPercentageString(length));
            }
        }
    }
}

export function Grid_RepeatHelper$reflection() {
    return union_type("Fss.Types.Grid.RepeatHelper", [], Grid_RepeatHelper, () => [[["Item1", int32_type], ["Item2", class_type("Fss.Types.ILengthPercentage")]], [["Item1", int32_type], ["Item2", Fraction$reflection()]], [["Item1", int32_type], ["Item2", ContentSize_ContentSize$reflection()]], [["Item1", int32_type], ["Item2", list_type(ContentSize_ContentSize$reflection())]], [["Item1", int32_type], ["Item2", list_type(class_type("Fss.Types.ILengthPercentage"))]], [["Item1", Grid_RepeatType$reflection()], ["Item2", Fraction$reflection()]], [["Item1", Grid_RepeatType$reflection()], ["Item2", class_type("Fss.Types.ILengthPercentage")]], [["Item1", Grid_RepeatType$reflection()], ["Item2", ContentSize_ContentSize$reflection()]], [["Item1", int32_type], ["Item2", Grid_MinMaxHelper$reflection()]]]);
}

export class Grid_Repeat {
    constructor() {
    }
}

export function Grid_Repeat$reflection() {
    return class_type("Fss.Types.Grid.Repeat", void 0, Grid_Repeat);
}

export function Grid_Repeat_Repeat_Z2CFD9AE7(value, length) {
    return new Grid_RepeatHelper(0, value, length);
}

export function Grid_Repeat_Repeat_5B504FE(value, length) {
    return new Grid_RepeatHelper(1, value, length);
}

export function Grid_Repeat_Repeat_75C513A(value, length) {
    return new Grid_RepeatHelper(2, value, length);
}

export function Grid_Repeat_Repeat_356F4650(value, length) {
    return new Grid_RepeatHelper(3, value, length);
}

export function Grid_Repeat_Repeat_11BAD453(value, length) {
    return new Grid_RepeatHelper(4, value, length);
}

export function Grid_Repeat_Repeat_1D7A60B3(value, length) {
    return new Grid_RepeatHelper(5, value, length);
}

export function Grid_Repeat_Repeat_Z3432FEAC(value, length) {
    return new Grid_RepeatHelper(6, value, length);
}

export function Grid_Repeat_Repeat_1F933577(value, length) {
    return new Grid_RepeatHelper(7, value, length);
}

export function Grid_Repeat_Repeat_5FB0605A(value, length) {
    return new Grid_RepeatHelper(8, value, length);
}

export class GridClasses_GridPosition extends CssRuleWithAuto {
    constructor(property) {
        super(property);
        this.property_2 = property;
    }
}

export function GridClasses_GridPosition$reflection() {
    return class_type("Fss.Types.GridClasses.GridPosition", void 0, GridClasses_GridPosition, CssRuleWithAuto$reflection());
}

export function GridClasses_GridPosition_$ctor_Z207A3CFB(property) {
    return new GridClasses_GridPosition(property);
}

export function GridClasses_GridPosition__value_Z721C83C5(this$, area) {
    const tupledArg = [this$.property_2, new String$(0, area)];
    return [tupledArg[0], tupledArg[1]];
}

export class GridClasses_GridColumn extends CssRuleWithAuto {
    constructor(property) {
        super(property);
        this.property_2 = property;
    }
}

export function GridClasses_GridColumn$reflection() {
    return class_type("Fss.Types.GridClasses.GridColumn", void 0, GridClasses_GridColumn, CssRuleWithAuto$reflection());
}

export function GridClasses_GridColumn_$ctor_Z207A3CFB(property) {
    return new GridClasses_GridColumn(property);
}

export function GridClasses_GridColumn__value_Z721C83C5(this$, area) {
    const tupledArg = [this$.property_2, new String$(0, area)];
    return [tupledArg[0], tupledArg[1]];
}

export function GridClasses_GridColumn__value_Z524259A4(this$, value) {
    const tupledArg = [this$.property_2, new Int(0, value)];
    return [tupledArg[0], tupledArg[1]];
}

export function GridClasses_GridColumn__value_Z176EF219(this$, value, area) {
    const value_1 = `${value} ${area}`;
    const tupledArg = [this$.property_2, new String$(0, value_1)];
    return [tupledArg[0], tupledArg[1]];
}

export function GridClasses_GridColumn__span_Z524259A4(this$, value) {
    const value_1 = `span ${value}`;
    const tupledArg = [this$.property_2, new String$(0, value_1)];
    return [tupledArg[0], tupledArg[1]];
}

export class GridClasses_GridRow extends GridClasses_GridPosition {
    constructor(property) {
        super(property);
        this.property_3 = property;
    }
}

export function GridClasses_GridRow$reflection() {
    return class_type("Fss.Types.GridClasses.GridRow", void 0, GridClasses_GridRow, GridClasses_GridPosition$reflection());
}

export function GridClasses_GridRow_$ctor_Z207A3CFB(property) {
    return new GridClasses_GridRow(property);
}

export function GridClasses_GridRow__value_Z18115A39(this$, area, value) {
    const tupledArg = [this$.property_3, new DividerMaster(0, area, int32ToString(value))];
    return [tupledArg[0], tupledArg[1]];
}

export class GridClasses_GridGap extends CssRuleWithNormal {
    constructor(property) {
        super(property);
        this.property_2 = property;
    }
}

export function GridClasses_GridGap$reflection() {
    return class_type("Fss.Types.GridClasses.GridGap", void 0, GridClasses_GridGap, CssRuleWithNormal$reflection());
}

export function GridClasses_GridGap_$ctor_Z207A3CFB(property) {
    return new GridClasses_GridGap(property);
}

export function GridClasses_GridGap__value_Z498FEB3B(this$, gap) {
    const tupledArg = [this$.property_2, unitHelpers_lengthPercentageToType(gap)];
    return [tupledArg[0], tupledArg[1]];
}

export class GridClasses_GridTwoGap extends GridClasses_GridGap {
    constructor(property) {
        super(property);
        this.property_3 = property;
    }
}

export function GridClasses_GridTwoGap$reflection() {
    return class_type("Fss.Types.GridClasses.GridTwoGap", void 0, GridClasses_GridTwoGap, GridClasses_GridGap$reflection());
}

export function GridClasses_GridTwoGap_$ctor_Z207A3CFB(property) {
    return new GridClasses_GridTwoGap(property);
}

export function GridClasses_GridTwoGap__value_3202B9A0(this$, rowGap, columnGap) {
    const value = new String$(0, `${unitHelpers_lengthPercentageString(rowGap)} ${unitHelpers_lengthPercentageString(columnGap)}`);
    const tupledArg = [this$.property_3, value];
    return [tupledArg[0], tupledArg[1]];
}

export class GridClasses_GridTemplate extends CssRuleWithAutoNone {
    constructor(property) {
        super(property);
        this.property_2 = property;
    }
}

export function GridClasses_GridTemplate$reflection() {
    return class_type("Fss.Types.GridClasses.GridTemplate", void 0, GridClasses_GridTemplate, CssRuleWithAutoNone$reflection());
}

export function GridClasses_GridTemplate_$ctor_Z207A3CFB(property) {
    return new GridClasses_GridTemplate(property);
}

export function GridClasses_GridTemplate__value_Z498FEB3B(this$, template) {
    const tupledArg = [this$.property_2, unitHelpers_lengthPercentageToType(template)];
    return [tupledArg[0], tupledArg[1]];
}

export function GridClasses_GridTemplate__minMax_Z1B4A27B9(this$, min, max) {
    const tupledArg = [this$.property_2, Grid_MinMax_MinMax_Z1B4A27B9(min, max)];
    return [tupledArg[0], tupledArg[1]];
}

export function GridClasses_GridTemplate__minMax_3202B9A0(this$, min, max) {
    const tupledArg = [this$.property_2, Grid_MinMax_MinMax_3202B9A0(min, max)];
    return [tupledArg[0], tupledArg[1]];
}

export function GridClasses_GridTemplate__minMax_Z19A3727D(this$, min, max) {
    const tupledArg = [this$.property_2, Grid_MinMax_MinMax_Z19A3727D(min, max)];
    return [tupledArg[0], tupledArg[1]];
}

export function GridClasses_GridTemplate__minMax_11822963(this$, min, max) {
    const tupledArg = [this$.property_2, Grid_MinMax_MinMax_11822963(min, max)];
    return [tupledArg[0], tupledArg[1]];
}

export function GridClasses_GridTemplate__minMax_Z3A23E2C0(this$, min, max) {
    const tupledArg = [this$.property_2, Grid_MinMax_MinMax_Z3A23E2C0(min, max)];
    return [tupledArg[0], tupledArg[1]];
}

export function GridClasses_GridTemplate__minMax_Z38CAB77C(this$, min, max) {
    const tupledArg = [this$.property_2, Grid_MinMax_MinMax_Z38CAB77C(min, max)];
    return [tupledArg[0], tupledArg[1]];
}

export function GridClasses_GridTemplate__fitContent_Z498FEB3B(this$, fitContent) {
    const tupledArg = [this$.property_2, new ContentSize_ContentSize(2, fitContent)];
    return [tupledArg[0], tupledArg[1]];
}

export function GridClasses_GridTemplate__repeat_Z2CFD9AE7(this$, number, size) {
    const tupledArg = [this$.property_2, Grid_Repeat_Repeat_Z2CFD9AE7(number, size)];
    return [tupledArg[0], tupledArg[1]];
}

export function GridClasses_GridTemplate__repeat_5B504FE(this$, value, fraction) {
    const tupledArg = [this$.property_2, Grid_Repeat_Repeat_5B504FE(value, fraction)];
    return [tupledArg[0], tupledArg[1]];
}

export function GridClasses_GridTemplate__repeat_75C513A(this$, value, contentSize) {
    const tupledArg = [this$.property_2, Grid_Repeat_Repeat_75C513A(value, contentSize)];
    return [tupledArg[0], tupledArg[1]];
}

export function GridClasses_GridTemplate__repeat_356F4650(this$, value, contentSizes) {
    const tupledArg = [this$.property_2, Grid_Repeat_Repeat_356F4650(value, contentSizes)];
    return [tupledArg[0], tupledArg[1]];
}

export function GridClasses_GridTemplate__repeat_11BAD453(this$, value, sizes) {
    const tupledArg = [this$.property_2, Grid_Repeat_Repeat_11BAD453(value, sizes)];
    return [tupledArg[0], tupledArg[1]];
}

export function GridClasses_GridTemplate__repeat_1D7A60B3(this$, value, fraction) {
    const tupledArg = [this$.property_2, Grid_Repeat_Repeat_1D7A60B3(value, fraction)];
    return [tupledArg[0], tupledArg[1]];
}

export function GridClasses_GridTemplate__repeat_Z3432FEAC(this$, value, length) {
    const tupledArg = [this$.property_2, Grid_Repeat_Repeat_Z3432FEAC(value, length)];
    return [tupledArg[0], tupledArg[1]];
}

export function GridClasses_GridTemplate__repeat_1F933577(this$, value, contentSize) {
    const tupledArg = [this$.property_2, Grid_Repeat_Repeat_1F933577(value, contentSize)];
    return [tupledArg[0], tupledArg[1]];
}

export function GridClasses_GridTemplate__repeat_5FB0605A(this$, value, minMax) {
    const tupledArg = [this$.property_2, Grid_Repeat_Repeat_5FB0605A(value, minMax)];
    return [tupledArg[0], tupledArg[1]];
}

export function GridClasses_GridTemplate__get_subgrid(this$) {
    const tupledArg = [this$.property_2, new Grid_GridTemplate(0)];
    return [tupledArg[0], tupledArg[1]];
}

export function GridClasses_GridTemplate__get_masonry(this$) {
    const tupledArg = [this$.property_2, new Grid_GridTemplate(1)];
    return [tupledArg[0], tupledArg[1]];
}

export class GridClasses_AutoHelper extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["Fractions", "ContentSizes", "Length", "Percent"];
    }
    StringifyCss() {
        const this$ = this;
        switch (this$.tag) {
            case 1: {
                const sizes = this$.fields[0];
                return join(" ", map(MasterTypeHelpers_stringifyICssValue, sizes));
            }
            case 2: {
                const lengths = this$.fields[0];
                return join(" ", map(MasterTypeHelpers_stringifyICssValue, lengths));
            }
            case 3: {
                const percents = this$.fields[0];
                return join(" ", map(MasterTypeHelpers_stringifyICssValue, percents));
            }
            default: {
                const fractions = this$.fields[0];
                return join(" ", map(MasterTypeHelpers_stringifyICssValue, fractions));
            }
        }
    }
}

export function GridClasses_AutoHelper$reflection() {
    return union_type("Fss.Types.GridClasses.AutoHelper", [], GridClasses_AutoHelper, () => [[["Item", list_type(Fraction$reflection())]], [["Item", list_type(ContentSize_ContentSize$reflection())]], [["Item", list_type(Length$reflection())]], [["Item", list_type(Percent$reflection())]]]);
}

export class GridClasses_GridAuto extends ContentSizeClasses_ContentSize {
    constructor(property) {
        super(property);
        this.property_4 = property;
    }
}

export function GridClasses_GridAuto$reflection() {
    return class_type("Fss.Types.GridClasses.GridAuto", void 0, GridClasses_GridAuto, ContentSizeClasses_ContentSize$reflection());
}

export function GridClasses_GridAuto_$ctor_Z207A3CFB(property) {
    return new GridClasses_GridAuto(property);
}

export function GridClasses_GridAuto__value_60C77522(this$, fraction) {
    const tupledArg = [this$.property_4, fraction];
    return [tupledArg[0], tupledArg[1]];
}

export function GridClasses_GridAuto__value_Z3ECA5D98(this$, fraction) {
    const tupledArg = [this$.property_4, new GridClasses_AutoHelper(0, fraction)];
    return [tupledArg[0], tupledArg[1]];
}

export function GridClasses_GridAuto__value_Z737E3B82(this$, sizes) {
    const tupledArg = [this$.property_4, new GridClasses_AutoHelper(2, sizes)];
    return [tupledArg[0], tupledArg[1]];
}

export function GridClasses_GridAuto__value_1FA41A59(this$, sizes) {
    const tupledArg = [this$.property_4, new GridClasses_AutoHelper(3, sizes)];
    return [tupledArg[0], tupledArg[1]];
}

export function GridClasses_GridAuto__value_501D378C(this$, contentSizes) {
    const tupledArg = [this$.property_4, new GridClasses_AutoHelper(1, contentSizes)];
    return [tupledArg[0], tupledArg[1]];
}

export class GridClasses_GridAutoFlow extends CssRule {
    constructor(property) {
        super(property);
        this.property_1 = property;
    }
}

export function GridClasses_GridAutoFlow$reflection() {
    return class_type("Fss.Types.GridClasses.GridAutoFlow", void 0, GridClasses_GridAutoFlow, CssRule$reflection());
}

export function GridClasses_GridAutoFlow_$ctor_Z207A3CFB(property) {
    return new GridClasses_GridAutoFlow(property);
}

export function GridClasses_GridAutoFlow__get_row(this$) {
    const tupledArg = [this$.property_1, new Grid_GridAutoFlow(0)];
    return [tupledArg[0], tupledArg[1]];
}

export function GridClasses_GridAutoFlow__get_column(this$) {
    const tupledArg = [this$.property_1, new Grid_GridAutoFlow(1)];
    return [tupledArg[0], tupledArg[1]];
}

export function GridClasses_GridAutoFlow__get_dense(this$) {
    const tupledArg = [this$.property_1, new Grid_GridAutoFlow(2)];
    return [tupledArg[0], tupledArg[1]];
}

export function GridClasses_GridAutoFlow__get_rowDense(this$) {
    const tupledArg = [this$.property_1, new Grid_GridAutoFlow(3)];
    return [tupledArg[0], tupledArg[1]];
}

export function GridClasses_GridAutoFlow__get_columnDense(this$) {
    const tupledArg = [this$.property_1, new Grid_GridAutoFlow(4)];
    return [tupledArg[0], tupledArg[1]];
}

export class GridClasses_GridTemplateAreas extends CssRuleWithNone {
    constructor(property) {
        super(property);
        this.property_2 = property;
    }
}

export function GridClasses_GridTemplateAreas$reflection() {
    return class_type("Fss.Types.GridClasses.GridTemplateAreas", void 0, GridClasses_GridTemplateAreas, CssRuleWithNone$reflection());
}

export function GridClasses_GridTemplateAreas_$ctor_Z207A3CFB(property) {
    return new GridClasses_GridTemplateAreas(property);
}

export function GridClasses_GridTemplateAreas__value_1334CEF1(this$, values) {
    let values_1;
    const v = join(" ", values);
    values_1 = (`"${v}"`);
    const tupledArg = [this$.property_2, new String$(0, values_1)];
    return [tupledArg[0], tupledArg[1]];
}

export function GridClasses_GridTemplateAreas__value_Z7F4D45E5(this$, values) {
    const values_1 = fold((acc, x_1) => (`${acc} "${x_1}"`), "", map((x) => join(" ", x), values));
    const tupledArg = [this$.property_2, new String$(0, values_1)];
    return [tupledArg[0], tupledArg[1]];
}

//# sourceMappingURL=Grid.fs.js.map
