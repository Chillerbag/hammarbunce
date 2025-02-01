using System.Collections.Generic;

// this class is used to build scenes using their start positions. 


// TODO: instantiate all the objects in these lists and populate the lists.
public static class SceneBuilder
{
    private static List<LevelObject> levelObjects;
    private static List<MenuObject> menuObjects;

    public static void OnMenuStart() {
        // set position in scene of each menu object. 
        foreach (LevelObject obj in levelObjects) {
            obj.onStart();
        }

    }

    public static void OnGameStart() {

        // set position in scene of each object. 
        foreach (LevelObject obj in levelObjects) {
            obj.onStart();
        }
    }

    
}
