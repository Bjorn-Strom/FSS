namespace Fss

open Fss.Types

[<AutoOpen>]
module MediaCss =
    // Some convenience functions here to more easily use media queries without accessing Fss.Types namespace.
    // Also stops collision with transitions and content-size
    let private mediaClass = MediaClasses.Media()
    type Media =
        static member query features rules = mediaClass.query features rules
        static member queryFor device features rules = mediaClass.queryFor device features rules
        // Device
        static member Screen = Media.Screen
        static member Speech = Media.Speech
        static member Print = Media.Print
        static member All = Media.All
        static member Not device = Media.Not device
        static member Only device = Media.Only device
        // Pointer
        static member Course = Media.Course
        static member Fine = Media.Fine
        static member None = Media.None
        // ColorGamut
        static member SRGB = Media.SRGB
        static member P3 = Media.P3
        static member REC2020 = Media.REC2020
        // DisplayMode
        static member Fullscreen = Media.Fullscreen
        static member Standalone = Media.Standalone
        static member MinimalUi = Media.MinimalUi
        static member Browser = Media.Browser
        // Light level
        static member Dim = Media.Dim
        static member Washed = Media.Washed
        // Orientation
        static member Landscape = Media.Landscape
        static member Portrait = Media.Portrait
        // Overflowblock
        static member OverflowNone = Media.OverflowBlock'.None'
        static member Scrolled = Media.Scrolled
        static member OptionalPaged = Media.OptionalPaged
        static member Paged = Media.Paged
        // ColorScheme
        static member Light = Media.Light
        static member Dark = Media.Dark
        // Contrast
        static member NoPreference = Media.NoPreference
        static member High = Media.High
        static member Low = Media.Low
        // Scan
        static member Interlace = Media.Interlace
        static member Progressive = Media.Progressive
        // Scripting
        static member ScriptingNone = Media.Scripting'.None'
        static member InitialOnly = Media.InitialOnly
        static member Enable = Media.Enable
        // Update
        static member UpdateNone = Media.Update'.None'
        static member Slow = Media.Slow
        static member Fast = Media.Fast
        // Features
        static member AnyHover hover = Media.AnyHover hover
        static member AnyPointer pointer = Media.AnyPointer pointer
        static member AspectRatio ratio = Media.AspectRatio ratio
        static member MinAspectRatio ratio = Media.MinAspectRatio ratio
        static member MaxAspectRatio ratio = Media.MaxAspectRatio ratio
        static member Color = Media.Color
        static member MinColor color = Media.MinColor color
        static member MaxColor color = Media.MaxColor color
        static member ColorGamut colorGamut = Media.ColorGamut colorGamut
        static member ColorIndex color = Media.ColorIndex color
        static member MinColorIndex color = Media.MinColorIndex color
        static member MaxColorIndex color = Media.MaxColorIndex color
        static member DisplayMode displayMode = Media.DisplayMode displayMode
        static member ForcedColors forced = Media.ForcedColors forced
        static member Grid grid = Media.Grid grid
        static member Height height = Media.Height height
        static member MinHeight height = Media.MinHeight height
        static member MaxHeight height = Media.MaxHeight height
        static member Width width = Media.Width width
        static member MinWidth width = Media.MinWidth width
        static member MaxWidth width = Media.MaxWidth width
        static member Hover hover = Media.Hover hover
        static member InvertedColors inverted = Media.InvertedColors inverted
        static member LightLevel lightLevel = Media.LightLevel lightLevel
        static member Monochrome monochrome = Media.Monochrome monochrome
        static member MinMonochrome monochrome = Media.MinMonochrome monochrome
        static member MaxMonochrome monochrome = Media.MaxMonochrome monochrome
        static member Orientation orientation = Media.Orientation orientation
        static member OverflowBlock overflowBlock = Media.OverflowBlock overflowBlock
        static member OverflowInline overflowInline = Media.OverflowInline overflowInline
        static member Pointer pointer = Media.Pointer pointer
        static member PrefersColorScheme colorScheme = Media.PrefersColorScheme colorScheme
        static member PrefersContrast contrast = Media.PrefersContrast contrast
        static member PrefersReducedMotion prefersReducedMotion = Media.PrefersReducedMotion prefersReducedMotion
        static member PrefersReducedTransparency prefersReducedTransparency = Media.PrefersReducedTransparency prefersReducedTransparency
        static member Resolution resolution = Media.Resolution resolution
        static member MinResolution resolution = Media.MinResolution resolution
        static member MaxResolution resolution = Media.MaxResolution resolution
        static member Scan scan = Media.Scan scan
        static member Scripting scripting = Media.Scripting scripting
        static member Update update  = Media.Update update
