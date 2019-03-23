using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class topHareket : MonoBehaviour {
    Rigidbody2D tophareket;
    public float gelenkuvvet;
    Animator animator;
     float dikeykuvvet;
    
	
	void Start () {
        dikeykuvvet = gelenkuvvet;
        animator = GetComponent<Animator>();
        tophareket = GetComponent<Rigidbody2D>();
        InvokeRepeating("topAyari", 1, 2);
		
	}
    void topAyari()
    {
        if (dikeykuvvet == gelenkuvvet)
        {
            dikeykuvvet = -gelenkuvvet;
        }
        else
        {
            dikeykuvvet = gelenkuvvet;
        }

    }
	void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Kerry")
        {
            GetComponent<Collider2D>().enabled = false;
            animator.SetTrigger("patlama");
            Destroy(this.gameObject, 2);//top objesini yok eder.
        }
    }
	
	void Update () {
        tophareket.velocity=new Vector2(0, dikeykuvvet);
	}
}
