using UnityEditor;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{

    public float speed;
    public GameObject target;
    public GameObject entrance;
    GameObject currentTarget;
    public Animator animator;
    public ParticleSystem bloodParticles;
    public AudioSource zombieSound;
    public AudioClip[] AudioClip;
    bool deathSound;

    public float health;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentTarget = entrance;
        zombieSound.pitch = Random.Range(0.4f, 0.6f);
        zombieSound.clip = AudioClip[Random.Range(8, 11)];
        zombieSound.Play();
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

        //>gets hit
        //>fuckin dies lmao
        if (health <= 0)
        {
            if (!deathSound)
            {
                zombieSound.pitch = Random.Range(0.4f, 0.6f);
                zombieSound.clip = AudioClip[Random.Range(2, 7)];
                zombieSound.Play();
                deathSound = true;
            }
            animator.SetBool("isDead", true);
            currentTarget = gameObject;
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("RealDeath"))
            {
                Destroy(gameObject);
            }
        }
    }
    public void damage()
    {
        bloodParticles.Play();
        animator.SetTrigger("hurt");
        zombieSound.pitch = Random.Range(0.4f, 0.6f);
        zombieSound.clip = AudioClip[Random.Range(0, 1)];
        zombieSound.Play();
    }
}
