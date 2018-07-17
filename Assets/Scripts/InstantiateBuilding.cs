using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateBuilding : MonoBehaviour
{	
	[SerializeField] GameObject[] prefab;
	bool build;
	bool canBuild = true;
	Vector3 rotate = new Vector3(0f, 90f, 0f);
	Vector3 position;
	Color color;
	GameObject newBuilding;
	GameObject currentBuilding;	


	void Update()
	{
		if (Input.GetButtonDown("Mouse Right") && newBuilding != null)
		{
			Destroy(currentBuilding);
			build = false;			
		}

		if (Input.GetKeyDown(KeyCode.R) && currentBuilding != null)
		{
			currentBuilding.transform.Rotate(rotate);			
		}
		if (Input.GetKeyDown(KeyCode.T) && currentBuilding != null)
		{
			currentBuilding.transform.Rotate(-rotate);		
		}

		if (build)
		{
			RaycastHit hitInfo;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			Physics.Raycast(ray, out hitInfo, Mathf.Infinity, LayerMask.GetMask("Terrain"));
			position = hitInfo.point;

			if (Input.GetButtonUp("Mouse Left") && canBuild)
			{
				foreach (Transform child in currentBuilding.transform)
				{
					color = child.GetComponent<Renderer>().material.color;
					color = Color.white;					
					child.GetComponent<Renderer>().material.color = color;
				}

				currentBuilding = Instantiate(newBuilding, hitInfo.point, currentBuilding.transform.rotation);				
			}

			if (currentBuilding.GetComponent<TriggerCheck>().triggered)
			{
				canBuild = false;
				foreach (Transform child in currentBuilding.transform)
				{
					color = child.GetComponent<Renderer>().material.color;
					color = Color.red;					
					child.GetComponent<Renderer>().material.color = color;
				}
			}
			else
			{
				foreach (Transform child in currentBuilding.transform)
				{
					canBuild = true;
					color = child.GetComponent<Renderer>().material.color;
					color = Color.green;					
					child.GetComponent<Renderer>().material.color = color;
				}
			}
		}
	}

	void LateUpdate()
	{
		if (currentBuilding != null)
		{
			float gridSize = 1f;
			Vector3 snapPos;
			snapPos.x = Mathf.Floor(position.x / gridSize) * gridSize;			
			snapPos.z = Mathf.Floor(position.z / gridSize) * gridSize;
			snapPos.y = position.y;
			currentBuilding.transform.position = snapPos;
		}
	}

	void Instantiate()
	{		
		build = true;
		currentBuilding = Instantiate(newBuilding);

		foreach (Transform child in currentBuilding.transform)
		{
			color = child.GetComponent<Renderer>().material.color;
			color = Color.green;			
			child.GetComponent<Renderer>().material.color = color;
		}		
	}

	public void BuildNewHouse()
	{
		newBuilding = prefab[0];		
		Instantiate();
	}

	public void BuildNewMill()
	{
		newBuilding = prefab[1];		
		Instantiate();
	}	
}
