using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    public Transform model;
    private Transform mainCamera;
    public Rigidbody rb;
    public float speed = 3f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        mainCamera = Camera.main.transform;
    }

    void FixedUpdate()
    {
        Vector3 forwardCam = new Vector3(mainCamera.forward.x, 0f, mainCamera.forward.z);
        Vector3 rightCam = new Vector3(mainCamera.right.x, 0f, mainCamera.forward.z);
        Vector3 movingVector = Input.GetAxis("Horizontal") * rightCam.normalized + Input.GetAxis("Vertical") * forwardCam.normalized;

        if (!mainCamera.GetComponent<CameraMove>().staticCamera && movingVector.magnitude >= 0.2f)
        {
            model.rotation = Quaternion.LookRotation(forwardCam, Vector3.up);
        }

        if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
        {
            rb.velocity = movingVector * speed;
        }
    }
}
