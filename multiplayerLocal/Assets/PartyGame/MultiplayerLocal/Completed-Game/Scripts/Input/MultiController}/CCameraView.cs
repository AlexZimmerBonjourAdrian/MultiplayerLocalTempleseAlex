using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCameraView : CBaseController
{
    public float mouseSensitivity = 180;

    public Transform playerBody;

    float xRotation = 0f;
    protected override void Awake()
    {
        base.Awake();

    }

    public void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void Update()
    {
        Camera();
    }
    protected override void Camera()
    {
        base.Camera();

        MouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        MouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= MouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * MouseX);
    }

}
