namespace Fss

open System.Net.NetworkInformation
open Fss.Animation
open Fss.Property
open Types
open Global
open Units.Time

module TransitionValue =
    let time (v: ITime): string =
        match v with
            | :? Global as g -> GlobalValue.globalValue g
            | :? Time   as t -> Units.Time.value t
            | _ -> "Unknown transition duration"

    let property (v: IProperty): string =
        match v with
            | :? Global   as g -> GlobalValue.globalValue g
            | :? Property as p -> Property.toKebabCase p
            | _ -> "Unknown transition property"

    let timingFunction (v: ITimingFunction): string =
        match v with
            | :? Global as g -> GlobalValue.globalValue g
            | :? Timing as t -> AnimationValue.timingFunction t
            | _ -> "Unknown transition property"