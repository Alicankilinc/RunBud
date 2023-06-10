using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class GravityFix : MonoBehaviour
{
    
    Rigidbody rrb;
    // Start is called before the first frame update
    void Start()
    {
        rrb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 gravity = Physics.gravity;
        Vector3 invertedGravitry = gravity * -1f;
        rrb.AddForce(invertedGravitry, ForceMode.Acceleration);

    }

}
