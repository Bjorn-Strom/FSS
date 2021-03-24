namespace Fss

namespace Fss.FssTypes
    [<RequireQualifiedAccess>]
    module Cursor =
        type Cursor =
            | Default
            | ContextMenu
            | Help
            | Pointer
            | Progress
            | Wait
            | Cell
            | Crosshair
            | Text
            | VerticalText
            | Alias
            | Copy
            | Move
            | NoDrop
            | NotAllowed
            | AllScroll
            | ColResize
            | RowResize
            | NResize
            | EResize
            | SResize
            | WResize
            | NsResize
            | EwResize
            | NeResize
            | NwResize
            | SeResize
            | SwResize
            | NeswResize
            | NwseResize
            interface ICursor

