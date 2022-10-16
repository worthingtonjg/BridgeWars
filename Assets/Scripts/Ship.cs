using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    public bool InTransit = true;
    public bool LiftedOff = false;
    public bool Reparied = false;
    public GameObject RepairBay;
    public GameObject OtherSpawner;
    public float moveSpeed = 25f;

    private Vector3 liftOffVector;

    // Start is called before the first frame update
    void Start()
    {
        liftOffVector = new Vector3(RepairBay.transform.position.x, RepairBay.transform.position.y+5, RepairBay.transform.position.z);
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
            if(!LiftedOff)
            {
                transform.position = Vector3.MoveTowards(transform.position, liftOffVector, moveSpeed * Time.deltaTime);

                if (Vector3.Distance(transform.position, liftOffVector) < 0.001f)
                {
                    LiftedOff = true;
                }
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, OtherSpawner.transform.position, moveSpeed * Time.deltaTime);

                if (Vector3.Distance(transform.position, OtherSpawner.transform.position) < 0.001f)
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}
