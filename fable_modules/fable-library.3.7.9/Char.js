import * as Unicode from "./Unicode.13.0.0.js";
function getCategoryFunc() {
    // unpack Unicode codepoint ranges (delta encoded) and general categories
    const offset = 35; // offsets unprintable characters
    const a1 = [...Unicode.rangeDeltas].map((ch) => { var _a; return ((_a = ch.codePointAt(0)) !== null && _a !== void 0 ? _a : 0) - offset; });
    const a2 = [...Unicode.categories].map((ch) => { var _a; return ((_a = ch.codePointAt(0)) !== null && _a !== void 0 ? _a : 0) - offset; });
    const codepoints = new Uint32Array(a1);
    const categories = new Uint8Array(a2);
    for (let i = 1; i < codepoints.length; ++i) {
        codepoints[i] += codepoints[i - 1];
    }
    // binary search in unicode ranges
    return (cp) => {
        let hi = codepoints.length;
        let lo = 0;
        while (hi - lo > 1) {
            const mid = Math.floor((hi + lo) / 2);
            const test = codepoints[mid];
            if (cp < test) {
                hi = mid;
            }
            else if (cp === test) {
                hi = lo = mid;
                break;
            }
            else if (test < cp) {
                lo = mid;
            }
        }
        return categories[lo];
    };
}
const isControlMask = 1 << 14 /* Control */;
const isDigitMask = 1 << 8 /* DecimalDigitNumber */;
const isLetterMask = 0
    | 1 << 0 /* UppercaseLetter */
    | 1 << 1 /* LowercaseLetter */
    | 1 << 2 /* TitlecaseLetter */
    | 1 << 3 /* ModifierLetter */
    | 1 << 4 /* OtherLetter */;
const isLetterOrDigitMask = isLetterMask | isDigitMask;
const isUpperMask = 1 << 0 /* UppercaseLetter */;
const isLowerMask = 1 << 1 /* LowercaseLetter */;
const isNumberMask = 0
    | 1 << 8 /* DecimalDigitNumber */
    | 1 << 9 /* LetterNumber */
    | 1 << 10 /* OtherNumber */;
const isPunctuationMask = 0
    | 1 << 18 /* ConnectorPunctuation */
    | 1 << 19 /* DashPunctuation */
    | 1 << 20 /* OpenPunctuation */
    | 1 << 21 /* ClosePunctuation */
    | 1 << 22 /* InitialQuotePunctuation */
    | 1 << 23 /* FinalQuotePunctuation */
    | 1 << 24 /* OtherPunctuation */;
const isSeparatorMask = 0
    | 1 << 11 /* SpaceSeparator */
    | 1 << 12 /* LineSeparator */
    | 1 << 13 /* ParagraphSeparator */;
const isSymbolMask = 0
    | 1 << 25 /* MathSymbol */
    | 1 << 26 /* CurrencySymbol */
    | 1 << 27 /* ModifierSymbol */
    | 1 << 28 /* OtherSymbol */;
const isWhiteSpaceMask = 0
    | 1 << 11 /* SpaceSeparator */
    | 1 << 12 /* LineSeparator */
    | 1 << 13 /* ParagraphSeparator */;
const unicodeCategoryFunc = getCategoryFunc();
function charCodeAt(s, index) {
    if (index >= 0 && index < s.length) {
        return s.charCodeAt(index);
    }
    else {
        throw new Error("Index out of range.");
    }
}
export const getUnicodeCategory = (s) => getUnicodeCategory2(s, 0);
export const isControl = (s) => isControl2(s, 0);
export const isDigit = (s) => isDigit2(s, 0);
export const isLetter = (s) => isLetter2(s, 0);
export const isLetterOrDigit = (s) => isLetterOrDigit2(s, 0);
export const isUpper = (s) => isUpper2(s, 0);
export const isLower = (s) => isLower2(s, 0);
export const isNumber = (s) => isNumber2(s, 0);
export const isPunctuation = (s) => isPunctuation2(s, 0);
export const isSeparator = (s) => isSeparator2(s, 0);
export const isSymbol = (s) => isSymbol2(s, 0);
export const isWhiteSpace = (s) => isWhiteSpace2(s, 0);
export const isHighSurrogate = (s) => isHighSurrogate2(s, 0);
export const isLowSurrogate = (s) => isLowSurrogate2(s, 0);
export const isSurrogate = (s) => isSurrogate2(s, 0);
export function getUnicodeCategory2(s, index) {
    const cp = charCodeAt(s, index);
    return unicodeCategoryFunc(cp);
}
export function isControl2(s, index) {
    const test = 1 << getUnicodeCategory2(s, index);
    return (test & isControlMask) !== 0;
}
export function isDigit2(s, index) {
    const test = 1 << getUnicodeCategory2(s, index);
    return (test & isDigitMask) !== 0;
}
export function isLetter2(s, index) {
    const test = 1 << getUnicodeCategory2(s, index);
    return (test & isLetterMask) !== 0;
}
export function isLetterOrDigit2(s, index) {
    const test = 1 << getUnicodeCategory2(s, index);
    return (test & isLetterOrDigitMask) !== 0;
}
export function isUpper2(s, index) {
    const test = 1 << getUnicodeCategory2(s, index);
    return (test & isUpperMask) !== 0;
}
export function isLower2(s, index) {
    const test = 1 << getUnicodeCategory2(s, index);
    return (test & isLowerMask) !== 0;
}
export function isNumber2(s, index) {
    const test = 1 << getUnicodeCategory2(s, index);
    return (test & isNumberMask) !== 0;
}
export function isPunctuation2(s, index) {
    const test = 1 << getUnicodeCategory2(s, index);
    return (test & isPunctuationMask) !== 0;
}
export function isSeparator2(s, index) {
    const test = 1 << getUnicodeCategory2(s, index);
    return (test & isSeparatorMask) !== 0;
}
export function isSymbol2(s, index) {
    const test = 1 << getUnicodeCategory2(s, index);
    return (test & isSymbolMask) !== 0;
}
export function isWhiteSpace2(s, index) {
    const test = 1 << getUnicodeCategory2(s, index);
    if ((test & isWhiteSpaceMask) !== 0) {
        return true;
    }
    const cp = charCodeAt(s, index);
    return (0x09 <= cp && cp <= 0x0D) || cp === 0x85 || cp === 0xA0;
}
export function isHighSurrogate2(s, index) {
    const cp = charCodeAt(s, index);
    return (0xD800 <= cp && cp <= 0xDBFF);
}
export function isLowSurrogate2(s, index) {
    const cp = charCodeAt(s, index);
    return (0xDC00 <= cp && cp <= 0xDFFF);
}
export function isSurrogate2(s, index) {
    const cp = charCodeAt(s, index);
    return (0xD800 <= cp && cp <= 0xDFFF);
}
export function isSurrogatePair(s, index) {
    return typeof index === "number"
        ? isHighSurrogate2(s, index) && isLowSurrogate2(s, index + 1)
        : isHighSurrogate(s) && isLowSurrogate(index);
}
export function parse(input) {
    if (input.length === 1) {
        return input[0];
    }
    else {
        throw new Error("String must be exactly one character long.");
    }
}
