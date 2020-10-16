namespace Fss

open Fss.Types

module PerspectiveValue =
    open Global
    open Units.Size
    let perspective (v: IPerspective): string =
        match v with
            | :? Global      as g -> GlobalValue.globalValue g
            | :? None        as n -> GlobalValue.none n
            | :? Size        as s -> Units.Size.value s
            | _ -> "Unknown perspective"