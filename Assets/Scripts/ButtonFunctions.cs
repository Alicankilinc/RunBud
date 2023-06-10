using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonFunctions : MonoBehaviour
{
    public Animator NinjaAnimator;
    public Transform icespawn, meteorspawn, ice, meteor, superpowershot,lightningspawn,lightning,kurtspawn;
    public ParticleSystem Lightningeffect;
    public AudioSource Fireshot, IceShot,LightningShot,Wolfspl,Shieldspl;
    public Image alevikon, buzikon, kalkanikon,kurtikon,simsekikon,hurricaneikon;
    public GameObject alevcollectable, buzcollectable, kalkancollectable, simsekcollectable,wolf, kurtcollectable,hurricanecollectable,kalkan;
    // Start is called before the first frame update
    void Start()
    {
        wolf.SetActive(false);
        alevikon.enabled = false;
        buzikon.enabled = false;
        kalkanikon.enabled = false;
        kurtikon.enabled = false;
        simsekikon.enabled = false;
        kurtikon.enabled=false;
        hurricaneikon.enabled = false;
        kalkan.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void KalkanButton()
    {
        kalkan.SetActive(true);
        kalkanikon.enabled = false;
        Shieldspl.Play();
        Invoke("Kalkanbitti", 1f);
    }
    public void WolfButton()
    {
        kurtspawn = Instantiate(kurtspawn,kurtspawn.position, Quaternion.identity);
        kurtikon.enabled = false;
        wolf.SetActive(true);
        Wolfspl.Play();
        Invoke("kurtyeter", 3f);
    }
    public void IceButton()
    {
        NinjaAnimator.SetBool("kos", false);
        NinjaAnimator.SetBool("kay", false);
        NinjaAnimator.SetBool("zipla", false);
        NinjaAnimator.SetBool("cast", true);
        Invoke("CastIptal", 0.1f);
        Invoke("buzfirlat", 0.25f);
        
    }
    public void FireButton()
    {
        NinjaAnimator.SetBool("kos", false);
        NinjaAnimator.SetBool("kay", false);
        NinjaAnimator.SetBool("zipla", false);
        NinjaAnimator.SetBool("cast", true);
        Invoke("CastIptal", 0.1f);
        Invoke("MeteorAt",0.25f);
       
    }
    public void SimsekButton()
    {
        NinjaAnimator.SetBool("kos", false);
        NinjaAnimator.SetBool("kay", false);
        NinjaAnimator.SetBool("zipla", false);
        NinjaAnimator.SetBool("cast", true);
        Invoke("CastIptal", 0.1f);
        Invoke("SimsekAt", 0.25f);
        
        //Lightningshot.Play();

    }
    void kurtyeter()
    {
        wolf.SetActive(false);
    }
    void Kalkanbitti()
    {
        kalkan.SetActive(false);
    }
    void CastIptal()
    {
        NinjaAnimator.SetBool("cast", false);
        NinjaAnimator.SetBool("kos", true);
    }
    void buzfirlat()
    {
        icespawn = Instantiate(ice, superpowershot.position, Quaternion.identity);
        icespawn.GetComponent<Rigidbody>().AddForce(superpowershot.right * -3000f);
        IceShot.Play();
        buzikon.enabled = false;
    }
    void MeteorAt()
    {
        meteorspawn = Instantiate(meteor, superpowershot.position, Quaternion.identity);
        meteorspawn.GetComponent<Rigidbody>().AddForce(superpowershot.right * -1000f);
        Fireshot.Play();
        alevikon.enabled = false;
    }
    void SimsekAt()
    {
        lightningspawn = Instantiate(lightning, superpowershot.position, Quaternion.identity);
        lightningspawn.GetComponent<Rigidbody>().AddForce(superpowershot.right * -2000f);
        LightningShot.Play();
        Lightningeffect.Play();
        simsekikon.enabled = false;
    }
}
