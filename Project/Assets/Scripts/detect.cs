using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detect : MonoBehaviour
{
    // Start is called before the first frame update
    public Node node;
    
    [SerializeField] string text;
    List<detect> objects;
    void Start()
    {
        node = new Node(text);
       
        
        
    }

    // Update is called once per frame
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.GetType() == typeof(BoxCollider))
        {
            Debug.Log(collision.gameObject.GetComponent<detect>().node.code);
            node.down = collision.gameObject.GetComponent<detect>().node;
            // Node connection
            Debug.Log("connected");
        }



        if (collision.GetType() == typeof(CapsuleCollider))
        {

            Debug.Log(collision.gameObject.GetComponent<detect>().node.code);
            node.right = collision.gameObject.GetComponent<detect>().node;
            Debug.Log("connected2");
            // do stuff only for the circle collider
        }


    }

    private void OnTriggerStay(Collider collision)
    {
        
        
        if (collision.GetType() == typeof(BoxCollider))
        {
            Debug.Log(collision.gameObject.GetComponent<detect>().node.code);
            node.down = collision.gameObject.GetComponent<detect>().node;
            // Node connection
            Debug.Log("connected");
        }

        

        
        else if (collision.GetType() == typeof(CapsuleCollider))
        {

            Debug.Log(collision.gameObject.GetComponent<detect>().node.code);
            node.right = collision.gameObject.GetComponent<detect>().node;
            Debug.Log("connected2");
            // do stuff only for the circle collider
        }

        

        
    }

    public void OnTriggerExit(Collider collision)
    {
        if (collision.GetType() == typeof(BoxCollider))
        {
            Debug.Log("exited1");
            node.down = null;
        }

        


        else if (collision.GetType() == typeof(CapsuleCollider))
        {
            Debug.Log("exited2");
            node.right = null;
        }

    }


    void Update()
    {
        
    }
    

}
