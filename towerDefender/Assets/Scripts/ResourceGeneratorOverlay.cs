using TMPro;
using UnityEngine;

public class ResourceGeneratorOverlay : MonoBehaviour
{
    [SerializeField] ResourcesGenerator resourcesGenerator;

    Transform barTransform;
    // Start is called before the first frame update
    void Start()
    {
        barTransform = transform.Find("bar");
        ResourcesGeneratorData generatorData = resourcesGenerator.GetResourcesGeneratorData();

        transform.Find("icon").GetComponent<SpriteRenderer>().sprite = 
            generatorData.ResourceTypeSO.Image;

        transform.Find("text").GetComponent<TextMeshPro>().text = 
            resourcesGenerator.GetAmountGeneratedPerSecond().ToString("F1");


    }

    // Update is called once per frame
    void Update()
    {
        barTransform.localScale = new Vector3(1-resourcesGenerator.GetTimeNormalized(), 1, 1);

    }
}
