using UnityEngine;
using UnityEngine.SceneManagement;

public class test : StateMachineBehaviour
{
    private void Start()
    {
        Debug.Log(this);
        ChangeScene();
    }
    private void ChangeScene()
    {
        SceneManager.LoadScene("Level 1");
    }
}