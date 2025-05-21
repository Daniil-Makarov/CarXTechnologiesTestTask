using UnityEngine;

public class Monster : MonoBehaviour {
	private const float m_reachDistance = 0.09f;
	
	[SerializeField] private float m_speed = 0.1f;
	[SerializeField] private int m_maxHP = 30;
	[SerializeField] private Rigidbody m_rigidbody;
	
	private int m_hp;
	private Transform m_target;
	private Vector3 m_targetPosition;

	private void Start() => m_hp = m_maxHP;

	private void FixedUpdate() => m_rigidbody.MovePosition(Vector3.MoveTowards(transform.position, m_targetPosition, m_speed * Time.fixedDeltaTime));

	private void OnTriggerEnter(Collider other) {
		if (other.transform == m_target)
			Destroy(gameObject);
	}

	public void SetTarget(Transform target) {
		m_target = target;
		m_targetPosition = target.position;
		m_targetPosition.y = transform.position.y;
	}

	public void TakeDamage(int damage) {
		m_hp -= damage;

		if (m_hp <= 0)
			Destroy(gameObject);
	}
}
