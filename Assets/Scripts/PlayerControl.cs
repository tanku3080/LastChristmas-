using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] SpriteAtlas[] atlas;
    SpriteAtlas[] sprite = null;

    void Start()
    {
        foreach (SpriteAtlas item in atlas)
        {
            sprite[sprite.Length].GetSprite(item.name);
            Debug.Log(sprite);
        }
        sprite[sprite.Length] = GetComponent<SpriteAtlas>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
