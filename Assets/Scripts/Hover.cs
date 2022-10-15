using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hover : MonoBehaviour
{
    public float moveTime = 3f;
    public float distance = 1f;
    public string axis = "y";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        iTween.MoveBy(gameObject, iTween.Hash(
            axis, distance,
            "time", moveTime,
            "easeType", "linear",
            "loopType", "pingPong" 
        ));
    }
}
