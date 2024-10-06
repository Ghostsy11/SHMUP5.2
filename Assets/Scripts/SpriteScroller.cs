using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteScroller : MonoBehaviour
{

    /// <summary>
    /// Parallax Scrolling System.
    /// </summary>
    [SerializeField] Vector2 moveSpeed;
    Vector2 offset;
    Material material;
    private void Awake()
    {
        material = GetComponent<SpriteRenderer>().material;
    }
    void Update()
    {
        offset = moveSpeed * Time.deltaTime;
        material.mainTextureOffset += offset;
    }

}
