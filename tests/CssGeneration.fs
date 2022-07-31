namespace FSSTests

open Fet
open Utils
open Fss

module CssGenerationTests =
    // Legg til selektor for klassenavn og Id
    // Skriv tester med alt dette
    // Rekkefølge stemmer
    // Antall hovers blir riktig
    let foo = createFss2 [
        Display.flex
        BackgroundColor.red
        Checked [
            BorderColor.bisque
        ]
        Hover [
            Color.white
            Display.flex
            Checked [
                Color.blue
            ]
            FontFamily.serif
            FontSize.value (px 28)
        ]
        BorderColor.red
        Display.grid
        Color.orangeRed
        Hover [
            Hover [
                Hover [
                    Hover [
                        Color.olive
                    ]
                ]
            ]
        ]

        ! Fss.Types.Html.A [
            Color.rebeccaPurple
            Hover [
                Color.orangeRed
            ]
        ]

        FirstLetter [
            Color.blue
        ]

        FirstLine [
            Color.orange
            After [
                Color.red
            ]
        ]

        !> Fss.Types.Html.Div [
            !~ Fss.Types.Html.Acronym [
                Color.orangeRed
            ]
        ]
    ]
    let tests =
        testList "CssGeneration"
            [
            ]
