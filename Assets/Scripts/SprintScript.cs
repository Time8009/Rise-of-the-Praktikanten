using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprintScript : MonoBehaviour
{
    public static float maxSprint = 100f;
    public static float Sprint = maxSprint;

    [SerializeField]
    public float sprintMalus = 1f;
    public SprintBar SprintBar;

    public bool RunIsRunning = false;
    public bool NotRunIsRunning = false;
    public bool shiftIsPressed = false;


    public IEnumerator Run()
    {
        if(RunIsRunning)
            yield break;

        RunIsRunning = true;

        while (shiftIsPressed)
        {
            yield return new WaitForSeconds(0.1f);
            SprintScript.Sprint = Mathf.Clamp(SprintScript.Sprint - sprintMalus, 0f, maxSprint);
            SprintBar.UpdateSprintBar();
        }

        RunIsRunning = false;
    }

    public IEnumerator NotRun()
    {
        if (NotRunIsRunning)
            yield break;

        NotRunIsRunning = true;

        while (!shiftIsPressed)
        {
            yield return new WaitForSeconds(0.5f);
            SprintScript.Sprint = Mathf.Clamp(SprintScript.Sprint + sprintMalus, 0f, maxSprint);
            SprintBar.UpdateSprintBar();
        }

        NotRunIsRunning = false;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            shiftIsPressed = true;
            StartCoroutine(Run());
        }
        else
        {
            shiftIsPressed = false;
            StartCoroutine(NotRun());            
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