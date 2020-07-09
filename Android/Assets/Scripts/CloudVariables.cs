using UnityEngine;

public class CloudVariables : MonoBehaviour
{
    public static int[] ImportantValues { get; set; }

    // Start is called before the first frame update
    void Awake()
    {
        ImportantValues = new int[4];
    }

}