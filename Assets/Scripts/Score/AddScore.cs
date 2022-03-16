using UnityEngine;

public class AddScore : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Score._score += 10;
    }
}
