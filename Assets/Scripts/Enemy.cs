/*
	Title:
	敌机类
	Description:
	控制敌机子弹发射 移动 逻辑
	
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Enemy : MonoBehaviour
{
	public float moveSpeed;
	Rigidbody rigidbody;

	public GameObject explosionPrefab;

	//子弹发射
	public GameObject bulletPrefab;//预设
	public Transform firePos;
	public float fireSpeed;
	float fireTime;

	private void Awake()
	{
		rigidbody = GetComponent<Rigidbody>();
		rigidbody.velocity = transform.forward * moveSpeed;//给自身正方向 一个速度 模拟移动
	}

	private void Update()
	{
		if (Time.time - fireTime > fireSpeed)
		{
			//创建敌机子弹
			var bullet = GameObject.Instantiate(bulletPrefab);
			bullet.transform.position = firePos.position;//设置位置
			fireTime = Time.time;
		}
	}

	public void ExplosionPlay()
	{
		GameObject.Instantiate(explosionPrefab, transform.position, Quaternion.identity);
	}


}

