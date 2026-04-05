namespace Fss

open Fss.Types

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
    // Logical border-block properties
    /// Shorthand for border-block-start and border-block-end
    let BorderBlock = BorderClasses.Border(Property.BorderBlock)
    /// Sets color for both block borders
    let BorderBlockColor = BorderClasses.BorderColorParent(Property.BorderBlockColor)
    /// Sets style for both block borders
    let BorderBlockStyle = BorderClasses.BorderStyleParent(Property.BorderBlockStyle)
    /// Sets width for both block borders
    let BorderBlockWidth = BorderClasses.BorderWidthParent(Property.BorderBlockWidth)
    /// Shorthand for border-block-start
    let BorderBlockStart = BorderClasses.Border(Property.BorderBlockStart)
    /// Sets color for block-start border
    let BorderBlockStartColor = BorderClasses.BorderColorParent(Property.BorderBlockStartColor)
    /// Sets style for block-start border
    let BorderBlockStartStyle = BorderClasses.BorderStyleParent(Property.BorderBlockStartStyle)
    /// Sets width for block-start border
    let BorderBlockStartWidth = BorderClasses.BorderWidthParent(Property.BorderBlockStartWidth)
    /// Shorthand for border-block-end
    let BorderBlockEnd = BorderClasses.Border(Property.BorderBlockEnd)
    /// Sets color for block-end border
    let BorderBlockEndColor = BorderClasses.BorderColorParent(Property.BorderBlockEndColor)
    /// Sets style for block-end border
    let BorderBlockEndStyle = BorderClasses.BorderStyleParent(Property.BorderBlockEndStyle)
    /// Sets width for block-end border
    let BorderBlockEndWidth = BorderClasses.BorderWidthParent(Property.BorderBlockEndWidth)
    // Logical border-inline properties
    /// Shorthand for border-inline-start and border-inline-end
    let BorderInline = BorderClasses.Border(Property.BorderInline)
    /// Sets color for both inline borders
    let BorderInlineColor = BorderClasses.BorderColorParent(Property.BorderInlineColor)
    /// Sets style for both inline borders
    let BorderInlineStyle = BorderClasses.BorderStyleParent(Property.BorderInlineStyle)
    /// Sets width for both inline borders
    let BorderInlineWidth = BorderClasses.BorderWidthParent(Property.BorderInlineWidth)
    /// Shorthand for border-inline-start
    let BorderInlineStart = BorderClasses.Border(Property.BorderInlineStart)
    /// Sets color for inline-start border
    let BorderInlineStartColor = BorderClasses.BorderColorParent(Property.BorderInlineStartColor)
    /// Sets style for inline-start border
    let BorderInlineStartStyle = BorderClasses.BorderStyleParent(Property.BorderInlineStartStyle)
    /// Sets width for inline-start border
    let BorderInlineStartWidth = BorderClasses.BorderWidthParent(Property.BorderInlineStartWidth)
    /// Shorthand for border-inline-end
    let BorderInlineEnd = BorderClasses.Border(Property.BorderInlineEnd)
    /// Sets color for inline-end border
    let BorderInlineEndColor = BorderClasses.BorderColorParent(Property.BorderInlineEndColor)
    /// Sets style for inline-end border
    let BorderInlineEndStyle = BorderClasses.BorderStyleParent(Property.BorderInlineEndStyle)
    /// Sets width for inline-end border
    let BorderInlineEndWidth = BorderClasses.BorderWidthParent(Property.BorderInlineEndWidth)
