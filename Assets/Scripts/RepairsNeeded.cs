using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RepairsNeeded : MonoBehaviour
{
    public GameObject RepairScreen;
    public List<GameObject> PossibleRepairs;
    public List<GameObject> RemainingRepairs;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Inspect()
    {
        PossibleRepairs.ForEach(r => r.SetActive(false));

        int repairCount = Random.Range(1, PossibleRepairs.Count  + 1);

        var repairs = PossibleRepairs.ToList();

        for(int i = 0; i < repairCount; i++)
        {
            int repairIndex = Random.Range(0, repairs.Count);
            var repair = repairs[repairIndex];
            repair.SetActive(true);

            RemainingRepairs.Add(repair);
            repairs.RemoveAt(repairIndex);
        }

        RepairScreen.SetActive(true);
    }

    public int MakeRepair(string name)
    {
        var repair = RemainingRepairs.FirstOrDefault(r => name.ToLower().Contains(r.name.ToLower()));
        RemainingRepairs.Remove(repair);
        repair.SetActive(false);

        Parts.Instance.Respawn(name);

        return RemainingRepairs.Count;
    }
}
