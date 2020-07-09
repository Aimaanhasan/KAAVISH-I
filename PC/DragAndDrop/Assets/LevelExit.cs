using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    
    GameObject canvas;
    
    private void Update()
    {
        
    }
    private void Start()
    {
        canvas = FindObjectOfType<LevelLoader>().levelcompletecanvas;
        if (canvas != null)
            canvas.SetActive(false);
        FindObjectOfType<StarHandler>().countCoins();
    }
    
    private void OnTriggerEnter(Collider collision)
    {
        canvas.SetActive(true);
        FindObjectOfType<StarHandler>().displayStars();
        
        
    }

}
