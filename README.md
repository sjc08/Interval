# Interval

[![NuGet](https://img.shields.io/nuget/v/Asjc.Interval)](https://www.nuget.org/packages/Asjc.Interval/)

Handle intervals easily.

## Features

✅ Generic interval support (int, double, DateTime...)

✅ Configurable inclusive/exclusive boundaries

✅ Infinite interval support (±∞)

✅ Nullable boundaries handling

✅ Clean string representation

## Usage

```csharp
// Create intervals
var intOpen = new Interval<int>(0, 1, startInclusive: false);
var dateRange = new Interval<DateTime>(new(2024, 1, 1), new(2024, 12, 31));
var infiniteRight = new Interval<double>(3.14, null);

// Check containment
intOpen.Contains(0);  // false
dateRange.Contains(new DateTime(2024, 10, 1)); // true

// String representation
infiniteRight.ToString(); // [3.14, +∞)
```

## Credits

- Icon from https://www.iconfinder.com/icons/765058