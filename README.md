# Infinite Procedural Generation

A Unity script for 3D infinite procedural generation.

## Setup

1. Create an empty GameObject in the scene hierarchy & attach the InfiniteProceduralGeneration.cs script to it.
2. On the script component select your player GameObject & set your desired world size.
3. Select how many zones you would like your enviroment to have (refer to zones below) & populate the blocks array on each zone with 1 x 1 cube GameObjects.

## Zones

Each zone consists of a blocks array & a noise height field. GameObjects added to the blocks array need to be 1x1 cubes. Blocks are randomly selected from a zone to be instantiated into the environment. When a zone is changed (after the player has moved a certain distance) the blocks used in the environment are now taken from the newly selected zone.

![image](https://user-images.githubusercontent.com/73779192/188277984-d555eb4e-7265-41c7-9640-44a155d06a82.png)



