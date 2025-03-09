using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CTestEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator _Anim;
    [SerializeField] public float _Life = 100f;
    void Start()
    {

        _Anim = GetComponent<Animator>();
    }

    // Update is called once per frame
 
    public void TakeDamage(float Life)
    {
        _Life -= Life;
    }
    public void AnimationController()
    {
        if(Input.GetKeyDown(KeyCode.V))
        {
            _Anim.SetBool("IsHit", false);
        }
    }


    public void Update()
    {
        var animatorinfo = this._Anim.GetCurrentAnimatorClipInfo(0);
        var current_animation = animatorinfo[0].clip.name;
        if (current_animation == "hit")
        {
            //Debug.Log(current_animation);
            _Anim.SetBool("IsHit", false);
        }
    }
    public void AnimationDamageTest()
    {
        
        _Anim.SetBool("IsHit", true);

     

        
    }

    
}
