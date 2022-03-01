using UnityEngine;

public class BallDestroyer : MonoBehaviour
{
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Ball")
		{
			//オブジェクトを削除
			Destroy(other.gameObject);	
		}
	}
}
