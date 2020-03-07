Battle ship task.

Please clone: https://github.com/ivanpchelnikov/BattleShipTask.git.

The Task

The task is to implement a Battleship state tracking API for a single player that must support the following logic:

• Create a board  • Add a battleship to the board 

• Take an “attack” at a given position, and report back whether the attack
resulted in a hit or a miss. 

The API should not support the entire game, just the state tracker. No graphical interface or persistence layer is required.

1. To create a board: Post localhost:{port}/game 
2. To add a ship on the board: Put localhost:{port}/game/{id}/{statX}/{startY}/{endX}/{endY}/
    - start of location X,Y should be less end of location X,Y  (0,0) - (4,0) and within boards size 10*10 in range (0-9,0-9)
    - location should be in line horisontaly or verticaly
    - if location intersect existing ship, no ship will be added
3. To attack a ship: Put localhost:{port}/game/{id}/{x}/{y}
    - missed - missing
    - ship - attack succesfull
    - sinked  - no ship left game over.
