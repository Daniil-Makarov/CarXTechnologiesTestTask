using System.Collections;
using UnityEngine;

public abstract class Tower : MonoBehaviour {
	[SerializeField] protected Projectile m_projectilePrefab;
	
	[SerializeField] private float m_shootInterval = 0.5f;
	[SerializeField] private float m_targetsCheckInterval = 0.1f;
	[SerializeField] private float m_range = 4f;
	[SerializeField] private LayerMask m_targetLayerMask;
	
	private Collider[] m_hitColliders = new Collider[1];

	private void Start() => StartCoroutine(ShootLoop());

	private IEnumerator ShootLoop() {
		while (true) {
			int targets = Physics.OverlapSphereNonAlloc(transform.position, m_range, m_hitColliders, m_targetLayerMask, QueryTriggerInteraction.Ignore);

			if (targets > 0) {
				Shoot(m_hitColliders[0]);
				yield return new WaitForSeconds(m_shootInterval);
			}
			else {
				yield return new WaitForSeconds(m_targetsCheckInterval);
			}
		}
	}

	protected abstract void Shoot(Collider target);
}