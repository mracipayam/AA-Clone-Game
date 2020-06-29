using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kucukCemberKod : MonoBehaviour
{

    Rigidbody2D fizik;
    public float hiz;
    bool hareketKonrol = false;
    GameObject oyunYoneticisi;
    // Start is called before the first frame update
    void Start()
    {
        fizik = GetComponent<Rigidbody2D>();
        oyunYoneticisi = GameObject.FindGameObjectWithTag("oyunyoneticisitag");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(!hareketKonrol){
            fizik.MovePosition(fizik.position + Vector2.up*hiz*Time.deltaTime);
        }
        
    }

    void OnTriggerEnter2D(Collider2D collision){
        if(collision.tag == "donencembertag"){
            transform.SetParent(collision.transform);
            hareketKonrol = true;
        }
        if(collision.tag == "kucukcembertag"){
            oyunYoneticisi.GetComponent<OyunYoneticisi>().OyunBitti();
        } 
    }
}
