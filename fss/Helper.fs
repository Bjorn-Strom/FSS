namespace Fss

module Helper =
    let rgb r g b = sprintf "rgb(%d, %d, %d)" r g b
    let hex (value: string) =
        if value.StartsWith('#') then
            value
        else
            sprintf "#%s"value
