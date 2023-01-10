using UnityEngine;
public class FPS : MonoBehaviour {
    public float moveSpeed = 10.0f;
    public float rotateSpeed = 10.0f;
    public float mouseSensitivity = 100.0f;

    void Start() {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update() {
        float horizontal = Input.GetAxis("Mouse X") * rotateSpeed;
        float vertical = Input.GetAxis("Mouse Y") * rotateSpeed;

        float x = transform.localEulerAngles.x - vertical;
        x = Mathf.Clamp(x, -89, 89);
        transform.localEulerAngles = new Vector3(x, transform.localEulerAngles.y + horizontal, transform.localEulerAngles.z);

        float moveX = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        float moveZ = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Translate(moveX, 0, moveZ);
    }
}