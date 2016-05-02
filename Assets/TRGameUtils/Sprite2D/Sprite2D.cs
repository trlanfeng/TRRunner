using UnityEngine;
using System.Collections;
[ExecuteInEditMode]
[RequireComponent(typeof(SpriteRenderer))]
public class Sprite2D : MonoBehaviour
{
    SpriteRenderer SR;
    public Vector2 originalSize;
    public Vector2 realSize;
    public float Up;
    public float Down;
    public float Left;
    public float Right;
    public Vector2 size;
    // Use this for initialization
    void Start()
    {
        SR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        getSpriteSize();
        getSpriteCorner();
    }

    void getSpriteSize()
    {
        float x = SR.sprite.bounds.size.x * 100;
        float y = SR.sprite.bounds.size.y * 100;
        originalSize = new Vector2(x, y);
        float rx = SR.bounds.size.x * 100;
        float ry = SR.bounds.size.y * 100;
        realSize = new Vector2(rx, ry);
    }

    void getSpriteCorner()
    {
        float w = SR.sprite.pivot.x;
        float h = SR.sprite.pivot.y;
        Up = (transform.position.y + h * 0.01f) * transform.localScale.y;
        Down = (transform.position.y - h * 0.01f) * transform.localScale.y;
        Left = (transform.position.x - w * 0.01f) * transform.localScale.x;
        Right = (transform.position.x + w * 0.01f) * transform.localScale.y;
    }

    public void setSize()
    {
        if (size.x > 0 && size.y > 0)
        {
            float sx = size.x / originalSize.x;
            float sy = size.y / originalSize.y;
            transform.localScale = new Vector3(sx, sy, 1);
        }
    }
}
