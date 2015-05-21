using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RsCrystal : MonoBehaviour
{

    private RsBonusManager bonusManager;

    void Awake()
    {
        bonusManager = GameObject.FindGameObjectWithTag("BonusManager").GetComponent<RsBonusManager>();
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {
            bonusManager.AddCrystals(1, gameObject.transform);
            //gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }

}
