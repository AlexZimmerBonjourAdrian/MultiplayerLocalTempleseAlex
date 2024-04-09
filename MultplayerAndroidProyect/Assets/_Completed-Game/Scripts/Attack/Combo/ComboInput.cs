using UnityEngine;
using System.Collections.Generic;
//using UnityEditor.UI;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using System.Linq;
using System.Xml.Linq;

public class ComboInput : MonoBehaviour
{
    // Crear una lista para almacenar las entradas del usuario
    // public string pepe;
    //[Tooltip("Attack Logic-2")]
    #region combo System

    [Header("ComboLogic")]

    [Tooltip("Logic")]
    [SerializeField] private Dictionary<string, CComboAttack> _comboTempList = new Dictionary<string, CComboAttack>();
    [SerializeField] private List<CComboAttack> _comboList = new List<CComboAttack>();
    [SerializeField] private CComboAttack _BasicCombo;
    #endregion

    [Space(20)]

    #region Attack Logic
    [Header("Attack Logic")]
    [Tooltip("Logic")]
    [SerializeField] public List<CAttack> _attackTempList = new List<CAttack>();
    [SerializeField] public List<CAttack> _attackList;
    #endregion

    public string KeyDiccionarieCombo;

    public void Start()
    {
        LoadComboResources();
    }
    void Update()
    {
        // Capturar la entrada del usuario
        #region Teclas
        if (Input.GetKeyDown(KeyCode.W))
        {

            _attackTempList.Add(_attackList[0]);

            Debug.Log(CheckCombo());
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            _attackTempList.Add(_attackList[1]);

            Debug.Log(CheckCombo());
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            _attackTempList.Add(_attackList[2]);

            Debug.Log(CheckCombo());
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            _attackTempList.Add(_attackList[2]);
            Debug.Log(CheckCombo());
        }
        #endregion


        //// Capturar la entrada del usuario
        //if (Input.GetKeyDown(KeyCode.W))
        //{
        //    _TempList.Add("Up");

        //    Debug.Log(CheckCombo());
        //}
        //else if (Input.GetKeyDown(KeyCode.S))
        //{
        //    _TempList.Add("Down");

        //    Debug.Log(CheckCombo());
        //}
        //else if (Input.GetKeyDown(KeyCode.A))
        //{
        //    _TempList.Add("Left");

        //    Debug.Log(CheckCombo());
        //}
        //else if (Input.GetKeyDown(KeyCode.D))
        //{
        //    _TempList.Add("Right");
        //    Debug.Log(CheckCombo());
        //}

        //Debug.Log(CheckCombo());
        // Imprimir la lista de entradas del usuario
        //foreach (string key in comboInput)
        //{
        //    Debug.Log(key);
        //}

    }
    //private bool CheckCombo()
    //{

    //    if (_TempList.SequenceEqual(comboInput))
    //    {
    //        _TempList.Clear();
    //        return true;
    //    }
    //    else if(comboInput != _TempList && _TempList.Count >=5) 
    //    {
    //        _TempList.Clear();
    //        return false;
    //    }
    //    return false;

    //}

    #region Set And Getter Combo
    public void SetKeyDiccionarieCombo(string Key)
    {
        Key = KeyDiccionarieCombo;
    }

    public string GetKeyDiccionarieCombo()
    {
        return KeyDiccionarieCombo;
    }

    public List<CAttack> GetListAttack()
    {
        return _attackList;
    }

    public List<CAttack> GetTempListAttack()
    {
        return _attackTempList;
    }

    public Dictionary<string, CComboAttack> GetComboDictinary()
    {
        return _comboTempList;

    }

    public List<CComboAttack> GetListCombo()
    {
        return _comboList;

    }


    private void DebugCombo()
    {
        foreach (CAttack element in _attackTempList) 
        {
            Debug.Log(element.nombre + " ");
        }

    }
    #endregion

    public void NextAttack()
    {

    }

    public void NextAttackDinamicSystem()
    {

    }

    //  public S
    public void LoadComboResources()
    {
        _attackList = new List<CAttack>(Resources.LoadAll<CAttack>("Player-2/Attack"));
        _comboList = new List<CComboAttack>(Resources.LoadAll<CComboAttack>("Player-2/Combo"));


        //Basic Combo 
        _BasicCombo = _comboList[0];
        _comboTempList.Add(_BasicCombo.name, _BasicCombo);
        KeyDiccionarieCombo = _BasicCombo.name;
    }
    //CkeckCombo
    public bool CheckCombo()
    {
        DebugCombo();
        CComboAttack Combo = _comboTempList[KeyDiccionarieCombo];
        if(_comboTempList.TryGetValue(KeyDiccionarieCombo, out Combo))
        { 
      
            if (_attackTempList.SequenceEqual(_comboTempList[KeyDiccionarieCombo].Combo))
            {
                _attackTempList.Clear();
                return true;
            }
            else if (!_attackTempList.SequenceEqual(_comboTempList[KeyDiccionarieCombo].Combo) && _attackTempList.Count >= 5)
            {
                _attackTempList.Clear();
                return false;
            }
        }
        return false;
    }

    public bool CheckComboDynamic()
    {
        //DebugCombo();
        //CComboAttack Combo = _comboTempList[KeyDiccionarieCombo];
        //if (_comboTempList.TryGetValue(KeyDiccionarieCombo, out Combo))
        //{

        //    if (_attackTempList.SequenceEqual(_comboTempList[KeyDiccionarieCombo].Combo))
        //    {
        //        _attackTempList.Clear();
        //        return true;
        //    }
        //    else if (!_attackTempList.SequenceEqual(_comboTempList[KeyDiccionarieCombo].Combo) && _attackTempList.Count >= 5)
        //    {
        //        _attackTempList.Clear();
        //        return false;
        //    }
        //}
        return false;
    }
}


//foreach (string key in _TempList)
//{

//    if (key == comboInput[_TempList.IndexOf(key)] && _TempList.Count <= 5)
//    {
//       Debug.Log(key);
//        if (comboInput == _TempList)
//            {
//                _TempList.Clear();
//                return true;
//            }

//    }
//    if (key != comboInput[comboInput.IndexOf(key)] || _TempList.Count > 5)
//    {
//        _TempList.Clear();
//        return false;
//    }

//}

