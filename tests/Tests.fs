namespace FSSTests

open Fet

module Tests =

    [<EntryPoint>]
    let main(args) =    
        if Seq.head args = "bench" then
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
        else
            runTests [
                Border.tests
                ContentSize.tests
                Margin.tests
                Padding.tests
                Color.tests
                Background.tests
                Cursor.tests
                Grid.tests
                Display.tests
                Flex.tests
                Perspective.tests
                Text.tests
                Position.tests
                Resize.tests
                Transition.tests
                Visibility.tests
                ListStyle.tests
                Content.tests
                Column.tests
                Outline.tests
                PointerEvents.tests
                Caret.tests
                ClipPath.tests
                AspectRatio.tests
                Clear.tests
                Appearance.tests
                Typography.tests
                MixBlendMode.tests
                Filter.tests
                Custom.tests
                BoxShadow.tests
                All.tests
                Scroll.tests
                Table.tests
                Word.tests
                WillChange.tests
                Image.tests
                Mask.tests
                Svg.tests
                Counter.tests
                Animation.tests
                Font.tests
                Transform.tests
                Psuedo.tests
                FontFace.tests
                Composite.tests
                Media.tests
                Selector.tests
            ]
            
        0