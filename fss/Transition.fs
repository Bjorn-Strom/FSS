namespace Fss

open Types
open Global
open Property
open Animation
open Units.Time

module Transition =
    type TransitionDuration =
        | TransitionDuration
        interface ITransitionDuration

open Fable.Core.JS

module TransitionValue =
    let duration (v: ITransitionDuration): string =
        match v with
            | :? Global as g -> GlobalValue.globalValue g
            | :? Time   as t -> Units.Time.value t
            | _ -> "Unknown transition duration"