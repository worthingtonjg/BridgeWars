using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Connector : MonoBehaviour
{
    public int currentState;
    public List<int> correctStates;
    public bool isDisabled;

    void OnMouseDown()
    {
        if(isDisabled) return;

        transform.Rotate(0f, 90f, 0f);
        ++currentState;
        if(currentState > 3)
        {
            currentState = 0;
        }
    }

    public bool Solved()
    {
        return correctStates.Contains(currentState);
    }
}

