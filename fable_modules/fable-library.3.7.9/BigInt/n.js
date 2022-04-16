import { Record } from "../Types.js";
import { record_type, array_type, int32_type } from "../Reflection.js";
import { op_LeftShift, op_BitwiseAnd, op_Addition, compare, op_Subtraction, op_Division, equals, fromInteger, op_Multiply, op_Modulus, toInt, fromBits } from "../Long.js";
import { copy, initialize, map, fill } from "../Array.js";
import { toArray, empty, head, tail, isEmpty, cons } from "../List.js";
import { int32ToString } from "../Util.js";
import { isNullOrEmpty, join } from "../String.js";

export class BigNat extends Record {
    constructor(bound, digits) {
        super();
        this.bound = (bound | 0);
        this.digits = digits;
    }
}

export function BigNat$reflection() {
    return record_type("BigInt.BigNat", [], BigNat, () => [["bound", int32_type], ["digits", array_type(int32_type)]]);
}

export function BigNatModule_FFT_pow32(x_mut, n_mut) {
    BigNatModule_FFT_pow32:
    while (true) {
        const x = x_mut, n = n_mut;
        if (n === 0) {
            return 1;
        }
        else if ((n % 2) === 0) {
            x_mut = (x * x);
            n_mut = (~(~(n / 2)));
            continue BigNatModule_FFT_pow32;
        }
        else {
            return (x * BigNatModule_FFT_pow32(x * x, ~(~(n / 2)))) | 0;
        }
        break;
    }
}

export function BigNatModule_FFT_leastBounding2Power(b) {
    const findBounding2Power = (b_1_mut, tp_mut, i_mut) => {
        findBounding2Power:
        while (true) {
            const b_1 = b_1_mut, tp = tp_mut, i = i_mut;
            if (b_1 <= tp) {
                return [tp, i];
            }
            else {
                b_1_mut = b_1;
                tp_mut = (tp * 2);
                i_mut = (i + 1);
                continue findBounding2Power;
            }
            break;
        }
    };
    return findBounding2Power(b, 1, 0);
}

export const BigNatModule_FFT_p = fromBits(2013265921, 0, false);

const BigNatModule_FFT_patternInput$004075 = [27, 15, 31, 440564289];

export const BigNatModule_FFT_w = BigNatModule_FFT_patternInput$004075[3];

export const BigNatModule_FFT_m = BigNatModule_FFT_patternInput$004075[1];

export const BigNatModule_FFT_k = BigNatModule_FFT_patternInput$004075[0];

export const BigNatModule_FFT_g = BigNatModule_FFT_patternInput$004075[2];

export const BigNatModule_FFT_primeP = BigNatModule_FFT_p;

export const BigNatModule_FFT_maxBitsInsideFp = 30;

export const BigNatModule_FFT_Fp_p = 2013265921;

export const BigNatModule_FFT_Fp_p64 = fromBits(2013265921, 0, true);

export function BigNatModule_FFT_Fp_toInt(x) {
    return ~(~x);
}

export function BigNatModule_FFT_Fp_ofInt32(x) {
    return x >>> 0;
}

export const BigNatModule_FFT_Fp_mzero = 0;

export const BigNatModule_FFT_Fp_mone = 1;

export const BigNatModule_FFT_Fp_mtwo = 2;

export function BigNatModule_FFT_Fp_mpow(x_mut, n_mut) {
    BigNatModule_FFT_Fp_mpow:
    while (true) {
        const x = x_mut, n = n_mut;
        if (n === 0) {
            return BigNatModule_FFT_Fp_mone;
        }
        else if ((n % 2) === 0) {
            x_mut = (toInt(op_Modulus(op_Multiply(fromInteger(x, true, 6), fromInteger(x, true, 6)), BigNatModule_FFT_Fp_p64)) >>> 0);
            n_mut = (~(~(n / 2)));
            continue BigNatModule_FFT_Fp_mpow;
        }
        else {
            const y_2 = BigNatModule_FFT_Fp_mpow(toInt(op_Modulus(op_Multiply(fromInteger(x, true, 6), fromInteger(x, true, 6)), BigNatModule_FFT_Fp_p64)) >>> 0, ~(~(n / 2)));
            return toInt(op_Modulus(op_Multiply(fromInteger(x, true, 6), fromInteger(y_2, true, 6)), BigNatModule_FFT_Fp_p64)) >>> 0;
        }
        break;
    }
}

export function BigNatModule_FFT_Fp_mpowL(x_mut, n_mut) {
    BigNatModule_FFT_Fp_mpowL:
    while (true) {
        const x = x_mut, n = n_mut;
        if (equals(n, fromBits(0, 0, false))) {
            return BigNatModule_FFT_Fp_mone;
        }
        else if (equals(op_Modulus(n, fromBits(2, 0, false)), fromBits(0, 0, false))) {
            x_mut = (toInt(op_Modulus(op_Multiply(fromInteger(x, true, 6), fromInteger(x, true, 6)), BigNatModule_FFT_Fp_p64)) >>> 0);
            n_mut = op_Division(n, fromBits(2, 0, false));
            continue BigNatModule_FFT_Fp_mpowL;
        }
        else {
            const y_2 = BigNatModule_FFT_Fp_mpowL(toInt(op_Modulus(op_Multiply(fromInteger(x, true, 6), fromInteger(x, true, 6)), BigNatModule_FFT_Fp_p64)) >>> 0, op_Division(n, fromBits(2, 0, false)));
            return toInt(op_Modulus(op_Multiply(fromInteger(x, true, 6), fromInteger(y_2, true, 6)), BigNatModule_FFT_Fp_p64)) >>> 0;
        }
        break;
    }
}

export function BigNatModule_FFT_Fp_m2PowNthRoot(n) {
    return BigNatModule_FFT_Fp_mpow(BigNatModule_FFT_w >>> 0, BigNatModule_FFT_pow32(2, BigNatModule_FFT_k - n));
}

export function BigNatModule_FFT_Fp_minv(x) {
    return BigNatModule_FFT_Fp_mpowL(x, op_Subtraction(BigNatModule_FFT_primeP, fromBits(2, 0, false)));
}

export function BigNatModule_FFT_computeFFT(lambda, mu, n, w, u, res, offset) {
    let x_1, x_3, y_5;
    if (n === 1) {
        res[offset] = u[mu];
    }
    else {
        const halfN = (~(~(n / 2))) | 0;
        const ww = toInt(op_Modulus(op_Multiply(fromInteger(w, true, 6), fromInteger(w, true, 6)), BigNatModule_FFT_Fp_p64)) >>> 0;
        const offsetHalfN = (offset + halfN) | 0;
        BigNatModule_FFT_computeFFT(lambda * 2, mu, halfN, ww, u, res, offset);
        BigNatModule_FFT_computeFFT(lambda * 2, lambda + mu, halfN, ww, u, res, offsetHalfN);
        let wj = BigNatModule_FFT_Fp_mone;
        for (let j = 0; j <= (halfN - 1); j++) {
            const even = res[offset + j];
            const odd = res[offsetHalfN + j];
            res[offset + j] = ((even + ((x_1 = wj, toInt(op_Modulus(op_Multiply(fromInteger(x_1, true, 6), fromInteger(odd, true, 6)), BigNatModule_FFT_Fp_p64)) >>> 0))) % BigNatModule_FFT_Fp_p);
            res[offsetHalfN + j] = (((even + BigNatModule_FFT_Fp_p) - ((x_3 = wj, toInt(op_Modulus(op_Multiply(fromInteger(x_3, true, 6), fromInteger(odd, true, 6)), BigNatModule_FFT_Fp_p64)) >>> 0))) % BigNatModule_FFT_Fp_p);
            wj = ((y_5 = wj, toInt(op_Modulus(op_Multiply(fromInteger(w, true, 6), fromInteger(y_5, true, 6)), BigNatModule_FFT_Fp_p64)) >>> 0));
        }
    }
}

export function BigNatModule_FFT_computFftInPlace(n, w, u) {
    const res = fill(new Uint32Array(n), 0, n, BigNatModule_FFT_Fp_mzero);
    BigNatModule_FFT_computeFFT(1, 0, n, w, u, res, 0);
    return res;
}

export function BigNatModule_FFT_computeInverseFftInPlace(n, w, uT) {
    const bigKInv = BigNatModule_FFT_Fp_minv(n >>> 0);
    return map((y) => (toInt(op_Modulus(op_Multiply(fromInteger(bigKInv, true, 6), fromInteger(y, true, 6)), BigNatModule_FFT_Fp_p64)) >>> 0), BigNatModule_FFT_computFftInPlace(n, BigNatModule_FFT_Fp_minv(w), uT), Uint32Array);
}

export const BigNatModule_FFT_maxTwoPower = 29;

export const BigNatModule_FFT_twoPowerTable = initialize(BigNatModule_FFT_maxTwoPower - 1, (i) => BigNatModule_FFT_pow32(2, i), Int32Array);

export function BigNatModule_FFT_computeFftPaddedPolynomialProduct(bigK, k, u, v) {
    const w = BigNatModule_FFT_Fp_m2PowNthRoot(k);
    const n = bigK | 0;
    const uT = BigNatModule_FFT_computFftInPlace(n, w, u);
    const vT = BigNatModule_FFT_computFftInPlace(n, w, v);
    return BigNatModule_FFT_computeInverseFftInPlace(n, w, initialize(n, (i) => {
        const x = uT[i];
        const y = vT[i];
        return toInt(op_Modulus(op_Multiply(fromInteger(x, true, 6), fromInteger(y, true, 6)), BigNatModule_FFT_Fp_p64)) >>> 0;
    }, Uint32Array));
}

export function BigNatModule_FFT_padTo(n, u) {
    const uBound = u.length | 0;
    return initialize(n, (i) => ((i < uBound) ? BigNatModule_FFT_Fp_ofInt32(u[i]) : BigNatModule_FFT_Fp_mzero), Uint32Array);
}

export function BigNatModule_FFT_computeFftPolynomialProduct(degu, u, degv, v) {
    const patternInput = BigNatModule_FFT_leastBounding2Power((degu + degv) + 1);
    const bigK = patternInput[0] | 0;
    const w = BigNatModule_FFT_Fp_m2PowNthRoot(patternInput[1]);
    const u_1 = BigNatModule_FFT_padTo(bigK, u);
    const v_1 = BigNatModule_FFT_padTo(bigK, v);
    const n = bigK | 0;
    const uT = BigNatModule_FFT_computFftInPlace(n, w, u_1);
    const vT = BigNatModule_FFT_computFftInPlace(n, w, v_1);
    return map(BigNatModule_FFT_Fp_toInt, BigNatModule_FFT_computeInverseFftInPlace(n, w, initialize(n, (i) => {
        const x = uT[i];
        const y = vT[i];
        return toInt(op_Modulus(op_Multiply(fromInteger(x, true, 6), fromInteger(y, true, 6)), BigNatModule_FFT_Fp_p64)) >>> 0;
    }, Uint32Array)), Int32Array);
}

export const BigNatModule_FFT_mzero = BigNatModule_FFT_Fp_mzero;

export const BigNatModule_FFT_mone = BigNatModule_FFT_Fp_mone;

export const BigNatModule_FFT_maxFp = ((BigNatModule_FFT_Fp_p + BigNatModule_FFT_Fp_p) - BigNatModule_FFT_mone) % BigNatModule_FFT_Fp_p;

export function BigNatModule_bound(n) {
    return n.bound;
}

export function BigNatModule_setBound(n, v) {
    n.bound = (v | 0);
}

export function BigNatModule_coeff(n, i) {
    return n.digits[i];
}

export function BigNatModule_coeff64(n, i) {
    return fromInteger(BigNatModule_coeff(n, i), false, 2);
}

export function BigNatModule_setCoeff(n, i, v) {
    n.digits[i] = (v | 0);
}

export function BigNatModule_pow64(x_mut, n_mut) {
    BigNatModule_pow64:
    while (true) {
        const x = x_mut, n = n_mut;
        if (n === 0) {
            return fromBits(1, 0, false);
        }
        else if ((n % 2) === 0) {
            x_mut = op_Multiply(x, x);
            n_mut = (~(~(n / 2)));
            continue BigNatModule_pow64;
        }
        else {
            return op_Multiply(x, BigNatModule_pow64(op_Multiply(x, x), ~(~(n / 2))));
        }
        break;
    }
}

export function BigNatModule_pow32(x_mut, n_mut) {
    BigNatModule_pow32:
    while (true) {
        const x = x_mut, n = n_mut;
        if (n === 0) {
            return 1;
        }
        else if ((n % 2) === 0) {
            x_mut = (x * x);
            n_mut = (~(~(n / 2)));
            continue BigNatModule_pow32;
        }
        else {
            return (x * BigNatModule_pow32(x * x, ~(~(n / 2)))) | 0;
        }
        break;
    }
}

export function BigNatModule_hash(n) {
    let res = 0;
    for (let i = 0; i <= (n.bound - 1); i++) {
        res = ((n.digits[i] + (res << 3)) | 0);
    }
    return res | 0;
}

export function BigNatModule_maxInt(a, b) {
    if (a < b) {
        return b | 0;
    }
    else {
        return a | 0;
    }
}

export function BigNatModule_minInt(a, b) {
    if (a < b) {
        return a | 0;
    }
    else {
        return b | 0;
    }
}

export const BigNatModule_baseBits = 24;

export const BigNatModule_baseN = 16777216;

export const BigNatModule_baseMask = 16777215;

export const BigNatModule_baseNi64 = fromBits(16777216, 0, false);

export const BigNatModule_baseMaski64 = fromBits(16777215, 0, false);

export const BigNatModule_baseMaskU = fromBits(16777215, 0, true);

export const BigNatModule_baseMask32A = 16777215;

export const BigNatModule_baseMask32B = 255;

export const BigNatModule_baseShift32B = 24;

export const BigNatModule_baseMask64A = 16777215;

export const BigNatModule_baseMask64B = 16777215;

export const BigNatModule_baseMask64C = 65535;

export const BigNatModule_baseShift64B = 24;

export const BigNatModule_baseShift64C = 48;

export function BigNatModule_divbase(x) {
    return ~(~((x >>> 0) >>> BigNatModule_baseBits));
}

export function BigNatModule_modbase(x) {
    return x & BigNatModule_baseMask;
}

export function BigNatModule_createN(b) {
    return new BigNat(b, new Int32Array(b));
}

export function BigNatModule_copyN(x) {
    return new BigNat(x.bound, copy(x.digits));
}

export function BigNatModule_normN(n) {
    const findLeastBound = (na_mut, i_mut) => {
        findLeastBound:
        while (true) {
            const na = na_mut, i = i_mut;
            if ((i === -1) ? true : (na[i] !== 0)) {
                return (i + 1) | 0;
            }
            else {
                na_mut = na;
                i_mut = (i - 1);
                continue findLeastBound;
            }
            break;
        }
    };
    const bound = findLeastBound(n.digits, n.bound - 1) | 0;
    n.bound = (bound | 0);
    return n;
}

export const BigNatModule_boundInt = 2;

export const BigNatModule_boundInt64 = 3;

export const BigNatModule_boundBase = 1;

export function BigNatModule_embed(x) {
    const x_1 = ((x < 0) ? 0 : x) | 0;
    if (x_1 < BigNatModule_baseN) {
        const r = BigNatModule_createN(1);
        r.digits[0] = (x_1 | 0);
        return BigNatModule_normN(r);
    }
    else {
        const r_1 = BigNatModule_createN(BigNatModule_boundInt);
        for (let i = 0; i <= (BigNatModule_boundInt - 1); i++) {
            r_1.digits[i] = (((~(~(x_1 / BigNatModule_pow32(BigNatModule_baseN, i)))) % BigNatModule_baseN) | 0);
        }
        return BigNatModule_normN(r_1);
    }
}

export function BigNatModule_embed64(x) {
    const x_1 = (compare(x, fromBits(0, 0, false)) < 0) ? fromBits(0, 0, false) : x;
    const r = BigNatModule_createN(BigNatModule_boundInt64);
    for (let i = 0; i <= (BigNatModule_boundInt64 - 1); i++) {
        r.digits[i] = ((~(~toInt(op_Modulus(op_Division(x_1, BigNatModule_pow64(BigNatModule_baseNi64, i)), BigNatModule_baseNi64)))) | 0);
    }
    return BigNatModule_normN(r);
}

export function BigNatModule_eval32(n) {
    if (n.bound === 1) {
        return n.digits[0] | 0;
    }
    else {
        let acc = 0;
        for (let i = n.bound - 1; i >= 0; i--) {
            acc = ((n.digits[i] + (BigNatModule_baseN * acc)) | 0);
        }
        return acc | 0;
    }
}

export function BigNatModule_eval64(n) {
    if (n.bound === 1) {
        return fromInteger(n.digits[0], false, 2);
    }
    else {
        let acc = fromBits(0, 0, false);
        for (let i = n.bound - 1; i >= 0; i--) {
            acc = op_Addition(fromInteger(n.digits[i], false, 2), op_Multiply(BigNatModule_baseNi64, acc));
        }
        return acc;
    }
}

export const BigNatModule_one = BigNatModule_embed(1);

export const BigNatModule_zero = BigNatModule_embed(0);

export function BigNatModule_restrictTo(d, n) {
    return new BigNat(BigNatModule_minInt(d, n.bound), n.digits);
}

export function BigNatModule_shiftUp(d, n) {
    const m = BigNatModule_createN(n.bound + d);
    for (let i = 0; i <= (n.bound - 1); i++) {
        m.digits[i + d] = (n.digits[i] | 0);
    }
    return m;
}

export function BigNatModule_shiftDown(d, n) {
    if ((n.bound - d) <= 0) {
        return BigNatModule_zero;
    }
    else {
        const m = BigNatModule_createN(n.bound - d);
        for (let i = 0; i <= (m.bound - 1); i++) {
            m.digits[i] = (n.digits[i + d] | 0);
        }
        return m;
    }
}

export function BigNatModule_degree(n) {
    return n.bound - 1;
}

export function BigNatModule_addP(i_mut, n_mut, c_mut, p_mut, q_mut, r_mut) {
    let z, i_1, z_1, i_2;
    BigNatModule_addP:
    while (true) {
        const i = i_mut, n = n_mut, c = c_mut, p = p_mut, q = q_mut, r = r_mut;
        if (i < n) {
            const x = ((((z = p, (i_1 = (i | 0), (i_1 < z.bound) ? z.digits[i_1] : 0))) + ((z_1 = q, (i_2 = (i | 0), (i_2 < z_1.bound) ? z_1.digits[i_2] : 0)))) + c) | 0;
            r.digits[i] = (BigNatModule_modbase(x) | 0);
            i_mut = (i + 1);
            n_mut = n;
            c_mut = BigNatModule_divbase(x);
            p_mut = p;
            q_mut = q;
            r_mut = r;
            continue BigNatModule_addP;
        }
        break;
    }
}

export function BigNatModule_add(p, q) {
    const rbound = (1 + BigNatModule_maxInt(p.bound, q.bound)) | 0;
    const r = BigNatModule_createN(rbound);
    BigNatModule_addP(0, rbound, 0, p, q, r);
    return BigNatModule_normN(r);
}

export function BigNatModule_subP(i_mut, n_mut, c_mut, p_mut, q_mut, r_mut) {
    let z, i_1, z_1, i_2;
    BigNatModule_subP:
    while (true) {
        const i = i_mut, n = n_mut, c = c_mut, p = p_mut, q = q_mut, r = r_mut;
        if (i < n) {
            const x = ((((z = p, (i_1 = (i | 0), (i_1 < z.bound) ? z.digits[i_1] : 0))) - ((z_1 = q, (i_2 = (i | 0), (i_2 < z_1.bound) ? z_1.digits[i_2] : 0)))) + c) | 0;
            if (x > 0) {
                r.digits[i] = (BigNatModule_modbase(x) | 0);
                i_mut = (i + 1);
                n_mut = n;
                c_mut = BigNatModule_divbase(x);
                p_mut = p;
                q_mut = q;
                r_mut = r;
                continue BigNatModule_subP;
            }
            else {
                const x_1 = (x + BigNatModule_baseN) | 0;
                r.digits[i] = (BigNatModule_modbase(x_1) | 0);
                i_mut = (i + 1);
                n_mut = n;
                c_mut = (BigNatModule_divbase(x_1) - 1);
                p_mut = p;
                q_mut = q;
                r_mut = r;
                continue BigNatModule_subP;
            }
        }
        else {
            return c !== 0;
        }
        break;
    }
}

export function BigNatModule_sub(p, q) {
    const rbound = BigNatModule_maxInt(p.bound, q.bound) | 0;
    const r = BigNatModule_createN(rbound);
    if (BigNatModule_subP(0, rbound, 0, p, q, r)) {
        return BigNatModule_embed(0);
    }
    else {
        return BigNatModule_normN(r);
    }
}

export function BigNatModule_isZero(p) {
    return p.bound === 0;
}

export function BigNatModule_IsZero(p) {
    return BigNatModule_isZero(p);
}

export function BigNatModule_isOne(p) {
    if (p.bound === 1) {
        return p.digits[0] === 1;
    }
    else {
        return false;
    }
}

export function BigNatModule_equal(p, q) {
    if (p.bound === q.bound) {
        const check = (pa_mut, qa_mut, i_mut) => {
            check:
            while (true) {
                const pa = pa_mut, qa = qa_mut, i = i_mut;
                if (i === -1) {
                    return true;
                }
                else if (pa[i] === qa[i]) {
                    pa_mut = pa;
                    qa_mut = qa;
                    i_mut = (i - 1);
                    continue check;
                }
                else {
                    return false;
                }
                break;
            }
        };
        return check(p.digits, q.digits, p.bound - 1);
    }
    else {
        return false;
    }
}

export function BigNatModule_shiftCompare(p, pn, q, qn) {
    if ((p.bound + pn) < (q.bound + qn)) {
        return -1;
    }
    else if ((p.bound + pn) > (q.bound + pn)) {
        return 1;
    }
    else {
        const check = (pa_mut, qa_mut, i_mut) => {
            check:
            while (true) {
                const pa = pa_mut, qa = qa_mut, i = i_mut;
                if (i === -1) {
                    return 0;
                }
                else {
                    const pai = ((i < pn) ? 0 : pa[i - pn]) | 0;
                    const qai = ((i < qn) ? 0 : qa[i - qn]) | 0;
                    if (pai === qai) {
                        pa_mut = pa;
                        qa_mut = qa;
                        i_mut = (i - 1);
                        continue check;
                    }
                    else if (pai < qai) {
                        return -1;
                    }
                    else {
                        return 1;
                    }
                }
                break;
            }
        };
        return check(p.digits, q.digits, (p.bound + pn) - 1) | 0;
    }
}

export function BigNatModule_compare(p, q) {
    if (p.bound < q.bound) {
        return -1;
    }
    else if (p.bound > q.bound) {
        return 1;
    }
    else {
        const check = (pa_mut, qa_mut, i_mut) => {
            check:
            while (true) {
                const pa = pa_mut, qa = qa_mut, i = i_mut;
                if (i === -1) {
                    return 0;
                }
                else if (pa[i] === qa[i]) {
                    pa_mut = pa;
                    qa_mut = qa;
                    i_mut = (i - 1);
                    continue check;
                }
                else if (pa[i] < qa[i]) {
                    return -1;
                }
                else {
                    return 1;
                }
                break;
            }
        };
        return check(p.digits, q.digits, p.bound - 1) | 0;
    }
}

export function BigNatModule_lt(p, q) {
    return BigNatModule_compare(p, q) === -1;
}

export function BigNatModule_gt(p, q) {
    return BigNatModule_compare(p, q) === 1;
}

export function BigNatModule_lte(p, q) {
    return BigNatModule_compare(p, q) !== 1;
}

export function BigNatModule_gte(p, q) {
    return BigNatModule_compare(p, q) !== -1;
}

export function BigNatModule_min(a, b) {
    if (BigNatModule_lt(a, b)) {
        return a;
    }
    else {
        return b;
    }
}

export function BigNatModule_max(a, b) {
    if (BigNatModule_lt(a, b)) {
        return b;
    }
    else {
        return a;
    }
}

export function BigNatModule_contributeArr(a_mut, i_mut, c_mut) {
    BigNatModule_contributeArr:
    while (true) {
        const a = a_mut, i = i_mut, c = c_mut;
        const x = op_Addition(fromInteger(a[i], false, 2), c);
        const c_1 = op_Division(x, BigNatModule_baseNi64);
        const x_3 = (~(~toInt(op_BitwiseAnd(x, BigNatModule_baseMaski64)))) | 0;
        a[i] = (x_3 | 0);
        if (compare(c_1, fromBits(0, 0, false)) > 0) {
            a_mut = a;
            i_mut = (i + 1);
            c_mut = c_1;
            continue BigNatModule_contributeArr;
        }
        break;
    }
}

export function BigNatModule_scale(k, p) {
    const r = BigNatModule_createN(p.bound + BigNatModule_boundInt);
    const k_1 = fromInteger(k, false, 2);
    for (let i = 0; i <= (p.bound - 1); i++) {
        BigNatModule_contributeArr(r.digits, i, op_Multiply(k_1, fromInteger(p.digits[i], false, 2)));
    }
    return BigNatModule_normN(r);
}

export function BigNatModule_mulSchoolBookBothSmall(p, q) {
    const r = BigNatModule_createN(2);
    const rak = op_Multiply(fromInteger(p, false, 2), fromInteger(q, false, 2));
    BigNatModule_setCoeff(r, 0, ~(~toInt(op_BitwiseAnd(rak, BigNatModule_baseMaski64))));
    BigNatModule_setCoeff(r, 1, ~(~toInt(op_Division(rak, BigNatModule_baseNi64))));
    return BigNatModule_normN(r);
}

export function BigNatModule_mulSchoolBookCarry(r_mut, c_mut, k_mut) {
    BigNatModule_mulSchoolBookCarry:
    while (true) {
        const r = r_mut, c = c_mut, k = k_mut;
        if (compare(c, fromBits(0, 0, false)) > 0) {
            const rak = op_Addition(BigNatModule_coeff64(r, k), c);
            BigNatModule_setCoeff(r, k, ~(~toInt(op_BitwiseAnd(rak, BigNatModule_baseMaski64))));
            r_mut = r;
            c_mut = op_Division(rak, BigNatModule_baseNi64);
            k_mut = (k + 1);
            continue BigNatModule_mulSchoolBookCarry;
        }
        break;
    }
}

export function BigNatModule_mulSchoolBookOneSmall(p, q) {
    const bp = BigNatModule_bound(p) | 0;
    const r = BigNatModule_createN(bp + 1);
    const q_1 = fromInteger(q, false, 2);
    let c = fromBits(0, 0, false);
    for (let i = 0; i <= (bp - 1); i++) {
        const rak = op_Addition(op_Addition(c, BigNatModule_coeff64(r, i)), op_Multiply(BigNatModule_coeff64(p, i), q_1));
        BigNatModule_setCoeff(r, i, ~(~toInt(op_BitwiseAnd(rak, BigNatModule_baseMaski64))));
        c = op_Division(rak, BigNatModule_baseNi64);
    }
    BigNatModule_mulSchoolBookCarry(r, c, bp);
    return BigNatModule_normN(r);
}

export function BigNatModule_mulSchoolBookNeitherSmall(p, q) {
    const r = BigNatModule_createN(p.bound + q.bound);
    const ra = r.digits;
    for (let i = 0; i <= (p.bound - 1); i++) {
        const pai = fromInteger(p.digits[i], false, 2);
        let c = fromBits(0, 0, false);
        let k = i;
        for (let j = 0; j <= (q.bound - 1); j++) {
            const qaj = fromInteger(q.digits[j], false, 2);
            const rak = op_Addition(op_Addition(fromInteger(ra[k], false, 2), c), op_Multiply(pai, qaj));
            ra[k] = ((~(~toInt(op_BitwiseAnd(rak, BigNatModule_baseMaski64)))) | 0);
            c = op_Division(rak, BigNatModule_baseNi64);
            k = ((k + 1) | 0);
        }
        BigNatModule_mulSchoolBookCarry(r, c, k);
    }
    return BigNatModule_normN(r);
}

export function BigNatModule_mulSchoolBook(p, q) {
    const pSmall = BigNatModule_bound(p) === 1;
    const qSmall = BigNatModule_bound(q) === 1;
    if (pSmall && qSmall) {
        return BigNatModule_mulSchoolBookBothSmall(BigNatModule_coeff(p, 0), BigNatModule_coeff(q, 0));
    }
    else if (pSmall) {
        return BigNatModule_mulSchoolBookOneSmall(q, BigNatModule_coeff(p, 0));
    }
    else if (qSmall) {
        return BigNatModule_mulSchoolBookOneSmall(p, BigNatModule_coeff(q, 0));
    }
    else {
        return BigNatModule_mulSchoolBookNeitherSmall(p, q);
    }
}

export class BigNatModule_encoding extends Record {
    constructor(bigL, twoToBigL, k, bigK, bigN, split, splits) {
        super();
        this.bigL = (bigL | 0);
        this.twoToBigL = (twoToBigL | 0);
        this.k = (k | 0);
        this.bigK = (bigK | 0);
        this.bigN = (bigN | 0);
        this.split = (split | 0);
        this.splits = splits;
    }
}

export function BigNatModule_encoding$reflection() {
    return record_type("BigInt.BigNatModule.encoding", [], BigNatModule_encoding, () => [["bigL", int32_type], ["twoToBigL", int32_type], ["k", int32_type], ["bigK", int32_type], ["bigN", int32_type], ["split", int32_type], ["splits", array_type(int32_type)]]);
}

export function BigNatModule_mkEncoding(bigL, k, bigK, bigN) {
    return new BigNatModule_encoding(bigL, BigNatModule_pow32(2, bigL), k, bigK, bigN, ~(~(BigNatModule_baseBits / bigL)), initialize(~(~(BigNatModule_baseBits / bigL)), (i) => BigNatModule_pow32(2, bigL * i), Int32Array));
}

export const BigNatModule_table = [BigNatModule_mkEncoding(1, 28, 268435456, 268435456), BigNatModule_mkEncoding(2, 26, 67108864, 134217728), BigNatModule_mkEncoding(3, 24, 16777216, 50331648), BigNatModule_mkEncoding(4, 22, 4194304, 16777216), BigNatModule_mkEncoding(5, 20, 1048576, 5242880), BigNatModule_mkEncoding(6, 18, 262144, 1572864), BigNatModule_mkEncoding(7, 16, 65536, 458752), BigNatModule_mkEncoding(8, 14, 16384, 131072), BigNatModule_mkEncoding(9, 12, 4096, 36864), BigNatModule_mkEncoding(10, 10, 1024, 10240), BigNatModule_mkEncoding(11, 8, 256, 2816), BigNatModule_mkEncoding(12, 6, 64, 768), BigNatModule_mkEncoding(13, 4, 16, 208)];

export function BigNatModule_calculateTableTow(bigL) {
    const k = (BigNatModule_FFT_maxBitsInsideFp - (2 * bigL)) | 0;
    const bigK = BigNatModule_pow64(fromBits(2, 0, false), k);
    return [bigL, k, bigK, op_Multiply(bigK, fromInteger(bigL, false, 2))];
}

export function BigNatModule_encodingGivenResultBits(bitsRes) {
    const selectFrom = (i_mut) => {
        selectFrom:
        while (true) {
            const i = i_mut;
            if (((i + 1) < BigNatModule_table.length) && (bitsRes < BigNatModule_table[i + 1].bigN)) {
                i_mut = (i + 1);
                continue selectFrom;
            }
            else {
                return BigNatModule_table[i];
            }
            break;
        }
    };
    if (bitsRes >= BigNatModule_table[0].bigN) {
        throw (new Error("Product is huge, around 268435456 bits, beyond quickmul"));
    }
    else {
        return selectFrom(0);
    }
}

export const BigNatModule_bitmask = initialize(BigNatModule_baseBits, (i) => (BigNatModule_pow32(2, i) - 1), Int32Array);

export const BigNatModule_twopowers = initialize(BigNatModule_baseBits, (i) => BigNatModule_pow32(2, i), Int32Array);

export const BigNatModule_twopowersI64 = initialize(BigNatModule_baseBits, (i) => BigNatModule_pow64(fromBits(2, 0, false), i));

export function BigNatModule_wordBits(word) {
    const hi = (k_mut) => {
        hi:
        while (true) {
            const k = k_mut;
            if (k === 0) {
                return 0;
            }
            else if ((word & BigNatModule_twopowers[k - 1]) !== 0) {
                return k | 0;
            }
            else {
                k_mut = (k - 1);
                continue hi;
            }
            break;
        }
    };
    return hi(BigNatModule_baseBits) | 0;
}

export function BigNatModule_bits(u) {
    if (u.bound === 0) {
        return 0;
    }
    else {
        return ((BigNatModule_degree(u) * BigNatModule_baseBits) + BigNatModule_wordBits(u.digits[BigNatModule_degree(u)])) | 0;
    }
}

export function BigNatModule_extractBits(n, enc, bi) {
    let z, i, z_1, i_1, z_2, i_2;
    const biw = (~(~(bi / BigNatModule_baseBits))) | 0;
    const bjw = (~(~(((bi + enc.bigL) - 1) / BigNatModule_baseBits))) | 0;
    if (biw !== bjw) {
        const xbit = (bi % BigNatModule_baseBits) | 0;
        return (((((z = n, (i = (biw | 0), (i < z.bound) ? z.digits[i] : 0))) >> xbit) | (((z_1 = n, (i_1 = (bjw | 0), (i_1 < z_1.bound) ? z_1.digits[i_1] : 0))) << (BigNatModule_baseBits - xbit))) & BigNatModule_bitmask[enc.bigL]) | 0;
    }
    else {
        return ((((z_2 = n, (i_2 = (biw | 0), (i_2 < z_2.bound) ? z_2.digits[i_2] : 0))) >> (bi % BigNatModule_baseBits)) & BigNatModule_bitmask[enc.bigL]) | 0;
    }
}

export function BigNatModule_encodePoly(enc, n) {
    const poly = fill(new Uint32Array(enc.bigK), 0, enc.bigK, BigNatModule_FFT_Fp_ofInt32(0));
    const biMax = (n.bound * BigNatModule_baseBits) | 0;
    const encoder = (i_mut, bi_mut) => {
        encoder:
        while (true) {
            const i = i_mut, bi = bi_mut;
            if ((i === enc.bigK) ? true : (bi > biMax)) {
            }
            else {
                const pi = BigNatModule_extractBits(n, enc, bi) | 0;
                poly[i] = BigNatModule_FFT_Fp_ofInt32(pi);
                i_mut = (i + 1);
                bi_mut = (bi + enc.bigL);
                continue encoder;
            }
            break;
        }
    };
    encoder(0, 0);
    return poly;
}

export function BigNatModule_decodeResultBits(enc, poly) {
    let n = 0;
    for (let i = 0; i <= (poly.length - 1); i++) {
        if (poly[i] !== BigNatModule_FFT_mzero) {
            n = (i | 0);
        }
    }
    return (((BigNatModule_FFT_maxBitsInsideFp + (enc.bigL * n)) + 1) + 1) | 0;
}

export function BigNatModule_decodePoly(enc, poly) {
    const rbound = ((~(~(BigNatModule_decodeResultBits(enc, poly) / BigNatModule_baseBits))) + 1) | 0;
    const r = BigNatModule_createN(rbound);
    const evaluate = (i_mut, j_mut, d_mut) => {
        evaluate:
        while (true) {
            const i = i_mut, j = j_mut, d = d_mut;
            if (i === enc.bigK) {
            }
            else {
                if (j >= rbound) {
                }
                else {
                    BigNatModule_contributeArr(r.digits, j, op_Multiply(fromInteger(BigNatModule_FFT_Fp_toInt(poly[i]), false, 2), BigNatModule_twopowersI64[d]));
                }
                const d_1 = (d + enc.bigL) | 0;
                const patternInput = (d_1 >= BigNatModule_baseBits) ? [j + 1, d_1 - BigNatModule_baseBits] : [j, d_1];
                i_mut = (i + 1);
                j_mut = patternInput[0];
                d_mut = patternInput[1];
                continue evaluate;
            }
            break;
        }
    };
    evaluate(0, 0, 0);
    return BigNatModule_normN(r);
}

export function BigNatModule_quickMulUsingFft(u, v) {
    const enc = BigNatModule_encodingGivenResultBits(BigNatModule_bits(u) + BigNatModule_bits(v));
    return BigNatModule_normN(BigNatModule_decodePoly(enc, BigNatModule_FFT_computeFftPaddedPolynomialProduct(enc.bigK, enc.k, BigNatModule_encodePoly(enc, u), BigNatModule_encodePoly(enc, v))));
}

export const BigNatModule_minDigitsKaratsuba = 16;

export function BigNatModule_recMulKaratsuba(mul, p, q) {
    const bmax = BigNatModule_maxInt(p.bound, q.bound) | 0;
    if (bmax > BigNatModule_minDigitsKaratsuba) {
        const k = (~(~(bmax / 2))) | 0;
        const a0 = BigNatModule_restrictTo(k, p);
        const a1 = BigNatModule_shiftDown(k, p);
        const b0 = BigNatModule_restrictTo(k, q);
        const b1 = BigNatModule_shiftDown(k, q);
        const q0 = mul(a0, b0);
        const q1 = mul(BigNatModule_add(a0, a1), BigNatModule_add(b0, b1));
        const q2 = mul(a1, b1);
        return BigNatModule_add(q0, BigNatModule_shiftUp(k, BigNatModule_add(BigNatModule_sub(q1, BigNatModule_add(q0, q2)), BigNatModule_shiftUp(k, q2))));
    }
    else {
        return BigNatModule_mulSchoolBook(p, q);
    }
}

export function BigNatModule_mulKaratsuba(x, y) {
    return BigNatModule_recMulKaratsuba(BigNatModule_mulKaratsuba, x, y);
}

export const BigNatModule_productDigitsUpperSchoolBook = ~(~(64000 / BigNatModule_baseBits));

export const BigNatModule_singleDigitForceSchoolBook = ~(~(32000 / BigNatModule_baseBits));

export const BigNatModule_productDigitsUpperFft = ~(~(BigNatModule_table[0].bigN / BigNatModule_baseBits));

export function BigNatModule_mul(p, q) {
    return BigNatModule_mulSchoolBook(p, q);
}

export function BigNatModule_scaleSubInPlace(x, f, a, n) {
    const patternInput = [x.digits, BigNatModule_degree(x)];
    const x_1 = patternInput[0];
    const patternInput_1 = [a.digits, BigNatModule_degree(a)];
    const ad = patternInput_1[1] | 0;
    const a_1 = patternInput_1[0];
    const f_1 = fromInteger(f, false, 2);
    let j = 0;
    let z = op_Multiply(f_1, fromInteger(a_1[0], false, 2));
    while ((compare(z, fromBits(0, 0, false)) > 0) ? true : (j < ad)) {
        if (j > patternInput[1]) {
            throw (new Error("scaleSubInPlace: pre-condition did not apply, result would be -ve"));
        }
        let zLo = ~(~toInt(op_BitwiseAnd(z, BigNatModule_baseMaski64)));
        let zHi = op_Division(z, BigNatModule_baseNi64);
        if (zLo <= x_1[j + n]) {
            x_1[j + n] = ((x_1[j + n] - zLo) | 0);
        }
        else {
            x_1[j + n] = ((x_1[j + n] + (BigNatModule_baseN - zLo)) | 0);
            zHi = op_Addition(zHi, fromBits(1, 0, false));
        }
        if (j < ad) {
            z = op_Addition(zHi, op_Multiply(f_1, fromInteger(a_1[j + 1], false, 2)));
        }
        else {
            z = zHi;
        }
        j = ((j + 1) | 0);
    }
    BigNatModule_normN(x);
}

export function BigNatModule_scaleSub(x, f, a, n) {
    const freshx = BigNatModule_add(x, BigNatModule_zero);
    BigNatModule_scaleSubInPlace(freshx, f, a, n);
    return BigNatModule_normN(freshx);
}

export function BigNatModule_scaleAddInPlace(x, f, a, n) {
    const patternInput = [x.digits, BigNatModule_degree(x)];
    const x_1 = patternInput[0];
    const patternInput_1 = [a.digits, BigNatModule_degree(a)];
    const ad = patternInput_1[1] | 0;
    const a_1 = patternInput_1[0];
    const f_1 = fromInteger(f, false, 2);
    let j = 0;
    let z = op_Multiply(f_1, fromInteger(a_1[0], false, 2));
    while ((compare(z, fromBits(0, 0, false)) > 0) ? true : (j < ad)) {
        if (j > patternInput[1]) {
            throw (new Error("scaleSubInPlace: pre-condition did not apply, result would be -ve"));
        }
        let zLo = ~(~toInt(op_BitwiseAnd(z, BigNatModule_baseMaski64)));
        let zHi = op_Division(z, BigNatModule_baseNi64);
        if (zLo < (BigNatModule_baseN - x_1[j + n])) {
            x_1[j + n] = ((x_1[j + n] + zLo) | 0);
        }
        else {
            x_1[j + n] = ((zLo - (BigNatModule_baseN - x_1[j + n])) | 0);
            zHi = op_Addition(zHi, fromBits(1, 0, false));
        }
        if (j < ad) {
            z = op_Addition(zHi, op_Multiply(f_1, fromInteger(a_1[j + 1], false, 2)));
        }
        else {
            z = zHi;
        }
        j = ((j + 1) | 0);
    }
    BigNatModule_normN(x);
}

export function BigNatModule_scaleAdd(x, f, a, n) {
    const freshx = BigNatModule_add(x, BigNatModule_zero);
    BigNatModule_scaleAddInPlace(freshx, f, a, n);
    return BigNatModule_normN(freshx);
}

export function BigNatModule_removeFactor(x, a, n) {
    const patternInput = [BigNatModule_degree(a), BigNatModule_degree(x)];
    const degx = patternInput[1] | 0;
    const dega = patternInput[0] | 0;
    if (degx < (dega + n)) {
        return 0;
    }
    else {
        const patternInput_1 = [a.digits, x.digits];
        const xa = patternInput_1[1];
        const aa = patternInput_1[0];
        const f = ((dega === 0) ? ((degx === n) ? (~(~(xa[n] / aa[0]))) : (~(~toInt(op_Division(op_Addition(op_Multiply(fromInteger(xa[degx], false, 2), BigNatModule_baseNi64), fromInteger(xa[degx - 1], false, 2)), fromInteger(aa[0], false, 2)))))) : ((degx === (dega + n)) ? (~(~(xa[degx] / (aa[dega] + 1)))) : (~(~toInt(op_Division(op_Addition(op_Multiply(fromInteger(xa[degx], false, 2), BigNatModule_baseNi64), fromInteger(xa[degx - 1], false, 2)), op_Addition(fromInteger(aa[dega], false, 2), fromBits(1, 0, false)))))))) | 0;
        if (f === 0) {
            if (BigNatModule_shiftCompare(a, n, x, 0) !== 1) {
                return 1;
            }
            else {
                return 0;
            }
        }
        else {
            return f | 0;
        }
    }
}

export function BigNatModule_divmod(b, a) {
    if (BigNatModule_isZero(a)) {
        throw (new Error());
    }
    else if (BigNatModule_degree(b) < BigNatModule_degree(a)) {
        return [BigNatModule_zero, b];
    }
    else {
        const x = BigNatModule_copyN(b);
        const d = BigNatModule_createN(((BigNatModule_degree(b) - BigNatModule_degree(a)) + 1) + 1);
        let p = BigNatModule_degree(b);
        const m = BigNatModule_degree(a) | 0;
        let n = p - m;
        const Invariant = (tupledArg) => {
        };
        let finished = false;
        while (!finished) {
            Invariant([d, x, n, p]);
            const f = BigNatModule_removeFactor(x, a, n) | 0;
            if (f > 0) {
                BigNatModule_scaleSubInPlace(x, f, a, n);
                BigNatModule_scaleAddInPlace(d, f, BigNatModule_one, n);
                Invariant([d, x, n, p]);
            }
            else {
                finished = ((f === 0) && (n === 0));
                if (!finished) {
                    if (p === (m + n)) {
                        Invariant([d, x, n - 1, p]);
                        n = ((n - 1) | 0);
                    }
                    else {
                        Invariant([d, x, n - 1, p - 1]);
                        n = ((n - 1) | 0);
                        p = ((p - 1) | 0);
                    }
                }
            }
        }
        return [BigNatModule_normN(d), BigNatModule_normN(x)];
    }
}

export function BigNatModule_div(b, a) {
    return BigNatModule_divmod(b, a)[0];
}

export function BigNatModule_rem(b, a) {
    return BigNatModule_divmod(b, a)[1];
}

export function BigNatModule_bitAnd(a, b) {
    const r = BigNatModule_createN(BigNatModule_minInt(a.bound, b.bound));
    for (let i = 0; i <= (r.bound - 1); i++) {
        r.digits[i] = ((a.digits[i] & b.digits[i]) | 0);
    }
    return BigNatModule_normN(r);
}

export function BigNatModule_bitOr(a, b) {
    const r = BigNatModule_createN(BigNatModule_maxInt(a.bound, b.bound));
    for (let i = 0; i <= (a.bound - 1); i++) {
        r.digits[i] = ((r.digits[i] | a.digits[i]) | 0);
    }
    for (let i_1 = 0; i_1 <= (b.bound - 1); i_1++) {
        r.digits[i_1] = ((r.digits[i_1] | b.digits[i_1]) | 0);
    }
    return BigNatModule_normN(r);
}

export function BigNatModule_bitXor(a, b) {
    const r = BigNatModule_createN(BigNatModule_maxInt(a.bound, b.bound));
    for (let i = 0; i <= (a.bound - 1); i++) {
        r.digits[i] = ((r.digits[i] ^ a.digits[i]) | 0);
    }
    for (let i_1 = 0; i_1 <= (b.bound - 1); i_1++) {
        r.digits[i_1] = ((r.digits[i_1] ^ b.digits[i_1]) | 0);
    }
    return BigNatModule_normN(r);
}

export function BigNatModule_hcf(a, b) {
    const hcfloop = (a_1_mut, b_1_mut) => {
        hcfloop:
        while (true) {
            const a_1 = a_1_mut, b_1 = b_1_mut;
            if (BigNatModule_equal(BigNatModule_zero, a_1)) {
                return b_1;
            }
            else {
                a_1_mut = BigNatModule_divmod(b_1, a_1)[1];
                b_1_mut = a_1;
                continue hcfloop;
            }
            break;
        }
    };
    if (BigNatModule_lt(a, b)) {
        return hcfloop(a, b);
    }
    else {
        return hcfloop(b, a);
    }
}

export const BigNatModule_two = BigNatModule_embed(2);

export function BigNatModule_powi(x, n) {
    const power = (acc_mut, x_1_mut, n_1_mut) => {
        power:
        while (true) {
            const acc = acc_mut, x_1 = x_1_mut, n_1 = n_1_mut;
            if (n_1 === 0) {
                return acc;
            }
            else if ((n_1 % 2) === 0) {
                acc_mut = acc;
                x_1_mut = BigNatModule_mul(x_1, x_1);
                n_1_mut = (~(~(n_1 / 2)));
                continue power;
            }
            else {
                acc_mut = BigNatModule_mul(x_1, acc);
                x_1_mut = BigNatModule_mul(x_1, x_1);
                n_1_mut = (~(~(n_1 / 2)));
                continue power;
            }
            break;
        }
    };
    return power(BigNatModule_one, x, n);
}

export function BigNatModule_pow(x, n) {
    const power = (acc_mut, x_1_mut, n_1_mut) => {
        power:
        while (true) {
            const acc = acc_mut, x_1 = x_1_mut, n_1 = n_1_mut;
            if (BigNatModule_isZero(n_1)) {
                return acc;
            }
            else {
                const patternInput = BigNatModule_divmod(n_1, BigNatModule_two);
                const ndiv2 = patternInput[0];
                if (BigNatModule_isZero(patternInput[1])) {
                    acc_mut = acc;
                    x_1_mut = BigNatModule_mul(x_1, x_1);
                    n_1_mut = ndiv2;
                    continue power;
                }
                else {
                    acc_mut = BigNatModule_mul(x_1, acc);
                    x_1_mut = BigNatModule_mul(x_1, x_1);
                    n_1_mut = ndiv2;
                    continue power;
                }
            }
            break;
        }
    };
    return power(BigNatModule_one, x, n);
}

export function BigNatModule_toFloat(n) {
    const evalFloat = (acc_mut, k_mut, i_mut) => {
        evalFloat:
        while (true) {
            const acc = acc_mut, k = k_mut, i = i_mut;
            if (i === n.bound) {
                return acc;
            }
            else {
                acc_mut = (acc + (k * n.digits[i]));
                k_mut = (k * BigNatModule_baseN);
                i_mut = (i + 1);
                continue evalFloat;
            }
            break;
        }
    };
    return evalFloat(0, 1, 0);
}

export function BigNatModule_ofInt32(n) {
    return BigNatModule_embed(n);
}

export function BigNatModule_ofInt64(n) {
    return BigNatModule_embed64(n);
}

export function BigNatModule_toUInt32(n) {
    const matchValue = n.bound | 0;
    switch (matchValue) {
        case 0: {
            return 0;
        }
        case 1: {
            const value = n.digits[0] | 0;
            return value >>> 0;
        }
        case 2: {
            const patternInput = [n.digits[0], n.digits[1]];
            const xB = patternInput[1] | 0;
            if (xB > BigNatModule_baseMask32B) {
                throw (new Error());
            }
            return ((patternInput[0] & BigNatModule_baseMask32A) >>> 0) + ((((xB & BigNatModule_baseMask32B) >>> 0) << BigNatModule_baseShift32B) >>> 0);
        }
        default: {
            throw (new Error());
        }
    }
}

export function BigNatModule_toUInt64(n) {
    const matchValue = n.bound | 0;
    switch (matchValue) {
        case 0: {
            return fromBits(0, 0, true);
        }
        case 1: {
            return fromInteger(n.digits[0], true, 2);
        }
        case 2: {
            const patternInput = [n.digits[0], n.digits[1]];
            return op_Addition(fromInteger(patternInput[0] & BigNatModule_baseMask64A, true, 2), op_LeftShift(fromInteger(patternInput[1] & BigNatModule_baseMask64B, true, 2), BigNatModule_baseShift64B));
        }
        case 3: {
            const patternInput_1 = [n.digits[0], n.digits[1], n.digits[2]];
            const xC = patternInput_1[2] | 0;
            if (xC > BigNatModule_baseMask64C) {
                throw (new Error());
            }
            return op_Addition(op_Addition(fromInteger(patternInput_1[0] & BigNatModule_baseMask64A, true, 2), op_LeftShift(fromInteger(patternInput_1[1] & BigNatModule_baseMask64B, true, 2), BigNatModule_baseShift64B)), op_LeftShift(fromInteger(xC & BigNatModule_baseMask64C, true, 2), BigNatModule_baseShift64C));
        }
        default: {
            throw (new Error());
        }
    }
}

export function BigNatModule_toString(n) {
    const degn = BigNatModule_degree(n) | 0;
    const route = (prior_mut, k_mut, ten2k_mut) => {
        route:
        while (true) {
            const prior = prior_mut, k = k_mut, ten2k = ten2k_mut;
            if (BigNatModule_degree(ten2k) > degn) {
                return cons([k, ten2k], prior);
            }
            else {
                prior_mut = cons([k, ten2k], prior);
                k_mut = (k + 1);
                ten2k_mut = BigNatModule_mul(ten2k, ten2k);
                continue route;
            }
            break;
        }
    };
    const collect = (isLeading_mut, digits_mut, n_1_mut, _arg1_mut) => {
        collect:
        while (true) {
            const isLeading = isLeading_mut, digits = digits_mut, n_1 = n_1_mut, _arg1 = _arg1_mut;
            if (!isEmpty(_arg1)) {
                const prior_1 = tail(_arg1);
                const patternInput = BigNatModule_divmod(n_1, head(_arg1)[1]);
                const nL = patternInput[1];
                const nH = patternInput[0];
                if (isLeading && BigNatModule_isZero(nH)) {
                    isLeading_mut = isLeading;
                    digits_mut = digits;
                    n_1_mut = nL;
                    _arg1_mut = prior_1;
                    continue collect;
                }
                else {
                    isLeading_mut = isLeading;
                    digits_mut = collect(false, digits, nL, prior_1);
                    n_1_mut = nH;
                    _arg1_mut = prior_1;
                    continue collect;
                }
            }
            else {
                const n_2 = BigNatModule_eval32(n_1) | 0;
                if (isLeading && (n_2 === 0)) {
                    return digits;
                }
                else {
                    return cons(int32ToString(n_2), digits);
                }
            }
            break;
        }
    };
    const digits_4 = collect(true, empty(), n, route(empty(), 0, BigNatModule_embed(10)));
    if (isEmpty(digits_4)) {
        return "0";
    }
    else {
        return join("", toArray(digits_4));
    }
}

export function BigNatModule_ofString(str) {
    const len = str.length | 0;
    if (isNullOrEmpty(str)) {
        throw (new Error("empty string\\nParameter name: str"));
    }
    const ten = BigNatModule_embed(10);
    const build = (acc_mut, i_mut) => {
        build:
        while (true) {
            const acc = acc_mut, i = i_mut;
            if (i === len) {
                return acc;
            }
            else {
                const c = str[i];
                const d = (c.charCodeAt(0) - 48) | 0;
                if ((0 <= d) && (d <= 9)) {
                    acc_mut = BigNatModule_add(BigNatModule_mul(ten, acc), BigNatModule_embed(d));
                    i_mut = (i + 1);
                    continue build;
                }
                else {
                    throw (new Error());
                }
            }
            break;
        }
    };
    return build(BigNatModule_embed(0), 0);
}

export function BigNatModule_isSmall(n) {
    return n.bound <= 1;
}

export function BigNatModule_getSmall(n) {
    const z = n;
    const i = 0;
    if (i < z.bound) {
        return z.digits[i] | 0;
    }
    else {
        return 0;
    }
}

export function BigNatModule_factorial(n) {
    const productR = (a, b) => {
        if (BigNatModule_equal(a, b)) {
            return a;
        }
        else {
            const m = BigNatModule_div(BigNatModule_add(a, b), BigNatModule_ofInt32(2));
            return BigNatModule_mul(productR(a, m), productR(BigNatModule_add(m, BigNatModule_one), b));
        }
    };
    return productR(BigNatModule_one, n);
}

