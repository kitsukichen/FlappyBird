using UnityEngine;

public class Pipe : MonoBehaviour
{
    [SerializeField] float pipeSpeed;
    [SerializeField] float randomOffset;
    FlappyBirdController flappyBirdController;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Vector2 newPosition = transform.position;
        newPosition.y = Random.Range(-randomOffset, randomOffset);

        transform.position = newPosition;
        flappyBirdController = FindFirstObjectByType<FlappyBirdController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(flappyBirdController.gameStarted == false)
        {
            return;
        }

        transform.position += Vector3.left * pipeSpeed * Time.deltaTime;
        if(transform.position.x <= -10)
        {
            Destroy(gameObject);
        }
    }
}
