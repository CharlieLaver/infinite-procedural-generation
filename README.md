# Procedural Generation Sandbox

An infinately procedual generated sandbox enviroment build in the Unity engine. The world is built up from 1x1 cubes that parent meshes that are to be randomly instantiated in the world. PLease note that this will only work in the Unity runtime enviroment.

## Resources

Inside the Resources folder is where you can add any GameObject and it will be instaniated into the generated enviroment dynamically.
The Resources folder consists of 3 directories that impacts where the GameObject is going to be used for in the enviroment:

### inventory

* /projectiles - Any GameObjects added here will then be added to the availble projectiles that the player has to shoot with.

### npc

The npc dir has a sub dir for all of the instances of a npc/ enemy. For example /npcCollect.
* /gameObjects - put all of the gameObjects that are related to the npc (e.g. the object that the npc will shoot or drop).
* /materials - materials from this dir will be randomlly selected to what material the npc has.
* /meshes - meshes from here will be randomlly selected to what mesh the npc has

### world

The world fir consists of sub dirs for every zone.
The zone class found at Assets/Core/zone.cs randomly selects a zone dir from this folder. Inside of each zone dir there are 3 folders:

* /common - GameObjects that are most common in the zone.
* /infrequent - GameObjects that are found infrequently in the zone.
* /rare - GameObjects that are rare in the zone (npc blocks etc). 
