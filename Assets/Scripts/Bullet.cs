/*
	Title:
	子弹
	
	Description:
	子弹移动及碰撞检测
	
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum BulletType
{
	PlayerBT,
	EnemyBT


}
public class Bullet : MonoBehaviour
{
	Rigidbody rigidbody;
	public float moveSpeed;
	public BulletType type;

	private void Awake()
	{
		rigidbody = GetComponent<Rigidbody>();
		if (rigidbody)
		{
			switch (type)
			{
				case BulletType.PlayerBT:
					rigidbody.velocity = Vector3.forward * moveSpeed;
					break;
				case BulletType.EnemyBT:
					rigidbody.velocity = -Vector3.forward * moveSpeed;
					break;
				default:
					break;
			}
			
		}
	}


	private void OnTriggerEnter(Collider other)
	{
		//玩家子弹碰撞
		if (type == BulletType.PlayerBT)
		{
			
			switch (other.tag)
			{
				case "Background":
				case "Player":
					return;
				case "Asteriod"://碰撞陨石
					GameControl.Instance.ScoreUpdate(20);
					other.gameObject.GetComponent<Asteroid>().ExplosionPlay();//播放陨石特效
					break;
				case "Enemy"://碰撞敌机
					GameControl.Instance.ScoreUpdate(50);
					other.gameObject.GetComponent<Enemy>().ExplosionPlay();//播放陨石特效
					break;
			}

			GameObject.Destroy(other.gameObject);
			GameObject.Destroy(this.gameObject);
		}


		




	}


}

