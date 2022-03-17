using UnityEngine;

public class DestroyOnCollision : MonoBehaviour
{
    //Destroy player and the object he collided with
    void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        Destroy(other.gameObject);
    }
}
