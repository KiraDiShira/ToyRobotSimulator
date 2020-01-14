# Toy Robot Simulator

This repository contains my implementation of [Toy Robot Simulator](https://github.com/nandowalter-lm/toy_robot#toy-robot-simulator) coding challenge.

## How to launch the app

```
git clone https://github.com/KiraDiShira/ToyRobotSimulator.git
cd ToyRobotSimulator/ToyRobotSimulator.ConsoleApp/
dotnet restore
dotnet build --configuration release
dotnet run 
```

## How to insert commands

If you don't launch the app you need to build the project:

```
git clone https://github.com/KiraDiShira/ToyRobotSimulator.git
cd ToyRobotSimulator/ToyRobotSimulator.ConsoleApp/
dotnet restore
dotnet build --configuration release
```

Than you can edit a `command.txt` file in `ToyRobotSimulator\ToyRobotSimulator.ConsoleApp\bin\Release\netcoreapp3.0\Resources` path.

## Test project

The solution has a `ToyRobotSimulator.Fixtures` project which includes 63 unit tests.

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
