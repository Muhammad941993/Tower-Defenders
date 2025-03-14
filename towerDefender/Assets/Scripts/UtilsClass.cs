using UnityEngine;

public static class UtilsClass
{
    static Camera camera;

    public static Vector3 GetMouseWorledPosition()
    {
        if(camera == null) camera = Camera.main;

        Vector3 worlesPosition = camera.ScreenToWorldPoint(Input.mousePosition);
        worlesPosition.z = 0;
        return worlesPosition;
    }

    public static Vector3 GetRandomDirection()
    {
        return new Vector3(Random.Range(-2f, 2f), Random.Range(-2f, 2f), Random.Range(0f, 0f));
    }

    public static float GetAngleFromVector(Vector3 vector)
    {
        return Mathf.Atan2(vector.y, vector.x) * Mathf.Rad2Deg;
        
    }
}
