namespace FssTypes

type CssColor =
    | CssColor of string
    interface ITextDecorationColor
    interface ITextEmphasisColor
    interface IBorderColor
    interface IOutlineColor
    interface IColumnRuleColor
    interface ICaretColor
    interface IColorStop

module CssColorValue =
    let color (CssColor c) = c
