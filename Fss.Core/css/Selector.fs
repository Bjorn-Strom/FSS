namespace Fss

[<AutoOpen>]
module Selector =
    type Selector =
        static member Tag tag = Fss.Types.Selector.Tag tag
        static member Id id = Fss.Types.Selector.Id id
        static member Class class' = Fss.Types.Selector.Class class'
