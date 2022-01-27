using UnityEngine;

public class GameClearDetector : MonoBehaviour
{
    public GoalJudge goal;

	void OnGUI()
   	{
		//ボールが入ったらラベルを表示
		if (goal.IsHolding())
        {
            
            GUI.matrix = Matrix4x4.Scale(Vector3.one * 8);
            GUI.color = Color.black;
            GUI.Label(new Rect(35, 40, 100, 100), "Game Clear!");
        }
    }
}
