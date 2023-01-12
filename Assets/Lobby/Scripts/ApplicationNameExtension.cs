using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshPro))]
public class ApplicationNameExtension : MonoBehaviour
{
    private TextMeshPro text;

    void Start()
    {
        text = GetComponent<TextMeshPro>();
        text.text = Application.productName;
    }
}
