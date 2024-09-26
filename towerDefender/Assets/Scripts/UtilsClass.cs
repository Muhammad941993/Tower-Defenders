using UnityEngine;

public static class UtilsClass
{
    static Camera camera;

    public static Vector3 GetMouseWorledPosition()
    {
        camera = camera ?? Camera.main;

        Vector3 WorlesPosition = camera.ScreenToWorldPoint(Input.mousePosition);
        WorlesPosition.z = 0;
        return WorlesPosition;
    }
}
