using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rockmovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        transform.Rotate(10, 0, 0);
        transform.Translate(0.4f, 0, 0 * Time.deltaTime);
    }
}
