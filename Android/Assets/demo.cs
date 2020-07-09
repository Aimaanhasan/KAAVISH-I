using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class demo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void hello()
    {
        
        CloudVariables.ImportantValues[1]++;
        PlayGamesScript.Instance.SaveData();
    }
}
