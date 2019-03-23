using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dalgakontrol : MonoBehaviour {
    Rigidbody2D fizikOlaylari;
    public float dikeykuvvet;//level yükseldikçe dalganın yükselme hızı artar
    int yataykuvvet=2;
    bool durum = true;
 




    void Start() {
      
        fizikOlaylari = GetComponent<Rigidbody2D>();//tanımlama diyelim.
        InvokeRepeating("kuvvetAyarlari", 2, 2);//fonk 2 saniye sonra çagır ve her 2 saniyede 1 çağır.


    }
    
void kuvvetAyarlari()
    {
        if (yataykuvvet==2)
        {
            yataykuvvet = -2;
        }
        else
        {
            yataykuvvet = 2;
        }

    }


    void Update()
    {
        fizikOlaylari.velocity = new Vector2(yataykuvvet, dikeykuvvet);



    }	
	}

