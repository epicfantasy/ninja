using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public Vector3 mpos;
    public Vector3 dir;
    Rigidbody2D rb2d;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Move bullet
        if (rb2d.velocity.magnitude<10)
            rb2d.AddRelativeForce(new Vector2(0, 50));
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag=="d")
        {
            Destroy(this.gameObject);
        }
    }
}
