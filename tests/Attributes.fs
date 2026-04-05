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
                    (sprintf ".%s{&[title]{background-color:red;}}" classname)

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
                    (sprintf ".%s{&[title]{background-color:red;&[required]{background-color:purple;}}}" classname)

                let classname, actual = createFss [
                   Attr.Has (Selector.a, Attribute.Title, [
                        BackgroundColor.red
                    ])
                ]
                testEqual
                    "Has attribute with HTML tag selector"
                    actual
                    (sprintf ".%s{&a[title]{background-color:red;}}" classname)

                let classname, actual = createFss [
                   Attr.Has (Selector.Class "SomeOtherClass", Attribute.Title, [
                        BackgroundColor.red
                    ])
                ]
                testEqual
                    "Has attribute with class selector"
                    actual
                    (sprintf ".%s{&.SomeOtherClass[title]{background-color:red;}}" classname)

                let classname, actual = createFss [
                   Attr.Has (Selector.Id "SomeId", Attribute.Title, [
                        BackgroundColor.red
                    ])
                ]
                testEqual
                    "Has attribute with id selector"
                    actual
                    (sprintf ".%s{&#SomeId[title]{background-color:red;}}" classname)

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
                    (sprintf ".%s{&#SomeId[title]{background-color:red;&:hover{background-color:green;}}}" classname)

                let classname, actual = createFss [
                   MatchAttr.Exactly (Attribute.Title, "article", [
                        FontSize.value (px 28)
                    ])
                ]
                testEqual
                    "="
                    actual
                    (sprintf """.%s{&[title="article"]{font-size:28px;}}""" classname)

                let classname, actual = createFss [
                   MatchAttr.Exactly (Attribute.Title, "aRtIcLe", Attribute.Case.Insensitive, [
                        FontSize.value (px 28)
                    ])
                ]
                testEqual
                    "= insensitive"
                    actual
                    (sprintf """.%s{&[title="aRtIcLe" i]{font-size:28px;}}""" classname)

                let classname, actual = createFss [
                   MatchAttr.Exactly (Attribute.Title, "aRtIcLe", Attribute.Case.Sensitive, [
                        FontSize.value (px 28)
                    ])
                ]
                testEqual
                    "= sensitive"
                    actual
                    (sprintf """.%s{&[title="aRtIcLe" s]{font-size:28px;}}""" classname)

                let classname, actual = createFss [
                   MatchAttr.Exactly (Selector.a, Attribute.Title, "article", [
                        FontSize.value (px 28)
                    ])
                ]
                testEqual
                    "= html tag"
                    actual
                    (sprintf """.%s{&a[title="article"]{font-size:28px;}}""" classname)

                let classname, actual = createFss [
                   MatchAttr.Exactly (Selector.Class "someClass", Attribute.Title, "aRtIcLe", Attribute.Case.Insensitive, [
                        FontSize.value (px 28)
                    ])
                ]
                testEqual
                    "= class insensitive"
                    actual
                    (sprintf """.%s{&.someClass[title="aRtIcLe" i]{font-size:28px;}}""" classname)

                let classname, actual = createFss [
                   MatchAttr.Exactly (Selector.Id "someId", Attribute.Title, "aRtIcLe", Attribute.Case.Sensitive, [
                        FontSize.value (px 28)
                    ])
                ]
                testEqual
                    "= id sensitive"
                    actual
                    (sprintf """.%s{&#someId[title="aRtIcLe" s]{font-size:28px;}}""" classname)

                let classname, actual = createFss [
                   MatchAttr.Exactly (Attribute.Title, "aRtIcLe", [
                        MatchAttr.Exactly (Selector.Id "someId", Attribute.Href, "foo", Attribute.Case.Sensitive, [
                            MatchAttr.Exactly (Selector.Class "someClass", Attribute.Alt, "bar", Attribute.Case.Insensitive, [
                                MatchAttr.Exactly (Selector.a, Attribute.Cite, "foobar", [
                                    Display.flex
                                ])
                            ])
                        ])
                    ])
                ]
                testEqual
                    "= nested"
                    actual
                    (sprintf """.%s{&[title="aRtIcLe"]{&#someId[href="foo" s]{&.someClass[alt="bar" i]{&a[cite="foobar"]{display:flex;}}}}}""" classname)

                let classname, actual = createFss [
                   MatchAttr.Contains (Attribute.Title, "article", [
                        FontSize.value (px 28)
                    ])
                ]
                testEqual
                    "~= "
                    actual
                    (sprintf """.%s{&[title~="article"]{font-size:28px;}}""" classname)

                let classname, actual = createFss [
                   MatchAttr.Contains (Attribute.Title, "aRtIcLe", Attribute.Case.Insensitive, [
                        FontSize.value (px 28)
                    ])
                ]
                testEqual
                    "~= insensitive"
                    actual
                    (sprintf """.%s{&[title~="aRtIcLe" i]{font-size:28px;}}""" classname)

                let classname, actual = createFss [
                   MatchAttr.Contains (Attribute.Title, "aRtIcLe", Attribute.Case.Sensitive, [
                        FontSize.value (px 28)
                    ])
                ]
                testEqual
                    "~= sensitive"
                    actual
                    (sprintf """.%s{&[title~="aRtIcLe" s]{font-size:28px;}}""" classname)

                let classname, actual = createFss [
                   MatchAttr.Contains (Selector.a, Attribute.Title, "article", [
                        FontSize.value (px 28)
                    ])
                ]
                testEqual
                    "~= html tag"
                    actual
                    (sprintf """.%s{&a[title~="article"]{font-size:28px;}}""" classname)

                let classname, actual = createFss [
                   MatchAttr.Contains (Selector.Class "someClass", Attribute.Title, "aRtIcLe", Attribute.Case.Insensitive, [
                        FontSize.value (px 28)
                    ])
                ]
                testEqual
                    "~= class insensitive"
                    actual
                    (sprintf """.%s{&.someClass[title~="aRtIcLe" i]{font-size:28px;}}""" classname)

                let classname, actual = createFss [
                   MatchAttr.Contains (Selector.Id "someId", Attribute.Title, "aRtIcLe", Attribute.Case.Sensitive, [
                        FontSize.value (px 28)
                    ])
                ]
                testEqual
                    "~= id sensitive"
                    actual
                    (sprintf """.%s{&#someId[title~="aRtIcLe" s]{font-size:28px;}}""" classname)

                let classname, actual = createFss [
                   MatchAttr.Contains (Attribute.Title, "aRtIcLe", [
                        MatchAttr.Contains (Selector.Id "someId", Attribute.Href, "foo", Attribute.Case.Sensitive, [
                            MatchAttr.Contains (Selector.Class "someClass", Attribute.Alt, "bar", Attribute.Case.Insensitive, [
                                MatchAttr.Contains (Selector.a, Attribute.Cite, "foobar", [
                                    Display.flex
                                ])
                            ])
                        ])
                    ])
                ]
                testEqual
                    "~= nested"
                    actual
                    (sprintf """.%s{&[title~="aRtIcLe"]{&#someId[href~="foo" s]{&.someClass[alt~="bar" i]{&a[cite~="foobar"]{display:flex;}}}}}""" classname)

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
                    (sprintf """.%s{display:flex;&[title="Foo"]{color:red;&[data-value="Bar"]{font-weight:700;&:hover{background-color:green;}}}&[data-value="Bar"]{display:none;}}""" classname)

                let classname, actual = createFss [
                   MatchAttr.ValueOrContinuation (Attribute.Title, "article", [
                        FontSize.value (px 28)
                    ])
                ]
                testEqual
                    "|="
                    actual
                    (sprintf """.%s{&[title|="article"]{font-size:28px;}}""" classname)

                let classname, actual = createFss [
                   MatchAttr.ValueOrContinuation (Attribute.Title, "aRtIcLe", Attribute.Case.Insensitive, [
                        FontSize.value (px 28)
                    ])
                ]
                testEqual
                    "|= insensitive"
                    actual
                    (sprintf """.%s{&[title|="aRtIcLe" i]{font-size:28px;}}""" classname)

                let classname, actual = createFss [
                   MatchAttr.ValueOrContinuation (Attribute.Title, "aRtIcLe", Attribute.Case.Sensitive, [
                        FontSize.value (px 28)
                    ])
                ]
                testEqual
                    "|= sensitive"
                    actual
                    (sprintf """.%s{&[title|="aRtIcLe" s]{font-size:28px;}}""" classname)

                let classname, actual = createFss [
                   MatchAttr.ValueOrContinuation (Selector.a, Attribute.Title, "article", [
                        FontSize.value (px 28)
                    ])
                ]
                testEqual
                    "|= html tag"
                    actual
                    (sprintf """.%s{&a[title|="article"]{font-size:28px;}}""" classname)

                let classname, actual = createFss [
                   MatchAttr.ValueOrContinuation (Selector.Class "someClass", Attribute.Title, "aRtIcLe", Attribute.Case.Insensitive, [
                        FontSize.value (px 28)
                    ])
                ]

                testEqual
                    "|= class insensitive"
                    actual
                    (sprintf """.%s{&.someClass[title|="aRtIcLe" i]{font-size:28px;}}""" classname)

                let classname, actual = createFss [
                   MatchAttr.ValueOrContinuation (Selector.Id "someId", Attribute.Title, "aRtIcLe", Attribute.Case.Sensitive, [
                        FontSize.value (px 28)
                    ])
                ]
                testEqual
                    "|= id sensitive"
                    actual
                    (sprintf """.%s{&#someId[title|="aRtIcLe" s]{font-size:28px;}}""" classname)

                let classname, actual = createFss [
                   MatchAttr.ValueOrContinuation (Attribute.Title, "aRtIcLe", [
                        MatchAttr.ValueOrContinuation (Selector.Id "someId", Attribute.Href, "foo", Attribute.Case.Sensitive, [
                            MatchAttr.ValueOrContinuation (Selector.Class "someClass", Attribute.Alt, "bar", Attribute.Case.Insensitive, [
                                MatchAttr.ValueOrContinuation (Selector.a, Attribute.Cite, "foobar", [
                                    Display.flex
                                ])
                            ])
                        ])
                    ])
                ]
                testEqual
                    "|= nested"
                    actual
                    (sprintf """.%s{&[title|="aRtIcLe"]{&#someId[href|="foo" s]{&.someClass[alt|="bar" i]{&a[cite|="foobar"]{display:flex;}}}}}""" classname)

                let classname, actual = createFss [
                   MatchAttr.Prefix (Attribute.Title, "article", [
                        FontSize.value (px 28)
                    ])
                ]
                testEqual
                    "^="
                    actual
                    (sprintf """.%s{&[title^="article"]{font-size:28px;}}""" classname)

                let classname, actual = createFss [
                   MatchAttr.Prefix (Attribute.Title, "aRtIcLe", Attribute.Case.Insensitive, [
                        FontSize.value (px 28)
                    ])
                ]
                testEqual
                    "^= insensitive"
                    actual
                    (sprintf """.%s{&[title^="aRtIcLe" i]{font-size:28px;}}""" classname)

                let classname, actual = createFss [
                   MatchAttr.Prefix (Attribute.Title, "aRtIcLe", Attribute.Case.Sensitive, [
                        FontSize.value (px 28)
                    ])
                ]
                testEqual
                    "^= sensitive"
                    actual
                    (sprintf """.%s{&[title^="aRtIcLe" s]{font-size:28px;}}""" classname)

                let classname, actual = createFss [
                   MatchAttr.Prefix (Selector.a, Attribute.Title, "article", [
                        FontSize.value (px 28)
                    ])
                ]
                testEqual
                    "^= html tag"
                    actual
                    (sprintf """.%s{&a[title^="article"]{font-size:28px;}}""" classname)

                let classname, actual = createFss [
                   MatchAttr.Prefix (Selector.Class "someClass", Attribute.Title, "aRtIcLe", Attribute.Case.Insensitive, [
                        FontSize.value (px 28)
                    ])
                ]
                testEqual
                    "^= class insensitive"
                    actual
                    (sprintf """.%s{&.someClass[title^="aRtIcLe" i]{font-size:28px;}}""" classname)

                let classname, actual = createFss [
                   MatchAttr.Prefix (Selector.Id "someId", Attribute.Title, "aRtIcLe", Attribute.Case.Sensitive, [
                        FontSize.value (px 28)
                    ])
                ]
                testEqual
                    "^= id sensitive"
                    actual
                    (sprintf """.%s{&#someId[title^="aRtIcLe" s]{font-size:28px;}}""" classname)

                let classname, actual = createFss [
                   MatchAttr.Prefix (Attribute.Title, "aRtIcLe", [
                        MatchAttr.Prefix (Selector.Id "someId", Attribute.Href, "foo", Attribute.Case.Sensitive, [
                            MatchAttr.Prefix (Selector.Class "someClass", Attribute.Alt, "bar", Attribute.Case.Insensitive, [
                                MatchAttr.Prefix (Selector.a, Attribute.Cite, "foobar", [
                                    Display.flex
                                ])
                            ])
                        ])
                    ])
                ]
                testEqual
                    "^= nested"
                    actual
                    (sprintf """.%s{&[title^="aRtIcLe"]{&#someId[href^="foo" s]{&.someClass[alt^="bar" i]{&a[cite^="foobar"]{display:flex;}}}}}""" classname)

                let classname, actual = createFss [
                   MatchAttr.Suffix (Attribute.Title, "article", [
                        FontSize.value (px 28)
                    ])
                ]
                testEqual
                    "$="
                    actual
                    (sprintf """.%s{&[title$="article"]{font-size:28px;}}""" classname)

                let classname, actual = createFss [
                   MatchAttr.Suffix (Attribute.Title, "aRtIcLe", Attribute.Case.Insensitive, [
                        FontSize.value (px 28)
                    ])
                ]
                testEqual
                    "$= insensitive"
                    actual
                    (sprintf """.%s{&[title$="aRtIcLe" i]{font-size:28px;}}""" classname)

                let classname, actual = createFss [
                   MatchAttr.Suffix (Attribute.Title, "aRtIcLe", Attribute.Case.Sensitive, [
                        FontSize.value (px 28)
                    ])
                ]
                testEqual
                    "$= sensitive"
                    actual
                    (sprintf """.%s{&[title$="aRtIcLe" s]{font-size:28px;}}""" classname)

                let classname, actual = createFss [
                   MatchAttr.Suffix (Selector.a, Attribute.Title, "article", [
                        FontSize.value (px 28)
                    ])
                ]
                testEqual
                    "$= html tag"
                    actual
                    (sprintf """.%s{&a[title$="article"]{font-size:28px;}}""" classname)

                let classname, actual = createFss [
                   MatchAttr.Suffix (Selector.Class "someClass", Attribute.Title, "aRtIcLe", Attribute.Case.Insensitive, [
                        FontSize.value (px 28)
                    ])
                ]
                testEqual
                    "$= class insensitive"
                    actual
                    (sprintf """.%s{&.someClass[title$="aRtIcLe" i]{font-size:28px;}}""" classname)

                let classname, actual = createFss [
                   MatchAttr.Suffix (Selector.Id "someId", Attribute.Title, "aRtIcLe", Attribute.Case.Sensitive, [
                        FontSize.value (px 28)
                    ])
                ]
                testEqual
                    "$= id sensitive"
                    actual
                    (sprintf """.%s{&#someId[title$="aRtIcLe" s]{font-size:28px;}}""" classname)

                let classname, actual = createFss [
                   MatchAttr.Suffix (Attribute.Title, "aRtIcLe", [
                        MatchAttr.Suffix (Selector.Id "someId", Attribute.Href, "foo", Attribute.Case.Sensitive, [
                            MatchAttr.Suffix (Selector.Class "someClass", Attribute.Alt, "bar", Attribute.Case.Insensitive, [
                                MatchAttr.Suffix (Selector.a, Attribute.Cite, "foobar", [
                                    Display.flex
                                ])
                            ])
                        ])
                    ])
                ]
                testEqual
                    "$= nested"
                    actual
                    (sprintf """.%s{&[title$="aRtIcLe"]{&#someId[href$="foo" s]{&.someClass[alt$="bar" i]{&a[cite$="foobar"]{display:flex;}}}}}""" classname)

                let classname, actual = createFss [
                   MatchAttr.AtLeastOne (Attribute.Title, "article", [
                        FontSize.value (px 28)
                    ])
                ]
                testEqual
                    "*="
                    actual
                    (sprintf """.%s{&[title*="article"]{font-size:28px;}}""" classname)

                let classname, actual = createFss [
                   MatchAttr.AtLeastOne (Attribute.Title, "aRtIcLe", Attribute.Case.Insensitive, [
                        FontSize.value (px 28)
                    ])
                ]
                testEqual
                    "*= insensitive"
                    actual
                    (sprintf """.%s{&[title*="aRtIcLe" i]{font-size:28px;}}""" classname)

                let classname, actual = createFss [
                   MatchAttr.AtLeastOne (Attribute.Title, "aRtIcLe", Attribute.Case.Sensitive, [
                        FontSize.value (px 28)
                    ])
                ]
                testEqual
                    "*= sensitive"
                    actual
                    (sprintf """.%s{&[title*="aRtIcLe" s]{font-size:28px;}}""" classname)

                let classname, actual = createFss [
                   MatchAttr.AtLeastOne (Selector.a, Attribute.Title, "article", [
                        FontSize.value (px 28)
                    ])
                ]
                testEqual
                    "*= html tag"
                    actual
                    (sprintf """.%s{&a[title*="article"]{font-size:28px;}}""" classname)

                let classname, actual = createFss [
                   MatchAttr.AtLeastOne (Selector.Class "someClass", Attribute.Title, "aRtIcLe", Attribute.Case.Insensitive, [
                        FontSize.value (px 28)
                    ])
                ]
                testEqual
                    "*= class insensitive"
                    actual
                    (sprintf """.%s{&.someClass[title*="aRtIcLe" i]{font-size:28px;}}""" classname)

                let classname, actual = createFss [
                   MatchAttr.AtLeastOne (Selector.Id "someId", Attribute.Title, "aRtIcLe", Attribute.Case.Sensitive, [
                        FontSize.value (px 28)
                    ])
                ]
                testEqual
                    "*= id sensitive"
                    actual
                    (sprintf """.%s{&#someId[title*="aRtIcLe" s]{font-size:28px;}}""" classname)

                let classname, actual = createFss [
                   MatchAttr.AtLeastOne (Attribute.Title, "aRtIcLe", [
                        MatchAttr.AtLeastOne (Selector.Id "someId", Attribute.Href, "foo", Attribute.Case.Sensitive, [
                            MatchAttr.AtLeastOne (Selector.Class "someClass", Attribute.Alt, "bar", Attribute.Case.Insensitive, [
                                MatchAttr.AtLeastOne (Selector.a, Attribute.Cite, "foobar", [
                                    Display.flex
                                ])
                            ])
                        ])
                    ])
                ]
                testEqual
                    "*= nested"
                    actual
                    (sprintf """.%s{&[title*="aRtIcLe"]{&#someId[href*="foo" s]{&.someClass[alt*="bar" i]{&a[cite*="foobar"]{display:flex;}}}}}""" classname)
                let classname, actual = createFss [
                    MatchAttr.Contains (Attribute.Class, "Article", [
                        MatchAttr.Exactly (Selector.p, Attribute.Title, "Header", [
                            FontSize.value(px 24)
                        ])
                    ])
                    MatchAttr.Contains (Selector.div, Attribute.Class, "Article", [
                        MatchAttr.Exactly (Attribute.Title, "Header", [
                            FontSize.value(px 24)
                        ])
                        BackgroundColor.red
                    ])
                ]
                testEqual
                    "~ and ="
                    actual
                    (sprintf """.%s{&[class~="Article"]{&p[title="Header"]{font-size:24px;}}&div[class~="Article"]{&[title="Header"]{font-size:24px;}background-color:red;}}""" classname)

                let classname, actual = createFss [
                    MatchAttr.Exactly (Attribute.Data "code", "FA123", [
                        Opacity.value 1
                    ])
                ]
                testEqual
                    "Data label"
                    actual
                    (sprintf """.%s{&[data-code="FA123"]{opacity:1;}}""" classname)

]
