using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAssets : MonoBehaviour
{
    public static ItemAssets Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public Sprite Pollen;
    public Sprite Fluff;
    public Sprite Grass;
    public Sprite Heal;
    public Sprite Projectile;

    public GameObject ItemPrefab;
    public GameObject ProjectilePrefab;
}
