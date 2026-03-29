# Project - Snake

Text taget från Canvas


Snake
The task is to implement a two player version of the classical Snake game. You can either solve this on Windows in Visual Studio using the Windows Forms Designer or programmatically using Visual Studio on Linux. Windows Forms is unfortunately not working on Mac since 10.15.

In Snake you control a snake on a 2D surface. The snake constantly moves in one direction, which can be changed using the keyboard. On the surface snake food spawns at random locations at random time intervals. The goal is to eat as much food as possible without colliding with yourself or the other snakes. The challenge increases as each food item consumed increases the length of the snake. See, e.g, 
The Perfect Snake GameLinks to an external site.

 

Goal of the project
Since this is a course in object oriented programming the design of your solutions is as important as the implementation. Show the design in the form of a class diagram to the assistants and discuss your ideas with them, preferably before you spend a lot of time implementing. The solution should make (sane) use of Windows Forms for the game and user interface. Apart from being playable there are no demands on the graphical quality of the game.

The project is split into two parts: the core game where you work together in groups of 2-3 people, and an individual extension to the game. The core game provides the basis for the extension. The extension replaces the project report and the oral presentation and provides you with an opportunity to show that you have been part of the development of the core game and understand your solution. You are not allowed to cooperate when implementing the extension.

The core game
The picture below shows the most basic 2-player version of the game and forms the core of the project.


Players
The core game should support up to two players. The number of players should be selectable before starting a new game. My suggestion is that player one is controlled by w, a, s, d and player two is controlled by i, j, k, l.

Score
Each player has a score. The player with the highest score at the end of the game wins. The game ends when all players have died.

Food
The game should have several types of food. The following are the required types, but feel free to add food of your own choice.

standard food worth 1 point that increases the length of the snake by 1
valuable food worth 5 points that increases the length of the snake by 2
diet food worth 1 point that decreases the length of the snake by 1
Dying
The game ends when all players are dead. A player dies when colliding with himself or another player. A collision with another snake awards the hit snake 5 points.

