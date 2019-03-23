using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class balik3hareket : MonoBehaviour {
    
    
        int yataykuvvet;
        Rigidbody2D hareket;
        public int hiz = 3;

        // Use this for initialization
        void Start()
        {
            hareket = GetComponent<Rigidbody2D>();
            InvokeRepeating("hareketayarla", 1, 3);

        }
        void hareketayarla()
        {
            if (yataykuvvet == hiz)
            {
                yataykuvvet = -hiz;
                transform.localScale = new Vector3(-5, 5, 1);
            }
            else
            {
                yataykuvvet = hiz;
                transform.localScale = new Vector3(5, 5, 1);
            }
        }
        // Update is called once per frame
        void Update()
        {
            hareket.velocity = new Vector2(yataykuvvet, 0);//sürekli 3 hizinda hareket eder.


        }
    }
