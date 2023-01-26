using UnityEngine;

public class ResetTime : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f;
        HealthScript.health = HealthScript.maxHealth;
        SprintScript.Sprint = SprintScript.maxSprint;
        ZombieWalk.canWalk = false;
    }
}
