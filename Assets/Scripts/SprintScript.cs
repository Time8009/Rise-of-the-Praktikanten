using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson

public class SprintScriptCustom : MonoBehaviour
{
    [Header("Stamina Main Parameters")]
    public float PlayerStamina = 100.0f;
    [SerializeField] private float maxStamina = 100.0f
    [SerializeField] private float jumpCost = 20;
    [HideInInspector] public bool hasRegenerated = true;
    [HideInInspector] public bool weAreSprinting = false;

    [Header("Stamina Regen Parameter")]
    [Range(0, 50)] [SerializeField] private float staminaDrain = 0.5f;
    [Range(0, 50)] [SerializeField] private float staminaRegen = 0.5f;

    [Header]("Stamina Speed Parameter")
    [SerializeField] private int slowedRunSpeed = 4;
    [SerializeField] private int NormalRunSpeed = 8;

    [Header] ("Stamina UI Elements")
    [SerializeField] private Image staminaProgressUI = null;
    [SerializeField] private CanvasGroup sliderCanvasGroup = null;

    private FirstPersonControllerCustom playerController;

    private void Start()
    {
        playerController = GetComponent<FirstPersonControllerCustom>();
    }

    private void Update()
    {
       if(!weAreSprinting)
        {
            if(PlayerStamina <= maxStamina - 0.01)
            {
                PlayerStamina += staminaRegen * Time.deltaTime;
                //UpdateStamina

                if(PlayerStamina >= maxStamina)
            }
        }
    }
}