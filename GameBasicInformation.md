# Game Basic Information #

## Summary ##

**A paragraph-length pitch for your game.**

## Gameplay Explanation ##

**In this section, explain how the game should be played. Treat this as a manual within a game. It is encouraged to explain the button mappings and the most optimal gameplay strategy.**


**If you did work that should be factored in to your grade that does not fit easily into the proscribed roles, add it here! Please include links to resources and descriptions of game-related material that does not fit into roles here.**

# Main Roles #

Your goal is to relate the work of your role and sub-role in terms of the content of the course. Please look at the role sections below for specific instructions for each role.

Below is a template for you to highlight items of your work. These provide the evidence needed for your work to be evaluated. Try to have at least 4 such descriptions. They will be assessed on the quality of the underlying system and how they are linked to course content. 

*Short Description* - Long description of your work item that includes how it is relevant to topics discussed in class. [link to evidence in your repository](https://github.com/dr-jam/ECS189L/edit/project-description/ProjectDocumentTemplate.md)

Here is an example:  
*Procedural Terrain* - The background of the game consists of procedurally-generated terrain that is produced with Perlin noise. This terrain can be modified by the game at run-time via a call to its script methods. The intent is to allow the player to modify the terrain. This system is based on the component design pattern and the procedural content generation portions of the course. [The PCG terrain generation script](https://github.com/dr-jam/CameraControlExercise/blob/513b927e87fc686fe627bf7d4ff6ff841cf34e9f/Obscura/Assets/Scripts/TerrainGenerator.cs#L6).

You should replay any **bold text** with your relevant information. Liberally use the template when necessary and appropriate.

*YiZhen Li* - 

*Ricardo Sun* - 

*Grace Sun* - 

*Kin Hei Wong* - 

*Projectile Motion & Enemy* (Collab with Dylan Wong)
The main enemies of this game fire constant projectiles at the player.
This is implemented via the Factory Design pattern portion of the course along with the Component Design Pattern.

*Scene Transition & Minor UI* (Collab with Dylan Wong)
Added Scene Transition (ExitScene) & added HP Elements.
Adherence to Unity's Component Design Pattern as opposed to Global Controller.

*Preliminary Shield Mechanics* (Collab with Ricardo)
Foundational Shield Mechanics (Taking Damage, Rendering)

*General Polishing & Foundations*
Created the base architecture (now mostly overwritten) along with most prefabs, general polishing of other code and game coherence.

*TileMap & Level  Design*
Implementation of TileMaps and Level Design.


*Dylan Wong* -


## User Interface

The user interface is very minamilistic, fitting with the arcadey nature of the game. There is a just a basic menu along with a health bar.

## Movement/Physics

**Describe the basics of movement and physics in your game. Is it the standard physics model? What did you change or modify? Did you make your movement scripts that do not use the physics system?**

## Animation and Visuals

**List your assets including their sources and licenses.**
Asset Package from Unity store:
* [Free 2D Mega Pack](https://assetstore.unity.com/packages/2d/free-2d-mega-pack-177430)([License agreement](https://unity3d.com/legal/as_terms?_ga=2.42120421.1153387216.1623213960-1737897374.1617173821))
* [Medieval Warrior Pack 2](https://assetstore.unity.com/packages/2d/characters/medieval-warrior-pack-2-174788)([License agreement](https://unity3d.com/legal/as_terms?_ga=2.219288409.1153387216.1623213960-1737897374.1617173821))
* [Painted HQ 2D Forest Medieval Background](https://assetstore.unity.com/packages/2d/environments/painted-hq-2d-forest-medieval-background-97738) ([License agreement](https://unity3d.com/legal/as_terms?_ga=2.213980887.1153387216.1623213960-1737897374.1617173821))
* [Platformer Fantasy SET1](https://assetstore.unity.com/packages/2d/environments/platformer-fantasy-set1-159063)([License agreement](https://unity3d.com/legal/as_terms?_ga=2.216620758.1153387216.1623213960-1737897374.1617173821))
* [Rocky World Platformer](https://assetstore.unity.com/packages/2d/environments/rocky-world-platformer-150009)([License agreement](https://unity3d.com/legal/as_terms?_ga=2.42094693.1153387216.1623213960-1737897374.1617173821))
* [Bolt 2D LittleWars Assets Pack](https://assetstore.unity.com/packages/2d/characters/bolt-2d-littlewars-assets-pack-189896)([License agreement](https://unity3d.com/legal/as_terms))

**Describe how your work intersects with game feel, graphic design, and world-building. Include your visual style guide if one exists.**

The three different scenes was created based on one main story that got more difficult after completing each level. The graphic design of the background, level, main character, and the enemies are all closely related to the background story. We used a coherent set of pixel assets so everything fit together on a meta level, but we also went with a more chaotic, anything goes, artstyle that would fit the frantic gameplay of dodging and blocking many shots. Through this chaos, we could have funny stuff like the enemy design. The fast and snappy gameplay aligns with this, with fast player movement and jumping, along with tracking enemies with fast projectiles.

## Input

**Describe the default input configuration.**

**Add an entry for each platform or input style your project supports.**

## Game Logic

**Document what game states and game data you managed and what design patterns you used to complete your task.**

We primairly went with the Component Pattern in designing our work, by splitting up mechanics in compartermalized components that held mechanics
that would interact with each other on a direct basis rather than relying upon a universal gamecontroller. The Factory Pattern was used for Projectile Generation.

Talk about this stuff here!

# Sub-Roles

## Audio

**List your assets including their sources and licenses.**

**Describe the implementation of your audio system.**

**Document the sound style.** 

## Gameplay Testing

**Add a link to the full results of your gameplay tests.**

**Summarize the key findings from your gameplay tests.**

## Narrative Design

**Document how the narrative is present in the game via assets, gameplay systems, and gameplay.** 

## Press Kit and Trailer

**Include links to your presskit materials and trailer.**

**Describe how you showcased your work. How did you choose what to show in the trailer? Why did you choose your screenshots?**

## Game Feel

**Document what you added to and how you tweaked your game to improve its game feel.**
