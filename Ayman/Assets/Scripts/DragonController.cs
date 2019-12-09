using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonController : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform Dragon;
    public float moveSpeed = 0.5F;
    bool routineRunning;
    Node rootNode;
    bool firstCardAppeared = false;
    IEnumerator RotateMe(Vector3 byAngles, float inTime)
    {
        while (routineRunning)
        {
            yield return new WaitForSeconds(0.1f);
        }
        routineRunning = true;
        var fromAngle = Dragon.transform.rotation;
        var toAngle = Quaternion.Euler(Dragon.eulerAngles + byAngles);
        for (var t = 0f; t < 1; t += Time.deltaTime / inTime)
        {
            Dragon.transform.rotation = Quaternion.Slerp(fromAngle, toAngle, t);
            yield return null;
        }
        Dragon.transform.rotation = toAngle;
        routineRunning = false;
    }

    IEnumerator MoveMe(float inTime)
    {
        
        while (routineRunning)
        {
            yield return new WaitForSeconds(0.1f);
        }
        routineRunning = true;
        for (var t = 0f; t < 0.0899; t += Time.deltaTime / inTime)
        {
            Debug.Log("SAD");
            Dragon.transform.Translate(Vector3.forward * Mathf.Clamp(1 * 6, -1, 1) * moveSpeed * Time.deltaTime);
            yield return null;
        }
        routineRunning = false;
    }

    void Update()
    {
        if (Input.GetKeyDown("e"))
        {
            StartCoroutine(RotateMe(Vector3.up * 90, 0.8f));
        }
        if (Input.GetKeyDown("q"))
        {
            StartCoroutine(RotateMe(Vector3.up * -90, 0.8f));
        }
        if (Input.GetKeyDown("w"))
        {
            MoveForward();
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            run();
        }
        detect[] detects = FindObjectsOfType<detect>();
        if (detects.Length > 0)
        { rootNode = detects[detects.Length - 1].node; }

    }

    void MoveForward()
    {
        StartCoroutine(MoveMe(0.8f));
    }

    void RotateRight()
    {
        StartCoroutine(RotateMe(Vector3.up * 90, 0.8f));

    }

    void RotateLeft()
    {
        StartCoroutine(RotateMe(Vector3.up * -90, 0.8f));
    }

    Node a;

    void Start()
    {
        moveSpeed = 0.8f;
        routineRunning = false;
        /*a = new Node("moveForward()");
        a.down = new Node("moveForward()");
        a.down.down = new Node("rotateLeft()");
        a.down.down.down = new Node("moveForward()");
        a.down.down.down.down = new Node("moveForward()");
        a.down.down.down.down.down = new Node("rotateLeft()");
        a.down.down.down.down.down.down = new Node("moveForward()");
        a.down.down.down.down.down.down.down = new Node("moveForward()");
        a.down.down.down.down.down.down.down.down = new Node("rotateLeft()");
        a.down.down.down.down.down.down.down.down.down = new Node("moveForward()");
        a.down.down.down.down.down.down.down.down.down.down = new Node("moveForward()");
        a.down.down.down.down.down.down.down.down.down.down.down = new Node("rotateLeft()");*/

        a = new Node("LOOP");
        a.right = new Node("4");
        a.right.down = new Node("LOOP");
        a.right.down.right = new Node("4");
        a.right.down.right.down = new Node("moveForward()");
        a.right.down.down = new Node("rotateRight()");


    }

    public void processNode(Node input_node)
    {
        
        Node temp = input_node;
        while (temp != null)
        {
            Debug.Log(temp.code);
            if (temp.code == "moveForward()")
            {
                
                MoveForward();
            }

            else if (temp.code == "rotateRight()")
            {
                RotateRight();
            }
            else if (temp.code == "rotateLeft()")
            {
                RotateLeft();
            }

            else if (temp.code == "LOOP")
            {
                processLoop(temp);
            }
            temp = temp.down;
        }
        
        
    }
    public void run()
    {
        if (rootNode != null)
        {
            Debug.Log(rootNode.code);

            processNode(rootNode);
        }
        
    }
    public void processLoop(Node input_node)
    {
        int count = Int32.Parse(input_node.right.code);
        for (int i = 0; i < count; i++)
        {
            processNode(input_node.right.down);
        }
    }





    // Update is called once per frame
    


}