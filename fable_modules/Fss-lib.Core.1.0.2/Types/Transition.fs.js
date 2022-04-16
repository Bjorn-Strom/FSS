import { Property_FontFaceProperty, Property_CssProperty, CssRule$reflection, CssRule } from "./MasterTypes.fs.js";
import { class_type } from "../../fable-library.3.7.9/Reflection.js";
import { AnimationClasses_AnimationTimingFunction$reflection, AnimationClasses_AnimationTimingFunction } from "./Animation.fs.js";

export class TransitionClass extends CssRule {
    constructor(property) {
        super(property);
    }
}

export function TransitionClass$reflection() {
    return class_type("Fss.Types.TransitionClasses.TransitionClass", void 0, TransitionClass, CssRule$reflection());
}

export function TransitionClass_$ctor_Z207A3CFB(property) {
    return new TransitionClass(property);
}

export class TransitionDelay extends CssRule {
    constructor(property) {
        super(property);
        this.property_1 = property;
    }
}

export function TransitionDelay$reflection() {
    return class_type("Fss.Types.TransitionClasses.TransitionDelay", void 0, TransitionDelay, CssRule$reflection());
}

export function TransitionDelay_$ctor_Z207A3CFB(property) {
    return new TransitionDelay(property);
}

export function TransitionDelay__value_74CCD5DD(this$, time) {
    const tupledArg = [this$.property_1, time];
    return [tupledArg[0], tupledArg[1]];
}

export class TransitionDuration extends CssRule {
    constructor(property) {
        super(property);
        this.property_1 = property;
    }
}

export function TransitionDuration$reflection() {
    return class_type("Fss.Types.TransitionClasses.TransitionDuration", void 0, TransitionDuration, CssRule$reflection());
}

export function TransitionDuration_$ctor_Z207A3CFB(property) {
    return new TransitionDuration(property);
}

export function TransitionDuration__value_74CCD5DD(this$, time) {
    const tupledArg = [this$.property_1, time];
    return [tupledArg[0], tupledArg[1]];
}

export class TransitionTimingFunction extends AnimationClasses_AnimationTimingFunction {
    constructor(property) {
        super(property);
    }
}

export function TransitionTimingFunction$reflection() {
    return class_type("Fss.Types.TransitionClasses.TransitionTimingFunction", void 0, TransitionTimingFunction, AnimationClasses_AnimationTimingFunction$reflection());
}

export function TransitionTimingFunction_$ctor_Z207A3CFB(property) {
    return new TransitionTimingFunction(property);
}

export class TransitionProperty extends CssRule {
    constructor(property) {
        super(property);
        this.property_1 = property;
    }
}

export function TransitionProperty$reflection() {
    return class_type("Fss.Types.TransitionClasses.TransitionProperty", void 0, TransitionProperty, CssRule$reflection());
}

export function TransitionProperty_$ctor_Z207A3CFB(property) {
    return new TransitionProperty(property);
}

export function TransitionProperty__get_appearance(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(0)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_alignContent(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(1)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_alignItems(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(2)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_alignSelf(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(3)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_all(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(4)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_animationDelay(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(5)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_animationDirection(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(6)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_animationDuration(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(7)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_animationFillMode(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(8)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_animationIterationCount(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(9)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_animationName(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(10)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_animationPlayState(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(11)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_animationTimingFunction(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(12)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_aspectRatio(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(13)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_backfaceVisibility(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(14)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_backgroundAttachment(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(15)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_backgroundBlendMode(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(16)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_backgroundClip(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(17)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_backgroundColor(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(18)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_backgroundImage(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(19)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_backgroundOrigin(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(20)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_backgroundPosition(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(21)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_backgroundRepeat(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(22)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_backgroundSize(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(23)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_backdropFilter(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(24)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_bleed(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(25)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_border(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(26)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_borderBottomColor(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(27)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_borderBottomLeftRadius(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(28)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_borderBottomRightRadius(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(29)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_borderBottomStyle(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(30)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_borderBottomWidth(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(31)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_borderBottom(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(32)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_borderCollapse(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(33)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_borderColor(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(34)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_borderImage(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(35)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_borderImageOutset(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(36)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_borderImageRepeat(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(37)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_borderImageSource(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(38)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_borderImageSlice(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(39)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_borderImageWidth(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(40)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_borderLeftColor(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(41)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_borderLeftStyle(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(42)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_borderLeftWidth(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(43)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_borderLeft(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(44)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_borderRadius(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(45)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_borderRightColor(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(46)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_borderRightStyle(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(47)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_borderRightWidth(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(48)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_borderRight(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(49)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_borderSpacing(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(50)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_borderStyle(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(51)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_borderTopColor(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(52)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_borderTopLeftRadius(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(53)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_borderTopRightRadius(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(54)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_borderTopStyle(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(55)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_borderTopWidth(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(56)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_borderTop(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(57)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_borderWidth(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(58)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_borderBlockColor(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(59)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_bottom(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(60)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_boxDecorationBreak(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(61)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_boxShadow(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(62)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_boxSizing(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(63)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_breakAfter(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(64)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_breakBefore(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(65)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_breakInside(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(66)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_captionSide(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(67)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_caretColor(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(68)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_clear(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(69)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_clip(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(70)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_clipPath(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(71)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_color(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(72)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_colorAdjust(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(73)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_columns(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(74)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_columnCount(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(75)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_columnFill(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(76)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_columnGap(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(77)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_columnRule(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(78)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_columnRuleColor(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(79)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_columnRuleStyle(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(80)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_columnRuleWidth(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(81)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_columnSpan(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(82)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_columnWidth(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(83)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_content(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(84)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_counterIncrement(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(85)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_counterReset(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(86)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_cueAfter(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(88)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_cueBefore(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(89)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_cue(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(90)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_cursor(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(91)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_direction(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(92)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_display(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(93)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_elevation(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(94)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_emptyCells(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(95)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_filter(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(96)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_flex(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(97)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_flexBasis(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(98)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_flexDirection(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(99)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_fontFeatureSettings(this$) {
    const tupledArg = [this$.property_1, new Property_FontFaceProperty(8)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_fontVariationSettings(this$) {
    const tupledArg = [this$.property_1, new Property_FontFaceProperty(9)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_flexFlow(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(102)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_flexGrow(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(103)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_flexShrink(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(104)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_flexWrap(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(105)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_float(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(106)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_fontFamily(this$) {
    const tupledArg = [this$.property_1, new Property_FontFaceProperty(3)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_fontKerning(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(108)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_fontLanguageOverride(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(109)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_fontSizeAdjust(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(110)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_fontSize(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(111)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_fontStretch(this$) {
    const tupledArg = [this$.property_1, new Property_FontFaceProperty(4)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_fontStyle(this$) {
    const tupledArg = [this$.property_1, new Property_FontFaceProperty(5)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_fontDisplay(this$) {
    const tupledArg = [this$.property_1, new Property_FontFaceProperty(2)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_fontSynthesis(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(115)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_fontVariant(this$) {
    const tupledArg = [this$.property_1, new Property_FontFaceProperty(7)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_fontVariantAlternates(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(117)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_fontVariantCaps(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(118)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_fontVariantEastAsian(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(119)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_fontVariantLigatures(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(120)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_fontVariantNumeric(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(121)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_fontVariantPosition(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(122)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_fontWeight(this$) {
    const tupledArg = [this$.property_1, new Property_FontFaceProperty(6)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_font(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(124)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_gridArea(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(125)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_gridAutoColumns(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(126)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_gridAutoFlow(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(127)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_gridAutoRows(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(128)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_gridColumnEnd(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(129)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_gridColumnStart(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(130)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_gridColumn(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(131)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_gridGap(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(132)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_gridRowEnd(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(133)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_gridRowGap(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(134)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_gridColumnGap(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(135)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_gridRowStart(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(136)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_gridRow(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(137)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_gridTemplateAreas(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(138)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_gridTemplateColumns(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(139)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_gridTemplateRows(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(140)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_gridTemplate(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(141)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_grid(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(142)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_hangingPunctuation(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(143)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_height(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(144)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_hyphens(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(145)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_isolation(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(146)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_imageRendering(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(147)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_justifyContent(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(148)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_justifyItems(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(149)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_justifySelf(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(150)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_label(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(378)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_left(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(151)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_letterSpacing(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(152)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_lineBreak(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(153)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_lineHeight(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(154)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_listStyle(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(155)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_listStyleImage(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(156)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_listStylePosition(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(157)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_listStyleType(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(158)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_lineGapOverride(this$) {
    const tupledArg = [this$.property_1, new Property_FontFaceProperty(10)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_maskClip(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(160)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_maskComposite(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(161)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_maskImage(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(162)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_maskMode(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(163)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_maskOrigin(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(164)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_maskPosition(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(165)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_maskRepeat(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(166)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_maskSize(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(167)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_marginBottom(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(168)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_marginLeft(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(169)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_marginRight(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(170)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_marginTop(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(171)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_margin(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(172)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_marginInlineStart(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(173)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_marginInlineEnd(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(174)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_marginBlockStart(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(175)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_marginBlockEnd(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(176)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_markerOffset(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(177)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_marks(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(178)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_maxHeight(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(179)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_maxWidth(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(180)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_minHeight(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(181)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_minWidth(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(182)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_mixBlendMode(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(183)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_navUp(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(184)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_navDown(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(185)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_navLeft(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(186)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_navRight(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(187)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_opacity(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(188)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_order(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(189)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_orphans(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(190)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_outlineColor(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(191)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_outlineOffset(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(192)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_outlineStyle(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(193)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_outlineWidth(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(194)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_outline(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(195)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_overflow(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(196)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_overflowWrap(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(197)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_overflowX(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(198)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_overflowY(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(199)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_objectFit(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(200)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_objectPosition(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(201)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_paddingBottom(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(202)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_paddingLeft(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(203)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_paddingRight(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(204)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_paddingTop(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(205)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_padding(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(206)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_paddingInlineStart(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(207)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_paddingInlineEnd(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(208)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_paddingBlockStart(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(209)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_paddingBlockEnd(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(210)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_page(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(211)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_pauseAfter(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(212)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_pauseBefore(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(213)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_pause(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(214)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_paintOrder(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(215)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_pointerEvents(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(216)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_perspective(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(217)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_perspectiveOrigin(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(218)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_pitchRange(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(219)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_pitch(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(220)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_placeContent(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(221)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_placeItems(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(222)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_placeSelf(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(223)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_playDuring(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(224)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_position(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(225)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_Quotes(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(226)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_resize(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(227)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_restAfter(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(228)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_restBefore(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(229)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_rest(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(230)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_richness(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(231)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_right(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(232)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_size(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(233)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_speakHeader(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(234)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_speakNumeral(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(235)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_speakPunctuation(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(236)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_src(this$) {
    const tupledArg = [this$.property_1, new Property_FontFaceProperty(12)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_speak(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(238)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_speechRate(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(239)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_stress(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(240)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_scrollBehavior(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(241)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_scrollMarginBottom(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(242)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_scrollMarginLeft(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(243)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_scrollMarginRight(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(244)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_scrollMarginTop(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(245)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_scrollMargin(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(246)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_scrollPaddingBottom(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(247)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_scrollPaddingLeft(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(248)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_scrollPaddingRight(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(249)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_scrollPaddingTop(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(250)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_scrollPadding(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(251)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_scrollSnapType(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(252)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_scrollSnapAlign(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(253)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_scrollSnapStop(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(254)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_sizeAdjust(this$) {
    const tupledArg = [this$.property_1, new Property_FontFaceProperty(11)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_overscrollBehaviorX(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(256)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_overscrollBehaviorY(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(257)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_tabSize(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(258)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_tableLayout(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(259)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_textAlign(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(260)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_textAlignLast(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(261)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_textDecoration(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(262)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_textDecorationColor(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(263)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_textDecorationLine(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(264)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_textDecorationThickness(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(265)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_textDecorationSkip(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(266)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_textDecorationSkipInk(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(267)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_textDecorationStyle(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(268)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_textIndent(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(269)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_textOverflow(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(270)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_textShadow(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(271)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_textTransform(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(272)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_textEmphasis(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(273)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_textEmphasisColor(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(274)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_textEmphasisPosition(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(275)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_textEmphasisStyle(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(276)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_textUnderlineOffset(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(277)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_textUnderlinePosition(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(278)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_textSizeAdjust(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(279)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_textOrientation(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(280)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_textRendering(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(281)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_textJustify(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(282)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_top(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(283)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_transform(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(284)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_transformOrigin(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(285)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_transformStyle(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(286)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_transition(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(287)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_transitionDelay(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(288)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_transitionDuration(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(289)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_transitionProperty(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(290)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_transitionTimingFunction(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(291)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_unicodeBidi(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(292)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_unicodeRange(this$) {
    const tupledArg = [this$.property_1, new Property_FontFaceProperty(13)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_userSelect(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(294)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_verticalAlign(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(295)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_visibility(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(296)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_voiceBalance(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(297)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_voiceDuration(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(298)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_voiceFamily(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(299)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_voicePitch(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(300)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_voiceRange(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(301)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_voiceRate(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(302)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_voiceStress(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(303)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_voiceVolume(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(304)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_volume(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(305)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_whiteSpace(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(306)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_widows(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(307)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_width(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(308)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_willChange(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(309)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_wordBreak(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(310)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_wordSpacing(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(311)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_wordWrap(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(312)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_writingMode(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(313)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_zIndex(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(314)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_active(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(315)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_anyLink(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(316)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_blank(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(317)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_checked(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(318)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_current(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(319)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_disabled(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(320)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_empty(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(321)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_enabled(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(322)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_firstChild(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(323)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_firstOfType(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(324)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_focus(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(325)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_focusVisible(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(326)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_focusWithin(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(327)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_future(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(328)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_hover(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(329)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_indeterminate(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(330)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_invalid(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(331)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_inRange(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(332)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__lang_Z721C83C5(this$, language) {
    const tupledArg = [this$.property_1, new Property_CssProperty(333, language)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_lastChild(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(334)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_lastOfType(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(335)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_link(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(336)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_localLink(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(337)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__nthChild_Z721C83C5(this$, nth) {
    const tupledArg = [this$.property_1, new Property_CssProperty(338, nth)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__nthLastChild_Z721C83C5(this$, nth) {
    const tupledArg = [this$.property_1, new Property_CssProperty(339, nth)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__nthLastOfType_Z721C83C5(this$, nth) {
    const tupledArg = [this$.property_1, new Property_CssProperty(340, nth)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__nthOfType_Z721C83C5(this$, nth) {
    const tupledArg = [this$.property_1, new Property_CssProperty(341, nth)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_onlyChild(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(342)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_onlyOfType(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(343)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_optional(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(344)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_outOfRange(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(345)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_past(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(346)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_playing(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(347)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_paused(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(348)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_placeholderShown(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(349)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_readOnly(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(350)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_readWrite(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(351)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_required(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(352)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_root(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(353)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_scope(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(354)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_target(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(355)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_targetWithin(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(356)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_valid(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(357)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_visited(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(358)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_userInvalid(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(359)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_after(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(360)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_before(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(361)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_firstLetter(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(362)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_firstLine(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(363)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_selection(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(364)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_alignmentBaseline(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(366)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_baselineShift(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(367)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_dominantBaseline(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(368)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_textAnchor(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(369)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_clipRule(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(370)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_floodColor(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(371)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_floodOpacity(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(372)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_lightingColor(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(373)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_stopColor(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(374)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_stopOpacity(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(375)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_colorInterpolation(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(376)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_colorInterpolationFilters(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(377)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_fill(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(379)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_fillOpacity(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(380)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_fillRule(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(381)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_shapeRendering(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(382)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_stroke(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(383)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_strokeOpacity(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(384)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_strokeDasharray(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(385)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_strokeDashoffset(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(386)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_strokeLinecap(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(387)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_strokeLinejoin(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(388)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_strokeMiterlimit(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(389)];
    return [tupledArg[0], tupledArg[1]];
}

export function TransitionProperty__get_strokeWidth(this$) {
    const tupledArg = [this$.property_1, new Property_CssProperty(390)];
    return [tupledArg[0], tupledArg[1]];
}

//# sourceMappingURL=Transition.fs.js.map
