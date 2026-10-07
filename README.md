# EduWise

A learning companion concept built for my IIE Diploma in IT in Software Development, exploring how to help students keep track of modules, deadlines and grades. Rather than forcing Java and C# into a single awkward app, I built it as **two small, independent pieces** that explore the same idea on two different platforms, which is closer to how real teams sometimes prototype an idea more than once before settling on one stack.

## EduWise Tracker (Java), in the java/ folder

A console app that lets you:
- Add modules with a deadline and (optional) grade
- View everything you've added
- **Generate an HTML report** (`report.html`) of your modules, which you can open directly in a browser. This is where Java and HTML connect, because the Java program writes real HTML as its output.

Data is saved to `modules.txt` so it's still there next time you run it.

### Running it

You need a Java JDK installed (Java 17 or newer is fine).

```
cd java
javac EduWiseTracker.java
java EduWiseTracker
```

Follow the on-screen menu. Choose option 3 at any point to generate `report.html`, then open that file in any browser.

## EduWise Companion (C#), in the main folder (Program.cs and EduWiseCompanion.csproj)

A separate console app that explores the same deadline-tracking idea in C#:
- Add a deadline with a due date
- View all deadlines sorted soonest-first, with overdue ones clearly flagged

Data is saved to `deadlines.txt`.

### Running it

You need the .NET SDK installed (.NET 8 or newer).

Run this from the main folder of the repository, next to `Program.cs`:

```
dotnet run
```

## Why two separate apps

Java and C# aren't normally combined in one running application: they're different platforms with different runtimes. Rather than fake a connection between them, EduWise is presented honestly as two small prototypes of the same core idea, built to compare how the same problem feels to solve in each language. The Java side also demonstrates HTML generation as real output, not just a static page.
