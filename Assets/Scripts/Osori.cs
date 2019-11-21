using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Osori : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] GameObject Osorisprite;
    [SerializeField] float jumpVelocity;
    [SerializeField] float maxHeight;
    bool isDead;
    public bool IsDead
    {
        get
        {
            return isDead;
        }
    }
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if((Input.GetButtonDown("Fire1")) &&transform.position.y < maxHeight)
        {
            if(!IsDead&&rb.isKinematic==false)
            {
                rb.velocity = new Vector2(0.0f, jumpVelocity);
            }
        }
        float angle;
        if (IsDead)
        {
            angle = -90f; 
        }
        else
        {
            angle = Mathf.Atan2(rb.velocity.y, 10) * Mathf.Rad2Deg;
        }
        
        Osorisprite.transform.localRotation = Quaternion.Euler(0.0f, 0.0f, angle);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Camera.main.SendMessage("Shake", SendMessageOptions.DontRequireReceiver);
        isDead = true;
        GetComponentInChildren<CircleCollider2D>().isTrigger = true;
        GetComponent<Rigidbody2D>().gravityScale = 0;
    }
    public void SetKinematic(bool value)
    {
        rb.isKinematic = value;
    }
}
