using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CTestPunch : MonoBehaviour
{
    // Start is called before the first frame update

  
    

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject != gameObject)
        {
            Debug.Log("Punch");
            other.gameObject.GetComponent<CTestEnemy>().AnimationDamageTest();
            
        }
    }
    
}
