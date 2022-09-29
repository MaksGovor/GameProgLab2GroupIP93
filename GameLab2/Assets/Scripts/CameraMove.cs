using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] Transform cameraTarget;
    [SerializeField] Transform model;
    [SerializeField] float minAngle;
    [SerializeField] float maxAngle;
    [SerializeField] float mouseSensitivity;
    [SerializeField] bool staticCamera;
    public bool isStaticCameraEnable { get; private set; }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        isStaticCameraEnable = staticCamera;
    }

    void Update()
    {
        cameraTarget.rotation *= Quaternion.AngleAxis(Input.GetAxis("Mouse X") * mouseSensitivity, Vector3.up);
        cameraTarget.rotation *= Quaternion.AngleAxis(-Input.GetAxis("Mouse Y") * mouseSensitivity, Vector3.right);

        float angleX = cameraTarget.localEulerAngles.x;
        if (angleX > 180 && angleX < maxAngle)
        {
            angleX = maxAngle;
        }
        else if (angleX < 180 && angleX > minAngle)
        {
            angleX = minAngle;
        }
        
        cameraTarget.localEulerAngles = new Vector3(angleX, cameraTarget.localEulerAngles.y, 0);
        if (staticCamera)
        {
            model.rotation = Quaternion.Euler(0, cameraTarget.rotation.eulerAngles.y, 0);
        }
    }
}
