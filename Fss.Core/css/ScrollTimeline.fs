namespace Fss

open Fss.Types

[<AutoOpen>]
module ScrollTimelineCss =
    /// Specifies which timeline drives a CSS animation
    let AnimationTimeline = ScrollTimelineClasses.AnimationTimeline(Property.AnimationTimeline)
    /// Specifies the name of a scroll progress timeline
    let ScrollTimelineName = ScrollTimelineClasses.ScrollTimelineName(Property.ScrollTimelineName)
    /// Specifies the axis of a scroll progress timeline
    let ScrollTimelineAxis = ScrollTimelineClasses.ScrollTimelineAxis(Property.ScrollTimelineAxis)
    /// Specifies the name of a view progress timeline
    let ViewTimelineName = ScrollTimelineClasses.ScrollTimelineName(Property.ViewTimelineName)
    /// Specifies the axis of a view progress timeline
    let ViewTimelineAxis = ScrollTimelineClasses.ScrollTimelineAxis(Property.ViewTimelineAxis)
    /// Specifies the range of the animation within the timeline
    let AnimationRange = ScrollTimelineClasses.AnimationRange(Property.AnimationRange)
    /// Specifies where in the timeline the animation starts
    let AnimationRangeStart = ScrollTimelineClasses.AnimationRangeEndpoint(Property.AnimationRangeStart)
    /// Specifies where in the timeline the animation ends
    let AnimationRangeEnd = ScrollTimelineClasses.AnimationRangeEndpoint(Property.AnimationRangeEnd)
