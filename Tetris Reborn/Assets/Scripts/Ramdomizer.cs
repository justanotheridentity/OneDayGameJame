using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Ramdomizer : MonoBehaviour {

    public Text score;
    public Text highScore;

    public Text time;
    public Text Highscore1;
    public Text Highscore2;
    public Text Highscore3;
    public Text Highscore4;
    public Text Highscore5;
    public Text Player1;
    public Text Player2;
    public Text Player3;
    public Text Player4;
    public Text Player5;
    private float highscore1;
    private float highscore2;
    private float highscore3;
    private float highscore4;
    private float highscore5;

    public Text PlayerBad;
    public Text HighscoreBad;
    public Text RankBad;

    public float test;
    public GameObject scoreManager;

    public InputField highscoreName;

    private bool credited;

    public Button playAgain;

    void Start()
    {
        highScore.text = PlayerPrefs.GetInt("Highscore", 0).ToString();
        Highscore1.text = PlayerPrefs.GetFloat("Highscore1", 100000).ToString();
        Highscore2.text = PlayerPrefs.GetFloat("Highscore2", 80000).ToString();
        Highscore3.text = PlayerPrefs.GetFloat("Highscore3", 60000).ToString();
        Highscore4.text = PlayerPrefs.GetFloat("Highscore4", 40000).ToString();
        Highscore5.text = PlayerPrefs.GetFloat("Highscore5", 20000).ToString();
        Player1.text = PlayerPrefs.GetString("Player1", "TITOUAN");
        Player2.text = PlayerPrefs.GetString("Player2", "QUENTIN");
        Player3.text = PlayerPrefs.GetString("Player3", "ARTHUR");
        Player4.text = PlayerPrefs.GetString("Player4", "TIMOTHE");
        Player5.text = PlayerPrefs.GetString("Player5", "THOMAS");
        credited = false;
        playAgain.transform.position = new Vector3(7140.6f, -4570.7f, 0);
        scoreManager = GameObject.FindGameObjectWithTag("Detect");
        scoreManager.GetComponent<ScoreManager>().onGame = false;
        test = ScoreManager.score;
        TimeStamp();
    }

    public void Reset ()
    {
        PlayerPrefs.DeleteAll();
        highScore.text = "0";
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (Player5.text == "")
            {
                Player5.text = highscoreName.text.ToUpper();
                PlayerPrefs.SetString("Player5", highscoreName.text.ToUpper());
                playAgain.transform.position = new Vector3(1680.6f, 80f, 0);
            }
            else
            if (Player4.text == "")
            {
                Player4.text = highscoreName.text.ToUpper();
                PlayerPrefs.SetString("Player4", highscoreName.text.ToUpper());
                playAgain.transform.position = new Vector3(1680.6f, 80f, 0);
            }
            else
            if (Player3.text == "")
            {
                Player3.text = highscoreName.text.ToUpper();
                PlayerPrefs.SetString("Player3", highscoreName.text.ToUpper());
                playAgain.transform.position = new Vector3(1680.6f, 80f, 0);
            }
            else
            if (Player2.text == "")
            {
                Player2.text = highscoreName.text.ToUpper();
                PlayerPrefs.SetString("Player2", highscoreName.text.ToUpper());
                playAgain.transform.position = new Vector3(1680.6f, 80f, 0);
            }
            else 
            if (Player1.text == "")
            {
                Player1.text = highscoreName.text.ToUpper();
                PlayerPrefs.SetString("Player1", highscoreName.text.ToUpper());
                playAgain.transform.position = new Vector3(1680.6f, 80f, 0);
            }
            else
            {
                PlayerBad.text = highscoreName.text.ToUpper();
                playAgain.transform.position = new Vector3(1680.6f, 80f, 0);
            }
        }
    }

    public void TimeStamp()
    {
        float timer = test;
        PlayerBad.text = "";
        HighscoreBad.text = "";
        RankBad.text = "";

        if (timer > PlayerPrefs.GetFloat("Highscore1", 100000))
        {
            Highscore5.text = Highscore4.text;
            Highscore4.text = Highscore3.text;
            Highscore3.text = Highscore2.text;
            Highscore2.text = Highscore1.text;
            Highscore1.text = timer.ToString();
            PlayerPrefs.SetFloat("Highscore5", PlayerPrefs.GetFloat("Highscore4", 40000));
            PlayerPrefs.SetFloat("Highscore4", PlayerPrefs.GetFloat("Highscore3", 60000));
            PlayerPrefs.SetFloat("Highscore3", PlayerPrefs.GetFloat("Highscore2", 80000));
            PlayerPrefs.SetFloat("Highscore2", PlayerPrefs.GetFloat("Highscore1", 100000));
            PlayerPrefs.SetFloat("Highscore1", timer);
            Player5.text = Player4.text;
            Player4.text = Player3.text;
            Player3.text = Player2.text;
            Player2.text = Player1.text;
            Player1.text = "";
            PlayerPrefs.SetString("Player5", PlayerPrefs.GetString("Player4", "TIMOTHE"));
            PlayerPrefs.SetString("Player4", PlayerPrefs.GetString("Player3", "ARTHUR"));
            PlayerPrefs.SetString("Player3", PlayerPrefs.GetString("Player2", "QUENTIN"));
            PlayerPrefs.SetString("Player2", PlayerPrefs.GetString("Player1", "TITOUAN"));
            PlayerPrefs.SetString("Player1", "");
        }
        else
        if (timer > PlayerPrefs.GetFloat("Highscore2", 80000))
        {
            Highscore5.text = Highscore4.text;
            Highscore4.text = Highscore3.text;
            Highscore3.text = Highscore2.text;
            Highscore2.text = timer.ToString();
            PlayerPrefs.SetFloat("Highscore5", PlayerPrefs.GetFloat("Highscore4", 40000));
            PlayerPrefs.SetFloat("Highscore4", PlayerPrefs.GetFloat("Highscore3", 60000));
            PlayerPrefs.SetFloat("Highscore3", PlayerPrefs.GetFloat("Highscore2", 80000));
            PlayerPrefs.SetFloat("Highscore2", timer);
            Player5.text = Player4.text;
            Player4.text = Player3.text;
            Player3.text = Player2.text;
            Player2.text = "";
            PlayerPrefs.SetString("Player5", PlayerPrefs.GetString("Player4", "TIMOTHE"));
            PlayerPrefs.SetString("Player4", PlayerPrefs.GetString("Player3", "ARTHUR"));
            PlayerPrefs.SetString("Player3", PlayerPrefs.GetString("Player2", "QUENTIN"));
            PlayerPrefs.SetString("Player2", "");
        }
        else
        if (timer > PlayerPrefs.GetFloat("Highscore3", 60000))
        {
            Highscore5.text = Highscore4.text;
            Highscore4.text = Highscore3.text;
            Highscore3.text = timer.ToString();
            PlayerPrefs.SetFloat("Highscore5", PlayerPrefs.GetFloat("Highscore4", 40000));
            PlayerPrefs.SetFloat("Highscore4", PlayerPrefs.GetFloat("Highscore3", 60000));
            PlayerPrefs.SetFloat("Highscore3", timer);
            Player5.text = Player4.text;
            Player4.text = Player3.text;
            Player3.text = "";
            PlayerPrefs.SetString("Player5", PlayerPrefs.GetString("Player4", "TIMOTHE"));
            PlayerPrefs.SetString("Player4", PlayerPrefs.GetString("Player3", "ARTHUR"));
            PlayerPrefs.SetString("Player3", "");
        }
        else
        if (timer > PlayerPrefs.GetFloat("Highscore4", 40000))
        {
            Highscore5.text = Highscore4.text;
            Highscore4.text = timer.ToString();
            PlayerPrefs.SetFloat("Highscore5", PlayerPrefs.GetFloat("Highscore4", 40000));
            PlayerPrefs.SetFloat("Highscore4", timer);
            Player5.text = Player4.text;
            Player4.text = "";
            PlayerPrefs.SetString("Player5", PlayerPrefs.GetString("Player4", "TIMOTHE"));
            PlayerPrefs.SetString("Player4", "");
        }
        else
        if (timer > PlayerPrefs.GetFloat("Highscore5", 20000))
        {
            Highscore5.text = timer.ToString();
            PlayerPrefs.SetFloat("Highscore5", timer);
            Player5.text = "";
            PlayerPrefs.SetString("Player5", "");
        }
        else
        {
            PlayerBad.text = "";
            HighscoreBad.text = timer.ToString();
            RankBad.text = "...";
        }
    }

    public void Replay()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
