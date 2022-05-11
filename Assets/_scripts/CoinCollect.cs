using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class CoinCollect : MonoBehaviour
{
    public float pickUpRadius = 1.5f;
    public float rotationSpeed = 10;
    public int value = 5;

    float randomOffset;

    SphereCollider myCollider;
    private void Awake()
    {

        myCollider = GetComponent<SphereCollider>();
        myCollider.isTrigger = true;
        myCollider.radius = pickUpRadius;
        rotationSpeed = Random.Range(-25f, 25);

    }
    private void Update()
    {
        transform.Rotate(Vector3.up * (rotationSpeed * Time.deltaTime));

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, pickUpRadius);
    }
    private void OnTriggerEnter(Collider other)
    {
        PickUpCoin(other);
    }
    public void PickUpCoin(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerController player = other.gameObject.GetComponent<PlayerController>();
            if (player != null)
            {
                player.IncreaseScore(value);
            }
        }
        Destroy(this.gameObject);
    }

}

