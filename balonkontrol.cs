using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class balonkontrol : MonoBehaviour {

   public int dikeykuvvet=0;
    Rigidbody2D hareket;
   
    
	void Start () {
        hareket = GetComponent<Rigidbody2D>();
       
	}
	
    
	
	void Update () {
        hareket.velocity = new Vector2(0, dikeykuvvet);//tüm kuvvetleri alır.
		
	}
}
