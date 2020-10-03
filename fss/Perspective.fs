namespace Fss

open Fss.Types

module Perspective =
    type Perspective =
        | None
        interface IPerspective
        
module PerspectiveValue =
    open Perspective
    open Global
    open Units.Size
    open Utilities.Helpers
    let perspective (v: IPerspective): string =
        match v with
            | :? Global      as g -> GlobalValue.globalValue g
            | :? None        as n -> GlobalValue.none n
            | :? Size        as s -> Units.Size.value s
            | :? Perspective as p -> duToLowercase p
            | _ -> "Unknown perspective"