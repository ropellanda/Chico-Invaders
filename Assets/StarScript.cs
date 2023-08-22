using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarScript : MonoBehaviour
{
    public GameObject stars;

    private void Start()
    {
        if (PlayerPrefs.GetInt("Stars") == 1)
        {
            stars.SetActive(true);
        }
    }
}
