using UnityEngine;

public class ProjectileShooter : MonoBehaviour
{
    public GameObject projectilepPrefab;
    public Transform firePoint;
    public float launchVelocity = 20f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
            Shoot();

    }

    void Shoot()
    {
        GameObject prjectile = Instantiate(projectilepPrefab, firePoint.position,firePoint.rotation);
        Rigidbody rb = prjectile.GetComponent<Rigidbody>();
        rb.linearVelocity = firePoint.forward * launchVelocity;
        Destroy(prjectile, 5f);
    }
}