using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneManagerr : MonoBehaviour
{
    public Camera mc;
    public Animator ayarlaranim,backanim;
    public Button oyna, ayarlar, cikis;
    public Button musiconbutton,musicoffbutton,backbutton,askbutton;
    // Start is called before the first frame update
    void Start()
    {
        ayarlaranim.enabled = false;
        backanim.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void oynabutton(string sahne)
    {
        oyna.gameObject.SetActive(false);
        ayarlar.gameObject.SetActive(false);
        cikis.gameObject.SetActive(false);
        ayarlaranim.enabled = true;
        Invoke("oyunagec", 1.5f);
       
    }
    public void ayarlarbutton(string sahne)
    {
        oyna.gameObject.SetActive(false);
        ayarlar.gameObject.SetActive(false);
        cikis.gameObject.SetActive(false);
        ayarlaranim.enabled = true;
        Invoke("ayarlaragec", 1.5f);
    }
    public void geributton()
    {
        musicoffbutton.gameObject.SetActive(false);
        musiconbutton.gameObject.SetActive(false);
        backbutton.gameObject.SetActive(false);
        askbutton.gameObject.SetActive(false);
        backanim.enabled=true;
        Invoke("menuyedonus", 1.5f);
        
    }
    public void çıkışbutton()
    {
        Application.Quit();
        
    }
    void oyunagec()
    {
        SceneManager.LoadScene(1);
    }
    void menuyedonus()
    {
        SceneManager.LoadScene(0);
    }
    void ayarlaragec()
    {
        SceneManager.LoadScene(2);
    }
}
