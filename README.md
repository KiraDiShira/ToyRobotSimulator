# Toy Robot Simulator

This repository contains my implementation of [Toy Robot Simulator](https://github.com/nandowalter-lm/toy_robot#toy-robot-simulator) coding challenge.

## Assumptions

I have implemented an `ErrorReporter` class whose responsability is to send all app exceptions to an `Exception monitoring` tool (like `Sentry`, `Fabric`, or `Rollbar`).

I didn't implement the code for sending the exception because I assume this is out of scope.

## Runtime analysis

Tha simulator alghoritm has a `O(N)` runtime where `N` is the number of commands.
