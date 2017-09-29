using UnityEngine;

public class CameraController : MonoBehaviour
{
	private Vector3 m_offset;

	[SerializeField]
	private Transform m_target;

	private void Start()
	{
		m_offset = m_target.position - transform.position;
	}

	private void LateUpdate()
	{
		transform.position = new Vector3(m_target.position.x - m_offset.x, transform.position.y, transform.position.z);
	}
}