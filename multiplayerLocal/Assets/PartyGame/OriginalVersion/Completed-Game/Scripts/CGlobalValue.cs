using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class CGlobalValue : MonoBehaviour
{
    public static int _PlayerCount = 0;
    public static List<GameObject> _ListPlayers;
    public static CGlobalValue Inst
    {
        get
        {
            if (_inst == null)
            {
                GameObject obj = new GameObject("CGlobalValue");
                return obj.AddComponent<CGlobalValue>();
            }
            return _inst;
        }
    }
    private static CGlobalValue _inst;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AsignControll()
    {
        _PlayerCount += 1;
    }
    public int GetPlayerController()
    {
        return _PlayerCount;
    }


}
