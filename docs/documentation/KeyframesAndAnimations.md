## Animations

Animations introduce 3 new functions:
- `keyframes` `KeyframeAttribute list -> IAnimationName`
- `frame`  `int -> CSSProperty list -> KeyframeAttribute`
- `frames`  `int list -> CSSProperty list -> KeyframeAttribute`

What this means is that keyframes is a function that takes a list of `frame` or `frame` function calls.
`frame` is used when you want to define a single keyframe and `frames` for multiple.
keyframes then gives you an animation name you supply to `fss`.

```fsharp
let bounceFrames =
    keyframes
        [
            frames [ 0; 20; 53; 80; 100 ]
                [
                   transforms
                       [
                           Transform.Translate3D(px 0, px 0, px 0) ]
                       ]
                ]
            frames [40; 43]
                [
                   transforms
                       [
                           Transform.Translate3D(px 0, px -30, px 0) ]
                       ]
                ]
            frame 70
                [
                   transforms
                       [
                            Transform.Translate3D(px 0, px -15, px 0) ]
                       ]
                ]
            frame 90
                [
                   transforms
                       [
                           Transform.Translate3D(px 0, px -4, px 0) ]
                       ]
                ]
        ]
let bounceAnimation =
    fss
        [
            AnimationName.Name bounceFrames
            AnimationDuration' (sec 1.0)
            AnimationTimingFunction.EaseInOut
            AnimationIterationCount.Infinite
        ]
```

## Transforms

Just a quick note on transforms. In CSS it is easy to think that when you apply a transform CSS expects just one transform

It works with one, but it is easier to think about transforms as accepting a list of transforms, now this list can have just one element.

I have also seen it as a mistake from people who don't know Css too well (I have made it myself), where combining transforms can be a bit of an issue.

For these reasons in Fss when you apply transforms it always expects a list, but otherwise works as you would expect.


```fsharp
Transforms
    [
        Transform.RotateX <| deg 10.
        Transform.RotateY <| deg 15.
        Transform.Perspective <| px 20
    ]
```