# Unity week 2: Formal elements

A project with step-by-step scenes illustrating some of the formal elements of game development in Unity, including: 

* Prefabs for instantiating new objects;
* Colliders for triggering outcomes of actions;
* Coroutines for setting time-based rules.

Text explanations are available 
[here](https://github.com/gamedev-at-ariel/gamedev-5782) in folder 04.

## Cloning
To clone the project, you may need to install git lfs first (if it is not already installed):

    git lfs install 

To clone faster, you can limit the depth to 1 like this:

    git clone --depth=1 https://github.com/<repository-name>.git

When you first open this project, you may not see the text in the score field.
This is because `TextMeshPro` is not in the project.
The Unity Editor should hopefully prompt you to import TextMeshPro;
once you do this, re-open the scenes, and you should be able to see the texts.

## Assignment additions

For the course assignment I implemented the following changes in this project:

1. **Health points system (requirement 4)**  
   - The player no longer dies immediately on the first hit.  
   - The spaceship starts the game with 3 health points.  
   - Every collision with an enemy reduces the health by 1 point.  
   - Health pickups occasionally appear on the screen; collecting them adds health to the player.  
   - The current health is displayed to the player in a clear way.

2. **Shield power-up (requirement 7)**  
   - The shield does not exist on the board at the start of the level.  
   - From time to time a shield icon appears at a random position.  
   - When the player collides with the shield, a circle is drawn around the spaceship.  
   - The color of the circle gradually fades and the shield disappears after 5 seconds.

In addition, I added two original ideas of my own:

3. **Vertical moving laser obstacle**  
   - A vertical laser wall moves up and down on the screen.  
   - Every few seconds the laser “teleports” to a new horizontal position.  
   - There is always one safe gap that the player can pass through, so the player has to time the movement carefully.

4. **Score-based screen clear**  
   - The score is tracked using the existing `NumberField` system.  
   - Whenever the player’s score reaches a multiple of 20 points, all enemies that are currently inside the camera view are destroyed.  
  




## Credits

Programming:
* Maoz Grossman
* Erel Segal-Halevi

Online courses:
* [The Ultimate Guide to Game Development with Unity 2019](https://www.udemy.com/the-ultimate-guide-to-game-development-with-unity/), by Jonathan Weinberger

Graphics:
* [Matt Whitehead](https://ccsearch.creativecommons.org/photos/7fd4a37b-8d1a-4d4c-80a2-4ca4a3839941)
* [Kenney's space kit](https://kenney.nl/assets/space-kit)
* [Ductman's 2D Animated Spacehips](https://assetstore.unity.com/packages/2d/characters/2d-animated-spaceships-96852)
* [Franc from the Noun Project](https://commons.wikimedia.org/w/index.php?curid=64661575)
* [Greek-arrow-animated.gif by Andrikkos is licensed under CC BY-SA 3.0](https://search.creativecommons.org/photos/2db102af-80d0-4ec8-9171-1ac77d2565ce)
