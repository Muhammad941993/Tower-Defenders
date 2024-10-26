using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/ResourceType")]

public class ResourcesTypeSO : ScriptableObject
{
    public string StringName;
    public string NameShort;
    public Sprite Image;
    public string ColorHexCode;

}
