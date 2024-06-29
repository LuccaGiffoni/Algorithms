# C# Algorithms Repository | Technical Training
Welcome to my **C# Coding Challenges** repository! This project is a collection of coding challenges focused on sharpening skills in C# development, covering various topics from string manipulation to advanced database interactions.

## Overview
This repository contains a series of coding challenges that I've completed and am currently working on. Each challenge is designed to test different aspects of C# programming, including algorithms, data structures, and application design.

## Table of Contents

1. [Challenges Completed](#challenges-completed)
2. [Challenges In Progress](#challenges-in-progress)
3. [Planned Challenges](#planned-challenges)

## Challenges Completed

### Medium-Level Challenges

- **Remove Vowels from a String**
  - **Description**: Removes all vowels from a given string.
  - **Location**: [src/Medium/RemoveVowels.cs](src/Medium/RemoveVowels.cs)
  - **Example Input**: `"Hello World"`
  - **Example Output**: `"Hll Wrld"`

- **Order Numbers by Even and Odd**
  - **Description**: Orders numbers in an array, evens first (ascending), odds last (descending).
  - **Location**: [src/Medium/OrderNumbers.cs](src/Medium/OrderNumbers.cs)
  - **Example Input**: `[1, 12, 90, 87, 345, 67, 98, 100, 124]`
  - **Example Output**: `[12, 90, 98, 100, 124, 345, 87, 67, 1]`

### High-Level Challenges

- **Anagram Grouping**
  - **Description**: Groups a list of strings into anagrams.
  - **Location**: [src/High/AnagramGrouping.cs](src/High/AnagramGrouping.cs)
  - **Example Input**: `["listen", "silent", "enlist", "rat", "tar", "art"]`
  - **Example Output**: `[["listen", "silent", "enlist"], ["rat", "tar", "art"]]`

- **Custom Dependency Injection Container**
  - **Description**: Implements a custom dependency injection container from scratch.
  - **Location**: [src/High/CustomDIContainer.cs](src/High/CustomDIContainer.cs)

### Very High-Level Challenges

- **WorkoutManager API**
  - **Description**: Implements a Workout Manager API using ASP.NET Core, EF Core, and SQLite.
  - **Location**: [src/VeryHigh/WorkoutManagerApi/](src/VeryHigh/WorkoutManagerApi/)
  - **Features**:
    - CRUD operations for `Workout` and `Exercise` entities.
    - API documentation using OpenAPI/Swagger.
  - **Example Input**: 
    - Create Workout: `{ "name": "Cardio Routine", "workoutType": "Cardio", "dayOfTheWeek": 1, "exercises": [{ "name": "Running", "description": "Run for 30 minutes", "sets": 1, "reps": 0, "seconds": 1800 }] }`
  - **Example Output**: 
    - Workout Created: `{ "id": "guid-value", "name": "Cardio Routine", "workoutType": "Cardio", "dayOfTheWeek": 1, "exercises": [{ "id": "guid-value", "name": "Running", "description": "Run for 30 minutes", "sets": 1, "reps": 0, "seconds": 1800 }] }`

## Challenges In Progress
### Medium-Level Challenges

- **Caesar Cipher Encoder/Decoder**
  - **Description**: Encodes and decodes text using the Caesar cipher technique.
  - **Location**: [src/Medium/CaesarCipher.cs](src/Medium/CaesarCipher.cs)
    
### High-Level Challenges

- **Implement Trie Data Structure**
  - **Description**: Implements a Trie data structure for efficient string searching.
  - **Location**: [src/High/TrieDataStructure.cs](src/High/TrieDataStructure.cs)

### Very High-Level Challenges

- **Build a Chatbot API**
  - **Description**: Implements a simple chatbot API using ASP.NET Core and integrates it with a front-end client.
  - **Location**: [src/VeryHigh/ChatbotApi/](src/VeryHigh/ChatbotApi/)

## Planned Challenges

### Medium-Level Challenges

- **Validate Palindrome Permutations**
  - **Description**: Checks if any permutation of a string is a palindrome.
  - **Location**: [src/Medium/ValidatePalindromePermutation.cs](src/Medium/ValidatePalindromePermutation.cs)
  - **Example Input**: `"civic"`
  - **Example Output**: `true`
    
### High-Level Challenges

- **Build a Simple Expression Evaluator**
  - **Description**: Evaluates mathematical expressions from string input.
  - **Location**: [src/High/ExpressionEvaluator.cs](src/High/ExpressionEvaluator.cs)

### Very High-Level Challenges

- **Develop a Task Scheduler API**
  - **Description**: Creates an API to schedule and manage tasks, with recurring task support.
  - **Location**: [src/VeryHigh/TaskSchedulerApi/](src/VeryHigh/TaskSchedulerApi/)
