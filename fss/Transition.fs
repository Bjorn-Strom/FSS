namespace Fss

module Transition = 0
    (*
    type Transition =
        | BackgroundColorFOO

        | background
        | backgroundColor
        | backgroundPosition
        | backgroundSize
        | border
        | borderBottom
        | borderBottomColor
        | borderBottomLeftRadius
        | borderBottomRightRadius
        | borderBottomWidth
        | borderColor
        | borderLeft
        | borderLeftColor
        | borderLeftWidth
        | borderRadius
        | borderRight
        | borderRightColor
        | borderRightWidth
        | borderTop
        | borderTopColor
        | borderTopLeftRadius
        | borderTopRightRadius
        | borderTopWidth
        | borderWidth
        | bottom
        | boxShadow
        | caretColor
        | clip
        | clipPath
        | color
        | columnCount
        | columnGap
        | columnRule
        | columnRuleColor
        | columnRuleWidth
        | columnWidth
        | columns
        | filter
        | flex
        | flexBasis
        | flexGrow
        | flexShrink
        | font
        | fontSize
        | fontSizeAdjust
        | fontStretch
        | fontVariationSettings
        | fontWeight
        | gridColumnGap
        | gridGap
        | gridRowGap
        | height
        | left
        | letterSpacing
        | lineHeight
        | margin
        | marginBottom
        | marginLeft
        | marginRight
        | marginTop
        | mask
        | maskPosition
        | maskSize
        | maxHeight
        | maxWidth
        | minHeight
        | minWidth
        | objectPosition
        | offset
        | offsetAnchor
        | offsetDistance
        | offsetPath
        | offsetRotate
        | opacity
        | order
        | outline
        | outlineColor
        | outlineOffset
        | outlineWidth
        | padding
        | paddingBottom
        | paddingLeft
        | paddingRight
        | paddingTop
        | right
        | tabSize
        | textIndent
        | textShadow
        | top
        | transform
        | transformOrigin
        | verticalAlign
        | visibility
        | width
        | wordSpacing
        | zIndex


    let value (t: Transition): string =
        match t with
            | BackgroundColorFOO -> "background-color"
*)
(*
.myStyle {
    background-color: red;
    transition: background-color;
    transition-duration: 3s;
}

.myStyle:hover {
    background-color: green
}

let myStyle =
    fss
        [
            BackgroundColor red
            Transition ???
            TransitionDuration (sec 3.0)
            Hover 
                [
                    BackgroundColor green
                ]
        ]
*)