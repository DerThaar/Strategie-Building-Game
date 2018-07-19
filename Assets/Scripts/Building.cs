using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Building : MonoBehaviour
{
	[SerializeField] GlobalStorage gS;
	[SerializeField] int[] resourcesToBuild;
	[SerializeField] Resource[] resources;
	bool canBeBuilt;
	int trueCounter;


	void Update()
	{
		for (int i = 0; i < resourcesToBuild.Length; i++)
		{
			if (gS.storedGoods[(int)resources[i]] >= resourcesToBuild[i])
			{
				trueCounter++;
			}

			if (trueCounter == resourcesToBuild.Length)
			{
				canBeBuilt = true;
				trueCounter = 0;
			}

			else
				canBeBuilt = false;
		}

		print(canBeBuilt);
	}
}
