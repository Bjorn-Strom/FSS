namespace FSSTests

// Lag egne test prosjekter til hvert bibliotek
// Disse testene bruker sin egen kode. Da kan jeg teste alt

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
                    Fss.Functions.createFss2 randomRules |> ignore
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
//                BorderTests.tests
//                ContentSizeTests.tests
//                MarginTests.tests
//                PaddingTests.tests
//                ColorTests.tests
//                BackgroundTests.tests
//                CursorTests.tests
//                GridTests.tests
//                DisplayTests.tests
//                FlexTests.tests
//                PerspectiveTests.tests
//                TextTests.tests
//                PositionTests.tests
//                ResizeTests.tests
//                TransitionTests.tests
//                VisibilityTests.tests
//                ListStyleTests.tests
//                ContentTests.tests
//                ColumnTests.tests
//                OutlineTests.tests
//                PointerEventsTests.tests
//                CaretTests.tests
//                ClipPathTests.tests
//                AspectRatioTests.tests
//                ClearTests.tests
//                AppearanceTests.tests
//                TypographyTests.tests
//                MixBlendModeTests.tests
//                FilterTests.tests
//                CustomTests.tests
//                BoxShadowTests.tests
//                AllTests.tests
//                ScrollTests.tests
//                TableTests.tests
//                WordTests.tests
//                WillChangeTests.tests
//                ImageTests.tests
//                MaskTests.tests
//                SvgTests.tests
//                CounterTests.tests
//                AnimationTests.tests
//                FontTests.tests
//                TransformTests.tests
//                PseudoTests.tests
//                FontFaceTests.tests

//                OrderingTests.tests
//                MediaTests.tests
//                CompositeTests.tests
//                SelectorTests.tests
                CssGenerationTests.tests
            ]

        0
