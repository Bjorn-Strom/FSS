namespace Fss

open System.Net.NetworkInformation
open Fss.Animation
open Fss.Property
open Types
open Global
open Units.Time

module Transition =
    
    type TransitionProperty =
        | Property
        interface ITransitionProperty
    
    type TransitionTime =
        | TransitionTime
        interface ITransitionTime
        
    type TransitionTimingFunction =
        | TransitionTimingFunction
        interface ITransitionTimingFunction
        
module TransitionValue =
    let time (v: ITransitionTime): string =
        match v with
            | :? Global as g -> GlobalValue.globalValue g
            | :? Time   as t -> Units.Time.value t
            | _ -> "Unknown transition duration"
            
    let property (v: ITransitionProperty): string =
        match v with
            | :? Global   as g -> GlobalValue.globalValue g
            | :? Property as p -> Property.propertyToKebabCase p
            | _ -> "Unknown transition property"
            
    let timingFunction (v: ITransitionTimingFunction): string =
        match v with
            | :? Global as g -> GlobalValue.globalValue g
            | :? Timing as t -> AnimationValue.timingFunction t
            | _ -> "Unknown transition property"