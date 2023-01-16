using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCameraMovement : MonoBehaviour
{
    [SerializeField]
    private float speed = 1f;

    [SerializeField]
    public float sensitivityX = 15F;
    [SerializeField]
    public float sensitivityY = 15F;

    [SerializeField]
    public float minimumY = -60F;
    [SerializeField]
    public float maximumY = 60F;

    private float mouseX = 0;
    private float mouseY = 0;
    private Vector3 mousePosition = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        float vertical = Input.GetAxis("Vertical");
        float Horizontal = Input.GetAxis("Horizontal");

        transform.localPosition += transform.forward * vertical * Time.deltaTime * speed;
        transform.localPosition += transform.right * Horizontal * Time.deltaTime * speed;

        mouseX += Input.GetAxis("Mouse X") * sensitivityX;

        mouseY += Input.GetAxis("Mouse Y") * sensitivityY;
        mouseY = Mathf.Clamp(mouseY, minimumY, maximumY);

        Debug.Log("MouseY : " + mouseY);
        Debug.Log("MouseX : " + mouseX);

        mousePosition.Set(-mouseY, mouseX, 0);

        transform.localEulerAngles = mousePosition;
    }
}
