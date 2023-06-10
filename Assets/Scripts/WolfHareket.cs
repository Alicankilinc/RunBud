using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WolfHareket : MonoBehaviour
{
    GameObject dusmann;
    NavMeshAgent nmesh;
    public float value = 20f;
    public GameObject Anakarakterr, enemmy,copzombie,warrok,romero, wolf;
    public Animator wolfanim;
    
   
    void Start()
    {
        GameObject dusmann = GameObject.FindWithTag("enemy");
        //PlayerPrefs.DeleteKey("enemydead");
        nmesh = GetComponent<NavMeshAgent>();
        wolfanim = GetComponent<Animator>();
        wolfanim.SetFloat("speed", 1);
        
        
    }

 
    void Update()
    {
        if (nmesh.SetDestination(enemmy.transform.position - new Vector3(0f, 1.5f, 0f)))
        {
            wolfanim.SetBool("kos", true);
        }

        if (Vector3.Distance(wolf.transform.position, enemmy.transform.position) < value)
        {
            wolfanim.SetBool("pence", true);
        }
        if (nmesh.SetDestination(copzombie.transform.position - new Vector3(0f, 1.5f, 0f)))
        {
            wolfanim.SetBool("kos", true);
        }

        if (Vector3.Distance(wolf.transform.position, copzombie.transform.position) < value)
        {
            wolfanim.SetBool("pence", true);
        }
        if (nmesh.SetDestination(romero.transform.position - new Vector3(0f, 1.5f, 0f)))
        {
            wolfanim.SetBool("kos", true);
        }

        if (Vector3.Distance(wolf.transform.position, romero.transform.position) < value)
        {
            wolfanim.SetBool("pence", true);
        }
        if (nmesh.SetDestination(warrok.transform.position - new Vector3(0f, 1.5f, 0f)))
        {
            wolfanim.SetBool("kos", true);
        }

        if (Vector3.Distance(wolf.transform.position, warrok.transform.position) < value)
        {
            wolfanim.SetBool("pence", true);
        }
        else
        {
            wolfanim.SetBool("pence", false);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "enemy")
        {

            wolfanim.SetBool("kos", false);
            wolfanim.SetBool("pence", false);
            wolfanim.SetBool("otur", true);
        }
    }
}
