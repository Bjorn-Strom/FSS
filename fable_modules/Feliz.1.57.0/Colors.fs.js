
export function hsl(hue, saturation, lightness) {
    return ((((("hsl(" + hue) + ",") + saturation) + "%,") + lightness) + "%)";
}

export function rgb(r, g, b) {
    return ((((("rgb(" + r) + ",") + g) + ",") + b) + ")";
}

export function rgba(r, g, b, a) {
    return ((((((("rgba(" + r) + ",") + g) + ",") + b) + ",") + a) + ")";
}

//# sourceMappingURL=Colors.fs.js.map
