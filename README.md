# Formulas

A Collection of C# formulas for the NAVEX IRM platform.

## Formula Dependencies

A set of inter-dependent formulas that together create a solution should be grouped together into a top level folder.

## File Naming and Formatting

All formula examples should be created in the repository must end with a .cs file extension and use the following structure replacing the text inside the brackets '[&nbsp;]' with information specific to the formula being described.

```csharp
// Recalculation Interval: [One Time | Recurring]
// Dependencies: [List any fields or formulas that are dependent on this field or that this field is dependent on. If the dependency is to another formula in this repository include the URL to the formula.]

// Purpose: [Why is this formula needed? What problem is being solved?]

// Formula Field Configuration:
//   Type: [Text | Numeric | Date | Yes-No]
//   Alias: [Any | Name to use if this is a dependency on another formula example or is a self-referencing formula.]
//   [Field attribute]: [Field Attribute Value]

// Known Issues / Hard-Coded Values: [List any known issues or explanations for any hard-coded values.]

// Formula Description: [Describe how the formula works.]

String example = "[formula code. Use comments only where necessary to describe formula functions or logic that his not obvious]";
return example;

// Notes: [Notes about any alternate uses, possible variations when using the formula or other information best explained after reviewing the formula code.]
```
