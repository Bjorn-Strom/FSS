namespace Fss

module Helper =
    let floatToPercent (f: float): string = sprintf "%d%%" (int <| f * 100.0)

    let rgb (r: int) (g: int) (b: int) = sprintf "rgb(%d, %d, %d)" r g b
    let rgba (r: int) (g: int) (b: int) (a: float) = sprintf "rgba(%d, %d, %d, %f)" r g b a
    let hex (value: string) =
        if value.StartsWith("#") then
            value
        else
            sprintf "#%s"value
    let hsl (h: int) (s: float) (l: float) = 
        sprintf "hsl(%d, %s, %s)" 
            h 
            (floatToPercent s)
            (floatToPercent l)
    let hsla (h: int) (s: float) (l: float) (a: float) = 
        sprintf "hsla(%d, %s, %s, %s)" 
            h 
            (floatToPercent s) 
            (floatToPercent l) 
            (floatToPercent a)
