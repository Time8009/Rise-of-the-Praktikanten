using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SprintBar : MonoBehaviour
{
    public Image SprintbarImage;
    public SprintScript player;
    public void UpdateSprintBar()
    {
        SprintbarImage.fillAmount = Mathf.Clamp(SprintScript.Sprint / SprintScript.maxSprint, 0, 1f);
    }
}
