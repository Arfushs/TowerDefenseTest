using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TowerManager : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private GameObject _towerPlacementUI;

    [SerializeField] private Tilemap _map;

    [SerializeField] private TileBase _placableTile;
    
    
    void Update()
    {
        // if (Input.GetMouseButtonDown(0)) 
        // {
        //     Vector3 mouseWorldPos = _camera.ScreenToWorldPoint(Input.mousePosition);
        //     mouseWorldPos.z = 0;
        //     Vector3Int cellPosition = _map.WorldToCell(mouseWorldPos);
        //     
        //     if (_map.GetTile(cellPosition) == _placableTile)
        //     {
        //         _towerPlacementUI.SetActive(true);
        //     }
        // }
    }
    
    
}
