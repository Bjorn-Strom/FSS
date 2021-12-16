namespace Fss

open Fss.FssTypes

[<AutoOpen>]
module MixBlendMode =
    /// Specifies how an elements content should blend with its parent.
    let MixBlendMode =
        MixBlendMode.MixBlendModeClasses.MixBlendMode(Property.MixBlendMode)
