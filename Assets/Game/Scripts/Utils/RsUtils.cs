using UnityEngine;
using System.Collections;

public class RsUtils : MonoBehaviour
{

    public static void SetActive(GameObject ob, bool value)
    {
        if (ob != null)
            ob.SetActive(value);
    }
}
