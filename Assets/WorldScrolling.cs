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
    [SerializeField] Vector2Int currentTile;
    [SerializeField] Vector2Int curPlayerTilePosition;

    [SerializeField] int terrainTileHorizontalCount;
    [SerializeField] int terrainTileVerticalCount;

    void Awake()
    {
        wholeHorizontalSize = tileSize * terrainTileHorizontalCount;
        wholeVerticalSize = tileSize * terrainTileVerticalCount;

        terrainTiles = new GameObject[terrainTileHorizontalCount, terrainTileVerticalCount];

        UpdatePlayerTilePos();
        currentTile = curPlayerTilePosition;
    }

    void Update()
    {
        UpdateTilePosition();
        UpdatePlayerTilePos();
    }

    void UpdateTilePosition()
    {
        if(currentTile != curPlayerTilePosition)
        {
            currentTile = curPlayerTilePosition;
            //循环遍历地块数组，移动到对应位置
            for(int x = 0; x < 3; x++)
            {
                for(int y = 0; y < 3; y++)
                {
                    Transform curTile = terrainTiles[x, y].transform;
                    Vector3 originPos = curTile.position;
                    float pos_x = curTile.position.x;
                    float pos_z = curTile.position.z;

                    Vector3 offPlayer = playerTransform.position - curTile.position;

                    //水平距离超过一半时移动到角色水平最前面
                    if(offPlayer.x > wholeHorizontalSize / 2)
                    {
                        curTile.position = new Vector3(pos_x + wholeHorizontalSize, 0, pos_z);
                    }else if(offPlayer.x < - wholeHorizontalSize / 2)
                    {
                        curTile.position = new Vector3(pos_x - wholeHorizontalSize, 0, pos_z);
                    }

                    //垂直距离超过所有地块边长一半时，移动到角色垂直最前方
                   if(offPlayer.z > wholeVerticalSize / 2)
                    {
                        curTile.position = new Vector3(pos_x, 0, pos_z + wholeVerticalSize);
                    }else if(offPlayer.z < - wholeVerticalSize / 2)
                    {
                        curTile.position = new Vector3(pos_x, 0, pos_z - wholeVerticalSize);
                    }

                    //判断地块是否改变，在改变地块上执行随机生成物品方法
                    if(originPos != curTile.position)
                    {
                        terrainTiles[x, y].GetComponent<TerrainTile>().Spawn();
                    }
                }
            }
              
        }
        
    }

    private void UpdatePlayerTilePos()
    {
        float pos_x = playerTransform.position.x;
        float pos_y = playerTransform.position.z;

        curPlayerTilePosition = new Vector2Int(
            (int)(terrainTileHorizontalCount + pos_x / tileSize % terrainTileHorizontalCount) % terrainTileHorizontalCount,
            (int)(terrainTileVerticalCount + pos_y / tileSize % terrainTileVerticalCount) % terrainTileVerticalCount);
    }

    public void Add(GameObject gameObject, Vector2Int tilePosition)
    {
        terrainTiles[tilePosition.x, tilePosition.y] = gameObject;
    }

}
