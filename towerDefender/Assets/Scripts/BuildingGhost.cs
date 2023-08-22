using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingGhost : MonoBehaviour
{
    Transform sprite;
    private void Awake()
    {
        sprite = transform.Find("sprite");
        Hide();
    }

    private void OnEnable()
    {

    }

    private void Start()
    {
        BuildingManager.Instance.OnBuidingChanged += Instance_OnBuidingChanged;
    }

    private void OnDisable()
    {
        BuildingManager.Instance.OnBuidingChanged -= Instance_OnBuidingChanged;
    }
    private void Update()
    {
        transform.position = UtilityClass.GetmouseWorledPosition();
    }
    private void Instance_OnBuidingChanged(object sender,BuildingManager.OnBuildingChangedEventArgs e)
    {
        if (e.activeBuilding == null)
        {
            Hide();
        }
        else
        {
            Show(e.activeBuilding.sprite);
        }
    }

    void Show(Sprite _sprite)
    {
        sprite.gameObject.SetActive(true);
        sprite.GetComponent<SpriteRenderer>().sprite = _sprite;
    }
    void Hide()
    {
        sprite.gameObject.SetActive(false);

    }
}
