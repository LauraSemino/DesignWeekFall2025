using System.Threading;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    public Vector3 direction;
    public float speed;
    public float damage;
    public float despawnTimer;
    public AudioSource shootSound;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        despawnTimer = 10f;
        shootSound.pitch = Random.Range(0.8f, 1.2f);
        shootSound.Play();
    }

    // Update is called once per frame
    void Update()
    {
        //moves the projectile
        transform.position += direction.normalized * speed * Time.deltaTime;

        //despawns it after a while
        despawnTimer -= Time.deltaTime;
        if (despawnTimer <= 0) 
        {
            Destroy(gameObject);
        }

    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyAI>().health -= damage;
            collision.gameObject.GetComponent<EnemyAI>().damage();
        }
    }

}
