using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yavrukontrol : MonoBehaviour {
    Rigidbody2D fizikOlaylari;
    Animator animKontrol;//şart verdik dikey kuvvete göre olacagı için animatörü tanımladık.mesela yavaş kanat çırpıp aniden hızlanmasını istiyoruz.



	// Use this for initialization
	void Start () {
        fizikOlaylari = GetComponent<Rigidbody2D>();
        animKontrol = GetComponent<Animator>();
        InvokeRepeating("yukariHareket", 1, 4);
		
	}
	
	// Update is called once per frame
	void Update () {
        animKontrol.SetFloat("dikeykuvvet", Mathf.Abs( fizikOlaylari.velocity.y));
        
		
	}
    void yukariHareket()
    {
        fizikOlaylari.velocity = new Vector2(0, 5);
    }
    void OnCollisionEnter2D(Collision2D collision)//temas oldugunda çalış
    {
        /* if (collision.collider.tag == "Kerry") //temas ettigi nesne player tagı ise
         {
             Destroy(this.gameObject); //yok olsun metodu
         }*/

       // GetComponent<Collider2D>().enabled = false;
    }
}
