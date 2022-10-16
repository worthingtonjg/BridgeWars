using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReconnectManager : MonoBehaviour
{
    public string PlayerName = "";
    public int currentScene = 0;

    private List<string> _scenes;

    // Start is called before the first frame update
    void Start()
    {
        _scenes = GetAllScenes();
    }

    public List<string> GetAllScenes()
    {
        var result = new List<string>();

        for(int i = 0; i < SceneManager.sceneCount; i++)
        {
            var scene = SceneManager.GetSceneAt(i);
            if(scene.name.StartsWith("Level"))
            {
                result.Add(scene.name);
            }
        }

        return result;
    }

    public bool LoadNextSceneAdditive()
    {
        if(currentScene >= _scenes.Count) return false;

        SceneManager.LoadScene(_scenes[currentScene++], LoadSceneMode.Additive);

        return true;
    }
}
