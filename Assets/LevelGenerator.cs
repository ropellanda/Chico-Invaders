using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public GameObject invaderPrefab;
    public GameObject invaderGroup;

    public Vector2Int size;
    public Vector2 offset;

    private void Awake()
    {
        for (int i = 0; i < size.x; i++)
        {
            for (int j = 0; j < size.y; j++)
            {
                GameObject newInvader = Instantiate(invaderPrefab, transform);
                newInvader.transform.position = transform.position + new Vector3((float)((size.x - 1) * .5f - i) * offset.x, j * offset.y, 0);
                newInvader.transform.parent = invaderGroup.transform;
            }
        }
    }
}
