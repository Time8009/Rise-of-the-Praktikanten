using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorStartEvent : MonoBehaviour
{
    public Animation anim;


    // Start is called before the first frame update
    void Start()
    {
        anim.enabled = false;
       
    }

    // Update is called once per frame
    private void ONTriggerEnter(Collider Collision)
    {
        anim.enabled = true;
        anim.Play("LOOK");
    }
}