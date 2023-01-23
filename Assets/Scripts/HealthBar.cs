using UnityEngine;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour {

public Image healthBarImage;
public HealthScript player;
public void UpdateHealthBar()
{
    healthBarImage.fillAmount = Mathf.Clamp(HealthScript.health / HealthScript.maxHealth, 0, 1f);
}
}