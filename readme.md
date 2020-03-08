<pre>
Battle ship task.

Please clone: https://github.com/ivanpchelnikov/BattleShipTask.git.

The Task

The task is to implement a Battleship state tracking API for a single player that must support the following logic:

• Create a board<br/>
• Add a battleship to the board<br/>
• Take an “attack” at a given position, and report back whether the attack resulted in a hit or a miss. 

The API should not support the entire game, just the state tracker. No graphical interface or persistence layer is required.

1. To create a board: Post <b>localhost:{port}/game </b>
2. To add a ship on the board: Put <b>localhost:{port}/game/{id}/{statX}/{startY}/{endX}/{endY}</b>
    - start of location X,Y should be less end of location X,Y  (0,0) - (4,0) and within boards size 10*10 in range (0-9,0-9)
    - location should be in line horisontaly or verticaly
    - if location intersect existing ship, no ship will be added
3. To attack a ship: Put <b>localhost:{port}/game/attack/{id}/{x}/{y}</b>
    - missed for missing
    - ship for attack succesfull
    - game over. if no ship left.
	
	Sample:
	
	Run a server localhost or use  https://battleship20200308120701.azurewebsites.net
	1. Create a game: 
			Post https://battleship20200308120701.azurewebsites.net/game 
				 - response: 1
	2. Add a ship: 
			Put https://battleship20200308120701.azurewebsites.net/game/1/0/0/0/3
				 - response: Ship was added succesfully to the game Id 1
	3. Attack ship: 
			Put https://battleship20200308120701.azurewebsites.net/game/attack/1/0/0
				- response: Ship 
			Put lhttps://battleship20200308120701.azurewebsites.net/game/attack/1/1/0 
				- response: Missed 
			Put https://battleship20200308120701.azurewebsites.net/game/attack/1/0/1 
				- response: Ship 
			Put https://battleship20200308120701.azurewebsites.net/game/attack/1/0/2 
				- response: Ship 
			Put https://battleship20200308120701.azurewebsites.net/game/attack/1/0/3 
				- response: Congratulation all ships are sinked. Game Over!
</pre>
