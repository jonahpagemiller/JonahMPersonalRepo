using UnityEngine;

public class CameraController : MonoBehaviour
{

    [SerializeField] Camera Cam;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // move camaera around ball based on mouse movement
        // Rotate camera about player using mouse while maintaining radius.
        Vector3 target = Cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Cam.nearClipPlane));
        transform.LookAt(target, Vector3.up);
    }
}
