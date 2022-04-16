// import Decimal, { makeRangeStepFunction as makeDecimalRangeStepFunction } from "./Decimal.js";
// import Long, { makeRangeStepFunction as makeLongRangeStepFunction } from "./Long.js";
import { some, value } from "./Option.js";
import { compare, equals } from "./Util.js";
export class Enumerator {
    constructor(iter) {
        this.iter = iter;
    }
    ["System.Collections.Generic.IEnumerator`1.get_Current"]() {
        return this.current;
    }
    ["System.Collections.IEnumerator.get_Current"]() {
        return this.current;
    }
    ["System.Collections.IEnumerator.MoveNext"]() {
        const cur = this.iter.next();
        this.current = cur.value;
        return !cur.done;
    }
    ["System.Collections.IEnumerator.Reset"]() {
        throw new Error("JS iterators cannot be reset");
    }
    Dispose() {
        return;
    }
}
export function getEnumerator(o) {
    return typeof o.GetEnumerator === "function"
        ? o.GetEnumerator()
        : new Enumerator(o[Symbol.iterator]());
}
export function toIterator(en) {
    return {
        [Symbol.iterator]() { return this; },
        next() {
            const hasNext = en["System.Collections.IEnumerator.MoveNext"]();
            const current = hasNext ? en["System.Collections.IEnumerator.get_Current"]() : undefined;
            return { done: !hasNext, value: current };
        },
    };
}
// export function toIterable<T>(en: IEnumerable<T>): Iterable<T> {
//   return {
//     [Symbol.iterator]() {
//       return toIterator(en.GetEnumerator());
//     },
//   };
// }
function __failIfNone(res) {
    if (res == null) {
        throw new Error("Seq did not contain any matching element");
    }
    return value(res);
}
class Seq {
    constructor(f) {
        this.f = f;
    }
    [Symbol.iterator]() { return new Seq(this.f); }
    next() {
        var _a;
        this.iter = (_a = this.iter) !== null && _a !== void 0 ? _a : this.f();
        return this.iter.next();
    }
    toString() {
        return "seq [" + Array.from(this).join("; ") + "]";
    }
}
function makeSeq(f) {
    return new Seq(f);
}
function isArrayOrBufferView(xs) {
    return Array.isArray(xs) || ArrayBuffer.isView(xs);
}
export function ofArray(xs) {
    if (Array.isArray(xs)) {
        return delay(() => xs);
    }
    else {
        return delay(() => unfold((i) => i != null && i < xs.length ? [xs[i], i + 1] : undefined, 0));
    }
}
export function allPairs(xs, ys) {
    let firstEl = true;
    const ysCache = [];
    return collect((x) => {
        if (firstEl) {
            firstEl = false;
            return map((y) => {
                ysCache.push(y);
                return [x, y];
            }, ys);
        }
        else {
            return ysCache.map((y) => [x, y]);
            // return map(function (i) {
            //     return [x, ysCache[i]];
            // }, rangeNumber(0, 1, ysCache.length - 1));
        }
    }, xs);
}
export function append(xs, ys) {
    return delay(() => {
        let firstDone = false;
        const i = xs[Symbol.iterator]();
        let iters = [i, undefined];
        return unfold(() => {
            var _a, _b;
            let cur;
            if (!firstDone) {
                cur = (_a = iters[0]) === null || _a === void 0 ? void 0 : _a.next();
                if (cur != null && !cur.done) {
                    return [cur.value, iters];
                }
                else {
                    firstDone = true;
                    iters = [undefined, ys[Symbol.iterator]()];
                }
            }
            cur = (_b = iters[1]) === null || _b === void 0 ? void 0 : _b.next();
            return cur != null && !cur.done ? [cur.value, iters] : undefined;
        }, iters);
    });
}
export function average(xs, averager) {
    let count = 0;
    const total = fold((acc, x) => {
        count++;
        return averager.Add(acc, x);
    }, averager.GetZero(), xs);
    return averager.DivideByInt(total, count);
}
export function averageBy(f, xs, averager) {
    let count = 0;
    const total = fold((acc, x) => {
        count++;
        return averager.Add(acc, f(x));
    }, averager.GetZero(), xs);
    return averager.DivideByInt(total, count);
}
export function concat(xs) {
    return delay(() => {
        const iter = xs[Symbol.iterator]();
        let output;
        return unfold((innerIter) => {
            let hasFinished = false;
            while (!hasFinished) {
                if (innerIter == null) {
                    const cur = iter.next();
                    if (!cur.done) {
                        innerIter = cur.value[Symbol.iterator]();
                    }
                    else {
                        hasFinished = true;
                    }
                }
                else {
                    const cur = innerIter.next();
                    if (!cur.done) {
                        output = cur.value;
                        hasFinished = true;
                    }
                    else {
                        innerIter = undefined;
                    }
                }
            }
            return innerIter != null ? [output, innerIter] : undefined;
        }, undefined);
    });
}
export function collect(f, xs) {
    return concat(map(f, xs));
}
export function choose(f, xs) {
    return delay(() => unfold((iter) => {
        let cur = iter.next();
        while (!cur.done) {
            const y = f(cur.value);
            if (y != null) {
                return [value(y), iter];
            }
            cur = iter.next();
        }
        return undefined;
    }, xs[Symbol.iterator]()));
}
export function compareWith(f, xs, ys) {
    if (xs === ys) {
        return 0;
    }
    let cur1;
    let cur2;
    let c = 0;
    for (const iter1 = xs[Symbol.iterator](), iter2 = ys[Symbol.iterator]();;) {
        cur1 = iter1.next();
        cur2 = iter2.next();
        if (cur1.done || cur2.done) {
            break;
        }
        c = f(cur1.value, cur2.value);
        if (c !== 0) {
            break;
        }
    }
    return (c !== 0) ? c : (cur1.done && !cur2.done) ? -1 : (!cur1.done && cur2.done) ? 1 : 0;
}
export function delay(f) {
    return makeSeq(() => f()[Symbol.iterator]());
}
export function empty() {
    return delay(() => []);
}
export function singleton(y) {
    return delay(() => [y]);
}
export function enumerateFromFunctions(factory, moveNext, current) {
    return delay(() => unfold((e) => moveNext(e) ? [current(e), e] : undefined, factory()));
}
export function enumerateWhile(cond, xs) {
    return concat(unfold(() => cond() ? [xs, true] : undefined, undefined));
}
export function enumerateThenFinally(xs, finalFn) {
    return delay(() => {
        let iter;
        try {
            iter = xs[Symbol.iterator]();
        }
        catch (err) {
            try {
                return empty();
            }
            finally {
                finalFn();
            }
        }
        return unfold((it) => {
            try {
                const cur = it.next();
                return !cur.done ? [cur.value, it] : undefined;
            }
            catch (err) {
                return undefined;
            }
            finally {
                finalFn();
            }
        }, iter);
    });
}
export function enumerateUsing(disp, work) {
    let isDisposed = false;
    const disposeOnce = () => {
        if (!isDisposed) {
            isDisposed = true;
            disp.Dispose();
        }
    };
    try {
        return enumerateThenFinally(work(disp), disposeOnce);
    }
    catch (err) {
        return void 0;
    }
    finally {
        disposeOnce();
    }
}
export function exactlyOne(xs) {
    const iter = xs[Symbol.iterator]();
    const fst = iter.next();
    if (fst.done) {
        throw new Error("Seq was empty");
    }
    const snd = iter.next();
    if (!snd.done) {
        throw new Error("Seq had multiple items");
    }
    return fst.value;
}
export function except(itemsToExclude, source) {
    const exclusionItems = Array.from(itemsToExclude);
    const testIsNotInExclusionItems = (element) => !exclusionItems.some((excludedItem) => equals(excludedItem, element));
    return filter(testIsNotInExclusionItems, source);
}
export function exists(f, xs) {
    let cur;
    for (const iter = xs[Symbol.iterator]();;) {
        cur = iter.next();
        if (cur.done) {
            break;
        }
        if (f(cur.value)) {
            return true;
        }
    }
    return false;
}
export function exists2(f, xs, ys) {
    let cur1;
    let cur2;
    for (const iter1 = xs[Symbol.iterator](), iter2 = ys[Symbol.iterator]();;) {
        cur1 = iter1.next();
        cur2 = iter2.next();
        if (cur1.done || cur2.done) {
            break;
        }
        if (f(cur1.value, cur2.value)) {
            return true;
        }
    }
    return false;
}
export function forAll(f, xs) {
    return !exists((x) => !f(x), xs);
}
export function forAll2(f, xs, ys) {
    return !exists2((x, y) => !f(x, y), xs, ys);
}
export function contains(i, xs) {
    return exists((x) => equals(x, i), xs);
}
export function filter(f, xs) {
    return delay(() => unfold((iter) => {
        let cur = iter.next();
        while (!cur.done) {
            if (f(cur.value)) {
                return [cur.value, iter];
            }
            cur = iter.next();
        }
        return undefined;
    }, xs[Symbol.iterator]()));
}
export function where(f, xs) {
    return filter(f, xs);
}
export function fold(f, acc, xs) {
    if (isArrayOrBufferView(xs)) {
        return xs.reduce(f, acc);
    }
    else {
        let cur;
        for (let i = 0, iter = xs[Symbol.iterator]();; i++) {
            cur = iter.next();
            if (cur.done) {
                break;
            }
            acc = f(acc, cur.value, i);
        }
        return acc;
    }
}
export function foldBack(f, xs, acc) {
    const arr = isArrayOrBufferView(xs) ? xs : Array.from(xs);
    for (let i = arr.length - 1; i >= 0; i--) {
        acc = f(arr[i], acc, i);
    }
    return acc;
}
export function fold2(f, acc, xs, ys) {
    const iter1 = xs[Symbol.iterator]();
    const iter2 = ys[Symbol.iterator]();
    let cur1;
    let cur2;
    for (let i = 0;; i++) {
        cur1 = iter1.next();
        cur2 = iter2.next();
        if (cur1.done || cur2.done) {
            break;
        }
        acc = f(acc, cur1.value, cur2.value, i);
    }
    return acc;
}
export function foldBack2(f, xs, ys, acc) {
    const ar1 = isArrayOrBufferView(xs) ? xs : Array.from(xs);
    const ar2 = isArrayOrBufferView(ys) ? ys : Array.from(ys);
    for (let i = ar1.length - 1; i >= 0; i--) {
        acc = f(ar1[i], ar2[i], acc, i);
    }
    return acc;
}
export function tryHead(xs) {
    const iter = xs[Symbol.iterator]();
    const cur = iter.next();
    return cur.done ? undefined : some(cur.value);
}
export function head(xs) {
    return __failIfNone(tryHead(xs));
}
export function initialize(n, f) {
    return delay(() => unfold((i) => i < n ? [f(i), i + 1] : undefined, 0));
}
export function initializeInfinite(f) {
    return delay(() => unfold((i) => [f(i), i + 1], 0));
}
export function tryItem(i, xs) {
    if (i < 0) {
        return undefined;
    }
    if (isArrayOrBufferView(xs)) {
        return i < xs.length ? some(xs[i]) : undefined;
    }
    for (let j = 0, iter = xs[Symbol.iterator]();; j++) {
        const cur = iter.next();
        if (cur.done) {
            break;
        }
        if (j === i) {
            return some(cur.value);
        }
    }
    return undefined;
}
export function item(i, xs) {
    return __failIfNone(tryItem(i, xs));
}
export function iterate(f, xs) {
    fold((_, x) => (f(x), undefined), undefined, xs);
}
export function iterate2(f, xs, ys) {
    fold2((_, x, y) => (f(x, y), undefined), undefined, xs, ys);
}
export function iterateIndexed(f, xs) {
    fold((_, x, i) => (f(i !== null && i !== void 0 ? i : 0, x), undefined), undefined, xs);
}
export function iterateIndexed2(f, xs, ys) {
    fold2((_, x, y, i) => (f(i !== null && i !== void 0 ? i : 0, x, y), undefined), undefined, xs, ys);
}
export function isEmpty(xs) {
    const i = xs[Symbol.iterator]();
    return i.next().done;
}
export function tryLast(xs) {
    return isEmpty(xs) ? undefined : some(reduce((_, x) => x, xs));
}
export function last(xs) {
    return __failIfNone(tryLast(xs));
}
export function length(xs) {
    return isArrayOrBufferView(xs)
        ? xs.length
        : fold((acc, _x) => acc + 1, 0, xs);
}
export function map(f, xs) {
    return delay(() => unfold((iter) => {
        const cur = iter.next();
        return !cur.done ? [f(cur.value), iter] : undefined;
    }, xs[Symbol.iterator]()));
}
export function mapIndexed(f, xs) {
    return delay(() => {
        let i = 0;
        return unfold((iter) => {
            const cur = iter.next();
            return !cur.done ? [f(i++, cur.value), iter] : undefined;
        }, xs[Symbol.iterator]());
    });
}
export function indexed(xs) {
    return mapIndexed((i, x) => [i, x], xs);
}
export function map2(f, xs, ys) {
    return delay(() => {
        const iter1 = xs[Symbol.iterator]();
        const iter2 = ys[Symbol.iterator]();
        return unfold(() => {
            const cur1 = iter1.next();
            const cur2 = iter2.next();
            return !cur1.done && !cur2.done ? [f(cur1.value, cur2.value), undefined] : undefined;
        }, undefined);
    });
}
export function mapIndexed2(f, xs, ys) {
    return delay(() => {
        let i = 0;
        const iter1 = xs[Symbol.iterator]();
        const iter2 = ys[Symbol.iterator]();
        return unfold(() => {
            const cur1 = iter1.next();
            const cur2 = iter2.next();
            return !cur1.done && !cur2.done ? [f(i++, cur1.value, cur2.value), undefined] : undefined;
        }, undefined);
    });
}
export function map3(f, xs, ys, zs) {
    return delay(() => {
        const iter1 = xs[Symbol.iterator]();
        const iter2 = ys[Symbol.iterator]();
        const iter3 = zs[Symbol.iterator]();
        return unfold(() => {
            const cur1 = iter1.next();
            const cur2 = iter2.next();
            const cur3 = iter3.next();
            return !cur1.done && !cur2.done && !cur3.done ? [f(cur1.value, cur2.value, cur3.value), undefined] : undefined;
        }, undefined);
    });
}
export function mapFold(f, acc, xs, transform) {
    const result = [];
    let r;
    let cur;
    for (let i = 0, iter = xs[Symbol.iterator]();; i++) {
        cur = iter.next();
        if (cur.done) {
            break;
        }
        [r, acc] = f(acc, cur.value);
        result.push(r);
    }
    return transform !== void 0 ? [transform(result), acc] : [result, acc];
}
export function mapFoldBack(f, xs, acc, transform) {
    const arr = isArrayOrBufferView(xs) ? xs : Array.from(xs);
    const result = [];
    let r;
    for (let i = arr.length - 1; i >= 0; i--) {
        [r, acc] = f(arr[i], acc);
        result.push(r);
    }
    return transform !== void 0 ? [transform(result), acc] : [result, acc];
}
export function max(xs, comparer) {
    const compareFn = comparer != null ? comparer.Compare : compare;
    return reduce((acc, x) => compareFn(acc, x) === 1 ? acc : x, xs);
}
export function maxBy(f, xs, comparer) {
    const compareFn = comparer != null ? comparer.Compare : compare;
    return reduce((acc, x) => compareFn(f(acc), f(x)) === 1 ? acc : x, xs);
}
export function min(xs, comparer) {
    const compareFn = comparer != null ? comparer.Compare : compare;
    return reduce((acc, x) => compareFn(acc, x) === -1 ? acc : x, xs);
}
export function minBy(f, xs, comparer) {
    const compareFn = comparer != null ? comparer.Compare : compare;
    return reduce((acc, x) => compareFn(f(acc), f(x)) === -1 ? acc : x, xs);
}
export function pairwise(xs) {
    return delay(() => {
        const iter = xs[Symbol.iterator]();
        const cur = iter.next();
        if (cur.done) {
            return empty();
        }
        const hd = cur.value;
        const tl = tail(xs);
        const ys = scan(([_, last], next) => [last, next], [hd, hd], tl);
        return skip(1, ys);
    });
}
// export function rangeChar(first: string, last: string) {
//   const firstNum = first.charCodeAt(0);
//   const lastNum = last.charCodeAt(0);
//   return delay(() => unfold((x) => x <= lastNum ? [String.fromCharCode(x), x + 1] : undefined, firstNum));
// }
// export function rangeLong(first: Long, step: Long, last: Long, unsigned: boolean): IterableIterator<Long> {
//   const stepFn = makeLongRangeStepFunction(step, last, unsigned) as (arg: Long) => Option<[Long, Long]>;
//   return delay(() => unfold(stepFn, first));
// }
// export function rangeDecimal(first: Decimal, step: Decimal, last: Decimal): IterableIterator<Decimal> {
//   const stepFn = makeDecimalRangeStepFunction(step, last) as (arg: Decimal) => Option<[Decimal, Decimal]>;
//   return delay(() => unfold(stepFn, first));
// }
// export function rangeNumber(first: number, step: number, last: number) {
//   if (step === 0) {
//     throw new Error("Step cannot be 0");
//   }
//   return delay(() => unfold((x) => step > 0 && x <= last || step < 0 && x >= last ? [x, x + step] : undefined, first));
// }
export function readOnly(xs) {
    return map((x) => x, xs);
}
export function reduce(f, xs) {
    if (isArrayOrBufferView(xs)) {
        return xs.reduce(f);
    }
    const iter = xs[Symbol.iterator]();
    let cur = iter.next();
    if (cur.done) {
        throw new Error("Seq was empty");
    }
    let acc = cur.value;
    while (true) {
        cur = iter.next();
        if (cur.done) {
            break;
        }
        acc = f(acc, cur.value);
    }
    return acc;
}
export function reduceBack(f, xs) {
    const ar = isArrayOrBufferView(xs) ? xs : Array.from(xs);
    if (ar.length === 0) {
        throw new Error("Seq was empty");
    }
    let acc = ar[ar.length - 1];
    for (let i = ar.length - 2; i >= 0; i--) {
        acc = f(ar[i], acc, i);
    }
    return acc;
}
export function replicate(n, x) {
    return initialize(n, () => x);
}
export function reverse(xs) {
    const ar = isArrayOrBufferView(xs) ? xs.slice(0) : Array.from(xs);
    return ofArray(ar.reverse());
}
export function scan(f, seed, xs) {
    return delay(() => {
        const iter = xs[Symbol.iterator]();
        return unfold((acc) => {
            if (acc == null) {
                return [seed, seed];
            }
            const cur = iter.next();
            if (!cur.done) {
                acc = f(acc, cur.value);
                return [acc, acc];
            }
            return undefined;
        }, undefined);
    });
}
export function scanBack(f, xs, seed) {
    return reverse(scan((acc, x) => f(x, acc), seed, reverse(xs)));
}
export function skip(n, xs) {
    return makeSeq(() => {
        const iter = xs[Symbol.iterator]();
        for (let i = 1; i <= n; i++) {
            if (iter.next().done) {
                throw new Error("Seq has not enough elements");
            }
        }
        return iter;
    });
}
export function skipWhile(f, xs) {
    return delay(() => {
        let hasPassed = false;
        return filter((x) => hasPassed || (hasPassed = !f(x)), xs);
    });
}
export function sortWith(f, xs) {
    const ys = Array.from(xs);
    return ofArray(ys.sort(f));
}
export function sum(xs, adder) {
    return fold((acc, x) => adder.Add(acc, x), adder.GetZero(), xs);
}
export function sumBy(f, xs, adder) {
    return fold((acc, x) => adder.Add(acc, f(x)), adder.GetZero(), xs);
}
export function tail(xs) {
    return skip(1, xs);
}
export function take(n, xs, truncate = false) {
    return delay(() => {
        const iter = xs[Symbol.iterator]();
        return unfold((i) => {
            if (i < n) {
                const cur = iter.next();
                if (!cur.done) {
                    return [cur.value, i + 1];
                }
                if (!truncate) {
                    throw new Error("Seq has not enough elements");
                }
            }
            return undefined;
        }, 0);
    });
}
export function truncate(n, xs) {
    return take(n, xs, true);
}
export function takeWhile(f, xs) {
    return delay(() => {
        const iter = xs[Symbol.iterator]();
        return unfold(() => {
            const cur = iter.next();
            if (!cur.done && f(cur.value)) {
                return [cur.value, undefined];
            }
            return undefined;
        }, 0);
    });
}
export function tryFind(f, xs, defaultValue) {
    for (let i = 0, iter = xs[Symbol.iterator]();; i++) {
        const cur = iter.next();
        if (cur.done) {
            break;
        }
        if (f(cur.value, i)) {
            return some(cur.value);
        }
    }
    return defaultValue === void 0 ? undefined : some(defaultValue);
}
export function find(f, xs) {
    return __failIfNone(tryFind(f, xs));
}
export function tryFindBack(f, xs, defaultValue) {
    const arr = isArrayOrBufferView(xs) ? xs.slice(0) : Array.from(xs);
    return tryFind(f, arr.reverse(), defaultValue);
}
export function findBack(f, xs) {
    return __failIfNone(tryFindBack(f, xs));
}
export function tryFindIndex(f, xs) {
    for (let i = 0, iter = xs[Symbol.iterator]();; i++) {
        const cur = iter.next();
        if (cur.done) {
            break;
        }
        if (f(cur.value, i)) {
            return i;
        }
    }
    return undefined;
}
export function findIndex(f, xs) {
    return __failIfNone(tryFindIndex(f, xs));
}
export function tryFindIndexBack(f, xs) {
    const arr = isArrayOrBufferView(xs) ? xs.slice(0) : Array.from(xs);
    for (let i = arr.length - 1; i >= 0; i--) {
        if (f(arr[i], i)) {
            return i;
        }
    }
    return undefined;
}
export function findIndexBack(f, xs) {
    return __failIfNone(tryFindIndexBack(f, xs));
}
export function tryPick(f, xs) {
    for (let i = 0, iter = xs[Symbol.iterator]();; i++) {
        const cur = iter.next();
        if (cur.done) {
            break;
        }
        const y = f(cur.value, i);
        if (y != null) {
            return y;
        }
    }
    return undefined;
}
export function pick(f, xs) {
    return __failIfNone(tryPick(f, xs));
}
export function unfold(f, fst) {
    return makeSeq(() => {
        // Capture a copy of the first value in the closure
        // so the sequence is restarted every time, see #1230
        let acc = fst;
        const iter = {
            next() {
                const res = f(acc);
                if (res != null) {
                    const v = value(res);
                    if (v != null) {
                        acc = v[1];
                        return { done: false, value: v[0] };
                    }
                }
                return { done: true, value: undefined };
            },
        };
        return iter;
    });
}
export function zip(xs, ys) {
    return map2((x, y) => [x, y], xs, ys);
}
export function zip3(xs, ys, zs) {
    return map3((x, y, z) => [x, y, z], xs, ys, zs);
}
export function windowed(windowSize, source) {
    if (windowSize <= 0) {
        throw new Error("windowSize must be positive");
    }
    return makeSeq(() => {
        let window = [];
        const iter = source[Symbol.iterator]();
        const iter2 = {
            next() {
                let cur;
                while (window.length < windowSize) {
                    if ((cur = iter.next()).done) {
                        return { done: true, value: undefined };
                    }
                    window.push(cur.value);
                }
                const value = window;
                window = window.slice(1);
                return { done: false, value };
            },
        };
        return iter2;
    });
}
export function transpose(source) {
    return makeSeq(() => {
        const iters = Array.from(source, (x) => x[Symbol.iterator]());
        const iter = {
            next() {
                if (iters.length === 0) {
                    return { done: true, value: undefined }; // empty sequence
                }
                const results = Array.from(iters, (iter) => iter.next());
                if (results[0].done) {
                    if (!results.every((x) => x.done)) {
                        throw new Error("Sequences have different lengths");
                    }
                    return { done: true, value: undefined };
                }
                else {
                    if (!results.every((x) => !x.done)) {
                        throw new Error("Sequences have different lengths");
                    }
                    const values = results.map((x) => x.value);
                    return { done: false, value: values };
                }
            },
        };
        return iter;
    });
}
