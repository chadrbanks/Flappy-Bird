using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public GameObject GameOverText;
    public bool GameOver = false;
    private int score = 0;

    public Text scoreText;

    public float scrollSpeed = -1.5f;

	void Awake ()
    {
        if (instance == null)
        {
            //DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void birdScored()
    {
        if( GameOver )
        {
            return;
        }
        score++;
        scoreText.text = "Score: " + score.ToString();
    }

    public void birdDied()
    {
        GameOverText.SetActive(true);
        GameOver = true;
    }
	
	void Update ()
    {
        if( GameOver && Input.GetMouseButtonDown(0) )
        {
            SceneManager.LoadScene( SceneManager.GetActiveScene().buildIndex );
        }
	}
}
