using UnityEngine.UI;
using UnityEngine;
using System;

public class AdventureGame : MonoBehaviour
{

    [SerializeField] Text storyText;
    [SerializeField] State startingState;

    State currentState;

    void Start()
    {
        currentState = startingState;
        storyText.text = currentState.GetStateStory();
    }

	void Update()
	{
        ManageState();
	}

    void ManageState()
    {
        var nextStates = currentState.GetNextStates();
        if (nextStates != null)
        {
            for (int index = 0; index < nextStates.Length; index++) 
            {
                if (Input.GetKeyDown(KeyCode.Alpha1 + index))
                {
                    currentState = nextStates[index];
                }
            }
        }
        storyText.text = currentState.GetStateStory();
    }
}
