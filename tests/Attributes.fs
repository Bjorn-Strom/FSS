namespace FSSTests

open Fet
open Utils
open Fss
open Fss.Types

module AttributeTests =
    let tests =
        testList "Attribute"
            [
                let classname, actual = createFss [
                   Attr.Has (Attribute.Title, [
                        BackgroundColor.red
                    ])
                ]
                testEqual
                    "Has attribute"
                    actual
                    $".{classname}[title]{{background-color:red;}}"

                let classname, actual = createFss [
                   Attr.Has (Attribute.Title, [
                        BackgroundColor.red
                        Attr.Has (Attribute.Required, [
                            BackgroundColor.purple
                        ])
                    ])
                ]
                testEqual
                    "Has attribute nested"
                    actual
                    $".{classname}[title]{{background-color:red;}}.{classname}[title][required]{{background-color:purple;}}"

                let classname, actual = createFss [
                   Attr.Has (Selector.Tag Html.A, Attribute.Title, [
                        BackgroundColor.red
                    ])
                ]
                testEqual
                    "Has attribute with HTML tag selector"
                    actual
                    $"a.{classname}[title]{{background-color:red;}}"

                let classname, actual = createFss [
                   Attr.Has (Selector.Class "SomeOtherClass", Attribute.Title, [
                        BackgroundColor.red
                    ])
                ]
                testEqual
                    "Has attribute with class selector"
                    actual
                    $".SomeOtherClass.{classname}[title]{{background-color:red;}}"

                let classname, actual = createFss [
                   Attr.Has (Selector.Id "SomeId", Attribute.Title, [
                        BackgroundColor.red
                    ])
                ]
                testEqual
                    "Has attribute with id selector"
                    actual
                    $"#SomeId.{classname}[title]{{background-color:red;}}"

                let classname, actual = createFss [
                   Attr.Has (Selector.Id "SomeId", Attribute.Title, [
                        BackgroundColor.red
                        Hover [
                            BackgroundColor.green
                        ]
                    ])
                ]
                testEqual
                    "Has attribute with id selector and a nested hover"
                    actual
                    $"#SomeId.{classname}[title]{{background-color:red;}}#SomeId.{classname}[title]:hover{{background-color:green;}}"

                let classname, actual = createFss [
                   MatchAttr.Exactly (Attribute.Title, "article", [
                        FontSize.value (px 28)
                    ])
                ]
                testEqual
                    "="
                    actual
                    $".{classname}[title=\"article\"]{{font-size:28px;}}"

                let classname, actual = createFss [
                   MatchAttr.Exactly (Attribute.Title, "aRtIcLe", Attribute.Case.Insensitive, [
                        FontSize.value (px 28)
                    ])
                ]
                testEqual
                    "= insensitive"
                    actual
                    $".{classname}[title=\"aRtIcLe\" i]{{font-size:28px;}}"

                let classname, actual = createFss [
                   MatchAttr.Exactly (Attribute.Title, "aRtIcLe", Attribute.Case.Sensitive, [
                        FontSize.value (px 28)
                    ])
                ]
                testEqual
                    "= sensitive"
                    actual
                    $".{classname}[title=\"aRtIcLe\" s]{{font-size:28px;}}"

                let classname, actual = createFss [
                   MatchAttr.Exactly (Selector.Tag Html.A, Attribute.Title, "article", [
                        FontSize.value (px 28)
                    ])
                ]
                testEqual
                    "= html tag"
                    actual
                    $"a.{classname}[title=\"article\"]{{font-size:28px;}}"

                let classname, actual = createFss [
                   MatchAttr.Exactly (Selector.Class "someClass", Attribute.Title, "aRtIcLe", Attribute.Case.Insensitive, [
                        FontSize.value (px 28)
                    ])
                ]
                testEqual
                    "= class insensitive"
                    actual
                    $".someClass.{classname}[title=\"aRtIcLe\" i]{{font-size:28px;}}"

                let classname, actual = createFss [
                   MatchAttr.Exactly (Selector.Id "someId", Attribute.Title, "aRtIcLe", Attribute.Case.Sensitive, [
                        FontSize.value (px 28)
                    ])
                ]
                testEqual
                    "= id sensitive"
                    actual
                    $"#someId.{classname}[title=\"aRtIcLe\" s]{{font-size:28px;}}"

                let classname, actual = createFss [
                   MatchAttr.Exactly (Attribute.Title, "aRtIcLe", [
                        MatchAttr.Exactly (Selector.Id "someId", Attribute.Href, "foo", Attribute.Case.Sensitive, [
                            MatchAttr.Exactly (Selector.Class "someClass", Attribute.Alt, "bar", Attribute.Case.Insensitive, [
                                MatchAttr.Exactly (Selector.Tag Html.A, Attribute.Cite, "foobar", [
                                    Display.flex
                                ])
                            ])
                        ])
                    ])
                ]
                testEqual
                    "= nested"
                    actual
                    $"a.someClass#someId.{classname}[title=\"aRtIcLe\"][href=\"foo\" s][alt=\"bar\" i][cite=\"foobar\"]{{display:flex;}}"

                let classname, actual = createFss [
                   MatchAttr.Contains (Attribute.Title, "article", [
                        FontSize.value (px 28)
                    ])
                ]
                testEqual
                    "~= "
                    actual
                    $".{classname}[title~=\"article\"]{{font-size:28px;}}"

                let classname, actual = createFss [
                   MatchAttr.Contains (Attribute.Title, "aRtIcLe", Attribute.Case.Insensitive, [
                        FontSize.value (px 28)
                    ])
                ]
                testEqual
                    "~= insensitive"
                    actual
                    $".{classname}[title~=\"aRtIcLe\" i]{{font-size:28px;}}"

                let classname, actual = createFss [
                   MatchAttr.Contains (Attribute.Title, "aRtIcLe", Attribute.Case.Sensitive, [
                        FontSize.value (px 28)
                    ])
                ]
                testEqual
                    "~= sensitive"
                    actual
                    $".{classname}[title~=\"aRtIcLe\" s]{{font-size:28px;}}"

                let classname, actual = createFss [
                   MatchAttr.Contains (Selector.Tag Html.A, Attribute.Title, "article", [
                        FontSize.value (px 28)
                    ])
                ]
                testEqual
                    "~= html tag"
                    actual
                    $"a.{classname}[title~=\"article\"]{{font-size:28px;}}"

                let classname, actual = createFss [
                   MatchAttr.Contains (Selector.Class "someClass", Attribute.Title, "aRtIcLe", Attribute.Case.Insensitive, [
                        FontSize.value (px 28)
                    ])
                ]
                testEqual
                    "~= class insensitive"
                    actual
                    $".someClass.{classname}[title~=\"aRtIcLe\" i]{{font-size:28px;}}"

                let classname, actual = createFss [
                   MatchAttr.Contains (Selector.Id "someId", Attribute.Title, "aRtIcLe", Attribute.Case.Sensitive, [
                        FontSize.value (px 28)
                    ])
                ]
                testEqual
                    "~= id sensitive"
                    actual
                    $"#someId.{classname}[title~=\"aRtIcLe\" s]{{font-size:28px;}}"

                let classname, actual = createFss [
                   MatchAttr.Contains (Attribute.Title, "aRtIcLe", [
                        MatchAttr.Contains (Selector.Id "someId", Attribute.Href, "foo", Attribute.Case.Sensitive, [
                            MatchAttr.Contains (Selector.Class "someClass", Attribute.Alt, "bar", Attribute.Case.Insensitive, [
                                MatchAttr.Contains (Selector.Tag Html.A, Attribute.Cite, "foobar", [
                                    Display.flex
                                ])
                            ])
                        ])
                    ])
                ]
                testEqual
                    "~= nested"
                    actual
                    $"a.someClass#someId.{classname}[title~=\"aRtIcLe\"][href~=\"foo\" s][alt~=\"bar\" i][cite~=\"foobar\"]{{display:flex;}}"

                let classname, actual = createFss [
                    Display.flex

                    MatchAttr.Exactly (Attribute.Title, "Foo", [
                        Color.red

                        MatchAttr.Exactly (Attribute.Custom "data-value", "Bar", [
                            FontWeight.value 700

                            Hover [ BackgroundColor.green ]
                        ])
                    ])

                    MatchAttr.Exactly (Attribute.Custom "data-value", "Bar", [
                        Display.none
                    ])
                ]
                testEqual
                    "Normal css with attributes and pseudo"
                    actual
                    $".{classname}{{display:flex;}}.{classname}[title=\"Foo\"]{{color:red;}}.{classname}[title=\"Foo\"][data-value=\"Bar\"]{{font-weight:700;}}.{classname}[title=\"Foo\"][data-value=\"Bar\"]:hover{{background-color:green;}}.{classname}[data-value=\"Bar\"]{{display:none;}}"

                let classname, actual = createFss [
                   MatchAttr.ValueOrContinuation (Attribute.Title, "article", [
                        FontSize.value (px 28)
                    ])
                ]
                testEqual
                    "|="
                    actual
                    $".{classname}[title|=\"article\"]{{font-size:28px;}}"

                let classname, actual = createFss [
                   MatchAttr.ValueOrContinuation (Attribute.Title, "aRtIcLe", Attribute.Case.Insensitive, [
                        FontSize.value (px 28)
                    ])
                ]
                testEqual
                    "|= insensitive"
                    actual
                    $".{classname}[title|=\"aRtIcLe\" i]{{font-size:28px;}}"

                let classname, actual = createFss [
                   MatchAttr.ValueOrContinuation (Attribute.Title, "aRtIcLe", Attribute.Case.Sensitive, [
                        FontSize.value (px 28)
                    ])
                ]
                testEqual
                    "|= sensitive"
                    actual
                    $".{classname}[title|=\"aRtIcLe\" s]{{font-size:28px;}}"

                let classname, actual = createFss [
                   MatchAttr.ValueOrContinuation (Selector.Tag Html.A, Attribute.Title, "article", [
                        FontSize.value (px 28)
                    ])
                ]
                testEqual
                    "|= html tag"
                    actual
                    $"a.{classname}[title|=\"article\"]{{font-size:28px;}}"

                let classname, actual = createFss [
                   MatchAttr.ValueOrContinuation (Selector.Class "someClass", Attribute.Title, "aRtIcLe", Attribute.Case.Insensitive, [
                        FontSize.value (px 28)
                    ])
                ]
                testEqual
                    "|= class insensitive"
                    actual
                    $".someClass.{classname}[title|=\"aRtIcLe\" i]{{font-size:28px;}}"

                let classname, actual = createFss [
                   MatchAttr.ValueOrContinuation (Selector.Id "someId", Attribute.Title, "aRtIcLe", Attribute.Case.Sensitive, [
                        FontSize.value (px 28)
                    ])
                ]
                testEqual
                    "|= id sensitive"
                    actual
                    $"#someId.{classname}[title|=\"aRtIcLe\" s]{{font-size:28px;}}"

                let classname, actual = createFss [
                   MatchAttr.ValueOrContinuation (Attribute.Title, "aRtIcLe", [
                        MatchAttr.ValueOrContinuation (Selector.Id "someId", Attribute.Href, "foo", Attribute.Case.Sensitive, [
                            MatchAttr.ValueOrContinuation (Selector.Class "someClass", Attribute.Alt, "bar", Attribute.Case.Insensitive, [
                                MatchAttr.ValueOrContinuation (Selector.Tag Html.A, Attribute.Cite, "foobar", [
                                    Display.flex
                                ])
                            ])
                        ])
                    ])
                ]
                testEqual
                    "|= nested"
                    actual
                    $"a.someClass#someId.{classname}[title|=\"aRtIcLe\"][href|=\"foo\" s][alt|=\"bar\" i][cite|=\"foobar\"]{{display:flex;}}"

                let classname, actual = createFss [
                   MatchAttr.Prefix (Attribute.Title, "article", [
                        FontSize.value (px 28)
                    ])
                ]
                testEqual
                    "^="
                    actual
                    $".{classname}[title^=\"article\"]{{font-size:28px;}}"

                let classname, actual = createFss [
                   MatchAttr.Prefix (Attribute.Title, "aRtIcLe", Attribute.Case.Insensitive, [
                        FontSize.value (px 28)
                    ])
                ]
                testEqual
                    "^= insensitive"
                    actual
                    $".{classname}[title^=\"aRtIcLe\" i]{{font-size:28px;}}"

                let classname, actual = createFss [
                   MatchAttr.Prefix (Attribute.Title, "aRtIcLe", Attribute.Case.Sensitive, [
                        FontSize.value (px 28)
                    ])
                ]
                testEqual
                    "^= sensitive"
                    actual
                    $".{classname}[title^=\"aRtIcLe\" s]{{font-size:28px;}}"

                let classname, actual = createFss [
                   MatchAttr.Prefix (Selector.Tag Html.A, Attribute.Title, "article", [
                        FontSize.value (px 28)
                    ])
                ]
                testEqual
                    "^= html tag"
                    actual
                    $"a.{classname}[title^=\"article\"]{{font-size:28px;}}"

                let classname, actual = createFss [
                   MatchAttr.Prefix (Selector.Class "someClass", Attribute.Title, "aRtIcLe", Attribute.Case.Insensitive, [
                        FontSize.value (px 28)
                    ])
                ]
                testEqual
                    "^= class insensitive"
                    actual
                    $".someClass.{classname}[title^=\"aRtIcLe\" i]{{font-size:28px;}}"

                let classname, actual = createFss [
                   MatchAttr.Prefix (Selector.Id "someId", Attribute.Title, "aRtIcLe", Attribute.Case.Sensitive, [
                        FontSize.value (px 28)
                    ])
                ]
                testEqual
                    "^= id sensitive"
                    actual
                    $"#someId.{classname}[title^=\"aRtIcLe\" s]{{font-size:28px;}}"

                let classname, actual = createFss [
                   MatchAttr.Prefix (Attribute.Title, "aRtIcLe", [
                        MatchAttr.Prefix (Selector.Id "someId", Attribute.Href, "foo", Attribute.Case.Sensitive, [
                            MatchAttr.Prefix (Selector.Class "someClass", Attribute.Alt, "bar", Attribute.Case.Insensitive, [
                                MatchAttr.Prefix (Selector.Tag Html.A, Attribute.Cite, "foobar", [
                                    Display.flex
                                ])
                            ])
                        ])
                    ])
                ]
                testEqual
                    "^= nested"
                    actual
                    $"a.someClass#someId.{classname}[title^=\"aRtIcLe\"][href^=\"foo\" s][alt^=\"bar\" i][cite^=\"foobar\"]{{display:flex;}}"

                let classname, actual = createFss [
                   MatchAttr.Suffix (Attribute.Title, "article", [
                        FontSize.value (px 28)
                    ])
                ]
                testEqual
                    "$="
                    actual
                    $".{classname}[title$=\"article\"]{{font-size:28px;}}"

                let classname, actual = createFss [
                   MatchAttr.Suffix (Attribute.Title, "aRtIcLe", Attribute.Case.Insensitive, [
                        FontSize.value (px 28)
                    ])
                ]
                testEqual
                    "$= insensitive"
                    actual
                    $".{classname}[title$=\"aRtIcLe\" i]{{font-size:28px;}}"

                let classname, actual = createFss [
                   MatchAttr.Suffix (Attribute.Title, "aRtIcLe", Attribute.Case.Sensitive, [
                        FontSize.value (px 28)
                    ])
                ]
                testEqual
                    "$= sensitive"
                    actual
                    $".{classname}[title$=\"aRtIcLe\" s]{{font-size:28px;}}"

                let classname, actual = createFss [
                   MatchAttr.Suffix (Selector.Tag Html.A, Attribute.Title, "article", [
                        FontSize.value (px 28)
                    ])
                ]
                testEqual
                    "$= html tag"
                    actual
                    $"a.{classname}[title$=\"article\"]{{font-size:28px;}}"

                let classname, actual = createFss [
                   MatchAttr.Suffix (Selector.Class "someClass", Attribute.Title, "aRtIcLe", Attribute.Case.Insensitive, [
                        FontSize.value (px 28)
                    ])
                ]
                testEqual
                    "$= class insensitive"
                    actual
                    $".someClass.{classname}[title$=\"aRtIcLe\" i]{{font-size:28px;}}"

                let classname, actual = createFss [
                   MatchAttr.Suffix (Selector.Id "someId", Attribute.Title, "aRtIcLe", Attribute.Case.Sensitive, [
                        FontSize.value (px 28)
                    ])
                ]
                testEqual
                    "$= id sensitive"
                    actual
                    $"#someId.{classname}[title$=\"aRtIcLe\" s]{{font-size:28px;}}"

                let classname, actual = createFss [
                   MatchAttr.Suffix (Attribute.Title, "aRtIcLe", [
                        MatchAttr.Suffix (Selector.Id "someId", Attribute.Href, "foo", Attribute.Case.Sensitive, [
                            MatchAttr.Suffix (Selector.Class "someClass", Attribute.Alt, "bar", Attribute.Case.Insensitive, [
                                MatchAttr.Suffix (Selector.Tag Html.A, Attribute.Cite, "foobar", [
                                    Display.flex
                                ])
                            ])
                        ])
                    ])
                ]
                testEqual
                    "$= nested"
                    actual
                    $"a.someClass#someId.{classname}[title$=\"aRtIcLe\"][href$=\"foo\" s][alt$=\"bar\" i][cite$=\"foobar\"]{{display:flex;}}"

                let classname, actual = createFss [
                   MatchAttr.AtLeastOne (Attribute.Title, "article", [
                        FontSize.value (px 28)
                    ])
                ]
                testEqual
                    "*="
                    actual
                    $".{classname}[title*=\"article\"]{{font-size:28px;}}"

                let classname, actual = createFss [
                   MatchAttr.AtLeastOne (Attribute.Title, "aRtIcLe", Attribute.Case.Insensitive, [
                        FontSize.value (px 28)
                    ])
                ]
                testEqual
                    "*= insensitive"
                    actual
                    $".{classname}[title*=\"aRtIcLe\" i]{{font-size:28px;}}"

                let classname, actual = createFss [
                   MatchAttr.AtLeastOne (Attribute.Title, "aRtIcLe", Attribute.Case.Sensitive, [
                        FontSize.value (px 28)
                    ])
                ]
                testEqual
                    "*= sensitive"
                    actual
                    $".{classname}[title*=\"aRtIcLe\" s]{{font-size:28px;}}"

                let classname, actual = createFss [
                   MatchAttr.AtLeastOne (Selector.Tag Html.A, Attribute.Title, "article", [
                        FontSize.value (px 28)
                    ])
                ]
                testEqual
                    "*= html tag"
                    actual
                    $"a.{classname}[title*=\"article\"]{{font-size:28px;}}"

                let classname, actual = createFss [
                   MatchAttr.AtLeastOne (Selector.Class "someClass", Attribute.Title, "aRtIcLe", Attribute.Case.Insensitive, [
                        FontSize.value (px 28)
                    ])
                ]
                testEqual
                    "*= class insensitive"
                    actual
                    $".someClass.{classname}[title*=\"aRtIcLe\" i]{{font-size:28px;}}"

                let classname, actual = createFss [
                   MatchAttr.AtLeastOne (Selector.Id "someId", Attribute.Title, "aRtIcLe", Attribute.Case.Sensitive, [
                        FontSize.value (px 28)
                    ])
                ]
                testEqual
                    "*= id sensitive"
                    actual
                    $"#someId.{classname}[title*=\"aRtIcLe\" s]{{font-size:28px;}}"

                let classname, actual = createFss [
                   MatchAttr.AtLeastOne (Attribute.Title, "aRtIcLe", [
                        MatchAttr.AtLeastOne (Selector.Id "someId", Attribute.Href, "foo", Attribute.Case.Sensitive, [
                            MatchAttr.AtLeastOne (Selector.Class "someClass", Attribute.Alt, "bar", Attribute.Case.Insensitive, [
                                MatchAttr.AtLeastOne (Selector.Tag Html.A, Attribute.Cite, "foobar", [
                                    Display.flex
                                ])
                            ])
                        ])
                    ])
                ]
                testEqual
                    "*= nested"
                    actual
                    $"a.someClass#someId.{classname}[title*=\"aRtIcLe\"][href*=\"foo\" s][alt*=\"bar\" i][cite*=\"foobar\"]{{display:flex;}}"








                // TODO:
//                let classname, actual = createFss [
//                    MatchAttr.Contains (Selector.Tag Html.Div, Attribute.Class, "Article", [
//                        MatchAttr.Exactly (Selector.Tag Html.P, Attribute.Title, "Header", [
//                            FontSize.value(px 24)
//                        ])
//                        BackgroundColor.red
//                    ])
//                ]
//                testEqual
//                    "~ and ="
//                    actual
//                    $"p.{classname}[class~=\"Article\"][title=\"Header\"],div.{classname}[class~=\"Article\"][title=\"Header\"]{{font-size:24px;}}"


]
