using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour
{
  [SerializeField] private float m_moveSpeed = 2;
  [SerializeField] private float m_rotationSpeed = 120;
  [SerializeField] private float attackRange = 0.5f;
  [SerializeField] private Animator m_animator = null;
  [SerializeField] private Rigidbody m_rigidBody = null;

  private UnityEngine.AI.NavMeshAgent navMeshAgent;
  private GameObject player;

  private void Awake()
  {
    if (!m_animator) { m_animator = gameObject.GetComponent<Animator>(); }
    if (!m_rigidBody) { m_rigidBody = gameObject.GetComponent<Rigidbody>(); }
    navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    player = GameObject.FindGameObjectWithTag("Player");
  }

  private void Update()
  {
    float speed = navMeshAgent.velocity.magnitude / m_moveSpeed;
    m_animator.SetFloat("MoveSpeed", Mathf.Lerp(m_animator.GetFloat("MoveSpeed"), speed, Time.deltaTime * 10));

    float rotationSpeed = m_rotationSpeed * Time.deltaTime;

    if (player != null)
    {
      float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
      if (distanceToPlayer <= attackRange)
      {
        navMeshAgent.isStopped = true;
        m_animator.SetTrigger("Attack");
      }
      else
      {
        navMeshAgent.isStopped = false;
        navMeshAgent.destination = player.transform.position;
        m_animator.ResetTrigger("Attack");
      }
    }
  }
}
