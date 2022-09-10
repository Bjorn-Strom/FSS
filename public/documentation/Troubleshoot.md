## Troubleshooting

### A classname links to the wrong styles
This could be an issue with the hashing function.
Try to use the `Label` property to append some text to the end of your classname and see if that works.

If you do fint a hash collision I would very much like to hear about it!

### A property I like is missing, what do I do?
Make a PR or an issue and I will take a look at it.

If you need something right now then use the escape hatch function
```fsharp
fss [
    custom "border" "red"
]
```
