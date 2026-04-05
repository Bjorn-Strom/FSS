namespace Fss

open Fss.Types

[<AutoOpen>]
module LayerCss =
    type Layer =
        /// Define a named cascade layer for reuse
        static member define (name: string) = CascadeLayer name
        /// Wrap rules in a named cascade layer
        static member layer (CascadeLayer name) (rules: Rule list) =
            (Property.Layer, Layer.LayerNamed(name, rules))
            |> Rule
        /// Wrap rules in an anonymous cascade layer
        static member anonymous (rules: Rule list) =
            (Property.Layer, Layer.LayerAnonymous(rules))
            |> Rule
