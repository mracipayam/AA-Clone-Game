using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuKontrol : MonoBehaviour
{
    int sonuncuLevel = 3;
    void Start()
    {
        //Butun kayitlari silme metodu
        //PlayerPrefs.DeleteAll();
    }
    public void oyunaGit(){
        int kayitliLevel = PlayerPrefs.GetInt("kayit");
        if (kayitliLevel == 0)
        {
            SceneManager.LoadScene(kayitliLevel + 1);
        }
        SceneManager.LoadScene(kayitliLevel);
    }
    public void cik(){
        Application.Quit();
    }
}
