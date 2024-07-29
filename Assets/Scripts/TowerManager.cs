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
    
    private List<Vector3Int> towerPositions = new List<Vector3Int>();
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            Vector3 mouseWorldPos = _camera.ScreenToWorldPoint(Input.mousePosition);
            mouseWorldPos.z = 0;
            Vector3Int cellPosition = _map.WorldToCell(mouseWorldPos);
            
            if (IsTowerOnTile(cellPosition))
            {
                Debug.Log("Bu tile üzerinde zaten bir kule var.");
            }
            else
            {
                Debug.Log("Bu tile üzerine bir kule yerleştirilebilir.");
                PlaceTower(cellPosition);
            }
        }
    }
    
    private bool IsTowerOnTile(Vector3Int tilePosition)
    {
        return towerPositions.Contains(tilePosition);
    }

    
    private void PlaceTower(Vector3Int tilePosition)
    {
        towerPositions.Add(tilePosition);
    }
    
    
}
