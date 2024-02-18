# Generic Finite State Machine Unity

## Overview

This repository showcases a generic finite state machine (FSM) implementation in Unity. It includes two scenes, each featuring a separate entity with different behaviors. Both entities inherit from the same state machine manager, demonstrating the flexibility and reusability of the FSM design.

## Scene 01

This scene features a basic player controller setup. The player character is controlled by the user and can move along the x and z axes.

The player has two main states:

- Idle State: In this state, the player is stationary.
- Walk State: When the player moves, it transitions to the walk state and moves in the direction specified by the user input.

## Scene 02

In this scene, an enemy character is set up to patrol a predefined route within the scene.

The enemy has two main states:

- Looking State: In this state, the enemy is looking around.
- Patrolling State: In this state, the enemy follows a predefined patrol route.
