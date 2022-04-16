import { BigInteger_op_Inequality_56F059C0, BigInteger_op_Equality_56F059C0, BigInteger_op_GreaterThanOrEqual_56F059C0, BigInteger_op_GreaterThan_56F059C0, BigInteger_op_LessThanOrEqual_56F059C0, BigInteger_op_LessThan_56F059C0, BigInteger_op_ExclusiveOr_56F059C0, BigInteger_op_BitwiseOr_56F059C0, BigInteger_op_BitwiseAnd_56F059C0, BigInteger_op_LeftShift_62E082A2, BigInteger_op_RightShift_62E082A2, BigInteger_op_UnaryPlus_Z665282C2, BigInteger_op_UnaryNegation_Z665282C2, BigInteger_op_Modulus_56F059C0, BigInteger_op_Division_56F059C0, BigInteger_op_Multiply_56F059C0, BigInteger_op_Subtraction_56F059C0, BigInteger_op_Addition_56F059C0, BigInteger__get_IsOne, BigInteger__get_IsZero, BigInteger__get_Sign, BigInteger__get_ToDecimal, BigInteger__get_ToDouble, BigInteger__get_ToSingle, BigInteger__get_ToUInt64, BigInteger__get_ToInt64, BigInteger__get_ToUInt32, BigInteger__get_ToInt32, BigInteger__get_ToUInt16, BigInteger__get_ToInt16, BigInteger__get_ToByte, BigInteger__get_ToSByte, BigInteger_$ctor_Z524259A4, BigInteger_$ctor_Z524259C1, BigInteger_get_Two, BigInteger_get_One, BigInteger_get_Zero, BigInteger_Abs_Z665282C2, BigInteger_Pow_62E082A2, BigInteger_GreatestCommonDivisor_56F059C0, BigInteger_DivRem_56F059C0, BigInteger_Parse_Z721C83C5, BigInteger } from "./BigInt/z.js";
import { fromInteger } from "./Long.js";
import { comparePrimitives, min, compare as compare_1, equals as equals_1, safeHash } from "./Util.js";
import { toString as toString_1 } from "./Types.js";
import { fold, empty, ofArrayWithTail, cons, toArray, head, skipWhile } from "./List.js";
import { fill, reverse } from "./Array.js";

export function isBigInt(x) {
    return x instanceof BigInteger;
}

export function tryParse(str, res) {
    try {
        res.contents = BigInteger_Parse_Z721C83C5(str);
        return true;
    }
    catch (matchValue) {
        return false;
    }
}

export function divRem(x, y, remainder) {
    const patternInput = BigInteger_DivRem_56F059C0(x, y);
    remainder.contents = patternInput[1];
    return patternInput[0];
}

export function parse(arg00) {
    return BigInteger_Parse_Z721C83C5(arg00);
}

export function greatestCommonDivisor(arg00, arg01) {
    return BigInteger_GreatestCommonDivisor_56F059C0(arg00, arg01);
}

export function pow(arg00, arg01) {
    return BigInteger_Pow_62E082A2(arg00, arg01);
}

export function abs(arg00) {
    return BigInteger_Abs_Z665282C2(arg00);
}

export const zero = BigInteger_get_Zero();

export const one = BigInteger_get_One();

export const two = BigInteger_get_Two();

export function fromString(s) {
    return BigInteger_Parse_Z721C83C5(s);
}

export function fromZero() {
    return BigInteger_get_Zero();
}

export function fromOne() {
    return BigInteger_get_One();
}

export function fromInt64(i) {
    return BigInteger_$ctor_Z524259C1(i);
}

export function fromInt32(i) {
    if (i > 2147483647) {
        return BigInteger_$ctor_Z524259C1(fromInteger(i, false, 6));
    }
    else {
        return BigInteger_$ctor_Z524259A4(i);
    }
}

export function toSByte(x) {
    return BigInteger__get_ToSByte(x);
}

export function toByte(x) {
    return BigInteger__get_ToByte(x);
}

export function toInt16(x) {
    return BigInteger__get_ToInt16(x);
}

export function toUInt16(x) {
    return BigInteger__get_ToUInt16(x);
}

export function toInt32(x) {
    return BigInteger__get_ToInt32(x);
}

export function toUInt32(x) {
    return BigInteger__get_ToUInt32(x);
}

export function toInt64(x) {
    return BigInteger__get_ToInt64(x);
}

export function toUInt64(x) {
    return BigInteger__get_ToUInt64(x);
}

export function toSingle(x) {
    return BigInteger__get_ToSingle(x);
}

export function toDouble(x) {
    return BigInteger__get_ToDouble(x);
}

export function toDecimal(x) {
    return BigInteger__get_ToDecimal(x);
}

export function sign(x) {
    return BigInteger__get_Sign(x);
}

export function isZero(x) {
    return BigInteger__get_IsZero(x);
}

export function isOne(x) {
    return BigInteger__get_IsOne(x);
}

export function hash(x) {
    return safeHash(x);
}

export function compare(x, y) {
    return x.CompareTo(y);
}

export function equals(x, y) {
    return equals_1(x, y);
}

export function toString(x) {
    return toString_1(x);
}

export const get_Zero = BigInteger_get_Zero();

export const get_One = BigInteger_get_One();

export function op_Addition(arg00, arg01) {
    return BigInteger_op_Addition_56F059C0(arg00, arg01);
}

export function op_Subtraction(arg00, arg01) {
    return BigInteger_op_Subtraction_56F059C0(arg00, arg01);
}

export function op_Multiply(arg00, arg01) {
    return BigInteger_op_Multiply_56F059C0(arg00, arg01);
}

export function op_Division(arg00, arg01) {
    return BigInteger_op_Division_56F059C0(arg00, arg01);
}

export function op_Modulus(arg00, arg01) {
    return BigInteger_op_Modulus_56F059C0(arg00, arg01);
}

export function op_UnaryNegation(arg00) {
    return BigInteger_op_UnaryNegation_Z665282C2(arg00);
}

export function op_UnaryPlus(arg00) {
    return BigInteger_op_UnaryPlus_Z665282C2(arg00);
}

export function op_RightShift(arg00, arg01) {
    return BigInteger_op_RightShift_62E082A2(arg00, arg01);
}

export function op_LeftShift(arg00, arg01) {
    return BigInteger_op_LeftShift_62E082A2(arg00, arg01);
}

export function op_BitwiseAnd(arg00, arg01) {
    return BigInteger_op_BitwiseAnd_56F059C0(arg00, arg01);
}

export function op_BitwiseOr(arg00, arg01) {
    return BigInteger_op_BitwiseOr_56F059C0(arg00, arg01);
}

export function op_ExclusiveOr(arg00, arg01) {
    return BigInteger_op_ExclusiveOr_56F059C0(arg00, arg01);
}

export function op_LessThan(arg00, arg01) {
    return BigInteger_op_LessThan_56F059C0(arg00, arg01);
}

export function op_LessThanOrEqual(arg00, arg01) {
    return BigInteger_op_LessThanOrEqual_56F059C0(arg00, arg01);
}

export function op_GreaterThan(arg00, arg01) {
    return BigInteger_op_GreaterThan_56F059C0(arg00, arg01);
}

export function op_GreaterThanOrEqual(arg00, arg01) {
    return BigInteger_op_GreaterThanOrEqual_56F059C0(arg00, arg01);
}

export function op_Equality(arg00, arg01) {
    return BigInteger_op_Equality_56F059C0(arg00, arg01);
}

export function op_Inequality(arg00, arg01) {
    return BigInteger_op_Inequality_56F059C0(arg00, arg01);
}

function flipTwosComplement(currByte, lowBitFound) {
    let array;
    const matchValue = [currByte, lowBitFound];
    if (matchValue[1]) {
        return [(currByte ^ 255) & 255, true];
    }
    else if (matchValue[0] === 0) {
        return [0, false];
    }
    else {
        return [(currByte ^ (254 << ((array = (new Int32Array([0, 1, 2, 3, 4, 5, 6, 7])), array.find((i) => ((currByte & (1 << i)) > 0)))))) & 255, true];
    }
}

export function toByteArray(value) {
    if (equals_1(value, zero)) {
        return new Uint8Array([0]);
    }
    else {
        const isPositive = compare_1(value, zero) > 0;
        const value_1 = isPositive ? value : BigInteger_op_Multiply_56F059C0(BigInteger_$ctor_Z524259A4(-1), value);
        const mask32 = fromInt64(fromInteger(4294967295, false, 6));
        const loop = (accumBytes_mut, consumeValue_mut, lowBitFound_mut) => {
            let value_6, value_8, value_9, value_10;
            loop:
            while (true) {
                const accumBytes = accumBytes_mut, consumeValue = consumeValue_mut, lowBitFound = lowBitFound_mut;
                if (compare_1(consumeValue, zero) <= 0) {
                    const accumBytes_1 = isPositive ? skipWhile((b) => (b === 0), accumBytes) : skipWhile((b_1) => (b_1 === 255), accumBytes);
                    const isHighBitOne = (head(accumBytes_1) & 128) !== 0;
                    return reverse(toArray((isPositive && isHighBitOne) ? cons(0, accumBytes_1) : (((!isPositive) && (!isHighBitOne)) ? cons(255, accumBytes_1) : accumBytes_1)));
                }
                else {
                    const currValue = toUInt32(BigInteger_op_BitwiseAnd_56F059C0(consumeValue, mask32));
                    if (isPositive) {
                        const b0 = currValue & 0xFF;
                        let b1;
                        const value_4 = currValue >>> 8;
                        b1 = (value_4 & 0xFF);
                        let b2;
                        const value_5 = currValue >>> 16;
                        b2 = (value_5 & 0xFF);
                        accumBytes_mut = ofArrayWithTail([(value_6 = (currValue >>> 24), value_6 & 0xFF), b2, b1, b0], accumBytes);
                        consumeValue_mut = BigInteger_op_RightShift_62E082A2(consumeValue, 32);
                        lowBitFound_mut = false;
                        continue loop;
                    }
                    else {
                        const patternInput = flipTwosComplement(currValue & 0xFF, lowBitFound);
                        const patternInput_1 = flipTwosComplement((value_8 = (currValue >>> 8), value_8 & 0xFF), patternInput[1]);
                        const patternInput_2 = flipTwosComplement((value_9 = (currValue >>> 16), value_9 & 0xFF), patternInput_1[1]);
                        const patternInput_3 = flipTwosComplement((value_10 = (currValue >>> 24), value_10 & 0xFF), patternInput_2[1]);
                        accumBytes_mut = ofArrayWithTail([patternInput_3[0], patternInput_2[0], patternInput_1[0], patternInput[0]], accumBytes);
                        consumeValue_mut = BigInteger_op_RightShift_62E082A2(consumeValue, 32);
                        lowBitFound_mut = patternInput_3[1];
                        continue loop;
                    }
                }
                break;
            }
        };
        return loop(empty(), value_1, false);
    }
}

export function fromByteArray(bytes) {
    if (bytes == null) {
        throw (new Error("bytes"));
    }
    if (bytes.length === 0) {
        return zero;
    }
    else {
        const isPositive = (bytes[bytes.length - 1] & 128) === 0;
        const buffer = fill(new Uint8Array(4), 0, 4, 0);
        const loop = (accumUInt32_mut, currIndex_mut, bytesRemaining_mut, lowBitFound_mut) => {
            loop:
            while (true) {
                const accumUInt32 = accumUInt32_mut, currIndex = currIndex_mut, bytesRemaining = bytesRemaining_mut, lowBitFound = lowBitFound_mut;
                if (bytesRemaining === 0) {
                    const value_2 = fold((acc, value) => BigInteger_op_Addition_56F059C0(BigInteger_op_LeftShift_62E082A2(acc, 32), fromInt64(fromInteger(value, false, 6))), zero, accumUInt32);
                    if (isPositive) {
                        return value_2;
                    }
                    else {
                        return BigInteger_op_Multiply_56F059C0(BigInteger_$ctor_Z524259A4(-1), value_2);
                    }
                }
                else {
                    const bytesToProcess = min(comparePrimitives, bytesRemaining, 4) | 0;
                    for (let i_1 = 0; i_1 <= (bytesToProcess - 1); i_1++) {
                        buffer[i_1] = bytes[currIndex + i_1];
                    }
                    if (isPositive) {
                        fill(buffer, bytesToProcess, 4 - bytesToProcess, 0);
                        accumUInt32_mut = cons((((((buffer[0] | ((buffer[1] << 8) >>> 0)) >>> 0) | ((buffer[2] << 16) >>> 0)) >>> 0) | ((buffer[3] << 24) >>> 0)) >>> 0, accumUInt32);
                        currIndex_mut = (currIndex + bytesToProcess);
                        bytesRemaining_mut = (bytesRemaining - bytesToProcess);
                        lowBitFound_mut = false;
                        continue loop;
                    }
                    else {
                        fill(buffer, bytesToProcess, 4 - bytesToProcess, 255);
                        const patternInput = flipTwosComplement(buffer[0], lowBitFound);
                        const patternInput_1 = flipTwosComplement(buffer[1], patternInput[1]);
                        const patternInput_2 = flipTwosComplement(buffer[2], patternInput_1[1]);
                        const patternInput_3 = flipTwosComplement(buffer[3], patternInput_2[1]);
                        accumUInt32_mut = cons((((((patternInput[0] | ((patternInput_1[0] << 8) >>> 0)) >>> 0) | ((patternInput_2[0] << 16) >>> 0)) >>> 0) | ((patternInput_3[0] << 24) >>> 0)) >>> 0, accumUInt32);
                        currIndex_mut = (currIndex + bytesToProcess);
                        bytesRemaining_mut = (bytesRemaining - bytesToProcess);
                        lowBitFound_mut = patternInput_3[1];
                        continue loop;
                    }
                }
                break;
            }
        };
        return loop(empty(), 0, bytes.length, false);
    }
}

