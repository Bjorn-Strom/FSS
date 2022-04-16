import { disposeSafe, comparePrimitives, max, toIterator, getEnumerator, structuralHash, equals, compare } from "./Util.js";
import { class_type } from "./Reflection.js";
import { toArray, empty, singleton, append, enumerateWhile, delay } from "./Seq.js";
import { initialize, copyTo, fill } from "./Array.js";

export class Comparer$1 {
    constructor() {
    }
    Compare(x, y) {
        return compare(x, y);
    }
}

export function Comparer$1$reflection(gen0) {
    return class_type("System.Collections.Generic.Comparer`1", [gen0], Comparer$1);
}

export function Comparer$1_$ctor() {
    return new Comparer$1();
}

export function Comparer$1_get_Default() {
    return {
        Compare(x, y) {
            return compare(x, y);
        },
    };
}

export class EqualityComparer$1 {
    constructor() {
    }
    Equals(x, y) {
        return equals(x, y);
    }
    GetHashCode(x) {
        return structuralHash(x);
    }
}

export function EqualityComparer$1$reflection(gen0) {
    return class_type("System.Collections.Generic.EqualityComparer`1", [gen0], EqualityComparer$1);
}

export function EqualityComparer$1_$ctor() {
    return new EqualityComparer$1();
}

export function EqualityComparer$1_get_Default() {
    return {
        Equals(x, y) {
            return equals(x, y);
        },
        GetHashCode(x_1) {
            return structuralHash(x_1);
        },
    };
}

export class Stack$1 {
    constructor(initialContents, initialCount) {
        this.contents = initialContents;
        this.count = (initialCount | 0);
    }
    GetEnumerator() {
        const this$ = this;
        return getEnumerator(delay(() => {
            let index = this$.count - 1;
            return enumerateWhile(() => (index >= 0), delay(() => append(singleton(this$.contents[index]), delay(() => {
                index = ((index - 1) | 0);
                return empty();
            }))));
        }));
    }
    [Symbol.iterator]() {
        return toIterator(this.GetEnumerator());
    }
    ["System.Collections.IEnumerable.GetEnumerator"]() {
        const this$ = this;
        return getEnumerator(this$);
    }
}

export function Stack$1$reflection(gen0) {
    return class_type("System.Collections.Generic.Stack`1", [gen0], Stack$1);
}

function Stack$1_$ctor_Z2E171D71(initialContents, initialCount) {
    return new Stack$1(initialContents, initialCount);
}

export function Stack$1_$ctor_Z524259A4(initialCapacity) {
    return Stack$1_$ctor_Z2E171D71(fill(new Array(initialCapacity), 0, initialCapacity, null), 0);
}

export function Stack$1_$ctor() {
    return Stack$1_$ctor_Z524259A4(4);
}

export function Stack$1_$ctor_BB573A(xs) {
    const arr = Array.from(xs);
    return Stack$1_$ctor_Z2E171D71(arr, arr.length);
}

export function Stack$1__Ensure_Z524259A4(this$, newSize) {
    const oldSize = this$.contents.length | 0;
    if (newSize > oldSize) {
        const old = this$.contents;
        this$.contents = fill(new Array(max(comparePrimitives, newSize, oldSize * 2)), 0, max(comparePrimitives, newSize, oldSize * 2), null);
        copyTo(old, 0, this$.contents, 0, this$.count);
    }
}

export function Stack$1__get_Count(this$) {
    return this$.count;
}

export function Stack$1__Pop(this$) {
    this$.count = ((this$.count - 1) | 0);
    return this$.contents[this$.count];
}

export function Stack$1__Peek(this$) {
    return this$.contents[this$.count - 1];
}

export function Stack$1__Contains_2B595(this$, x) {
    let found = false;
    let i = 0;
    while ((i < this$.count) && (!found)) {
        if (equals(x, this$.contents[i])) {
            found = true;
        }
        else {
            i = ((i + 1) | 0);
        }
    }
    return found;
}

export function Stack$1__TryPeek_404CD8EE(this$, result) {
    if (this$.count > 0) {
        result.contents = Stack$1__Peek(this$);
        return true;
    }
    else {
        return false;
    }
}

export function Stack$1__TryPop_404CD8EE(this$, result) {
    if (this$.count > 0) {
        result.contents = Stack$1__Pop(this$);
        return true;
    }
    else {
        return false;
    }
}

export function Stack$1__Push_2B595(this$, x) {
    Stack$1__Ensure_Z524259A4(this$, this$.count + 1);
    this$.contents[this$.count] = x;
    this$.count = ((this$.count + 1) | 0);
}

export function Stack$1__Clear(this$) {
    this$.count = 0;
    fill(this$.contents, 0, this$.contents.length, null);
}

export function Stack$1__TrimExcess(this$) {
    if ((this$.count / this$.contents.length) > 0.9) {
        Stack$1__Ensure_Z524259A4(this$, this$.count);
    }
}

export function Stack$1__ToArray(this$) {
    return initialize(this$.count, (i) => this$.contents[(this$.count - 1) - i]);
}

export class Queue$1 {
    constructor(initialContents, initialCount) {
        this.contents = initialContents;
        this.count = (initialCount | 0);
        this.head = 0;
        this.tail = (initialCount | 0);
    }
    GetEnumerator() {
        const this$ = this;
        return getEnumerator(Queue$1__toSeq(this$));
    }
    [Symbol.iterator]() {
        return toIterator(this.GetEnumerator());
    }
    ["System.Collections.IEnumerable.GetEnumerator"]() {
        const this$ = this;
        return getEnumerator(this$);
    }
}

export function Queue$1$reflection(gen0) {
    return class_type("System.Collections.Generic.Queue`1", [gen0], Queue$1);
}

function Queue$1_$ctor_Z2E171D71(initialContents, initialCount) {
    return new Queue$1(initialContents, initialCount);
}

export function Queue$1_$ctor_Z524259A4(initialCapacity) {
    if (initialCapacity < 0) {
        throw (new Error("capacity is less than 0"));
    }
    return Queue$1_$ctor_Z2E171D71(fill(new Array(initialCapacity), 0, initialCapacity, null), 0);
}

export function Queue$1_$ctor() {
    return Queue$1_$ctor_Z524259A4(4);
}

export function Queue$1_$ctor_BB573A(xs) {
    const arr = Array.from(xs);
    return Queue$1_$ctor_Z2E171D71(arr, arr.length);
}

export function Queue$1__get_Count(_) {
    return _.count;
}

export function Queue$1__Enqueue_2B595(_, value) {
    if (_.count === Queue$1__size(_)) {
        Queue$1__ensure_Z524259A4(_, _.count + 1);
    }
    _.contents[_.tail] = value;
    _.tail = (((_.tail + 1) % Queue$1__size(_)) | 0);
    _.count = ((_.count + 1) | 0);
}

export function Queue$1__Dequeue(_) {
    if (_.count === 0) {
        throw (new Error("Queue is empty"));
    }
    const value = _.contents[_.head];
    _.head = (((_.head + 1) % Queue$1__size(_)) | 0);
    _.count = ((_.count - 1) | 0);
    return value;
}

export function Queue$1__Peek(_) {
    if (_.count === 0) {
        throw (new Error("Queue is empty"));
    }
    return _.contents[_.head];
}

export function Queue$1__TryDequeue_404CD8EE(this$, result) {
    if (this$.count === 0) {
        return false;
    }
    else {
        result.contents = Queue$1__Dequeue(this$);
        return true;
    }
}

export function Queue$1__TryPeek_404CD8EE(this$, result) {
    if (this$.count === 0) {
        return false;
    }
    else {
        result.contents = Queue$1__Peek(this$);
        return true;
    }
}

export function Queue$1__Contains_2B595(this$, x) {
    let found = false;
    let i = 0;
    while ((i < this$.count) && (!found)) {
        if (equals(x, this$.contents[Queue$1__toIndex_Z524259A4(this$, i)])) {
            found = true;
        }
        else {
            i = ((i + 1) | 0);
        }
    }
    return found;
}

export function Queue$1__Clear(this$) {
    this$.count = 0;
    this$.head = 0;
    this$.tail = 0;
    fill(this$.contents, 0, Queue$1__size(this$), null);
}

export function Queue$1__TrimExcess(this$) {
    if ((this$.count / this$.contents.length) > 0.9) {
        Queue$1__ensure_Z524259A4(this$, this$.count);
    }
}

export function Queue$1__ToArray(this$) {
    return toArray(Queue$1__toSeq(this$));
}

export function Queue$1__CopyTo_Z2E171D71(this$, target, start) {
    let i = start;
    const enumerator = getEnumerator(Queue$1__toSeq(this$));
    try {
        while (enumerator["System.Collections.IEnumerator.MoveNext"]()) {
            const item = enumerator["System.Collections.Generic.IEnumerator`1.get_Current"]();
            target[i] = item;
            i = ((i + 1) | 0);
        }
    }
    finally {
        disposeSafe(enumerator);
    }
}

function Queue$1__size(this$) {
    return this$.contents.length;
}

function Queue$1__toIndex_Z524259A4(this$, i) {
    return (this$.head + i) % Queue$1__size(this$);
}

function Queue$1__ensure_Z524259A4(this$, requiredSize) {
    const newBuffer = fill(new Array(requiredSize), 0, requiredSize, null);
    if (this$.head < this$.tail) {
        copyTo(this$.contents, this$.head, newBuffer, 0, this$.count);
    }
    else {
        copyTo(this$.contents, this$.head, newBuffer, 0, Queue$1__size(this$) - this$.head);
        copyTo(this$.contents, 0, newBuffer, Queue$1__size(this$) - this$.head, this$.tail);
    }
    this$.head = 0;
    this$.tail = (this$.count | 0);
    this$.contents = newBuffer;
}

function Queue$1__toSeq(this$) {
    return delay(() => {
        let i = 0;
        return enumerateWhile(() => (i < this$.count), delay(() => append(singleton(this$.contents[Queue$1__toIndex_Z524259A4(this$, i)]), delay(() => {
            i = ((i + 1) | 0);
            return empty();
        }))));
    });
}

