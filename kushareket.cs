using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kushareket : MonoBehaviour {
    int yataykuvvet ;
    Rigidbody2D fizikolaylari;
    public int hiz = 4;


	
	void Start () {
        fizikolaylari = GetComponent<Rigidbody2D>();
        InvokeRepeating("hareketayarlari", 1, 4);
        
		
	}
    void hareketayarlari()
    {

        if (yataykuvvet == hiz)
        {
            yataykuvvet = -hiz;  
            transform.localScale=new Vector3(-1, 1, 1);//localscale yön değiştirir.
        }
        else
        {
            yataykuvvet = hiz;
            transform.localScale = new Vector3(1, 1, 1);
        }
    }
	

	void Update () {
        fizikolaylari.velocity = new Vector2(yataykuvvet, 0);//sürekli olarak 4 hızında hareket edecek. yatay eksende
		
	}
}
