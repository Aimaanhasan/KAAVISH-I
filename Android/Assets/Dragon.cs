using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 originalTransform;
    //public Transform dragonTransform;
    public bool cactusOnFront;
    [SerializeField] ParticleSystem DragonFlame;
    void Start()
    {
        cactusOnFront = false;
        originalTransform = transform.localPosition;
    } 
    
    public void StartFire()
    {
        DragonFlame.Play();
    }

    public void StopFire()
    {
        DragonFlame.Stop();
    }

    private void OnTriggerEnter(Collider collider)
    {

        if (collider.GetType() == typeof(BoxCollider))
            if (collider.gameObject.layer == 9)
            {
                Debug.Log("Dragon dead");
                Die();
            }
    }

    public void Die()
    {
        
        transform.localPosition = originalTransform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
