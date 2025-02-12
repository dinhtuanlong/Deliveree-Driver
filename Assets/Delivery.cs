using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] Color32 hasPackageColor = new Color32(1, 1, 1, 1);
    [SerializeField] Color32 noPackageColor = new Color32(1, 1, 1, 1);
    [SerializeField] float destroyDelay = 0.5f;

    bool hasPackage;

    SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = noPackageColor;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision detected with " + collision.gameObject.name);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Package" && !hasPackage)
        {
            hasPackage = true;
            Debug.Log("Player has picked up the package");
            spriteRenderer.color = hasPackageColor;
            Destroy(collider.gameObject, destroyDelay);
        }

        if (collider.tag == "Customer" && hasPackage)
        {
            Debug.Log("Player has delivered the package");
            spriteRenderer.color = noPackageColor;
            hasPackage = false;
        }
    }
}
