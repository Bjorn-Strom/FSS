namespace Fss

open Units.Size
open Utilities.Types

module Margin =
    type Margin =
        | Margin of Size
        | Auto
        interface ICSSProperty

    let value (v: Margin): string =
        match v with
            | Margin s -> Units.Size.value s
            | Auto -> "auto"
