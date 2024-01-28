using UnityEngine;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using System.Linq;

public class ComboInput : MonoBehaviour
{
    // Crear una lista para almacenar las entradas del usuario
    [SerializeField] private List<string> comboInput;
    [SerializeField]private List<string> _TempList= new List<string>();

    void Update()
    {
        // Capturar la entrada del usuario
        if (Input.GetKeyDown(KeyCode.W))
        {
           _TempList.Add("Up");
   
            Debug.Log(CheckCombo());
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            _TempList.Add("Down");
    
            Debug.Log(CheckCombo());
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            _TempList.Add("Left");
   
            Debug.Log(CheckCombo());
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            _TempList.Add("Right");
            Debug.Log(CheckCombo());
        }
        
        //Debug.Log(CheckCombo());
        // Imprimir la lista de entradas del usuario
        //foreach (string key in comboInput)
        //{
        //    Debug.Log(key);
        //}

    }
    private bool CheckCombo()
    {



        if (_TempList.SequenceEqual(comboInput))
        {
            _TempList.Clear();
            return true;
        }
        else if(comboInput != _TempList && _TempList.Count >=5) 
        {
            _TempList.Clear();
            return false;
        }
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

