
using UnityEngine;

public class CKeyboard
{

   [SerializeField] private float mouseSensivility = 100f;

    public static CKeyboard KeysGame;

    #region MoveButton
    public KeyCode A = KeyCode.A;
    public KeyCode W = KeyCode.B;
   public KeyCode D = KeyCode.D;
   public KeyCode S = KeyCode.S;
    #endregion

    #region transformRegion
    public KeyCode Key1 = KeyCode.Alpha1;
    public KeyCode Key2 = KeyCode.Alpha2;
    public KeyCode Key3 = KeyCode.Alpha3;
    #endregion

    #region mouse Input
    public KeyCode clickMouse = KeyCode.Mouse0;
    public KeyCode rigthClickMouse = KeyCode.Mouse1;
    public float MouseWheel = Input.GetAxis("Mouse ScrollWheel");
    public float MouseX = Input.GetAxis("Mouse X");
    public float MouseY = Input.GetAxis("Mouse Y");
    #endregion
    #region Acciones button
    public KeyCode X = KeyCode.X;
    public KeyCode F = KeyCode.F;
    #endregion
    #region Teclas de desarrollo
    public KeyCode F1 = KeyCode.F1;
    public KeyCode F2 = KeyCode.F2;
    public KeyCode F3 = KeyCode.F3;
    #endregion 
    #region Dash Rodar saltar
    public KeyCode Ctrl = KeyCode.LeftControl;
    public KeyCode Shift = KeyCode.LeftShift;
    public KeyCode Space = KeyCode.Space;

    public KeyCode Enter = KeyCode.KeypadEnter;
    #endregion
    // Start is called before the first frame update



    #region Segundo Jugador


    #endregion
    public float getMouseAxisX()
    {
        return MouseX * mouseSensivility * Time.deltaTime;
    }
    public float getMouseAxisY()
    {
        return MouseY * mouseSensivility * Time.deltaTime;
    }

    public bool PressButton(KeyCode any)
    {
        return Input.GetKeyDown(any);
    }

    public bool PressedButton(KeyCode any)
    {
       return Input.GetKey(any);
    }
   
    
 
}
