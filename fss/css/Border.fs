namespace Fss

open Fss.FssTypes

[<AutoOpen>]
module BorderCss =
    /// Specifies width of an elements border.
    let BorderWidth = BorderClasses.BorderWidth(Property.BorderWidth)
    // https://developer.mozilla.org/en-US/docs/Web/CSS/border-top-width
    // https://developer.mozilla.org/en-US/docs/Web/CSS/border-right-width
    // https://developer.mozilla.org/en-US/docs/Web/CSS/border-bottom-width
    // https://developer.mozilla.org/en-US/docs/Web/CSS/border-left-width
    /// Specifies width of the top border of an element
    let BorderTopWidth = BorderClasses.BorderWidthParent(Property.BorderTopWidth)
    /// Specifies width of the right border of an element
    let BorderRightWidth = BorderClasses.BorderWidthParent(Property.BorderRightWidth)
    /// Specifies width of the bottom border of an element
    let BorderBottomWidth = BorderClasses.BorderWidthParent(Property.BorderBottomWidth)
    /// Specifies width of the left border of an element
    let BorderLeftWidth = BorderClasses.BorderWidthParent(Property.BorderLeftWidth)
    /// Specifies roundness of border edge.
    let BorderRadius = BorderClasses.BorderRadius(Property.BorderRadius)
    /// Specifies roundness of top left corner.
    let BorderTopLeftRadius = BorderClasses.BorderRadiusEdge(Property.BorderTopLeftRadius)
    /// Specifies roundness of top right corner.
    let BorderTopRightRadius = BorderClasses.BorderRadiusEdge(Property.BorderTopRightRadius)
    /// Specifies roundness of bottom right corner.
    let BorderBottomRightRadius = BorderClasses.BorderRadiusEdge(Property.BorderBottomRightRadius)
    /// Specifies roundness of bottom left corner.
    let BorderBottomLeftRadius = BorderClasses.BorderRadiusEdge(Property.BorderBottomLeftRadius)
    // Sets the style of an elements border
    let BorderStyle = BorderClasses.BorderStyle(Property.BorderStyle)
    /// Sets the style of an elements top border
    let BorderTopStyle = BorderClasses.BorderStyleParent(Property.BorderTopStyle)
    /// Sets the style of an elements right border
    let BorderRightStyle = BorderClasses.BorderStyleParent(Property.BorderRightStyle)
    /// Sets the style of an elements bottom border
    let BorderBottomStyle = BorderClasses.BorderStyleParent(Property.BorderBottomStyle)
    /// Sets the style of an elements left border
    let BorderLeftStyle = BorderClasses.BorderStyleParent(Property.BorderLeftStyle)
    /// Specifies whether cells inside a table have shared or separate borders
    let BorderCollapse = BorderClasses.BorderCollapse(Property.BorderCollapse)
    /// Sets the distance of an elements border image from its border box
    let BorderImageOutset = BorderClasses.BorderImageOutset(Property.BorderImageOutset)
    /// Specifies how edges of an image are fit to an elements borders
    let BorderImageRepeat = BorderClasses.BorderImageRepeat(Property.BorderImageRepeat)
    /// Divides the border image source into regions
    let BorderImageSlice = BorderClasses.BorderImageSlice(Property.BorderImageSlice)
    /// Specifies the color of an elements border
    let BorderColor = BorderClasses.BorderColor(Property.BorderColor)
    /// Specifies the color of the top border of an element
    let BorderTopColor = BorderClasses.BorderColorParent(Property.BorderTopColor)
    /// Specifies the color of the right border of an element
    let BorderRightColor = BorderClasses.BorderColorParent(Property.BorderRightColor)
    /// Specifies the color of the bottom border of an element
    let BorderBottomColor = BorderClasses.BorderColorParent(Property.BorderBottomColor)
    /// Specifies the color of the left border of an element
    let BorderLeftColor = BorderClasses.BorderColorParent(Property.BorderLeftColor)
    /// Specifies the distance between table cells.
    /// Only active when border-collapse is set to separate
    let BorderSpacing = BorderClasses.BorderSpacing(Property.BorderSpacing)
    /// Specifies width of a border image
    let BorderImageWidth = BorderClasses.BorderImageWidth(Property.BorderImageWidth)
    // https://developer.mozilla.org/en-US/docs/Web/CSS/border-image-source
    /// Specifies the source image used creating an elements border image
    let BorderImageSource =
        ImageClasses.ImageClass(Property.BorderImageSource)
    /// Resets border
    let Border = BorderClasses.Border(Property.Border)
