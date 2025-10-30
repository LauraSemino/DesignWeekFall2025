using UnityEngine;

public class EnemyAI : MonoBehaviour
{

    public float speed;
    public GameObject target;
    public GameObject entrance;
    GameObject currentTarget;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentTarget = entrance;
    }

    // Update is called once per frame
    void Update()
    {
        
        //targeting
        if ((transform.position - entrance.transform.position).magnitude <= 0.3f)
        {
            currentTarget = target;
        }


        Vector3 direction = currentTarget.transform.position - transform.position;
        Vector3 facing = direction.normalized;
     
        //standard movement
        transform.rotation = Quaternion.LookRotation(facing);
        transform.position += speed * Time.deltaTime * direction.normalized;
    }


}
