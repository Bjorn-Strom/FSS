### Whats new in 2.0?

- Changed Css properties from PascalCase to camelCase.
    - This was done to more easily distinguish between the properties and constructors and hopefully make Fss more pleasing to both use and read.
- Moved types out to a separate namespace `FssTypes`
    - An annoyance I've had while using Fss is the messy namespace. Part of that comes from all the types. Hopefully moving them out will make it a better experience.
    - Previously you had to write `TextDecorationTypes.`
- Added feliz