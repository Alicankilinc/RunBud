using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class karakterhareket : MonoBehaviour
{
    Rigidbody rb;
    public bool isGrounded;
    public float JumpForce = 4.0f;
    public Vector3 jump;
    public BoxCollider mainbc;
    public SphereCollider spherebc;
    public Animator annim;
    public Transform lightning, lightningspawn, icespawn, meteorspawn, ice, meteor, superpowershot;
    public Image alevikon, buzikon, kalkanikon, simsekikon, kurtikon, hurricaneikon;
    public AudioSource  Theme,JumpSound,SlideSound,DeathSound,DamageSound;
    public AudioSource LaunchSound, Fireshot, Lightningshot, IceShot;
    public AudioSource fireclt, iceclt, lightningclt, wolfclt, hurricaneclt, shieldclt;
    public ParticleSystem Lightningeffect;
    public GameObject alevcollectable, buzcollectable, kalkancollectable, simsekcollectable, kurtcollectable, Anakarakter, launcher, hurricane,kalkan;
    
    void Start()
    {
       
        jump = new Vector3(0, 2.5f, 0);
        hurricane.SetActive(false);
        launcher.gameObject.SetActive(false);
        spherebc.enabled = false;
        mainbc = GetComponent<BoxCollider>();
        //Theme.Play();
        rb = GetComponent<Rigidbody>();
        annim = GetComponent<Animator>();
        annim.SetBool("kos", true);
        //StartCoroutine(Finishlaunch());
    }

    // Update is called once per frame
    void Update()
    {
        if (SwipeManager.swipeDown)
        {
            SlideSound.Play();
            mainbc.enabled = false;
            spherebc.enabled = true;
            //Anakarakter.transform.position = Anakarakter.transform.position - new Vector3(0, 0.36f, 0);
            annim.SetBool("zipla", false);
            annim.SetBool("kos", false);
            annim.SetBool("kay", true);
            Invoke("kaymaiptal", 1f);
        }
        if (SwipeManager.swipeUp && isGrounded == false)
        {
            JumpSound.Play();
            annim.SetBool("kay", false);
            annim.SetBool("kos", false);
            annim.SetBool("zipla", true);
            rb.AddForce(jump * JumpForce, ForceMode.Impulse);
            isGrounded = true;

            Invoke("ziplamaiptal", 1f);
        }

        if (launcher.activeInHierarchy == true)
        {

            annim.SetBool("kos", false);
            annim.SetBool("uc", true);
            Anakarakter.GetComponent<Rigidbody>().AddForce(new Vector3(-10, 0, 0), ForceMode.Acceleration);
            rb.useGravity = false;
            Anakarakter.GetComponent<BoxCollider>().enabled = false;
            Debug.Log("Launcher Aktif Kanka");

        }

        //if (Input.GetMouseButtonDown(0))
        //{
        //    meteorspawn = Instantiate(meteor, superpowershot.position, Quaternion.identity);
        //    meteorspawn.GetComponent<Rigidbody>().AddForce(superpowershot.right * -1000f);
        //    Fireshot.Play();
        //}

        //if (Input.GetMouseButtonDown(1))
        //{
        //    icespawn = Instantiate(ice, superpowershot.position, Quaternion.identity);
        //    icespawn.GetComponent<Rigidbody>().AddForce(superpowershot.right * -3000f);
        //    IceShot.Play();
        //}
        if (Input.GetKeyUp(KeyCode.W))
        {
            lightningspawn = Instantiate(lightning, superpowershot.position, Quaternion.identity);
            lightningspawn.GetComponent<Rigidbody>().AddForce(superpowershot.right * -1000f);
            Lightningeffect.Play();
            //Lightningshot.Play();
        }
        Anakarakter.transform.Translate(0, 0, 5 * Time.deltaTime);
    }
    void kaymaiptal()
    {
        mainbc.enabled = true;
        spherebc.enabled = false;
        annim.SetBool("kay", false);
        annim.SetBool("kos", true);
    }
    void ziplamaiptal()
    {
        isGrounded = false;
        annim.SetBool("zipla", false);
        annim.SetBool("dus", false);
        annim.SetBool("kos", true);
    }
    IEnumerator Finishlaunch()
    {
        if (launcher.activeInHierarchy == true)
        {
            annim.SetBool("kos", false);
            annim.SetBool("uc", true);
            Anakarakter.GetComponent<Rigidbody>().AddForce(new Vector3(-100, 0, 0), ForceMode.Acceleration);
            Anakarakter.GetComponent<BoxCollider>().enabled = false;
            Debug.Log("Launcher Aktif Kanka");

        }
        yield return new WaitForSeconds(2);
        rb.useGravity = true;
        launcher.SetActive(false);
        annim.SetBool("uc", false);
        annim.SetBool("kos", true);
        Anakarakter.GetComponent<BoxCollider>().enabled = true;
    }

    private void OnTriggerEnter(Collider col)
    {
       
       
        if (col.gameObject.tag == "enemy")
        {
            if (kalkan.activeInHierarchy == false)
            {
                DeathSound.Play();
                annim.SetBool("kos", false);
                annim.SetBool("kay", false);
                annim.SetBool("zipla", false);
                annim.SetBool("dead", true);
                //mainbc.enabled = false;

            }

        }
        if (col.gameObject.tag == "firlatma(ikon)")
        {
            StartCoroutine(Finishlaunch());
            launcher.gameObject.SetActive(true);
            LaunchSound.Play();

        }
        if (col.gameObject.tag == "alev(ikon)")
        {
            if (gameObject != null)
            {
                fireclt.Play();
                Destroy(col.gameObject);
                alevikon.enabled = true;
            }

        }
        if (col.gameObject.name.Contains("buzcollectable"))
        {
            if (gameObject != null)
            {
                iceclt.Play();
                Destroy(col.gameObject);
                buzikon.enabled = true;
            }
        }

        if (col.gameObject.tag == "kalkan(ikon)")
        {
            if (gameObject != null)
            {
                shieldclt.Play();
                Destroy(col.gameObject);
                kalkanikon.enabled = true;

            }
        }
        if (col.gameObject.tag == "kurt(ikon)")
        {
            if (gameObject != null)
            {
                wolfclt.Play();
                Destroy(col.gameObject);
                kurtikon.enabled = true;
            }
        }
        if (col.gameObject.tag == "simsek(ikon)")
        {
            if (gameObject != null)
            {
                lightningclt.Play();
                Destroy(col.gameObject);
                simsekikon.enabled = true;
            }
        }
        if (col.gameObject.tag == "hurricane(ikon)")
        {
            if (gameObject != null)
            {
                hurricaneclt.Play();
                Destroy(col.gameObject);
                hurricaneikon.enabled = true;
            }
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag=="killerparkour")
        {
            DamageSound.Play();
            annim.SetBool("kos", false);
            annim.SetBool("kay", false);
            annim.SetBool("zipla", false);
            annim.SetBool("dead", true);
        }
    }



}
