using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyhareket : MonoBehaviour
{
    public GameObject enemy,maincharacter,dondurdu;
    public Animator enemyanimator,wolfanim;
    public BoxCollider bc;
    public SphereCollider meteorcollider;
    public CapsuleCollider lightningcollider;
    public ParticleSystem lighted;
    Rigidbody rb;
    NavMeshAgent nmesh;
    // Start is called before the first frame update
    void Start()
    {
        lighted.Stop();
        dondurdu.SetActive(false);
        rb = GetComponent<Rigidbody>();
        bc= GetComponent<BoxCollider>();
        //PlayerPrefs.DeleteKey("öldü")
        nmesh = GetComponent<NavMeshAgent>();
        enemyanimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (nmesh.SetDestination(maincharacter.transform.position - new Vector3(0.5f, 0f, 0f)))

        {
            enemyanimator.SetBool("run", true);
        }

        if (Vector3.Distance(enemy.transform.position, maincharacter.transform.position) < 5f)
        {
           
            enemyanimator.SetBool("atak", true);
        }
        else
        {
            enemyanimator.SetBool("atak", false);
        }

    }
   
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="Wolff")
        {
            nmesh.enabled = false;
            enemyanimator.SetBool("run", false);
            enemyanimator.SetBool("atak", false);
            enemyanimator.SetBool("die", true);
            bc.enabled = false;
        }
        if (other.gameObject.tag=="freezer")
        {
   
            Destroy(other.gameObject);
            bc.enabled = false;
            nmesh.enabled = false;
            dondurdu.SetActive (true);
            rb.constraints = RigidbodyConstraints.FreezePosition;
            enemyanimator.enabled=false;
        }
        if (other.gameObject.tag == "lightning")
        {
            Destroy(other.gameObject);
            bc.enabled = false;
            nmesh.enabled = false;
            enemyanimator.enabled = false;
            rb.constraints = RigidbodyConstraints.FreezePosition;
            lighted.Play();
        }
        if (other.gameObject.tag=="throwable")
        {
            nmesh.enabled = false;
           
            bc.enabled=false;
            enemyanimator.SetBool("atak", false);
            enemyanimator.SetBool("run", false);
            enemyanimator.SetBool("die", true);
            //Destroy(this.gameObject);
        }
        if (other.gameObject.name == "kalkan")
        {
            nmesh.enabled = false;
            
            bc.enabled = false;
            enemyanimator.SetBool("atak", false);
            enemyanimator.SetBool("run", false);
            enemyanimator.SetBool("die", true);
        }
        if (other.gameObject.tag == "donertekme")
        {
            bc.enabled = false;
            nmesh.enabled = false;

            enemyanimator.SetBool("atak", false);
            enemyanimator.SetBool("run", false);
            enemyanimator.SetBool("die", true);
        }
    }


    
}
