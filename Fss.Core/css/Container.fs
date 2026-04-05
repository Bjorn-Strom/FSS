namespace Fss

open Fss.Types

[<AutoOpen>]
module ContainerCss =
    /// Specifies the container type for container queries
    let ContainerType = ContainerClasses.ContainerType(Property.ContainerType)
    /// Specifies the container name for container queries
    let ContainerName = ContainerClasses.ContainerName(Property.ContainerName)
    /// Shorthand for container-name / container-type
    let ContainerShorthand = ContainerClasses.ContainerShorthand(Property.Container)

    type Container =
        /// Query a container by features
        static member query (features: Container.Feature list) (rules: Rule list) =
            (Property.ContainerQuery, Container.ContainerQuery(features, rules))
            |> Rule
        /// Query a named container by features
        static member queryNamed (name: string) (features: Container.Feature list) (rules: Rule list) =
            (Property.ContainerQuery, Container.ContainerQueryNamed(name, features, rules))
            |> Rule
        // Features
        static member Width width = Container.Width width
        static member MinWidth width = Container.MinWidth width
        static member MaxWidth width = Container.MaxWidth width
        static member Height height = Container.Height height
        static member MinHeight height = Container.MinHeight height
        static member MaxHeight height = Container.MaxHeight height
        static member InlineSize size = Container.InlineSize size
        static member MinInlineSize size = Container.MinInlineSize size
        static member MaxInlineSize size = Container.MaxInlineSize size
        static member BlockSize size = Container.BlockSize size
        static member MinBlockSize size = Container.MinBlockSize size
        static member MaxBlockSize size = Container.MaxBlockSize size
        static member AspectRatio ratio = Container.AspectRatio ratio
        static member MinAspectRatio ratio = Container.MinAspectRatio ratio
        static member MaxAspectRatio ratio = Container.MaxAspectRatio ratio
        static member Orientation orientation = Container.Orientation orientation
