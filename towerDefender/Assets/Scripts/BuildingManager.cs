using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingManager : MonoBehaviour
{
    BuildingTypeListSO buildingTypeListSO;
    Camera main;
    private void Awake()
    {
        main = Camera.main;
    }
    // Start is called before the first frame update
    void Start()
    {
        buildingTypeListSO = Resources.Load<BuildingTypeListSO>(typeof(BuildingTypeListSO).Name);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(buildingTypeListSO.List[2].Prefab, GetmouseWorledPosition(), Quaternion.identity);
        }
    }


    Vector3 GetmouseWorledPosition()
    {
        Vector3 pos = main.ScreenToWorldPoint(Input.mousePosition);
        pos.z = 0;
        return pos;
    }
}
