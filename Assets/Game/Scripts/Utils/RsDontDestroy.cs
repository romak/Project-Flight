﻿using UnityEngine;
using System.Collections;

public class RsDontDestroy : MonoBehaviour {

	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(this.gameObject);
    }
	
}
