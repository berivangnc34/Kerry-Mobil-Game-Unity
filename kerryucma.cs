using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kerryucma : MonoBehaviour {

    Rigidbody2D fizikOlaylari;
    public float dikeykuvvet;//level yükseldikçe dalganın yükselme hızı artar
    void Start () {
        fizikOlaylari = GetComponent<Rigidbody2D>();//tanımlama diyelim.
         }

    // Update is called once per frame
    void Update () {
        fizikOlaylari.velocity = new Vector2(0, dikeykuvvet);

    }
}
