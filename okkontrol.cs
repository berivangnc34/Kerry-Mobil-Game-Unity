using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class okkontrol : MonoBehaviour {
    Rigidbody2D fizikolaylari;
    Animator animkontrol;
    public int yataykuvvet;



	// Use this for initialization
	void Start () {
        fizikolaylari = GetComponent<Rigidbody2D>();
        animkontrol = GetComponent<Animator>();
        Destroy(transform.gameObject, 20);//oklar 20 sn sonra yok olsun

		
	}
	
	// Update is called once per frame
	void Update () {
        fizikolaylari.velocity = new Vector2(yataykuvvet, 0);
		
	}
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "yildiz")
        {
            GetComponent<Collider2D>().enabled = false;
            yataykuvvet = 0;
            animkontrol.SetBool("carpma", true);
            Destroy(transform.gameObject, 0.5f);
        }
       
      
         //temas oldugu zaman patlama efekti devreye girer..
    }
}
