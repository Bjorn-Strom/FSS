import { BigNatModule_factorial, BigNatModule_ofString, BigNatModule_toFloat, BigNatModule_toUInt64, BigNatModule_toUInt32, BigNatModule_pow, BigNatModule_two, BigNatModule_rem, BigNatModule_lte, BigNatModule_hcf, BigNatModule_bitXor, BigNatModule_bitOr, BigNatModule_bitAnd, BigNatModule_divmod, BigNatModule_mul, BigNatModule_isOne, BigNatModule_sub, BigNatModule_gte, BigNatModule_scale, BigNatModule_one, BigNatModule_add, BigNatModule_ofInt64, BigNatModule_hash, BigNatModule_gt, BigNatModule_lt, BigNatModule_equal, BigNatModule_getSmall, BigNatModule_isSmall, BigNatModule_ofInt32, BigNatModule_toString, BigNatModule_isZero } from "./n.js";
import { Record, toString } from "../Types.js";
import { class_type } from "../Reflection.js";
import { initialize } from "../Array.js";
import { op_Addition, op_Multiply, fromValue, equals, fromBits, compare, fromInteger, op_UnaryNegation } from "../Long.js";
import { op_UnaryNegation_Int32 } from "../Int32.js";
import Decimal from "../Decimal.js";

export class BigInteger extends Record {
    constructor(signInt, v) {
        super();
        this.signInt = (signInt | 0);
        this.v = v;
    }
    toString() {
        const x = this;
        const matchValue = BigInteger__get_SignInt(x) | 0;
        switch (matchValue) {
            case -1: {
                return BigNatModule_isZero(BigInteger__get_V(x)) ? "0" : ("-" + BigNatModule_toString(BigInteger__get_V(x)));
            }
            case 0: {
                return "0";
            }
            case 1: {
                return BigNatModule_toString(BigInteger__get_V(x));
            }
            default: {
                throw (new Error("signs should be +/- 1 or 0"));
            }
        }
    }
    Equals(obj) {
        const this$ = this;
        return (obj instanceof BigInteger) && BigInteger_op_Equality_56F059C0(this$, obj);
    }
    GetHashCode() {
        const x = this;
        return BigInteger_hash_Z665282C2(x) | 0;
    }
    toJSON(_key) {
        const this$ = this;
        return toString(this$);
    }
    CompareTo(obj) {
        const this$ = this;
        if (obj instanceof BigInteger) {
            return BigInteger_compare_56F059C0(this$, obj) | 0;
        }
        else {
            throw (new Error("the objects are not comparable\\nParameter name: obj"));
        }
    }
}

export function BigInteger$reflection() {
    return class_type("BigInt.BigInteger", void 0, BigInteger, class_type("System.ValueType"));
}

export function BigInteger_$ctor_Z2BE94A1(signInt, v) {
    return new BigInteger(signInt, v);
}

(() => {
    BigInteger.smallLim = 4096;
    BigInteger.smallPosTab = initialize(BigInteger.smallLim, BigNatModule_ofInt32);
    BigInteger.one = BigInteger_$ctor_Z524259A4(1);
    BigInteger.two = BigInteger_$ctor_Z524259A4(2);
    BigInteger.zero = BigInteger_$ctor_Z524259A4(0);
})();

export function BigInteger_nat_Z67CCE57D(n) {
    if (BigNatModule_isSmall(n) && (BigNatModule_getSmall(n) < BigInteger.smallLim)) {
        return BigInteger.smallPosTab[BigNatModule_getSmall(n)];
    }
    else {
        return n;
    }
}

export function BigInteger_create_Z2BE94A1(s, n) {
    return BigInteger_$ctor_Z2BE94A1(s, BigInteger_nat_Z67CCE57D(n));
}

export function BigInteger_posn_Z67CCE57D(n) {
    return BigInteger_$ctor_Z2BE94A1(1, BigInteger_nat_Z67CCE57D(n));
}

export function BigInteger_negn_Z67CCE57D(n) {
    return BigInteger_$ctor_Z2BE94A1(-1, BigInteger_nat_Z67CCE57D(n));
}

export function BigInteger__get_Sign(x) {
    if (BigInteger__get_IsZero(x)) {
        return 0;
    }
    else {
        return x.signInt | 0;
    }
}

export function BigInteger__get_SignInt(x) {
    return x.signInt;
}

export function BigInteger__get_V(x) {
    return x.v;
}

export function BigInteger_op_Equality_56F059C0(x, y) {
    const matchValue = [BigInteger__get_SignInt(x), BigInteger__get_SignInt(y)];
    let pattern_matching_result;
    if (matchValue[0] === -1) {
        if (matchValue[1] === -1) {
            pattern_matching_result = 1;
        }
        else if (matchValue[1] === 0) {
            pattern_matching_result = 8;
        }
        else if (matchValue[1] === 1) {
            pattern_matching_result = 3;
        }
        else {
            pattern_matching_result = 9;
        }
    }
    else if (matchValue[0] === 0) {
        if (matchValue[1] === -1) {
            pattern_matching_result = 6;
        }
        else if (matchValue[1] === 0) {
            pattern_matching_result = 4;
        }
        else if (matchValue[1] === 1) {
            pattern_matching_result = 5;
        }
        else {
            pattern_matching_result = 9;
        }
    }
    else if (matchValue[0] === 1) {
        if (matchValue[1] === -1) {
            pattern_matching_result = 2;
        }
        else if (matchValue[1] === 0) {
            pattern_matching_result = 7;
        }
        else if (matchValue[1] === 1) {
            pattern_matching_result = 0;
        }
        else {
            pattern_matching_result = 9;
        }
    }
    else {
        pattern_matching_result = 9;
    }
    switch (pattern_matching_result) {
        case 0: {
            return BigNatModule_equal(BigInteger__get_V(x), BigInteger__get_V(y));
        }
        case 1: {
            return BigNatModule_equal(BigInteger__get_V(x), BigInteger__get_V(y));
        }
        case 2: {
            if (BigNatModule_isZero(BigInteger__get_V(x))) {
                return BigNatModule_isZero(BigInteger__get_V(y));
            }
            else {
                return false;
            }
        }
        case 3: {
            if (BigNatModule_isZero(BigInteger__get_V(x))) {
                return BigNatModule_isZero(BigInteger__get_V(y));
            }
            else {
                return false;
            }
        }
        case 4: {
            return true;
        }
        case 5: {
            return BigNatModule_isZero(BigInteger__get_V(y));
        }
        case 6: {
            return BigNatModule_isZero(BigInteger__get_V(y));
        }
        case 7: {
            return BigNatModule_isZero(BigInteger__get_V(x));
        }
        case 8: {
            return BigNatModule_isZero(BigInteger__get_V(x));
        }
        case 9: {
            throw (new Error("signs should be +/- 1 or 0\\nParameter name: x"));
        }
    }
}

export function BigInteger_op_Inequality_56F059C0(x, y) {
    return !BigInteger_op_Equality_56F059C0(x, y);
}

export function BigInteger_op_LessThan_56F059C0(x, y) {
    const matchValue = [BigInteger__get_SignInt(x), BigInteger__get_SignInt(y)];
    let pattern_matching_result;
    if (matchValue[0] === -1) {
        if (matchValue[1] === -1) {
            pattern_matching_result = 1;
        }
        else if (matchValue[1] === 0) {
            pattern_matching_result = 8;
        }
        else if (matchValue[1] === 1) {
            pattern_matching_result = 3;
        }
        else {
            pattern_matching_result = 9;
        }
    }
    else if (matchValue[0] === 0) {
        if (matchValue[1] === -1) {
            pattern_matching_result = 6;
        }
        else if (matchValue[1] === 0) {
            pattern_matching_result = 4;
        }
        else if (matchValue[1] === 1) {
            pattern_matching_result = 5;
        }
        else {
            pattern_matching_result = 9;
        }
    }
    else if (matchValue[0] === 1) {
        if (matchValue[1] === -1) {
            pattern_matching_result = 2;
        }
        else if (matchValue[1] === 0) {
            pattern_matching_result = 7;
        }
        else if (matchValue[1] === 1) {
            pattern_matching_result = 0;
        }
        else {
            pattern_matching_result = 9;
        }
    }
    else {
        pattern_matching_result = 9;
    }
    switch (pattern_matching_result) {
        case 0: {
            return BigNatModule_lt(BigInteger__get_V(x), BigInteger__get_V(y));
        }
        case 1: {
            return BigNatModule_lt(BigInteger__get_V(y), BigInteger__get_V(x));
        }
        case 2: {
            return false;
        }
        case 3: {
            if (!BigNatModule_isZero(BigInteger__get_V(x))) {
                return true;
            }
            else {
                return !BigNatModule_isZero(BigInteger__get_V(y));
            }
        }
        case 4: {
            return false;
        }
        case 5: {
            return !BigNatModule_isZero(BigInteger__get_V(y));
        }
        case 6: {
            return false;
        }
        case 7: {
            return false;
        }
        case 8: {
            return !BigNatModule_isZero(BigInteger__get_V(x));
        }
        case 9: {
            throw (new Error("signs should be +/- 1 or 0\\nParameter name: x"));
        }
    }
}

export function BigInteger_op_GreaterThan_56F059C0(x, y) {
    const matchValue = [BigInteger__get_SignInt(x), BigInteger__get_SignInt(y)];
    let pattern_matching_result;
    if (matchValue[0] === -1) {
        if (matchValue[1] === -1) {
            pattern_matching_result = 1;
        }
        else if (matchValue[1] === 0) {
            pattern_matching_result = 8;
        }
        else if (matchValue[1] === 1) {
            pattern_matching_result = 3;
        }
        else {
            pattern_matching_result = 9;
        }
    }
    else if (matchValue[0] === 0) {
        if (matchValue[1] === -1) {
            pattern_matching_result = 6;
        }
        else if (matchValue[1] === 0) {
            pattern_matching_result = 4;
        }
        else if (matchValue[1] === 1) {
            pattern_matching_result = 5;
        }
        else {
            pattern_matching_result = 9;
        }
    }
    else if (matchValue[0] === 1) {
        if (matchValue[1] === -1) {
            pattern_matching_result = 2;
        }
        else if (matchValue[1] === 0) {
            pattern_matching_result = 7;
        }
        else if (matchValue[1] === 1) {
            pattern_matching_result = 0;
        }
        else {
            pattern_matching_result = 9;
        }
    }
    else {
        pattern_matching_result = 9;
    }
    switch (pattern_matching_result) {
        case 0: {
            return BigNatModule_gt(BigInteger__get_V(x), BigInteger__get_V(y));
        }
        case 1: {
            return BigNatModule_gt(BigInteger__get_V(y), BigInteger__get_V(x));
        }
        case 2: {
            if (!BigNatModule_isZero(BigInteger__get_V(x))) {
                return true;
            }
            else {
                return !BigNatModule_isZero(BigInteger__get_V(y));
            }
        }
        case 3: {
            return false;
        }
        case 4: {
            return false;
        }
        case 5: {
            return false;
        }
        case 6: {
            return !BigNatModule_isZero(BigInteger__get_V(y));
        }
        case 7: {
            return !BigNatModule_isZero(BigInteger__get_V(x));
        }
        case 8: {
            return false;
        }
        case 9: {
            throw (new Error("signs should be +/- 1 or 0\\nParameter name: x"));
        }
    }
}

export function BigInteger_compare_56F059C0(n, nn) {
    if (BigInteger_op_LessThan_56F059C0(n, nn)) {
        return -1;
    }
    else if (BigInteger_op_Equality_56F059C0(n, nn)) {
        return 0;
    }
    else {
        return 1;
    }
}

export function BigInteger_hash_Z665282C2(z) {
    if (BigInteger__get_SignInt(z) === 0) {
        return 1;
    }
    else {
        return (BigInteger__get_SignInt(z) + BigNatModule_hash(BigInteger__get_V(z))) | 0;
    }
}

export function BigInteger__get_StructuredDisplayString(x) {
    return toString(x);
}

export function BigInteger_$ctor_Z524259A4(n) {
    if (n >= 0) {
        return BigInteger_$ctor_Z2BE94A1(1, BigInteger_nat_Z67CCE57D(BigNatModule_ofInt32(n)));
    }
    else if (n === -2147483648) {
        return BigInteger_$ctor_Z2BE94A1(-1, BigInteger_nat_Z67CCE57D(BigNatModule_ofInt64(op_UnaryNegation(fromInteger(n, false, 2)))));
    }
    else {
        return BigInteger_$ctor_Z2BE94A1(-1, BigInteger_nat_Z67CCE57D(BigNatModule_ofInt32(op_UnaryNegation_Int32(n))));
    }
}

export function BigInteger_$ctor_Z524259C1(n) {
    if (compare(n, fromBits(0, 0, false)) >= 0) {
        return BigInteger_$ctor_Z2BE94A1(1, BigInteger_nat_Z67CCE57D(BigNatModule_ofInt64(n)));
    }
    else if (equals(n, fromBits(0, 2147483648, false))) {
        return BigInteger_$ctor_Z2BE94A1(-1, BigInteger_nat_Z67CCE57D(BigNatModule_add(BigNatModule_ofInt64(fromBits(4294967295, 2147483647, false)), BigNatModule_one)));
    }
    else {
        return BigInteger_$ctor_Z2BE94A1(-1, BigInteger_nat_Z67CCE57D(BigNatModule_ofInt64(op_UnaryNegation(n))));
    }
}

export function BigInteger_get_One() {
    return BigInteger.one;
}

export function BigInteger_get_Two() {
    return BigInteger.two;
}

export function BigInteger_get_Zero() {
    return BigInteger.zero;
}

export function BigInteger_op_UnaryNegation_Z665282C2(z) {
    const matchValue = BigInteger__get_SignInt(z) | 0;
    if (matchValue === 0) {
        return BigInteger_get_Zero();
    }
    else {
        return BigInteger_create_Z2BE94A1(op_UnaryNegation_Int32(matchValue), BigInteger__get_V(z));
    }
}

export function BigInteger_Scale_Z320F31E(k, z) {
    if (BigInteger__get_SignInt(z) === 0) {
        return BigInteger_get_Zero();
    }
    else if (k < 0) {
        return BigInteger_create_Z2BE94A1(op_UnaryNegation_Int32(BigInteger__get_SignInt(z)), BigNatModule_scale(op_UnaryNegation_Int32(k), BigInteger__get_V(z)));
    }
    else {
        return BigInteger_create_Z2BE94A1(BigInteger__get_SignInt(z), BigNatModule_scale(k, BigInteger__get_V(z)));
    }
}

export function BigInteger_subnn_6A57060(nx, ny) {
    if (BigNatModule_gte(nx, ny)) {
        return BigInteger_posn_Z67CCE57D(BigNatModule_sub(nx, ny));
    }
    else {
        return BigInteger_negn_Z67CCE57D(BigNatModule_sub(ny, nx));
    }
}

export function BigInteger_addnn_6A57060(nx, ny) {
    return BigInteger_posn_Z67CCE57D(BigNatModule_add(nx, ny));
}

export function BigInteger__get_IsZero(x) {
    if (BigInteger__get_SignInt(x) === 0) {
        return true;
    }
    else {
        return BigNatModule_isZero(BigInteger__get_V(x));
    }
}

export function BigInteger__get_IsOne(x) {
    if (BigInteger__get_SignInt(x) === 1) {
        return BigNatModule_isOne(BigInteger__get_V(x));
    }
    else {
        return false;
    }
}

export function BigInteger_op_Addition_56F059C0(x, y) {
    if (BigInteger__get_IsZero(y)) {
        return x;
    }
    else if (BigInteger__get_IsZero(x)) {
        return y;
    }
    else {
        const matchValue = [BigInteger__get_SignInt(x), BigInteger__get_SignInt(y)];
        let pattern_matching_result;
        if (matchValue[0] === -1) {
            if (matchValue[1] === -1) {
                pattern_matching_result = 1;
            }
            else if (matchValue[1] === 1) {
                pattern_matching_result = 3;
            }
            else {
                pattern_matching_result = 4;
            }
        }
        else if (matchValue[0] === 1) {
            if (matchValue[1] === -1) {
                pattern_matching_result = 2;
            }
            else if (matchValue[1] === 1) {
                pattern_matching_result = 0;
            }
            else {
                pattern_matching_result = 4;
            }
        }
        else {
            pattern_matching_result = 4;
        }
        switch (pattern_matching_result) {
            case 0: {
                return BigInteger_addnn_6A57060(BigInteger__get_V(x), BigInteger__get_V(y));
            }
            case 1: {
                return BigInteger_op_UnaryNegation_Z665282C2(BigInteger_addnn_6A57060(BigInteger__get_V(x), BigInteger__get_V(y)));
            }
            case 2: {
                return BigInteger_subnn_6A57060(BigInteger__get_V(x), BigInteger__get_V(y));
            }
            case 3: {
                return BigInteger_subnn_6A57060(BigInteger__get_V(y), BigInteger__get_V(x));
            }
            case 4: {
                throw (new Error("signs should be +/- 1\\nParameter name: x"));
            }
        }
    }
}

export function BigInteger_op_Subtraction_56F059C0(x, y) {
    if (BigInteger__get_IsZero(y)) {
        return x;
    }
    else if (BigInteger__get_IsZero(x)) {
        return BigInteger_op_UnaryNegation_Z665282C2(y);
    }
    else {
        const matchValue = [BigInteger__get_SignInt(x), BigInteger__get_SignInt(y)];
        let pattern_matching_result;
        if (matchValue[0] === -1) {
            if (matchValue[1] === -1) {
                pattern_matching_result = 1;
            }
            else if (matchValue[1] === 1) {
                pattern_matching_result = 3;
            }
            else {
                pattern_matching_result = 4;
            }
        }
        else if (matchValue[0] === 1) {
            if (matchValue[1] === -1) {
                pattern_matching_result = 2;
            }
            else if (matchValue[1] === 1) {
                pattern_matching_result = 0;
            }
            else {
                pattern_matching_result = 4;
            }
        }
        else {
            pattern_matching_result = 4;
        }
        switch (pattern_matching_result) {
            case 0: {
                return BigInteger_subnn_6A57060(BigInteger__get_V(x), BigInteger__get_V(y));
            }
            case 1: {
                return BigInteger_subnn_6A57060(BigInteger__get_V(y), BigInteger__get_V(x));
            }
            case 2: {
                return BigInteger_addnn_6A57060(BigInteger__get_V(x), BigInteger__get_V(y));
            }
            case 3: {
                return BigInteger_op_UnaryNegation_Z665282C2(BigInteger_addnn_6A57060(BigInteger__get_V(x), BigInteger__get_V(y)));
            }
            case 4: {
                throw (new Error("signs should be +/- 1\\nParameter name: x"));
            }
        }
    }
}

export function BigInteger_op_Multiply_56F059C0(x, y) {
    if (BigInteger__get_IsZero(x)) {
        return x;
    }
    else if (BigInteger__get_IsZero(y)) {
        return y;
    }
    else if (BigInteger__get_IsOne(x)) {
        return y;
    }
    else if (BigInteger__get_IsOne(y)) {
        return x;
    }
    else {
        const m = BigNatModule_mul(BigInteger__get_V(x), BigInteger__get_V(y));
        return BigInteger_create_Z2BE94A1(BigInteger__get_SignInt(x) * BigInteger__get_SignInt(y), m);
    }
}

export function BigInteger_DivRem_56F059C0(x, y) {
    if (BigInteger__get_IsZero(y)) {
        throw (new Error());
    }
    if (BigInteger__get_IsZero(x)) {
        return [BigInteger_get_Zero(), BigInteger_get_Zero()];
    }
    else {
        const patternInput = BigNatModule_divmod(BigInteger__get_V(x), BigInteger__get_V(y));
        const r = patternInput[1];
        const d = patternInput[0];
        const matchValue = [BigInteger__get_SignInt(x), BigInteger__get_SignInt(y)];
        let pattern_matching_result;
        if (matchValue[0] === -1) {
            if (matchValue[1] === -1) {
                pattern_matching_result = 1;
            }
            else if (matchValue[1] === 1) {
                pattern_matching_result = 3;
            }
            else {
                pattern_matching_result = 4;
            }
        }
        else if (matchValue[0] === 1) {
            if (matchValue[1] === -1) {
                pattern_matching_result = 2;
            }
            else if (matchValue[1] === 1) {
                pattern_matching_result = 0;
            }
            else {
                pattern_matching_result = 4;
            }
        }
        else {
            pattern_matching_result = 4;
        }
        switch (pattern_matching_result) {
            case 0: {
                return [BigInteger_posn_Z67CCE57D(d), BigInteger_posn_Z67CCE57D(r)];
            }
            case 1: {
                return [BigInteger_posn_Z67CCE57D(d), BigInteger_negn_Z67CCE57D(r)];
            }
            case 2: {
                return [BigInteger_negn_Z67CCE57D(d), BigInteger_posn_Z67CCE57D(r)];
            }
            case 3: {
                return [BigInteger_negn_Z67CCE57D(d), BigInteger_negn_Z67CCE57D(r)];
            }
            case 4: {
                throw (new Error("signs should be +/- 1\\nParameter name: x"));
            }
        }
    }
}

export function BigInteger_op_Division_56F059C0(x, y) {
    return BigInteger_DivRem_56F059C0(x, y)[0];
}

export function BigInteger_op_Modulus_56F059C0(x, y) {
    return BigInteger_DivRem_56F059C0(x, y)[1];
}

export function BigInteger_op_RightShift_62E082A2(x, y) {
    return BigInteger_op_Division_56F059C0(x, BigInteger_Pow_62E082A2(BigInteger_get_Two(), y));
}

export function BigInteger_op_LeftShift_62E082A2(x, y) {
    return BigInteger_op_Multiply_56F059C0(x, BigInteger_Pow_62E082A2(BigInteger_get_Two(), y));
}

export function BigInteger_op_BitwiseAnd_56F059C0(x, y) {
    return BigInteger_posn_Z67CCE57D(BigNatModule_bitAnd(BigInteger__get_V(x), BigInteger__get_V(y)));
}

export function BigInteger_op_BitwiseOr_56F059C0(x, y) {
    return BigInteger_posn_Z67CCE57D(BigNatModule_bitOr(BigInteger__get_V(x), BigInteger__get_V(y)));
}

export function BigInteger_op_ExclusiveOr_56F059C0(x, y) {
    return BigInteger_posn_Z67CCE57D(BigNatModule_bitXor(BigInteger__get_V(x), BigInteger__get_V(y)));
}

export function BigInteger_GreatestCommonDivisor_56F059C0(x, y) {
    const matchValue = [BigInteger__get_SignInt(x), BigInteger__get_SignInt(y)];
    if (matchValue[0] === 0) {
        if (matchValue[1] === 0) {
            return BigInteger_get_Zero();
        }
        else {
            return BigInteger_posn_Z67CCE57D(BigInteger__get_V(y));
        }
    }
    else if (matchValue[1] === 0) {
        return BigInteger_posn_Z67CCE57D(BigInteger__get_V(x));
    }
    else {
        return BigInteger_posn_Z67CCE57D(BigNatModule_hcf(BigInteger__get_V(x), BigInteger__get_V(y)));
    }
}

export function BigInteger__get_IsNegative(x) {
    if (BigInteger__get_SignInt(x) === -1) {
        return !BigInteger__get_IsZero(x);
    }
    else {
        return false;
    }
}

export function BigInteger__get_IsPositive(x) {
    if (BigInteger__get_SignInt(x) === 1) {
        return !BigInteger__get_IsZero(x);
    }
    else {
        return false;
    }
}

export function BigInteger_Abs_Z665282C2(x) {
    if (BigInteger__get_SignInt(x) === -1) {
        return BigInteger_op_UnaryNegation_Z665282C2(x);
    }
    else {
        return x;
    }
}

export function BigInteger_op_LessThanOrEqual_56F059C0(x, y) {
    const matchValue = [BigInteger__get_SignInt(x), BigInteger__get_SignInt(y)];
    let pattern_matching_result;
    if (matchValue[0] === -1) {
        if (matchValue[1] === -1) {
            pattern_matching_result = 1;
        }
        else if (matchValue[1] === 0) {
            pattern_matching_result = 6;
        }
        else if (matchValue[1] === 1) {
            pattern_matching_result = 3;
        }
        else {
            pattern_matching_result = 9;
        }
    }
    else if (matchValue[0] === 0) {
        if (matchValue[1] === -1) {
            pattern_matching_result = 8;
        }
        else if (matchValue[1] === 0) {
            pattern_matching_result = 4;
        }
        else if (matchValue[1] === 1) {
            pattern_matching_result = 7;
        }
        else {
            pattern_matching_result = 9;
        }
    }
    else if (matchValue[0] === 1) {
        if (matchValue[1] === -1) {
            pattern_matching_result = 2;
        }
        else if (matchValue[1] === 0) {
            pattern_matching_result = 5;
        }
        else if (matchValue[1] === 1) {
            pattern_matching_result = 0;
        }
        else {
            pattern_matching_result = 9;
        }
    }
    else {
        pattern_matching_result = 9;
    }
    switch (pattern_matching_result) {
        case 0: {
            return BigNatModule_lte(BigInteger__get_V(x), BigInteger__get_V(y));
        }
        case 1: {
            return BigNatModule_lte(BigInteger__get_V(y), BigInteger__get_V(x));
        }
        case 2: {
            if (BigNatModule_isZero(BigInteger__get_V(x))) {
                return BigNatModule_isZero(BigInteger__get_V(y));
            }
            else {
                return false;
            }
        }
        case 3: {
            return true;
        }
        case 4: {
            return true;
        }
        case 5: {
            return BigNatModule_isZero(BigInteger__get_V(x));
        }
        case 6: {
            return true;
        }
        case 7: {
            return true;
        }
        case 8: {
            return BigNatModule_isZero(BigInteger__get_V(y));
        }
        case 9: {
            throw (new Error("signs should be +/- 1 or 0\\nParameter name: x"));
        }
    }
}

export function BigInteger_op_GreaterThanOrEqual_56F059C0(x, y) {
    const matchValue = [BigInteger__get_SignInt(x), BigInteger__get_SignInt(y)];
    let pattern_matching_result;
    if (matchValue[0] === -1) {
        if (matchValue[1] === -1) {
            pattern_matching_result = 1;
        }
        else if (matchValue[1] === 0) {
            pattern_matching_result = 6;
        }
        else if (matchValue[1] === 1) {
            pattern_matching_result = 3;
        }
        else {
            pattern_matching_result = 9;
        }
    }
    else if (matchValue[0] === 0) {
        if (matchValue[1] === -1) {
            pattern_matching_result = 8;
        }
        else if (matchValue[1] === 0) {
            pattern_matching_result = 4;
        }
        else if (matchValue[1] === 1) {
            pattern_matching_result = 7;
        }
        else {
            pattern_matching_result = 9;
        }
    }
    else if (matchValue[0] === 1) {
        if (matchValue[1] === -1) {
            pattern_matching_result = 2;
        }
        else if (matchValue[1] === 0) {
            pattern_matching_result = 5;
        }
        else if (matchValue[1] === 1) {
            pattern_matching_result = 0;
        }
        else {
            pattern_matching_result = 9;
        }
    }
    else {
        pattern_matching_result = 9;
    }
    switch (pattern_matching_result) {
        case 0: {
            return BigNatModule_gte(BigInteger__get_V(x), BigInteger__get_V(y));
        }
        case 1: {
            return BigNatModule_gte(BigInteger__get_V(y), BigInteger__get_V(x));
        }
        case 2: {
            return true;
        }
        case 3: {
            if (BigNatModule_isZero(BigInteger__get_V(x))) {
                return BigNatModule_isZero(BigInteger__get_V(y));
            }
            else {
                return false;
            }
        }
        case 4: {
            return true;
        }
        case 5: {
            return true;
        }
        case 6: {
            return BigNatModule_isZero(BigInteger__get_V(x));
        }
        case 7: {
            return BigNatModule_isZero(BigInteger__get_V(y));
        }
        case 8: {
            return true;
        }
        case 9: {
            throw (new Error("signs should be +/- 1 or 0\\nParameter name: x"));
        }
    }
}

export function BigInteger_Pow_62E082A2(x, y) {
    if (y < 0) {
        throw (new Error("y"));
    }
    const matchValue = [BigInteger__get_IsZero(x), y];
    if (matchValue[0]) {
        if (matchValue[1] === 0) {
            return BigInteger_get_One();
        }
        else {
            return BigInteger_get_Zero();
        }
    }
    else {
        const yval = BigInteger_$ctor_Z524259A4(y);
        return BigInteger_create_Z2BE94A1(BigNatModule_isZero(BigNatModule_rem(BigInteger__get_V(yval), BigNatModule_two)) ? 1 : BigInteger__get_SignInt(x), BigNatModule_pow(BigInteger__get_V(x), BigInteger__get_V(yval)));
    }
}

export function BigInteger__get_ToInt32(x) {
    if (BigInteger__get_IsZero(x)) {
        return 0;
    }
    else {
        const u = BigNatModule_toUInt32(BigInteger__get_V(x));
        if (u <= (2147483647 >>> 0)) {
            return (BigInteger__get_SignInt(x) * (~(~u))) | 0;
        }
        else if ((BigInteger__get_SignInt(x) === -1) && (u === ((2147483647 + 1) >>> 0))) {
            return -2147483648;
        }
        else {
            throw (new Error());
        }
    }
}

export function BigInteger__get_ToUInt32(x) {
    if (BigInteger__get_IsZero(x)) {
        return 0;
    }
    else {
        return BigNatModule_toUInt32(BigInteger__get_V(x));
    }
}

export function BigInteger__get_ToInt64(x) {
    if (BigInteger__get_IsZero(x)) {
        return fromBits(0, 0, false);
    }
    else {
        const u = BigNatModule_toUInt64(BigInteger__get_V(x));
        if (compare(u, fromValue(fromBits(4294967295, 2147483647, false), true)) <= 0) {
            return op_Multiply(fromInteger(BigInteger__get_SignInt(x), false, 2), fromValue(u, false));
        }
        else if ((BigInteger__get_SignInt(x) === -1) && equals(u, fromValue(op_Addition(fromBits(4294967295, 2147483647, false), fromBits(1, 0, false)), true))) {
            return fromBits(0, 2147483648, false);
        }
        else {
            throw (new Error());
        }
    }
}

export function BigInteger__get_ToUInt64(x) {
    if (BigInteger__get_IsZero(x)) {
        return fromBits(0, 0, true);
    }
    else {
        return BigNatModule_toUInt64(BigInteger__get_V(x));
    }
}

export function BigInteger__get_ToDouble(x) {
    const matchValue = BigInteger__get_SignInt(x) | 0;
    switch (matchValue) {
        case -1: {
            return -BigNatModule_toFloat(BigInteger__get_V(x));
        }
        case 0: {
            return 0;
        }
        case 1: {
            return BigNatModule_toFloat(BigInteger__get_V(x));
        }
        default: {
            throw (new Error("signs should be +/- 1 or 0\\nParameter name: x"));
        }
    }
}

export function BigInteger__get_ToSByte(x) {
    return (BigInteger__get_ToInt32(x) + 0x80 & 0xFF) - 0x80;
}

export function BigInteger__get_ToByte(x) {
    return BigInteger__get_ToUInt32(x) & 0xFF;
}

export function BigInteger__get_ToInt16(x) {
    return (BigInteger__get_ToInt32(x) + 0x8000 & 0xFFFF) - 0x8000;
}

export function BigInteger__get_ToUInt16(x) {
    return BigInteger__get_ToUInt32(x) & 0xFFFF;
}

export function BigInteger__get_ToSingle(x) {
    return BigInteger__get_ToDouble(x);
}

export function BigInteger__get_ToDecimal(x) {
    return new Decimal(BigInteger__get_ToDouble(x));
}

export function BigInteger_Parse_Z721C83C5(text) {
    if (text == null) {
        throw (new Error("text"));
    }
    const text_1 = text.trim();
    const len = text_1.length | 0;
    if (len === 0) {
        throw (new Error());
    }
    const matchValue = [text_1[0], len];
    if (matchValue[0] === "+") {
        if (matchValue[1] === 1) {
            throw (new Error());
        }
        else {
            return BigInteger_posn_Z67CCE57D(BigNatModule_ofString(text_1.slice(1, (len - 1) + 1)));
        }
    }
    else if (matchValue[0] === "-") {
        if (matchValue[1] === 1) {
            throw (new Error());
        }
        else {
            return BigInteger_negn_Z67CCE57D(BigNatModule_ofString(text_1.slice(1, (len - 1) + 1)));
        }
    }
    else {
        return BigInteger_posn_Z67CCE57D(BigNatModule_ofString(text_1));
    }
}

export function BigInteger__get_IsSmall(x) {
    if (BigInteger__get_IsZero(x)) {
        return true;
    }
    else {
        return BigNatModule_isSmall(BigInteger__get_V(x));
    }
}

export function BigInteger_Factorial_Z665282C2(x) {
    if (BigInteger__get_IsNegative(x)) {
        throw (new Error("mustBeNonNegative\\nParameter name: x"));
    }
    if (BigInteger__get_IsPositive(x)) {
        return BigInteger_posn_Z67CCE57D(BigNatModule_factorial(BigInteger__get_V(x)));
    }
    else {
        return BigInteger_get_One();
    }
}

export function BigInteger_op_UnaryPlus_Z665282C2(n1) {
    return n1;
}

export function BigInteger_FromInt64_Z524259C1(x) {
    return BigInteger_$ctor_Z524259C1(x);
}

export function BigInteger_FromInt32_Z524259A4(x) {
    return BigInteger_$ctor_Z524259A4(x);
}

