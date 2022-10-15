using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public List<GameObject> Prefabs;
    public GameObject RepairBay;
    public GameObject OtherSpawner;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Ship Spawn()
    {
        var prefab = Prefabs[Random.Range(0, Prefabs.Count)];
        var instance = GameObject.Instantiate(prefab, transform.position, transform.rotation);
        
        instance.AddComponent<Ship>();
        instance.AddComponent<Hover>();

        var shipComponent = instance.GetComponent<Ship>();
        shipComponent.RepairBay = RepairBay;
        shipComponent.OtherSpawner = OtherSpawner;

        var hoverComponent = instance.GetComponent<Hover>();
        hoverComponent.enabled = false;

        return shipComponent;
    }
}
