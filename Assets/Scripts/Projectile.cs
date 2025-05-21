using System.Collections;
using UnityEngine;

public abstract class Projectile : MonoBehaviour {
	[SerializeField] protected float m_speed = 0.2f;
	[SerializeField] protected int m_damage = 10;
	
	[SerializeField] private float m_lifeTime = 2f;
	
	public float Speed => m_speed;

	private void Start() => StartCoroutine(DestroyAfterTime());

	private void OnTriggerEnter(Collider other) {
		if (other.TryGetComponent(out Monster monster)) {
			monster.TakeDamage(m_damage);
			Destroy(gameObject);
		}
	}
	
	private IEnumerator DestroyAfterTime() {
		yield return new WaitForSeconds(m_lifeTime);
		Destroy(gameObject);
	}
}