using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
	AudioSource shotSound;

	public GameObject ballPrefab;
	public Transform ballParentTransform;
	public BallManager ballManager;
	public float shotForce;
	public float shotTorque;
	public float baseWidth;
	public float baseHeight;
	public int shootcounter = 0;

	void Start()
	{
		shotSound = GetComponent<AudioSource>();
	}
	
	void Update()
	{
		if (Input.GetButtonDown("Fire1"))
		{
			Shot();
		}
	}

	Vector3 GetInstantiatePosition()
	{
		//画面のサイズとInputの割合からキャンディ生成のポジションを計算
		float x = baseWidth * (Input.mousePosition.x / Screen.width) - (baseWidth / 2);
		float y = baseHeight * (Input.mousePosition.y / Screen.height) - (baseHeight / 2);
		return transform.position + new Vector3(x, y, 0);
	}

	public void Shot()
	{
		//ボールを生成できる条件外ならばShotしない
		if (ballManager.GetBallAmount() <= 0) return;
		//プレハブからballオブジェクトを生成
		GameObject ball = (GameObject)Instantiate(
			ballPrefab,
			GetInstantiatePosition(),
			Quaternion.identity
		);

		//生成したballオブジェクトの親をballParentTransformに設定する
		ball.transform.parent = ballParentTransform;

		//BallオブジェクトのRigidbodyを取得し力と回転を加える
		Rigidbody ballRigidBody = ball.GetComponent<Rigidbody>();
		ballRigidBody.AddForce(transform.forward * shotForce);
		ballRigidBody.AddTorque(new Vector3(0, shotTorque, 0));

		//Ballのストックを消費
		ballManager.ConsumeBall();

		//サウンドを再生
		shotSound.Play();
	}
}