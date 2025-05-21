using UnityEngine;

public class CannonProjectile : Projectile {
	private void Update() => transform.Translate(transform.forward * m_speed * Time.deltaTime, Space.World);
}
