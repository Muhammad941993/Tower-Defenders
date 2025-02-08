using System;
using UnityEngine;
public class BuildingConstraction : MonoBehaviour
{
    float constractionTimer;
    float constractionTimerMax;
    BuildingTypeSO buildingTypeSO;
    BoxCollider2D boxCollider2D;
    [SerializeField]SpriteRenderer spriteRenderer;
    Material constructionMaterial;

    private void Start()
    {
        constructionMaterial = spriteRenderer.material;
    }

    public static Transform Create(Vector3 position ,BuildingTypeSO buildingType)
    {
        Transform buildingConstraction = Resources.Load<Transform>("BuildingConstraction");
        var building = Instantiate(buildingConstraction, position, Quaternion.identity);
        
        building.GetComponent<BuildingConstraction>().SetBuildingType(buildingType);
        return building;
    }
   
    // Update is called once per frame
    void Update()
    {
        constractionTimer -= Time.deltaTime;
        constructionMaterial.SetFloat("_Progress",ConstractionTimerNormalized());
        if (constractionTimer <= 0)
        {
            Instantiate(buildingTypeSO.prefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    void SetBuildingType(BuildingTypeSO buildingType)
    {
        buildingTypeSO = buildingType;
        constractionTimer = buildingType.constractionTimerMax;
        constractionTimerMax = constractionTimer;
        spriteRenderer.sprite = buildingType.sprite;
        GetComponent<BuildingTypeHolder>().BuildingTypeSO = buildingType;
        GetComponent<BoxCollider2D>().size = buildingType.prefab.GetComponent<BoxCollider2D>().size;
    }
    
    public float ConstractionTimerNormalized()=> 1 - (constractionTimer / constractionTimerMax);
}
