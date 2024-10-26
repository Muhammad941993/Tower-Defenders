using TMPro;
using UnityEngine;

public class ToolTipeUI : MonoBehaviour
{
    public static ToolTipeUI Instance;
    [SerializeField] RectTransform recCanves;
    ToolTipeTimer m_toolTipeTimer;
    RectTransform imageRec;
    TextMeshProUGUI tipeText;
    RectTransform tooltipeTransform;

    private void Awake()
    {
        Instance = this;

        imageRec = transform.Find("image").GetComponent<RectTransform>();
        tipeText = transform.Find("text").GetComponent<TextMeshProUGUI>();
        tooltipeTransform = GetComponent<RectTransform>();
    }

    // Start is called before the first frame update
    void Start()
    {
        Hide();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 anchorPos = Input.mousePosition / recCanves.localScale.x;

        anchorPos.x = Mathf.Clamp(anchorPos.x, 0, recCanves.rect.width - imageRec.rect.width);
        anchorPos.y = Mathf.Clamp(anchorPos.y, 0, recCanves.rect.height - imageRec.rect.height);


        tooltipeTransform.anchoredPosition = anchorPos;
        if (m_toolTipeTimer is not null)
        {
            m_toolTipeTimer.Timer -= Time.deltaTime;
            if (m_toolTipeTimer.Timer <= 0)
            {
                Hide();
            }
        }
    }

    void SetText(string text)
    {
        tipeText.SetText(text);
        tipeText.ForceMeshUpdate();
        imageRec.sizeDelta = tipeText.GetRenderedValues() + new Vector2(8, 8);
    }

    public void Show(string tipeText ,ToolTipeTimer toolTipeTimer = null)
    {
        m_toolTipeTimer = toolTipeTimer;
        gameObject.SetActive(true);
        SetText(tipeText);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public class ToolTipeTimer
    {
        public float Timer { get; set; }
    }
}
