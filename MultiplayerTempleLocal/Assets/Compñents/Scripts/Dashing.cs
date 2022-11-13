using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dashing : MonoBehaviour
{
    [Header("References")]
    public Transform orientation;
    public Transform playerCam;
    private Rigidbody rb;
    private PlayerMovementDashing pm;

    [Header("Dashing")]
    public float dashForce = 70f;
    public float dashUpwardForce = 2f;
    public float maxDashYSpeed;
    public float dashDuration = 0.4f;

    [Header("Settings")]
    public bool useCameraForward = true;
    public bool allowAllDirections = true;
    public bool disableGravity = false;
    public bool resetYVel = true;

    [Header("Cooldown")]
    public float dashCd = 1.5f; // cooldown of your dash ability
    private float dashCdTimer;

    [Header("Input")]
    public KeyCode dashKey = KeyCode.E;

    private void Start()
    {
        if (playerCam == null)
            playerCam = Camera.main.transform;

        rb = GetComponent<Rigidbody>();
        pm = GetComponent<PlayerMovementDashing>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(dashKey))
            Dash();

        if (dashCdTimer > 0)
            dashCdTimer -= Time.deltaTime;
    }

    private void Dash()
    {
        // cooldown implementation
        if (dashCdTimer > 0) return;
        else dashCdTimer = dashCd;

        // this will cause the PlayerMovement script to change to MovementMode.dashing
        pm.dashing = true;
        pm.maxYSpeed = maxDashYSpeed;

        Transform forwardT;

        // decide wheter you want to use the playerCam or the playersOrientation as forward direction
        if (useCameraForward)
            forwardT = playerCam;
        else
            forwardT = orientation;

        // call the GetDirection() function below to calculate the direction
        Vector3 direction = GetDirection(forwardT);

        // calculate the forward and upward force
        Vector3 forceToApply = direction * dashForce + orientation.up * dashUpwardForce;

        // disable gravity of the players rigidbody if needed
        if (disableGravity)
            rb.useGravity = false;

        // reset the y velocity of the players rigidbody to 0 if needed
        if (resetYVel)
            rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.y);

        // add the dash force (deayed)
        delayedForceToApply = forceToApply;

        // limit y speed
        //if (delayedForceToApply.y > maxDashYSpeed)
        //    delayedForceToApply = new Vector3(delayedForceToApply.x, maxDashYSpeed, delayedForceToApply.z);

        print("dashForce: " + delayedForceToApply);
        Invoke(nameof(DelayedDashForce), 0.025f);

        // make sure the dash stops after the dashDuration is over
        Invoke(nameof(ResetDash), dashDuration);
    }

    private Vector3 delayedForceToApply;
    private void DelayedDashForce()
    {
        rb.AddForce(delayedForceToApply, ForceMode.Impulse);
    }

    private void ResetDash()
    {
        pm.dashing = false;
        pm.maxYSpeed = 0;

        // if you disabled it before, activate the gravity of the rigidbody again
        if (disableGravity)
            rb.useGravity = true;
    }

    private Vector3 GetDirection(Transform forwardT)
    {
        // get the W,A,S,D input
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        // 2 Vector3 for the forward and right velocity
        Vector3 direction = new Vector3();

        if (allowAllDirections)
            direction = forwardT.forward * z + forwardT.right * x;
        else
            direction = forwardT.forward;

        if (x == 0 && z == 0) 
            direction = forwardT.forward;

        return direction.normalized;
    }
}
