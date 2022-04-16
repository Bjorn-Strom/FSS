import { CounterClasses_CounterIncrement_$ctor_Z207A3CFB, CounterClasses_CounterSet_$ctor_Z207A3CFB, CounterClasses_CounterReset_$ctor_Z207A3CFB, CounterClasses_FallbackClass_$ctor, CounterClasses_SpeakAsClass_$ctor, CounterClasses_AdditiveSymbolsClass_$ctor, CounterClasses_SymbolsClass_$ctor, CounterClasses_PadClass_$ctor, CounterClasses_RangeClass_$ctor, CounterClasses_FixClass_$ctor_Z237A0E4E, CounterClasses_NegativeClass_$ctor, CounterClasses_SystemClass_$ctor } from "../Types/CounterStyle.fs.js";
import { NameLabel, Property_CssProperty, Property_CounterProperty } from "../Types/MasterTypes.fs.js";
import { replace } from "../../fable-library.3.7.9/String.js";

export const System = CounterClasses_SystemClass_$ctor();

export const Negative = CounterClasses_NegativeClass_$ctor();

export const Prefix = CounterClasses_FixClass_$ctor_Z237A0E4E(new Property_CounterProperty(2));

export const Suffix = CounterClasses_FixClass_$ctor_Z237A0E4E(new Property_CounterProperty(3));

export const Range$ = CounterClasses_RangeClass_$ctor();

export const Pad = CounterClasses_PadClass_$ctor();

export const Symbols = CounterClasses_SymbolsClass_$ctor();

export const AdditiveSymbols = CounterClasses_AdditiveSymbolsClass_$ctor();

export const SpeakAs = CounterClasses_SpeakAsClass_$ctor();

export const Fallback = CounterClasses_FallbackClass_$ctor();

export const CounterReset = CounterClasses_CounterReset_$ctor_Z207A3CFB(new Property_CssProperty(86));

export const CounterSet = CounterClasses_CounterSet_$ctor_Z207A3CFB(new Property_CssProperty(87));

export const CounterIncrement = CounterClasses_CounterIncrement_$ctor_Z207A3CFB(new Property_CssProperty(85));

export function CounterLabel(label) {
    const tupledArg = [new Property_CounterProperty(10), new NameLabel(0, replace(label, " ", ""))];
    return [tupledArg[0], tupledArg[1]];
}

//# sourceMappingURL=CounterStyle.fs.js.map
