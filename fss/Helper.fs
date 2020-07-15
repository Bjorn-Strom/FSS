namespace Fss

module Helper =
    let rgb r g b = sprintf "rgb(%d, %d, %d)" r g b
    let hex value = sprintf "#%s" value