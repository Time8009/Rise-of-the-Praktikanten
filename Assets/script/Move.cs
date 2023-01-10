using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed = 4.0f;
    public GameObject character;
    public GameObject mainCamera;
    private Transform characterTransform;

    void Start()
    {
        characterTransform = character.GetComponent<Transform>();
    }

    void Update()
    {
        Vector3 direction = Vector3.zero;
        if (Input.GetKey(KeyCode.D))
        {
            direction += mainCamera.transform.right;
        }
        if (Input.GetKey(KeyCode.A))
        {
            direction -= mainCamera.transform.right;
        }
        if (Input.GetKey(KeyCode.W))
        {
            direction += mainCamera.transform.forward;
        }
        if (Input.GetKey(KeyCode.S))
        {
            direction -= mainCamera.transform.forward;
        }
        direction = direction.normalized * speed * Time.deltaTime;
        characterTransform.position += direction;
    }
}
