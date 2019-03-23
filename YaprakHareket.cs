using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YaprakHareket : MonoBehaviour {

    int hareketyön = -1;
    
	void Start () {
        InvokeRepeating("hareketyöndegis", 0.1f, 3);
	}
	
	
	void Update () {
        transform.Rotate(0, 0, hareketyön * Time.deltaTime*50);
	}
    void hareketyöndegis()
    {
        hareketyön = hareketyön * -1;
    }
}
