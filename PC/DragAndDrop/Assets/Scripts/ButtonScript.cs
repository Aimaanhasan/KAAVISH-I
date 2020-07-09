using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ButtonScript : MonoBehaviour
{
    [SerializeField] public Canvas canvas;
    public Canvas mainCanvas;
    public GameObject prefab;
    GameObject showCode;
    bool ShowCodeInstantiated = false;
    private void Start()
    {
        
        //  canvas = GameObject.FindGameObjectWithTag ( "ErrorDialogueCanvas" );
        //prefab = GameObject.FindGameObjectWithTag("showCode");

    }

    public void ShowCode()
    {
        if (!ShowCodeInstantiated)
        {
            showCode = Instantiate(prefab, mainCanvas.transform.localPosition, mainCanvas.transform.localRotation);
            showCode.transform.SetParent(mainCanvas.transform, false);

            showCode.transform.localScale = new Vector3Int(3, 3, 1);
            showCode.transform.position = new Vector2(625, 800);
            ShowCodeInstantiated = true;
            showCode.GetComponent<Canvas>().overrideSorting = true;
        }
        else
        {
            showCode.SetActive(!showCode.activeSelf);
        }
        GameObject childOfChild3 = showCode.transform.Find("body").gameObject;
        Debug.Log(childOfChild3);
        childOfChild3.GetComponent<TextMeshProUGUI>().text = "";
        childOfChild3.GetComponent<TextMeshProUGUI>().text = FindObjectOfType<DragonController>().getCode();

        //showCode.transform.localPosition = new Vector2(100, 700);

    }
    public void CloseShowCode()
    {
        canvas.enabled = false;
    }
    public void CloseErrorBox()
    {
        canvas.enabled = false;
    }
}
