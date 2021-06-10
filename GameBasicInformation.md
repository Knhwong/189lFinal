# Game Basic Information #

## Summary ##

Cayde was just a simple man living with his best friend, a dog named Duke. One day, Cayde came home to find his house destroyed and his dog missing. See, Cayde is simple, but he is more than just a normal man. Cayde is the master of counter-attacking. Cayde went to his basement and dug out his old, trusty shield. The enemies are ahead, and Cayde will get his dog back at all costs. The player will play as the character Cayde and step on the path of making through enemies and rescuing his best friend, Duke.

## Gameplay Explanation ##

The control of this game is very simple. There are four buttons to press in total. The "a" key moves the character left. The "d" key moves the character right. The "space" key will make the character, and the left mouse click will hold up the shield. The special skil that Cayde has it to reflect whatever shot at him if he block the projectile right before it hits the shield. Thus, to defeat enemies, player will need to block attacks when necessary. Holding down the shield will also block the attacks, but the shield will not last long. Once it is broken, it requies a few seconds before getting repaired.

How the game should be played is depend on the players. If the player is confident with his/her movement, then he/she can try to douge all the projectiles and run to the end. Of course, the other way is to work with the shield. The player can work with the shield repair cool down and block all the attacks, or he/she can master the skill of counter-attacking. The play style is quite free.

# Main Roles #

Your goal is to relate the work of your role and sub-role in terms of the content of the course. Please look at the role sections below for specific instructions for each role.

Below is a template for you to highlight items of your work. These provide the evidence needed for your work to be evaluated. Try to have at least 4 such descriptions. They will be assessed on the quality of the underlying system and how they are linked to course content. 

*Short Description* - Long description of your work item that includes how it is relevant to topics discussed in class. [link to evidence in your repository](https://github.com/dr-jam/ECS189L/edit/project-description/ProjectDocumentTemplate.md)

Here is an example:  
*Procedural Terrain* - The background of the game consists of procedurally-generated terrain that is produced with Perlin noise. This terrain can be modified by the game at run-time via a call to its script methods. The intent is to allow the player to modify the terrain. This system is based on the component design pattern and the procedural content generation portions of the course. [The PCG terrain generation script](https://github.com/dr-jam/CameraControlExercise/blob/513b927e87fc686fe627bf7d4ff6ff841cf34e9f/Obscura/Assets/Scripts/TerrainGenerator.cs#L6).

You should replay any **bold text** with your relevant information. Liberally use the template when necessary and appropriate.

**Yizhen Liu** - 

*User Interface* -
All necessary UI in the game including menu, health bar, logo etc. I took the inspirations from both exercise 3 and 4.

*Trailer* -
My job is range from scripting to video-editing. I learned from the professor's examples of successful game trailers and promotions.

*Press Kit* (Collab with Dylan Long) -
The press kit demonstrates the overall info for our game. It is essential and also serious for the publishers.

*Final Pollishing* -
Find and fix bugs. 

**Ricardo Sun** - 

*Shield Mechanics* (Collab with Kin Hei Wong) -
The shield works in two ways and should difference between a normal and a perfect block. This also corresponds to the shield breaking from too many hits and repairing after a few seconds.

*User Input* (Collab with Dylan Long) -
The user input are accepted and connected to the player movenment, including jumping, moving on x-axis, and holding/unholding shield.  
This also follows the command pattern design. [The Command Pattern script](https://github.com/Knhwong/189lFinal/blob/f8d61aaf0e691c01eb64f626d68a0e7e1d1a187c/Reflect/Assets/Scripts/PlayerCommands/IPlayerCommand.cs)

*Character Animation* (Collab with Grace Sun)
Finding the player and enemy characters and set the logic for playing the correct animations when idling, jumping, walking, injured, and dead.

*Audio* -
Find and implement sound effects for player movement, shield actions, projectiles, enemy interacitons, as well as the back ground music.

*Final Pollishing* -
Pollish the game and fixed a few bugs involving moving into walls.

**Grace Sun** - 

*Background Design* -
Designed three levels that unit with each other. 

*Character Design* (Collab with Ricardo) -
Designed and chose the right figure design for the main charater. Draw the sheild that can counter attack the bullet.

*Character Animation* (Collab with Ricardo) -
Implemented the animation of the main character that is able to act different with different movement.

*Enemy Design* -
Designed and chose the right figure design for enemies that shoot balls to the main charater.

**Kin Hei Wong** - 

*Projectile Motion & Enemy* (Collab with Dylan Long)
The main enemies of this game fire constant projectiles at the player.
This is implemented via the Factory Design pattern portion of the course along with the Component Design Pattern.

*Scene Transition & Minor UI* (Collab with Dylan Long)
Added Scene Transition (ExitScene) & added HP Elements.
Adherence to Unity's Component Design Pattern as opposed to Global Controller.

*Preliminary Shield Mechanics* (Collab with Ricardo)
Foundational Shield Mechanics (Taking Damage, Rendering)

*General Polishing & Foundations*
Created the base architecture (now mostly overwritten) along with most prefabs, general polishing of other code and game coherence.

*TileMap & Level Design*
Implementation of TileMaps and Level Design.

**Dylan Long** -

*Projectiles* (Game Physics)
I was the primary developer for this aspect of the game. I implemented the reflection of the projectiles, and their attributes. I implemented a vector difference approach which a normalized vector aimed directly at the enemy. This vector is then scaled by the velocity attribute. So we control how fast each each enemy fires at the player, and projectiles will always fire directly at the player. There is projectile firing script which controls the prodouction of projectiles and is attached to the projectile launcher, and then there is a projectile controller for each projectile. Information about the projectile is passed to the projectile controller from the projectile firing script. 

*ADSR Manager* (Game Physics) (unused) -
I implemented an ADSR Manager using the Professor's template. We used this initially, trying to fine tune it to maximize playability. However, we found that the simple in-built movement function worked perfectly, so we ended up removing it.

*Scene Loader* (additional role) -
I implemented a scene loading script along with game objects which causes the game to trigger a fade-to-black scene switch at the end of each level. This was done using a Youtube video as a guide. It occurs at the beginning of the game and at the end of each level when the playe collides with a hidden game object. The fading was done using the Unity animator.

*Game Concepts* -
Took part in the decisions regarding the functionality of the shield, enemy firing, player movement, interactions between enemy and player, etc. 

## User Interface

The user interface is very minamilistic, fitting with the arcadey nature of the game. I designed a main menu, pause menu and player health bar/ shield bar. And I considered the users'need to restart the level or leave the game during the gameplay. The overall design is retro, arcade-like. 

## Movement/Physics

The movement in the game is simple and similar to classic games such as Mario. The player can move left right and jump. During a jump the player can change directions. This simple model worked perfectly for our game because the focal point of the physics of the game is the use of the shield. It was decided that the shield must be held up instantaneously in order for the player to be able to block rapidly fired projectiles without simply holding the shield up constantly. The goal here is to incentivize the player to time the shield blocks which makes the game more exciting.

## Animation and Visuals

* [Free 2D Mega Pack](https://assetstore.unity.com/packages/2d/free-2d-mega-pack-177430)([License agreement](https://unity3d.com/legal/as_terms?_ga=2.42120421.1153387216.1623213960-1737897374.1617173821))
* [Medieval Warrior Pack 2](https://assetstore.unity.com/packages/2d/characters/medieval-warrior-pack-2-174788)([License agreement](https://unity3d.com/legal/as_terms?_ga=2.219288409.1153387216.1623213960-1737897374.1617173821))
* [Painted HQ 2D Forest Medieval Background](https://assetstore.unity.com/packages/2d/environments/painted-hq-2d-forest-medieval-background-97738) ([License agreement](https://unity3d.com/legal/as_terms?_ga=2.213980887.1153387216.1623213960-1737897374.1617173821))
* [Platformer Fantasy SET1](https://assetstore.unity.com/packages/2d/environments/platformer-fantasy-set1-159063)([License agreement](https://unity3d.com/legal/as_terms?_ga=2.216620758.1153387216.1623213960-1737897374.1617173821))
* [Rocky World Platformer](https://assetstore.unity.com/packages/2d/environments/rocky-world-platformer-150009)([License agreement](https://unity3d.com/legal/as_terms?_ga=2.42094693.1153387216.1623213960-1737897374.1617173821))
* [Bolt 2D LittleWars Assets Pack](https://assetstore.unity.com/packages/2d/characters/bolt-2d-littlewars-assets-pack-189896)([License agreement](https://unity3d.com/legal/as_terms))

The three different scenes was created based on one main story that got more difficult after completing each level. The initial scene is at twilight, which implies the anger of Cayde. The second scene is in daylight which shows the transition of time and the beauty of the environment. The last scene is at cold night, which suggests the end of the story and the diffuculty of the level. The graphic design of the background, tiles, main character, and the enemies are all closely related to the background story. We used a coherent set of pixel assets so everything fit together on a meta level, but we also went with a more chaotic, anything goes, artstyle that would fit the frantic gameplay of dodging and blocking many shots. Through this chaos, we could have funny stuff like the enemy design. The fast and snappy gameplay aligns with this, with fast player movement and jumping, along with tracking enemies with fast projectiles.

## Input

The Input is quite simple. Moving right, left, and jumping are just like any other 2D platformer games. The holding shield input is also not complicated. When receiving the user input, just toggle the renderer and the collider of the shield such that it is not in effect. One thing worth mentioning is that every input are designed to receive the action immediately as well as when stopping it. This is due to the fact that the game's core concept is related to reaction time, and we want the game to reflect the player's action with minimal delay.

## Game Logic

We primairly went with the Component Pattern in designing our work, by splitting up mechanics in compartermalized components that held mechanics
that would interact with each other on a direct basis rather than relying upon a universal gamecontroller. The Factory Pattern was used for Projectile Generation, and the Command Pattern Design was used for basic player commands.

Some examples worth mentioning here are:  
When the player is in the air, he cannot jump again, but he can block. This makes the player be able to actively try to reflect the projectiles.  
When the player touches the enemy, the character will bounce back and damage the player. Within this bound back period, the player cannot move. This increase the difficult for those who want to speed run through the level.  

# Sub-Roles

## Audio

* [SoundBits | Free Sound FX Collection](https://assetstore.unity.com/packages/audio/sound-fx/soundbits-free-sound-fx-collection-31837)([License agreement](https://unity3d.com/legal/as_terms))
* [UI Sfx](https://assetstore.unity.com/packages/audio/sound-fx/ui-sfx-36989)([License agreement](https://unity3d.com/legal/as_terms))
* [Classic Footstep SFX](https://assetstore.unity.com/packages/audio/sound-fx/classic-footstep-sfx-173668)([License agreement](https://unity3d.com/legal/as_terms))
* [(FREE) Cyberpunk / Sci-Fi Soundtrack](https://assetstore.unity.com/packages/audio/music/electronic/free-cyberpunk-sci-fi-soundtrack-183868)([License agreement](https://unity3d.com/legal/as_terms))
* [Shooting Sound](https://assetstore.unity.com/packages/audio/sound-fx/shooting-sound-177096)([License agreement](https://unity3d.com/legal/as_terms))
* [Free Sound Effects Pack](https://assetstore.unity.com/packages/audio/sound-fx/free-sound-effects-pack-155776#content)([License agreement](https://unity3d.com/legal/as_terms))
* [Retro video game sfx - Explode](https://freesound.org/people/OwlStorm/sounds/404754/)([License agreement](https://creativecommons.org/publicdomain/zero/1.0/))

Quite a lot of effort were put in to finding the right sound for every action. The walking and jumping sound are relatively easy to find, but the hold out shield sound is quite difficult to find. In the end, I used a card sound, which seems to be irrelavent to shields, but works great for the moment.  
Another thing worth mentioning is the background music. Before that the game feel was not yet to be determinded. But, once the BGM is set, the entire game feels arcade-ish and retro, which leads to other further design decisions. With that being set, the rest sound effects all follows the retro style and quite a lot of 8-bit SFX are used.

## Gameplay Testing

[Testing Document](https://docs.google.com/document/d/1C1JtMZfvX7OqyhI6QGa9GF-D-K68Z0L3vE8aqQPocDU/edit?usp=sharing)

All core functionality works and the game is playable. However, minor bugs exist with some clipping into walls, while difficulty may be too much,
however because parrying is free, it balances out.  
After discovering the problems, the bugs are discovered, and the movement clipping into wall bug is fixed.

## Narrative Design

The story itself has quite a few inspirations from the John Wick series. As mentioned before, the background image and the tiles of each level hints about the main character's emotion, the difficulty of the game, as well as the time span. The idea is that the main character has to go on a great adventure across the world in order to find his dog. The background is supposed to influence the player's feeling of progressing through a hellish place (level 1), then a softer place (level 2), and finally a climactically dangerous place (level 3). We wanted the feel to be similar to Frodo travelling across Middle Earth. This was to emphasize the passion for his dog and a willingness to go to incredible lengths. And, in the end, through all the danger, he gets his dog back. His shield is supposed to make the player seem like a simple person. He is not a fighter. However, he has this particular skill of counter attacking which can get the job down in a passive way.

## Press Kit and Trailer

Press Kit: https://github.com/Knhwong/189lFinal/blob/main/Press%20Kit.md  
Trailer: https://www.youtube.com/watch?v=MCESlzAYfKo&ab_channel=EdwardsLau

My inspiration comes from a meme years ago,where gamers seeked for the huge satisfaction from upgrading the computer hardware like GPU or RAM. Since we are creating a retro arcarde game, we want to minimize the pc specification requirement. So that our users could enjoy the game from no matter laptop 20 years ago or the latest gaming beast. In our trailer, I draw a strong contrast from the latest 3A games, which require strong pc setups, to our games, which is light-weighted but also interesting. I tried to find a 80s VHS video effect to attract audience's attention. In the press kit, the screen shots shows all game elements that are included in our game: protagonist, enemies, weapons and scenes. These well-chosen moments will definietly catch your eyes!

## Game Feel

**Document what you added to and how you tweaked your game to improve its game feel.**
