## Conditional Styling

If you want to style something conditionally you can use conditional or match expression For example if you've defined a union type for your button sizes that looks like this:

```fsharp
type ButtonSize =
   | Small
   | Big
```

You could have a function that takes this ButtonSize as a parameter and spits out the styling you want.

```fsharp
let buttonStyle buttonType =
  fss  [
           match buttonType with
           | Big ->
               Height' (px 80)
               Width' (px 80)
           | Small ->
               Height' (px 40)
               Width' (px 40)
       ]
button [ ClassName <| buttonStyle Small ] [ str "Small" ]
button [ ClassName <| buttonStyle Big ] [ str "Big" ]
```

Which results in the following: