Simple Targeting system for BrickBreak games.

Setup
1. MainCamera must be ortographic
2. create startpoint and game event asset in create menu on assets.
3. create a emptygame object in inspector
    * add startpoion script 
    * assign startpoint and game event from assets to inspector.

just this.

if you want to draw a line
1. create a empty game object named LineDraw
2. add DrawLine script
    * setup you must a indicator for start point just a sprite prefap
3. add start point game event and setup
    * set on Cahange event Drawline > setPositions
4. add Game Event 
    * add end Drag event to DrawLine > Hide