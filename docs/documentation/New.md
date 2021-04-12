## Whats new in 2.0?

There are some breaking changes unfortunately.
Hopefully they steer the project in a better direction. Below is an overview of these changes.
They were made based on feedback from users as well as annoyances I myself had while using Fss.

### The time for camels
It wasn't always easy to distinguish between the CSS properties, types and constructors.
This led to Fss being more unreadable than I had wanted.
In order to alleviate this all CSS properties have been changed from using PascalCase to camelCase.
Hopefully make Fss more pleasing to both use and read.

So where you used to write:
```fsharp
AnimationTimingFunction.EaseInOut
```
You now have to write:
```fsharp
AnimationTimingFunction.easeInOut
```

### Why are there so many types?
An annoyance I've had while using (and making) Fss is the messy namespace.
Not only has this been a long standing issue I was also not sure of how I wanted it to be.
The solution is another namespace `FssTypes`.
This namespace is in the `Fss` namespace. So opening just `Fss` will no longer bombard you with types.
If you need to access the types now either open the `FssTypes` namespace as well or access it with a qualifier.

### A KB here a KB there
I also worked hard on reducing the final bundle size of Fss.
By doing the above changes I was also able to consolidate and fix up some parts of the code base.
This allowed me to remove a little over 100 kb from the final bundle.
While it might not seem like much, every little bit helps. Hopefully even more reductions in size can be made in the future.