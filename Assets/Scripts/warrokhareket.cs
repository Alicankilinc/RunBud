using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class warrokhareket : MonoBehaviour
{
    Rigidbody rb;
    public GameObject warrok, maincharacter;
    public Animator warrokanimator;
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
        warrokanimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (nmesh.SetDestination(maincharacter.transform.position - new Vector3(0.5f, 0f, 0f)))

        {
            warrokanimator.SetBool("run", true);
        }

        if (bc.enabled == true)
        {
            if (Vector3.Distance(warrok.transform.position, maincharacter.transform.position) < 3f)
            {

                warrokanimator.SetBool("atak", true);
            }
        }
        
        else
        {
            warrokanimator.SetBool("atak", false);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Wolff")
        {
            nmesh.enabled = false;
            warrokanimator.SetBool("run", false);
            warrokanimator.SetBool("atak", false);
            warrokanimator.SetBool("die", true);
            bc.enabled = false;
        }
        if (other.gameObject.tag == "freezer")
        {
            
            Destroy(other.gameObject);
            bc.enabled = false;
            nmesh.enabled = false;
            dondurdu.SetActive(true);
            rb.constraints = RigidbodyConstraints.FreezePosition;
            warrokanimator.enabled = false;
        }
        if (other.gameObject.tag=="lightning")
        {
            Destroy(other.gameObject);
            bc.enabled = false;
            nmesh.enabled = false;
            warrokanimator.enabled=false;
            rb.constraints = RigidbodyConstraints.FreezePosition;
            lighted.Play();
        }
        if (other.gameObject.tag == "throwable")
        {
            bc.enabled= false;
            nmesh.enabled= false;
            warrokanimator.SetBool("atak", false);
            warrokanimator.SetBool("run", false);
            warrokanimator.SetBool("die", true);
        }
        if (other.gameObject.name == "kalkan")
        {

            bc.enabled = false;
            nmesh.enabled = false;
            warrokanimator.SetBool("atak", false);
            warrokanimator.SetBool("run", false);
            warrokanimator.SetBool("die", true);
        }
        if (other.gameObject.tag == "donertekme")
        {
            bc.enabled = false;
            nmesh.enabled = false;

            warrokanimator.SetBool("atak", false);
            warrokanimator.SetBool("run", false);
            warrokanimator.SetBool("die", true);
        }
    }
    
}
