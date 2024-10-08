using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="BuildingType" ,menuName = "ScriptableObject/BuildingType")]
public class BuildingTypeSO : ScriptableObject
{
    public string stringName;
    public GameObject prefab;
    public Sprite sprite;
    public float minConstructionRadius;
    public ResourcesGeneratorData resourceGeneratorData;
    public ResourceAmount[] constructionCostArray;
}
