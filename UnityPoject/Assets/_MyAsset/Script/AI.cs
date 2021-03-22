using UnityEngine;
using System.Collections;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class AI : MonoBehaviour
{
    enum AiSTate
    {
        Roaming,
        chasing
    }

    AiSTate state = AiSTate.Roaming;
    Vector3 basePos;
    GameObject player;
    UnityEngine.AI.NavMeshAgent agent;

    public float wanderRadius;
    public float wanderTimer;

    private Transform target;
    private float timer;

    public Renderer rend;
    Vector4 effectValue = new Vector4(0.1f, 0.1f, 0.2f, 0.1f);
    Vector4 resetValue = new Vector4(0f, 0f, 0.2f, 0.1f);
    Vector4 currentEffectValue = new Vector4(0f, 0f, 0.2f, 0.1f);

    void Awake()
    {
        basePos = transform.position;
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

	// Use this for initialization
	void OnEnable ()
    {
        state = AiSTate.Roaming;
        transform.position = basePos;
        timer = wanderTimer;
        Disappear();
    }
	
	// Update is called once per frame
	void Update ()
    {
        rend.material.SetVector("_IntensityAndScrolling", currentEffectValue);

        switch (state)
        {
            case AiSTate.Roaming:
                UpdateRoaming();
                break;
            case AiSTate.chasing:
                agent.destination = player.transform.position;
                break;
            default:
                break;
        }
    }

    public void BeginChase()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (!player)
        {
            Debug.Log("Make sure your player is tagged!!");
        }
        state = AiSTate.chasing;
    }

    // Update is called once per frame
    void UpdateRoaming()
    {
        timer += Time.deltaTime;

        if (timer >= wanderTimer)
        {
            Vector3 newPos = RandomNavSphere(transform.position, wanderRadius, -1);
            agent.SetDestination(newPos);
            timer = 0;
        }
    }

    public Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask)
    {
        Vector3 randDirection = Random.insideUnitSphere * dist;

        randDirection += origin;

        UnityEngine.AI.NavMeshHit navHit;

        UnityEngine.AI.NavMesh.SamplePosition(randDirection, out navHit, dist, layermask);

        return navHit.position;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, wanderRadius);
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
            BeginChase();
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    public void Appear()
    {
        CancelInvoke();

        DOTween.To(() => currentEffectValue, x => currentEffectValue = x, effectValue, 2);
        Invoke("Disappear", 3f);
    }

    public void Disappear()
    {
        DOTween.To(() => currentEffectValue, x => currentEffectValue = x, resetValue, 2);
    }
}

