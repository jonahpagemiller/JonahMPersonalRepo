using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField]
    private float speed;
    public Camera cam;
    public Vector3 camOFFset;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        cam.transform.position = camOFFset + transform.position;
        cam.transform.LookAt(transform.position);
    }
     void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        rb.linearVelocity = new Vector3(movementVector.x,0, movementVector.y)*speed;

    }
}
