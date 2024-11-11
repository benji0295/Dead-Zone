using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System.Collections.Generic;

public class ZombieSpawner : MonoBehaviour
{
  public int zombieCount = 5;
  public float spawnRadius = 20f;
  public float detectionRadius = 20f;
  public GameObject zombiePrefab;
  public GameObject ground;

  private GameObject player;
  private List<GameObject> spawnedZombies = new List<GameObject>();
  private bool inRange = false;

  private void Start()
  {
    player = GameObject.FindGameObjectWithTag("Player");
    transform.position = ground.transform.position;

    StartCoroutine(CheckPlayerDistance());
  }

  private IEnumerator CheckPlayerDistance()
  {
    float distance = Vector3.Distance(player.transform.position, transform.position);

    if (distance <= detectionRadius && !inRange)
    {
      inRange = true;
      SpawnZombies();
    }
    else if (distance > detectionRadius && inRange)
    {
      inRange = false;
      DespawnZombies();
    }

    yield return new WaitForSeconds(0.5f);
  }

  private void SpawnZombies()
  {
    for (int i = 0; i < zombieCount; i++)
    {
      var zombiePosition = GetZombiePosition();
      GameObject zombie = Instantiate(zombiePrefab, zombiePosition, Quaternion.identity);
      spawnedZombies.Add(zombie);
    }
  }

  private void DespawnZombies()
  {
    foreach (GameObject zombie in spawnedZombies)
    {
      Destroy(zombie);
    }
    spawnedZombies.Clear();
  }

  private Vector3 GetZombiePosition()
  {
    float groundY = ground.transform.position.y;
    return new Vector3(
        Random.Range(-spawnRadius, spawnRadius),
        groundY,
        Random.Range(-spawnRadius, spawnRadius)
    );
  }
}
