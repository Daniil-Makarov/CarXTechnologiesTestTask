using UnityEngine;

public class SimpleTower : Tower {
	protected override void Shoot(Collider target) {
		GuidedProjectile projectile = Instantiate(m_projectilePrefab, transform.position + Vector3.up * 1.5f, Quaternion.identity) as GuidedProjectile;
		projectile?.SetTarget(target.transform);
	}
}
