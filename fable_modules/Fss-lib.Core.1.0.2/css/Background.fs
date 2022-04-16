namespace Fss

open Fss.Types

[<AutoOpen>]
module Background =
    /// Specifies how an element's background extends.
    let BackgroundClip =
        BackgroundClasses.BackgroundClip(Property.BackgroundClip)
    /// Specifies a backgrounds origin
    let BackgroundOrigin =
        BackgroundClasses.BackgroundOrigin(Property.BackgroundOrigin)
    /// Specifies how background is repeated.
    let BackgroundRepeat =
        BackgroundClasses.BackgroundRepeat(Property.BackgroundRepeat)
    /// Specifies size of background.
    let BackgroundSize =
        BackgroundClasses.BackgroundSize(Property.BackgroundSize)
    /// Specifies how background is fixed within viewport.
    let BackgroundAttachment =
        BackgroundClasses.BackgroundAttachment(Property.BackgroundAttachment)
    /// Specifies the background color.
    let BackgroundColor =
        BackgroundClasses.BackgroundColor(Property.BackgroundColor)
    /// Draws background image on element.
    let BackgroundImage =
        BackgroundClasses.BackgroundImage(Property.BackgroundImage)
    /// Specifies the position of a background.
    let BackgroundPosition =
        BackgroundClasses.BackgroundPosition(Property.BackgroundPosition)
    /// Specifies how an elements background image should interact with its background color.
    let BackgroundBlendMode =
        BackgroundClasses.BackgroundBlendMode(Property.BackgroundBlendMode)
    /// Specifies how an element is blended with backdrop.
    let Isolation =
        BackgroundClasses.Isolation(Property.Isolation)
    /// Specifies how an element should be rendered across multiple lines
    let BoxDecorationBreak =
        BackgroundClasses.BoxDecorationBreak(Property.BoxDecorationBreak)
