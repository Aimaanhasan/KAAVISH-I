using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cactus : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.GetType() == typeof(BoxCollider))
        {
            collider.gameObject.GetComponent<Dragon>().cactusOnFront = true;
        }
        if (collider.GetType() == typeof(SphereCollider))
        {
            collider.gameObject.GetComponent<Dragon>().Die();
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.GetType() == typeof(BoxCollider))
        {
            collider.gameObject.GetComponent<Dragon>().cactusOnFront = false;
        }

    }

    private void OnDestroy()
    {
        FindObjectOfType<Dragon>().cactusOnFront = false;
    }
}