namespace Fss

open Fss.Types

[<AutoOpen>]
module MixBlendMode =
    /// Specifies how an elements content should blend with its parent.
    let MixBlendMode = MixBlendModeClasses.MixBlendMode(Property.MixBlendMode)
