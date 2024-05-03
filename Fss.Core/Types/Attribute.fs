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
        | Data of string
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
        | Custom of string
        interface ICssValue with
            member this.StringifyCss() =
                match this with
                | Property  -> "property"
                | Attribute -> "attribute"
                | Map -> "map"
                | Style -> "style"
                | Class -> "class"
                | ClassList -> "class-list"
                | Data label -> $"data-{label}"
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
                | Custom s -> s

    type Case =
        | Sensitive
        | Insensitive

    type AttributeMaster =
        | Normal of Attribute * Rule list
        | Exactly of Attribute * string * Case option * Rule list
        | Contains of Attribute * string * Case option * Rule list
        | ValueOrContinuation of Attribute * string * Case option * Rule list
        | Prefix of Attribute * string * Case option * Rule list
        | Suffix of Attribute * string * Case option * Rule list
        | AtLeastOne of Attribute * string * Case option * Rule list
        interface ICssValue with
            // Used for creating classname
            member this.StringifyCss() =
                match this with
                | Normal (_, rules)
                | Exactly (_,_,_,rules)
                | Contains (_,_,_,rules)
                | ValueOrContinuation (_,_,_,rules)
                | Prefix (_,_,_,rules)
                | Suffix (_,_,_,rules)
                | AtLeastOne (_,_,_,rules)
                    -> stringifyList rules


module internal AttributeHelpers =
    type internal Match =
        | Normal
        | Exactly
        | Contains
        | ValueOrContinuation
        | Prefix
        | Suffix
        | AtLeastOne

    let stringifyAttribute (attribute: Attribute.Attribute) matcher match' case =
        let matcher =
            match matcher with
            | Some matcher when matcher = Exactly -> "="
            | Some matcher when matcher = Contains -> "~="
            | Some matcher when matcher = ValueOrContinuation -> "|="
            | Some matcher when matcher = Prefix -> "^="
            | Some matcher when matcher = Suffix -> "$="
            | Some matcher when matcher = AtLeastOne -> "*="
            | _ -> ""
        let case =
            match case with
            | Some case when case = Attribute.Case.Sensitive -> " s"
            | Some case when case = Attribute.Case.Insensitive -> " i"
            | _ -> ""
        let match' =
            if match' = "" then
                ""
            else
                $"\"{match'}\""

        $"[{stringifyICssValue attribute}{matcher}{match'}{case}]"

[<RequireQualifiedAccess>]
module AttributeClasses =
    type Attribute =
        // Elements with a name of attr
        static member attribute (attribute: Attribute.Attribute, rules: Rule list) =
            (Property.Attribute, Attribute.Normal (attribute, rules))
            |> Rule
        static member attribute (selector: Selector, attribute: Attribute.Attribute, rules: Rule list) =
            (Property.AttributeSelector selector, Attribute.Normal (attribute, rules))
            |> Rule
        // Elements with name of attr and whose value matches excactly  (=)
        static member exactly (attribute: Attribute.Attribute, value: string, case: Attribute.Case option, rules: Rule list) =
            (Property.Attribute, Attribute.AttributeMaster.Exactly (attribute, value, case, rules))
            |> Rule
        static member exactly (selector: Selector, attribute: Attribute.Attribute, value: string, case: Attribute.Case option, rules: Rule list) =
            (Property.AttributeSelector selector, Attribute.AttributeMaster.Exactly (attribute, value, case, rules))
            |> Rule
        // Elements with name of attr and matches any entry in space delimited list (~=)
        static member contains (attribute: Attribute.Attribute, value: string, case: Attribute.Case option, rules: Rule list) =
            (Property.Attribute, Attribute.AttributeMaster.Contains (attribute, value, case, rules))
            |> Rule
        static member contains (selector: Selector, attribute: Attribute.Attribute, value: string, case: Attribute.Case option, rules: Rule list) =
            (Property.AttributeSelector selector, Attribute.AttributeMaster.Contains (attribute, value, case, rules))
            |> Rule
        // Elements with name of attr and whose value contains value or followed by a hyphen (|=)
        static member value_or_continuation (attribute: Attribute.Attribute, value: string, case: Attribute.Case option, rules: Rule list) =
            (Property.Attribute, Attribute.ValueOrContinuation (attribute, value, case, rules))
            |> Rule
        static member value_or_continuation (selector: Selector, attribute: Attribute.Attribute, value: string, case: Attribute.Case option, rules: Rule list) =
            (Property.AttributeSelector selector, Attribute.ValueOrContinuation (attribute, value, case, rules))
            |> Rule
        // Elements with name of attr and whose value is prefixed by value (^=)
        static member prefix (attribute: Attribute.Attribute, value: string, case: Attribute.Case option, rules: Rule list) =
            (Property.Attribute, Attribute.Prefix (attribute, value, case, rules))
            |> Rule
        static member prefix (selector: Selector, attribute: Attribute.Attribute, value: string, case: Attribute.Case option, rules: Rule list) =
            (Property.AttributeSelector selector, Attribute.Prefix (attribute, value, case, rules))
            |> Rule
        // Elements with name of attr and whose value is suffixed by value ($=)
        static member suffix (attribute: Attribute.Attribute, value: string, case: Attribute.Case option, rules: Rule list) =
            (Property.Attribute, Attribute.Suffix (attribute, value, case, rules))
            |> Rule
        static member suffix (selector: Selector, attribute: Attribute.Attribute, value: string, case: Attribute.Case option, rules: Rule list) =
            (Property.AttributeSelector selector, Attribute.Suffix (attribute, value, case, rules))
            |> Rule
        // Elements with name of attr and whose value contains at least one occurence of value (*=)
        static member at_least_one (attribute: Attribute.Attribute, value: string, case: Attribute.Case option, rules: Rule list) =
            (Property.Attribute, Attribute.AtLeastOne (attribute, value, case, rules))
            |> Rule
        static member at_least_one (selector: Selector, attribute: Attribute.Attribute, value: string, case: Attribute.Case option, rules: Rule list) =
            (Property.AttributeSelector selector, Attribute.AtLeastOne (attribute, value, case, rules))
            |> Rule
