using UnityEngine;

public class BallManager : MonoBehaviour
{
	const int DefaultBallAmount = 5;
	
	//現在のボールのストック数
    public int ball = DefaultBallAmount;
    
	public void ConsumeBall()
	{
		if (ball > 0) ball--;
	}

	public int GetBallAmount()
	{
		return ball;
	}
	
	void OnGUI()
	{
		GUI.matrix = Matrix4x4.Scale(Vector3.one * 8);
		GUI.color = Color.black;
		//ボールのストック数を表示
		string label2 = "Ball : " + ball;
		GUI.Label(new Rect(5, 10, 50, 30), label2);
	}
}
