using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] monsterReference;

    private GameObject spawnedMonster;

    [SerializeField]
    private Transform leftPos, rightPos;

    private int randomIndex;
    private int randomSide;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnMonsters());
    }

    IEnumerator SpawnMonsters() // Every new enemy is generated every 1-5 seconds
    {
        while (true) // Run forever
        {
            Debug.Log("Inicio del juego");
            yield return new WaitForSeconds(Random.Range(1, 5)); // Makes the game uncrasheable

            randomIndex = Random.Range(1, monsterReference.Length);
            randomSide = Random.Range(0, 2);

            spawnedMonster = Instantiate(monsterReference[randomIndex]); // the kind of monster that will appear
            spawnedMonster.transform.position = leftPos.position;
            
            if (randomSide == 0) // Spawns a monster to the left side
            {
                spawnedMonster.transform.position = leftPos.position;
                spawnedMonster.GetComponent<Monster>().speed = 5; // null reference exception when it spawns enemy 1
            }

            else // Spawns a monster to the right side
            {
                spawnedMonster.transform.position = rightPos.position;
                spawnedMonster.GetComponent<Monster>().speed = -Random.Range(4, 10);
                spawnedMonster.transform.localScale = new Vector3(-1f, 1f, 1f); // Changes the direction the monster is facing
            } 
        }
    }
}
