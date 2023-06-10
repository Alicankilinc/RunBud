using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class copzombiehareket : MonoBehaviour
{
    Rigidbody rb;
    public GameObject copzombie, maincharacter;
    public Animator copzombieanimator;
    public BoxCollider bc;
    public SphereCollider meteorcollider;
    public GameObject dondurdu;
    public ParticleSystem lighted;
    NavMeshAgent nmesh;
    // Start is called before the first frame update
    void Start()
    {
        lighted.Stop();
        rb = GetComponent<Rigidbody>();
        dondurdu.SetActive(false);
        bc = GetComponent<BoxCollider>();
        //PlayerPrefs.DeleteKey("öldü")
        nmesh = GetComponent<NavMeshAgent>();
        copzombieanimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (nmesh.SetDestination(maincharacter.transform.position - new Vector3(0.5f, 0f, 0f)))

        {
            copzombieanimator.SetBool("run", true);
        }

        if (Vector3.Distance(copzombie.transform.position, maincharacter.transform.position) < 3f)
        {

            copzombieanimator.SetBool("atak", true);
        }
        else
        {
            copzombieanimator.SetBool("atak", false);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Wolff")
        {
            nmesh.enabled = false;
            copzombieanimator.SetBool("run", false);
            copzombieanimator.SetBool("atak", false);
            copzombieanimator.SetBool("die", true);
            bc.enabled = false;
        }
        if (other.gameObject.tag == "freezer")
        {
            Destroy(other.gameObject);
            bc.enabled = false;
            nmesh.enabled = false;
            dondurdu.SetActive(true);
            rb.constraints = RigidbodyConstraints.FreezePosition;
            copzombieanimator.enabled = false;
        }
        if (other.gameObject.tag == "throwable")
        {
            bc.enabled = false;
            nmesh.enabled = false;
            copzombieanimator.SetBool("atak", false);
            copzombieanimator.SetBool("run", false);
            copzombieanimator.SetBool("die", true);
            //Destroy(this.gameObject);

        }
        if (other.gameObject.tag == "lightning")
        {
            Destroy(other.gameObject);
            bc.enabled = false;
            nmesh.enabled = false;
            copzombieanimator.enabled = false;
            rb.constraints = RigidbodyConstraints.FreezePosition;
            lighted.Play();
        }
        if (other.gameObject.name == "kalkan")
        {
            bc.enabled = false;
            nmesh.enabled = false;
            
            copzombieanimator.SetBool("atak", false);
            copzombieanimator.SetBool("run", false);
            copzombieanimator.SetBool("die", true);
        }
        if (other.gameObject.tag=="donertekme")
        {
            bc.enabled = false;
            nmesh.enabled = false;

            copzombieanimator.SetBool("atak", false);
            copzombieanimator.SetBool("run", false);
            copzombieanimator.SetBool("die", true);
        }
    }
}
