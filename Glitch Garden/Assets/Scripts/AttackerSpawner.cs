using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    bool spawn = true;
    [SerializeField] float baseMinSpawnDelay = 6f; // For setting the difficulty
    [SerializeField] float maxSpawnDelay = 10f; 
    float minSpawnDelay;
    [SerializeField] Attacker[] attackerArray;
    // Start is called before the first frame update
    IEnumerator Start() 
    {
        while (spawn == true)
        {
            minSpawnDelay = baseMinSpawnDelay - (2 * PlayerPrefsController.GetDifficulty()); //Difficulty setting
            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
            SpawnAttacker();
        }
    }
    
    public void StopSpawning()
    {
        spawn = false;
    }

    private void SpawnAttacker()
    {
              Attacker newAttacker = attackerArray[Random.Range(0,attackerArray.Length)];
              Spawn(newAttacker);
    }

    void Spawn(Attacker attacker)
    {      
        Attacker newAttacker = Instantiate(attacker, transform.position, Quaternion.identity);
        newAttacker.transform.parent = transform;
    }
}
