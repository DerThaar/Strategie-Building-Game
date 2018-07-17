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

	enum Storage
	{
		Materials, Consumables
	}

	Storage storage;

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
			storage = (Storage)EditorGUILayout.EnumPopup("Can store:", storage);
			ammountOfStorage = EditorGUILayout.IntField("Ammount Of Storage:", ammountOfStorage);
			EditorGUILayout.Space();
		}
		
		producing = EditorGUILayout.Toggle("Producing", producing);	
		consuming = EditorGUILayout.Toggle("Consuming", consuming);


	}	
}


