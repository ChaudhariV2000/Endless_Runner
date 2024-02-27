
using System.Collections;

using System.Collections.Generic;
using UnityEngine;

public class Tilemanager : MonoBehaviour
{
    public GameObject[] tileprefabs;
    public float zSpan = 0;
    public float titlelenght = 30;
    public int numberoftile = 6;
    private List<GameObject> activeTiles = new List<GameObject>();

    public Transform PlayerTransform;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < numberoftile; i++)
        {
            if (i == 0)
            {
                Spawntile(0);
            }
            else
            {
                Spawntile(Random.Range(0, tileprefabs.Length));
            }
        }

    }

    // Update is called once per frame
    void Update()
    {

        if (PlayerTransform.position.z - 35 > zSpan - (numberoftile * titlelenght))
        {
            Spawntile(Random.Range(0, tileprefabs.Length));
            DeleteTile();

        }


    }
    public void Spawntile(int tileindex)
    {

        GameObject go = Instantiate(tileprefabs[tileindex], transform.forward * zSpan, transform.rotation);
        activeTiles.Add(go);
        zSpan += titlelenght;
    }

    public void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }
}
