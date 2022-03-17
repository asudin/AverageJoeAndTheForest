using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    [Header("Boundaries for death")]
    [SerializeField, Tooltip("When object moves further that these restrictions it will be destroyed.")]
    private float _boundary = 50;

    [SerializeField, Tooltip("When object moves further that these restrictions it will be destroyed.")]
    private float _sideBoundary = 40;

    private void Update()
    {
        if (transform.position.z > _boundary || transform.position.z < _boundary)
        {
            Destroy(gameObject);
        }
        else if (transform.position.x > _sideBoundary || transform.position.x > -_sideBoundary)
        {
            Destroy(gameObject);
        }
    }
}
