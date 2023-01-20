using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ZombieWalk
{
    public static bool canWalk = false;
}

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Animator))]
public class ZombieAI : MonoBehaviour
{
    public GameObject Target;
    public float speed = 1.5f;

    private Rigidbody RB;

    private Animator animator;

    private float distance;
    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        animator.SetFloat("Speed", speed);
    }

    // Update is called once per frame
    void Update()
    {
        if (!ZombieWalk.canWalk)
            return;

        transform.LookAt(Target.gameObject.transform);

        //RB.MovePosition(transform.position + transform.forward * Time.deltaTime * speed);

        distance = Vector3.Distance(transform.position, Target.gameObject.transform.position);

        if (distance > 3.0f)
            distance = 1.0f;
        else if (distance < 3.0f && distance > 2.3f)
            distance = 0.0f;
        else if (distance < 2.3f)
            distance = -1.0f;

        animator.SetFloat("VerticalMove", distance);
    }
}
