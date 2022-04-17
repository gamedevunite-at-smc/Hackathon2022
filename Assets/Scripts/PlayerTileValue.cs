using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerTileValue : MonoBehaviour
{

    private new Transform transform;

    private Tilemap tilemap;

    [SerializeField] private List<Sprite> roadTiles;

    private bool onRoad = false;
    public bool OnRoad => onRoad;

    private void Awake()
    {
        transform = GetComponent<Transform>();

        tilemap = FindObjectOfType<Tilemap>();
    }

    private void Update()
    {

        var cell = tilemap.WorldToCell(transform.position);

        var sprite = tilemap.GetSprite(cell);

        onRoad = roadTiles.Contains(sprite);
    }
}
