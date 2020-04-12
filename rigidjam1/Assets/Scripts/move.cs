using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class move : MonoBehaviour
{
    public Sprite sp;
    public GameObject throwable;
    Rigidbody2D rb2d;
    bool isDead = false;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(isDead);
        if(collision.transform.tag=="bee")
        {
            isDead = true;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (!isDead)
        {
            float x = Input.GetAxis("Horizontal");
            float y = Input.GetAxis("Vertical");
            rb2d.velocity = new Vector2(x * 7, y * 7);
            GetComponent<Animator>().SetBool("da", x + y > 0 || x + y < 0);
            if (Input.GetMouseButtonDown(0))
            {
                GameObject newBullet = Instantiate(throwable);
                newBullet.transform.position = transform.position;
                Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
                diff.Normalize();

                float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
                newBullet.transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);


            }
        }
        else
        {
            Destroy(GetComponent<Animator>());
            GetComponent<SpriteRenderer>().sprite = sp;
            if(Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("SampleScene");
            }
        }
    }
}
