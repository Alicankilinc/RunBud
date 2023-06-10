using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    [SerializeField] AudioSource musicc;
    private void Awake()
    {
        DontDestroyOnLoad(this);
    }
    public void onMusic()
    {
        musicc.Play();
    }
    public void OffMusic()
    {
        musicc.Stop();
    }
}
