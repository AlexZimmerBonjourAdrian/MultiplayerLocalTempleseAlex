using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CLevelState : MonoBehaviour
{
    // Start is called before the first frame update
   [SerializeField]  private Transform position;
    void Start()
    {
        CPlayerManager.Inst.Spawn(position.position);  
    }

    // Update is called once per frame
 
}
