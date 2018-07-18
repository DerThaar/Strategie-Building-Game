using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Building : MonoBehaviour
{
	[SerializeField] new string name;
	[SerializeField] bool housing;
	[SerializeField] bool storing;
	[SerializeField] bool producing;
	[SerializeField] bool consuming;
	[SerializeField] Resource[] resourcesToBuild;
	[SerializeField] int[] ammountOfBuildResources;

	private void Awake()
	{
		
	}

}
