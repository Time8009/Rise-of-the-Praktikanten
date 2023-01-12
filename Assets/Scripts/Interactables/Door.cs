using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interactable
{
    [SerializeField]
    private GameObject door;
    private bool doorOpen;
    void Start()
    {

    }
    void Update()
    {

    }
    protected override void Interact()
    {
        doorOpen = !doorOpen;

        door.SetActive(false);
        //door.GetComponent<Animator>().SetBool("IsOpen", doorOpen);
    }
}