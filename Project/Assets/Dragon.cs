using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 originalTransform;
    public Transform dragonTransform;
    void Start()
    {
        originalTransform = dragonTransform.position;
    }
    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.layer == 9)
        {
            Die();
        }
    }

    void Die()
    {
        
        dragonTransform.position = originalTransform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
