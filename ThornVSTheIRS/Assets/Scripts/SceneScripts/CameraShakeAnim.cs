using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;


public class CameraShakeAnim : MonoBehaviour
{

    public AudioClip crash;

     
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<CameraShaker>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShakeCamera()
    {
        CameraShaker.Instance.ShakeOnce(2f, 2f, .1f, 1f);  
    }

    public void PlaySound()
    {
        GetComponent<AudioSource>().PlayOneShot(crash);
    }
   
}
