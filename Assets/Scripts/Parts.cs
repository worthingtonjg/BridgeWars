using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Parts : MonoBehaviour
{
    private static Parts _instance;

    public List<GameObject> SpawnPool;

    public static Parts Instance
    {
        get
        {
            return _instance;
        }
    }
    
    void Awake()
    {
        _instance = this;
    }

    public void Respawn(string name)
    {
        var part = SpawnPool.FirstOrDefault(s => name.ToLower().Contains(s.name.ToLower()));
        part.SetActive(true);
    }
}
