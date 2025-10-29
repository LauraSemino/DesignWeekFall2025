using UnityEngine;

public class EnemyAI : MonoBehaviour
{

    public float speed;
    public GameObject target;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = target.transform.position - transform.position;
        Vector3 facing = direction.normalized;

        transform.rotation = Quaternion.Euler(facing);
        transform.position += speed * Time.deltaTime * direction.normalized;
    }
}
