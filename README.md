# Toy Robot Simulator

This repository contains my implementation of [Toy Robot Simulator](https://github.com/nandowalter-lm/toy_robot#toy-robot-simulator) coding challenge.

To write `commands` you need to create a `commands.txt` file and place it in the following path (depending if you are building the solution in Debug or Release mode):

```
ToyRobotSimulator.ConsoleApp\bin\Debug\netcoreapp3.0
```

or

```
ToyRobotSimulator.ConsoleApp\bin\Release\netcoreapp3.0
```

## Assumptions

I have implemented an `ErrorReporter` class whose responsability is to send all app exceptions to an `Exception monitoring` tool (like `Sentry`, `Fabric`, or `Rollbar`).

I didn't implement the code for sending the exception because I assumed this is out of scope.

## Runtime analysis

Tha simulator alghoritm has a `O(N)` runtime where `N` is the number of commands.
