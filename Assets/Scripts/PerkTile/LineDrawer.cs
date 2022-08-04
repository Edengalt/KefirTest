using System.Collections.Generic;
using UnityEngine;

public class LineDrawer : MonoBehaviour
{
    [SerializeField] private List<PerkTileBase> connected = new List<PerkTileBase>();
    [SerializeField] private LineRenderer linePrefab;

    public List<PerkTileBase> GetConnectedTiles()
    {
        return connected;
    }

    private void Awake()
    {
        if (linePrefab == null) return;
        for (int i = 0; i < connected.Count; i++)
        {
            if(connected[i] == null) continue;
            LineRenderer line = Instantiate(linePrefab, this.transform, true);
            line.SetPosition(0, transform.position);
            line.SetPosition(1, connected[i].transform.position);
        }
    }

    private void OnDrawGizmos()
    {
        for (int i = 0; i < connected.Count; i++)
        {
            if(connected[i] != null)
                Gizmos.DrawLine(transform.position,connected[i].transform.position);
        }
    }
}
