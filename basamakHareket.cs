using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basamakHareket : MonoBehaviour {
    int yataykuvvet ;
    Rigidbody2D fizik;
    public int hiz=2;

	// Use this for initialization
	void Start () {
        fizik = GetComponent<Rigidbody2D>();
        InvokeRepeating("hareketlibasamak", 1, 3);
		
	}
    void hareketlibasamak()

    {
        if (yataykuvvet == hiz)
        {
            yataykuvvet = -hiz;
            
        }
        else
        {
            yataykuvvet = hiz;
        }

    }	
	
	void Update () {
        fizik.velocity = new Vector2(yataykuvvet, 0);
		
	}
}
