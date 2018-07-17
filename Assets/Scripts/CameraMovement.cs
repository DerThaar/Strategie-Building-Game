using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
	public GUIStyle style;
	[SerializeField] float moveSpeed;
	[SerializeField] float scaleSpeed;
	[SerializeField] float rotateSpeed;
	[SerializeField] Transform camTarget;
	[SerializeField] LayerMask mask;

	float scaleAmount;


	void Update()
	{
		Move();
		Rotate();
		CheckHeight();
		Scale();
	}

	void Move()
	{
		Vector3 move = Vector3.zero;
		float h = 0f;
		float v = 0f;

		if (Input.GetButton("Mouse Left"))
		{
			h = -(Input.GetAxis("Mouse X")) * 2f;
			v = -(Input.GetAxis("Mouse Y")) * 2f;		
		}
		else
		{
			h = Input.GetAxis("Horizontal");
			v = Input.GetAxis("Vertical");
		}

		move = new Vector3(h, 0f, v) * moveSpeed * Time.deltaTime;		
		transform.Translate(move);
	}

	void Scale()
	{
		float scale = Input.GetAxis("Mouse ScrollWheel");
		Vector3 distance = transform.position - camTarget.position;
		scaleAmount += scale * scaleSpeed;
		scaleAmount = Mathf.Clamp(scaleAmount, 0f, distance.magnitude - 8f);
		Transform camPos = transform.GetChild(0).transform;
		Vector3 newPos = transform.position + (camPos.forward * scaleAmount);
		camPos.position = Vector3.Lerp(camPos.position, newPos, Time.deltaTime * 10f);

	}

	void Rotate()
	{
		if (Input.GetButton("Mouse WheelButton"))
		{
			float h = Input.GetAxis("Mouse X");
			Vector3 rotate = new Vector3(0f, h, 0f);
			transform.RotateAround(camTarget.position, rotate, rotateSpeed);
		}
	}

	void CheckHeight()
	{
		Transform camPos = transform.GetChild(0).transform;
		RaycastHit hit;
		if (Physics.Raycast(camPos.position, Vector3.down, out hit, Mathf.Infinity, mask))
		{
			Vector3 distance = camPos.position - hit.point;
			if (distance.magnitude <= 3f)
			{
				//Vector3 correction = new Vector3(transform.position.x, transform.position.y + 0.1f, transform.position.z);
				//transform.position = Vector3.Lerp(transform.position, correction, Time.deltaTime);
				transform.position += new Vector3(0f, 0.08f, 0f);
				//camPos.position = new Vector3(transform.position.x, hit.point.y + 0.04f, transform.position.z);
			}
		}
	}
}
