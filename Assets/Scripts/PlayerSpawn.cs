using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    public GameObject playerPrefab;
    public void Spawn()
    {
        if(playerPrefab) Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);
    }
}
