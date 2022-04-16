import { compare } from "./Util.js";
import { unfold, delay } from "./Seq.js";
import { op_Addition, fromZero } from "./BigInt.js";
import { op_Addition as op_Addition_1, fromParts } from "./Decimal.js";
import { op_Addition as op_Addition_2, fromBits } from "./Long.js";

export function makeRangeStepFunction(step, stop, zero, add) {
    const stepComparedWithZero = compare(step, zero) | 0;
    if (stepComparedWithZero === 0) {
        throw (new Error("The step of a range cannot be zero"));
    }
    const stepGreaterThanZero = stepComparedWithZero > 0;
    return (x) => {
        const comparedWithLast = compare(x, stop) | 0;
        return ((stepGreaterThanZero && (comparedWithLast <= 0)) ? true : ((!stepGreaterThanZero) && (comparedWithLast >= 0))) ? [x, add(x, step)] : (void 0);
    };
}

export function integralRangeStep(start, step, stop, zero, add) {
    const stepFn = makeRangeStepFunction(step, stop, zero, add);
    return delay(() => unfold(stepFn, start));
}

export function rangeBigInt(start, step, stop) {
    return integralRangeStep(start, step, stop, fromZero(), op_Addition);
}

export function rangeDecimal(start, step, stop) {
    return integralRangeStep(start, step, stop, fromParts(0, 0, 0, false, 0), op_Addition_1);
}

export function rangeDouble(start, step, stop) {
    return integralRangeStep(start, step, stop, 0, (x, y) => (x + y));
}

export function rangeInt64(start, step, stop) {
    return integralRangeStep(start, step, stop, fromBits(0, 0, false), op_Addition_2);
}

export function rangeUInt64(start, step, stop) {
    return integralRangeStep(start, step, stop, fromBits(0, 0, true), op_Addition_2);
}

export function rangeChar(start, stop) {
    const intStop = stop.charCodeAt(0) | 0;
    return delay(() => unfold((c) => {
        if (c <= intStop) {
            return [String.fromCharCode(c), c + 1];
        }
        else {
            return void 0;
        }
    }, start.charCodeAt(0)));
}

