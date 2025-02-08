using UnityEngine;
using UnityEngine.UI;

public class ConstractionTimerUI : MonoBehaviour
{
    [SerializeField] Image constractionTimerProgress;
    [SerializeField] BuildingConstraction buildingConstraction;
   
    // Update is called once per frame
    void Update()
    {
        constractionTimerProgress.fillAmount = buildingConstraction.ConstractionTimerNormalized();
    }
}
