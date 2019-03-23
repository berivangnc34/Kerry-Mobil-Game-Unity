using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yildizkontrol : MonoBehaviour {

	// Use this for initialization
	void Start () {

        Destroy(this.gameObject, 160);
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(0, 0, -1);
		
	}
}
