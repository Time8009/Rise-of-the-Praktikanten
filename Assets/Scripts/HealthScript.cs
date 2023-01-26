using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour
{
    public static float maxHealth = 100f;
    public static float health = maxHealth;
    public HealthBar healthBar;
    public Canvas canvas;


    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void Retry()
    {
        SceneManager.LoadScene(3);    
    }

    private void Start()
    {
        canvas.enabled = false;
    }

    public void TakeDamage()
    {
        HealthScript.health = HealthScript.health - 5;
        healthBar.UpdateHealthBar();
    }

    void Update()
    {

        healthBar.UpdateHealthBar();

        if (Input.GetKeyDown(KeyCode.T))
        {
            TakeDamage();
        }
        if (HealthScript.health <= 0)
        {
            Time.timeScale = 0;
            canvas.enabled = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
}