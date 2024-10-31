using UnityEngine;

public static class UtilsClass
{
    static Camera camera;

    public static Vector3 GetMouseWorledPosition()
    {
        camera = camera ?? Camera.main;

        Vector3 worlesPosition = camera.ScreenToWorldPoint(Input.mousePosition);
        worlesPosition.z = 0;
        return worlesPosition;
    }
    
    
}
