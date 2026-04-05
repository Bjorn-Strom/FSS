namespace FSSTests

open Fss
open Fss.Types
open Fet
open Utils

module ScrollTimelineTests =
    let tests =
        testList "ScrollTimeline"
            [
                // AnimationTimeline
                testCase
                    "AnimationTimeline auto"
                    [ AnimationTimeline.auto ]
                    "{animation-timeline:auto;}"
                testCase
                    "AnimationTimeline none"
                    [ AnimationTimeline.none ]
                    "{animation-timeline:none;}"
                testCase
                    "AnimationTimeline scroll()"
                    [ AnimationTimeline.scroll() ]
                    "{animation-timeline:scroll();}"
                testCase
                    "AnimationTimeline scroll(nearest)"
                    [ AnimationTimeline.scroll(ScrollTimeline.Nearest) ]
                    "{animation-timeline:scroll(nearest);}"
                testCase
                    "AnimationTimeline scroll(root)"
                    [ AnimationTimeline.scroll(ScrollTimeline.Root) ]
                    "{animation-timeline:scroll(root);}"
                testCase
                    "AnimationTimeline scroll(block)"
                    [ AnimationTimeline.scroll(ScrollTimeline.Block) ]
                    "{animation-timeline:scroll(block);}"
                testCase
                    "AnimationTimeline scroll(root inline)"
                    [ AnimationTimeline.scroll(ScrollTimeline.Root, ScrollTimeline.Inline) ]
                    "{animation-timeline:scroll(root inline);}"
                testCase
                    "AnimationTimeline scroll(self y)"
                    [ AnimationTimeline.scroll(ScrollTimeline.Self, ScrollTimeline.Y) ]
                    "{animation-timeline:scroll(self y);}"
                testCase
                    "AnimationTimeline view()"
                    [ AnimationTimeline.view() ]
                    "{animation-timeline:view();}"
                testCase
                    "AnimationTimeline view(block)"
                    [ AnimationTimeline.view(ScrollTimeline.Block) ]
                    "{animation-timeline:view(block);}"
                testCase
                    "AnimationTimeline view(inline)"
                    [ AnimationTimeline.view(ScrollTimeline.Inline) ]
                    "{animation-timeline:view(inline);}"
                testCase
                    "AnimationTimeline view with inset"
                    [ AnimationTimeline.view(ScrollTimeline.Block, "10%") ]
                    "{animation-timeline:view(block 10%);}"
                testCase
                    "AnimationTimeline named"
                    [ AnimationTimeline.named "--my-scroller" ]
                    "{animation-timeline:--my-scroller;}"
                testCase
                    "AnimationTimeline inherit"
                    [ AnimationTimeline.inherit' ]
                    "{animation-timeline:inherit;}"

                // ScrollTimelineName
                testCase
                    "ScrollTimelineName value"
                    [ ScrollTimelineName.value "--my-scroller" ]
                    "{scroll-timeline-name:--my-scroller;}"
                testCase
                    "ScrollTimelineName none"
                    [ ScrollTimelineName.none ]
                    "{scroll-timeline-name:none;}"

                // ScrollTimelineAxis
                testCase
                    "ScrollTimelineAxis block"
                    [ ScrollTimelineAxis.block ]
                    "{scroll-timeline-axis:block;}"
                testCase
                    "ScrollTimelineAxis inline"
                    [ ScrollTimelineAxis.inline' ]
                    "{scroll-timeline-axis:inline;}"
                testCase
                    "ScrollTimelineAxis x"
                    [ ScrollTimelineAxis.x ]
                    "{scroll-timeline-axis:x;}"
                testCase
                    "ScrollTimelineAxis y"
                    [ ScrollTimelineAxis.y ]
                    "{scroll-timeline-axis:y;}"

                // ViewTimelineName
                testCase
                    "ViewTimelineName value"
                    [ ViewTimelineName.value "--my-viewer" ]
                    "{view-timeline-name:--my-viewer;}"

                // ViewTimelineAxis
                testCase
                    "ViewTimelineAxis block"
                    [ ViewTimelineAxis.block ]
                    "{view-timeline-axis:block;}"
                testCase
                    "ViewTimelineAxis inline"
                    [ ViewTimelineAxis.inline' ]
                    "{view-timeline-axis:inline;}"

                // AnimationRange
                testCase
                    "AnimationRange normal"
                    [ AnimationRange.normal ]
                    "{animation-range:normal;}"
                testCase
                    "AnimationRange cover"
                    [ AnimationRange.value ScrollTimeline.Cover ]
                    "{animation-range:cover;}"
                testCase
                    "AnimationRange entry"
                    [ AnimationRange.value ScrollTimeline.Entry ]
                    "{animation-range:entry;}"
                testCase
                    "AnimationRange entry with percentage"
                    [ AnimationRange.value(ScrollTimeline.Entry, pct 10) ]
                    "{animation-range:entry 10%;}"
                testCase
                    "AnimationRange start and end"
                    [ AnimationRange.value(ScrollTimeline.Entry, pct 10, ScrollTimeline.Cover, pct 50) ]
                    "{animation-range:entry 10% cover 50%;}"

                // AnimationRangeStart / End
                testCase
                    "AnimationRangeStart entry"
                    [ AnimationRangeStart.value ScrollTimeline.Entry ]
                    "{animation-range-start:entry;}"
                testCase
                    "AnimationRangeStart entry 10%"
                    [ AnimationRangeStart.value(ScrollTimeline.Entry, pct 10) ]
                    "{animation-range-start:entry 10%;}"
                testCase
                    "AnimationRangeEnd exit"
                    [ AnimationRangeEnd.value ScrollTimeline.Exit ]
                    "{animation-range-end:exit;}"
                testCase
                    "AnimationRangeEnd exit 90%"
                    [ AnimationRangeEnd.value(ScrollTimeline.Exit, pct 90) ]
                    "{animation-range-end:exit 90%;}"
                testCase
                    "AnimationRangeStart normal"
                    [ AnimationRangeStart.normal ]
                    "{animation-range-start:normal;}"
            ]
