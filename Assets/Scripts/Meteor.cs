using UnityEngine;

public class Meteor : MonoBehaviour
{
	[SerializeField]
	private float m_speed;

	private Rigidbody2D m_rigidbody2D;

	private void Awake()
	{
		m_rigidbody2D = GetComponent<Rigidbody2D>();
	}

	private void FixedUpdate()
	{
		m_rigidbody2D.velocity = -transform.right * m_speed;
	}
}