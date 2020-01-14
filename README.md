# Toy Robot Simulator

This repository contains my implementation of [Toy Robot Simulator](https://github.com/nandowalter-lm/toy_robot#toy-robot-simulator) coding challenge.

## How to launch the app

As an example in the root of this repository there is a `commands.txt` file that can be edited to insert the commands.

```
git clone https://github.com/KiraDiShira/ToyRobotSimulator.git
cd ToyRobotSimulator/ToyRobotSimulator.ConsoleApp/
dotnet restore
dotnet build --configuration release
```

Copy the `commands.txt` file into the path:

```
ToyRobotSimulator\ToyRobotSimulator.ConsoleApp\bin\Release\netcoreapp3.0\
```

Finally:

```
dotnet run 
```

## Test project

The solution has a `ToyRobotSimulator.Fixtures` project which includes 62 unit tests.

To launch all tests:

```
cd ToyRobotSimulator/ToyRobotSimulator.Fixtures/
dotnet test
```

## Assumptions

I have implemented an `ErrorReporter` class whose responsability is to send all app exceptions to an `Exception monitoring` tool (like `Sentry`, `Fabric`, or `Rollbar`).

I didn't implement the code to send the exception because I assumed this is out of scope.

## Runtime analysis

Tha simulator algorithm has a `O(N)` runtime where `N` is the number of commands.
