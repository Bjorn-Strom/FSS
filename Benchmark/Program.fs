open BenchmarkDotNet.Attributes
open BenchmarkDotNet.Running
open BenchmarkDotNet.Configs
open BenchmarkDotNet.Jobs
open Fss

// ---------------------------------------------------------------------------
// Fixed input data — deterministic so runs are comparable across commits
// ---------------------------------------------------------------------------

module Inputs =
    /// Flat rules only, no nesting. Pure stringification.
    let flatSmall =
        [ Display.flex
          BackgroundColor.blue
          Color.red
          FontSize.value (px 16)
          Padding.value (px 10) ]

    let flatMedium =
        [ Display.flex
          BackgroundColor.hex "44c767"
          Color.white
          FontSize.value (px 16)
          Padding.value (px 10, px 20)
          Margin.value (px 0)
          BorderRadius.value (px 4)
          BorderWidth.value (px 1)
          BorderStyle.solid
          BorderColor.hex "18ab29"
          Width.value (pct 100)
          Height.auto
          Cursor.pointer
          Position.relative
          ZIndex.value 10
          Opacity.value 0.9
          LetterSpacing.value (px 1)
          LineHeight.value (em 1.5)
          TextAlign.center
          TextTransform.uppercase ]

    let flatLarge =
        [ Display.flex
          FlexDirection.column
          FlexWrap.wrap
          JustifyContent.spaceBetween
          AlignItems.center
          AlignContent.stretch
          BackgroundColor.hex "f0f0f0"
          Color.hex "333333"
          FontSize.value (px 14)
          FontWeight.bold
          FontStyle.italic
          FontFamily.sansSerif
          Padding.value (px 10, px 20, px 10, px 20)
          Margin.value (px 0, auto)
          BorderRadius.value (px 8)
          BorderWidth.value (px 2)
          BorderStyle.dashed
          BorderColor.hex "cccccc"
          Width.value (pct 100)
          MaxWidth.value (px 1200)
          MinHeight.value (vh 100.0)
          Height.auto
          Cursor.pointer
          Position.relative
          Top.value (px 0)
          Left.value (px 0)
          ZIndex.value 100
          Opacity.value 1.0
          LetterSpacing.value (px 1)
          LineHeight.value (em 1.6)
          TextAlign.left
          TextTransform.capitalize
          TextDecoration.none
          BoxSizing.borderBox
          Overflow.hidden
          OverflowX.auto
          OverflowY.scroll
          WhiteSpace.nowrap
          WordBreak.breakAll
          PointerEvents.none
          UserSelect.none
          VerticalAlign.middle
          Visibility.visible
          BackgroundRepeat.noRepeat
          BackgroundSize.cover
          BackgroundPosition.center
          ObjectFit.cover
          ListStyleType.none
          WritingMode.horizontalTb
          Direction.ltr
          TabSize.value 4 ]

    /// Rules interleaved with pseudo-class scopes — exercises chunk
    let interleavedSmall =
        [ Color.red
          Hover [ Color.blue ]
          FontSize.value (px 14) ]

    let interleavedMedium =
        [ Color.red
          BackgroundColor.white
          Hover [ Color.blue; BackgroundColor.hex "eeeeee" ]
          FontSize.value (px 14)
          Padding.value (px 10)
          Focus [ BorderColor.hex "0066ff"; OutlineStyle.none ]
          Margin.value (px 0)
          BorderRadius.value (px 4)
          Active [ BackgroundColor.hex "dddddd" ]
          Cursor.pointer ]

    let interleavedLarge =
        [ Display.flex
          FlexDirection.column
          Hover [
              BackgroundColor.hex "f5f5f5"
              Color.hex "111111"
              BorderColor.hex "0066ff"
          ]
          Color.hex "333333"
          FontSize.value (px 14)
          Padding.value (px 16)
          Focus [
              OutlineStyle.none
              BorderColor.hex "0066ff"
              BoxShadow.value (px 0, px 0, px 4, hex "0066ff")
          ]
          Margin.value (px 0, auto)
          BorderRadius.value (px 8)
          BorderWidth.value (px 1)
          BorderStyle.solid
          BorderColor.hex "cccccc"
          Active [
              BackgroundColor.hex "e0e0e0"
              Transform.value [ Transform.scale 0.98 ]
          ]
          Width.value (pct 100)
          MaxWidth.value (px 960)
          Cursor.pointer
          Visited [ Color.hex "551a8b" ]
          Position.relative
          ZIndex.value 1
          Opacity.value 1.0
          FirstChild [
              MarginTop.value (px 0)
          ]
          LastChild [
              MarginBottom.value (px 0)
          ]
          TextAlign.left
          LineHeight.value (em 1.5) ]

    /// Deeply nested scopes — pseudo inside combinator inside media
    let deeplyNested =
        [ Color.black
          Media.query [ Fss.Types.Media.MinWidth (px 768) ] [
              Color.hex "333333"
              FontSize.value (px 16)
              Hover [
                  Color.hex "0066ff"
                  TextDecorationLine.underline
              ]
          ]
          Media.query [ Fss.Types.Media.MinWidth (px 1024) ] [
              FontSize.value (px 18)
              Hover [
                  Color.hex "0044cc"
              ]
          ]
          Hover [ Color.blue ]
          Focus [ OutlineStyle.none ]
          !> (Selector.p) [
              MarginBottom.value (px 16)
              Hover [ Color.red ]
          ] ]

    /// Scaling: generate N flat rules by repeating a pattern
    let scalingRules (n: int) =
        let pattern = [
            Display.flex
            Color.red
            BackgroundColor.blue
            FontSize.value (px 14)
            Padding.value (px 10)
            Margin.value (px 5)
            BorderRadius.value (px 4)
            Width.value (pct 100)
            Cursor.pointer
            Opacity.value 0.8
        ]
        List.init n (fun i -> pattern[i % pattern.Length])

    /// Scaling: generate N interleaved rules (rule, pseudo, rule, pseudo, ...)
    let scalingInterleaved (n: int) =
        List.init n (fun i ->
            if i % 3 = 1 then
                Hover [ Color.value (rgb (i % 256) ((i * 7) % 256) ((i * 13) % 256)) ]
            else
                Padding.value (px (i + 1))
        )

// ---------------------------------------------------------------------------
// Benchmarks
// ---------------------------------------------------------------------------

[<MemoryDiagnoser>]
[<SimpleJob(RuntimeMoniker.Net10_0, warmupCount = 5, iterationCount = 20)>]
type FlatRules() =
    [<Benchmark>]
    member _.Small() = createFss Inputs.flatSmall

    [<Benchmark>]
    member _.Medium() = createFss Inputs.flatMedium

    [<Benchmark>]
    member _.Large() = createFss Inputs.flatLarge

[<MemoryDiagnoser>]
[<SimpleJob(RuntimeMoniker.Net10_0, warmupCount = 5, iterationCount = 20)>]
type InterleavedRules() =
    [<Benchmark>]
    member _.Small() = createFss Inputs.interleavedSmall

    [<Benchmark>]
    member _.Medium() = createFss Inputs.interleavedMedium

    [<Benchmark>]
    member _.Large() = createFss Inputs.interleavedLarge

[<MemoryDiagnoser>]
[<SimpleJob(RuntimeMoniker.Net10_0, warmupCount = 5, iterationCount = 20)>]
type DeepNesting() =
    [<Benchmark>]
    member _.DeeplyNested() = createFss Inputs.deeplyNested

[<MemoryDiagnoser>]
[<SimpleJob(RuntimeMoniker.Net10_0, warmupCount = 5, iterationCount = 20)>]
type Scaling() =
    let flat10 = Inputs.scalingRules 10
    let flat50 = Inputs.scalingRules 50
    let flat200 = Inputs.scalingRules 200
    let interleaved10 = Inputs.scalingInterleaved 10
    let interleaved50 = Inputs.scalingInterleaved 50
    let interleaved200 = Inputs.scalingInterleaved 200

    [<Benchmark>]
    member _.Flat_10() = createFss flat10

    [<Benchmark>]
    member _.Flat_50() = createFss flat50

    [<Benchmark>]
    member _.Flat_200() = createFss flat200

    [<Benchmark>]
    member _.Interleaved_10() = createFss interleaved10

    [<Benchmark>]
    member _.Interleaved_50() = createFss interleaved50

    [<Benchmark>]
    member _.Interleaved_200() = createFss interleaved200

[<EntryPoint>]
let main args =
    // Note: the stringify cache in MasterTypeHelpers is internal,
    // so BenchmarkDotNet's process isolation handles cache state naturally.

    let config = DefaultConfig.Instance
    BenchmarkRunner.Run<FlatRules>(config) |> ignore
    BenchmarkRunner.Run<InterleavedRules>(config) |> ignore
    BenchmarkRunner.Run<DeepNesting>(config) |> ignore
    BenchmarkRunner.Run<Scaling>(config) |> ignore
    0
