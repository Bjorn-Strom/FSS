namespace FSSTests

open Fet
open Utils
open Fss

module CompositeTests =
    let counterName, counter =
        createCounterStyle [ System.cyclic
                             Symbols.value [ "" ]
                             Suffix.value " "
                             Prefix.value " " ]

    let fontName, font =
        createFontFace
            "DroidSerif"
            [ FontFace.Src.truetype "https://rawgit.com/google/fonts/master/ufl/ubuntu/Ubuntu-Bold.ttf"
              FontFace.FontWeight.value 100
              FontFace.FontStyle.normal ]

    let counterStyleName, counterStyle =
       createFss [ ListStyleType.value counterName
                   FontFamily.value fontName
                   ! (Selector.Tag Fss.Types.Html.Li) [ After [ Content.value "."  ]]
                   ! (Selector.Tag Fss.Types.Html.Li) [
                       BackgroundColor.aliceBlue
                       Hover [ BackgroundColor.orangeRed ]
                   ]
                   ]

    let containerName, container =
       createFss [ Display.flex
                   FlexDirection.column
                   AlignItems.center
                   JustifyContent.center
                   Label "container" ]

    let animationName, spinimation =
        createAnimation [ frame 0 [ Custom "transform" "rotate(0deg)" ]
                          frame 100 [ Custom "transform" "rotate(360deg)" ] ]

    let titleName, title =
       createFss [ AnimationName.value animationName
                   AnimationDuration.value (sec 1)
                   AnimationIterationCount.infinite
                   FontFamily.value "DroidSerif"
                   Hover [ AnimationDuration.value (ms 500) ]
                   Media.query [ Fss.Types.Media.MaxWidth(px 600) ] [
                       BackgroundColor.hex "87ceeb"
                   ]
                   Label "title"
                 ]
    let composition =
        ([$"@counter-style {counter}"
          $"@font-face {font}"
          $"{counterStyle}"
          $"{container}"
          $"@keyframes {spinimation}"
          $"{title}"]
        |> String.concat "")

    let tests =
       testList "Composite"
           [
               test "CompositeTest" <| fun _ ->
                   Expect.equal composition $"""@counter-style {counterName}{{system:cyclic;symbols:"";suffix:" ";prefix:" ";}}@font-face {{font-family:"DroidSerif";src:url(https://rawgit.com/google/fonts/master/ufl/ubuntu/Ubuntu-Bold.ttf) format('truetype');font-weight:100;font-style:normal;}}.{counterStyleName}{{list-style-type:{counterName};font-family:DroidSerif;}}.{counterStyleName} li::after{{content:".";}}.{counterStyleName} li{{background-color:aliceblue;}}.{counterStyleName} li:hover{{background-color:orangered;}}.{containerName}{{display:flex;flex-direction:column;align-items:center;justify-content:center;}}@keyframes {animationName}{{0%%{{transform:rotate(0deg);}}100%%{{transform:rotate(360deg);}}}}.{titleName}{{animation-name:{animationName};animation-duration:1s;animation-iteration-count:infinite;font-family:DroidSerif;}}.{titleName}:hover{{animation-duration:500ms;}}@media (max-width:600px) {{.{titleName}{{background-color:#87ceeb;}}}}"""
               testCase
                   "Important"
                   [ important Color.red ]
                   "{color:red !important;}"
               let _, actual = createFssWithClassname "myOwnClassName" [ BorderColor.red; BackgroundColor.green ]
               testEqual
                   "Test creating css with custom classname"
                   actual
                   ".myOwnClassName{border-color:red;background-color:green;}"
               testEqual
                   "Test that combine works"
                   (combine ["classnameA"] [ "classnameToCombine", true; "classnameToIgnore", false ])
                   "classnameA classnameToCombine"
           ]
