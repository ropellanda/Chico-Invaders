using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvaderScript : MonoBehaviour
{
    public float lenght = 9;
    public LayerMask player;

    public GameObject missile;
    public GameObject invaderGroup;

    public float raycastOffset = 4;

    private bool canShoot = true;
    private bool canMove = true;

    private void Start()
    {
        invaderGroup = GameObject.FindGameObjectWithTag("Group");
        StartCoroutine(Move());
    }

    public void FixedUpdate()
    {
        RaycastHit2D ray = Physics2D.Raycast(transform.position + new Vector3(0, raycastOffset, 0), Vector2.down, lenght);
        Debug.DrawRay(transform.position + new Vector3(0, raycastOffset, 0), Vector2.down * 10);

        if(ray.collider != null)
        {
            if (ray.collider.CompareTag("Player"))
            {
                TryShooting();
            }
        }

    }

    private void Update()
    {
        if (canMove)
        {
            canMove = false;
            TestPosition();
            StartCoroutine(Move());
        }
    }

    void TryShooting()
    {
        if (canShoot == true)
        {
           StartCoroutine(Shoot());
        }
    }

    private IEnumerator Shoot()
    {
        if (PlayerPrefs.GetInt("Hardcore") == 0)
        {
            Debug.Log("Normal");
            int randomNumber = Random.Range(0, 4);
            if (randomNumber == 1)
            {
                Debug.Log("Shooted");
                Instantiate(missile, transform.position - new Vector3(0, 1, 0), transform.rotation);
            }
            canShoot = false;
            yield return new WaitForSeconds(1);
            canShoot = true;
        } else
        {
            Debug.Log("Hardcore");
            int randomNumber = Random.Range(0, 2);
            if (randomNumber == 1)
            {
                Debug.Log("Shooted");
                Instantiate(missile, transform.position - new Vector3(0, 1, 0), transform.rotation);
            }
            canShoot = false;
            yield return new WaitForSeconds(0.5f);
            canShoot = true;
        }
    }

    private IEnumerator Move()
    {
        yield return new WaitForSeconds(2);
        canMove = true;
    }

    void TestPosition()
    {
        if (invaderGroup.transform.position.x == -3)
        {
            invaderGroup.transform.position = new Vector3(3, invaderGroup.transform.position.y, 0);
        }
        else
        {
            invaderGroup.transform.position = new Vector3(invaderGroup.transform.position.x - 0.5f, invaderGroup.transform.position.y, invaderGroup.transform.position.z);
        }
    }
}
