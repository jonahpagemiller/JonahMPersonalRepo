
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float sprintSpeed = 10f;
    public float jumpHight = 1.5f;
    public float mouseSensitivity = 100f;
    public Transform camreraTransform;

    private CharacterController characterController;
    private Vector3 velicity;
    private float xrotation;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;

    }
    public void Launch(Vector3 force) => velicity += force;
    // Update is called once per frame
    void Update()
    {
        bool grounded = characterController.isGrounded;
        if (grounded && velicity.y < 0) velicity.y = -2f;

        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        xrotation = Mathf.Clamp(xrotation - mouseY, -90f, 90f);
        camreraTransform.localRotation = Quaternion.Euler(xrotation, 0, 0);
        transform.Rotate(Vector3.up * mouseX);

        float speed = Input.GetKey(KeyCode.LeftShift) ? sprintSpeed : moveSpeed;
        Vector3 move = transform.right * Input.GetAxis("Horizontal") + transform.forward * Input.GetAxis("Vertical");
        characterController.Move(move * (speed * Time.deltaTime));

        if(Input.GetButton("Jump") && grounded)
            velicity.y = Mathf.Sqrt(jumpHight * -2f * Physics.gravity.y);

        velicity.y += Physics.gravity.y * Time.deltaTime;
        characterController.Move(velicity * Time.deltaTime);
    }
}
