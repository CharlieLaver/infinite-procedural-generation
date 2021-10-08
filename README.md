# unity-sandbox

NOTE: no game art is included in this repo

Project conventions:

- All collectables are named with a # and the end.

TODO:

- reformat codebase to have core and surface 

Project Structure (Scripts dir)
The codebase is split into 2 categories:
CORE CLASSES -> holds the core logic that can be used in multiple instances
SURFACE CLASSES -> inherited from core classes and holds more unique logic specific to that use case. surface classes are what is attached to the gameObjects in the engine.


