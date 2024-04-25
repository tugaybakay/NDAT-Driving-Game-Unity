using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public Movement movement;
    public Horizontal horizontal;
    public GameObject[] roads;
    public float xSpawn = -100f;
    public float roadLength = 100f;
    public bool isOver = false;
    public int counter = 1;
    public Text gameOverText;

    private void Update()
    {
        // Game Over olmadığı durumda R tuşuna basıldığında
        if (isOver && Input.GetKeyDown(KeyCode.R))
        {
            // Oyun yeniden başlat
            RestartGame();
	    gameOverText.enabled = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "GameOver")
        {
            Debug.Log("Game Over!");
            movement.enabled = false;
            horizontal.enabled = false;
            isOver = true;
	    gameOverText.enabled = true;
        }
        else if (collision.collider.tag == "WinCond")
        {
            Debug.Log("You Won!");
            movement.enabled = false;
            horizontal.enabled = false;
        }
        if (collision.collider.tag == "Road" && !isOver)
        {
            spawnRoad(counter);
            counter++;
        }
    }

    public void spawnRoad(int roadNumber)
    {
        Instantiate(roads[roadNumber], transform.right * xSpawn, transform.rotation);
        xSpawn -= roadLength;
    }

    public void RestartGame()
    {
        // Mevcut sahneyi yeniden yükle
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
