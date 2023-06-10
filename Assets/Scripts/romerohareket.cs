using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class romerohareket : MonoBehaviour
{
    public GameObject romero, maincharacter;
    public Animator romeroanimator;
    public BoxCollider bc;
    public SphereCollider meteorcollider;
    public GameObject dondurdu;
    public ParticleSystem lighted;
    Rigidbody rb;
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
        romeroanimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (nmesh.SetDestination(maincharacter.transform.position - new Vector3(0.5f, 0f, 0f)))

        {
            romeroanimator.SetBool("run", true);
        }

        if (Vector3.Distance(romero.transform.position, maincharacter.transform.position) < 3f)
        {

            romeroanimator.SetBool("atak", true);
        }
        else
        {
            romeroanimator.SetBool("atak", false);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Wolff")
        {
            nmesh.enabled = false;
            romeroanimator.SetBool("run", false);
            romeroanimator.SetBool("atak", false);
            romeroanimator.SetBool("die", true);
            bc.enabled = false;
            
        }
        if (other.gameObject.tag == "freezer")
        {
            Destroy(other.gameObject);
            bc.enabled = false;
            nmesh.enabled = false;
            dondurdu.SetActive(true);
            rb.constraints = RigidbodyConstraints.FreezePosition;
            romeroanimator.enabled = false;
            
        }
        if (other.gameObject.tag == "lightning")
        {
            Destroy(other.gameObject);
            bc.enabled = false;
            nmesh.enabled = false;
            romeroanimator.enabled = false;
            rb.constraints = RigidbodyConstraints.FreezePosition;
            lighted.Play();
        }

        if (other.gameObject.tag == "throwable")
        {
            bc.enabled=false;
            nmesh.enabled = false;
            romeroanimator.SetBool("atak", false);
            romeroanimator.SetBool("run", false);
            romeroanimator.SetBool("die", true);

        }
        if (other.gameObject.name == "kalkan")
        {
            bc.enabled = false;
            nmesh.enabled = false;
            
            romeroanimator.SetBool("atak", false);
            romeroanimator.SetBool("run", false);
            romeroanimator.SetBool("die", true);

        }
        if (other.gameObject.tag == "donertekme")
        {
            bc.enabled = false;
            nmesh.enabled = false;

            romeroanimator.SetBool("atak", false);
            romeroanimator.SetBool("run", false);
            romeroanimator.SetBool("die", true);
        }
    }
}
