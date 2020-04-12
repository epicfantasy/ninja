using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bee : MonoBehaviour
{
    public GameObject ded;
    float maxSpeed = 0;
    // Start is called before the first frame update
    void Start()
    {
        maxSpeed = Random.Range(2, 7);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 diff = GameObject.Find("ninja").transform.position - transform.position;
        diff.Normalize();

        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
        if (GetComponent<Rigidbody2D>().velocity.magnitude < maxSpeed)
        {
            GetComponent<Rigidbody2D>().drag=0;

            GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(0, 5));
        }
        else
            GetComponent<Rigidbody2D>().drag++;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag=="lol")
        {
            GameObject dead = Instantiate(ded);
            dead.transform.position = transform.position;
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
    }
}
