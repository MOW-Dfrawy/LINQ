# LINQ Queries in C#

This project demonstrates the use of **LINQ (Language Integrated Query)** in C# to perform different data operations on collections and databases.  
It includes examples of common LINQ queries such as filtering, sorting, grouping, and selecting data.

## 🚀 Features

- Using LINQ with C#
- Filtering data with `Where`
- Sorting data with `OrderBy` and `OrderByDescending`
- Selecting specific fields with `Select`
- Grouping data using `GroupBy`
- Basic query syntax and method syntax examples

## 🛠 Tech Stack

- C#
- .NET
- LINQ
- Visual Studio

## 📌 Example LINQ Queries

### Filter Data
```csharp
var result = students.Where(s => s.Age > 20);
