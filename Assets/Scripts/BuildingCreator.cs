using UnityEngine;
using UnityEditor;

public class BuildingCreator : EditorWindow
{
	string buildingName;
	bool housing;
	bool storing;
	bool producing;
	bool consuming;
	bool materials;
	bool consumables;
	int ammountOfPeople;
	int ammountOfStorage;	
	GameObject model;
	Resource[] resource;
	int numberOfResources;


	[MenuItem("Window/BuildingCreator")]
	public static void ShowWindow()
	{
		GetWindow<BuildingCreator>("BuildingCreator");
	}

	void OnGUI()
	{
		GUILayout.Label("Create A Building", EditorStyles.boldLabel);
		EditorGUILayout.Space();
		buildingName = EditorGUILayout.TextField("Name:", buildingName);
		model = (GameObject)EditorGUILayout.ObjectField("Model:", model, typeof(GameObject));
		EditorGUILayout.Space();
		housing = EditorGUILayout.Toggle("Housing", housing);
		if (housing)
		{			
			ammountOfPeople = EditorGUILayout.IntField("Ammount Of People:", ammountOfPeople);
			EditorGUILayout.Space();
		}

		storing = EditorGUILayout.Toggle("Storing", storing);
		if (storing)
		{				
			ammountOfStorage = EditorGUILayout.IntField("Ammount Of Storage:", ammountOfStorage);
			numberOfResources = EditorGUILayout.IntField("Number of stored goods:", numberOfResources);
			for (int i = 0; i < numberOfResources; i++)
			{
				//resource[i] = (Resource)EditorGUILayout.EnumPopup("Can store:", resource);
			}
			EditorGUILayout.Space();
		}
		
		producing = EditorGUILayout.Toggle("Producing", producing);	
		consuming = EditorGUILayout.Toggle("Consuming", consuming);


	}	
}


