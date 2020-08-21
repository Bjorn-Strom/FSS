namespace Fss

open Types
open Global
open Units.Percent
open Units.Size
open Utilities.Helpers

// https://developer.mozilla.org/en-US/docs/Web/CSS/text-align
module TextAlign =
    type TextAlign =
        | Left
        | Right
        | Center
        | Justify
        | JustifyAll
        | Start
        | End
        | MatchParent
        interface ITextAlign
        
    let private textAlignValue (v: TextAlign): string = duToKebab v

    let value (v: ITextAlign): string =
        match v with
            | :? Global    as g -> Global.value g
            | :? TextAlign as t -> textAlignValue t
            | _                 -> "Unknown text align"


// https://developer.mozilla.org/en-US/docs/Web/CSS/text-decoration-line
module TextDecorationLine =
    type TextDecorationLine =
        | None
        | Underline
        | Overline
        | LineThrough
        interface ITextDecorationLine

    let private textDecorationLineValue (v: TextDecorationLine): string = duToKebab v

    let value (v: ITextDecorationLine): string =
        match v with
            | :? Global             as g -> Global.value g 
            | :? TextDecorationLine as t -> textDecorationLineValue t
            | _                          -> "unknown text decoration line"

// https://developer.mozilla.org/en-US/docs/Web/CSS/text-decoration-thickness
module TextDecorationThickness =
    type TextDecorationThickness =
        | Auto
        | FromFont
        interface ITextDecorationThickness

    let value (v: ITextDecorationThickness): string = 
        match v with
            | :? Global                  as g -> Global.value g
            | :? Percent                 as p -> Units.Percent.value p
            | :? Size                    as s -> Units.Size.value s
            | :? TextDecorationThickness as t -> duToKebab t
            | _                               -> "unkown text decoration thickness"