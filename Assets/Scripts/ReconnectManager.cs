using System.Collections;
using System.Collections.Generic;
using System.IO;
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

        // Get build scenes
         var sceneNumber = SceneManager.sceneCountInBuildSettings;
         
         for (int i = 0; i < sceneNumber; i++)
         {
             string scene = Path.GetFileNameWithoutExtension(SceneUtility.GetScenePathByBuildIndex(i));
             if(scene.Contains($"{PlayerName}Level"))
             {
                result.Add(scene);
             }
         }

        result = result.OrderBy(r => r).ToList();

        return result;
    }

    public void LoadNextSceneAdditive(Player playerComponent)
    {
        string sceneName = _scenes[currentScene++];
        SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);

        if(currentScene >= _scenes.Count) currentScene = 0;
    }
}
