import { fold } from "../fable-library.3.7.9/Seq.js";
import { isUpper } from "../fable-library.3.7.9/Char.js";
import { printf, toText } from "../fable-library.3.7.9/String.js";
import { toString } from "../fable-library.3.7.9/Types.js";

export function Helpers_toLowerAndCombine(separator, value) {
    return fold((acc, element) => {
        if (isUpper(element) && (acc.length === 0)) {
            return acc + element.toLocaleLowerCase();
        }
        else if (isUpper(element) && (acc.length !== 0)) {
            const arg30 = element.toLocaleLowerCase();
            return toText(printf("%s%s%s"))(acc)(separator)(arg30);
        }
        else {
            return acc + element;
        }
    }, "", value.split(""));
}

export function Helpers_toKebabCase(x) {
    let copyOfStruct;
    return Helpers_toLowerAndCombine("-", (copyOfStruct = x, toString(copyOfStruct)));
}

export function Helpers_toSpacedCase(x) {
    let copyOfStruct;
    return Helpers_toLowerAndCombine(" ", (copyOfStruct = x, toString(copyOfStruct)));
}

const FNV_1A_prime = -2128831035;

export function FNV_1A_hash(string) {
    let hash = 0;
    for (let i = 0; i <= (string.length - 1); i++) {
        hash = ((hash ^ string[i].charCodeAt(0)) | 0);
        hash = ((hash * FNV_1A_prime) | 0);
    }
    return hash | 0;
}

//# sourceMappingURL=Utilities.fs.js.map
