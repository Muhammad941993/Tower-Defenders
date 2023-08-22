using UnityEngine;

public static class UtilityClass
{
    static Camera camera;
    public static Vector3 GetmouseWorledPosition()
    {
        if (camera == null) camera = Camera.main;

        Vector3 pos = camera.ScreenToWorldPoint(Input.mousePosition);
        pos.z = 0;
        return pos;
    }
}
