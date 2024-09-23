using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CHelicopterController : CBaseController
{
    private CharacterController controller;

    public float speed = 10f;


    [Range(-90, 90)] public float MaxAngleRotate;
    public float TurnSpeedX = 90F;
    public float TurnSpeedY = 30;
    public bool CanAterrizar;
    public Transform DefaultTransform;

   
    private void Start()
    {
        controller = GetComponent<CharacterController>();
        CanAterrizar = false;
        DefaultTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        MovementPlayer();
    }
    private IEnumerable Reorientate()
    {
      
            transform.Rotate(DefaultTransform.position.x * speed * Time.deltaTime, DefaultTransform.position.y * speed * Time.deltaTime, DefaultTransform.position.z * speed* Time.deltaTime);
            yield return new WaitForSeconds(0.1F);
       


    }
   protected override void MovementPlayer()
    {
        base.MovementPlayer();
        Vector3 movDir;

        Horizontal = Input.GetAxisRaw("Horizontal");
        Vertical = Input.GetAxisRaw("Vertical");

        if(Input.GetKey(_Q))
        transform.Rotate(0, -1 * TurnSpeedY * Time.deltaTime, 0);

        if (Input.GetKey(_E))
            transform.Rotate(0, 1 * TurnSpeedY * Time.deltaTime, 0);
         movDir = transform.forward * Vertical * speed;

        transform.Rotate(Vertical * TurnSpeedX * Time.deltaTime,0,  0);
        controller.Move(movDir * Time.deltaTime - Vector3.up * 0.1f);

        if (transform.rotation.x >= MaxAngleRotate)
        {
          transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x,transform.rotation.y, MaxAngleRotate));
        }
        else if(transform.rotation.x <= -MaxAngleRotate)
        {
            transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, transform.rotation.y, -MaxAngleRotate));
        }
        StartCoroutine("Reorientate");
    }

}
