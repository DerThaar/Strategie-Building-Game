using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class GlobalStorage : MonoBehaviour
{
	[SerializeField] TMP_Text[] resourceText;
	public int[] storedGoods = new int[] { 80, 50, 60, 50, 10, 30, 60, 40, 190 };
	string[] resourceNames;


	public int GetStoredGoods(Resource res)
	{
		return storedGoods[(int)res];
	}


	void Update()
	{
		for (int i = 0; i < resourceText.Length; i++)
		{
			resourceText[i].text = storedGoods[i].ToString() + " " + (Resource)i;
		}
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

