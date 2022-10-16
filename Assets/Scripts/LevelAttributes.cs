using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelAttributes : MonoBehaviour
{
    public string LevelName;

    public string PlayerName;

    public LevelController LevelController;
    
    public Camera LevelCamera;

    public void SetPlayer(string name)
    {
        PlayerName = name;
        LevelController.PlayerName = name;
    }

    // Start is called before the first frame update
    void Start()
    {
        LevelName = SceneManager.GetActiveScene().name;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
