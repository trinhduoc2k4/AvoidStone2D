using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockSpawner : MonoBehaviour
{
    public GameObject[] rocks;
    private void Start()
    {
        //StartCoroutine(SpawnRock());
    }

    void Spawner()
    {
        int randomRock = Random.Range(0, rocks.Length);
        float randomPos = Random.Range(-7.5f, 7.5f);
        Instantiate(rocks[randomRock], new Vector3(randomPos, transform.position.y, transform.position.z), Quaternion.identity);    
    }

    public IEnumerator SpawnRock()
    {
        while (true)
        {
            yield return new WaitForSeconds(.3f);
            Spawner();
        }
    }
}
