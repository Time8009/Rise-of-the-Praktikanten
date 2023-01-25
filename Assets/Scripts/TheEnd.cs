using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class TheEnd : MonoBehaviour
{
    public Canvas canvas;

    private void End()
    {
        SceneManager.LoadScene(0);
    }

    void Start()
    {
        canvas.enabled = false;
    }

    private void OnTriggerEnter(Collider other)   
    {
        Time.timeScale = 0;
        canvas.enabled = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
