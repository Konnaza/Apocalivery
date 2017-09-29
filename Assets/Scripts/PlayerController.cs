using UnityEngine;

public class PlayerController : MonoBehaviour
{
	private Rigidbody2D m_rigidbody2D;

	[SerializeField]
	private float m_moveSpeed;

	[SerializeField]
	private float m_jumpSpeed;

	private bool m_isGrounded;
	private bool m_isJumping;

	private Animator m_animator;

	[SerializeField]
	private Transform m_groundCheckPos;

	[SerializeField]
	private Vector2 m_groundCheckSize;

	[SerializeField]
	private LayerMask m_groundLayermask;

	private void Awake()
	{
		m_rigidbody2D = GetComponent<Rigidbody2D>();
		m_animator = GetComponent<Animator>();
	}

	private void Update()
	{
		m_isJumping = Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow);
		m_rigidbody2D.velocity = new Vector2(m_moveSpeed, m_rigidbody2D.velocity.y);
		m_isGrounded = Physics2D.OverlapCapsule(transform.position - (Vector3.up * -0.2f), m_groundCheckSize, CapsuleDirection2D.Horizontal, 0f, m_groundLayermask);
	}

	private void FixedUpdate()
	{
		if (m_isJumping && m_isGrounded)
		{
			m_rigidbody2D.velocity = new Vector2(m_rigidbody2D.velocity.x, m_rigidbody2D.velocity.y + m_jumpSpeed);
		}

		if (m_rigidbody2D.velocity.y < -Mathf.Epsilon)
		{
			m_animator.SetBool("isFalling", true);
		}
		else
		{
			m_animator.SetBool("isFalling", false);
		}
	}
}