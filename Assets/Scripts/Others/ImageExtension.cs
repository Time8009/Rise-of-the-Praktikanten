using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class ImageExtension : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerUpHandler, IPointerDownHandler
{
    private Image image;

    [SerializeField]
    private string URL = "https://chat.openai.com/chat";

    [SerializeField]
    private float HoverSize = 1.1f;

    private Vector3 hoverVector;

    public void OnPointerDown(PointerEventData eventData)
    {
        image.transform.localScale = hoverVector * HoverSize;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        image.transform.localScale = hoverVector;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        image.transform.localScale = Vector3.one;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Application.OpenURL(URL);
        image.transform.localScale = Vector3.one;
    }

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        hoverVector.Set(HoverSize, HoverSize, HoverSize);
    }

}
