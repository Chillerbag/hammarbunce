using System.Collections.Generic;

public static class SceneBuilder
{
    private static List<LevelObject> levelObjects;
    private static List<MenuObject> menuObjects;

    public static void OnMenuStart() {
        // set position in scene of each menu object. 
        foreach (LevelObject obj in levelObjects) {
            obj.onLevelStart();
        }

    }

    public static void OnGameStart() {

        // set position in scene of each object. 
        foreach (LevelObject obj in levelObjects) {
            obj.onLevelStart();
        }
    }

    
}
