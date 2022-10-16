using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    private static Game _instance;

    public static Game Instance
    {
        get
        {
            return _instance;
        }
    }

    public GameObject Player1;
    public GameObject Player2;

    public GameObject P1Jobs;
    public GameObject P2Jobs;

    public TMP_Text P1JobsRemainingText;
    public TMP_Text P2JobsRemainingText;
    public TMP_Text WinText;

    public GameObject WinPanel;

    private Player p1PlayerComponent;
    private Player p2PlayerComponent;

    private ReconnectManager p1Jobs;
    private ReconnectManager p2Jobs;

    void Awake()
    {
        _instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        Fader.Instance.FadeIn();

        p1PlayerComponent = Player1.GetComponent<Player>();
        p2PlayerComponent = Player2.GetComponent<Player>();
        p1Jobs = P1Jobs.GetComponent<ReconnectManager>();
        p2Jobs = P2Jobs.GetComponent<ReconnectManager>();
    }

    public bool RefreshJobsRemaining()
    {
        var p1Remaining = p1Jobs.JobsRemaining();
        var p2Remaining = p2Jobs.JobsRemaining();

        P1JobsRemainingText.text = p1Jobs.JobsRemaining().ToString();
        P2JobsRemainingText.text = p2Jobs.JobsRemaining().ToString();

        return p1Remaining <= 0 || p2Remaining <= 0;
    }

    public void ShowGameOver()
    {
        var p1Remaining = p1Jobs.JobsRemaining();
        var p2Remaining = p2Jobs.JobsRemaining();

        string winText = "Player 1 - You win!";
        if(p2Remaining > p1Remaining)
        {
            winText = "Player 2 - You win!";
        }

        WinText.text = winText;
        WinPanel.SetActive(true);

        Sounds.Instance.Play("wingame");
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
