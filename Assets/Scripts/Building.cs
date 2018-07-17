using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Building", menuName = "Buildings")]
public class Building : ScriptableObject
{

	[SerializeField] new string name;
	[SerializeField] bool housing;
	[SerializeField] bool storing;
	[SerializeField] bool producing;
	[SerializeField] bool consuming;
	[SerializeField] Ressource ressource;
	[SerializeField] int[] buildCost;

	void BuildCost()
	{

	}
}
