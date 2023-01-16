using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    public float crouchSpeed = 2.5f;
    private bool isCrouching = false;
    private Vector3 moveDirection;
    private bool isJumping = false;

    void Update()
    {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");
        moveDirection = new Vector3(horizontal, 0, vertical);
        if (isCrouching)
        {
            moveDirection *= crouchSpeed;
        }
        else
        {
            moveDirection *= moveSpeed;
        }
        moveDirection = transform.TransformDirection(moveDirection);
        transform.position += moveDirection * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            isCrouching = !isCrouching;
        }
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            isJumping = true;
            GetComponent<Rigidbody>().AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
        }
    }
}