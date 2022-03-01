using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleController : MonoBehaviour
{
    public Text scoreText;

    public void Start()
    {
        //　スコアを表示
        scoreText.text = "Score : " + PlayerPrefs.GetInt("Score") + "ゴール";
    }

    public void OnStartButtonClicked()
    {
        SceneManager.LoadScene("Main");
    }
}