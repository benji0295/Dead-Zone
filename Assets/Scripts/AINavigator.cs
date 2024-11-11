using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AINavigator : MonoBehaviour
{
  private UnityEngine.AI.NavMeshAgent navMeshAgent;
  private GameObject player;

  private void Start()
  {
    navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    player = GameObject.FindGameObjectWithTag("Player");
  }

  private void Update()
  {
    navMeshAgent.destination = player.transform.position;
  }
}
