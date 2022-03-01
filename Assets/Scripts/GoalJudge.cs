using UnityEngine;

public class GoalJudge : MonoBehaviour
{
	GameObject gameController;
	//どのボールを吸い寄せるかをタグで指定
	public string targetTag;
	bool isHolding;

    void Start()
    {
		//　ゲーム開始時にGameControllerをFindしておく
		gameController = GameObject.FindWithTag("GameController");
    }

    //ボールが入っているかを返す
    public bool IsHolding()
	{
		return isHolding;
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == targetTag)
		{
			isHolding = true;
			gameController.SendMessage("IncreaseScore");
		}
	}
}