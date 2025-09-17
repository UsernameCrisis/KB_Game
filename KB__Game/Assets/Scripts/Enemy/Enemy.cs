using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    
    private void Update()
    {
        if (player != null)
        {
            Vector3 direction = player.transform.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.position += direction.normalized * Time.deltaTime;
        }
    }

}