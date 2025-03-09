using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class CBulletManager : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> _ListGameObjectProyectile = new List<GameObject>();

    public List<CGenericBullet> _ListPolimorfic = new List<CGenericBullet>();

    protected GameObject _obj;
    public static CBulletManager Inst
    {
        get
        {
            if (_inst == null)
            {
                GameObject obj = new GameObject("CBulletManager");
                return obj.AddComponent<CBulletManager>();
            }
            return _inst;
        }
    }
    private static CBulletManager _inst;
    private void Awake()
    {
        if (_inst != null && _inst != this)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(this.gameObject);
        _inst = this;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GarbageCollection();
    }

    private void GarbageCollection()

    {
        for (int i = _ListGameObjectProyectile.Count - 1; i >= 0; i--)
        {
            if (_ListGameObjectProyectile[i] == null)
            {
                _ListGameObjectProyectile.RemoveAt(i);
            }
        }
        for (int i = _ListPolimorfic.Count - 1; i >= 0; i--)
        {
            if (_ListPolimorfic[i] == null)
            {
                _ListPolimorfic.RemoveAt(i);
            }
        }
    }
    public void SpawnAttack_1(Vector3 Pos, GameObject obj_A)
    {
        GameObject obj = (GameObject)Instantiate(obj_A, Pos, Quaternion.identity);
        CGenericBullet NewBullet = obj.GetComponent<CGenericBullet>();
        _ListPolimorfic.Add(NewBullet);
        _obj = obj;
    }

    public void SpawnAttack_2(Vector3 Pos, GameObject obj_A)
    {
        GameObject obj = (GameObject)Instantiate(obj_A, Pos, Quaternion.identity);
        CGenericBullet NewBullet = obj.GetComponent<CGenericBullet>();
        _ListPolimorfic.Add(NewBullet);
        _obj = obj;
    }

   

}
