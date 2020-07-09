using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CountManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject countCanvas;
    int count;
    public TextMeshProUGUI countText;
    void Start()
    {
        activateCanvas(false);  
        count = 0;
    }

    void activateCanvas(bool activate)
    {
        
        countCanvas.SetActive(activate);
        countText.text = count.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo))
            {
                var rig = hitInfo.collider.GetComponent<CountManager>();
                if (rig != null)
                {
                    //rig.GetComponent<MeshRenderer>().material = hitMaterial;
                    //rig.AddForceAtPosition(ray.direction * 50f, hitInfo.point, ForceMode.VelocityChange);
                    Debug.Log("Raycast working");
                    activateCanvas(true);
                }
            }
        }
    }

    public void changeCount(int n)
    {
        if ((count >= 0) && (count < 100))
        {
            if (n < 0)
            {
                count++;
            }
            count += n;
            countText.text = count.ToString();
        }

    }

    public void enterCount()
    {
        FindObjectOfType<detect>().node.code = count.ToString();
        FindObjectOfType<detect>().changeSprite();
        activateCanvas(false);
    }
}
