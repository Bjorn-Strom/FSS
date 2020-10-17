namespace Fss

open Fss.Animation
open Fss.Property
open Types
open Global

module TransitionValue =
    open TimingFunction

    let property (v: IProperty): string =
        match v with
            | :? Global   as g -> GlobalValue.globalValue g
            | :? Property as p -> Property.toKebabCase p
            | _ -> "Unknown transition property"

    let timing (v: ITimingFunction): string =
        match v with
            | :? Global         as g -> GlobalValue.globalValue g
            | :? TimingFunction as t -> TimingFunctionValue.timingFunction t
            | _ -> "Unknown transition property"