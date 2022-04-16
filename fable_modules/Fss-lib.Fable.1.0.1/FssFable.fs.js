import { addToSet } from "../fable-library.3.7.9/MapUtil.js";
import { createAnimation, createFontFace, createFontFaces, createCounterStyle, createGlobal, createFss } from "../Fss-lib.Core.1.0.2/Functions.fs.js";
import { join } from "../fable-library.3.7.9/String.js";
import { map } from "../fable-library.3.7.9/List.js";

function processCssRule(name, rule) {
    return `${name} ${rule}`;
}

const styleCache = new Set([]);

function injectCss(className, css) {
    if (styleCache.has(className)) {
    }
    else {
        const head = document.getElementsByTagName("head")[0];
        const style = document.createElement("style");
        style.setAttribute("type", "text/css");
        style.appendChild(document.createTextNode(css));
        head.appendChild(style);
        addToSet(className, styleCache);
    }
}

export function fss(properties) {
    const patternInput = createFss(properties);
    const cssRules = patternInput[1];
    const className = patternInput[0];
    injectCss(className, join("", map((tupledArg) => processCssRule(tupledArg[0], tupledArg[1]), cssRules)));
    return className;
}

export function global$0027(properties) {
    const cssRules = createGlobal(properties);
    injectCss("*", join("", map((tupledArg) => processCssRule(tupledArg[0], tupledArg[1]), cssRules)));
}

function processCounterRules(name, rules) {
    return `@counter-style ${name} ${rules}`;
}

export function counterStyle(properties) {
    const patternInput = createCounterStyle(properties);
    const counterStyle_1 = patternInput[1];
    const counterName = patternInput[0];
    injectCss(counterName, processCounterRules(counterName, counterStyle_1));
    return counterName;
}

function processFontFaceRules(rules) {
    return `@font-face ${rules}`;
}

export function fontFaces(name, properties) {
    const patternInput = createFontFaces(name, properties);
    const fontStyles = patternInput[1];
    const fontName = patternInput[0];
    injectCss(fontName, processFontFaceRules(fontStyles));
    return fontName;
}

export function fontFace(name, properties) {
    const patternInput = createFontFace(name, properties);
    const fontStyles = patternInput[1];
    const fontName = patternInput[0];
    injectCss(fontName, processFontFaceRules(fontStyles));
    return fontName;
}

function processAnimationRules(name, rules) {
    return `@keyframes ${name} ${rules}`;
}

export function keyframes(properties) {
    const patternInput = createAnimation(properties);
    const animationStyles = patternInput[1];
    const animationName = patternInput[0];
    injectCss(animationName, processAnimationRules(animationName, animationStyles));
    return animationName;
}

//# sourceMappingURL=FssFable.fs.js.map
