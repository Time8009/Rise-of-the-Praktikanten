using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ButtonExtension : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Button button;

    [SerializeField]
    private float HoverSize = 1.1f;

    private Vector3 hoverVector;

    public void OnPointerEnter(PointerEventData eventData)
    {
        button.transform.localScale = hoverVector;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        button.transform.localScale = Vector3.one;
    }

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        hoverVector.Set(HoverSize,HoverSize,HoverSize);
    }
 
}
