import { Union } from "./Types.js";
import { union_type } from "./Reflection.js";
import { some } from "./Option.js";

export class FSharpResult$2 extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["Ok", "Error"];
    }
}

export function FSharpResult$2$reflection(gen0, gen1) {
    return union_type("FSharp.Core.FSharpResult`2", [gen0, gen1], FSharpResult$2, () => [[["ResultValue", gen0]], [["ErrorValue", gen1]]]);
}

export function Result_Map(mapping, result) {
    if (result.tag === 0) {
        return new FSharpResult$2(0, mapping(result.fields[0]));
    }
    else {
        return new FSharpResult$2(1, result.fields[0]);
    }
}

export function Result_MapError(mapping, result) {
    if (result.tag === 0) {
        return new FSharpResult$2(0, result.fields[0]);
    }
    else {
        return new FSharpResult$2(1, mapping(result.fields[0]));
    }
}

export function Result_Bind(binder, result) {
    if (result.tag === 0) {
        return binder(result.fields[0]);
    }
    else {
        return new FSharpResult$2(1, result.fields[0]);
    }
}

export class FSharpChoice$2 extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["Choice1Of2", "Choice2Of2"];
    }
}

export function FSharpChoice$2$reflection(gen0, gen1) {
    return union_type("FSharp.Core.FSharpChoice`2", [gen0, gen1], FSharpChoice$2, () => [[["Item", gen0]], [["Item", gen1]]]);
}

export class FSharpChoice$3 extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["Choice1Of3", "Choice2Of3", "Choice3Of3"];
    }
}

export function FSharpChoice$3$reflection(gen0, gen1, gen2) {
    return union_type("FSharp.Core.FSharpChoice`3", [gen0, gen1, gen2], FSharpChoice$3, () => [[["Item", gen0]], [["Item", gen1]], [["Item", gen2]]]);
}

export class FSharpChoice$4 extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["Choice1Of4", "Choice2Of4", "Choice3Of4", "Choice4Of4"];
    }
}

export function FSharpChoice$4$reflection(gen0, gen1, gen2, gen3) {
    return union_type("FSharp.Core.FSharpChoice`4", [gen0, gen1, gen2, gen3], FSharpChoice$4, () => [[["Item", gen0]], [["Item", gen1]], [["Item", gen2]], [["Item", gen3]]]);
}

export class FSharpChoice$5 extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["Choice1Of5", "Choice2Of5", "Choice3Of5", "Choice4Of5", "Choice5Of5"];
    }
}

export function FSharpChoice$5$reflection(gen0, gen1, gen2, gen3, gen4) {
    return union_type("FSharp.Core.FSharpChoice`5", [gen0, gen1, gen2, gen3, gen4], FSharpChoice$5, () => [[["Item", gen0]], [["Item", gen1]], [["Item", gen2]], [["Item", gen3]], [["Item", gen4]]]);
}

export class FSharpChoice$6 extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["Choice1Of6", "Choice2Of6", "Choice3Of6", "Choice4Of6", "Choice5Of6", "Choice6Of6"];
    }
}

export function FSharpChoice$6$reflection(gen0, gen1, gen2, gen3, gen4, gen5) {
    return union_type("FSharp.Core.FSharpChoice`6", [gen0, gen1, gen2, gen3, gen4, gen5], FSharpChoice$6, () => [[["Item", gen0]], [["Item", gen1]], [["Item", gen2]], [["Item", gen3]], [["Item", gen4]], [["Item", gen5]]]);
}

export class FSharpChoice$7 extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["Choice1Of7", "Choice2Of7", "Choice3Of7", "Choice4Of7", "Choice5Of7", "Choice6Of7", "Choice7Of7"];
    }
}

export function FSharpChoice$7$reflection(gen0, gen1, gen2, gen3, gen4, gen5, gen6) {
    return union_type("FSharp.Core.FSharpChoice`7", [gen0, gen1, gen2, gen3, gen4, gen5, gen6], FSharpChoice$7, () => [[["Item", gen0]], [["Item", gen1]], [["Item", gen2]], [["Item", gen3]], [["Item", gen4]], [["Item", gen5]], [["Item", gen6]]]);
}

export function Choice_makeChoice1Of2(x) {
    return new FSharpChoice$2(0, x);
}

export function Choice_makeChoice2Of2(x) {
    return new FSharpChoice$2(1, x);
}

export function Choice_tryValueIfChoice1Of2(x) {
    if (x.tag === 0) {
        return some(x.fields[0]);
    }
    else {
        return void 0;
    }
}

export function Choice_tryValueIfChoice2Of2(x) {
    if (x.tag === 1) {
        return some(x.fields[0]);
    }
    else {
        return void 0;
    }
}

