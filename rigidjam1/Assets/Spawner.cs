using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject bee;
    float wave = 1;
    float num = 3;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawn());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator spawn()
    {
        yield return new WaitForSeconds(10);
        for (int i = 0; i <= num; i++)
        {
            GameObject newBee = Instantiate(bee);
            Vector2 pos = new Vector2(0, 0);
            int a = Random.Range(1, 4);
            if (a==1)
            {
                pos= new Vector2(-8, Random.Range(-8,8));
            }
            else if(a==2)
            {
                pos = new Vector2(8, Random.Range(-8, 8));
            }
            else if(a==3)
            {
                pos = new Vector2(Random.Range(-8, 8),8);
            }
            else
            {
                pos = new Vector2(Random.Range(-8, 8), -8);
            }
            newBee.transform.position = pos;
        }
        num += 2;
        StartCoroutine(spawn());
    }
}
