namespace Fss

open Fss.FssTypes

[<AutoOpen>]
module Border =
    /// Specifies width of an elements border.
    let BorderWidth =
        Border.BorderClasses.BorderWidth(Property.BorderWidth)
    // https://developer.mozilla.org/en-US/docs/Web/CSS/border-top-width
    // https://developer.mozilla.org/en-US/docs/Web/CSS/border-right-width
    // https://developer.mozilla.org/en-US/docs/Web/CSS/border-bottom-width
    // https://developer.mozilla.org/en-US/docs/Web/CSS/border-left-width
    /// Specifies width of the top border of an element
    let BorderTopWidth =
        Border.BorderClasses.BorderWidthParent(Property.BorderTopWidth)
    /// Specifies width of the right border of an element
    let BorderRightWidth =
        Border.BorderClasses.BorderWidthParent(Property.BorderRightWidth)
    /// Specifies width of the bottom border of an element
    let BorderBottomWidth =
        Border.BorderClasses.BorderWidthParent(Property.BorderBottomWidth)
    /// Specifies width of the left border of an element
    let BorderLeftWidth =
        Border.BorderClasses.BorderWidthParent(Property.BorderLeftWidth)
    /// Specifies roundness of border edge.
    let BorderRadius =
        Border.BorderClasses.BorderRadius(Property.BorderRadius)
    /// Specifies roundness of top left corner.
    let BorderTopLeftRadius =
        Border.BorderClasses.BorderRadiusEdge(Property.BorderTopLeftRadius)
    /// Specifies roundness of top right corner.
    let BorderTopRightRadius =
        Border.BorderClasses.BorderRadiusEdge(Property.BorderTopRightRadius)
    /// Specifies roundness of bottom right corner.
    let BorderBottomRightRadius =
        Border.BorderClasses.BorderRadiusEdge(Property.BorderBottomRightRadius)
    /// Specifies roundness of bottom left corner.
    let BorderBottomLeftRadius =
        Border.BorderClasses.BorderRadiusEdge(Property.BorderBottomLeftRadius)
    // Sets the style of an elements border
    let BorderStyle =
        Border.BorderClasses.BorderStyle(Property.BorderStyle)
    /// Sets the style of an elements top border
    let BorderTopStyle =
        Border.BorderClasses.BorderStyleParent(Property.BorderTopStyle)
    /// Sets the style of an elements right border
    let BorderRightStyle =
        Border.BorderClasses.BorderStyleParent(Property.BorderRightStyle)
    /// Sets the style of an elements bottom border
    let BorderBottomStyle =
        Border.BorderClasses.BorderStyleParent(Property.BorderBottomStyle)
    /// Sets the style of an elements left border
    let BorderLeftStyle =
        Border.BorderClasses.BorderStyleParent(Property.BorderLeftStyle)
    /// Specifies whether cells inside a table have shared or separate borders
    let BorderCollapse =
        Border.BorderClasses.BorderCollapse(Property.BorderCollapse)
    /// Sets the distance of an elements border image from its border box
    let BorderImageOutset =
        Border.BorderClasses.BorderImageOutset(Property.BorderImageOutset)
    /// Specifies how edges of an image are fit to an elements borders
    let BorderImageRepeat =
        Border.BorderClasses.BorderImageRepeat(Property.BorderImageRepeat)
    /// Divides the border image source into regions
    let BorderImageSlice =
        Border.BorderClasses.BorderImageSlice(Property.BorderImageSlice)
    /// Specifies the color of an elements border
    let BorderColor =
        Border.BorderClasses.BorderColor(Property.BorderColor)
    /// Specifies the color of the top border of an element
    let BorderTopColor =
        Border.BorderClasses.BorderColorParent(Property.BorderTopColor)
    /// Specifies the color of the right border of an element
    let BorderRightColor =
        Border.BorderClasses.BorderColorParent(Property.BorderRightColor)
    /// Specifies the color of the bottom border of an element
    let BorderBottomColor =
        Border.BorderClasses.BorderColorParent(Property.BorderBottomColor)
    /// Specifies the color of the left border of an element
    let BorderLeftColor =
        Border.BorderClasses.BorderColorParent(Property.BorderLeftColor)
    /// Specifies the distance between table cells.
    /// Only active when border-collapse is set to separate
    let BorderSpacing =
        Border.BorderClasses.BorderSpacing(Property.BorderSpacing)
    /// Specifies width of a border image
    let BorderImageWidth =
        Border.BorderClasses.BorderImageWidth(Property.BorderImageWidth)
    // https://developer.mozilla.org/en-US/docs/Web/CSS/border-image-source
    /// Specifies the source image used creating an elements border image
    let BorderImageSource =
        Image.ImageClasses.ImageClass(Property.BorderImageSource)
    /// Resets border
    let Border =
        Border.BorderClasses.Border(Property.Border)
