namespace Fss

namespace Fss.Types
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
            interface ICssValue with
                member this.StringifyCss() =
                    match this with
                    | Property  -> "property"
                    | Attribute -> "attribute"
                    | Map -> "map"
                    | Style -> "style"
                    | Class -> "class"
                    | ClassList -> "class-list"
                    | Id -> "id"
                    | Title -> "title"
                    | Hidden -> "hidden"
                    | Type -> "type"
                    | Value -> "value"
                    | Checked -> "checked"
                    | Placeholder -> "placeholder"
                    | Selected -> "selected"
                    | Accept -> "accept"
                    | AcceptCharset -> "accept-charset"
                    | Action -> "action"
                    | Autocomplete -> "autocomplete"
                    | Autofocus -> "autofocus"
                    | Disabled -> "disabled"
                    | Enctype -> "enctype"
                    | List -> "list"
                    | Maxlength -> "maxlength"
                    | Minlength -> "minlength"
                    | Method -> "method"
                    | Multiple -> "multiple"
                    | Name -> "name"
                    | Novalidate -> "novalidate"
                    | Pattern -> "pattern"
                    | Readonly -> "readonly"
                    | Required -> "required"
                    | Size -> "size"
                    | For -> "for"
                    | Form -> "form"
                    | Max -> "max"
                    | Min -> "min"
                    | Step -> "step"
                    | Cols -> "cols"
                    | Rows -> "rows"
                    | Wrap -> "wrap"
                    | Href -> "href"
                    | Target -> "target"
                    | Download -> "download"
                    | Hreflang -> "hreflang"
                    | Media -> "media"
                    | Ping -> "ping"
                    | Rel -> "rel"
                    | Ismap -> "ismap"
                    | Usemap -> "usemap"
                    | Shape -> "shape"
                    | Coords -> "coords"
                    | Src -> "src"
                    | Height -> "height"
                    | Width -> "width"
                    | Alt -> "alt"
                    | Autoplay -> "autoplay"
                    | Controls -> "controls"
                    | Loop -> "loop"
                    | Preload -> "preload"
                    | Poster -> "poster"
                    | Default -> "default"
                    | Kind -> "kind"
                    | Srclang -> "srclang"
                    | Sandbox -> "sandbox"
                    | Srcdoc -> "srcdoc"
                    | Reversed -> "reversed"
                    | Start -> "start"
                    | Align -> "align"
                    | Colspan -> "colspan"
                    | Rowspan -> "rowspan"
                    | Headers -> "headers"
                    | Scope -> "scope"
                    | Accesskey -> "accesskey"
                    | Contenteditable -> "contenteditable"
                    | Contextmenu -> "contextmenu"
                    | Dir -> "dir"
                    | Draggable -> "draggable"
                    | Dropzone -> "dropzone"
                    | Itemprop -> "itemprop"
                    | Lang -> "lang"
                    | Spellcheck -> "spellcheck"
                    | Tabindex -> "tabindex"
                    | Cite -> "cite"
                    | Datetime -> "datetime"
                    | Pubdate -> "pubdate"
                    | Manifest -> "manifest"