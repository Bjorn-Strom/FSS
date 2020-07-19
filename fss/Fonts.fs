namespace Fss

// https://developer.mozilla.org/en-US/docs/Web/CSS/font-size
module Fonts =
    type FontSize =
        // Absolute
        | XxSmall
        | XSmall
        | Small
        | Medium
        | Large
        | XLarge
        | XxLarge
        | XxxLarge
        // Relative
        | Smaller
        | Larger
        interface Utilities.Types.ICSSProperty

    let value v =
        match v with
            | XxSmall -> "xx-small"
            | XSmall -> "x-small"
            | Small -> "small"
            | Medium -> "medium"
            | Large -> "large"
            | XLarge -> "x-large"
            | XxLarge -> "xx-large"
            | XxxLarge -> "xxx-large"
            // Relative
            | Smaller -> "smaller"
            | Larger -> "larger"
    
    let fontSize = "fontSize"