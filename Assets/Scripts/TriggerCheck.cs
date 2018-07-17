using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCheck : MonoBehaviour
{
	List<GameObject> nearbyBuildings = new List<GameObject>();
	public bool triggered;


	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Building"))
		{
			nearbyBuildings.Add(other.gameObject);
			triggered = true;
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.CompareTag("Building"))
		{
			nearbyBuildings.Remove(other.gameObject);
			if(nearbyBuildings.Count == 0)
			{
				triggered = false;
			}
		}
	}
}
