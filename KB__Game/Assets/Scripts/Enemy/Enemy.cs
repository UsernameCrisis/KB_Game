using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float moveSpeed = 100;

    [Header("Destination")]
    [SerializeField] private float destRadius = 5f;
    [SerializeField] private float minDistToDest = 0.5f;

    [Header("Wait Timer")]
    [SerializeField] private float minWait = 1f;
    [SerializeField] private float maxWait = 3f;
    private EnemyState _currentState;
    private float waitTimer;
    private Vector2 dest;
    private bool hasCollided = false;
    enum EnemyState
    {
        Idle,
        Roaming
    }

    private EnemyState CurrentState
    {
        get { return _currentState; }
        set
        {
            if (_currentState == value) return;
            _currentState = value;

            switch (_currentState)
            {
                case EnemyState.Idle:
                    // All variable that is needed for idle state goes here
                    waitTimer = Random.Range(minWait, maxWait);
                    break;
                case EnemyState.Roaming:
                    // All variable that is needed for roaming state goes here
                    dest = DestinationRandomizer(transform.position, destRadius);
                    hasCollided = false;
                    break;
            }
        }
    }

    void Awake()
    {
        rb = this.GetComponent<Rigidbody2D>();
        CurrentState = EnemyState.Idle;
    }

    void FixedUpdate()
    {
        switch (CurrentState)
        {
            case EnemyState.Idle:
                waitTimer -= Time.fixedDeltaTime;

                if (waitTimer <= 0f)
                {
                    CurrentState = EnemyState.Roaming;
                }
                break;

            case EnemyState.Roaming:

                MoveTowards(dest);

                if (Vector2.Distance(transform.position, dest) < minDistToDest)
                {
                    CurrentState = EnemyState.Idle;
                }
                break;
        }
    }

    private void MoveTowards(Vector2 dest)
    {
        Vector2 dir = (dest - (Vector2)transform.position).normalized;
        rb.AddForce(new Vector2(dir.x * moveSpeed, dir.y * moveSpeed), ForceMode2D.Force);
    }

    private Vector2 DestinationRandomizer(Vector2 center, float radius)
    {
        for (int i = 0; i < 20; i++)
        {
            float x = Random.Range(-radius, radius);
            float y = Random.Range(-radius, radius);
            Vector2 candidate = center + new Vector2(x, y);

            if (x * x + y * y <= radius * radius)
            {
                RaycastHit2D hit = Physics2D.Linecast(center, candidate, LayerMask.GetMask("Wall")); // Check if path is blocked
                if (hit.collider == null)
                {
                    return candidate;
                }
            }
        }
        return center;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (CurrentState == EnemyState.Roaming && !hasCollided)
        {
            if (collision.gameObject.CompareTag("Wall"))
            {
                rb.linearVelocity = Vector2.zero;
                CurrentState = EnemyState.Idle;
                hasCollided = true;
            }
        }
    }
}