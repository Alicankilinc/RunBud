using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firexplosion : MonoBehaviour
{
    Rigidbody rb;
    SphereCollider sc;
    public ParticleSystem explode;
    public GameObject meteor;
    // Start is called before the first frame update
    void Start()
    {
        sc = GetComponent<SphereCollider>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "enemy")
        {
            //sc.enabled = false;
            //rb.constraints = RigidbodyConstraints.FreezePositionX;
            //rb.constraints = RigidbodyConstraints.FreezePositionZ;
            explode.Play();

        }

    }
}
