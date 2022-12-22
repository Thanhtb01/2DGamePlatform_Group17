using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D mybody; 
    private SpriteRenderer sprite;
    private Vector2 movement;
    private Vector2 mousePos;
    [SerializeField] Camera cam;

    void Awake()
    {
        mybody = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        movement = new Vector2();
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }
    private void FixedUpdate()
    {
        mybody.MovePosition(mybody.position + movement * speed * Time.fixedDeltaTime);
        Vector2 lookDir = mousePos - mybody.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        mybody.rotation = angle;
    }
}
