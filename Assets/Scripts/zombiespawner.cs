using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombiespawner : MonoBehaviour
{
    public int spawncounter = 0;
    public int zombilicounter = 0;
    public GameObject zombie1, zombie2, zombie3, zombie4, zombie5, zombie6, zombie7, zombie8,zombie9;
    public GameObject canavar1, canavar2, canavar3, canavar4, canavar5;
    // Start is called before the first frame update
    void Start()
    {
        zombie1.SetActive(false); zombie2.SetActive(false);
        zombie3.SetActive(false); zombie4.SetActive(false);
        zombie5.SetActive(false); zombie6.SetActive(false);
        zombie7.SetActive(false); zombie8.SetActive(false);
        zombie9.SetActive(false);
        canavar1.SetActive(false);
        canavar2.SetActive(false);
        canavar3.SetActive(false);
        canavar4.SetActive(false);
        canavar5.SetActive(false);


    }

    // Update is called once per frame
    void Update()
    {
        if (spawncounter==1)
        {
            zombie1.SetActive(true);
           
        }
        if (spawncounter == 2)
        {
            zombie2.SetActive(true);
            
        }
        if (spawncounter == 3)
        {
            zombie3.SetActive(true);
        }
        if (spawncounter == 4)
        {
            zombie4.SetActive(true);
        }
        if (spawncounter == 5)
        {
            zombie5.SetActive(true);
        }
        if (spawncounter == 6)
        {
            zombie6.SetActive(true);
        }
        if (spawncounter == 7)
        {
            zombie7.SetActive(true);
        }
        if (spawncounter == 8)
        {
            zombie8.SetActive(true);
        }
        if (spawncounter == 9)
        {
            zombie9.SetActive(true);
        }
        if (zombilicounter ==1)
        {
            canavar1.SetActive(true);
        }
        if (zombilicounter == 2)
        {
            canavar2.SetActive(true);
        }
        if (zombilicounter == 3)
        {
            canavar3.SetActive(true);
        }
        if (zombilicounter == 4)
        {
            canavar4.SetActive(true);
        }
        if (zombilicounter == 5)
        {
            canavar5.SetActive(true);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="zombici")
        {
            spawncounter++;
        }
        if (other.gameObject.name=="sifirlayici")
        {
            spawncounter = 0;
        }
        if (other.gameObject.tag=="zombili")
        {
            zombilicounter++;
        }
        if (other.gameObject.tag=="sifirladi")
        {
            zombilicounter = 0;
        }
    }
}
