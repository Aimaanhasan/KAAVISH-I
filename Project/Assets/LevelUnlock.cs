using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUnlock : MonoBehaviour
{
    [SerializeField] Button[] buttons;
    // Start is called before the first frame update
    [SerializeField] bool chapterScreen;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (chapterScreen)
        {
            int chaptersUnlocked = CloudVariables.ImportantValues[1];
            for (int i = 0; i < chaptersUnlocked + 1; i++)
                buttons[i].interactable = true;
        }

        else
        {
            if (LevelLoader.chapter == CloudVariables.ImportantValues[1])
            {
                int levelsUnlocked = CloudVariables.ImportantValues[2];
                for (int i = 0; i < levelsUnlocked + 1; i++)
                    buttons[i].interactable = true;
            }
            else
                for (int i = 0; i < 6; i++)
                    buttons[i].interactable = true;
        }

        

    }
}