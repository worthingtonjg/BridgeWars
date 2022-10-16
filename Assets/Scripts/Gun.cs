using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public string FireButtonName;
    public GameObject BulletPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown(FireButtonName))
        {
            var bullet = GameObject.Instantiate(BulletPrefab, transform.position, transform.rotation);
            GameObject.Destroy(bullet, 3f);
            Sounds.Instance.Play("pew");
        }
    }
}
