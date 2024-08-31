using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "ScriptableObject/ResourceTypeList")]
public class ResourcesTypeListSO : ScriptableObject
{
    public List<ResourcesTypeSO> List;
}
