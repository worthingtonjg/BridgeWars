using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float x = 1f;
    public float y = 0f;
    public float z = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(x*Time.deltaTime, y*Time.deltaTime, z*Time.deltaTime);
    }
}
