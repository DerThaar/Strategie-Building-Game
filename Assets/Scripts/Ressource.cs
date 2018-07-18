using UnityEngine;

public class Ressource : MonoBehaviour
{
	public Resource resource;
	int[] storedGoods;


	public int GetStoredGoods(Resource res)
	{
		return storedGoods[(int)res];
	}
}

public enum Resource
{
	Wood,
	Stone,
	Iron,
	Fish,
	Potato,
	Beef,
	Wheet,
	Flour,
	Bread,
}

