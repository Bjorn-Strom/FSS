namespace Fss

open Fss.Types

[<AutoOpen>]
module Custom =
    /// CSS shorthand
    /// Useful when you want to circumvent FSS
    ///<param name="key">The key of the CSS you want to apply</param>
    ///<param name="value">The CSS value you wand to apply</param>
    let Custom key value = (Property.Custom key, Custom value) |> Rule
        
