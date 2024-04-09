using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu]
public class CComboAttack : CAttack
{
    // Start is called before the first frame update

    public string nameCombo;
    public string description;
    public string Text;
    public List<CAttack> Combo;
    public List<CComboAttack> ChainCombo;
    public float DelayNextCombo;
    public bool IsCanChainCombo;


}
