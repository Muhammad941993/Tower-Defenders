using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="BuildingType" ,menuName = "ScriptableObject/BuildingType")]
public class BuildingTypeSO : ScriptableObject
{
    public string StringName;
    public GameObject Prefab;
    public Sprite Sprite;
    public ResourcesGeneratorData resourceGeneratorData;
}
