using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEditor;

public class TileAutomata : MonoBehaviour
{
    [Range(0, 100)]
    public int initChance;

    [Range(1, 8)]
    public int birthLimit;

    [Range(1, 8)]
    public int deathLimit;

    [Range(1, 10)]
    public int numR;
    private int count = 0;

    private int[,] terrainMap;
    public Vector3Int tmapSize;


    public Tilemap topMap;
    public Tilemap botMap;
    public Tile topTile;
    public Tile botTile;

    int width;
    int height;

    public void doSim(int numR)
    {
        ClearMaps(false);
        width = tmapSize.x;
        height = tmapSize.y;

        if(terrainMap == null)
        {
            terrainMap = new int[width, height];
            initPos();
        }

        for(int i = 0; i < numR; i++)
        {
            terrainMap = genTilePos(terrainMap);
        }
        for(int x = 0; x < width; x++)
        {
            for(int y = 0; y < height; y++)
            {
                if (terrainMap[x, y] == 1)
                    topMap.SetTile(new Vector3Int(-x + width / 2, -y + height / 2, 0), topTile);
                    botMap.SetTile(new Vector3Int(-x + width / 2, -y + height / 2, 0), botTile);
            }
        }
    }
    public int[,] genTilePos(int [,] oldMap)
    {
        int[,] newMap = new int[width, height];
        int neighb;
        BoundsInt myB = new BoundsInt(-1, -1, 0, 3, 3, 1);

        for(int x=0; x<width; x++)
        {
            for(int y = 0; y<height; y++)
            {
                neighb = 0;
                foreach(var b in myB.allPositionsWithin)
                {
                    if (b.x == 0 && b.y == 0) continue;
                    if(x+b.x >= 0 && x + b.y < width && y + b.y >= 0 && y + b.y < height)
                    {
                        neighb += oldMap[x + b.x, y + b.y];
                    }
                    else
                    {
                        neighb++;
                    }

                }
                if (oldMap[x, y] == 1)
                {
                    if (neighb < deathLimit) newMap[x, y] = 0;
                    else
                    {
                        newMap[x, y] = 1;
                    }
                }
                if (oldMap[x, y] == 0)
                {
                    if (neighb >birthLimit ) newMap[x, y] = 1;
                    else
                    {
                        newMap[x, y] = 0;
                    }
                }

            }
        }
        

        return newMap;
    }
    public void initPos()
    {
        for(int x = 0; x < width; x++)
        {
            for(int y = 0; y < height; y++)
            {
                terrainMap[x, y] = Random.Range(1, 101) < initChance ? 1 : 0;
            }
        }
    }
    public void ClearMaps(bool complete)
    {
        topMap.ClearAllTiles();
        botMap.ClearAllTiles();

        if (complete)
        {
            terrainMap = null;
        }
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            doSim(numR);
        }
        if (Input.GetMouseButtonDown(1)){
            ClearMaps(true);
        }
        if (Input.GetMouseButtonDown(2))
        {
            SaveAssetMap();
            count++;
        }
    }

    private void SaveAssetMap()
    {
        string saveName = "tMapXY_" + count;
        var mf = GameObject.Find("Grid");
        if (mf)
        {
            var savePath = "Assets/" + saveName + ".prefab";
            if(PrefabUtility.CreatePrefab(savePath, mf))
            {
                EditorUtility.DisplayDialog("Tilemap Saved", "Your Tilemap was saved under" + savePath, "Continue");
            }
            else
            {
                EditorUtility.DisplayDialog("Tilemap NOT  Saved", "An ERROR occured while trying to save Tilemap under" + savePath, "Continue");
            }
        }
    }
}
