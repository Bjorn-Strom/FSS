namespace Fss
namespace Fss.Types

open Fss.Types

type ICssValue =
    interface
        abstract member StringifyCss : unit -> string
    end

type ICounterValue =
    interface
        abstract member StringifyCounter : unit -> string
    end

type IFontFaceValue =
    interface
        abstract member StringifyFontFace : unit -> string
    end

[<AutoOpen>]
module MasterTypeHelpers =
    let internal cache = System.Collections.Generic.Dictionary<ICssValue, string>()
    // TODO: internal
    let stringifyICssValue cssValue: string =
        if cache.ContainsKey(cssValue) then
            cache[cssValue]
        else
            let newValue = (cssValue :> ICssValue).StringifyCss()
            cache.Add(cssValue, newValue)
            newValue
    let internal stringifyICounterValue cssValue: string =
        (cssValue :> ICounterValue).StringifyCounter()
    let internal stringifyIFontFaceValue cssValue: string =
        (cssValue :> IFontFaceValue).StringifyFontFace()
