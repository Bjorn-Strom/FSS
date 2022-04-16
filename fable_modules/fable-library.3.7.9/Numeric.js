export const symbol = Symbol("numeric");
export function isNumeric(x) {
    return typeof x === "number" || (x === null || x === void 0 ? void 0 : x[symbol]);
}
export function compare(x, y) {
    if (typeof x === "number") {
        return x < y ? -1 : (x > y ? 1 : 0);
    }
    else {
        return x.CompareTo(y);
    }
}
export function multiply(x, y) {
    if (typeof x === "number") {
        return x * y;
    }
    else {
        return x[symbol]().multiply(y);
    }
}
export function toFixed(x, dp) {
    if (typeof x === "number") {
        return x.toFixed(dp);
    }
    else {
        return x[symbol]().toFixed(dp);
    }
}
export function toPrecision(x, sd) {
    if (typeof x === "number") {
        return x.toPrecision(sd);
    }
    else {
        return x[symbol]().toPrecision(sd);
    }
}
export function toExponential(x, dp) {
    if (typeof x === "number") {
        return x.toExponential(dp);
    }
    else {
        return x[symbol]().toExponential(dp);
    }
}
export function toHex(x) {
    if (typeof x === "number") {
        return (Number(x) >>> 0).toString(16);
    }
    else {
        return x[symbol]().toHex();
    }
}
