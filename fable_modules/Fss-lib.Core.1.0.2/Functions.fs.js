import { ImportantMaster, MasterTypeHelpers_stringifyICounterValue, CombinatorMaster__Unwrap, MasterTypeHelpers_stringifyICssValue, NameLabel, CombinatorMaster, Pseudo } from "./Types/MasterTypes.fs.js";
import { Media_MediaQuery } from "./Types/Media.fs.js";
import { toList } from "../fable-library.3.7.9/Seq.js";
import { printf, toText, join, split } from "../fable-library.3.7.9/String.js";
import { fold, append, reverse, tryHead, collect, singleton, filter, map, head, tail, isEmpty } from "../fable-library.3.7.9/List.js";
import { seqToString, toString } from "../fable-library.3.7.9/Types.js";
import { FNV_1A_hash } from "./Utilities.fs.js";
import { FontFaceClasses_FontFamily__string_Z721C83C5 } from "./Types/FontFace.fs.js";
import { FontFamily } from "./css/FontFace.fs.js";
import { colorHelpers_hex, Color_Color } from "./Types/Color.fs.js";
import { Fraction, Time, Percent, Angle, Length } from "./Types/Units.fs.js";
import { Font_SettingSwitch } from "./Types/Font.fs.js";

function isSecondary(_arg1, value) {
    if (value instanceof Pseudo) {
        return true;
    }
    else if (value instanceof CombinatorMaster) {
        return true;
    }
    else if (value instanceof Media_MediaQuery) {
        return true;
    }
    else {
        return false;
    }
}

function isCombinator(_arg2, value) {
    if (value instanceof CombinatorMaster) {
        return true;
    }
    else {
        return false;
    }
}

function isMedia(_arg3, value) {
    if (value instanceof Media_MediaQuery) {
        return true;
    }
    else {
        return false;
    }
}

function isPseudo(_arg4, value) {
    if (value instanceof Pseudo) {
        return true;
    }
    else {
        return false;
    }
}

function isLabel(_arg5, value) {
    if (value instanceof NameLabel) {
        return true;
    }
    else {
        return false;
    }
}

function isCounterLabel(_arg6, value) {
    if (value instanceof NameLabel) {
        return true;
    }
    else {
        return false;
    }
}

function addBrackets(string) {
    return `{ ${string} }`;
}

function addClassName(className, css, value) {
    if (css.indexOf("@media") >= 0) {
        const patternInput = toList(split(css, ["@"], null, 0));
        let pattern_matching_result, css_1, name;
        if (!isEmpty(patternInput)) {
            if (!isEmpty(tail(patternInput))) {
                pattern_matching_result = 0;
                css_1 = head(tail(patternInput));
                name = head(patternInput);
            }
            else {
                pattern_matching_result = 1;
            }
        }
        else {
            pattern_matching_result = 1;
        }
        switch (pattern_matching_result) {
            case 0: {
                return [`@${css_1}`, `{ ${className}${name} ${value.slice(1, value.length).trim()}`];
            }
            case 1: {
                throw (new Error("Match failure: Microsoft.FSharp.Collections.FSharpList`1"));
            }
        }
    }
    else {
        return [`${className}${css}`, value];
    }
}

function createMainCssString(propertyName, propertyValue) {
    return [MasterTypeHelpers_stringifyICssValue(propertyName), `${MasterTypeHelpers_stringifyICssValue(propertyValue)}`];
}

function createMainCSS(properties) {
    let arg10;
    const cssStrings = map((tupledArg_1) => createMainCssString(tupledArg_1[0], tupledArg_1[1]), filter((arg) => {
        let tupledArg;
        return !((tupledArg = arg, isLabel(tupledArg[0], tupledArg[1])));
    }, properties));
    const cssString = addBrackets((arg10 = join(";", map((tupledArg_2) => {
        const n = tupledArg_2[0];
        const v = tupledArg_2[1];
        return `${n}: ${v}`;
    }, cssStrings)), toText(printf("%s;"))(arg10)));
    return `${cssString}`;
}

function createPseudoCssString(propertyName, propertyValue) {
    let p;
    const colons = (propertyValue instanceof Pseudo) ? ((p = propertyValue, (p.tag === 1) ? "::" : ":")) : "";
    return [`${colons}${MasterTypeHelpers_stringifyICssValue(propertyName)}`, `{ ${MasterTypeHelpers_stringifyICssValue(propertyValue)}; }`];
}

function createPseudoCss(properties) {
    return map((tupledArg_1) => {
        const name = tupledArg_1[0];
        const value = tupledArg_1[1];
        return [`${name}`, `${value}`];
    }, map((tupledArg) => createPseudoCssString(tupledArg[0], tupledArg[1]), properties));
}

function createMediaCssString(className, _arg7, propertyValue) {
    const stringifyMedia = (features, rules) => {
        const features_1 = join(" and ", map((x) => {
            let copyOfStruct;
            return `(${((copyOfStruct = x, toString(copyOfStruct)))})`;
        }, features));
        let css_1;
        const css = createFssInternal(className, rules)[1];
        css_1 = addBrackets(join("", map((tupledArg) => {
            const x_1 = tupledArg[0];
            const y = tupledArg[1];
            return `${x_1} ${y}`;
        }, css)));
        return [features_1, css_1];
    };
    if (propertyValue instanceof Media_MediaQuery) {
        const m = propertyValue;
        if (m.tag === 1) {
            const rules_2 = m.fields[2];
            const features_4 = m.fields[1];
            const device = m.fields[0];
            const device_1 = MasterTypeHelpers_stringifyICssValue(device);
            const patternInput_2 = stringifyMedia(features_4, rules_2);
            const featureString = patternInput_2[0];
            const css_3 = patternInput_2[1];
            const featureString_1 = (!isEmpty(features_4)) ? (`and ${featureString}`) : "";
            return [`@media ${device_1} ${featureString_1}`, css_3];
        }
        else {
            const rules_1 = m.fields[1];
            const features_2 = m.fields[0];
            const patternInput_1 = stringifyMedia(features_2, rules_1);
            const features_3 = patternInput_1[0];
            const css_2 = patternInput_1[1];
            return [`@media ${features_3}`, css_2];
        }
    }
    else {
        return ["", ""];
    }
}

export function createMediaCss(className, properties) {
    return map((m) => createMediaCssString(className, m[0], m[1]), properties);
}

function createCombinatorCssString(propertyName, propertyValue) {
    if (propertyValue instanceof CombinatorMaster) {
        const c = propertyValue;
        const css = createFssInternal("", CombinatorMaster__Unwrap(c))[1];
        return map((tupledArg) => {
            const x = tupledArg[0];
            const y = tupledArg[1];
            return [`${MasterTypeHelpers_stringifyICssValue(propertyName)}${x}`, y];
        }, css);
    }
    else {
        return singleton(["", ""]);
    }
}

function createCombinatorCss(properties) {
    return collect((m) => createCombinatorCssString(m[0], m[1]), properties);
}

function createFssInternal(name, properties) {
    const label = tryHead(reverse(map((tupledArg_1) => {
        const y = tupledArg_1[1];
        return y;
    }, filter((tupledArg) => isLabel(tupledArg[0], tupledArg[1]), properties))));
    let label_1;
    if (label == null) {
        label_1 = "";
    }
    else {
        const l = label;
        label_1 = (`-${MasterTypeHelpers_stringifyICssValue(l)}`);
    }
    let className;
    if (name != null) {
        const n = name;
        className = n;
    }
    else {
        className = (`.css${FNV_1A_hash(seqToString(properties))}${label_1}`);
    }
    const addClassName_1 = (cssPair) => addClassName(className, cssPair[0], cssPair[1]);
    const properties_1 = filter((arg) => {
        let tupledArg_2;
        return !((tupledArg_2 = arg, isLabel(tupledArg_2[0], tupledArg_2[1])));
    }, properties);
    const mainStyles = createMainCSS(filter((arg_1) => {
        let tupledArg_3;
        return !((tupledArg_3 = arg_1, isSecondary(tupledArg_3[0], tupledArg_3[1])));
    }, properties_1));
    const pseudoStyles = map(addClassName_1, createPseudoCss(filter((tupledArg_4) => isPseudo(tupledArg_4[0], tupledArg_4[1]), properties_1)));
    const mediaStyles = createMediaCss(className, filter((tupledArg_5) => isMedia(tupledArg_5[0], tupledArg_5[1]), properties_1));
    const combinatorStyles = map(addClassName_1, createCombinatorCss(filter((tupledArg_6) => isCombinator(tupledArg_6[0], tupledArg_6[1]), properties_1)));
    const newCss = filter((tupledArg_7) => {
        const v = tupledArg_7[1];
        return v !== "{ ; }";
    }, append(singleton([className, mainStyles]), append(pseudoStyles, append(mediaStyles, combinatorStyles))));
    return [className.slice(1, className.length), newCss];
}

export function createFss(properties) {
    return createFssInternal(void 0, properties);
}

export function createFssWithClassname(className, properties) {
    return createFssInternal(className, properties);
}

export function createGlobal(properties) {
    const css = createFssInternal("*", properties)[1];
    return css;
}

function stringifyCounterProperty(property_0, property_1) {
    const property = [property_0, property_1];
    const propertyValue = property[1];
    const propertyName = property[0];
    return `${MasterTypeHelpers_stringifyICssValue(propertyName)}: ${propertyValue.StringifyCounter()};`;
}

function createCounterStyleInternal(name, properties) {
    const label = tryHead(reverse(map((tupledArg_1) => {
        const y = tupledArg_1[1];
        return y;
    }, filter((tupledArg) => isCounterLabel(tupledArg[0], tupledArg[1]), properties))));
    const propertyString = join("", map((tupledArg_3) => stringifyCounterProperty(tupledArg_3[0], tupledArg_3[1]), filter((arg) => {
        let tupledArg_2;
        return !((tupledArg_2 = arg, isCounterLabel(tupledArg_2[0], tupledArg_2[1])));
    }, properties)));
    let label_1;
    if (label == null) {
        label_1 = "";
    }
    else {
        const l = label;
        label_1 = (`counter-${MasterTypeHelpers_stringifyICounterValue(l)}`);
    }
    let counterName;
    if (name != null) {
        const n = name;
        counterName = n;
    }
    else {
        counterName = (`counter${FNV_1A_hash(propertyString)}${label_1}`);
    }
    return [counterName, addBrackets(propertyString)];
}

export function createCounterStyle(properties) {
    return createCounterStyleInternal(void 0, properties);
}

export function createCounterStyleWithName(className, properties) {
    return createCounterStyleInternal(className, properties);
}

function stringifyFontFaceProperty(property_0, property_1) {
    const property = [property_0, property_1];
    const propertyValue = property[1];
    const propertyName = property[0];
    return `${MasterTypeHelpers_stringifyICssValue(propertyName)}: ${propertyValue.StringifyFontFace()};`;
}

export function createFontFace(name, properties) {
    const properties_1 = append(singleton(FontFaceClasses_FontFamily__string_Z721C83C5(FontFamily, name)), properties);
    const properties_2 = join("", map((tupledArg) => stringifyFontFaceProperty(tupledArg[0], tupledArg[1]), properties_1));
    return [name, addBrackets(properties_2)];
}

export function createFontFaces(name, properties) {
    const fontFace = map((ruleList) => createFontFace(name, ruleList), properties);
    const fontName = head(fontFace)[0];
    const fontFaceString = join("\n", map((tupledArg) => {
        const x = tupledArg[1];
        return x;
    }, fontFace));
    return [fontName, fontFaceString];
}

function createAnimationInternal(name, attributeList) {
    const framePositionToString = (frames) => join(",", map((n) => (`${n}%`), frames));
    const animationStyles = fold((acc, x) => {
        if (x.tag === 1) {
            const rules_2 = x.fields[1];
            const ns = x.fields[0];
            const rules_3 = head(createFss(rules_2)[1])[1];
            const frameNumbers = framePositionToString(ns);
            return `${acc} ${frameNumbers} ${rules_3}`;
        }
        else {
            const rules = x.fields[1];
            const n_1 = x.fields[0] | 0;
            const rules_1 = head(createFss(rules)[1])[1];
            return `${acc} ${n_1}% ${rules_1}`;
        }
    }, "", attributeList);
    if (name != null) {
        const name_1 = name;
        return [name_1, addBrackets(animationStyles)];
    }
    else {
        return [`animation-${FNV_1A_hash(animationStyles)}`, addBrackets(animationStyles)];
    }
}

export function createAnimation(attributeList) {
    return createAnimationInternal(void 0, attributeList);
}

export function createAnimationWithName(name, attributeList) {
    return createAnimationInternal(name, attributeList);
}

export function important(propertyName, propertyValue) {
    const tupledArg = [propertyName, new ImportantMaster(0, propertyValue)];
    return [tupledArg[0], tupledArg[1]];
}

export function combine(styles, stylesPred) {
    return join(" ", map((tuple_1) => tuple_1[0], filter((tuple) => tuple[1], append(map((s) => [s, true], styles), stylesPred))));
}

export function rgb(red, green, blue) {
    return new Color_Color(145, red, green, blue);
}

export function rgba(red, green, blue, alpha) {
    return new Color_Color(146, red, green, blue, alpha);
}

export function hex(value) {
    return colorHelpers_hex(value);
}

export function hsl(hue, saturation, lightness) {
    return new Color_Color(148, hue, saturation, lightness);
}

export function hsla(hue, saturation, lightness, alpha) {
    return new Color_Color(149, hue, saturation, lightness, alpha);
}

export function px(v) {
    return new Length(0, v);
}

export function inc(v) {
    return new Length(1, v);
}

export function cm(v) {
    return new Length(2, v);
}

export function mm(v) {
    return new Length(3, v);
}

export function pt(v) {
    return new Length(4, v);
}

export function pc(v) {
    return new Length(5, v);
}

export function em(v) {
    return new Length(6, v);
}

export function rem(v) {
    return new Length(7, v);
}

export function ex(v) {
    return new Length(8, v);
}

export function ch(v) {
    return new Length(9, v);
}

export function vw(v) {
    return new Length(10, v);
}

export function vh(v) {
    return new Length(11, v);
}

export function vmax(v) {
    return new Length(12, v);
}

export function vmin(v) {
    return new Length(13, v);
}

export function deg(v) {
    return new Angle(0, v);
}

export function grad(v) {
    return new Angle(1, v);
}

export function rad(v) {
    return new Angle(2, v);
}

export function turn(v) {
    return new Angle(3, v);
}

export function pct(v) {
    return new Percent(0, v);
}

export function sec(v) {
    return new Time(0, v);
}

export function ms(v) {
    return new Time(1, v);
}

export function fr(v) {
    return new Fraction(0, v);
}

export const On = new Font_SettingSwitch(0);

export const Off = new Font_SettingSwitch(1);

//# sourceMappingURL=Functions.fs.js.map
