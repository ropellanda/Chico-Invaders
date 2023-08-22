using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float movementInput;
    public float speed = 5;
    private bool canFire = true;
    public float cooldownTimer = 0.6f;
    public GameObject missilePrefab;
    private float maxX = 8;

    public GameObject winPanel;
    public GameObject losePanel;
    public GameObject hardcorePanel;


    int invaderCount;

    private void Start()
    {
        Cursor.visible = false;
    }

    void Update()
    {
        movementInput = Input.GetAxisRaw("Horizontal");

        if ((movementInput > 0 && transform.position.x < maxX) || (movementInput < 0 && transform.position.x > -maxX))
        {
            gameObject.transform.Translate(Vector3.right * Time.deltaTime * movementInput * speed);
        }

        if (Input.GetKeyDown("x") && canFire)
        {
            Instantiate(missilePrefab, transform.position + new Vector3(0, 1, 0), Quaternion.Euler(new Vector3(0, 0, 90)));
            StartCoroutine(Cooldown());
        }

        invaderCount = FindObjectOfType<LevelGenerator>().transform.childCount;

        if (invaderCount == 0)
        {
            Win();
        }
    }

    private IEnumerator Cooldown()
    {
        canFire = false;
        yield return new WaitForSeconds(cooldownTimer);
        canFire = true;
    }

    void Win()
    {
        winPanel.SetActive(true);
        Cursor.visible = true;
        if (PlayerPrefs.GetInt("Hardcore") == 1)
        {
            Debug.Log("Beat Hardcore");
            hardcorePanel.SetActive(true);
        }
    }
}
