namespace Fss

open Fss.Types

[<AutoOpen>]
module Attribute =
    type Attr =
      // [title] { }
      static member Has (attribute: Attribute.Attribute, rules: Rule list) =
          AttributeClasses.Attribute.attribute(attribute, rules)
      // div[title] { }
      static member Has (selector: Selector, attribute: Attribute.Attribute, rules: Rule list) =
          AttributeClasses.Attribute.attribute(selector, attribute, rules)

    type MatchAttr =
      // [title="foo"] { }
      static member Exactly (attribute: Attribute.Attribute, value: string, rules: Rule list) =
          AttributeClasses.Attribute.exactly(attribute, value, None, rules)
      // [title~="foo" i] { }
      static member Exactly (attribute: Attribute.Attribute, value: string, case: Attribute.Case, rules: Rule list) =
          AttributeClasses.Attribute.exactly(attribute, value, Some case, rules)
      // div[title="foo"] { }
      static member Exactly (selector: Selector, attribute: Attribute.Attribute, value: string, rules: Rule list) =
          AttributeClasses.Attribute.exactly(selector, attribute, value, None, rules)
      // div[title="foo" i] { }
      static member Exactly (selector: Selector, attribute: Attribute.Attribute, value: string, case: Attribute.Case, rules: Rule list) =
          AttributeClasses.Attribute.exactly(selector, attribute, value, Some case, rules)

      // [title~="foo"] { }
      static member Contains (attribute: Attribute.Attribute, value: string, rules: Rule list) =
          AttributeClasses.Attribute.contains(attribute, value, None, rules)
      // [title~="foo" i] { }
      static member Contains (attribute: Attribute.Attribute, value: string, case: Attribute.Case, rules: Rule list) =
          AttributeClasses.Attribute.contains(attribute, value, Some case, rules)

      // div[title~="foo"] { }
      static member Contains (selector: Selector, attribute: Attribute.Attribute, value: string, rules: Rule list) =
          AttributeClasses.Attribute.contains(selector, attribute, value, None, rules)
      // div[title~="foo" i] { }
      static member Contains (selector: Selector, attribute: Attribute.Attribute, value: string, case: Attribute.Case, rules: Rule list) =
          AttributeClasses.Attribute.contains(selector, attribute, value, Some case, rules)

      // [title|="foo"] { }
      static member ValueOrContinuation (attribute: Attribute.Attribute, value: string, rules: Rule list) =
          AttributeClasses.Attribute.value_or_continuation(attribute, value, None, rules)
      // [title|="foo" i] { }
      static member ValueOrContinuation (attribute: Attribute.Attribute, value: string, case: Attribute.Case, rules: Rule list) =
          AttributeClasses.Attribute.value_or_continuation(attribute, value, Some case, rules)
      // div[title|="foo"] { }
      static member ValueOrContinuation (selector: Selector, attribute: Attribute.Attribute, value: string, rules: Rule list) =
          AttributeClasses.Attribute.value_or_continuation(selector, attribute, value, None, rules)
      // div[title|="foo" i] { }
      static member ValueOrContinuation (selector: Selector, attribute: Attribute.Attribute, value: string, case: Attribute.Case, rules: Rule list) =
          AttributeClasses.Attribute.value_or_continuation(selector, attribute, value, Some case, rules)

      // [title^="foo"] { }
      static member Prefix (attribute: Attribute.Attribute, value: string, rules: Rule list) =
          AttributeClasses.Attribute.prefix(attribute, value, None, rules)
      // [title^="foo" i] { }
      static member Prefix (attribute: Attribute.Attribute, value: string, case: Attribute.Case, rules: Rule list) =
          AttributeClasses.Attribute.prefix(attribute, value, Some case, rules)
      // div[title^="foo"] { }
      static member Prefix (selector: Selector, attribute: Attribute.Attribute, value: string, rules: Rule list) =
          AttributeClasses.Attribute.prefix(selector, attribute, value, None, rules)
      // div[title^="foo" i] { }
      static member Prefix (selector: Selector, attribute: Attribute.Attribute, value: string, case: Attribute.Case, rules: Rule list) =
          AttributeClasses.Attribute.prefix(selector, attribute, value, Some case, rules)

      // [title$="foo"] { }
      static member Suffix (attribute: Attribute.Attribute, value: string, rules: Rule list) =
          AttributeClasses.Attribute.suffix(attribute, value, None, rules)
      // [title$="foo" i] { }
      static member Suffix (attribute: Attribute.Attribute, value: string, case: Attribute.Case, rules: Rule list) =
          AttributeClasses.Attribute.suffix(attribute, value, Some case, rules)
      // div[title$="foo"] { }
      static member Suffix (selector: Selector, attribute: Attribute.Attribute, value: string, rules: Rule list) =
          AttributeClasses.Attribute.suffix(selector, attribute, value, None, rules)
      // div[title$="foo" i] { }
      static member Suffix (selector: Selector, attribute: Attribute.Attribute, value: string, case: Attribute.Case, rules: Rule list) =
          AttributeClasses.Attribute.suffix(selector, attribute, value, Some case, rules)

      // [title*="foo"] { }
      static member AtLeastOne (attribute: Attribute.Attribute, value: string, rules: Rule list) =
          AttributeClasses.Attribute.at_least_one(attribute, value, None, rules)
      // [title*="foo" i] { }
      static member AtLeastOne (attribute: Attribute.Attribute, value: string, case: Attribute.Case, rules: Rule list) =
          AttributeClasses.Attribute.at_least_one(attribute, value, Some case, rules)
      // div[title*="foo"] { }
      static member AtLeastOne (selector: Selector, attribute: Attribute.Attribute, value: string, rules: Rule list) =
          AttributeClasses.Attribute.at_least_one(selector, attribute, value, None, rules)
      // div[title*="foo" i] { }
      static member AtLeastOne (selector: Selector, attribute: Attribute.Attribute, value: string, case: Attribute.Case, rules: Rule list) =
          AttributeClasses.Attribute.at_least_one(selector, attribute, value, Some case, rules)
