using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnTriggerEnter(Collider other)
    {

        if(!other.tag.Contains("Player")) return;

        var playerComponent = other.GetComponent<Player>();
        if(playerComponent.parts.Any(p => p.activeSelf)) return;

        var part = playerComponent.parts.FirstOrDefault(p => p.name.Contains(this.name));
        Sounds.Instance.Play("pickup");
        part.SetActive(true);
        gameObject.SetActive(false);
    }
}
