using UnityEngine;
using UnityEngine.SceneManagement;

public class test : StateMachineBehaviour
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log(this);
        ChangeScene();
    }
    private void ChangeScene()
    {
        SceneManager.LoadScene("Wake Up Text");
    }
}