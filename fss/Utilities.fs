namespace Fss.Utilities

open Browser
open Microsoft.FSharp.Reflection
open System

module Types =
    type IAnimation      = interface end
    type IGlobal         = interface end
    type IFontSize       = interface end
    type IColor          = interface end
    type IBorderStyle    = interface end
    type IBorderWidth    = interface end
    type IMargin         = interface end
    type IDisplay        = interface end
    type IFlexDirection  = interface end
    type IFlexWrap       = interface end
    type IJustifyContent = interface end
    type IAlignItems     = interface end
    type IAlignContent   = interface end
    type IAlignSelf      = interface end
    type IOrder          = interface end
    type IFlexGrow       = interface end
    type IFlexShrink     = interface end
    type IFlexBasis      = interface end
    type ITransform      = interface end
    type ITransition     = interface end
    type ILinearGradient = interface end
    type IRadialGradient = interface end
    
    let inline duToString (x:'a) = 
        match FSharpValue.GetUnionFields(x, typeof<'a>) with
        | case, _ -> case.Name

    let pascalToKebabCase (value: string): string =
        value
        |> Seq.fold (fun acc element ->
        if Char.IsUpper(char element) then 
            sprintf "%s-%s" acc (string <| Char.ToLower(element))
        else 
            acc + (string element)) ""

module Global =
    open Types

    type Global =
        | Initial
        | Inherit
        | Unset
        | Revert
        interface IGlobal
        interface IFontSize
        interface IColor
        interface IBorderStyle
        interface IBorderWidth
        interface IMargin
        interface IDisplay
        interface IFlexDirection
        interface IFlexWrap
        interface IJustifyContent
        interface IAlignItems
        interface IAlignContent
        interface IAlignSelf
        interface IOrder
        interface IFlexGrow
        interface IFlexShrink
        interface IFlexBasis
        interface ITransform
        interface ITransition

    let value (v: Global): string =
        match v with
            | Initial -> "initial"
            | Inherit -> "inherit"
            | Unset -> "unset"
            | Revert -> "revert"

module Converters =
    let floatToPercent (f: float): string = sprintf "%d%%" (int <| f * 100.0)

module Color =
    open Converters

    let rgb (r: int) (g: int) (b: int) = sprintf "rgb(%d, %d, %d)" r g b
    let rgba (r: int) (g: int) (b: int) (a: float) = sprintf "rgba(%d, %d, %d, %f)" r g b a
    let hex (value: string) =
        if value.StartsWith("#") then
            value
        else
            sprintf "#%s"value
    let hsl (h: int) (s: float) (l: float) = 
        sprintf "hsl(%d, %s, %s)" 
            h 
            (floatToPercent s)
            (floatToPercent l)
    let hsla (h: int) (s: float) (l: float) (a: float) = 
        sprintf "hsla(%d, %s, %s, %s)" 
            h 
            (floatToPercent s) 
            (floatToPercent l) 
            (floatToPercent a)
