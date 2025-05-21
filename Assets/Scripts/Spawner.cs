using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spawner : MonoBehaviour {
	[SerializeField] private Monster m_monsterPrefab;
	[SerializeField] private float m_firstInterval = 1;
	[SerializeField] private float m_interval = 3;
	[SerializeField] private Transform m_moveTarget;

	private void Start() => StartCoroutine(SpawnLoop());

	private IEnumerator SpawnLoop() {
		yield return new WaitForSeconds(m_firstInterval);
		
		while (true) {
			Instantiate(m_monsterPrefab, transform.position, Quaternion.identity).SetTarget(m_moveTarget);
			yield return new WaitForSeconds(m_interval);
		}
	}
}
