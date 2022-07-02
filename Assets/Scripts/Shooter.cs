using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
	GameObject ball;
	public GameObject ballPrefab;
	public GameController gameController;
	public float shotForce;
	public float shotTorque;
	public float baseWidth;
	public float baseHeight;
	public int shootcounter = 0;
	Rigidbody ballRigidBody;
	float touch_sensitivity = 100.0f;
	float mouse_sensitivity = 100.0f;

	void Update()
	{
		if (Input.GetButtonDown("Fire1"))
		{
			//プレハブからballオブジェクトを生成
			ball = (GameObject)Instantiate(ballPrefab, GetInstantiatePosition(), Quaternion.identity);

			ballRigidBody = ball.GetComponent<Rigidbody>();

			//Ballのストックを消費
			gameController.ConsumeBall();
		}

		if (Input.GetMouseButton(0))
		{
			float dx, dy;

			dx = Input.GetAxis("Mouse X") * mouse_sensitivity * Time.deltaTime;
			dy = Input.GetAxis("Mouse Y") * mouse_sensitivity * Time.deltaTime;

			if (Input.touchCount > 0)
			{
				Debug.Log("touch");
				dx = Input.touches[0].deltaPosition.x * touch_sensitivity * Time.deltaTime;
				dy = Input.touches[0].deltaPosition.y * touch_sensitivity * Time.deltaTime;
			}

			Physics.gravity = new Vector3(0, 0, 0);

			ballRigidBody.MovePosition(ballRigidBody.position + new Vector3(dx, dy, 0));
		}

		if (Input.GetButtonUp("Fire1"))
		{
			Physics.gravity = new Vector3(0, -9.81f, 0);
			Shot();
		}
	}

	Vector3 GetInstantiatePosition()
	{
		//画面のサイズとInputの割合からキャンディ生成のポジションを計算
		float x = baseWidth * (Input.mousePosition.x / Screen.width) - (baseWidth / 2);
		float y = baseHeight * (Input.mousePosition.y / Screen.height) - (baseHeight / 2);
		return transform.position + new Vector3(x, y, -22.0f);
	}

	void Shot()
	{
		//ボールを生成できる条件外ならばShotしない
		if (gameController.GetBallAmount() < 0) return;

		//BallオブジェクトのRigidbodyを取得し力と回転を加える
		ballRigidBody.AddForce(transform.forward * shotForce);
		ballRigidBody.AddTorque(new Vector3(0, 100 * shotTorque, 0));
	}
}