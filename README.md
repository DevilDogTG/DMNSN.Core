# DMNSN.Core

[![.NET 8](https://img.shields.io/badge/.NET-8.0-512BD4?style=flat&logo=.net# Enum descriptions
MyEnum value = MyEnum.SomeValue;
string description = value.Description();
```

## :books: API Referencettps://dotnet.microsoft.com/download/dotnet/8.0)
[![NuGet](https://img.shields.io/nuget/v/DMNSN.Core?style=flat&logo=nuget)](https://www.nuget.org/packages/DMNSN.Core)
[![License](https://img.shields.io/badge/License-OneWeb%20Co.%2C%20Ltd.-blue?style=flat)](#license)

A comprehensive .NET 8 shared library providing essential utilities, extension methods, and configuration helpers for modern .NET applications.

## :bookmark_tabs: Table of Contents

- [Features](#features)
- [Installation](#installation)
- [Quick Start](#quick-start)
- [API Reference](#api-reference)
  - [Extension Methods](#extension-methods)
  - [Configuration](#configuration)
  - [Logging Settings](#logging-settings)
  - [Format Enums](#format-enums)
- [Examples](#examples)
- [Testing](#testing)
- [Contributing](#contributing)
- [Support](#support)
- [License](#license)
- [Authors](#authors)

## :sparkles: Features

### :hammer_and_wrench: Extension Methods
- **String Conversion**: Parse objects to strings with fallback defaults
- **String Manipulation**: Trim strings to specific lengths and extract substrings from the end
- **Boolean Parsing**: Parse various string representations as boolean values (case-insensitive)
- **Enum Utilities**: Extract descriptions and custom attributes from enum values
- **Exception Handling**: Enhanced exception message and stack trace extraction with inner exception support

### :gear: Configuration Utilities
- **Configuration Keys**: Predefined constants for common configuration sections
- **Configuration Files**: Standardized file name constants
- **Logging Settings**: Comprehensive logging configuration with console and file output options

### :calendar: Format Definitions
- **Date Formats**: Predefined date format patterns
- **Time Formats**: Various time representation formats
- **DateTime Formats**: Combined date and time format patterns

### :white_check_mark: Test Coverage
- **Comprehensive Unit Tests**: 82+ tests covering all functionality
- **Edge Case Testing**: Thorough testing of null values, empty strings, and boundary conditions
- **Integration Testing**: Tests for method chaining and combined operations

## :package: Installation

### Package Manager
```powershell
Install-Package DMNSN.Core
```

### .NET CLI
```bash
dotnet add package DMNSN.Core
```

### PackageReference
```xml
<PackageReference Include="DMNSN.Core" Version="8.0.0" />
```

## :rocket: Quick Start

Add the using statement to access extension methods:

```csharp
using DMNSN.Core.Extensions;
using DMNSN.Core.Settings;
using DMNSN.Core.Constraints;
```

### Basic Usage

```csharp
// String conversion with fallback
object value = null;
string result = value.ParseString("default"); // Returns "default"

// Boolean parsing (case-insensitive)
bool isTrue = "YES".ParseBoolean(); // Returns true
bool isFalse = "random".ParseBoolean(); // Returns false

// String manipulation
string text = "Hello World";
string trimmed = text.TrimLength(5); // Returns "Hello"
string lastPart = text.ReverseSubstring(5); // Returns "World"

// Enum descriptions
MyEnum value = MyEnum.SomeValue;
string description = value.Description();
## ?? API Reference

### Extension Methods

#### ConvertExtension (String Operations)

##### `ParseString(object, string)`
Converts any object to its string representation with a fallback default value.
```csharp
public static string ParseString(this object ob, string defaultValue = "")
```

**Examples:**

```csharp
int number = 42;
string result = number.ParseString(); // "42"

object nullValue = null;
string fallback = nullValue.ParseString("N/A"); // "N/A"
```

##### `TrimLength(string, int)`
Trims a string to the specified maximum length.

```csharp
public static string TrimLength(this string s, int maxLength)
```

**Examples:**

```csharp
string longText = "Hello World";
string short = longText.TrimLength(5); // "Hello"
```

##### `ReverseSubstring(string, int)`
Returns a substring containing the specified number of characters from the end.

```csharp
public static string ReverseSubstring(this string s, int count = 1)
```

**Examples:**

```csharp
string text = "Programming";
string last4 = text.ReverseSubstring(4); // "ming"
string lastChar = text.ReverseSubstring(); // "g"
```

#### ConvertExtension (Boolean Operations)

##### `ParseBoolean(string)`
Parses various string representations as boolean values (case-insensitive).

```csharp
public static bool ParseBoolean(this string s)
```

**True Values:** `"true"`, `"yes"`, `"y"`, `"1"` (case-insensitive)  
**False Values:** Everything else, including null, empty, or whitespace

**Examples:**

```csharp
"TRUE".ParseBoolean();    // true
"yes".ParseBoolean();     // true
"Y".ParseBoolean();       // true
"1".ParseBoolean();       // true
"false".ParseBoolean();   // false
"no".ParseBoolean();      // false
"anything".ParseBoolean(); // false
```

#### EnumExtension

##### `Description(Enum)`
Retrieves the description from a `DescriptionAttribute` applied to an enum value.

```csharp
public static string? Description(this Enum value)
```

##### `GetAttribute<TAttribute>(Enum)`
Retrieves a custom attribute from an enum field.

```csharp
public static TAttribute? GetAttribute<TAttribute>(this Enum value) where TAttribute : Attribute
```

#### ExceptionExtension

##### `GetMessage(Exception, bool, string)`
Retrieves exception messages including inner exceptions.

```csharp
public static string GetMessage(this Exception ex, bool getInner = true, string inSeparator = " ===>>> Inner Exception ===>>> ")
```

##### `GetStackTrace(Exception, bool, string)`
Retrieves stack traces including
