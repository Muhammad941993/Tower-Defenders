using TMPro;
using UnityEngine;

public class ResourceNerbyOverlay : MonoBehaviour
{
     ResourcesGeneratorData resourcesGenerator;

    TextMeshPro text;
    private void Start()
    {
        text = transform.Find("text").GetComponent<TextMeshPro>();
        Hide();
    }

    private void Update()
    {

        int nearResource = ResourcesGenerator.GetNearbyResourceAmount(resourcesGenerator, transform.position);
        int percent = Mathf.RoundToInt((float)nearResource / resourcesGenerator.maxResourceAmount * 100);

        text.text = percent + "%";
    }
    public void Show(ResourcesGeneratorData _resourcesGenerator)
    {
        resourcesGenerator = _resourcesGenerator;

        transform.Find("icon").GetComponent<SpriteRenderer>().sprite =
            _resourcesGenerator.ResourceTypeSO.Image;



        gameObject.SetActive(true);
    }
    public void Hide()
    {
        gameObject.SetActive(false);

    }
}
