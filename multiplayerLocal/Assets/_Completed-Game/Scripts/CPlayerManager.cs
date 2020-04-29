using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPlayerManager : MonoBehaviour
{
    /*
    public int _PlayerNumber;
    [SerializeField]private GameObject _TankPrefab;
    public List<CPlayerController> _Play;
    */
    // Start is called before the first frame update
    private List<PlayerController> _PlayerList = new List<PlayerController>();
    [SerializeField] private GameObject[] _AssetManager;
    

    public static CPlayerManager Inst
    {
        get
        {
            if(_inst == null)
            {
                GameObject obj = new GameObject("CPlayerManager");
                return obj.AddComponent<CPlayerManager>();
            }
            return _inst;
        }
    }
    private static CPlayerManager _inst;

    private void Awake()
    {
        if(_inst != null && _inst != this)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(this.gameObject);
        _inst = this;
        
    }
    // Update is called once per frame
    void Update()
    {
        for (int i = _PlayerList.Count - 1; i >= 0; i--)
        {
         if(_PlayerList[i]== null)
            {
                _PlayerList.RemoveAt(i);
            }
        }

        
    }

    public void Spawn(Vector2 Pos)
    {
        
        if (_PlayerList.Count <= 2)
        {
            GameObject obj = (GameObject)Instantiate(_AssetManager[0], Pos, Quaternion.identity);
            PlayerController newPlayer = obj.GetComponent<PlayerA>();
           // newPlayer.AsignControll();
            _PlayerList.Add(newPlayer);
            
        }
    }
    
}
