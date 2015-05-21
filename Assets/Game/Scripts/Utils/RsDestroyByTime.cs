using UnityEngine;
using System.Collections;

public class RsDestroyByTime : MonoBehaviour {

    public float m_destroyDelay = 5f;

	void Start () {
        Destroy(gameObject,m_destroyDelay);
	}
	
}
