using UnityEngine.SceneManagement;
using UnityEngine;
public class HealthScript : MonoBehaviour {

    public static float maxHealth = 100f;
    public static float health = maxHealth;
    public HealthBar healthBar;
        
    public void TakeDamage() {
        HealthScript.health = HealthScript.health - 5;
        healthBar.UpdateHealthBar();
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.T)) {
            TakeDamage();
        }
        if(HealthScript.health <= 0) {
            SceneManager.LoadScene("Lobby");
        }
    }
}