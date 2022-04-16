﻿namespace Fss

open Fss.Types

[<AutoOpen>]
module ContentCss =
    let Content = ContentClasses.Content(Property.Content)

[<AutoOpen>]
module Label =
    /// Gives label to generated CSS string.
    let Label (label: string) =
        (Property.CssProperty.NameLabel, NameLabel.NameLabel(label.Replace(" ", "")))
        |> Rule
