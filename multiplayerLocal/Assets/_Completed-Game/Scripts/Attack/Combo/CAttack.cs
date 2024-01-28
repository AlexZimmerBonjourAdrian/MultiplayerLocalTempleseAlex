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
}
