using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    public AudioSource collisionSound;
    bool soundWasPlayed;

    // Start is called before the first frame update
    void Start()
    {
        soundWasPlayed = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (!soundWasPlayed)
        {
            collisionSound.Play();
            soundWasPlayed = true;
        }
        Info.Instance.poOpadnieciu = true;
        Info.Instance.wykonywanyRuch = false;
    }
}
