using JetBrains.Annotations;
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
    public List<PlayerController> _PlayerList = new List<PlayerController>();
    private List<GameObject> _ListObject = new List<GameObject>();
    [SerializeField] private GameObject[] _AssetManager;
    private GameObject _obj;
    private Transform _serchTransform;

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
        for(int i = _ListObject.Count -1; i >= 0;i--)
        {
            if(_ListObject[i]==null)
            {
                _ListObject.RemoveAt(i);
            }
        }
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            changedCharacter(1, 0);
        }
        else if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            changedCharacter(2, 0);
        }
        else if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            changedCharacter(3, 0);
        }
        
    }

    public void Spawn(Vector3 Pos)
    {
        
        if (_PlayerList.Count <= 2)
        {
            
            GameObject obj = (GameObject)Instantiate(_AssetManager[0], Pos, Quaternion.identity);
            PlayerController newPlayer = obj.GetComponent<PlayerA>();
           // newPlayer.AsignControll();
            _PlayerList.Add(newPlayer);
            //_ListObject.Add(obj);
            _obj = obj;
            
        }
    }
    public void changedCharacter(int count,int NumPlayer)
    {
    
        PlayerController newPlayer;
        _ListObject.Add(_obj);
        
        //for (int i = _PlayerList.Count - 1; i <= 0; i--)
        //{
            
            switch (count)
            {
                case 1:
                Destroy(_obj);
                    _obj = (GameObject)Instantiate(_AssetManager[0], _ListObject[0].transform.position, Quaternion.identity);
                    newPlayer = _obj.GetComponent<PlayerA>();
                    _PlayerList[NumPlayer] = newPlayer;
                    _ListObject[0] = null;
                    
                    /*
                     _obj=(GameObject)Instantiate(_AssetManager[0],position)
                    _PlayerList[i]=
                    */
                    break;
                case 2:
                Destroy(_obj);
                _obj = (GameObject)Instantiate(_AssetManager[1], _ListObject[0].transform.position, Quaternion.identity);
                    newPlayer = _obj.GetComponent<PlayerB>();
                    _PlayerList[NumPlayer] = newPlayer;
                    _ListObject[0] = null;
                    break;
                case 3:
                Destroy(_obj);
                _obj = (GameObject)Instantiate(_AssetManager[2], _ListObject[0].transform.position, Quaternion.identity);
                    newPlayer = _obj.GetComponent<PlayerC>();
                    _PlayerList[NumPlayer] = newPlayer;
                    _ListObject[0] = null;
                    break;
            //}
        }
      
    }

    
    public virtual void AsignControll()
    {

    }


}
