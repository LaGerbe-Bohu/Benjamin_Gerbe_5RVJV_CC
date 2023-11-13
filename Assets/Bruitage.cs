using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bruitage : MonoBehaviour
{
    public AudioSource AS;

    private void OnCollisionEnter(Collision other)
    {
        AS.Play();
    }
}
