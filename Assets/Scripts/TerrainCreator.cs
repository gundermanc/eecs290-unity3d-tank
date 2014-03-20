using UnityEngine;
using System.Collections;

public class TerrainCreator : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		TerrainCreator.createEdges ();
		TerrainCreator.createCenter ();
		TerrainCreator.smooth ();
		TerrainCreator.addGrass ();
	}
	
	static void createEdges() {
		float[,] edgeHeights = new float[100, 100];
		for (int i = 0; i < 100; i++) {
			for(int j = 0; j < 100; j++) {
				edgeHeights[i,j] = Random.Range (0f, 0.5f);
			}
		}
		Terrain.activeTerrain.terrainData.SetHeights (0, 0, edgeHeights);
	}
	
	static void createCenter() {
		float[,] centerHeights = new float[90, 90];
		for(int i = 0; i < 90; i++) {
			for(int j = 0; j < 90; j++) {
				centerHeights[i,j] = Random.Range(0f, 0.05f);
			}
		}
		Terrain.activeTerrain.terrainData.SetHeights (5, 5, centerHeights);
	}
	
	static void smooth() {
		float[,] smoothHeights = new float[100, 100];
		for(int i = 0; i < 100; i++) {
			for(int j = 0; j < 100; j++) {
				if(i - 1 <= 0 && j + 1 >= 100) { //upper left corner
					smoothHeights[i,j] = 0.005f * (Terrain.activeTerrain.terrainData.GetHeight(i + 1, j) + Terrain.activeTerrain.terrainData.GetHeight(i, j - 1)) / 2;
				}
				else if(j + 1 >= 100) { //top edge
					smoothHeights[i,j] = 0.005f * (Terrain.activeTerrain.terrainData.GetHeight(i - 1, j) + Terrain.activeTerrain.terrainData.GetHeight(i, j - 1) + Terrain.activeTerrain.terrainData.GetHeight(i + 1, j)) / 3;
				}
				else if(i + 1 >= 100 && j + 1 >= 100) { //upper right corner
					smoothHeights[i,j] = 0.005f * (Terrain.activeTerrain.terrainData.GetHeight(i - 1, j) + Terrain.activeTerrain.terrainData.GetHeight(i, j - 1)) / 2;
				}
				else if(i + 1 >= 100) { //right edge
					smoothHeights[i,j] = 0.005f * (Terrain.activeTerrain.terrainData.GetHeight(i, j + 1) + Terrain.activeTerrain.terrainData.GetHeight(i - 1, j) + Terrain.activeTerrain.terrainData.GetHeight(i, j - 1)) / 3;
				}
				else if(i + 1 >= 100 && j - 1 <= 0) { //bottom right corner
					smoothHeights[i,j] = 0.005f * (Terrain.activeTerrain.terrainData.GetHeight(i, j + 1) + Terrain.activeTerrain.terrainData.GetHeight(i - 1, j)) / 2;
				}
				else if(j - 1 <= 0) { //bottom edge
					smoothHeights[i,j] = 0.005f * (Terrain.activeTerrain.terrainData.GetHeight(i - 1, j) + Terrain.activeTerrain.terrainData.GetHeight(i, j + 1) + Terrain.activeTerrain.terrainData.GetHeight(i + 1, j)) / 3;
				}
				else if(i - 1 <= 0 && j - 1 <= 0) { //bottom left corner
					smoothHeights[i,j] = 0.005f * (Terrain.activeTerrain.terrainData.GetHeight(i, j + 1) + Terrain.activeTerrain.terrainData.GetHeight(i + 1, j)) / 2;
				}
				else if(i - 1 <= 0) { //left edge
					smoothHeights[i,j] = 0.005f * (Terrain.activeTerrain.terrainData.GetHeight(i, j + 1) + Terrain.activeTerrain.terrainData.GetHeight(i + 1, j) + Terrain.activeTerrain.terrainData.GetHeight(i, j - 1)) / 3;
				}
				else { //middle points
					smoothHeights[i,j] = 0.005f * (Terrain.activeTerrain.terrainData.GetHeight(i - 1, j) + Terrain.activeTerrain.terrainData.GetHeight(i, j - 1) + Terrain.activeTerrain.terrainData.GetHeight(i, j + 1) + Terrain.activeTerrain.terrainData.GetHeight(i + 1, j)) / 4;
				}
			}
		}
		Terrain.activeTerrain.terrainData.SetHeights(0, 0, smoothHeights);
	}

	static void addGrass() {
		int[,] grass = new int[100, 100];
		for(int i = 0; i < 100; i++) {
			for(int j = 0; j < 100; j++) {
				grass[i,j] = (int)Random.Range (0, 2);
			}
		}
		Terrain.activeTerrain.terrainData.SetDetailLayer (0, 0, 0, grass);
	}
}