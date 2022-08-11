﻿namespace FSSTests

open Fet

module Tests =

    [<EntryPoint>]
    let main(args) =
        match Seq.tryHead args with
        | Some args ->
            if args = "bench" then
                printfn "Generating some random CSS and timing it..."
                let timingList = System.Collections.Generic.List()
                for i in 0 .. 100 do
                    let randomRules = Generators.createRandomRules i
                    let start = System.DateTime.Now
                    Fss.Functions.createFss randomRules |> ignore
                    let stop = System.DateTime.Now
                    let timespan = (stop - start).TotalMilliseconds
                    timingList.Add(i, timespan)

                printfn "Performance test complete"
                printfn "Number of rules, Milliseconds used"
                Seq.iter (fun (n, ms) ->
                    printfn $"{n}, {ms}"
                    ) timingList
        | None ->
            runTests [
                BorderTests.tests
                ContentSizeTests.tests
                MarginTests.tests
                PaddingTests.tests
                ColorTests.tests
                BackgroundTests.tests
                CursorTests.tests
                GridTests.tests
                DisplayTests.tests
                FlexTests.tests
                PerspectiveTests.tests
                TextTests.tests
                PositionTests.tests
                ResizeTests.tests
                TransitionTests.tests
                VisibilityTests.tests
                ListStyleTests.tests
                ContentTests.tests
                ColumnTests.tests
                OutlineTests.tests
                PointerEventsTests.tests
                CaretTests.tests
                ClipPathTests.tests
                AspectRatioTests.tests
                ClearTests.tests
                AppearanceTests.tests
                TypographyTests.tests
                MixBlendModeTests.tests
                FilterTests.tests
                CustomTests.tests
                BoxShadowTests.tests
                AllTests.tests
                ScrollTests.tests
                TableTests.tests
                WordTests.tests
                WillChangeTests.tests
                ImageTests.tests
                MaskTests.tests
                SvgTests.tests
                CssGenerationTests.tests
                MediaTests.tests
                TransformTests.tests
                PseudoTests.tests
                FontTests.tests
                OrderingTests.tests
                SelectorTests.tests
                AnimationTests.tests

//                CompositeTests.tests
//                CounterTests.tests
//                FontFaceTests.tests


            ]

        0

// TODO:
// - Functions to make media stuff easier?
// - Speed up
// - Selectors can use classnames or id
// - Attribute selectors can use classnames or id
// DONE:
// Changed how the CSS is generated
// Also changed CSS output to be more minimized
        // This is reflected in the tests
