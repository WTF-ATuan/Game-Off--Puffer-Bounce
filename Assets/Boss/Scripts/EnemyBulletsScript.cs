using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletsScript : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D rd;
    public float force;
    private float timer; 
    // Start is called before the first frame update
    void Start()
    {
        rd = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");

        Vector3 direction = player.transform.position - transform.position;
        rd.velocity= new Vector2(direction.x, direction.y).normalized * force;

        float rot =Mathf.Atan2(-direction.y , -direction.x)*Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0,0,rot );  
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime; 

        if (timer > 10) {
            Destroy(gameObject);

        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
        
    }
}
