using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [Header("Animal Spawn Settings")]
    public GameObject[] animalPrefabs;

    [SerializeField, Tooltip("Time passed before new spawn.")]
    private float _spawnDelay = 2f;
    private float _spawnInterval = 1.5f;

    [SerializeField, Tooltip("Spawn range on different axis where player can kill animals right and left.")]
    private float _spawnRange = 15f;

    [SerializeField, Tooltip("Spawn range from the player.")]
    private float _spawnPosition = 20f;

    [Header("Enemy Animal Settings")]
    public GameObject enemyAnimal;

    void Start()
    {
        //Repeating the spawn of random animals
        InvokeRepeating("SpawnRandomAnimal", _spawnDelay, _spawnInterval);
        Invoke("SpawnHorizontalAnimal", 6);
    }

    void SpawnRandomAnimal()
    {
        int animalIndex = Random.Range(0, animalPrefabs.Length);

        //Randomly generate animal spawn index and X axis position
        Vector3 spawnPosVertical = new Vector3(Random.Range(-_spawnRange, _spawnRange), 0, _spawnPosition);
        Instantiate(animalPrefabs[animalIndex], spawnPosVertical, animalPrefabs[animalIndex].transform.rotation);
    }

    void SpawnHorizontalAnimal()
    {
        //Randomly generate animal spawn index and Z axis position
        float randNum = Random.Range(0, 2);
        float randomStagInterval = Random.Range(5, 8);

        if (Score._score > 100)
        {
            Debug.Log($"Score is: {Score._score}");

            if (randNum == 0)
            {
                Vector3 spawnPosHorizontal = new Vector3(-_spawnRange, 0, Random.Range(2, 15));
                Instantiate(enemyAnimal, spawnPosHorizontal, Quaternion.Euler(0, 90, 0));

                //Continue to spawn stags in random intervals
                Invoke("SpawnHorizontalAnimal", randomStagInterval);
            }
            else if (randNum == 1)
            {
                Vector3 spawnPosHorizontal = new Vector3(_spawnRange, 0, Random.Range(2, 15));
                Instantiate(enemyAnimal, spawnPosHorizontal, Quaternion.Euler(0, -90, 0));

                //Continue to spawn stags in random intervals
                Invoke("SpawnHorizontalAnimal", randomStagInterval);
            }
        }
        else
        {
            Debug.Log($"Score is less than 100");
            Invoke("SpawnHorizontalAnimal", randomStagInterval);
        }
    }
}
