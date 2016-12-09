using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameHandler : MonoBehaviour {

    public const int GAME_RUNNING = 0, GAME_PAUSED = 1, GAME_OVER = 2, GAME_RESTART = 3;
    private int GAME_STATE = 1;
    private float GameScore = 0f;

    public GameObject player;
    public Text highscore;

    //Score
    string scoreKey = "score";

    // UI
    public GameObject panel_paused;
    public GameObject panel_gameover;
    public Text panel_gameover_text;

	void Start ()
    {
        setGameState(GAME_RUNNING);
	}
	
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            quitGame();

        highscore.text = GameScore + "m";
        if (player.GetComponent<Player>().isDead)
            setGameState(GAME_OVER);
        switch (GAME_STATE)
        {
            case GAME_RUNNING:
                GameScore += Time.deltaTime;
                GameScore = Mathf.Round(GameScore * 100f) / 100f;
                // Debug.Log("Score:" + GameScore);
                break;

            case GAME_PAUSED:
                break;

            case GAME_OVER:
                break;
        }
    }

    public void setGameState(int state)
    {
        switch (state)
        {
            case GAME_RUNNING:
                GAME_STATE = GAME_RUNNING;
                Time.timeScale = 1f;
                showGameOver(false);
                showPaused(false);
                break;

            case GAME_PAUSED:
                GAME_STATE = GAME_PAUSED;
                Time.timeScale = 0f;
                showPaused(true);
                break;

            case GAME_OVER:
                GAME_STATE = GAME_OVER;
                Time.timeScale = .3f;
                showGameOver(true);
                saveScore();
                setGameOverText(""+GameScore);
                break;

            case GAME_RESTART:
                GAME_STATE = GAME_RESTART;
                restartGame();
                showGameOver(false);
                showPaused(false);
                setGameState(GAME_RUNNING);
                break;
        }
    }

    public void quitGame()
    {
        Application.Quit();
    }

    private void showGameOver(bool show)
    {
        if(panel_gameover != null)
            panel_gameover.SetActive(show);
    }

    private void showPaused(bool show)
    {
        if (panel_paused != null)
            panel_paused.SetActive(show);
    }

    private void setGameOverText(string score)
    {
        if (panel_gameover_text != null)
            panel_gameover_text.text = "Score: " + score + "m\nHighScore: " + getHighScore() + "m";
    }

    private string getHighScore()
    {
        return PlayerPrefs.GetFloat(scoreKey).ToString();
    }

    private void saveScore()
    {
        if (PlayerPrefs.GetFloat(scoreKey) < GameScore)
        {
            PlayerPrefs.SetFloat(scoreKey, GameScore);
            PlayerPrefs.Save();
        }
    }

    private void restartGame()
    {
        RigidbodyConstraints2D con = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;

        player.transform.position = new Vector3(-7f, 9f, 0f);
        player.transform.eulerAngles = Vector3.zero;
        player.GetComponent<Player>().isDead = false;
        player.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        player.GetComponent<Rigidbody2D>().constraints = con;
        killEnemies();
        GameScore = 0f;
    }

    // Destroys alle the enemyobjects
    private void killEnemies()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Bird");
        foreach (GameObject g in enemies)
        {
            Destroy(g);
        }

        enemies = GameObject.FindGameObjectsWithTag("Car");
        foreach (GameObject g in enemies)
        {
            Destroy(g);
        }
    }

}
