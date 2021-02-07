namespace FSSTests

open Fable.Mocha
open Fable.Core.JsInterop
open Utils
open Fss

module ClipPath =
     let tests =
        testList "ClipPath"
            [
                test
                    "ClipPath all sides pct"
                    [ ClipPath.Inset(pct 40)]
                    [ "clipPath" ==> "inset(40%)" ]
                test
                    "ClipPath all sides px"
                    [ ClipPath.Inset(px 40)]
                    [ "clipPath" ==> "inset(40px)" ]
                test
                    "ClipPath horizontal-vertical"
                    [ ClipPath.Inset(pct 40, px 50)]
                    [ "clipPath" ==> "inset(40% 50px)" ]
                test
                    "ClipPath top-horizontal-bottom"
                    [ ClipPath.Inset(pct 40, px 50, vh 3.)]
                    [ "clipPath" ==> "inset(40% 50px 3.0vh)" ]
                test
                    "ClipPath top-right-bottom-left"
                    [ ClipPath.Inset(pct 40, px 50, vh 3., rem 2.)]
                    [ "clipPath" ==> "inset(40% 50px 3.0vh 2.0rem)" ]

                test
                    "ClipPath all sides pct with round"
                    [ ClipPath.Inset(pct 40, [ pct 50 :> ILengthPercentage ])]
                    [ "clipPath" ==> "inset(40% round 50%)" ]
                test
                    "ClipPath all sides px"
                    [ ClipPath.Inset(px 40, [ px 50 :> ILengthPercentage ])]
                    [ "clipPath" ==> "inset(40px round 50px)" ]
                test
                    "ClipPath horizontal-vertical"
                    [ ClipPath.Inset(pct 40, px 50, [ px 50 :> ILengthPercentage ])]
                    [ "clipPath" ==> "inset(40% 50px round 50px)" ]
                test
                    "ClipPath top-horizontal-bottom"
                    [ ClipPath.Inset(pct 40, px 50, vh 3., [ px 50 :> ILengthPercentage ])]
                    [ "clipPath" ==> "inset(40% 50px 3.0vh round 50px)" ]
                test
                    "ClipPath top-right-bottom-left"
                    [ ClipPath.Inset(pct 40, px 50, vh 3., rem 2., [ px 50 :> ILengthPercentage; pct 50 :> ILengthPercentage ])]
                    [ "clipPath" ==> "inset(40% 50px 3.0vh 2.0rem round 50px 50%)" ]

                test
                    "ClipPath none"
                    [ ClipPath.None]
                    [ "clipPath" ==> "none" ]
                test
                    "ClipPath inherit"
                    [ ClipPath.Inherit]
                    [ "clipPath" ==> "inherit" ]
                test
                    "ClipPath initial"
                    [ ClipPath.Initial]
                    [ "clipPath" ==> "initial" ]
                test
                    "ClipPath unset"
                    [ ClipPath.Unset ]
                    [ "clipPath" ==> "unset" ]
            ]