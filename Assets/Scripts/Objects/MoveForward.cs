using UnityEngine;

public class MoveForward : MonoBehaviour
{
    [Header("Object Settings")]
    [SerializeField, Tooltip("Object movement speed.")]
    private float speed = 30f;

    private void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
