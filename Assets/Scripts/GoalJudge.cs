using UnityEngine;

public class GoalJudge : MonoBehaviour
{
	//どのボールを吸い寄せるかをタグで指定
	public string targetTag;
	bool isHolding;
	//public GameObject effectPrefab;
	//public Vector3 effectRotation;

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
		}
	}

    void OnTriggerStay(Collider other)
	{
		//コライダに触れているオブジェクトのRigidbodyコンポーネントを取得
		Rigidbody r = other.gameObject.GetComponent<Rigidbody>();

		//ボールがどの方向にあるかを計算
		Vector3 direction = other.gameObject.transform.position - transform.position;
		direction.Normalize();

		//中心地点でボールを止めるため速度を減衰させる
		r.velocity *= 0;
		r.AddForce(direction * -80.0f, ForceMode.Acceleration);

		/*if (effectPrefab != null)
		{
			//Ballのポジションにエフェクトを生成
			Instantiate(
				effectPrefab,
				new Vector3(0, -3, 5),
				Quaternion.Euler(effectRotation)
			);
		}*/
	}
}