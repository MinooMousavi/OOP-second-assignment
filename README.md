# Tundra Animal Simulation

A **C# object-oriented simulation** of predator-prey dynamics in the tundra ecosystem. Developed using **Visual Studio**.

## Project Overview

This simulation models colonies of predators and prey, where population changes in one colony affect others. The program reads colony data from a text file and simulates interactions turn by turn until prey populations either go extinct or quadruple.  

### Species Modeled

- **Predators:** Snowy owl, Arctic fox, Wolf  
- **Prey:** Lemming, Arctic hare, Gopher  

### Key Mechanics

- Prey populations grow according to species-specific rules and decrease when attacked by predators.  
- Predator reproduction depends on prey availability and occurs periodically.  
- Prey colonies may decrease or disperse if their numbers are too low or too high.  
- Predators select prey colonies randomly each turn; starvation reduces predator numbers.  
- Each colony has a name, species, and starting population, all read from an input file.  
- The simulation prints the state of each colony every turn.  

### Features

- Fully object-oriented design using classes, inheritance, and encapsulation.  
- Dynamic interaction between predator and prey colonies based on ecological rules.  
- File input for colony initialization and turn-based simulation output.  

## Technologies

- **Language:** C#  
- **IDE:** Visual Studio  
- **Paradigm:** Object-Oriented Programming  

## Installation

1. Clone the repository:

```bash
git clone https://github.com/your-username/tundra-animal-simulation.git
