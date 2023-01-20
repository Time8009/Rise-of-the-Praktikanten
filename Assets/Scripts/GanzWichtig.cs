using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GanzWichtig : MonoBehaviour
{
    [SerializeField]
    private GameObject PartyPrefab;

    private bool HaveParty = false;

    private void CreateParty()
    {
        if(!HaveParty)
        {
            HaveParty = true;
            if (PartyPrefab != null)
            {
                foreach (GameObject gop in UnityEngine.Object.FindObjectsOfType<GameObject>())
                {
                    GameObject.Instantiate(PartyPrefab, gop.transform);
                }
            }
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            CreateParty();
        }
    }
}
