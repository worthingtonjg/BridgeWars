using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public string nextScene;
    public GameObject canvas;
    public int rows;
    public int cols;
    public string PlayerName;

    private int selectedRow;
    private int selectedCol;

    private List<GameObject> connectors;
    private List<Connector> connectorComponents = new List<Connector>();

    // Start is called before the first frame update
    void Start()
    {
        var connectors = GameObject.FindGameObjectsWithTag("Connector").OrderBy(c => c.name).ToList();
        connectors.ForEach(c => connectorComponents.Add(c.GetComponent<Connector>()));
        connectorComponents[0].ToggleSelected(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(connectorComponents.All(c => c.Solved()))
        {
            StartCoroutine("CloseLevel");
        }

        if(PlayerName=="P1")
        {
            if(Input.GetKeyDown(KeyCode.A)) MoveLeft();
            if(Input.GetKeyDown(KeyCode.D)) MoveRight();
            if(Input.GetKeyDown(KeyCode.W)) MoveUp();
            if(Input.GetKeyDown(KeyCode.S)) MoveDown();
            if(Input.GetKeyDown(KeyCode.Space)) Rotate();
        }
        else
        {
            if(Input.GetKeyDown(KeyCode.LeftArrow)) MoveLeft();
            if(Input.GetKeyDown(KeyCode.RightArrow)) MoveRight();
            if(Input.GetKeyDown(KeyCode.UpArrow)) MoveUp();
            if(Input.GetKeyDown(KeyCode.DownArrow)) MoveDown();
            if(Input.GetKeyDown(KeyCode.KeypadEnter)) Rotate();            
        }
    }

    IEnumerator CloseLevel()
    {
        connectorComponents.ForEach(c => c.isDisabled = true);

        yield return new WaitForSeconds(1f);

        GameObject player;
        GameObject repairBay;
        if(PlayerName=="P1")
        {
            player = GameObject.Find("Player1");
            repairBay = GameObject.Find("P1RepairBay");
        }
        else
        {
            player = GameObject.Find("Player2");
            repairBay = GameObject.Find("P2RepairBay");
        }

        var controller = player.GetComponent<CharacterController>();
        controller.enabled = true;

        var repairBayComponent = repairBay.GetComponent<RepairBay>();
        repairBayComponent.RepairsFinished();

        var LevelAttributes = GetComponent<LevelAttributes>();
        SceneManager.UnloadSceneAsync(LevelAttributes.LevelName);
    }

    private void MoveLeft()
    {
        --selectedCol;
        if(selectedCol < 0)
        {
            selectedCol = cols - 1;
        }
        UpdateSelected();
    }

    private void MoveRight()
    {
        ++selectedCol;
        if(selectedCol >= cols)
        {
            selectedCol = 0;
        }                
        UpdateSelected();
    }

    private void MoveDown()
    {
        ++selectedRow;
        if(selectedRow >= rows)
        {
            selectedRow = 0;
        }
        UpdateSelected();
    }

    private void MoveUp()
    {
        --selectedRow;
        if(selectedRow < 0)
        {
            selectedRow = rows - 1;
        }
 
        UpdateSelected();
    }

    private void UpdateSelected()
    {
        connectorComponents.ForEach(c => c.ToggleSelected(false));
        GetSelected().ToggleSelected(true);
    }

    private Connector GetSelected()
    {
        var index = selectedCol + (selectedRow * cols);        
        return connectorComponents[index];
    }

    private void Rotate()
    {
        GetSelected().Rotate();
    }
}
