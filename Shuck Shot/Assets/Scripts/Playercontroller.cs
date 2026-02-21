using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playercontroller : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    private Rigidbody rb;
    private int Timer = 2;
    [SerializeField] private GameObject bullet;
    [SerializeField] private int jumpForce;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Physics.Raycast(transform.position, Vector3.down, 1.2f))
            {
                rb.AddForce(Vector3.up * jumpForce);
            }
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += transform.forward * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += -transform.right * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += -transform.forward * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += transform.right * speed * Time.deltaTime; ;
        }
        if (Input.GetMouseButton(0))
        {
            Shoot();

        }

    }

    private void Shoot()
    {
        //need offset from player position
        Instantiate(bullet, transform.position, Quaternion.identity);

    }
}
