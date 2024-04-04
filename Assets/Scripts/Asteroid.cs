/*
	Title:
	陨石
	
	Description:
	控制陨石的 旋转 位移
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
	public float moveSpeed;
	public float angularSpeed;
	private void Awake()
	{
		//给刚体速度 模拟平移
		GetComponent<Rigidbody>().velocity = Vector3.back * moveSpeed;
		//给刚体 角速度 模拟旋转
		//Random.insideUnitSphere;//单位球上 随机一个点
		var dir = Random.insideUnitCircle;//单位圆上的一个点 随机
		GetComponent<Rigidbody>().angularVelocity = new Vector3(dir.x, 0, dir.y) * angularSpeed;
	}


	public GameObject explosionPrefab;//陨石爆炸预制体
	public void ExplosionPlay()
	{
		GameObject.Instantiate(explosionPrefab, transform.position, Quaternion.identity);
	}
}

