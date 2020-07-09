using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 originalTransform;
    //public Transform dragonTransform;
    void Start()
    {
        
        originalTransform = transform.localPosition;
    } 
    
   

    private void OnTriggerEnter(Collider collider)
    {
        

        if (collider.gameObject.layer == 9)
        {
            Debug.Log("Dragon dead");
            Die();
        }
    }

    void Die()
    {
        
        transform.localPosition = originalTransform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
