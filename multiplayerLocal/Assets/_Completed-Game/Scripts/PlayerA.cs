using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerA : PlayerController
{
    // Start is called before the first frame update
    public Rigidbody _rigidbodyA;
    public PlayerA()
    {
      
    }
    public override void Start()
    {
        base.Start();
        _rigidbodyA = GetComponent<Rigidbody>();
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
    protected override void Move()
    {
        base.Move();
        rb.AddForce(movement * speed);
        _rigidbodyA.constraints = RigidbodyConstraints.None;
        

        //Dar habilidades especiales
        //Pensar en que hacer 
    }

    protected override void EspecialHability()
    {
        base.EspecialHability();

    }
    public override void AsignControll()
    {
        base.AsignControll();
    }
   
}
