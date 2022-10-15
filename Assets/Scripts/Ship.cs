using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    public bool InTransit = true;
    public bool Reparied = false;
    public GameObject RepairBay;
    public GameObject OtherSpawner;
    public float moveSpeed = 25f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(InTransit)
        {
            transform.position = Vector3.MoveTowards(transform.position, RepairBay.transform.position, moveSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.position, RepairBay.transform.position) < 0.001f)
            {
                InTransit = false;
                var repairBayComponent = RepairBay.GetComponent<RepairBay>();
                repairBayComponent.Inspect();

                var hoverComponent = GetComponent<Hover>();
                hoverComponent.enabled = true;
            }
        }

        if(Reparied)
        {
            transform.position = Vector3.MoveTowards(transform.position, OtherSpawner.transform.position, moveSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.position, OtherSpawner.transform.position) < 0.001f)
            {
                Destroy(gameObject);
            }
        }
    }
}
