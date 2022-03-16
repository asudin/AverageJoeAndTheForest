using UnityEngine;

public class Score : MonoBehaviour
{
    [Header("Score Settings")]
    public static int _score = 0;

    private void Start()
    {
        _score = 0;
    }

    // Each time a player hits an enemy he gets 10 score
    private void Update()
    {
        GetComponent<UnityEngine.UI.Text>().text = _score.ToString();
    }
}
