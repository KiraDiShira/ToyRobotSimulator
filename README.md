# Toy Robot Simulator

This repository contains my implementation of [Toy Robot Simulator](https://github.com/nandowalter-lm/toy_robot#toy-robot-simulator) coding challenge.

## How to insert commands

```
git clone https://github.com/KiraDiShira/ToyRobotSimulator.git
cd ToyRobotSimulator/ToyRobotSimulator.ConsoleApp/
dotnet restore
dotnet build --configuration release
dotnet run 
```
To write `commands` you need to create a `commands.txt` file and place it in the following path (depending if you are building the solution in Debug or Release mode):

```
ToyRobotSimulator.ConsoleApp\bin\Debug\netcoreapp3.0
```

or

```
ToyRobotSimulator.ConsoleApp\bin\Release\netcoreapp3.0
```
As an example, I have attached a `command.txt` file in the root of this repository.

## Test project

The solution has a `ToyRobotSimulator.Fixtures` project which includes 63 unit tests.

## Assumptions

I have implemented an `ErrorReporter` class whose responsability is to send all app exceptions to an `Exception monitoring` tool (like `Sentry`, `Fabric`, or `Rollbar`).

I didn't implement the code for sending the exception because I assumed this is out of scope.

## Runtime analysis

Tha simulator algorithm has a `O(N)` runtime where `N` is the number of commands.
