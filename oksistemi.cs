using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oksistemi : MonoBehaviour {
    public GameObject[] oklar;
    int oksayisi;
    int sayac = 0;

	// Use this for initialization
	void Start () {
        oksayisi = oklar.Length ;
        InvokeRepeating("okatma", 1, 3);//1 sn çalışma her 3 sn 1 çalışır

		
	}
    void okatma()
    {
        Vector2 olusturmayeri = new Vector2(transform.position.x + 1, transform.position.y);//okun oluşturuma yeri
        Instantiate(oklar[sayac], olusturmayeri, Quaternion.Euler(0, 0, -30));//nesneyi ve oluşturma yerini verir,oldugu gibi alır
        if (sayac + 1 == oksayisi)
        {
            sayac = 0;
        }
        else
        {
            sayac += 1;
        }

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
