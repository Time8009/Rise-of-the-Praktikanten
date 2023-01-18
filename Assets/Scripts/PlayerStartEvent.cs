using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStartEvent : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Input.GetAxisRaw("Horizontal") * 5f * Time.deltaTime, 0f, 0f);  
    }
}
