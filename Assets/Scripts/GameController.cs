using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    //　ゲームステート
    enum State
    {
        Ready,
        Play,
        GameOver
    }

    State state;
    int goal;
    public Text goalText;
    public Text ballText;
    public Text stateText;
    public Text scoreText;
    const int DefaultBallAmount = 5;
    public int ball = DefaultBallAmount;

    void Start()
    {
        //　開始と同時にReadyステートに移行
        Ready();
    }

    void LateUpdate()
    {
        //　ゲームのステートごとにイベントを監視
        switch (state)
        {
            case State.Ready:
                //　タッチしたらゲームスタート
                if (Input.GetButtonDown("Fire1")) GameStart();
                break;

            case State.Play:
                //　ボールが0になったらゲームオーバー
                if (ball == 0) GameOver();
                break;

            case State.GameOver:
                PlayerPrefs.SetInt("Score", goal);
                Invoke("ReturnToTitle", 2.0f);
                break;
        }

        //　ラベルを表示
        BallPossession();
    }

    void Ready()
    {
        state = State.Ready;

        //　ラベルを更新
        ballText.text = "Ball : " + 5;
        goalText.text = "Goal : " + 0;
        stateText.gameObject.SetActive(true);
        stateText.text = "Ready";
    }

    void GameStart()
    {
        state = State.Play;

        //　ラベルを更新
        stateText.gameObject.SetActive(false);
        stateText.text = "";
    }

    void GameOver()
    {
        state = State.GameOver;

        //　Keeperコンポーネントを探し出す
        Keeper keeper = GameObject.FindObjectOfType<Keeper>();

        //　Keeperの移動を停止
        keeper.enabled = false;

        //　ラベルを更新
        stateText.gameObject.SetActive(true);
        stateText.text = "Finish!!";
    }

    void ReturnToTitle()
    {
        //　タイトルシーンに切り替え
        SceneManager.LoadScene("Title");
    }

    //　ラベルを更新
    void BallPossession()
    {
        ballText.text = "Ball : " + ball;
    }

    //　ゴール数を計算
    void IncreaseScore()
    {
        goal++;
        goalText.text = "Goal : " + goal;
    }

    //　ボールを消費
    public void ConsumeBall()
    {
        if (ball > 0) ball--;
    }

    //　ボールの所持数
    public int GetBallAmount()
    {
        return ball;
    }
}