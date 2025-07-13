# Mastermind Game 
A simple and fun terminal-based game built in C#.
Use logic and deduction to guess a secret 4-digit code within a limited number of attempts.
Supports custom code and attempt count via command-line flags.

##How the Game Works :
Program.Main
  └── Parses -c and -t from terminal
  └── new Game(code, attempts)
        └── new SecretCode(code)
  └── game.Start()
        └── Loop for attempts
              └── Ask for guess
              └── Validate guess (SecretCode.IsValidGuess)
              └── Compare to code (count correct/misplaced)
              └── Give feedback
              └── End on win or lose

## HOW THE CODE WORK :
###1-Program Class:
The entry point of the game.
Reads terminal arguments:
-c for custom secret code
-t for number of attempts

Creates a Game object and starts the game.

###2-Game Class :
Initializes the game with a secret code and max attempts.
Creates a new SecretCode object using the given code (or random if not provided).

Method : Start() :
Runs the main gameplay loop.
For each attempt:
 -Prompts the player for input.

Validates the input with SecretCode.IsValidGuess().

Compares the guess to the secret code:

 -Counts well-placed and misplaced digits.

 -Displays feedback.

Ends the game when:

The player cracks the code (4 well-placed).
Attempts run out.

###3-SecretCode Class :
-tores a custom code or generates a random 4-digit code from digits 0–8 with no repeats.

Method: GenerateRandomCode() :
-Randomly creates a 4-digit secret code with no repeated digits from 0–8.

Method: IsValidGuess(string guess) :
nsures the player's guess:
 -Is exactly 4 characters
 -Contains only digits between 0–8
 -Has no repeated digits

              

              
