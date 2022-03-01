using UnityEngine;

public class Keeper : MonoBehaviour
{
   	Vector3 startPosition;

	public float amplitude;
	public float speed;

	void Start()
	{
		startPosition = transform.localPosition;
	}

	void Update()
	{
		//変位を計算
		float x = amplitude * Mathf.Sin(Time.time * speed);

		//xを変位させたポジションに再設定
		transform.localPosition = startPosition + new Vector3(x, 0, 0);
	}
}
