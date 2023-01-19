using UnityEngine;
using UnityEngine.SceneManagement;

public class WakeUp : MonoBehaviour
{
    private void Start()
    {
        Debug.Log(this);
        ChangeScene();    
    }
    private void ChangeScene()
    {
        SceneManager.LoadScene("");
    }
}