using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OyunYoneticisi : MonoBehaviour
{
    GameObject donenCember;
    GameObject anaCember;
    public Animator animator;
    public Text DonenCemberLevel,bir,iki,uc;
    bool kontrol = true;

    public int kacTaneKucukCemberOlsun;

       


    void Start()
    {
        PlayerPrefs.SetInt("kayit",int.Parse(SceneManager.GetActiveScene().name));//Kaldigimiz leveli kaydediyoruz.


        //int gelenDeger = PlayerPrefs.GetInt("kayit");

        //Objelere ve ilgili objenin scriptine erisiyoruz.
        donenCember = GameObject.FindGameObjectWithTag("donencembertag");
        anaCember = GameObject.FindGameObjectWithTag("anacembertag");
        DonenCemberLevel.text = SceneManager.GetActiveScene().name;

        if(kacTaneKucukCemberOlsun < 2){
            bir.text = kacTaneKucukCemberOlsun+"";//bir texti string oldugundan yanina string ifade ekleyince cast oldu.
            
        }
        else if(kacTaneKucukCemberOlsun < 3){
            bir.text = kacTaneKucukCemberOlsun+"";
            iki.text = (kacTaneKucukCemberOlsun-1)+"";
        }
        else{
            bir.text = kacTaneKucukCemberOlsun+"";
            iki.text = (kacTaneKucukCemberOlsun-1)+"";
            uc.text = (kacTaneKucukCemberOlsun-2)+"";
        }
    }

    public void KucukCemberlerdeTextGosterme(){
        //Azalma islemi gerceklestiren ve guncelleyen fonksiyon
        //Kucuk cemberlerin icindeki sayilari azaltan fonksiyon
        kacTaneKucukCemberOlsun--;
        if(kacTaneKucukCemberOlsun < 2){
            bir.text = kacTaneKucukCemberOlsun+"";//bir texti string oldugundan yanina string ifade ekleyince cast oldu.
            iki.text = "";
            uc.text = "";
        }
        else if(kacTaneKucukCemberOlsun < 3){
            bir.text = kacTaneKucukCemberOlsun+"";
            iki.text = (kacTaneKucukCemberOlsun-1)+"";
            uc.text = "";
        }
        else{
            bir.text = kacTaneKucukCemberOlsun+"";
            iki.text = (kacTaneKucukCemberOlsun-1)+"";
            uc.text = (kacTaneKucukCemberOlsun-2)+"";
        }
        if(kacTaneKucukCemberOlsun==0){
            StartCoroutine(yeniLevel()); 
        }
    }
    IEnumerator yeniLevel(){
        donenCember.GetComponent<Dondurme>().enabled = false;
        anaCember.GetComponent<AnaCember>().enabled = false; 
        yield return new WaitForSeconds(0.5f);
        if(kontrol){
            animator.SetTrigger("yenilevel");
            yield return new WaitForSeconds(1.5f);//Bir saniye bekletme

            SceneManager.LoadScene(int.Parse(SceneManager.GetActiveScene().name)+1);//Level adini integer'a cast ettik
        }

    }

    public void OyunBitti(){
        StartCoroutine(CagrilanMetot());
    }

    IEnumerator CagrilanMetot(){
        donenCember.GetComponent<Dondurme>().enabled = false;
        anaCember.GetComponent<AnaCember>().enabled = false; 
        kontrol = false;
        animator.SetTrigger("oyunbitti");
        yield return new WaitForSeconds(1.5f);//1.5 saniye bekletme komutu
        
        SceneManager.LoadScene("AnaMenu");
    }

}
