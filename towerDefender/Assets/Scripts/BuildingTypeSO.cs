using System;
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

    public string GetConstructionCost()
    {
        string constructionCost = stringName + "\n";
        foreach (var VARIABLE in constructionCostArray)
        {
            constructionCost += $"<color=#{VARIABLE.resourcesTypeSO.ColorHexCode}>" +
                               $"{VARIABLE.resourcesTypeSO.NameShort} : {VARIABLE.amount} </color> ";
        }
        return constructionCost;
    }
}
 