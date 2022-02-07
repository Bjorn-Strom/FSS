namespace FSSTests

open System
open Fss

module Generators =
    let pick source =
        source
        |> Array.sortBy (fun _ -> Random().Next())
        |> Array.head
        
    module PrimitiveGenerator =
        let int () = Random().Next()
        let intLimit limit = Random().Next() % limit
        let string () = Guid.NewGuid().ToString()
        let float () = Random().NextDouble()
        let listOf func = seq { for _ in 0 .. intLimit(10) -> func() } |> Seq.toList
        
    module UnitGenerator =
        let Troouba () =
            [|
                fun () -> Fss.Types.Px <| PrimitiveGenerator.int () 
                fun () -> Fss.Types.In <| PrimitiveGenerator.float () 
                fun () -> Fss.Types.Cm <| PrimitiveGenerator.float () 
                fun () -> Fss.Types.Mm <| PrimitiveGenerator.float () 
                fun () -> Fss.Types.Pt <| PrimitiveGenerator.float () 
                fun () -> Fss.Types.Pc <| PrimitiveGenerator.float () 
                fun () -> Fss.Types.Em' <| PrimitiveGenerator.float () 
                fun () -> Fss.Types.Rem <| PrimitiveGenerator.float () 
                fun () -> Fss.Types.Ex <| PrimitiveGenerator.float () 
                fun () -> Fss.Types.Ch <| PrimitiveGenerator.float () 
                fun () -> Fss.Types.Vw <| PrimitiveGenerator.float () 
                fun () -> Fss.Types.Vh <| PrimitiveGenerator.float () 
                fun () -> Fss.Types.VMax <| PrimitiveGenerator.float () 
                fun () -> Fss.Types.VMin <| PrimitiveGenerator.float () 
            |]
            |> pick 
            
        let percent () = Fss.Types.Percent <| PrimitiveGenerator.intLimit 100 
        let fraction () = Fss.Types.Fr <| PrimitiveGenerator.float()
        
        let lengthPercent () =
            [|
                (Troouba ()()) :> Fss.Types.ILengthPercentage
                (percent ()) :> Fss.Types.ILengthPercentage
            |]
            |> pick
        
        let angle () =
            [|
                fun () -> Fss.Types.Deg <| PrimitiveGenerator.float ()
                fun () -> Fss.Types.Grad <| PrimitiveGenerator.float ()
                fun () -> Fss.Types.Rad <| PrimitiveGenerator.float ()
                fun () -> Fss.Types.Turn <| PrimitiveGenerator.float ()
            |]
            |> pick
            
        let time () =
            [|
                fun () -> Fss.Types.Sec <| PrimitiveGenerator.float ()
                fun () -> Fss.Types.Ms <| PrimitiveGenerator.float ()
            |] |> pick
            
    module BaseColorGenerator =
        let color () =
            [|
                fun () -> Fss.Types.Color.Black
                fun () -> Fss.Types.Color.Silver
                fun () -> Fss.Types.Color.Gray
                fun () -> Fss.Types.Color.White
                fun () -> Fss.Types.Color.Maroon
                fun () -> Fss.Types.Color.Red
                fun () -> Fss.Types.Color.Purple
                fun () -> Fss.Types.Color.Fuchsia
                fun () -> Fss.Types.Color.Green
                fun () -> Fss.Types.Color.Lime
                fun () -> Fss.Types.Color.Olive
                fun () -> Fss.Types.Color.Yellow
                fun () -> Fss.Types.Color.Navy
                fun () -> Fss.Types.Color.Blue
                fun () -> Fss.Types.Color.Teal
                fun () -> Fss.Types.Color.Aqua
                fun () -> Fss.Types.Color.Orange
                fun () -> Fss.Types.Color.AliceBlue
                fun () -> Fss.Types.Color.AntiqueWhite
                fun () -> Fss.Types.Color.AquaMarine
                fun () -> Fss.Types.Color.Azure
                fun () -> Fss.Types.Color.Beige
                fun () -> Fss.Types.Color.Bisque
                fun () -> Fss.Types.Color.BlanchedAlmond
                fun () -> Fss.Types.Color.BlueViolet
                fun () -> Fss.Types.Color.Brown
                fun () -> Fss.Types.Color.Burlywood
                fun () -> Fss.Types.Color.CadetBlue
                fun () -> Fss.Types.Color.Chartreuse
                fun () -> Fss.Types.Color.Chocolate
                fun () -> Fss.Types.Color.Coral
                fun () -> Fss.Types.Color.CornflowerBlue
                fun () -> Fss.Types.Color.Cornsilk
                fun () -> Fss.Types.Color.Crimson
                fun () -> Fss.Types.Color.Cyan
                fun () -> Fss.Types.Color.DarkBlue
                fun () -> Fss.Types.Color.DarkCyan
                fun () -> Fss.Types.Color.DarkGoldenrod
                fun () -> Fss.Types.Color.DarkGray
                fun () -> Fss.Types.Color.DarkGreen
                fun () -> Fss.Types.Color.DarkKhaki
                fun () -> Fss.Types.Color.DarkMagenta
                fun () -> Fss.Types.Color.DarkOliveGreen
                fun () -> Fss.Types.Color.DarkOrange
                fun () -> Fss.Types.Color.DarkOrchid
                fun () -> Fss.Types.Color.DarkRed
                fun () -> Fss.Types.Color.DarkSalmon
                fun () -> Fss.Types.Color.DarkSeaGreen
                fun () -> Fss.Types.Color.DarkSlateBlue
                fun () -> Fss.Types.Color.DarkSlateGray
                fun () -> Fss.Types.Color.DarkTurquoise
                fun () -> Fss.Types.Color.DarkViolet
                fun () -> Fss.Types.Color.DeepPink
                fun () -> Fss.Types.Color.DeepSkyBlue
                fun () -> Fss.Types.Color.DimGrey
                fun () -> Fss.Types.Color.DodgerBlue
                fun () -> Fss.Types.Color.FireBrick
                fun () -> Fss.Types.Color.FloralWhite
                fun () -> Fss.Types.Color.ForestGreen
                fun () -> Fss.Types.Color.Gainsboro
                fun () -> Fss.Types.Color.GhostWhite
                fun () -> Fss.Types.Color.Gold
                fun () -> Fss.Types.Color.Goldenrod
                fun () -> Fss.Types.Color.GreenYellow
                fun () -> Fss.Types.Color.Grey
                fun () -> Fss.Types.Color.Honeydew
                fun () -> Fss.Types.Color.HotPink
                fun () -> Fss.Types.Color.IndianRed
                fun () -> Fss.Types.Color.Indigo
                fun () -> Fss.Types.Color.Ivory
                fun () -> Fss.Types.Color.Khaki
                fun () -> Fss.Types.Color.Lavender
                fun () -> Fss.Types.Color.LavenderBlush
                fun () -> Fss.Types.Color.LawnGreen
                fun () -> Fss.Types.Color.LemonChiffon
                fun () -> Fss.Types.Color.LightBlue
                fun () -> Fss.Types.Color.LightCoral
                fun () -> Fss.Types.Color.LightCyan
                fun () -> Fss.Types.Color.LightGoldenrodYellow
                fun () -> Fss.Types.Color.LightGray
                fun () -> Fss.Types.Color.LightGreen
                fun () -> Fss.Types.Color.LightGrey
                fun () -> Fss.Types.Color.LightPink
                fun () -> Fss.Types.Color.LightSalmon
                fun () -> Fss.Types.Color.LightSeaGreen
                fun () -> Fss.Types.Color.LightSkyBlue
                fun () -> Fss.Types.Color.LightSlateGrey
                fun () -> Fss.Types.Color.LightSteelBlue
                fun () -> Fss.Types.Color.LightYellow
                fun () -> Fss.Types.Color.LimeGreen
                fun () -> Fss.Types.Color.Linen
                fun () -> Fss.Types.Color.Magenta
                fun () -> Fss.Types.Color.MediumAquamarine
                fun () -> Fss.Types.Color.MediumBlue
                fun () -> Fss.Types.Color.MediumOrchid
                fun () -> Fss.Types.Color.MediumPurple
                fun () -> Fss.Types.Color.MediumSeaGreen
                fun () -> Fss.Types.Color.MediumSlateBlue
                fun () -> Fss.Types.Color.MediumSpringGreen
                fun () -> Fss.Types.Color.MediumTurquoise
                fun () -> Fss.Types.Color.MediumVioletRed
                fun () -> Fss.Types.Color.MidnightBlue
                fun () -> Fss.Types.Color.MintCream
                fun () -> Fss.Types.Color.MistyRose
                fun () -> Fss.Types.Color.Moccasin
                fun () -> Fss.Types.Color.NavajoWhite
                fun () -> Fss.Types.Color.OldLace
                fun () -> Fss.Types.Color.Olivedrab
                fun () -> Fss.Types.Color.OrangeRed
                fun () -> Fss.Types.Color.Orchid
                fun () -> Fss.Types.Color.PaleGoldenrod
                fun () -> Fss.Types.Color.PaleGreen
                fun () -> Fss.Types.Color.PaleTurquoise
                fun () -> Fss.Types.Color.PaleVioletred
                fun () -> Fss.Types.Color.PapayaWhip
                fun () -> Fss.Types.Color.Peachpuff
                fun () -> Fss.Types.Color.Peru
                fun () -> Fss.Types.Color.Pink
                fun () -> Fss.Types.Color.Plum
                fun () -> Fss.Types.Color.PowderBlue
                fun () -> Fss.Types.Color.RosyBrown
                fun () -> Fss.Types.Color.RoyalBlue
                fun () -> Fss.Types.Color.SaddleBrown
                fun () -> Fss.Types.Color.Salmon
                fun () -> Fss.Types.Color.SandyBrown
                fun () -> Fss.Types.Color.SeaGreen
                fun () -> Fss.Types.Color.SeaShell
                fun () -> Fss.Types.Color.Sienna
                fun () -> Fss.Types.Color.SkyBlue
                fun () -> Fss.Types.Color.SlateBlue
                fun () -> Fss.Types.Color.SlateGray
                fun () -> Fss.Types.Color.Snow
                fun () -> Fss.Types.Color.SpringGreen
                fun () -> Fss.Types.Color.SteelBlue
                fun () -> Fss.Types.Color.Tan
                fun () -> Fss.Types.Color.Thistle
                fun () -> Fss.Types.Color.Tomato
                fun () -> Fss.Types.Color.Turquoise
                fun () -> Fss.Types.Color.Violet
                fun () -> Fss.Types.Color.Wheat
                fun () -> Fss.Types.Color.WhiteSmoke
                fun () -> Fss.Types.Color.YellowGreen
                fun () -> Fss.Types.Color.RebeccaPurple
                fun () -> Fss.Types.Color.Transparent
                fun () -> Fss.Types.Color.CurrentColor
                fun () -> Fss.Types.Color.Rgb(PrimitiveGenerator.intLimit(255), PrimitiveGenerator.intLimit(255), PrimitiveGenerator.intLimit(255))
                fun () -> Fss.Types.Color.Rgba(PrimitiveGenerator.intLimit(255), PrimitiveGenerator.intLimit(255), PrimitiveGenerator.intLimit(255), PrimitiveGenerator.float())
                fun () -> Fss.Types.Color.Hex(PrimitiveGenerator.string())
                fun () -> Fss.Types.Color.Hsl(PrimitiveGenerator.intLimit(255), PrimitiveGenerator.intLimit(255), PrimitiveGenerator.intLimit(255))
                fun () -> Fss.Types.Color.Hsla(PrimitiveGenerator.intLimit(255),PrimitiveGenerator.intLimit(255),PrimitiveGenerator.intLimit(255),PrimitiveGenerator.float())
            |]
            |> pick
            
    module ContentSizeGenerator =
        let items =
            [|
                 fun () -> Width.value (UnitGenerator.lengthPercent())
                 fun () -> Width.maxContent 
                 fun () -> Width.minContent 
                 fun () -> Width.fitContent (UnitGenerator.lengthPercent()) 
                 fun () -> Width.auto 
                 fun () -> Width.initial 
                 fun () -> Width.inherit' 
                 fun () -> Width.unset 
                 fun () -> Width.revert 
                 fun () -> Height.value (UnitGenerator.lengthPercent()) 
                 fun () -> Height.maxContent 
                 fun () -> Height.minContent 
                 fun () -> Height.fitContent (UnitGenerator.lengthPercent()) 
                 fun () -> Height.auto 
                 fun () -> Height.initial 
                 fun () -> Height.inherit' 
                 fun () -> Height.unset 
                 fun () -> Height.revert 
                 fun () -> MinWidth.value (UnitGenerator.lengthPercent()) 
                 fun () -> MinWidth.maxContent 
                 fun () -> MinWidth.minContent 
                 fun () -> MinWidth.fitContent (UnitGenerator.lengthPercent()) 
                 fun () -> MinWidth.auto 
                 fun () -> MinWidth.initial 
                 fun () -> MinWidth.inherit' 
                 fun () -> MinWidth.unset 
                 fun () -> MinWidth.revert 
                 fun () -> MinHeight.value (UnitGenerator.lengthPercent()) 
                 fun () -> MinHeight.maxContent 
                 fun () -> MinHeight.minContent 
                 fun () -> MinHeight.fitContent (UnitGenerator.lengthPercent()) 
                 fun () -> MinHeight.auto 
                 fun () -> MinHeight.initial 
                 fun () -> MinHeight.inherit' 
                 fun () -> MinHeight.unset 
                 fun () -> MinHeight.revert 
            |]
        
    module BorderGenerator =
        let style() =
            [|
                Fss.Types.Border.Style.Hidden
                Fss.Types.Border.Style.Dotted
                Fss.Types.Border.Style.Dashed
                Fss.Types.Border.Style.Solid
                Fss.Types.Border.Style.Double
                Fss.Types.Border.Style.Groove
                Fss.Types.Border.Style.Ridge
                Fss.Types.Border.Style.Inset
                Fss.Types.Border.Style.Outset
            |]
            |> pick
            
        let imageRepeat() =
            [|
                Fss.Types.Border.Stretch
                Fss.Types.Border.Repeat
                Fss.Types.Border.Round
                Fss.Types.Border.Space
            |]
            |> pick
            
        let items = [|
            fun () -> Border.initial
            fun () -> Border.inherit'
            fun () -> Border.unset
            fun () -> Border.revert
            fun () -> Border.none
            fun () -> BorderStyle.hidden
            fun () -> BorderStyle.dotted
            fun () -> BorderStyle.dashed
            fun () -> BorderStyle.solid
            fun () -> BorderStyle.double
            fun () -> BorderStyle.groove
            fun () -> BorderStyle.ridge
            fun () -> BorderStyle.inset
            fun () -> BorderStyle.outset
            fun () -> BorderStyle.value(style(), style(), style(), style())
            fun () -> BorderStyle.none
            fun () -> BorderStyle.initial
            fun () -> BorderStyle.inherit'
            fun () -> BorderStyle.unset
            fun () -> BorderStyle.revert
            fun () -> BorderTopStyle.hidden
            fun () -> BorderTopStyle.dotted
            fun () -> BorderTopStyle.dashed
            fun () -> BorderTopStyle.solid
            fun () -> BorderTopStyle.double
            fun () -> BorderTopStyle.groove
            fun () -> BorderTopStyle.ridge
            fun () -> BorderTopStyle.inset
            fun () -> BorderTopStyle.outset
            fun () -> BorderTopStyle.none
            fun () -> BorderTopStyle.initial
            fun () -> BorderTopStyle.inherit'
            fun () -> BorderTopStyle.unset
            fun () -> BorderTopStyle.revert
            fun () -> BorderRightStyle.hidden
            fun () -> BorderRightStyle.dotted
            fun () -> BorderRightStyle.dashed
            fun () -> BorderRightStyle.solid
            fun () -> BorderRightStyle.double
            fun () -> BorderRightStyle.groove
            fun () -> BorderRightStyle.ridge
            fun () -> BorderRightStyle.inset
            fun () -> BorderRightStyle.outset
            fun () -> BorderRightStyle.none
            fun () -> BorderRightStyle.initial
            fun () -> BorderRightStyle.inherit'
            fun () -> BorderRightStyle.unset
            fun () -> BorderRightStyle.revert
            fun () -> BorderBottomStyle.hidden
            fun () -> BorderBottomStyle.dotted
            fun () -> BorderBottomStyle.dashed
            fun () -> BorderBottomStyle.solid
            fun () -> BorderBottomStyle.double
            fun () -> BorderBottomStyle.groove
            fun () -> BorderBottomStyle.ridge
            fun () -> BorderBottomStyle.inset
            fun () -> BorderBottomStyle.outset
            fun () -> BorderBottomStyle.none
            fun () -> BorderBottomStyle.initial
            fun () -> BorderBottomStyle.inherit'
            fun () -> BorderBottomStyle.unset
            fun () -> BorderBottomStyle.revert
            fun () -> BorderLeftStyle.hidden
            fun () -> BorderLeftStyle.dotted
            fun () -> BorderLeftStyle.dashed
            fun () -> BorderLeftStyle.solid
            fun () -> BorderLeftStyle.double
            fun () -> BorderLeftStyle.groove
            fun () -> BorderLeftStyle.ridge
            fun () -> BorderLeftStyle.inset
            fun () -> BorderLeftStyle.outset
            fun () -> BorderLeftStyle.none
            fun () -> BorderLeftStyle.initial
            fun () -> BorderLeftStyle.inherit'
            fun () -> BorderLeftStyle.unset
            fun () -> BorderLeftStyle.revert
            fun () -> BorderRadius.value (UnitGenerator.Troouba ()())
            fun () -> BorderTopLeftRadius.value (UnitGenerator.lengthPercent())
            fun () -> BorderTopRightRadius.value (UnitGenerator.lengthPercent())
            fun () -> BorderBottomLeftRadius.value (UnitGenerator.lengthPercent())
            fun () -> BorderBottomRightRadius.value (UnitGenerator.lengthPercent())
            fun () -> BorderRadius.value
                          (UnitGenerator.lengthPercent(),
                           UnitGenerator.lengthPercent(),
                           UnitGenerator.lengthPercent(),
                           UnitGenerator.lengthPercent())
            fun () -> BorderTopLeftRadius.initial
            fun () -> BorderTopRightRadius.inherit'
            fun () -> BorderBottomLeftRadius.unset
            fun () -> BorderBottomLeftRadius.revert
            fun () -> BorderBottomRightRadius.initial
            fun () -> BorderRadius.inherit'
            fun () -> BorderRadius.inherit'
            fun () -> BorderRadius.unset
            fun () -> BorderRadius.revert
            fun () -> BorderWidth.value (UnitGenerator.lengthPercent())
            fun () -> BorderWidth.thin
            fun () -> BorderWidth.medium
            fun () -> BorderWidth.thick
            fun () -> BorderWidth.initial
            fun () -> BorderWidth.inherit'
            fun () -> BorderWidth.unset
            fun () -> BorderWidth.revert
            fun () -> BorderWidth.value (UnitGenerator.lengthPercent(), UnitGenerator.lengthPercent(), UnitGenerator.lengthPercent(), UnitGenerator.lengthPercent())
            fun () -> BorderTopWidth.value (UnitGenerator.lengthPercent())
            fun () -> BorderTopWidth.thin
            fun () -> BorderTopWidth.medium
            fun () -> BorderTopWidth.thick
            fun () -> BorderTopWidth.initial
            fun () -> BorderTopWidth.inherit'
            fun () -> BorderTopWidth.unset
            fun () -> BorderTopWidth.revert
            fun () -> BorderRightWidth.value (UnitGenerator.lengthPercent())
            fun () -> BorderRightWidth.thin
            fun () -> BorderRightWidth.medium
            fun () -> BorderRightWidth.thick
            fun () -> BorderRightWidth.initial
            fun () -> BorderRightWidth.inherit'
            fun () -> BorderRightWidth.unset
            fun () -> BorderRightWidth.revert
            fun () -> BorderBottomWidth.value (UnitGenerator.lengthPercent())
            fun () -> BorderBottomWidth.thin
            fun () -> BorderBottomWidth.medium
            fun () -> BorderBottomWidth.thick
            fun () -> BorderBottomWidth.initial
            fun () -> BorderBottomWidth.inherit'
            fun () -> BorderBottomWidth.unset
            fun () -> BorderBottomWidth.revert
            fun () -> BorderLeftWidth.value (UnitGenerator.lengthPercent())
            fun () -> BorderLeftWidth.thin
            fun () -> BorderLeftWidth.medium
            fun () -> BorderLeftWidth.thick
            fun () -> BorderLeftWidth.initial
            fun () -> BorderLeftWidth.inherit'
            fun () -> BorderLeftWidth.unset
            fun () -> BorderLeftWidth.revert
            fun () -> BorderColor.red
            fun () -> BorderColor.initial
            fun () -> BorderColor.inherit'
            fun () -> BorderColor.unset
            fun () -> BorderColor.revert
            fun () -> BorderColor.value (BaseColorGenerator.color()(), BaseColorGenerator.color()(), BaseColorGenerator.color()())
            fun () -> BorderTopColor.rgb (PrimitiveGenerator.intLimit(255)) (PrimitiveGenerator.intLimit(255)) (PrimitiveGenerator.intLimit(255))
            fun () -> BorderRightColor.green
            fun () -> BorderBottomColor.blue
            fun () -> BorderLeftColor.white
            fun () -> BorderCollapse.collapse
            fun () -> BorderCollapse.separate
            fun () -> BorderCollapse.initial
            fun () -> BorderCollapse.inherit'
            fun () -> BorderCollapse.unset
            fun () -> BorderCollapse.revert
            fun () -> BorderSpacing.value (UnitGenerator.lengthPercent())
            fun () -> BorderSpacing.value (UnitGenerator.lengthPercent(), UnitGenerator.lengthPercent())
            fun () -> BorderSpacing.initial
            fun () -> BorderSpacing.inherit'
            fun () -> BorderSpacing.unset
            fun () -> BorderSpacing.revert
            fun () -> BorderImageSource.none
            fun () -> BorderImageSource.url $"{PrimitiveGenerator.string()}.jpg"
            fun () -> BorderImageSource.linearGradient(UnitGenerator.angle()(), [ BaseColorGenerator.color()(), UnitGenerator.percent(); BaseColorGenerator.color()(), UnitGenerator.percent() ])
            fun () -> BorderImageSource.inherit'
            fun () -> BorderImageSource.initial
            fun () -> BorderImageSource.unset
            fun () -> BorderImageWidth.auto
            fun () -> BorderImageWidth.value (UnitGenerator.lengthPercent())
            fun () -> BorderImageWidth.value (PrimitiveGenerator.int ())
            fun () -> BorderImageWidth.value (UnitGenerator.lengthPercent(), UnitGenerator.lengthPercent())
            fun () -> BorderImageWidth.value (UnitGenerator.lengthPercent(), UnitGenerator.lengthPercent(), UnitGenerator.lengthPercent(), UnitGenerator.lengthPercent())
            fun () -> BorderImageWidth.inherit'
            fun () -> BorderImageWidth.initial
            fun () -> BorderImageWidth.unset
            fun () -> BorderImageWidth.revert
            fun () -> BorderImageRepeat.stretch
            fun () -> BorderImageRepeat.repeat
            fun () -> BorderImageRepeat.round
            fun () -> BorderImageRepeat.space
            fun () -> BorderImageRepeat.value(imageRepeat(), imageRepeat())
            fun () -> BorderImageRepeat.inherit'
            fun () -> BorderImageRepeat.initial
            fun () -> BorderImageRepeat.unset
            fun () -> BorderImageRepeat.revert
            fun () -> BorderImageSlice.value (UnitGenerator.lengthPercent())
            fun () -> BorderImageSlice.value (UnitGenerator.lengthPercent(), UnitGenerator.lengthPercent())
            fun () -> BorderImageSlice.value (UnitGenerator.lengthPercent(), UnitGenerator.lengthPercent(), UnitGenerator.lengthPercent())
            fun () -> BorderImageSlice.inherit'
            fun () -> BorderImageSlice.initial
            fun () -> BorderImageSlice.unset
            fun () -> BorderImageSlice.revert
            fun () -> BorderImageOutset.value (UnitGenerator.lengthPercent())
            fun () -> BorderImageOutset.value (PrimitiveGenerator.float())
            fun () -> BorderImageOutset.value(PrimitiveGenerator.float(), PrimitiveGenerator.float())
            fun () -> BorderImageOutset.value (UnitGenerator.lengthPercent(), UnitGenerator.lengthPercent(), UnitGenerator.lengthPercent(), UnitGenerator.lengthPercent())
            fun () -> BorderImageOutset.inherit'
            fun () -> BorderImageOutset.initial
            fun () -> BorderImageOutset.unset
            fun () -> BorderImageOutset.revert |]
        
    module MarginGenerator =
        let items = [|
                fun () -> MarginTop.value (UnitGenerator.lengthPercent())
                fun () -> MarginTop.inherit' 
                fun () -> MarginTop.initial 
                fun () -> MarginTop.unset 
                fun () -> MarginTop.revert 
                fun () -> MarginRight.value (UnitGenerator.lengthPercent())
                fun () -> MarginRight.inherit' 
                fun () -> MarginRight.initial 
                fun () -> MarginRight.unset 
                fun () -> MarginRight.revert 
                fun () -> MarginBottom.value (UnitGenerator.lengthPercent())
                fun () -> MarginBottom.inherit' 
                fun () -> MarginBottom.initial 
                fun () -> MarginBottom.unset 
                fun () -> MarginBottom.revert 
                fun () -> MarginLeft.value (UnitGenerator.lengthPercent())
                fun () -> MarginLeft.inherit' 
                fun () -> MarginLeft.initial 
                fun () -> MarginLeft.unset 
                fun () -> MarginLeft.revert 
                fun () -> Margin.value (UnitGenerator.lengthPercent())
                fun () -> Margin.auto
                fun () -> Margin.inherit'
                fun () -> Margin.initial
                fun () -> Margin.unset 
                fun () -> Margin.revert 
                fun () -> Margin.value ((UnitGenerator.lengthPercent()), (UnitGenerator.lengthPercent()), (UnitGenerator.lengthPercent()), (UnitGenerator.lengthPercent())) 
                fun () -> MarginInlineStart.value (UnitGenerator.lengthPercent())
                fun () -> MarginInlineStart.initial
                fun () -> MarginInlineStart.unset 
                fun () -> MarginInlineStart.inherit'
                fun () -> MarginInlineStart.initial
                fun () -> MarginInlineStart.unset 
                fun () -> MarginInlineStart.revert 
                fun () -> MarginInlineEnd.value (UnitGenerator.lengthPercent())
                fun () -> MarginInlineEnd.initial
                fun () -> MarginInlineEnd.unset 
                fun () -> MarginInlineEnd.inherit'
                fun () -> MarginInlineEnd.revert
                fun () -> MarginBlockStart.value (UnitGenerator.lengthPercent())
                fun () -> MarginBlockStart.initial
                fun () -> MarginBlockStart.unset 
                fun () -> MarginBlockStart.inherit'
                fun () -> MarginBlockStart.initial
                fun () -> MarginBlockStart.unset 
                fun () -> MarginBlockEnd.value (UnitGenerator.lengthPercent())
                fun () -> MarginBlockEnd.initial
                fun () -> MarginBlockEnd.unset 
                fun () -> MarginBlockEnd.inherit'
                fun () -> MarginBlockEnd.initial
                fun () -> MarginBlockEnd.unset 
        |]
        
    module PaddingGenerator =
        let items = [|
                fun () -> PaddingTop.value (UnitGenerator.lengthPercent())
                fun () -> PaddingTop.inherit' 
                fun () -> PaddingTop.initial 
                fun () -> PaddingTop.unset 
                fun () -> PaddingTop.revert 
                fun () -> PaddingRight.value (UnitGenerator.lengthPercent())
                fun () -> PaddingRight.inherit' 
                fun () -> PaddingRight.initial 
                fun () -> PaddingRight.unset 
                fun () -> PaddingRight.revert 
                fun () -> PaddingBottom.value (UnitGenerator.lengthPercent())
                fun () -> PaddingBottom.inherit' 
                fun () -> PaddingBottom.initial 
                fun () -> PaddingBottom.unset 
                fun () -> PaddingBottom.revert 
                fun () -> PaddingLeft.value (UnitGenerator.lengthPercent())
                fun () -> PaddingLeft.inherit' 
                fun () -> PaddingLeft.initial 
                fun () -> PaddingLeft.unset 
                fun () -> PaddingLeft.revert 
                fun () -> Padding.value (UnitGenerator.lengthPercent())
                fun () -> Padding.auto
                fun () -> Padding.inherit'
                fun () -> Padding.initial
                fun () -> Padding.unset 
                fun () -> Padding.revert 
                fun () -> Padding.value ((UnitGenerator.lengthPercent()), (UnitGenerator.lengthPercent()), (UnitGenerator.lengthPercent()), (UnitGenerator.lengthPercent())) 
                fun () -> PaddingInlineStart.value (UnitGenerator.lengthPercent())
                fun () -> PaddingInlineStart.initial
                fun () -> PaddingInlineStart.unset 
                fun () -> PaddingInlineStart.inherit'
                fun () -> PaddingInlineStart.initial
                fun () -> PaddingInlineStart.unset 
                fun () -> PaddingInlineStart.revert 
                fun () -> PaddingInlineEnd.value (UnitGenerator.lengthPercent())
                fun () -> PaddingInlineEnd.initial
                fun () -> PaddingInlineEnd.unset 
                fun () -> PaddingInlineEnd.inherit'
                fun () -> PaddingInlineEnd.revert
                fun () -> PaddingBlockStart.value (UnitGenerator.lengthPercent())
                fun () -> PaddingBlockStart.initial
                fun () -> PaddingBlockStart.unset 
                fun () -> PaddingBlockStart.inherit'
                fun () -> PaddingBlockStart.initial
                fun () -> PaddingBlockStart.unset 
                fun () -> PaddingBlockEnd.value (UnitGenerator.lengthPercent())
                fun () -> PaddingBlockEnd.initial
                fun () -> PaddingBlockEnd.unset 
                fun () -> PaddingBlockEnd.inherit'
                fun () -> PaddingBlockEnd.initial
                fun () -> PaddingBlockEnd.unset 
        |]
        
    module ColorGenerator =
        let items = [|
            fun () -> ColorAdjust.exact
            fun () -> ColorAdjust.economy
            fun () -> ColorAdjust.inherit' 
            fun () -> ColorAdjust.initial 
            fun () -> ColorAdjust.unset 
            fun () -> ColorAdjust.revert 
            fun () -> Color.aliceBlue 
            fun () -> Color.rgb (PrimitiveGenerator.intLimit(255)) (PrimitiveGenerator.intLimit(255)) (PrimitiveGenerator.intLimit(255))
            fun () -> Color.rgba (PrimitiveGenerator.intLimit(255)) (PrimitiveGenerator.intLimit(255)) (PrimitiveGenerator.intLimit(255)) (PrimitiveGenerator.float())
            fun () -> Color.hex (PrimitiveGenerator.string())
            fun () -> Color.hex (PrimitiveGenerator.string())
            fun () -> Color.hsl (PrimitiveGenerator.intLimit(255)) (PrimitiveGenerator.intLimit(255)) (PrimitiveGenerator.intLimit(255))
            fun () -> Color.hsla (PrimitiveGenerator.intLimit(255)) (PrimitiveGenerator.intLimit(255)) (PrimitiveGenerator.intLimit(255)) (PrimitiveGenerator.intLimit(100))
            fun () -> Color.inherit' 
            fun () -> Color.initial 
            fun () -> Color.unset 
            fun () -> Color.revert 
            fun () -> Color.value (BaseColorGenerator.color()())
        |]
        
    module BackgroundGenerator =
        let repeat () =
            [|
                Fss.Types.Background.RepeatX
                Fss.Types.Background.RepeatY
                Fss.Types.Background.Repeat
                Fss.Types.Background.Space
                Fss.Types.Background.Round
                Fss.Types.Background.NoRepeat
            |] |> pick
        let size () =
            [|
                Fss.Types.Background.Cover
                Fss.Types.Background.Contain
            |] |> pick
        let blendMode () =
            [|
                Fss.Types.Background.Multiply
                Fss.Types.Background.Screen
                Fss.Types.Background.Overlay
                Fss.Types.Background.Darken
                Fss.Types.Background.Lighten
                Fss.Types.Background.ColorDodge
                Fss.Types.Background.ColorBurn
                Fss.Types.Background.HardLight
                Fss.Types.Background.SoftLight
                Fss.Types.Background.Difference
                Fss.Types.Background.Exclusion
                Fss.Types.Background.Hue
                Fss.Types.Background.Saturation
                Fss.Types.Background.Color
                Fss.Types.Background.Luminosity
            |] |> pick
        let items = [|
            fun () -> BackgroundColor.red 
            fun () -> BackgroundColor.value (rgb (PrimitiveGenerator.int()) (PrimitiveGenerator.int()) (PrimitiveGenerator.int())) 
            fun () -> BackgroundColor.initial
            fun () -> BackgroundColor.inherit'
            fun () -> BackgroundColor.unset
            fun () -> BackgroundColor.revert
            fun () -> BackgroundImage.url $"{PrimitiveGenerator.string()}.png" 
            fun () -> BackgroundImage.linearGradient ((UnitGenerator.angle()(), [ Fss.Types.Color.Red, UnitGenerator.percent(); Fss.Types.Color.Blue, UnitGenerator.percent() ])) 
            fun () -> BackgroundImage.radialGradient(Fss.Types.Image.Circle, Fss.Types.Image.ClosestSide, UnitGenerator.percent(), UnitGenerator.percent(), [ hex (PrimitiveGenerator.string()), UnitGenerator.percent(); hex (PrimitiveGenerator.string()), UnitGenerator.percent()])
            fun () -> BackgroundImage.radialGradient(Fss.Types.Image.Circle, Fss.Types.Image.ClosestCorner, UnitGenerator.percent(), UnitGenerator.percent(), [ hex (PrimitiveGenerator.string()), UnitGenerator.percent(); hex (PrimitiveGenerator.string()), UnitGenerator.percent()])
            fun () -> BackgroundImage.radialGradient(Fss.Types.Image.Circle, Fss.Types.Image.FarthestSide, UnitGenerator.percent(), UnitGenerator.percent(), [ hex (PrimitiveGenerator.string()), UnitGenerator.percent(); hex (PrimitiveGenerator.string()), UnitGenerator.percent()])
            fun () -> BackgroundImage.radialGradient(Fss.Types.Image.Circle, Fss.Types.Image.FarthestCorner, UnitGenerator.percent(), UnitGenerator.percent(), [ hex (PrimitiveGenerator.string()), UnitGenerator.percent(); hex (PrimitiveGenerator.string()), UnitGenerator.percent()])
            fun () -> BackgroundImage.radialGradient(Fss.Types.Image.Ellipse, Fss.Types.Image.ClosestSide, UnitGenerator.percent(), UnitGenerator.percent(), [ hex (PrimitiveGenerator.string()), UnitGenerator.percent(); hex (PrimitiveGenerator.string()), UnitGenerator.percent()])
            fun () -> BackgroundImage.radialGradient(Fss.Types.Image.Ellipse, Fss.Types.Image.ClosestCorner, UnitGenerator.percent(), UnitGenerator.percent(), [ hex (PrimitiveGenerator.string()), UnitGenerator.percent(); hex (PrimitiveGenerator.string()), UnitGenerator.percent()])
            fun () -> BackgroundImage.radialGradient(Fss.Types.Image.Ellipse, Fss.Types.Image.FarthestSide, UnitGenerator.percent(), UnitGenerator.percent(), [ hex (PrimitiveGenerator.string()), UnitGenerator.percent(); hex (PrimitiveGenerator.string()), UnitGenerator.percent()])
            fun () -> BackgroundImage.radialGradient(Fss.Types.Image.Ellipse, Fss.Types.Image.FarthestCorner, UnitGenerator.percent(), UnitGenerator.percent(), [ hex (PrimitiveGenerator.string()), UnitGenerator.percent(); hex (PrimitiveGenerator.string()), UnitGenerator.percent()])
            fun () -> BackgroundImage.conicGradient(UnitGenerator.angle()(), UnitGenerator.percent(), UnitGenerator.percent(), [ BaseColorGenerator.color()(), UnitGenerator.angle()(); BaseColorGenerator.color()(), UnitGenerator.angle()(); BaseColorGenerator.color()(), UnitGenerator.angle()(); BaseColorGenerator.color()(), UnitGenerator.angle()(); BaseColorGenerator.color()(), UnitGenerator.angle()(); ])
            fun () -> BackgroundImage.conicGradient(UnitGenerator.angle()(), UnitGenerator.percent(), UnitGenerator.percent(), [ hex (PrimitiveGenerator.string()), UnitGenerator.angle()(); hex (PrimitiveGenerator.string()), UnitGenerator.angle()() ])
            fun () -> BackgroundImage.repeatingConicGradient(UnitGenerator.angle()(), UnitGenerator.percent(), UnitGenerator.percent(), [ BaseColorGenerator.color()(), UnitGenerator.percent(); BaseColorGenerator.color()(), UnitGenerator.percent(); BaseColorGenerator.color()(), UnitGenerator.percent(); BaseColorGenerator.color()(), UnitGenerator.percent(); ]) 
            fun () -> BackgroundPosition.top 
            fun () -> BackgroundPosition.bottom
            fun () -> BackgroundPosition.left
            fun () -> BackgroundPosition.right
            fun () -> BackgroundPosition.center
            fun () -> BackgroundPosition.value (UnitGenerator.percent())
            fun () -> BackgroundPosition.initial
            fun () -> BackgroundPosition.inherit'
            fun () -> BackgroundPosition.unset
            fun () -> BackgroundOrigin.borderBox
            fun () -> BackgroundOrigin.paddingBox
            fun () -> BackgroundOrigin.contentBox
            fun () -> BackgroundOrigin.inherit' 
            fun () -> BackgroundOrigin.initial 
            fun () -> BackgroundOrigin.unset 
            fun () -> BackgroundOrigin.revert 
            fun () -> BackgroundClip.text
            fun () -> BackgroundClip.borderBox 
            fun () -> BackgroundClip.paddingBox
            fun () -> BackgroundClip.contentBox
            fun () -> BackgroundClip.inherit' 
            fun () -> BackgroundClip.initial
            fun () -> BackgroundClip.unset 
            fun () -> BackgroundClip.revert 
            fun () -> BackgroundRepeat.repeatX 
            fun () -> BackgroundRepeat.repeatY 
            fun () -> BackgroundRepeat.repeat
            fun () -> BackgroundRepeat.space
            fun () -> BackgroundRepeat.round
            fun () -> BackgroundRepeat.noRepeat
            fun () -> BackgroundRepeat.inherit' 
            fun () -> BackgroundRepeat.initial
            fun () -> BackgroundRepeat.unset 
            fun () -> BackgroundRepeat.revert 
            fun () -> BackgroundRepeat.value(repeat(), repeat()) 
            fun () -> BackgroundSize.cover
            fun () -> BackgroundSize.contain
            fun () -> BackgroundSize.value (size())
            fun () -> BackgroundSize.value (UnitGenerator.percent())
            fun () -> BackgroundSize.auto 
            fun () -> BackgroundSize.inherit' 
            fun () -> BackgroundSize.initial
            fun () -> BackgroundSize.unset 
            fun () -> BackgroundSize.revert 
            fun () -> BackgroundAttachment.scroll
            fun () -> BackgroundAttachment.fixed'
            fun () -> BackgroundAttachment.local
            fun () -> BackgroundAttachment.inherit' 
            fun () -> BackgroundAttachment.initial 
            fun () -> BackgroundAttachment.unset 
            fun () -> BackgroundAttachment.revert 
            fun () -> BackgroundBlendMode.multiply
            fun () -> BackgroundBlendMode.screen
            fun () -> BackgroundBlendMode.overlay
            fun () -> BackgroundBlendMode.darken
            fun () -> BackgroundBlendMode.lighten
            fun () -> BackgroundBlendMode.colorDodge
            fun () -> BackgroundBlendMode.colorBurn
            fun () -> BackgroundBlendMode.hardLight
            fun () -> BackgroundBlendMode.softLight
            fun () -> BackgroundBlendMode.difference
            fun () -> BackgroundBlendMode.exclusion
            fun () -> BackgroundBlendMode.hue
            fun () -> BackgroundBlendMode.saturation
            fun () -> BackgroundBlendMode.color
            fun () -> BackgroundBlendMode.luminosity
            fun () -> BackgroundBlendMode.value (blendMode())
            fun () -> BackgroundBlendMode.normal 
            fun () -> BackgroundBlendMode.inherit' 
            fun () -> BackgroundBlendMode.initial 
            fun () -> BackgroundBlendMode.unset 
            fun () -> BackgroundBlendMode.revert 
            fun () -> Isolation.isolate 
            fun () -> Isolation.auto 
            fun () -> Isolation.inherit' 
            fun () -> Isolation.initial 
            fun () -> Isolation.unset 
            fun () -> Isolation.revert 
            fun () -> BoxDecorationBreak.clone 
            fun () -> BoxDecorationBreak.slice 
            fun () -> BoxDecorationBreak.inherit' 
            fun () -> BoxDecorationBreak.initial 
            fun () -> BoxDecorationBreak.unset 
            fun () -> BoxDecorationBreak.revert 
        |]
        
    module CursorGenerator =
        let items =
            [|
                fun () -> Cursor.url $"{PrimitiveGenerator.string()}.cur"
                fun () -> Cursor.url ($"{PrimitiveGenerator.string()}.cur", PrimitiveGenerator.int(), PrimitiveGenerator.int())
                fun () -> Cursor.none
                fun () -> Cursor.auto
                fun () -> Cursor.inherit'
                fun () -> Cursor.initial
                fun () -> Cursor.unset
                fun () -> Cursor.revert
                fun () -> Cursor.alias
                fun () -> Cursor.contextMenu
                fun () -> Cursor.help
                fun () -> Cursor.pointer
                fun () -> Cursor.progress
                fun () -> Cursor.wait
                fun () -> Cursor.cell
                fun () -> Cursor.crosshair
                fun () -> Cursor.text
                fun () -> Cursor.verticalText
                fun () -> Cursor.alias
                fun () -> Cursor.copy
                fun () -> Cursor.move
                fun () -> Cursor.noDrop
                fun () -> Cursor.notAllowed
                fun () -> Cursor.allScroll
                fun () -> Cursor.colResize
                fun () -> Cursor.rowResize
                fun () -> Cursor.nResize
                fun () -> Cursor.eResize
                fun () -> Cursor.sResize
                fun () -> Cursor.wResize
                fun () -> Cursor.nsResize
                fun () -> Cursor.ewResize
                fun () -> Cursor.neResize
                fun () -> Cursor.nwResize
                fun () -> Cursor.seResize
                fun () -> Cursor.swResize
                fun () -> Cursor.neswResize
                fun () -> Cursor.nwseResize
            |]
            
    module GridGenerator =
        let items =
            [|
                fun () -> GridArea.value (PrimitiveGenerator.string())
                fun () -> GridArea.value $"{(PrimitiveGenerator.string())} / {(PrimitiveGenerator.string())}" 
                fun () -> GridArea.value $"span {PrimitiveGenerator.int()} / {(PrimitiveGenerator.string())}" 
                fun () -> GridArea.auto 
                fun () -> GridArea.inherit'
                fun () -> GridArea.initial
                fun () -> GridArea.unset
                fun () -> GridArea.revert
                fun () -> GridColumn.value $"{(PrimitiveGenerator.string())} / {(PrimitiveGenerator.string())}" 
                fun () -> GridColumn.value $"{(PrimitiveGenerator.string())} / {PrimitiveGenerator.int()}" 
                fun () -> GridColumn.auto
                fun () -> GridColumn.inherit'
                fun () -> GridColumn.initial
                fun () -> GridColumn.unset
                fun () -> GridColumn.revert
                fun () -> GridColumnStart.auto
                fun () -> GridColumnStart.value (PrimitiveGenerator.int())
                fun () -> GridColumnStart.value  (PrimitiveGenerator.string())
                fun () -> GridColumnStart.value (PrimitiveGenerator.int(), "area") 
                fun () -> GridColumnStart.span (PrimitiveGenerator.int())
                fun () -> GridColumnStart.inherit'
                fun () -> GridColumnStart.initial
                fun () -> GridColumnStart.unset
                fun () -> GridColumnStart.revert
                fun () -> GridColumnEnd.auto
                fun () -> GridColumnEnd.value (PrimitiveGenerator.int())
                fun () -> GridColumnEnd.value  (PrimitiveGenerator.string())
                fun () -> GridColumnEnd.value ((PrimitiveGenerator.int()),  (PrimitiveGenerator.string())) 
                fun () -> GridColumnEnd.span (PrimitiveGenerator.int())
                fun () -> GridColumnEnd.inherit'
                fun () -> GridColumnEnd.initial
                fun () -> GridColumnEnd.unset
                fun () -> GridColumnEnd.revert
                fun () -> GridRow.value $"{(PrimitiveGenerator.string())} / {(PrimitiveGenerator.string())}" 
                fun () -> GridRow.value ((PrimitiveGenerator.string()), (PrimitiveGenerator.int())) 
                fun () -> GridRow.auto
                fun () -> GridRow.inherit'
                fun () -> GridRow.initial
                fun () -> GridRow.unset
                fun () -> GridRow.revert
                fun () -> GridRowStart.auto
                fun () -> GridRowStart.value (PrimitiveGenerator.int())
                fun () -> GridRowStart.value (PrimitiveGenerator.string())
                fun () -> GridRowStart.value ((PrimitiveGenerator.int()), (PrimitiveGenerator.string())) 
                fun () -> GridRowStart.span (PrimitiveGenerator.int())
                fun () -> GridRowStart.inherit'
                fun () -> GridRowStart.initial
                fun () -> GridRowStart.unset
                fun () -> GridRowStart.revert
                fun () -> GridRowEnd.auto
                fun () -> GridRowEnd.value (PrimitiveGenerator.int())
                fun () -> GridRowEnd.value (PrimitiveGenerator.string())
                fun () -> GridRowEnd.value ((PrimitiveGenerator.int()), (PrimitiveGenerator.string())) 
                fun () -> GridRowEnd.span (PrimitiveGenerator.int())
                fun () -> GridRowEnd.inherit'
                fun () -> GridRowEnd.initial
                fun () -> GridRowEnd.unset
                fun () -> GridRowEnd.revert
                fun () -> GridGap.value (UnitGenerator.lengthPercent())
                fun () -> GridGap.value (UnitGenerator.lengthPercent(), UnitGenerator.lengthPercent()) 
                fun () -> GridGap.inherit'
                fun () -> GridGap.initial
                fun () -> GridGap.unset
                fun () -> GridGap.revert
                fun () -> GridRowGap.normal
                fun () -> GridRowGap.value (UnitGenerator.lengthPercent())
                fun () -> GridRowGap.inherit'
                fun () -> GridRowGap.initial
                fun () -> GridRowGap.unset
                fun () -> GridRowGap.revert
                fun () -> GridColumnGap.normal
                fun () -> GridColumnGap.value (UnitGenerator.lengthPercent())
                fun () -> GridColumnGap.inherit'
                fun () -> GridColumnGap.initial
                fun () -> GridColumnGap.unset
                fun () -> GridColumnGap.revert
                fun () -> GridTemplateRows.value (UnitGenerator.lengthPercent())
                fun () -> GridTemplateRows.minMax ((UnitGenerator.lengthPercent()), (UnitGenerator.fraction())) 
                fun () -> GridTemplateRows.repeat(PrimitiveGenerator.int(), UnitGenerator.fraction()) 
                fun () -> GridTemplateRows.repeat(PrimitiveGenerator.int(), UnitGenerator.lengthPercent())
                fun () -> GridTemplateRows.repeat((PrimitiveGenerator.int()), Fss.Types.ContentSize.MinContent) 
                fun () -> GridTemplateRows.repeat((PrimitiveGenerator.int()), Fss.Types.ContentSize.MaxContent) 
                fun () -> GridTemplateRows.repeat((PrimitiveGenerator.int()), [Fss.Types.ContentSize.MinContent; Fss.Types.ContentSize.MaxContent]) 
                fun () -> GridTemplateRows.repeat(Fss.Types.Grid.AutoFill, UnitGenerator.lengthPercent())
                fun () -> GridTemplateRows.repeat(Fss.Types.Grid.AutoFit, UnitGenerator.lengthPercent())
                fun () -> GridTemplateRows.fitContent(UnitGenerator.lengthPercent())
                fun () -> GridTemplateRows.repeat(PrimitiveGenerator.int(), UnitGenerator.lengthPercent())
                fun () -> GridTemplateRows.subgrid 
                fun () -> GridTemplateRows.masonry 
                fun () -> GridTemplateRows.none
                fun () -> GridTemplateRows.auto
                fun () -> GridTemplateRows.inherit'
                fun () -> GridTemplateRows.initial
                fun () -> GridTemplateRows.unset
                fun () -> GridTemplateRows.revert
                fun () -> GridTemplateColumns.value (UnitGenerator.lengthPercent())
                fun () -> GridTemplateColumns.minMax ((UnitGenerator.lengthPercent()), (UnitGenerator.fraction())) 
                fun () -> GridTemplateColumns.repeat(PrimitiveGenerator.int(), UnitGenerator.fraction()) 
                fun () -> GridTemplateColumns.repeat(PrimitiveGenerator.int(), UnitGenerator.lengthPercent())
                fun () -> GridTemplateColumns.repeat((PrimitiveGenerator.int()), Fss.Types.ContentSize.MinContent) 
                fun () -> GridTemplateColumns.repeat((PrimitiveGenerator.int()), Fss.Types.ContentSize.MaxContent) 
                fun () -> GridTemplateColumns.repeat((PrimitiveGenerator.int()), [Fss.Types.ContentSize.MinContent; Fss.Types.ContentSize.MaxContent]) 
                fun () -> GridTemplateColumns.repeat(Fss.Types.Grid.AutoFill, UnitGenerator.lengthPercent())
                fun () -> GridTemplateColumns.repeat(Fss.Types.Grid.AutoFit, UnitGenerator.lengthPercent())
                fun () -> GridTemplateColumns.fitContent(UnitGenerator.lengthPercent())
                fun () -> GridTemplateColumns.repeat(PrimitiveGenerator.int(), UnitGenerator.lengthPercent())
                fun () -> GridTemplateColumns.subgrid 
                fun () -> GridTemplateColumns.masonry 
                fun () -> GridTemplateColumns.none
                fun () -> GridTemplateColumns.auto
                fun () -> GridTemplateColumns.inherit'
                fun () -> GridTemplateColumns.initial
                fun () -> GridTemplateColumns.unset
                fun () -> GridTemplateColumns.revert
                fun () -> GridAutoColumns.minContent
                fun () -> GridAutoColumns.maxContent
                fun () -> GridAutoColumns.auto
                fun () -> GridAutoColumns.value (UnitGenerator.lengthPercent())
                fun () -> GridAutoColumns.value (UnitGenerator.fraction())
                fun () -> GridAutoColumns.fitContent (UnitGenerator.lengthPercent())
                fun () -> GridAutoColumns.value (PrimitiveGenerator.listOf(UnitGenerator.Troouba()))
                fun () -> GridAutoColumns.value (PrimitiveGenerator.listOf(UnitGenerator.percent))
                fun () -> GridAutoColumns.value (PrimitiveGenerator.listOf(UnitGenerator.fraction))
                fun () -> GridAutoColumns.inherit'
                fun () -> GridAutoColumns.initial
                fun () -> GridAutoColumns.unset
                fun () -> GridAutoRows.minContent
                fun () -> GridAutoRows.maxContent
                fun () -> GridAutoRows.auto
                fun () -> GridAutoRows.value (UnitGenerator.lengthPercent())
                fun () -> GridAutoRows.value (UnitGenerator.fraction())
                fun () -> GridAutoRows.fitContent(UnitGenerator.lengthPercent())
                fun () -> GridAutoRows.value (PrimitiveGenerator.listOf(UnitGenerator.Troouba()))
                fun () -> GridAutoRows.value (PrimitiveGenerator.listOf(UnitGenerator.percent))
                fun () -> GridAutoRows.value (PrimitiveGenerator.listOf(UnitGenerator.fraction))
                fun () -> GridAutoRows.inherit'
                fun () -> GridAutoRows.initial
                fun () -> GridAutoRows.unset
                fun () -> GridAutoFlow.row
                fun () -> GridAutoFlow.column
                fun () -> GridAutoFlow.dense
                fun () -> GridAutoFlow.rowDense
                fun () -> GridAutoFlow.columnDense
                fun () -> GridAutoFlow.inherit'
                fun () -> GridAutoFlow.initial
                fun () -> GridAutoFlow.unset
                fun () -> GridTemplateAreas.none
                fun () -> GridTemplateAreas.value (PrimitiveGenerator.listOf(PrimitiveGenerator.string)) 
                fun () -> GridTemplateAreas.inherit' 
                fun () -> GridTemplateAreas.initial
                fun () -> GridTemplateAreas.unset
                fun () -> GridTemplateAreas.revert
            |]
            
    module DisplayGenerator =
        let display () =
            [|
                Fss.Types.Display.Inline
                Fss.Types.Display.InlineBlock
                Fss.Types.Display.Block
                Fss.Types.Display.RunIn
                Fss.Types.Display.Flex
                Fss.Types.Display.Grid
                Fss.Types.Display.FlowRoot
                Fss.Types.Display.Table
                Fss.Types.Display.TableCell
                Fss.Types.Display.TableColumn
                Fss.Types.Display.TableColumnGroup
                Fss.Types.Display.TableHeaderGroup
                Fss.Types.Display.TableRowGroup
                Fss.Types.Display.TableFooterGroup
                Fss.Types.Display.TableRow
                Fss.Types.Display.TableCaption
            |] |> pick
        let items =
            [|
                fun () -> Display.inline' 
                fun () -> Display.inlineBlock
                fun () -> Display.block
                fun () -> Display.runIn
                fun () -> Display.flex
                fun () -> Display.grid
                fun () -> Display.flowRoot
                fun () -> Display.table
                fun () -> Display.tableCell
                fun () -> Display.tableColumn
                fun () -> Display.tableColumnGroup
                fun () -> Display.tableHeaderGroup
                fun () -> Display.tableRowGroup
                fun () -> Display.tableFooterGroup
                fun () -> Display.tableRow
                fun () -> Display.tableCaption
                fun () -> Display.value (display())
                fun () -> Display.none
                fun () -> Display.inherit'
                fun () -> Display.initial
                fun () -> Display.unset
                fun () -> Display.revert
            |]
            
    module FlexGenerator =
        let items =
            [|
                fun () -> FlexDirection.row
                fun () -> FlexDirection.rowReverse
                fun () -> FlexDirection.column
                fun () -> FlexDirection.columnReverse
                fun () -> FlexDirection.inherit'
                fun () -> FlexDirection.initial
                fun () -> FlexDirection.unset
                fun () -> FlexDirection.revert
                fun () -> FlexWrap.noWrap
                fun () -> FlexWrap.wrap
                fun () -> FlexWrap.wrapReverse
                fun () -> FlexWrap.inherit'
                fun () -> FlexWrap.initial
                fun () -> FlexWrap.unset
                fun () -> FlexWrap.revert
                fun () -> FlexBasis.value (UnitGenerator.lengthPercent())
                fun () -> FlexBasis.auto
                fun () -> FlexBasis.fill 
                fun () -> FlexBasis.maxContent
                fun () -> FlexBasis.minContent
                fun () -> FlexBasis.fitContent 
                fun () -> FlexBasis.content
                fun () -> FlexBasis.inherit'
                fun () -> FlexBasis.initial
                fun () -> FlexBasis.unset
                fun () -> FlexBasis.revert
                fun () -> JustifyContent.start
                fun () -> JustifyContent.end'
                fun () -> JustifyContent.flexStart
                fun () -> JustifyContent.flexEnd
                fun () -> JustifyContent.center
                fun () -> JustifyContent.left
                fun () -> JustifyContent.right
                fun () -> JustifyContent.normal
                fun () -> JustifyContent.baseline
                fun () -> JustifyContent.spaceBetween
                fun () -> JustifyContent.spaceAround
                fun () -> JustifyContent.spaceEvenly
                fun () -> JustifyContent.right
                fun () -> JustifyContent.safe
                fun () -> JustifyContent.unsafe
                fun () -> JustifyContent.inherit'
                fun () -> JustifyContent.initial
                fun () -> JustifyContent.unset
                fun () -> JustifyContent.revert
                fun () -> JustifySelf.normal 
                fun () -> JustifySelf.selfStart
                fun () -> JustifySelf.selfEnd
                fun () -> JustifySelf.flexStart
                fun () -> JustifySelf.flexEnd
                fun () -> JustifySelf.center
                fun () -> JustifySelf.baseline
                fun () -> JustifySelf.stretch
                fun () -> JustifySelf.safe
                fun () -> JustifySelf.unsafe
                fun () -> JustifySelf.inherit'
                fun () -> JustifySelf.initial
                fun () -> JustifySelf.unset
                fun () -> JustifyItems.start
                fun () -> JustifyItems.end'
                fun () -> JustifyItems.flexStart
                fun () -> JustifyItems.flexEnd
                fun () -> JustifyItems.center
                fun () -> JustifyItems.normal
                fun () -> JustifyItems.baseline
                fun () -> JustifyItems.safe
                fun () -> JustifyItems.unsafe
                fun () -> JustifyItems.inherit'
                fun () -> JustifyItems.initial
                fun () -> JustifyItems.unset
                fun () -> JustifyItems.revert
                fun () -> JustifyItems.legacy
                fun () -> AlignSelf.normal
                fun () -> AlignSelf.selfStart
                fun () -> AlignSelf.selfEnd
                fun () -> AlignSelf.flexStart
                fun () -> AlignSelf.flexEnd
                fun () -> AlignSelf.center
                fun () -> AlignSelf.baseline
                fun () -> AlignSelf.stretch
                fun () -> AlignSelf.safe
                fun () -> AlignSelf.unsafe
                fun () -> AlignSelf.inherit'
                fun () -> AlignSelf.initial
                fun () -> AlignSelf.unset
                fun () -> AlignSelf.revert
                fun () -> AlignItems.start
                fun () -> AlignItems.end'
                fun () -> AlignItems.flexStart
                fun () -> AlignItems.flexEnd
                fun () -> AlignItems.center
                fun () -> AlignItems.normal
                fun () -> AlignItems.baseline
                fun () -> AlignItems.safe
                fun () -> AlignItems.unsafe
                fun () -> AlignItems.inherit'
                fun () -> AlignItems.initial
                fun () -> AlignItems.unset
                fun () -> AlignItems.revert
                fun () -> AlignContent.start
                fun () -> AlignContent.end'
                fun () -> AlignContent.flexStart
                fun () -> AlignContent.flexEnd
                fun () -> AlignContent.center
                fun () -> AlignContent.normal
                fun () -> AlignContent.baseline
                fun () -> AlignContent.spaceBetween
                fun () -> AlignContent.spaceAround
                fun () -> AlignContent.spaceEvenly
                fun () -> AlignContent.safe
                fun () -> AlignContent.unsafe
                fun () -> AlignContent.inherit'
                fun () -> AlignContent.initial
                fun () -> AlignContent.unset
                fun () -> Order.value (PrimitiveGenerator.int()) 
                fun () -> Order.inherit'
                fun () -> Order.initial
                fun () -> Order.unset
                fun () -> Order.revert
                fun () -> FlexGrow.value (PrimitiveGenerator.float()) 
                fun () -> FlexGrow.inherit'
                fun () -> FlexGrow.initial
                fun () -> FlexGrow.unset
                fun () -> FlexShrink.value (PrimitiveGenerator.float()) 
                fun () -> FlexShrink.inherit'
                fun () -> FlexShrink.initial
                fun () -> FlexShrink.unset
            |]
            
    module PerspectiveGenerator =
        let items =
            [|
                fun () -> Perspective.value (UnitGenerator.lengthPercent())
                fun () -> Perspective.none 
                fun () -> Perspective.inherit'
                fun () -> Perspective.initial
                fun () -> Perspective.unset
                fun () -> Perspective.revert
                fun () -> PerspectiveOrigin.value (UnitGenerator.lengthPercent())
                fun () -> PerspectiveOrigin.value (UnitGenerator.lengthPercent(), UnitGenerator.lengthPercent()) 
                fun () -> PerspectiveOrigin.inherit'
                fun () -> PerspectiveOrigin.initial
                fun () -> PerspectiveOrigin.unset
                fun () -> PerspectiveOrigin.revert
                fun () -> BackfaceVisibility.hidden
                fun () -> BackfaceVisibility.visible
                fun () -> BackfaceVisibility.inherit'
                fun () -> BackfaceVisibility.initial
                fun () -> BackfaceVisibility.unset
                fun () -> BackfaceVisibility.revert
            |]
            
    module TextGenerator =
        let emphasisPosition () =
            [|
                Fss.Types.Text.EmphasisPosition.Over
                Fss.Types.Text.EmphasisPosition.Under
                Fss.Types.Text.EmphasisPosition.Right
                Fss.Types.Text.EmphasisPosition.Left
            |] |> pick
            
        let underlinePosition () =
            [|
                Fss.Types.Text.UnderlinePosition.FromFont
                Fss.Types.Text.UnderlinePosition.Under
                Fss.Types.Text.UnderlinePosition.Left
                Fss.Types.Text.UnderlinePosition.Right
                Fss.Types.Text.UnderlinePosition.AutoPos
                Fss.Types.Text.UnderlinePosition.Above
                Fss.Types.Text.UnderlinePosition.Below
            |] |> pick
            
        let hangingPunctuation () =
            [|
                Fss.Types.Text.HangingPunctuation.First
                Fss.Types.Text.HangingPunctuation.Last
                Fss.Types.Text.HangingPunctuation.ForceEnd
                Fss.Types.Text.HangingPunctuation.AllowEnd
            |] |> pick
        
        let items =
            [|
                fun () -> TextTransform.none
                fun () -> TextTransform.capitalize
                fun () -> TextTransform.uppercase
                fun () -> TextTransform.lowercase
                fun () -> TextTransform.fullWidth
                fun () -> TextTransform.fullSizeKana
                fun () -> TextDecoration.none
                fun () -> TextDecoration.inherit'
                fun () -> TextDecoration.initial
                fun () -> TextDecoration.unset
                fun () -> TextDecoration.revert
                fun () -> TextEmphasis.none
                fun () -> TextEmphasis.inherit' 
                fun () -> TextEmphasis.initial 
                fun () -> TextEmphasis.unset 
                fun () -> TextEmphasis.revert 
                fun () -> TextAlign.left 
                fun () -> TextAlign.right 
                fun () -> TextAlign.center 
                fun () -> TextAlign.justify 
                fun () -> TextAlign.justifyAll 
                fun () -> TextAlign.start 
                fun () -> TextAlign.end' 
                fun () -> TextAlign.matchParent 
                fun () -> TextAlign.inherit' 
                fun () -> TextAlign.initial 
                fun () -> TextAlign.unset 
                fun () -> TextAlign.revert 
                fun () -> TextAlignLast.left 
                fun () -> TextAlignLast.right 
                fun () -> TextAlignLast.center 
                fun () -> TextAlignLast.justify 
                fun () -> TextAlignLast.start 
                fun () -> TextAlignLast.end' 
                fun () -> TextAlignLast.inherit' 
                fun () -> TextAlignLast.initial 
                fun () -> TextAlignLast.unset 
                fun () -> TextAlignLast.revert 
                fun () -> TextDecorationColor.red
                fun () -> TextDecorationColor.hex (PrimitiveGenerator.string())
                fun () -> TextDecorationColor.rgba (PrimitiveGenerator.int()) (PrimitiveGenerator.int()) (PrimitiveGenerator.int()) (PrimitiveGenerator.float()) 
                fun () -> TextDecorationColor.transparent
                fun () -> TextDecorationColor.inherit'
                fun () -> TextDecorationColor.initial
                fun () -> TextDecorationColor.unset
                fun () -> TextDecorationColor.revert
                fun () -> TextDecorationLine.none
                fun () -> TextDecorationLine.underline
                fun () -> TextDecorationLine.overline
                fun () -> TextDecorationLine.lineThrough
                fun () -> TextDecorationLine.blink
                fun () -> TextDecorationLine.inherit' 
                fun () -> TextDecorationLine.initial 
                fun () -> TextDecorationLine.unset 
                fun () -> TextDecorationSkip.none
                fun () -> TextDecorationSkip.objects
                fun () -> TextDecorationSkip.spaces
                fun () -> TextDecorationSkip.edges
                fun () -> TextDecorationSkip.boxDecoration
                fun () -> TextDecorationSkip.inherit'
                fun () -> TextDecorationSkip.initial
                fun () -> TextDecorationSkip.unset
                fun () -> TextDecorationSkip.revert
                fun () -> TextDecorationSkipInk.auto
                fun () -> TextDecorationSkipInk.all
                fun () -> TextDecorationSkipInk.none
                fun () -> TextDecorationSkipInk.inherit'
                fun () -> TextDecorationSkipInk.unset
                fun () -> TextDecorationSkipInk.initial
                fun () -> TextDecorationSkipInk.revert
                fun () -> TextDecorationStyle.solid
                fun () -> TextDecorationStyle.double
                fun () -> TextDecorationStyle.dotted
                fun () -> TextDecorationStyle.dashed
                fun () -> TextDecorationStyle.wavy
                fun () -> TextDecorationStyle.inherit'
                fun () -> TextDecorationStyle.initial
                fun () -> TextDecorationStyle.unset
                fun () -> TextDecorationStyle.revert
                fun () -> TextDecorationThickness.auto 
                fun () -> TextDecorationThickness.fromFont 
                fun () -> TextDecorationThickness.value (UnitGenerator.lengthPercent())
                fun () -> TextDecorationThickness.inherit' 
                fun () -> TextDecorationThickness.initial 
                fun () -> TextDecorationThickness.unset 
                fun () -> TextDecorationThickness.revert 
                fun () -> TextEmphasisColor.hex (PrimitiveGenerator.string())
                fun () -> TextEmphasisColor.blue 
                fun () -> TextEmphasisColor.rgba (PrimitiveGenerator.int()) (PrimitiveGenerator.int()) (PrimitiveGenerator.int()) (PrimitiveGenerator.float()) 
                fun () -> TextEmphasisColor.transparent 
                fun () -> TextEmphasisColor.inherit' 
                fun () -> TextEmphasisColor.initial 
                fun () -> TextEmphasisColor.unset 
                fun () -> TextEmphasisColor.revert 
                fun () -> TextEmphasisPosition.value (emphasisPosition(), emphasisPosition()) 
                fun () -> TextEmphasisPosition.inherit' 
                fun () -> TextEmphasisPosition.initial 
                fun () -> TextEmphasisPosition.unset 
                fun () -> TextEmphasisPosition.revert 
                fun () -> TextEmphasisStyle.value (PrimitiveGenerator.string())
                fun () -> TextEmphasisStyle.filled 
                fun () -> TextEmphasisStyle.open'
                fun () -> TextEmphasisStyle.circle
                fun () -> TextEmphasisStyle.doubleCircle
                fun () -> TextEmphasisStyle.triangle
                fun () -> TextEmphasisStyle.filledSesame
                fun () -> TextEmphasisStyle.openSesame
                fun () -> TextEmphasisStyle.inherit' 
                fun () -> TextEmphasisStyle.initial 
                fun () -> TextEmphasisStyle.unset 
                fun () -> TextEmphasisStyle.revert 
                fun () -> TextShadow.value (UnitGenerator.Troouba()(), UnitGenerator.Troouba()(), UnitGenerator.Troouba()(), BaseColorGenerator.color()())
                fun () -> TextShadow.value (PrimitiveGenerator.listOf(fun () -> UnitGenerator.Troouba()(), UnitGenerator.Troouba()(), UnitGenerator.Troouba()(), BaseColorGenerator.color()()))
                fun () -> TextShadow.inherit' 
                fun () -> TextShadow.initial 
                fun () -> TextShadow.unset 
                fun () -> TextShadow.revert 
                fun () -> TextUnderlineOffset.value (UnitGenerator.lengthPercent())
                fun () -> TextUnderlineOffset.auto 
                fun () -> TextUnderlineOffset.inherit' 
                fun () -> TextUnderlineOffset.initial 
                fun () -> TextUnderlineOffset.unset 
                fun () -> TextUnderlineOffset.revert 
                fun () -> TextUnderlinePosition.fromFont 
                fun () -> TextUnderlinePosition.under 
                fun () -> TextUnderlinePosition.left 
                fun () -> TextUnderlinePosition.right 
                fun () -> TextUnderlinePosition.autoPos 
                fun () -> TextUnderlinePosition.above 
                fun () -> TextUnderlinePosition.below 
                fun () -> TextUnderlinePosition.value (underlinePosition(), underlinePosition()) 
                fun () -> TextUnderlinePosition.auto 
                fun () -> TextUnderlinePosition.inherit' 
                fun () -> TextUnderlinePosition.initial 
                fun () -> TextUnderlinePosition.unset 
                fun () -> TextUnderlinePosition.revert 
                fun () -> TextIndent.value (UnitGenerator.lengthPercent())
                fun () -> TextIndent.hanging (UnitGenerator.lengthPercent())
                fun () -> TextIndent.eachLine (UnitGenerator.lengthPercent())
                fun () -> TextIndent.hangingEachLine (UnitGenerator.lengthPercent())
                fun () -> TextIndent.inherit' 
                fun () -> TextIndent.initial 
                fun () -> TextIndent.unset 
                fun () -> TextIndent.unset 
                fun () -> TextOverflow.clip 
                fun () -> TextOverflow.ellipsis 
                fun () -> TextOverflow.value (PrimitiveGenerator.string())
                fun () -> TextOverflow.inherit' 
                fun () -> TextOverflow.initial 
                fun () -> TextOverflow.unset 
                fun () -> TextOverflow.revert 
                fun () -> Quotes.none 
                fun () -> Quotes.auto 
                fun () -> Quotes.value (PrimitiveGenerator.listOf(PrimitiveGenerator.string))
                fun () -> Quotes.inherit' 
                fun () -> Quotes.initial 
                fun () -> Quotes.unset 
                fun () -> Hyphens.manual 
                fun () -> Hyphens.none 
                fun () -> Hyphens.auto 
                fun () -> Hyphens.inherit' 
                fun () -> Hyphens.initial 
                fun () -> Hyphens.unset 
                fun () -> Hyphens.revert 
                fun () -> TextSizeAdjust.value (UnitGenerator.lengthPercent())
                fun () -> TextSizeAdjust.none 
                fun () -> TextSizeAdjust.auto 
                fun () -> TextSizeAdjust.inherit' 
                fun () -> TextSizeAdjust.initial 
                fun () -> TextSizeAdjust.unset 
                fun () -> TextSizeAdjust.revert 
                fun () -> TabSize.value (UnitGenerator.lengthPercent())
                fun () -> TabSize.value (PrimitiveGenerator.int())
                fun () -> TabSize.inherit' 
                fun () -> TabSize.initial 
                fun () -> TabSize.unset 
                fun () -> TabSize.revert 
                fun () -> TextOrientation.mixed 
                fun () -> TextOrientation.upright 
                fun () -> TextOrientation.sidewaysRight 
                fun () -> TextOrientation.sideways 
                fun () -> TextOrientation.useGlyphOrientation 
                fun () -> TextOrientation.inherit' 
                fun () -> TextOrientation.initial 
                fun () -> TextOrientation.unset 
                fun () -> TextOrientation.revert 
                fun () -> TextRendering.optimizeSpeed 
                fun () -> TextRendering.optimizeLegibility 
                fun () -> TextRendering.geometricPrecision 
                fun () -> TextRendering.auto 
                fun () -> TextRendering.inherit' 
                fun () -> TextRendering.initial 
                fun () -> TextRendering.unset 
                fun () -> TextRendering.revert 
                fun () -> TextJustify.interCharacter 
                fun () -> TextJustify.interWord 
                fun () -> TextJustify.auto 
                fun () -> TextJustify.none 
                fun () -> TextJustify.inherit' 
                fun () -> TextJustify.initial 
                fun () -> TextJustify.unset 
                fun () -> TextJustify.revert 
                fun () -> WhiteSpace.nowrap 
                fun () -> WhiteSpace.pre 
                fun () -> WhiteSpace.preWrap 
                fun () -> WhiteSpace.preLine 
                fun () -> WhiteSpace.breakSpaces 
                fun () -> WhiteSpace.normal 
                fun () -> WhiteSpace.inherit' 
                fun () -> WhiteSpace.initial 
                fun () -> WhiteSpace.unset 
                fun () -> UserSelect.text 
                fun () -> UserSelect.contain 
                fun () -> UserSelect.all 
                fun () -> UserSelect.element 
                fun () -> UserSelect.none 
                fun () -> UserSelect.auto 
                fun () -> UserSelect.inherit' 
                fun () -> UserSelect.initial 
                fun () -> UserSelect.unset 
                fun () -> UserSelect.revert 
                fun () -> HangingPunctuation.first 
                fun () -> HangingPunctuation.last 
                fun () -> HangingPunctuation.forceEnd 
                fun () -> HangingPunctuation.allowEnd 
                fun () -> HangingPunctuation.value (PrimitiveGenerator.listOf(hangingPunctuation))
                fun () -> HangingPunctuation.none 
                fun () -> HangingPunctuation.inherit' 
                fun () -> HangingPunctuation.initial 
                fun () -> HangingPunctuation.unset 
            |]
    
    module PositionGenerator =
        let items =
            [|
                fun () -> Direction.ltr 
                fun () -> Direction.rtl 
                fun () -> Direction.inherit'
                fun () -> Direction.initial
                fun () -> Direction.unset
                fun () -> Direction.revert
                fun () -> BoxSizing.borderBox
                fun () -> BoxSizing.contentBox
                fun () -> BoxSizing.inherit'
                fun () -> BoxSizing.initial
                fun () -> BoxSizing.unset
                fun () -> BoxSizing.revert
                fun () -> Left.value (UnitGenerator.lengthPercent()) 
                fun () -> Left.auto
                fun () -> Left.inherit'
                fun () -> Left.initial
                fun () -> Left.unset
                fun () -> Left.revert
                fun () -> Right.value (UnitGenerator.lengthPercent()) 
                fun () -> Right.auto
                fun () -> Right.inherit'
                fun () -> Right.initial
                fun () -> Right.unset
                fun () -> Right.revert
                fun () -> Bottom.value (UnitGenerator.lengthPercent()) 
                fun () -> Bottom.auto
                fun () -> Bottom.inherit'
                fun () -> Bottom.initial
                fun () -> Bottom.unset
                fun () -> Bottom.revert
                fun () -> Top.value (UnitGenerator.lengthPercent()) 
                fun () -> Top.auto
                fun () -> Top.inherit'
                fun () -> Top.initial
                fun () -> Top.unset
                fun () -> Top.revert
                fun () -> VerticalAlign.baseline
                fun () -> VerticalAlign.sub
                fun () -> VerticalAlign.super
                fun () -> VerticalAlign.textTop
                fun () -> VerticalAlign.textBottom
                fun () -> VerticalAlign.middle
                fun () -> VerticalAlign.top
                fun () -> VerticalAlign.bottom
                fun () -> VerticalAlign.value (UnitGenerator.lengthPercent())
                fun () -> VerticalAlign.inherit' 
                fun () -> VerticalAlign.initial 
                fun () -> VerticalAlign.unset 
                fun () -> Position.static'
                fun () -> Position.relative
                fun () -> Position.absolute
                fun () -> Position.sticky
                fun () -> Position.fixed'
                fun () -> Float.left
                fun () -> Float.right
                fun () -> Float.inlineStart
                fun () -> Float.inlineEnd
                fun () -> Float.none
                fun () -> Float.inherit'
                fun () -> Float.initial
                fun () -> Float.unset
                fun () -> WritingMode.horizontalTb
                fun () -> WritingMode.verticalRl
                fun () -> WritingMode.verticalLr
                fun () -> WritingMode.inherit'
                fun () -> WritingMode.initial
                fun () -> WritingMode.unset
                fun () -> WritingMode.revert
                fun () -> BreakAfter.avoid
                fun () -> BreakAfter.always
                fun () -> BreakAfter.all
                fun () -> BreakAfter.avoidPage
                fun () -> BreakAfter.page
                fun () -> BreakAfter.left
                fun () -> BreakAfter.right
                fun () -> BreakAfter.recto
                fun () -> BreakAfter.verso
                fun () -> BreakAfter.avoidColumn
                fun () -> BreakAfter.column
                fun () -> BreakAfter.avoidRegion
                fun () -> BreakAfter.region
                fun () -> BreakAfter.auto
                fun () -> BreakAfter.inherit'
                fun () -> BreakAfter.initial
                fun () -> BreakAfter.unset
                fun () -> BreakAfter.revert
                fun () -> BreakBefore.avoid
                fun () -> BreakBefore.always
                fun () -> BreakBefore.all
                fun () -> BreakBefore.avoidPage
                fun () -> BreakBefore.page
                fun () -> BreakBefore.left
                fun () -> BreakBefore.right
                fun () -> BreakBefore.recto
                fun () -> BreakBefore.verso
                fun () -> BreakBefore.avoidColumn
                fun () -> BreakBefore.column
                fun () -> BreakBefore.avoidRegion
                fun () -> BreakBefore.region
                fun () -> BreakBefore.auto
                fun () -> BreakBefore.inherit'
                fun () -> BreakBefore.initial
                fun () -> BreakBefore.unset
                fun () -> BreakBefore.revert
                fun () -> BreakInside.avoid
                fun () -> BreakInside.avoidPage
                fun () -> BreakInside.avoidColumn
                fun () -> BreakInside.avoidRegion
                fun () -> BreakInside.auto
                fun () -> BreakInside.inherit'
                fun () -> BreakInside.initial
                fun () -> BreakInside.unset
                fun () -> BreakInside.revert
            |]
    
    module ResizeGenerator =
        let items =
            [|
                fun () -> Resize.both
                fun () -> Resize.horizontal
                fun () -> Resize.vertical
                fun () -> Resize.inline'
                fun () -> Resize.block
                fun () -> Resize.none
                fun () -> Resize.initial
                fun () -> Resize.inherit'
                fun () -> Resize.unset
            |]
            
    module TransitionGenerator =
        let step () =
            [|
                Fss.Types.TimingFunction.JumpStart
                Fss.Types.TimingFunction.JumpEnd
                Fss.Types.TimingFunction.JumpNone
                Fss.Types.TimingFunction.JumpBoth
                Fss.Types.TimingFunction.Start
                Fss.Types.TimingFunction.End
            |] |> pick
        let items =
            [|
                fun () -> Transition.inherit'
                fun () -> Transition.initial 
                fun () -> Transition.unset
                fun () -> Transition.revert
                fun () -> TransitionDuration.value (UnitGenerator.time()()) 
                fun () -> TransitionDuration.inherit'
                fun () -> TransitionDuration.initial 
                fun () -> TransitionDuration.unset
                fun () -> TransitionDuration.revert
                fun () -> TransitionDelay.value (UnitGenerator.time()()) 
                fun () -> TransitionDelay.inherit'
                fun () -> TransitionDelay.initial 
                fun () -> TransitionDelay.unset
                fun () -> TransitionDelay.revert
                fun () -> TransitionProperty.backgroundColor
                fun () -> TransitionProperty.all
                fun () -> TransitionProperty.inherit'
                fun () -> TransitionProperty.initial 
                fun () -> TransitionProperty.unset
                fun () -> TransitionProperty.revert
                fun () -> TransitionTimingFunction.ease 
                fun () -> TransitionTimingFunction.easeIn 
                fun () -> TransitionTimingFunction.easeOut 
                fun () -> TransitionTimingFunction.easeInOut 
                fun () -> TransitionTimingFunction.linear 
                fun () -> TransitionTimingFunction.stepStart 
                fun () -> TransitionTimingFunction.stepEnd 
                fun () -> TransitionTimingFunction.cubicBezier(PrimitiveGenerator.float(), PrimitiveGenerator.float(), PrimitiveGenerator.float(), PrimitiveGenerator.float())
                fun () -> TransitionTimingFunction.step (PrimitiveGenerator.int()) 
                fun () -> TransitionTimingFunction.step(PrimitiveGenerator.int(), step ())
                fun () -> TransitionTimingFunction.inherit' 
                fun () -> TransitionTimingFunction.initial 
                fun () -> TransitionTimingFunction.unset 
                fun () -> TransitionTimingFunction.revert 
            |]
            
    module VisibilityGenerator =
        let items =
            [|
                fun () -> PaintOrder.normal
                fun () -> PaintOrder.stroke
                fun () -> PaintOrder.markers
                fun () -> PaintOrder.fill
                fun () -> PaintOrder.normal
                fun () -> PaintOrder.inherit'
                fun () -> PaintOrder.initial
                fun () -> PaintOrder.unset
                fun () -> PaintOrder.revert
                fun () -> Visibility.hidden
                fun () -> Visibility.collapse
                fun () -> Visibility.visible
                fun () -> Visibility.inherit'
                fun () -> Visibility.initial
                fun () -> Visibility.unset
                fun () -> Visibility.revert
                fun () -> Opacity.value (PrimitiveGenerator.float())
                fun () -> Opacity.value (UnitGenerator.percent()) 
                fun () -> Opacity.inherit'
                fun () -> Opacity.initial
                fun () -> Opacity.unset
                fun () -> Opacity.revert
                fun () -> ZIndex.value (PrimitiveGenerator.int())
                fun () -> ZIndex.auto
                fun () -> ZIndex.auto
                fun () -> ZIndex.inherit'
                fun () -> ZIndex.initial
                fun () -> ZIndex.unset
                fun () -> ZIndex.revert
            |]
        
    module ListStyleGenerator =
        let items =
            [|
                fun () -> ListStyle.none
                fun () -> ListStyle.initial
                fun () -> ListStyle.inherit'
                fun () -> ListStyle.unset
                fun () -> ListStyle.revert
                fun () -> ListStyleImage.url $"{PrimitiveGenerator.string}.jpg"
                fun () -> ListStyleImage.none
                fun () -> ListStyleImage.initial
                fun () -> ListStyleImage.inherit'
                fun () -> ListStyleImage.unset
                fun () -> ListStyleImage.revert
                fun () -> ListStylePosition.inside
                fun () -> ListStylePosition.outside
                fun () -> ListStylePosition.initial
                fun () -> ListStylePosition.inherit'
                fun () -> ListStylePosition.unset
                fun () -> ListStylePosition.revert
                fun () -> ListStyleType.disc
                fun () -> ListStyleType.circle
                fun () -> ListStyleType.square
                fun () -> ListStyleType.decimal
                fun () -> ListStyleType.georgian
                fun () -> ListStyleType.tradChineseInformal
                fun () -> ListStyleType.kannada
                fun () -> ListStyleType.string (PrimitiveGenerator.string())
                fun () -> ListStyleType.value (PrimitiveGenerator.string())
                fun () -> ListStyleType.none
                fun () -> ListStyleType.initial
                fun () -> ListStyleType.inherit'
                fun () -> ListStyleType.unset
                fun () -> ListStyleType.revert
            |]
            
    module ContentGenerator =
        let attributes () =
            [|
                Fss.Types.Attribute.Property
                Fss.Types.Attribute.Attribute
                Fss.Types.Attribute.Map
                Fss.Types.Attribute.Style
                Fss.Types.Attribute.Class
                Fss.Types.Attribute.ClassList
                Fss.Types.Attribute.Id
                Fss.Types.Attribute.Title
                Fss.Types.Attribute.Hidden
                Fss.Types.Attribute.Type
                Fss.Types.Attribute.Value
                Fss.Types.Attribute.Checked
                Fss.Types.Attribute.Placeholder
                Fss.Types.Attribute.Selected
                Fss.Types.Attribute.Accept
                Fss.Types.Attribute.AcceptCharset
                Fss.Types.Attribute.Action
                Fss.Types.Attribute.Autocomplete
                Fss.Types.Attribute.Autofocus
                Fss.Types.Attribute.Disabled
                Fss.Types.Attribute.Enctype
                Fss.Types.Attribute.List
                Fss.Types.Attribute.Maxlength
                Fss.Types.Attribute.Minlength
                Fss.Types.Attribute.Method
                Fss.Types.Attribute.Multiple
                Fss.Types.Attribute.Name
                Fss.Types.Attribute.Novalidate
                Fss.Types.Attribute.Pattern
                Fss.Types.Attribute.Readonly
                Fss.Types.Attribute.Required
                Fss.Types.Attribute.Size
                Fss.Types.Attribute.For
                Fss.Types.Attribute.Form
                Fss.Types.Attribute.Max
                Fss.Types.Attribute.Min
                Fss.Types.Attribute.Step
                Fss.Types.Attribute.Cols
                Fss.Types.Attribute.Rows
                Fss.Types.Attribute.Wrap
                Fss.Types.Attribute.Href
                Fss.Types.Attribute.Target
                Fss.Types.Attribute.Download
                Fss.Types.Attribute.Hreflang
                Fss.Types.Attribute.Media
                Fss.Types.Attribute.Ping
                Fss.Types.Attribute.Rel
                Fss.Types.Attribute.Ismap
                Fss.Types.Attribute.Usemap
                Fss.Types.Attribute.Shape
                Fss.Types.Attribute.Coords
                Fss.Types.Attribute.Src
                Fss.Types.Attribute.Height
                Fss.Types.Attribute.Width
                Fss.Types.Attribute.Alt
                Fss.Types.Attribute.Autoplay
                Fss.Types.Attribute.Controls
                Fss.Types.Attribute.Loop
                Fss.Types.Attribute.Preload
                Fss.Types.Attribute.Poster
                Fss.Types.Attribute.Default
                Fss.Types.Attribute.Kind
                Fss.Types.Attribute.Srclang
                Fss.Types.Attribute.Sandbox
                Fss.Types.Attribute.Srcdoc
                Fss.Types.Attribute.Reversed
                Fss.Types.Attribute.Start
                Fss.Types.Attribute.Align
                Fss.Types.Attribute.Colspan
                Fss.Types.Attribute.Rowspan
                Fss.Types.Attribute.Headers
                Fss.Types.Attribute.Scope
                Fss.Types.Attribute.Accesskey
                Fss.Types.Attribute.Contenteditable
                Fss.Types.Attribute.Contextmenu
                Fss.Types.Attribute.Dir
                Fss.Types.Attribute.Draggable
                Fss.Types.Attribute.Dropzone
                Fss.Types.Attribute.Itemprop
                Fss.Types.Attribute.Lang
                Fss.Types.Attribute.Spellcheck
                Fss.Types.Attribute.Tabindex
                Fss.Types.Attribute.Cite
                Fss.Types.Attribute.Datetime
                Fss.Types.Attribute.Pubdate
                Fss.Types.Attribute.Manifest
            |] |> pick
        let items =
            [|
                fun () -> Content.normal 
                fun () -> Content.none 
                fun () -> Content.url (PrimitiveGenerator.string())
                fun () -> Content.url(PrimitiveGenerator.string(), PrimitiveGenerator.string()) 
                fun () -> Content.linearGradient((UnitGenerator.angle()(), (PrimitiveGenerator.listOf(fun () -> BaseColorGenerator.color()(), UnitGenerator.lengthPercent()))))
                fun () -> Content.value (PrimitiveGenerator.string())
                fun () -> Content.attribute (attributes())
                fun () -> Content.openQuote 
                fun () -> Content.closeQuote 
                fun () -> Content.noOpenQuote 
                fun () -> Content.noCloseQuote 
                fun () -> Content.inherit' 
                fun () -> Content.initial 
                fun () -> Content.unset 
                fun () -> Content.revert 
            |]
            
    module ColumnGenerator =
        let items =
            [|
                fun () -> ColumnWidth.value (UnitGenerator.lengthPercent())
                fun () -> ColumnWidth.auto
                fun () -> ColumnWidth.inherit'
                fun () -> ColumnWidth.initial
                fun () -> ColumnWidth.unset
                fun () -> ColumnWidth.revert
                fun () -> ColumnFill.balance
                fun () -> ColumnFill.balanceAll
                fun () -> ColumnFill.auto
                fun () -> ColumnFill.inherit'
                fun () -> ColumnFill.initial
                fun () -> ColumnFill.unset
                fun () -> ColumnFill.revert
                fun () -> ColumnGap.normal
                fun () -> ColumnGap.value (UnitGenerator.lengthPercent())
                fun () -> ColumnGap.inherit'
                fun () -> ColumnGap.initial
                fun () -> ColumnGap.unset
                fun () -> ColumnGap.revert
                fun () -> ColumnSpan.all
                fun () -> ColumnSpan.none
                fun () -> ColumnSpan.inherit'
                fun () -> ColumnSpan.initial
                fun () -> ColumnSpan.unset
                fun () -> Columns.inherit'
                fun () -> Columns.initial
                fun () -> Columns.unset
                fun () -> Columns.revert
                fun () -> ColumnRule.inherit'
                fun () -> ColumnRule.initial
                fun () -> ColumnRule.unset
                fun () -> ColumnRule.revert
                fun () -> ColumnRuleWidth.thin
                fun () -> ColumnRuleWidth.medium
                fun () -> ColumnRuleWidth.thick
                fun () -> ColumnRuleWidth.value (UnitGenerator.lengthPercent())
                fun () -> ColumnRuleWidth.inherit'
                fun () -> ColumnRuleWidth.initial
                fun () -> ColumnRuleWidth.unset
                fun () -> ColumnRuleWidth.revert
                fun () -> ColumnRuleStyle.hidden 
                fun () -> ColumnRuleStyle.dotted 
                fun () -> ColumnRuleStyle.dashed 
                fun () -> ColumnRuleStyle.solid 
                fun () -> ColumnRuleStyle.double 
                fun () -> ColumnRuleStyle.groove 
                fun () -> ColumnRuleStyle.ridge 
                fun () -> ColumnRuleStyle.inset 
                fun () -> ColumnRuleStyle.outset 
                fun () -> ColumnRuleStyle.none 
                fun () -> ColumnRuleStyle.revert 
                fun () -> ColumnRuleStyle.initial 
                fun () -> ColumnRuleStyle.inherit' 
                fun () -> ColumnRuleStyle.unset 
                fun () -> ColumnRuleColor.red 
                fun () -> ColumnRuleColor.initial 
                fun () -> ColumnRuleColor.inherit' 
                fun () -> ColumnRuleColor.unset 
                fun () -> ColumnRuleColor.revert 
                fun () -> ColumnCount.value (PrimitiveGenerator.int())
                fun () -> ColumnCount.auto
                fun () -> ColumnCount.inherit'
                fun () -> ColumnCount.initial
                fun () -> ColumnCount.unset
                fun () -> ColumnCount.revert
            |]
            
    module OutlineGenerator =
        let items =
            [|
                fun () -> OutlineOffset.value (UnitGenerator.lengthPercent())
                fun () -> OutlineOffset.initial 
                fun () -> OutlineOffset.inherit' 
                fun () -> OutlineOffset.unset 
                fun () -> OutlineOffset.revert 
                fun () -> Outline.initial 
                fun () -> Outline.inherit' 
                fun () -> Outline.unset 
                fun () -> Outline.revert 
                fun () -> OutlineWidth.value (UnitGenerator.lengthPercent())
                fun () -> OutlineWidth.thin 
                fun () -> OutlineWidth.medium 
                fun () -> OutlineWidth.thick 
                fun () -> OutlineWidth.initial 
                fun () -> OutlineWidth.inherit' 
                fun () -> OutlineWidth.unset 
                fun () -> OutlineWidth.revert 
                fun () -> OutlineStyle.hidden 
                fun () -> OutlineStyle.dotted 
                fun () -> OutlineStyle.dashed 
                fun () -> OutlineStyle.solid 
                fun () -> OutlineStyle.double 
                fun () -> OutlineStyle.groove 
                fun () -> OutlineStyle.ridge 
                fun () -> OutlineStyle.inset 
                fun () -> OutlineStyle.outset 
                fun () -> OutlineStyle.none 
                fun () -> OutlineStyle.initial 
                fun () -> OutlineStyle.inherit' 
                fun () -> OutlineStyle.unset 
                fun () -> OutlineStyle.revert 
                fun () -> OutlineColor.hex (PrimitiveGenerator.string())
                fun () -> OutlineColor.rgb (PrimitiveGenerator.int()) (PrimitiveGenerator.int()) (PrimitiveGenerator.int())
                fun () -> OutlineColor.blue
                fun () -> OutlineColor.inherit'
                fun () -> OutlineColor.initial
                fun () -> OutlineColor.unset 
                fun () -> OutlineColor.revert 
                fun () -> OutlineColor.value (BaseColorGenerator.color()())
            |]
            
    module PointerEventGenerator =
        let items = 
            [|
                fun () -> PointerEvents.visiblePainted
                fun () -> PointerEvents.visibleFill
                fun () -> PointerEvents.visibleStroke
                fun () -> PointerEvents.visible
                fun () -> PointerEvents.painted
                fun () -> PointerEvents.stroke
                fun () -> PointerEvents.all
                fun () -> PointerEvents.none
                fun () -> PointerEvents.auto
                fun () -> PointerEvents.inherit'
                fun () -> PointerEvents.initial
                fun () -> PointerEvents.unset
            |]
            
    module ClipPathGenerator =
        let items =
            [|
                fun () -> ClipPath.marginBox
                fun () -> ClipPath.borderBox
                fun () -> ClipPath.paddingBox
                fun () -> ClipPath.contentBox
                fun () -> ClipPath.fillBox
                fun () -> ClipPath.strokeBox
                fun () -> ClipPath.viewBox
                fun () -> ClipPath.url (PrimitiveGenerator.string())
                fun () -> ClipPath.path (PrimitiveGenerator.string())
                fun () -> ClipPath.inset (UnitGenerator.lengthPercent())
                fun () -> ClipPath.inset(UnitGenerator.lengthPercent(), UnitGenerator.lengthPercent())
                fun () -> ClipPath.inset(UnitGenerator.lengthPercent(), UnitGenerator.lengthPercent(), UnitGenerator.lengthPercent())
                fun () -> ClipPath.inset(UnitGenerator.lengthPercent(), UnitGenerator.lengthPercent(), UnitGenerator.lengthPercent(), UnitGenerator.lengthPercent())
                fun () -> ClipPath.inset(UnitGenerator.lengthPercent(), PrimitiveGenerator.listOf(UnitGenerator.lengthPercent))
                fun () -> ClipPath.inset(UnitGenerator.lengthPercent(), UnitGenerator.lengthPercent(), PrimitiveGenerator.listOf(UnitGenerator.lengthPercent))
                fun () -> ClipPath.inset(UnitGenerator.lengthPercent(), UnitGenerator.lengthPercent(), UnitGenerator.lengthPercent(), PrimitiveGenerator.listOf(UnitGenerator.lengthPercent))
                fun () -> ClipPath.inset(UnitGenerator.lengthPercent(), UnitGenerator.lengthPercent(), UnitGenerator.lengthPercent(), UnitGenerator.lengthPercent(), PrimitiveGenerator.listOf(UnitGenerator.lengthPercent))
                fun () -> ClipPath.circle(UnitGenerator.lengthPercent())
                fun () -> ClipPath.circleAt(UnitGenerator.lengthPercent(), UnitGenerator.lengthPercent(), UnitGenerator.lengthPercent())
                fun () -> ClipPath.circleAt(UnitGenerator.lengthPercent(), UnitGenerator.lengthPercent(), UnitGenerator.lengthPercent())
                fun () -> ClipPath.ellipse(UnitGenerator.lengthPercent())
                fun () -> ClipPath.ellipseAt(UnitGenerator.lengthPercent(), UnitGenerator.lengthPercent(), UnitGenerator.lengthPercent())
                fun () -> ClipPath.ellipseAt(UnitGenerator.lengthPercent(), UnitGenerator.lengthPercent(), UnitGenerator.lengthPercent())
                fun () -> ClipPath.polygon (PrimitiveGenerator.listOf (fun () -> UnitGenerator.percent(), UnitGenerator.percent()))
                fun () -> ClipPath.none
                fun () -> ClipPath.inherit'
                fun () -> ClipPath.initial
                fun () -> ClipPath.unset 
                fun () -> ClipPath.revert 
            |]
            
    module AspectRatioGenerator =
        let items =
            [|
                fun () -> AspectRatio.value(PrimitiveGenerator.int()) 
                fun () -> AspectRatio.value(PrimitiveGenerator.int(), PrimitiveGenerator.int()) 
                fun () -> AspectRatio.inherit'
                fun () -> AspectRatio.initial
                fun () -> AspectRatio.unset 
                fun () -> AspectRatio.revert 
            |]
    
    module ClearGenerator =
        let items =
            [|
                fun () -> Clear.none
                fun () -> Clear.inherit'
                fun () -> Clear.initial
                fun () -> Clear.unset 
                fun () -> Clear.revert 
                fun () -> Clear.left 
                fun () -> Clear.right 
                fun () -> Clear.both 
                fun () -> Clear.inlineStart 
                fun () -> Clear.inlineEnd 
            |]
            
    module AppearanceGenerator =
        let items =
            [|
                fun () -> Appearance.pushButton
                fun () -> Appearance.squareButton
                fun () -> Appearance.button
                fun () -> Appearance.buttonBevel
                fun () -> Appearance.listbox
                fun () -> Appearance.listitem
                fun () -> Appearance.menulist
                fun () -> Appearance.menulistButton
                fun () -> Appearance.menulistText
                fun () -> Appearance.menulistTextfield
                fun () -> Appearance.menupopup
                fun () -> Appearance.scrollbarbuttonUp
                fun () -> Appearance.scrollbarbuttonDown
                fun () -> Appearance.scrollbarbuttonLeft
                fun () -> Appearance.scrollbarbuttonRight
                fun () -> Appearance.scrollbartrackHorizontal
                fun () -> Appearance.scrollbartrackVertical
                fun () -> Appearance.scrollbarthumbHorizontal
                fun () -> Appearance.scrollbarthumbVertical
                fun () -> Appearance.scrollbargripperHorizontal
                fun () -> Appearance.scrollbargripperVertical
                fun () -> Appearance.sliderHorizontal
                fun () -> Appearance.sliderVertical
                fun () -> Appearance.sliderthumbHorizontal
                fun () -> Appearance.sliderthumbVertical
                fun () -> Appearance.caret
                fun () -> Appearance.searchfield
                fun () -> Appearance.searchfieldDecoration
                fun () -> Appearance.searchfieldResultsDecoration
                fun () -> Appearance.searchfieldResultsButton
                fun () -> Appearance.searchfieldCancelButton
                fun () -> Appearance.textfield
                fun () -> Appearance.textarea
                fun () -> Appearance.checkbox
                fun () -> Appearance.checkboxContainer
                fun () -> Appearance.checkboxSmall
                fun () -> Appearance.dialog
                fun () -> Appearance.menuitem
                fun () -> Appearance.progressbar
                fun () -> Appearance.radio
                fun () -> Appearance.radioContainer
                fun () -> Appearance.radioSmall
                fun () -> Appearance.resizer
                fun () -> Appearance.scrollbar
                fun () -> Appearance.separator
                fun () -> Appearance.statusbar
                fun () -> Appearance.tab
                fun () -> Appearance.tabpanels
                fun () -> Appearance.textfieldMultiline
                fun () -> Appearance.toolbar
                fun () -> Appearance.toolbarbutton
                fun () -> Appearance.toolbox
                fun () -> Appearance.mozMacUnifiedToolbar
                fun () -> Appearance.mozWinBorderlessGlass
                fun () -> Appearance.mozWinBrowsertabbarToolbox
                fun () -> Appearance.mozWinCommunicationsToolbox
                fun () -> Appearance.mozWinGlass
                fun () -> Appearance.mozWinMediaToolbox
                fun () -> Appearance.tooltip
                fun () -> Appearance.treeheadercell
                fun () -> Appearance.treeheadersortarrow
                fun () -> Appearance.treeitem
                fun () -> Appearance.treetwisty
                fun () -> Appearance.treetwistyopen
                fun () -> Appearance.treeview
                fun () -> Appearance.window
                fun () -> Appearance.none
                fun () -> Appearance.auto
                fun () -> Appearance.inherit'
                fun () -> Appearance.initial
                fun () -> Appearance.unset
                fun () -> Appearance.revert
            |]
            
    module TypographyGenerator =
        let items =
            [|
                fun () -> Orphans.value (PrimitiveGenerator.int())
                fun () -> Orphans.inherit'
                fun () -> Orphans.initial
                fun () -> Orphans.unset 
                fun () -> Orphans.revert 
                fun () -> Widows.value (PrimitiveGenerator.int())
                fun () -> Widows.inherit'
                fun () -> Widows.initial
                fun () -> Widows.unset 
                fun () -> Widows.revert 
            |]
            
    module MixBlendModeGenerator =
        let items =
            [|
                fun () -> MixBlendMode.multiply
                fun () -> MixBlendMode.screen
                fun () -> MixBlendMode.overlay
                fun () -> MixBlendMode.darken
                fun () -> MixBlendMode.lighten
                fun () -> MixBlendMode.colorDodge
                fun () -> MixBlendMode.colorBurn
                fun () -> MixBlendMode.hardLight
                fun () -> MixBlendMode.softLight
                fun () -> MixBlendMode.difference
                fun () -> MixBlendMode.exclusion
                fun () -> MixBlendMode.hue
                fun () -> MixBlendMode.saturation
                fun () -> MixBlendMode.color
                fun () -> MixBlendMode.luminosity
                fun () -> MixBlendMode.normal 
                fun () -> MixBlendMode.inherit' 
                fun () -> MixBlendMode.initial 
                fun () -> MixBlendMode.unset 
                fun () -> MixBlendMode.revert 
            |]
    
    module FilterGenerator =
        let items =
            [|
                fun () -> Filter.url (PrimitiveGenerator.string())
                fun () -> Filter.blur (UnitGenerator.Troouba()())
                fun () -> Filter.brightness (UnitGenerator.percent())
                fun () -> Filter.contrast (UnitGenerator.percent())
                fun () -> Filter.dropShadow(UnitGenerator.Troouba()(), UnitGenerator.Troouba()(), UnitGenerator.Troouba()(), BaseColorGenerator.color()())
                fun () -> Filter.dropShadow(UnitGenerator.Troouba()(), UnitGenerator.Troouba()(), UnitGenerator.Troouba()(), BaseColorGenerator.color()(), UnitGenerator.percent())
                fun () -> Filter.grayscale (UnitGenerator.percent())
                fun () -> Filter.hueRotate (UnitGenerator.angle()())
                fun () -> Filter.invert (UnitGenerator.percent())
                fun () -> Filter.opacity (UnitGenerator.percent())
                fun () -> Filter.saturate (UnitGenerator.percent())
                fun () -> Filter.sepia (UnitGenerator.percent())
                fun () -> Filter.none 
                fun () -> Filter.inherit' 
                fun () -> Filter.initial 
                fun () -> Filter.unset 
                fun () -> BackdropFilter.url(PrimitiveGenerator.string())
                fun () -> BackdropFilter.blur (UnitGenerator.Troouba()())
                fun () -> BackdropFilter.brightness (UnitGenerator.percent())
                fun () -> BackdropFilter.contrast (UnitGenerator.percent())
                fun () -> BackdropFilter.grayscale (UnitGenerator.percent())
                fun () -> BackdropFilter.hueRotate (UnitGenerator.angle()())
                fun () -> BackdropFilter.invert (UnitGenerator.percent())
                fun () -> BackdropFilter.opacity (UnitGenerator.percent())
                fun () -> BackdropFilter.saturate (UnitGenerator.percent())
                fun () -> BackdropFilter.sepia (UnitGenerator.percent())
                fun () -> BackdropFilter.none 
                fun () -> BackdropFilter.inherit' 
                fun () -> BackdropFilter.initial 
                fun () -> BackdropFilter.unset 
                fun () -> BackdropFilter.revert 
            |]
            
    module BoxShadowGenerator =
        let items =
            [|
                fun () -> BoxShadow.value(UnitGenerator.Troouba()(), UnitGenerator.Troouba()(), BaseColorGenerator.color()()) 
                fun () -> BoxShadow.initial
                fun () -> BoxShadow.inherit'
                fun () -> BoxShadow.unset
                fun () -> BoxShadow.revert
            |]
            
    module AllGenerator =
        let items =
            [|
                fun () -> All.inherit'
                fun () -> All.initial
                fun () -> All.unset 
                fun () -> All.revert 
            |]
            
    module ScrollGenerator =
        let items =
            [|
                fun () -> ScrollBehavior.auto
                fun () -> ScrollBehavior.smooth
                fun () -> ScrollBehavior.inherit'
                fun () -> ScrollBehavior.initial
                fun () -> ScrollBehavior.unset 
                fun () -> ScrollBehavior.revert 
                fun () -> OverscrollBehaviorX.contain
                fun () -> OverscrollBehaviorX.auto
                fun () -> OverscrollBehaviorX.inherit'
                fun () -> OverscrollBehaviorX.initial
                fun () -> OverscrollBehaviorX.unset 
                fun () -> OverscrollBehaviorY.contain
                fun () -> OverscrollBehaviorY.auto
                fun () -> OverscrollBehaviorY.inherit'
                fun () -> OverscrollBehaviorY.initial
                fun () -> OverscrollBehaviorY.unset 
                fun () -> ScrollPaddingTop.value (UnitGenerator.lengthPercent())
                fun () -> ScrollPaddingTop.inherit'
                fun () -> ScrollPaddingTop.initial
                fun () -> ScrollPaddingTop.unset 
                fun () -> ScrollPaddingTop.revert 
                fun () -> ScrollPaddingRight.value (UnitGenerator.lengthPercent())
                fun () -> ScrollPaddingRight.inherit'
                fun () -> ScrollPaddingRight.initial
                fun () -> ScrollPaddingRight.unset 
                fun () -> ScrollPaddingRight.revert 
                fun () -> ScrollPaddingBottom.value (UnitGenerator.lengthPercent())
                fun () -> ScrollPaddingBottom.inherit'
                fun () -> ScrollPaddingBottom.initial
                fun () -> ScrollPaddingBottom.unset 
                fun () -> ScrollPaddingBottom.revert 
                fun () -> ScrollPaddingLeft.value (UnitGenerator.lengthPercent())
                fun () -> ScrollPaddingLeft.inherit'
                fun () -> ScrollPaddingLeft.initial
                fun () -> ScrollPaddingLeft.unset 
                fun () -> ScrollPaddingLeft.revert 
                fun () -> ScrollPadding.value (UnitGenerator.lengthPercent())
                fun () -> ScrollPadding.inherit'
                fun () -> ScrollPadding.initial
                fun () -> ScrollPadding.unset 
                fun () -> ScrollPadding.revert 
                fun () -> ScrollPadding.value (UnitGenerator.lengthPercent(), UnitGenerator.lengthPercent(), UnitGenerator.lengthPercent(), UnitGenerator.lengthPercent()) 
                fun () -> ScrollMarginTop.value (UnitGenerator.lengthPercent())
                fun () -> ScrollMarginTop.inherit'
                fun () -> ScrollMarginTop.initial
                fun () -> ScrollMarginTop.unset 
                fun () -> ScrollMarginTop.revert 
                fun () -> ScrollMarginRight.value (UnitGenerator.lengthPercent())
                fun () -> ScrollMarginRight.inherit'
                fun () -> ScrollMarginRight.initial
                fun () -> ScrollMarginRight.unset 
                fun () -> ScrollMarginRight.revert 
                fun () -> ScrollMarginBottom.value (UnitGenerator.lengthPercent())
                fun () -> ScrollMarginBottom.inherit'
                fun () -> ScrollMarginBottom.initial
                fun () -> ScrollMarginBottom.unset 
                fun () -> ScrollMarginBottom.revert 
                fun () -> ScrollMarginLeft.value (UnitGenerator.lengthPercent())
                fun () -> ScrollMarginLeft.inherit'
                fun () -> ScrollMarginLeft.initial
                fun () -> ScrollMarginLeft.unset 
                fun () -> ScrollMarginLeft.revert 
                fun () -> ScrollMargin.value (UnitGenerator.lengthPercent())
                fun () -> ScrollMargin.inherit'
                fun () -> ScrollMargin.initial
                fun () -> ScrollMargin.unset 
                fun () -> ScrollMargin.value (UnitGenerator.lengthPercent(), UnitGenerator.lengthPercent(), UnitGenerator.lengthPercent(), UnitGenerator.lengthPercent()) 
                fun () -> ScrollSnapType.none 
                fun () -> ScrollSnapType.x 
                fun () -> ScrollSnapType.y 
                fun () -> ScrollSnapType.block 
                fun () -> ScrollSnapType.inline' 
                fun () -> ScrollSnapType.both 
                fun () -> ScrollSnapType.mandatory(Fss.Types.Scroll.SnapType.X) 
                fun () -> ScrollSnapType.proximity(Fss.Types.Scroll.SnapType.X) 
                fun () -> ScrollSnapType.inherit'
                fun () -> ScrollSnapType.initial
                fun () -> ScrollSnapType.unset 
                fun () -> ScrollSnapType.revert 
                fun () -> ScrollSnapAlign.value(Fss.Types.Scroll.SnapAlign.Start, Fss.Types.Scroll.SnapAlign.End)
                fun () -> ScrollSnapAlign.start
                fun () -> ScrollSnapAlign.end'
                fun () -> ScrollSnapAlign.center
                fun () -> ScrollSnapAlign.none
                fun () -> ScrollSnapAlign.inherit' 
                fun () -> ScrollSnapAlign.initial
                fun () -> ScrollSnapAlign.unset 
                fun () -> ScrollSnapAlign.revert 
                fun () -> ScrollSnapStop.normal
                fun () -> ScrollSnapStop.always
                fun () -> ScrollSnapStop.inherit' 
                fun () -> ScrollSnapStop.initial
                fun () -> ScrollSnapStop.unset 
                fun () -> ScrollSnapStop.revert 
            |]
            
    module TableGenerator =
        let items =
            [|
                fun () -> CaptionSide.top
                fun () -> CaptionSide.bottom
                fun () -> CaptionSide.left
                fun () -> CaptionSide.right
                fun () -> CaptionSide.topOutside
                fun () -> CaptionSide.bottomOutside
                fun () -> CaptionSide.inherit'
                fun () -> CaptionSide.initial
                fun () -> CaptionSide.unset
                fun () -> CaptionSide.revert
                fun () -> EmptyCells.show
                fun () -> EmptyCells.hide
                fun () -> EmptyCells.inherit'
                fun () -> EmptyCells.initial
                fun () -> EmptyCells.unset
                fun () -> EmptyCells.revert
                fun () -> TableLayout.fixed'
                fun () -> TableLayout.auto
                fun () -> TableLayout.inherit'
                fun () -> TableLayout.initial
                fun () -> TableLayout.unset
                fun () -> TableLayout.revert
            |]
            
    module WordGenerator =
        let items =
            [|
                fun () -> WordSpacing.normal
                fun () -> WordSpacing.value (UnitGenerator.lengthPercent())
                fun () -> WordSpacing.inherit'
                fun () -> WordSpacing.initial
                fun () -> WordSpacing.unset
                fun () -> WordSpacing.revert
                fun () -> WordBreak.wordBreak
                fun () -> WordBreak.breakAll
                fun () -> WordBreak.keepAll
                fun () -> WordBreak.normal
                fun () -> WordBreak.inherit'
                fun () -> WordBreak.initial
                fun () -> WordBreak.unset
                fun () -> WordBreak.revert
            |]
            
    module WillChangeGenerator =
        let items =
            [|
                fun () -> WillChange.value (PrimitiveGenerator.string())
                fun () -> WillChange.value (PrimitiveGenerator.listOf(PrimitiveGenerator.string))
                fun () -> WillChange.contents 
                fun () -> WillChange.scrollPosition 
                fun () -> WillChange.auto 
                fun () -> WillChange.initial 
                fun () -> WillChange.inherit' 
                fun () -> WillChange.unset 
                fun () -> WillChange.revert 
            |]
            
    module ImageGenerator =
        let items =
            [|
                fun () -> ObjectFit.fill 
                fun () -> ObjectFit.contain 
                fun () -> ObjectFit.cover 
                fun () -> ObjectFit.scaleDown 
                fun () -> ObjectFit.none 
                fun () -> ObjectPosition.value (UnitGenerator.lengthPercent(), UnitGenerator.lengthPercent())
                fun () -> ObjectPosition.inherit'
                fun () -> ObjectPosition.initial
                fun () -> ObjectPosition.unset 
                fun () -> ObjectPosition.revert 
                fun () -> ImageRendering.auto
                fun () -> ImageRendering.crispEdges
                fun () -> ImageRendering.pixelated 
                fun () -> ImageRendering.inherit'
                fun () -> ImageRendering.initial
                fun () -> ImageRendering.unset 
                fun () -> ImageRendering.revert 
            |]
            
    module MaskGenerator =
        let items =
            [|
                fun () -> MaskClip.contentBox
                fun () -> MaskClip.paddingBox
                fun () -> MaskClip.borderBox
                fun () -> MaskClip.marginBox
                fun () -> MaskClip.fillBox
                fun () -> MaskClip.strokeBox
                fun () -> MaskClip.viewBox
                fun () -> MaskClip.noClip
                fun () -> MaskClip.border
                fun () -> MaskClip.padding
                fun () -> MaskClip.content
                fun () -> MaskClip.text
                fun () -> MaskClip.inherit'
                fun () -> MaskClip.initial
                fun () -> MaskClip.unset 
                fun () -> MaskClip.revert 
                fun () -> MaskComposite.add
                fun () -> MaskComposite.subtract
                fun () -> MaskComposite.intersect
                fun () -> MaskComposite.exclude
                fun () -> MaskComposite.inherit'
                fun () -> MaskComposite.initial
                fun () -> MaskComposite.unset 
                fun () -> MaskComposite.revert 
                fun () -> MaskImage.none 
                fun () -> MaskImage.url (PrimitiveGenerator.string())
                fun () -> MaskImage.linearGradient(UnitGenerator.angle()(), (PrimitiveGenerator.listOf(fun () -> BaseColorGenerator.color()(), UnitGenerator.lengthPercent())))
                fun () -> MaskImage.inherit' 
                fun () -> MaskImage.initial 
                fun () -> MaskImage.unset 
                fun () -> MaskImage.revert 
                fun () -> MaskMode.alpha 
                fun () -> MaskMode.luminance 
                fun () -> MaskMode.matchSource 
                fun () -> MaskMode.inherit' 
                fun () -> MaskMode.initial 
                fun () -> MaskMode.unset 
                fun () -> MaskMode.revert 
                fun () -> MaskOrigin.contentBox
                fun () -> MaskOrigin.paddingBox
                fun () -> MaskOrigin.borderBox
                fun () -> MaskOrigin.marginBox
                fun () -> MaskOrigin.fillBox
                fun () -> MaskOrigin.strokeBox
                fun () -> MaskOrigin.viewBox
                fun () -> MaskOrigin.border
                fun () -> MaskOrigin.padding
                fun () -> MaskOrigin.content
                fun () -> MaskOrigin.inherit'
                fun () -> MaskOrigin.initial
                fun () -> MaskOrigin.unset 
                fun () -> MaskPosition.value(UnitGenerator.lengthPercent(), UnitGenerator.lengthPercent())
                fun () -> MaskPosition.value (PrimitiveGenerator.listOf(fun () -> UnitGenerator.lengthPercent(), UnitGenerator.lengthPercent()))
                fun () -> MaskPosition.inherit'
                fun () -> MaskPosition.initial
                fun () -> MaskPosition.unset 
                fun () -> MaskPosition.revert 
                fun () -> MaskRepeat.repeatX
                fun () -> MaskRepeat.repeatY
                fun () -> MaskRepeat.noRepeat
                fun () -> MaskRepeat.repeat
                fun () -> MaskRepeat.round
                fun () -> MaskRepeat.space
                fun () -> MaskRepeat.inherit'
                fun () -> MaskRepeat.initial
                fun () -> MaskRepeat.unset 
                fun () -> MaskRepeat.revert 
                fun () -> MaskSize.cover
                fun () -> MaskSize.contain
                fun () -> MaskSize.value(UnitGenerator.lengthPercent())
                fun () -> MaskSize.value(UnitGenerator.lengthPercent(), UnitGenerator.lengthPercent())
                fun () -> MaskSize.value(PrimitiveGenerator.listOf(UnitGenerator.lengthPercent))
                fun () -> MaskSize.auto
                fun () -> MaskSize.inherit'
                fun () -> MaskSize.initial
                fun () -> MaskSize.unset 
                fun () -> MaskSize.revert 
            |]
    
    module SvgGenerator =
        let items =
            [|
                fun () -> Svg.AlignmentBaseline.baseline
                fun () -> Svg.AlignmentBaseline.textBottom
                fun () -> Svg.AlignmentBaseline.textBeforeEdge
                fun () -> Svg.AlignmentBaseline.middle
                fun () -> Svg.AlignmentBaseline.central
                fun () -> Svg.AlignmentBaseline.textTop
                fun () -> Svg.AlignmentBaseline.textAfterEdge
                fun () -> Svg.AlignmentBaseline.ideographic
                fun () -> Svg.AlignmentBaseline.alphabetic
                fun () -> Svg.AlignmentBaseline.hanging
                fun () -> Svg.AlignmentBaseline.mathematical
                fun () -> Svg.AlignmentBaseline.top
                fun () -> Svg.AlignmentBaseline.center
                fun () -> Svg.AlignmentBaseline.bottom
                fun () -> Svg.BaselineShift.sub
                fun () -> Svg.BaselineShift.super
                fun () -> Svg.BaselineShift.value (UnitGenerator.lengthPercent())
                fun () -> Svg.DominantBaseline.ideographic
                fun () -> Svg.DominantBaseline.alphabetic
                fun () -> Svg.DominantBaseline.hanging
                fun () -> Svg.DominantBaseline.mathematical
                fun () -> Svg.DominantBaseline.central
                fun () -> Svg.DominantBaseline.middle
                fun () -> Svg.DominantBaseline.textAfterEdge
                fun () -> Svg.DominantBaseline.textBeforeEdge
                fun () -> Svg.DominantBaseline.textTop
                fun () -> Svg.TextAnchor.start
                fun () -> Svg.TextAnchor.middle
                fun () -> Svg.TextAnchor.end'
                fun () -> Svg.ClipRule.nonzero
                fun () -> Svg.ClipRule.evenodd
                fun () -> Svg.FloodColor.rgb (PrimitiveGenerator.intLimit(255)) (PrimitiveGenerator.intLimit(255)) (PrimitiveGenerator.intLimit(255))
                fun () -> Svg.FloodColor.green 
                fun () -> Svg.FloodOpacity.value (PrimitiveGenerator.float())
                fun () -> Svg.LightingColor.rgb (PrimitiveGenerator.intLimit(255)) (PrimitiveGenerator.intLimit(255)) (PrimitiveGenerator.intLimit(255))
                fun () -> Svg.LightingColor.green 
                fun () -> Svg.StopColor.rgb (PrimitiveGenerator.intLimit(255)) (PrimitiveGenerator.intLimit(255)) (PrimitiveGenerator.intLimit(255))
                fun () -> Svg.StopColor.green 
                fun () -> Svg.StopOpacity.value (PrimitiveGenerator.float())
                fun () -> Svg.ColorInterpolation.sRGB 
                fun () -> Svg.ColorInterpolation.linearRGB 
                fun () -> Svg.ColorInterpolation.auto 
                fun () -> Svg.ColorInterpolationFilters.sRGB 
                fun () -> Svg.ColorInterpolationFilters.linearRGB 
                fun () -> Svg.ColorInterpolationFilters.auto 
                fun () -> Svg.Fill.rgb (PrimitiveGenerator.intLimit(255)) (PrimitiveGenerator.intLimit(255)) (PrimitiveGenerator.intLimit(255))
                fun () -> Svg.Fill.green 
                fun () -> Svg.FillOpacity.value (PrimitiveGenerator.float())
                fun () -> Svg.FillRule.nonzero
                fun () -> Svg.FillRule.evenodd
                fun () -> Svg.ImageRendering.optimizeSpeed
                fun () -> Svg.ImageRendering.optimizeQuality
                fun () -> Svg.ImageRendering.auto
                fun () -> Svg.ShapeRendering.optimizeSpeed
                fun () -> Svg.ShapeRendering.crispEdges
                fun () -> Svg.ShapeRendering.geometricPrecision
                fun () -> Svg.ShapeRendering.auto
                fun () -> Svg.Stroke.rgb (PrimitiveGenerator.intLimit(255)) (PrimitiveGenerator.intLimit(255)) (PrimitiveGenerator.intLimit(255))
                fun () -> Svg.Stroke.green 
                fun () -> Svg.StrokeOpacity.value (PrimitiveGenerator.float())
                fun () -> Svg.StrokeDasharray.value (PrimitiveGenerator.listOf(PrimitiveGenerator.int))
                fun () -> Svg.StrokeLinecap.butt
                fun () -> Svg.StrokeLinecap.round
                fun () -> Svg.StrokeLinecap.square
                fun () -> Svg.StrokeLinejoin.arcs
                fun () -> Svg.StrokeLinejoin.bevel
                fun () -> Svg.StrokeLinejoin.miter
                fun () -> Svg.StrokeLinejoin.miter
                fun () -> Svg.StrokeLinejoin.miterClip
                fun () -> Svg.StrokeLinejoin.round
                fun () -> Svg.StrokeMiterlimit.value (PrimitiveGenerator.int())
                fun () -> Svg.StrokeWidth.value (UnitGenerator.lengthPercent())
            |]
            
    module TransformGenerator =
        let items =
            [|
                fun () -> Transform.none 
                fun () -> Transform.inherit' 
                fun () -> Transform.initial 
                fun () -> Transform.unset 
                fun () -> Transform.value [ Transform.matrix(PrimitiveGenerator.float(), PrimitiveGenerator.float(), PrimitiveGenerator.float(), PrimitiveGenerator.float(), PrimitiveGenerator.float(), PrimitiveGenerator.float()) ] 
                fun () -> Transform.value [ Transform.matrix3D(PrimitiveGenerator.int(), PrimitiveGenerator.int(), PrimitiveGenerator.int(), PrimitiveGenerator.int(), PrimitiveGenerator.int(), PrimitiveGenerator.int(), PrimitiveGenerator.int(), PrimitiveGenerator.int(), PrimitiveGenerator.int(), PrimitiveGenerator.int(), PrimitiveGenerator.int(), PrimitiveGenerator.int(), PrimitiveGenerator.float(), PrimitiveGenerator.float(), PrimitiveGenerator.float(), PrimitiveGenerator.float()) ] 
                fun () -> Transform.value [ Transform.perspective(px 17) ] 
                fun () -> Transform.value [ Transform.rotate(turn 0.5) ] 
                fun () -> Transform.value [ Transform.rotate3D(1.0, 2.0, 3.0, (deg 10.0)) ] 
                fun () -> Transform.value [ Transform.rotateX(deg 10.0) ] 
                fun () -> Transform.value [ Transform.rotateY(grad 360.0) ] 
                fun () -> Transform.value [ Transform.rotateZ(rad 1.5) ] 
                fun () -> Transform.value [ Transform.translate(px 12) ] 
                fun () -> Transform.value [ Transform.translate(px 12, pct 50) ] 
                fun () -> Transform.value [ Transform.translate3D(px 12, pct 50, em 3.0) ] 
                fun () -> Transform.value [ Transform.translateX (px 10) ] 
                fun () -> Transform.value [ Transform.translateY(em 3.0) ] 
                fun () -> Transform.value [ Transform.translateZ(rem 3.0) ] 
                fun () -> Transform.value [ Transform.scale(0.5) ] 
                fun () -> Transform.value [ Transform.scale(0.5, 0.5) ] 
                fun () -> Transform.value [ Transform.scale3D(0.1, 0.2, 0.3) ] 
                fun () -> Transform.value [ Transform.scaleX(0.9) ] 
                fun () -> Transform.value [ Transform.scaleY(2.3) ] 
                fun () -> Transform.value [ Transform.scaleZ(3.4) ] 
                fun () -> Transform.value [ Transform.skew(deg 270.) ] 
                fun () -> Transform.value [ Transform.skew(turn 0.5, deg 10.0) ] 
                fun () -> Transform.value [ Transform.skewX(rad 9.) ] 
                fun () -> Transform.value [ Transform.skewY(deg 50.0) ] 
                fun () -> Transform.value [ Transform.translate3D(px 30, px 30, px 0); Transform.rotateZ(deg -179.) ] 
                fun () -> TransformOrigin.value (UnitGenerator.lengthPercent())
                fun () -> TransformOrigin.top 
                fun () -> TransformOrigin.right 
                fun () -> TransformOrigin.bottom 
                fun () -> TransformOrigin.left 
                fun () -> TransformOrigin.inherit' 
                fun () -> TransformOrigin.initial 
                fun () -> TransformOrigin.unset 
                fun () -> TransformOrigin.revert 
                fun () -> TransformStyle.flat 
                fun () -> TransformStyle.preserve3d 
                fun () -> TransformStyle.inherit' 
                fun () -> TransformStyle.initial 
                fun () -> TransformStyle.unset 
                fun () -> TransformStyle.revert 
            |]
    
    let createRandomRules numRules =
        seq { for _ in 0 .. numRules ->
                [| yield! BorderGenerator.items 
                   yield! ContentSizeGenerator.items 
                   yield! MarginGenerator.items
                   yield! PaddingGenerator.items
                   yield! ColorGenerator.items
                   yield! BackgroundGenerator.items
                   yield! CursorGenerator.items
                   yield! GridGenerator.items
                   yield! DisplayGenerator.items
                   yield! FlexGenerator.items
                   yield! PerspectiveGenerator.items
                   yield! TextGenerator.items
                   yield! PositionGenerator.items
                   yield! ResizeGenerator.items
                   yield! TransitionGenerator.items
                   yield! VisibilityGenerator.items
                   yield! ListStyleGenerator.items
                   yield! ContentGenerator.items
                   yield! ColumnGenerator.items
                   yield! OutlineGenerator.items
                   yield! PointerEventGenerator.items
                   yield! ClipPathGenerator.items
                   yield! AspectRatioGenerator.items
                   yield! ClearGenerator.items
                   yield! AppearanceGenerator.items
                   yield! TypographyGenerator.items
                   yield! MixBlendModeGenerator.items
                   yield! FilterGenerator.items
                   yield! BoxShadowGenerator.items
                   yield! AllGenerator.items
                   yield! ScrollGenerator.items
                   yield! TableGenerator.items
                   yield! WordGenerator.items
                   yield! WillChangeGenerator.items
                   yield! ImageGenerator.items
                   yield! MaskGenerator.items
                   yield! SvgGenerator.items
                   yield! TransformGenerator.items
                |] |> pick }
        |> Seq.map (fun x -> x())
        |> Seq.toList