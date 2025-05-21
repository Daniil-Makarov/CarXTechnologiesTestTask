using UnityEngine;

public class CannonTower : Tower {
	[SerializeField] private int m_steps = 10;
	[SerializeField] private Transform m_shootPoint;
	[SerializeField] private Transform m_base;
	[SerializeField] private Transform m_cannon;

	protected override void Shoot(Collider target) {
		Vector3 targetPosition = target.transform.position;
		Rigidbody targetRigidbody = target.attachedRigidbody;
		Vector3 targetVelocity = targetRigidbody.velocity;

		Vector3 shootPosition = m_shootPoint.position;
		float projectileSpeed = m_projectilePrefab.Speed;

		float time = (targetPosition - shootPosition).magnitude / projectileSpeed;
		Vector3 intersection;

		for (int i = 0; i < m_steps; i++) {
			intersection = targetPosition + targetVelocity * time;
			float newTime = (intersection - shootPosition).magnitude / projectileSpeed;
		
			if (Mathf.Abs(newTime - time) < 0.01f)
				break;
		
			time = newTime;
		}

		intersection = targetPosition + targetVelocity * time;
		Vector3 direction = (intersection - shootPosition).normalized;
		m_base.forward = new Vector3(direction.x, 0, direction.z);
		m_cannon.forward = direction;

		Instantiate(m_projectilePrefab, m_shootPoint.position, Quaternion.LookRotation(direction));
	}
}