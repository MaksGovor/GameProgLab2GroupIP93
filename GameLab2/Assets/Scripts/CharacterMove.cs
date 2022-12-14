using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    [SerializeField] Transform model;
    [SerializeField] Rigidbody rb;
    [SerializeField] float speed = 3f;
    [SerializeField] float jumpForce = 100f;
    private Transform mainCamera;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        mainCamera = Camera.main.transform;
    }

    private void OnCollisionStay(Collision collision)
    {
        isGrounded = true;
    }

    void FixedUpdate()
    {
        Vector3 forwardCam = new Vector3(mainCamera.forward.x, 0f, mainCamera.forward.z);
        Vector3 rightCam = new Vector3(mainCamera.right.x, 0f, mainCamera.right.z);
        Vector3 movingVector = Input.GetAxis("Horizontal") * rightCam.normalized + Input.GetAxis("Vertical") * forwardCam.normalized;

        if (!mainCamera.GetComponent<CameraMove>().isStaticCameraEnable && movingVector.magnitude >= 0.2f)
        {
            model.rotation = Quaternion.LookRotation(forwardCam, Vector3.up);
        }

        if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
        {
            rb.AddForce(movingVector * speed, ForceMode.VelocityChange);
        }

        if (Input.GetKey(KeyCode.Space) && isGrounded) 
        {
            rb.AddForce(new Vector3(0, jumpForce, 0));
            isGrounded = false;
        }
    }
}
