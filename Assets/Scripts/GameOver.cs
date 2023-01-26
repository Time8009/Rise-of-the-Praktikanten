using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public Canvas canvas;
    // Start is called before the first frame update
    void Start()
    {
        canvas.enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 1;
    }

}
