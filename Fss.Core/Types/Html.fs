namespace Fss

namespace Fss.Types

    [<RequireQualifiedAccess>]
    module Html =
        type Html =
            | A
            | All
            | Abbr
            | Acronym
            | Address
            | Applet
            | Area
            | Article
            | Aside
            | Audio
            | B
            | Base
            | Basefont
            | Bdo
            | Big
            | Blockquote
            | Body
            | Br
            | Button
            | Canvas
            | Caption
            | Center
            | Cite
            | Code
            | Col
            | Colgroup
            | Datalist
            | Dd
            | Del
            | Dfn
            | Div
            | Dl
            | Dt
            | Em
            | Embed
            | Fieldset
            | Figcaption
            | Figure
            | Font
            | Footer
            | Form
            | Frame
            | Frameset
            | Head
            | Header
            | H1
            | H2
            | H3
            | H4
            | H5
            | H6
            | Hr
            | Html
            | I
            | Iframe
            | Img
            | Input
            | Ins
            | Kbd
            | Label
            | Legend
            | Li
            | Link
            | Main
            | Map
            | Mark
            | Meta
            | Meter
            | Nav
            | Noscript
            | Object
            | Ol
            | Optgroup
            | Option
            | P
            | Param
            | Pre
            | Progress
            | Q
            | S
            | Samp
            | Script
            | Section
            | Select
            | Small
            | Source
            | Span
            | Strike
            | Strong
            | Style
            | Sub
            | Sup
            | Table
            | Tbody
            | Td
            | Textarea
            | Tfoot
            | Th
            | Thead
            | Time
            | Title
            | Tr
            | U
            | Ul
            | Var
            | Video
            | Wbr
            with
            member this.Stringify () =
                match this with
                | A -> "a"
                | All -> "*"
                | Abbr -> "abbr"
                | Acronym -> "acronym"
                | Address -> "address"
                | Applet -> "applet"
                | Area -> "area"
                | Article -> "article"
                | Aside -> "aside"
                | Audio -> "audio"
                | B -> "b"
                | Base -> "base"
                | Basefont -> "basefront"
                | Bdo -> "bdo"
                | Big -> "big"
                | Blockquote -> "blockquote"
                | Body -> "body"
                | Br -> "br"
                | Button -> "button"
                | Canvas -> "canvas"
                | Caption -> "caption"
                | Center -> "center"
                | Cite -> "cite"
                | Code -> "code"
                | Col -> "col"
                | Colgroup -> "colgroup"
                | Datalist -> "datalist"
                | Dd -> "dd"
                | Del -> "del"
                | Dfn -> "dfn"
                | Div -> "div" 
                | Dl -> "dl"
                | Dt -> "dt"
                | Em -> "em"
                | Embed -> "embed"
                | Fieldset -> "fieldset"
                | Figcaption -> "figcaption"
                | Figure -> "figure"
                | Font -> "font"
                | Footer -> "footer"
                | Form -> "form"
                | Frame -> "frame"
                | Frameset -> "frameset"
                | Head -> "head"
                | Header -> "header"
                | H1 -> "h1"
                | H2 -> "h2"
                | H3 -> "h3"
                | H4 -> "h4"
                | H5  -> "h5"
                | H6 -> "h6"
                | Hr -> "hr"
                | Html -> "html"
                | I -> "i"
                | Iframe -> "iframe"
                | Img -> "img"
                | Input -> "input"
                | Ins -> "ins"
                | Kbd -> "kdb"
                | Label -> "label"
                | Legend -> "legend"
                | Li -> "li"
                | Link -> "link"
                | Main -> "main"
                | Map -> "map"
                | Mark -> "mark"
                | Meta -> "meta"
                | Meter -> "meter"
                | Nav -> "nav"
                | Noscript -> "noscript"
                | Object -> "object"
                | Ol -> "ol"
                | Optgroup -> "optgroup"
                | Option -> "option"
                | P -> "p"
                | Param -> "param"
                | Pre -> "pre"
                | Progress -> "progress"
                | Q -> "q"
                | S -> "s"
                | Samp -> "samp"
                | Script -> "script"
                | Section -> "section"
                | Select -> "select"
                | Small -> "small"
                | Source -> "source"
                | Span -> "span"
                | Strike -> "strike"
                | Strong -> "strong"
                | Style -> "style"
                | Sub -> "sub"
                | Sup -> "sup"
                | Table -> "table"
                | Tbody -> "tbody"
                | Td -> "td"
                | Textarea -> "textarea"
                | Tfoot -> "tfoot"
                | Th -> "th"
                | Thead -> "thead"
                | Time -> "time"
                | Title -> "title"
                | Tr -> "tr"
                | U -> "u"
                | Ul -> "ul"
                | Var -> "var"
                | Video -> "video"
                | Wbr -> "wbr"