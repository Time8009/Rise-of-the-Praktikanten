using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprintScript : MonoBehaviour
{
    public static float maxSprint = 100f;
    public static float Sprint = maxSprint;
    public SprintBar SprintBar;


    public IEnumerator Run()
    {
        yield return null;        
        SprintScript.Sprint = SprintScript.Sprint - 1;
        SprintBar.UpdateSprintBar();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            StartCoroutine(Run());
        }
    }
    
}



 /*   public void Run()
    {
        SprintScript.Sprint = SprintScript.Sprint - 5;
        SprintBar.UpdateSprintBar();
        
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            Run();
            
        }
    }
} */