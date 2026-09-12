using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class WorldScrolling : MonoBehaviour
{
    [SerializeField] Transform playerTransform;
    [SerializeField] float tileSize = 20f;
    float wholeHorizontalSize;
    float wholeVerticalSize;
    GameObject[,] terrainTiles;

    [SerializeField] int terrainTileHorizontalCount;
    [SerializeField] int terrainTileVerticalCount;

    void Awake()
    {
        wholeHorizontalSize = tileSize * terrainTileHorizontalCount;
        wholeVerticalSize = tileSize * terrainTileVerticalCount;

        terrainTiles = new GameObject[terrainTileHorizontalCount, terrainTileVerticalCount];
    }

    void Update()
    {
        UpdateTilePosition();
    }

    void UpdateTilePosition()
    {
        //循环遍历地块数组，判断是否在对应位置
        for(int x = 0; x < 3; x++)
        {
            for(int y = 0; y < 3; y++)
            {
                Transform curTile = terrainTiles[x, y].transform;
                float pos_x = curTile.position.x;
                float pos_z = curTile.position.z;

                Vector3 offPlayer = playerTransform.position - curTile.position;

                //水平距离超过一半时移动到角色水平最前面
                if(offPlayer.x > wholeHorizontalSize / 2)
                {
                    curTile.position = new Vector3(pos_x + wholeHorizontalSize, 0, curTile.position.z);
                }else if(offPlayer.x < - wholeHorizontalSize / 2)
                {
                    curTile.position = new Vector3(pos_x - wholeHorizontalSize, 0, curTile.position.z);
                }

                //垂直距离超过所有地块边长一半时，移动到角色垂直最前方
                if(offPlayer.z > wholeVerticalSize / 2)
                {
                    curTile.position = new Vector3(curTile.position.x, 0, pos_z + wholeVerticalSize);
                }else if(offPlayer.z < - wholeVerticalSize / 2)
                {
                    curTile.position = new Vector3(curTile.position.x, 0, pos_z - wholeVerticalSize);
                }
            }
        }
    }

    public void Add(GameObject gameObject, Vector2Int tilePosition)
    {
        terrainTiles[tilePosition.x, tilePosition.y] = gameObject;
    }

}
