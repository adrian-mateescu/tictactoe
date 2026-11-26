# tictactoe
Candidate: "Should the game support variable board sizes, such as 4x4 or 5x5?"

Interviewer: "For the purpose of this interview, let’s stick with the standard 3x3 board."

Candidate: "Should the game support both player-vs-player and player-vs-computer modes?"

Interviewer: "Let’s keep it simple and focus only on the player-vs-player mode for now."

Candidate: "What should happen if a player tries to make an invalid move, like selecting an already filled cell?"

Interviewer: "The game should reject the move and inform the player to make another selection."

Candidate: "Should the system maintain a scoreboard across multiple games to track player wins?"

Interviewer: "For now, let's keep the core design focused on a single game. Tracking a scoreboard across multiple games is a good extension to discuss afterward."

Candidate: "How should the user input be handled? Should we take input from the console, or just hardcode a sample game sequence?"

Interviewer: "To keep things focused on the design, you can hardcode a sample sequence in a demo or main method."

Candidate: "Should we track the history of moves to allow features like undo or move replay?"

Interviewer: "That's an interesting feature to consider, but let’s leave it out for now and focus on the core gameplay logic."

Functional Requirements
The game is played on a 3x3 grid.
Two players take alternate turns, identified by markers ‘X’ and ‘O’.
The game should detect and announce the winner.
The game should declare a draw if all cells are filled and no player has won.
The game should reject invalid moves and inform the player.
Moves can be hardcoded in a driver/demo class to simulate gameplay

Non-Functional Requirements
The design should follow object-oriented principles with clear responsibilities and separation of concerns.
The system should be modular and extensible to support future features like larger boards, AI opponent, move history, etc.
The game logic should be testable and easy to maintain.
The system should provide clear console output that reflects the current state of the game board..

fter the requirements are clear, the next step is to identify the core entities that will form the foundation of our design.


2. Identifying Core Entities
How do you go from a list of requirements to actual entities/classes?

The key is to look for nouns in the requirements that have distinct attributes or behaviors. Not every noun becomes a class, but this approach gives you a starting point.

Let's walk through our requirements and identify what needs to exist in our system.

1. The game is played on a 3x3 grid.
The grid is central to everything. We need something to represent it. This gives us our first entity: Board.

But what is a grid made of? Individual squares. Each square can be empty or contain a symbol. This suggests a second entity: Cell. The Board will contain 9 Cells arranged in a 3x3 structure.

Because they have different responsibilities. The Board manages the overall grid structure and operations like "is the board full?" or "place a symbol at position (1,2)". The Cell just holds a single value.

This separation also makes the code cleaner. If we later want to add features like highlighting the winning cells, the Cell class is the natural place for that logic.

2. Two players take alternate turns, identified by markers ‘X’ and ‘O’.
We need to represent players. Each player has a name and an assigned symbol. This gives us the Player entity.

What about the symbols themselves?

We could use strings ("X", "O") or characters, but that's error-prone. What stops someone from creating a player with symbol "Z"?

Using an enum Symbol with values X, O, and EMPTY gives us type safety. The compiler will catch invalid symbols at compile time rather than runtime.

3. The game processes moves and determines game outcomes.
Something needs to coordinate the gameplay: accept moves, validate them, check for wins, switch turns. This orchestrator is our Game entity.

The game also needs to track its current state. Is it still in progress? Did someone win? Is it a draw?

We could use a boolean isGameOver and a winner field, but that gets messy. What if we need to distinguish between "X won" and "O won"?

An enum GameStatus with values IN_PROGRESS, WINNER_X, WINNER_O, and DRAW captures all possibilities cleanly.
Entity	Type	Responsibility
Symbol	Enum	Cell values: X, O, or EMPTY
GameStatus	Enum	Game state: IN_PROGRESS, WINNER_X, WINNER_O, DRAW
Cell	Data Class	Holds a single symbol
Player	Data Class	Holds player name and assigned symbol
Board	Core Class	Manages the 3x3 grid
Game	Core Class	Orchestrates gameplay and win detection


Continu reading at : https://algomaster.io/learn/lld/design-tic-tac-toe
Application in C#
