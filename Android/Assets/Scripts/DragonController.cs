using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DragonController : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform Dragon;
    public float moveSpeed = 0.5F;
    bool routineRunning;
    Node rootNode;
    SphereCollider bodyCollider;
    
    public TextMeshProUGUI text;
    public TextMeshProUGUI errorText;
    public GameObject canvas;
    public GameObject errorCanvas;
    bool firstCardAppeared = false;
    private int errors;

    

    public void activateCanvas()
    {
        
        if (canvas.activeSelf)
        {
            activateErrorCanvas(false);
            canvas.SetActive(false);
        }
        else
        {
            canvas.SetActive(true);
        }
    }

    public void activateErrorCanvas(bool activate)
    {
        errorCanvas.SetActive(activate);
    }
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

    IEnumerator Fire(float InTime)
    {
        while (routineRunning)
        {
            yield return new WaitForSeconds(0.1f);
        }
        routineRunning = true;
        FindObjectOfType<Dragon>().StartFire();
        yield return new WaitForSeconds(InTime);
        if (isCactusOnFront())
            Destroy(FindObjectOfType<Cactus>().gameObject);
        FindObjectOfType<Dragon>().StopFire();

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
            Dragon.transform.Translate(Vector3.forward * Mathf.Clamp(1 * 6, -1, 1) * moveSpeed * Time.deltaTime);
            yield return null;
        }
        routineRunning = false;
    }

    IEnumerator FlyMe(float inTime)
    {

        while (routineRunning)
        {
            yield return new WaitForSeconds(0.1f);
        }
        routineRunning = true;
        for (var t = 0f; t < 0.0899; t += Time.deltaTime / inTime)
        {
            //Debug.Log("SAD");
            Dragon.transform.Translate(Vector3.up * Mathf.Clamp(1 * 6, -1, 1) * moveSpeed * Time.deltaTime);
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
            Fly();
        }
        if (Input.GetKeyDown("z"))
            moveForward();

        if(Input.GetKeyDown(KeyCode.Space))
        {
            run();
        }
        if (Input.GetKeyDown("p"))
        {
            fire();
        }
        detect[] detects = FindObjectsOfType<detect>();
        if (detects.Length > 0)
        {
            rootNode = detects[detects.Length - 1].node;
            if (canvas.activeSelf)
                text.text = processNodeText(rootNode, 10);
        }

    }

    void moveForward()
    {
        StartCoroutine(MoveMe(1f));
    }

    void Fly()
    {
        
        StartCoroutine(FlyMe(0.6f));
        
    }

    void rotateRight()
    {
        StartCoroutine(RotateMe(Vector3.up * 90, 0.8f));

    }

    void rotateLeft()
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
        //Debug.Log(processNodeText(a, 10));


    }

    public void processIf(Node input_node)
    {
        if (input_node.right != null)
        {
            if (input_node.right.code == "isCactusOnFront()")
                if (isCactusOnFront())
                {
                    processNode(input_node.right.down);
                }
        }
    }

    private bool isCactusOnFront()
    {
        return FindObjectOfType<Dragon>().cactusOnFront;
    }

    public void processNode(Node input_node)
    {
        
        Node temp = input_node;
        while (temp != null)
        {
            if (temp.code == "LOOP")
            {
                //count--;
                processLoop(temp);
            }

            else if (temp.code == "moveForward()")
            {
                moveForward();
            }

            else if (temp.code == "IF")
            {
                processIf(temp);
            }

            else if (temp.code == "rotateLeft()")
            {
                rotateLeft();
            }

            else if (temp.code == "rotateRight()")
            {
                rotateRight();
            }

            else if (temp.code == "fire()")
            {
                fire();
            }
            temp = temp.down;
        }
    }

    private void fire()
    {
        StartCoroutine(Fire(5f));
    }

    public string processNodeText(Node input_node, int count)
    {
        string code = "";
        Node temp = input_node;
        while (temp != null)
        {
            if (temp.code == "LOOP")
            {
                
                if (checkloopError(temp))
                    code += processLoopText(temp, --count) + "\n";
                else
                {
                    return code;
                }
            }
            if (temp.code == "IF")
            {
                if (IFerrors(input_node))
                    code += processIfText(temp, --count) + "\n";
                else
                    return code;
            }
            else
            {   
                if (StatementError(temp))
                    code += temp.code + "\n";
                else
                    return code;
            }

            temp = temp.down;
        }
        return code;
        
        
    }

    private string processLoopText(Node temp, int count1)
    {
        if (count1 == 0)
            return null;
        string code = "";
        if (temp.right != null)
        {
            

                int count = 0;
                try
                {
                    count = Int32.Parse(temp.right.code);
                }

                catch
                {
                    Debug.Log("");
                }

                code = "for (int i = 0; i <" + count + "; i++) \n {";
                code = code + processNodeText(temp.right.down, --count1) + "}";
            
            
        }
        
        return code;
    }

    private string processIfText(Node temp, int count1)
    {
        if (count1 == 0)
            return null;
        string code = "";
        if (temp.right != null)
        {
            
            
            code = "if (" + temp.right.code + ") \n { \n";
            code = code + processNodeText(temp.right.down, --count1) + "\n }";
            return code;

           
        }
        
        return code;
    }

    public void run()
    {
        
       if (rootNode != null)
        {
            activateErrorCanvas(false);
            Debug.Log(rootNode.code);
            errors = 0;
            processNodeText(rootNode, 100);
            if (errors == 0)
                processNode(rootNode);
            else
            {
                activateErrorCanvas(true);
                errorText.text = "Fix the errors before running";
            }
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

    public bool StatementError(Node inputNode)
    {
        
        string[] _statements = { "moveForward()", "moveBackward()", "rotateRight()", "rotateLeft()", "fly()", "fire()" };
        List<string> statements = new List<string>(_statements);

        string a = inputNode.code;
        if (statements.Contains(a))
        {

            if (inputNode.right != null)
            {
                activateErrorCanvas(true);
                errorText.text = "Nothing is expected on the right of " + a +  " statement.";
                Debug.LogError("Nothing is expected on the right of this statement.");
                errors++;
                return false;
            }
            else
            {
                activateErrorCanvas(false);
            }
        }
        else
        {
            return false;
        }
        return true;
    }

    public bool IFerrors(Node inputNode)
    {
        if (inputNode.right == null)
        {
            activateErrorCanvas(true);
            errorText.text = "No condition found on the right of IF";
            errors++;
            return false;
        }
        string[] _if_errors = { "moveForward()", "moveBackward()", "rotateRight()", "rotateLeft()", "fly()", "firee()", "else","loop",
                                "count", "if"};
        List<string> if_errors = new List<string>(_if_errors);

        for (int i = 0; i < if_errors.Count; i++)
        { 

            if (inputNode.right.code == if_errors[i])
            {
                activateErrorCanvas(true);
                errorText.text = "This is not expected on the right of this IF statement.";
                Debug.LogError("This is not expected on the right of this IF statement.");
                errors++;
                return false;
            }
        }

        activateErrorCanvas(false);
        return true;
    }

    /*public bool elseErrors(Node inputNode)
    {
        string[] _else_errors = { "Else", "tree", "hole", "stone", "Spikes", "barrier", "count" };
        List<string> else_errors = new List<string>(_else_errors);

        for (int i = 0; i < else_errors.Count; i++)
        {
            if (inputNode.right.code == else_errors[i])
            {
                Debug.LogError("This is not expected on the right of ELSE statement.");
                return false;
            }
        }
        return true;
    }*/

    public bool checkloopError(Node inputNode)
    {
        if (inputNode.right == null)
        {
            activateErrorCanvas(true);
            errorText.text = "No condition found on the right of loop";
            errors++;
            return false;
        }
        //Uncomment this section when count work is done
        /*if (inputNode.right.code != "count")
        {
            activateErrorCanvas(true);
            errorText.text = "This is not expected on the right of Loop.";
            Debug.LogError("This is not expected on the right of Loop.");
            return false;
        }

        activateErrorCanvas(false);
        return true;*/

        //Comment this section when count work is done
        try
        {
            Int32.Parse(inputNode.right.code);
            return true;
        }
        catch
        {
            activateErrorCanvas(true);
            errorText.text = "This is not expected on the right of Loop.";
            Debug.LogError("This is not expected on the right of Loop.");
            errors++;
            return false;
        }
        
    }


    // Update is called once per frame



}