using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByTime : MonoBehaviour
{
    public float lifeTime;

    void Start () {
        Destroy (gameObject, lifeTime);
        AudioSource audio =  GetComponent <AudioSource>();
        if(audio) audio.pitch = Random.Range (0.75f, 1.25f);
    }
}
