using System.Threading;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] GameObject pipePrefab;
    [SerializeField] float pipeSpawnDelay;
    float countdown;

    FlappyBirdController flappyBirdController;

    void Start()
    {
        flappyBirdController = FindAnyObjectByType<FlappyBirdController>();
    }

    // Update is called once per fram
    void Update()
    {
        if(flappyBirdController.gameStarted == false)
        {
            return;
        }

        countdown -= Time.deltaTime;
        if(countdown <= 0)
        {
            Instantiate(pipePrefab, transform);
            countdown = pipeSpawnDelay;
        }
    }
}
