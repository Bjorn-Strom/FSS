## Labels

Fss provides a custom CSS property called label which appends a string to a classname.
This is useful when you want to make a classname slightly more readable or if you encounter a classname collision.

```fsharp
let styleWithoutLabel = fss [ Color.red ]
let styleWithLabel = fss [ Color.hotPink; Label "HotPinkLabel" ]
div [ ClassName styleWithoutLabel ] [ str styleWithoutLabel ]
div [ ClassName styleWithLabel ] [ str styleWithLabel ]
```

<example/>
