namespace Fss

namespace Fss.Types

[<RequireQualifiedAccess>]
module Position =
    type Position =
        | Static
        | Relative
        | Absolute
        | Sticky
        | Fixed
        interface ICssValue with
            member this.StringifyCss() =
                match this with
                | Static -> "static"
                | Relative -> "relative"
                | Absolute -> "absolute"
                | Sticky -> "sticky"
                | Fixed -> "fixed"

    type VerticalAlign =
        | Baseline
        | Sub
        | Super
        | TextTop
        | TextBottom
        | Middle
        | Top
        | Bottom
        interface ICssValue with
            member this.StringifyCss() = 
                match this with
                | Baseline -> "baseline"
                | Sub -> "sub"
                | Super -> "super"
                | TextTop -> "text-top"
                | TextBottom -> "text-bottom"
                | Middle -> "middle"
                | Top -> "top"
                | Bottom -> "bottom"

    type Float =
        | Left
        | Right
        | InlineStart
        | InlineEnd
        interface ICssValue with
            member this.StringifyCss() =
                match this with
                | Left -> "left"
                | Right -> "right"
                | InlineStart -> "inline-start"
                | InlineEnd -> "inline-end"

    type BoxSizing =
        | ContentBox
        | BorderBox
        interface ICssValue with
            member this.StringifyCss() =
                match this with
                | ContentBox -> "content-box"
                | BorderBox -> "border-box"

    type Direction =
        | Rtl
        | Ltr
        interface ICssValue with
            member this.StringifyCss() =
                match this with
                | Rtl -> "rtl"
                | Ltr -> "ltr"

    type Break =
        | Avoid
        | Always
        | All
        | AvoidPage
        | Page
        | Left
        | Right
        | Recto
        | Verso
        | AvoidColumn
        | Column
        | AvoidRegion
        | Region
        interface ICssValue with
            member this.StringifyCss() =
                match this with
                | Avoid -> "avoid"
                | Always -> "always"
                | All -> "all"
                | AvoidPage -> "avoid-page"
                | Page -> "page"
                | Left -> "left"
                | Right -> "right"
                | Recto -> "recto"
                | Verso -> "verso"
                | AvoidColumn -> "avoid-column"
                | Column -> "column"
                | AvoidRegion -> "avoid-region"
                | Region -> "region"

    type BreakInside =
        | Avoid
        | AvoidPage
        | AvoidColumn
        | AvoidRegion
        interface ICssValue with
            member this.StringifyCss() =
                match this with
                | Avoid -> "avoid"
                | AvoidPage -> "avoid-page"
                | AvoidColumn -> "avoid-column"
                | AvoidRegion -> "avoid-region"

[<RequireQualifiedAccess>]
module PositionClasses =
    // https://developer.mozilla.org/en-US/docs/Web/CSS/position
    type Position(property) =
        inherit CssRule(property)
        /// The element is positioned according to the normal document flow
        /// This is the default value
        member this.static' = (property, Position.Static) |> Rule
        /// The element is positioned according to the normal document flow
        /// but is then offset relative to its top, right, bottom and left values.
        /// This offset does not affect the position of any other elements and the element itself
        /// still has its position in the document
        member this.relative = (property, Position.Relative) |> Rule
        /// The element is taken out of the normal document flow
        /// No space is created for it and it is positioned to its closest ancestor
        /// Its final position is determined by its top, right, bottom and left values
        member this.absolute = (property, Position.Absolute) |> Rule
        /// The element is treated as a relative element until a specific scroll threshold is reached
        /// At that point it is treadet as  afixed position where it is told to stick
        member this.sticky = (property, Position.Sticky) |> Rule
        /// The element is taken out of the normal document flow
        /// No space is created for it and it is positioned to the document
        /// Its final position is determined by its top, right, bottom and left values
        member this.fixed' = (property, Position.Fixed) |> Rule
    // https://developer.mozilla.org/en-US/docs/Web/CSS/top
    // https://developer.mozilla.org/en-US/docs/Web/CSS/right
    // https://developer.mozilla.org/en-US/docs/Web/CSS/bottom
    // https://developer.mozilla.org/en-US/docs/Web/CSS/left
    type TopRightBottomLeft(property) =
        inherit CssRuleWithAutoLength(property)
    // https://developer.mozilla.org/en-US/docs/Web/CSS/vertical-align
    type VerticalAlign(property) =
        inherit CssRuleWithLength(property)
        /// Aligns the baseline of the element with the baseline of the parent
        /// This is the default value
        member this.baseline = (property, Position.Baseline) |> Rule
        /// Aligns the baseline of the element with the subscript baseline of the parent
        member this.sub = (property, Position.Sub) |> Rule
        /// Alings the baseline of the element with the superscript-baseline of its parent.
        member this.super = (property, Position.Super) |> Rule
        /// Aligns the top of the element to the top of the parents font
        member this.textTop = (property, Position.TextTop) |> Rule
        /// Aligns the bottom of the element to the bottom of the parents font
        member this.textBottom = (property, Position.TextBottom) |> Rule
        /// Aligns the middle of the element to the middle of the lowercase letters in the parent
        member this.middle = (property, Position.Middle) |> Rule
        /// Aligns the top of the element to the top of the entire line
        member this.top = (property, Position.Top) |> Rule
        /// Aligns the bottom of the element to the bottom of the entire line
        member this.bottom = (property, Position.Bottom) |> Rule
    // https://developer.mozilla.org/en-US/docs/Web/CSS/float
    type Float(property) =
        inherit CssRuleWithNone(property)
        /// Element must float to the left side of its containing block
        member this.left = (property, Position.Left) |> Rule
        /// Element must float to the right side of its containing block
        member this.right = (property, Position.Right) |> Rule
        /// Element must float to start side of its containing block
        member this.inlineStart = (property, Position.InlineStart) |> Rule
        /// Element must float to end side of its containing block
        member this.inlineEnd = (property, Position.InlineEnd) |> Rule
    // https://developer.mozilla.org/en-US/docs/Web/CSS/box-sizing
    type BoxSizing(property) =
        inherit CssRule(property)
        /// Size includes content, padding and border
        member this.borderBox = (property, Position.BorderBox) |> Rule
        /// Size does not include content, padding or border
        member this.contentBox = (property, Position.ContentBox) |> Rule
    // https://developer.mozilla.org/en-US/docs/Web/CSS/direction
    type Direction(property) =
        inherit CssRule(property)
        /// Text and other elements go from left to right
        /// This is the default value
        member this.ltr = (property, Position.Ltr) |> Rule
        /// Text and other elements go from right to left
        member this.rtl = (property, Position.Rtl) |> Rule

    // https://developer.mozilla.org/en-US/docs/Web/CSS/break-after
    // https://developer.mozilla.org/en-US/docs/Web/CSS/break-before
    type Break(property) =
        inherit CssRuleWithAuto(property)
        /// Avoids any break from being inserted
        member this.avoid = (property, Position.Avoid) |> Rule
        /// Forces page breaks to be inserted
        member this.always = (property, Position.Always) |> Rule
        /// FOrces page breaks to be inserted, breaks in all possible contexts
        member this.all = (property, Position.All) |> Rule
        /// Avoids any page break
        member this.avoidPage = (property, Position.AvoidPage) |> Rule
        /// Forces page break
        member this.page = (property, Position.Page) |> Rule
        /// Forces whatever break will make the next page into a left page
        member this.left = (property, Position.Left) |> Rule
        /// Forces whatever break will make the next page into a right page
        member this.right = (property, Position.Right) |> Rule
        /// Forces one or two page breaks, whichever will make the next page into a recto page
        member this.recto = (property, Position.Recto) |> Rule
        /// Forces one or two page breaks, whichever will make the next page into a verso page
        member this.verso = (property, Position.Verso) |> Rule
        /// Avoids any column break
        member this.avoidColumn = (property, Position.AvoidColumn) |> Rule
        /// Forces any column break
        member this.column = (property, Position.Column) |> Rule
        /// Avoids any region break
        member this.avoidRegion = (property, Position.AvoidRegion) |> Rule
        /// Forces any region break
        member this.region = (property, Position.Region) |> Rule
    // https://developer.mozilla.org/en-US/docs/Web/CSS/break-inside
    type BreakInside(property) =
        inherit CssRuleWithAuto(property)
        /// Avoids any break
        member this.avoid = (property, Position.Avoid) |> Rule
        /// Avoids any page break
        member this.avoidPage = (property, Position.AvoidPage) |> Rule
        /// Avoids any column break
        member this.avoidColumn = (property, Position.AvoidColumn) |> Rule
        /// Avoids any region break
        member this.avoidRegion = (property, Position.AvoidRegion) |> Rule

[<RequireQualifiedAccess>]
module WritingMode =
    type WritingMode =
        | HorizontalTb
        | VerticalRl
        | VerticalLr
        interface ICssValue with
            member this.StringifyCss() = Fss.Utilities.Helpers.toKebabCase this

[<RequireQualifiedAccess>]
module WritingModeClasses =
    // https://developer.mozilla.org/en-US/docs/Web/CSS/writing-mode
    type WritingMode(property) =
        inherit CssRule(property)
        /// For ltr scripts the content flows horizontally from left to right
        /// For rtl scripts the content flows horizontally from right to left
        member this.horizontalTb = (property, WritingMode.HorizontalTb) |> Rule
        /// For lrt scripts the content flows vertically from top to bottom with the next line to the left of the current one 
        /// For lrt scripts the content flows vertically from bottom to top with the next line to the right of the current one 
        member this.verticalRl = (property, WritingMode.VerticalRl) |> Rule
        /// For lrt scripts the content flows vertically from bottom to top with the next line to the right of the current one 
        /// For lrt scripts the content flows vertically from top to bottom with the next line to the left of the current one 
        member this.verticalLr = (property, WritingMode.VerticalLr) |> Rule
