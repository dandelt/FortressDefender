using UnityEngine;
using UnityEngine.Tilemaps;

public class BrickWall : MonoBehaviour
{
    public Tilemap tilemap;

    public void TakeDamage(Vector3 hitPosition)
    {
        Vector3Int tilePosition = tilemap.WorldToCell(hitPosition);
        Vector3 worldPosition = tilemap.GetCellCenterWorld(tilePosition);

        if (tilemap.HasTile(tilePosition)) // Nếu có Tile ở vị trí này
        {
            //Debug.Log($"🔥 Xóa Tile tại Tilemap vị trí: {tilePosition} | World Position: {worldPosition}");
            tilemap.SetTile(tilePosition, null);
        }
        else
        {
            //Debug.Log($"❌ Không tìm thấy Tile tại {tilePosition} | World Position: {worldPosition}");
        }
    }
}