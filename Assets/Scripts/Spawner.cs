using UnityEngine;
using UnityEngine.SceneManagement;  // Required for scene management

public class Spawner : MonoBehaviour
{
    public GameObject prefab;
    public GameObject endPointPrefab;  // The end point object to spawn after 10 clones
    public float spawnRate = 1;
    public float maxHeight = -1f;
    public float minHeight = 1f;
    private int spawnCount = 0;  // Counter to track the number of spawns

    private void OnEnable()
    {
        InvokeRepeating(nameof(Spawn), spawnRate, spawnRate);
    }

    private void OnDisable()
    {
        CancelInvoke(nameof(Spawn));
    }

    private void Spawn()
    {
        GameObject pipes = Instantiate(prefab, transform.position, Quaternion.identity);
        pipes.transform.position += Vector3.up * Random.Range(minHeight, maxHeight);

        spawnCount++;  // Increment the spawn counter

        // Check if it's the 10th spawn
        if (spawnCount == 2)
        {
            
        }
    }

    private void NextScene()
    {
        SceneManager.LoadScene("scne2");  // Load the next scene
    }
}
