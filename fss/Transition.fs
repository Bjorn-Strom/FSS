namespace Fss

open System.Net.NetworkInformation
open Fss.Animation
open Fss.Property
open Types
open Global
open Units.Time

module Transition =
    type Transition =
        {
            Property : IProperty
            Duration : ITime
            Timing   : ITimingFunction
            Delay    : ITime
        }
        interface ITransition

    let property (property: IProperty) transition =
        { transition with Property = property }

    let duration (duration: ITime) transition =
        { transition with Duration = duration }

    let timing (timing: ITimingFunction) transition =
        { transition with Timing = timing }

    let delay (delay: ITime) transition =
        { transition with Delay = delay }

module TransitionValue =
    open Transition

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

    let timing (v: ITimingFunction): string =
        match v with
            | :? Global as g -> GlobalValue.globalValue g
            | :? Timing as t -> AnimationValue.timingFunction t
            | _ -> "Unknown transition property"

    let transition (v: ITransition): string =
        let stringifyTransition (t: Transition): string =
            sprintf "%s %s %s %s"
                (property t.Property)
                (time t.Duration)
                (timing t.Timing)
                (time t.Delay)

        match v with
            | :? Transition as t -> stringifyTransition t
            | _ -> "Unknown transition value"




