using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarHandler : MonoBehaviour
{
    GameObject[] objects;
    // Start is called before the first frame update
    float totalCoins;
    void Awake()
    {
        objects = GameObject.FindGameObjectsWithTag("Star");
        foreach (var obj in objects)
            obj.SetActive(false);
        
    }

    public void countCoins()
    {
        totalCoins = GameObject.FindGameObjectsWithTag("Coin").Length;
        Debug.Log(totalCoins);
    }
    void Start()
    {
        
        
    }
    
    public void displayStars()
    {
        for (int i = 0; i < 3; i++)
            objects[i].SetActive(true);
        //for video
       /* Debug.Log(GameObject.FindGameObjectsWithTag("Coin").Length);
        float collectedCoins = totalCoins - GameObject.FindGameObjectsWithTag("Coin").Length;
        float percentCollected  = (collectedCoins / totalCoins) * 100;
        Debug.Log(collectedCoins);
        Debug.Log(percentCollected);
        if (percentCollected > 0)
            objects[0].SetActive(true);
        if (percentCollected > 34)
            objects[1].SetActive(true);
        if (percentCollected > 67)
            objects[2].SetActive(true);*/
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
