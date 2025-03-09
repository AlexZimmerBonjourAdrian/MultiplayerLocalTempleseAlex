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

    public void Update()
    {
        //Temp code to text Spawn Secundary Character
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            CPlayerManager.Inst.Spawn(position.position + Vector3.right * 5f);
        }
    }
    // Update is called once per frame

}
