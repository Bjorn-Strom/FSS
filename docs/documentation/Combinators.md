## Combinators

Combinators can be used when you want to style something depending on selector relationships.
There are 4 combinators all of them supported by Fss.

If you want even more information about combinators or where these examples come from you can take a look at this [article](https://blog.logrocket.com/what-you-need-to-know-about-css-combinators/)

- ### Descendant (! )
This combinator allows you to select specific selectors within a CSS block.
For example if we want to make all paragraphs within a div be red, we can do the following:

```fsharp
let redParagraphs = fss [ ! Html.P [ Color.red ] ]
div [ ClassName redParagraphs ]
   [
       p [] [ str "Text in a paragraph and therefore red"]
       str "Text outside of paragraph"
       div [] [ p [] [ str "Text in paragraph in div and red" ] ]
   ]
```


- ### Child (!>)
While descendants hits all the selectors within the css block, child will only select direct descendants. I.E one level deep.

So if we copy the same example from above but use the child combinator instead we get:

```fsharp
let childCombinator = fss [ !> Html.P [ Color.red ] ]
div [ ClassName childCombinator ]
   [
       p [] [ str "Text in a paragraph and therefore red"]
       str "Text outside of paragraph"
       div [] [ p [] [ str "Text in paragraph in div and not red" ] ]
   ]
```

- ### Adjacent sibling (!+)
This combinator selects the element directly after the 'main' element.
So if we do:

```fsharp
let directCombinator = fss [ !+ Html.P [ Color.red ] ]
div []
  [
      div [ ClassName directCombinator ] [ p [] [ str "Text in paragraph in div" ] ]
      p [] [ str "Text in a paragraph and after the div with the combinator so is red"]
      p [] [ str "Text in a paragraph but not after div with the combinator so is not red"]
   ]
```

- ### General sibling (!~)
The general sibling combinator is similar to the adjacent one. But instead of selecting only 1 sibling, it selects them all.

```fsharp
let adjacentCombinator = fss [ !+ Html.P [ Color.red ] ]
div []
  [
      div [ ClassName adjacentCombinator ] [ p [] [ str "Text in paragraph in div" ] ]
      p [] [ str "Text in a paragraph and after the div with the combinator so is red"]
      p [] [ str "Text in a paragraph but not after div with the combinator so is not red"]
   ]
```
