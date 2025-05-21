using UnityEngine;

public class GuidedProjectile : Projectile {
	private Transform m_target;
	
	private void Update() {
		if (!m_target) {
			Destroy(gameObject);
			return;
		}

		transform.position = Vector3.MoveTowards(transform.position, m_target.position, m_speed * Time.deltaTime);
	}
	
	public void SetTarget(Transform target) => m_target = target;
}