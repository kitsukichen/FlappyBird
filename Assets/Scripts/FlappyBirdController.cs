using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class FlappyBirdController : MonoBehaviour
{
    [SerializeField] float jumpForce; //Controls how high the bird jumps
    int points;
    [SerializeField] TextMeshProUGUI pointsUI;
    public bool gameStarted;
    [SerializeField] GameObject resetButton;

    public void StartGame()
    {
        gameStarted = true;
        GetComponent<Rigidbody2D>().gravityScale = 1;
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if(gameStarted == false)
        {
            return;
        }
        if(context.performed == true)
        {
            Debug.Log("Jump Pressed");
            GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpForce);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameStarted == false)
        {
            return;
        }
        if(collision.CompareTag("Pipe"))
        {
            Debug.Log("Hit Pipe");
            gameStarted = false;
            resetButton.SetActive(true);
        }
        if(collision.CompareTag("Goal"))
        {
            Debug.Log("Get Point");
            points += 1;
            pointsUI.text = points.ToString();
        }
    }

    public void ResetGame()
    {
        SceneManager.LoadScene(0);
    }
}
