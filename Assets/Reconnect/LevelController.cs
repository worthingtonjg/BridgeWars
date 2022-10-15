using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public string nextScene;
    public GameObject canvas;

    private List<GameObject> connectors;
    private List<Connector> connectorComponents = new List<Connector>();

    // Start is called before the first frame update
    void Start()
    {
        var connectors = GameObject.FindGameObjectsWithTag("Connector").ToList();
        connectors.ForEach(c => connectorComponents.Add(c.GetComponent<Connector>()));
    }

    // Update is called once per frame
    void Update()
    {
        print($"Solved: {connectorComponents.Count(c => c.Solved())}");

        if(connectorComponents.All(c => c.Solved()))
        {
            StartCoroutine("EnableNextLevel");
        }
    }

    IEnumerator EnableNextLevel()
    {
        connectorComponents.ForEach(c => c.isDisabled = true);

        yield return new WaitForSeconds(1f);

        canvas.SetActive(true);
    }

    public void NextScene()
    {
        if(connectorComponents.All(c => c.Solved())) 
        {
            SceneManager.LoadScene(nextScene);
        }
    }
}
