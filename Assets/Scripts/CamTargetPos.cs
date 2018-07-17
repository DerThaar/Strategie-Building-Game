using UnityEngine;

public class CamTargetPos : MonoBehaviour
{
	[SerializeField] Camera cam;
	[SerializeField] LayerMask mask;


	void Update()
	{		
		RaycastHit hit;
		if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, Mathf.Infinity, mask))
		{
			transform.position = hit.point;
		}
	}
}
