using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Xml;
using UnityEngine;

[CreateAssetMenu]
public class CAttack : ScriptableObject
{
   
    public string nombre;
    public int ControlCharacter;
    public float damage;
    public AnimationClip animation;
    public CAttack NextAtack;
    public float DelayNextAttack;

    // M�todo para establecer el siguiente ataque
    public void SetNextAttack(CAttack nextAttack)
    {
        NextAtack = nextAttack;
    }

    // M�todo para obtener el siguiente ataque
    public CAttack GetNextAttack()
    {
        return NextAtack;
    }
}
