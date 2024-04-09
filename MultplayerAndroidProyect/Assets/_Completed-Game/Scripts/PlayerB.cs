using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerB : PlayerController
{
    public Rigidbody _rigidbodyB;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        _rigidbodyB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    public override void FixedUpdate()
    {
        base.FixedUpdate();
    }
    /*
    public override void SetCountText()
    {
        base.SetCountText();
    }
    */
   public override void Move()
    {
        base.Move();
        rb.velocity = movement * speed;
        _rigidbodyB.constraints = RigidbodyConstraints.FreezeRotation;


    }
   public override void EspecialHability()
    {
        base.EspecialHability();

    }
    public override void AsignControll()
    {
        base.AsignControll();
    }
    
}
