using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hurricane : MonoBehaviour
{
    public Image hurricaneikon;
    public Animator annim;
    public AudioSource hurrispl;
    public GameObject hurricanecollectable,hurricane;
    public BoxCollider anakaraktercollider;
    // Start is called before the first frame update
    void Start()
    {
        hurricaneikon.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (hurricane.activeInHierarchy == true)
        {
            annim.SetBool("kos", false);
            annim.SetBool("tekme", true);
        }
    }
    public void HurricaneButton()
    {
        hurrispl.Play();
        anakaraktercollider.enabled = false;
        StartCoroutine(FinishHurricane());
        hurricane.SetActive(true);
        hurricaneikon.enabled=false;

    }
    IEnumerator FinishHurricane()
    {
        if (hurricane.activeInHierarchy == true)
        {
            anakaraktercollider.enabled = false;
            annim.SetBool("kos", false);
            annim.SetBool("tekme", true);
            
        }
        yield return new WaitForSeconds(3);
        anakaraktercollider.enabled = true;
        hurricane.SetActive(false);
        annim.SetBool("tekme", false);
        annim.SetBool("kos", true);
    }
}
