using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreamScript : MonoBehaviour
{
    public AudioSource scream;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L)) {
            scream.Play();
        }
    }
}
