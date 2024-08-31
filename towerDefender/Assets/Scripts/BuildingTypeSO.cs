using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="BuildingType" ,menuName = "ScriptableObject/BuildingType")]
public class BuildingTypeSO : ScriptableObject
{
    public string StringName;
    public GameObject Prefab;
    public ResourcesGeneratorData resourceGeneratorData;

}
