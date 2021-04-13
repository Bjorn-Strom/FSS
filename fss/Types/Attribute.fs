namespace Fss

namespace Fss.FssTypes

    [<RequireQualifiedAccess>]
    module Attribute =
        type Attribute =
            | Property
            | Attribute
            | Map
            | Style
            | Class
            | ClassList
            | Id
            | Title
            | Hidden
            | Type
            | Value
            | Checked
            | Placeholder
            | Selected
            | Accept
            | AcceptCharset
            | Action
            | Autocomplete
            | Autofocus
            | Disabled
            | Enctype
            | List
            | Maxlength
            | Minlength
            | Method
            | Multiple
            | Name
            | Novalidate
            | Pattern
            | Readonly
            | Required
            | Size
            | For
            | Form
            | Max
            | Min
            | Step
            | Cols
            | Rows
            | Wrap
            | Href
            | Target
            | Download
            | Hreflang
            | Media
            | Ping
            | Rel
            | Ismap
            | Usemap
            | Shape
            | Coords
            | Src
            | Height
            | Width
            | Alt
            | Autoplay
            | Controls
            | Loop
            | Preload
            | Poster
            | Default
            | Kind
            | Srclang
            | Sandbox
            | Srcdoc
            | Reversed
            | Start
            | Align
            | Colspan
            | Rowspan
            | Headers
            | Scope
            | Accesskey
            | Contenteditable
            | Contextmenu
            | Dir
            | Draggable
            | Dropzone
            | Itemprop
            | Lang
            | Spellcheck
            | Tabindex
            | Cite
            | Datetime
            | Pubdate
            | Manifest

    [<AutoOpen>]
    module attributeHelpers =
        let internal attributeToString (a: Attribute.Attribute) = Fss.Utilities.Helpers.duToKebab a