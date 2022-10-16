using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class RepairBay : MonoBehaviour
{
    public Spawner spawner;
    public bool IsBayEmpty = true;
    public bool RepairsNeeded = true;
    public Ship shipToRepair;
    public RepairsNeeded repairsNeeded;
    public string PlayerName;
    public ReconnectManager reconnectManager;
    public TMP_Text Score;
    public TMP_Text JobsRemaining;

    private int score;
    private int multiplier = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(IsBayEmpty)
        {
            Spawn();
        }
    }


    public void RepairsFinished()
    {
        score += 100*multiplier;
        Score.text = score.ToString();
        ++multiplier;

        bool gameOver = Game.Instance.RefreshJobsRemaining();

        if(gameOver)
        {
            Game.Instance.ShowGameOver();
            return;
        }

        if(repairsNeeded.RemainingRepairs.Count == 0)
        {
            shipToRepair.Reparied = true;
            shipToRepair = null;
            Spawn();
        }
    }

    public void Inspect()
    {
        RepairsNeeded = true;
        repairsNeeded.Inspect();
    }

    private void Spawn()
    {
        shipToRepair = spawner.Spawn();
        IsBayEmpty = false;
        RepairsNeeded = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if(!other.tag.Contains("Player")) return;
        if(other.name != PlayerName) return;

        var playerComponent = other.GetComponent<Player>();
        
        var part = playerComponent.parts.FirstOrDefault(p => p.activeSelf);

        if(part == null) return;

        var playerCam = GameObject.Find($"{PlayerName}Cam");
        var playerCamComponent = playerCam.GetComponent<Camera>();

        int repairsRemaing = repairsNeeded.MakeRepair(part.name);
        part.SetActive(false);

        playerComponent.ToggleController(false);
        reconnectManager.LoadNextSceneAdditive(playerComponent);
    }
}
