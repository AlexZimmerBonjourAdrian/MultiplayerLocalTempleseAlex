using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CBaseController : MonoBehaviour
{
    protected Camera CamCharacter;
    public float Horizontal;
    public float Vertical;
    public float MouseX;
    public float MouseY;
    public KeyCode _Q = KeyCode.Q;
    public KeyCode _E = KeyCode.E;
    public KeyCode _R = KeyCode.R;

    protected virtual void Awake()
    {
        Horizontal = Input.GetAxis("Horizontal");
        Vertical = Input.GetAxis("Vertical");
        MouseX = Input.GetAxis("Mouse X");
        MouseY = Input.GetAxis("Mouse Y");
    }


    protected virtual void MovementPlayer()
    {
        
    }


    protected virtual void Camera()
    {

    }


}
