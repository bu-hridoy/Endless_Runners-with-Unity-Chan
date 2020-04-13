using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour {

	public GameObject[] tilePrefabs;

	private Transform PlayerTransform;
	private float spawnZ = 6.0f;
	private float tilelength = 20.0f;
	private int anmTilesOnScreen = 4;
	private float safe = 20.0f;
	private List<GameObject> activeTile; 
	private int last = 0;
	// Use this for initialization
	private void Start () {
		activeTile = new List<GameObject> ();
		PlayerTransform = GameObject.FindGameObjectWithTag ("Player").transform;

		for (int i = 0; i < anmTilesOnScreen; i++) {
			if (i < 2)
				SpawnTile (0);
			else
				SpawnTile ();

		}

	}
	
	// Update is called once per frame
	private void Update () {
		if (PlayerTransform.position.z - safe > (spawnZ - anmTilesOnScreen * tilelength)) {
			SpawnTile ();
			DeleteTile ();
		}
	}

	private void SpawnTile(int prefabIndex = -1)
	{
		GameObject go;
		if (prefabIndex == -1)
			go = Instantiate (tilePrefabs [RandomIndex ()]) as GameObject;
		else
			go = Instantiate (tilePrefabs [prefabIndex]) as GameObject;
		

		go.transform.SetParent (transform);
		go.transform.position = Vector3.forward * spawnZ;

		spawnZ += tilelength;
		activeTile.Add (go);

	}

	private void DeleteTile()
	{
		Destroy (activeTile [0]);
		activeTile.RemoveAt (0);

	}

	private int RandomIndex()
	{
		if (tilePrefabs.Length <= 1)
			return 0;

		int random = last;
		while (random == last) {
			random = Random.Range (0, tilePrefabs.Length);
		}
		last = random;
		return random;
	}
}
