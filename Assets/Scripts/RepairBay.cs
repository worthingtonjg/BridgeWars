using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RepairBay : MonoBehaviour
{
    public Spawner spawner;
    public bool IsBayEmpty = true;
    public bool RepairsNeeded = true;
    public Ship shipToRepair;
    public RepairsNeeded repairsNeeded;
    public string PlayerName;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(IsBayEmpty)
        {
            Spawn();
        }
    }


    public void RepairsFinished()
    {
        shipToRepair.Reparied = true;
        shipToRepair = null;
        Spawn();
    }

    public void Inspect()
    {
        RepairsNeeded = true;
        repairsNeeded.Inspect();
    }

    private void Spawn()
    {
        shipToRepair = spawner.Spawn();
        IsBayEmpty = false;
        RepairsNeeded = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if(!other.tag.Contains("Player")) return;
        if(other.name != PlayerName) return;

        var playerComponent = other.GetComponent<Player>();
        
        var part = playerComponent.parts.FirstOrDefault(p => p.activeSelf);

        if(part == null) return;

        int repairsRemaing = repairsNeeded.MakeRepair(part.name);
        part.SetActive(false);

        if(repairsRemaing == 0)
        {
            print("you win");
        }
    }
}
