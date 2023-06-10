using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelspawn : MonoBehaviour
{
    public Transform Level1, Level2, Level3;
    Vector3 Level1pozisyon, Level2pozisyon, Level3pozisyon;
    Transform level1klon,level2klon,level3klon;
   
    // Start is called before the first frame update
    void Start()
    {
        
        
        Level1pozisyon= Level3.transform.position + new Vector3(610,0,0);
        Level2pozisyon= Level1.transform.position + new Vector3(607.93f,0,0);
        Level3pozisyon = Level2.transform.position + new Vector3(610.02f, 0, 0);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="level2getir")
        {
            level2klon = Instantiate(Level2, Level1pozisyon, Level1.transform.rotation);
        }
        if (other.gameObject.tag=="level3getir")
        {
            level3klon = Instantiate(Level2, Level3pozisyon, Level2.transform.rotation);
        }
        if (other.gameObject.tag=="level1getir")
        {
            level1klon = Instantiate(Level3, Level1pozisyon, Level3.transform.rotation);
        }
    }
}
