/*
	Title:
	玩家控制
	
	Description:
		控制玩家移动
		玩家子弹发射
		玩家碰撞处理
	
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]//编辑器扩展命令 指定类型 可在编辑器中可视化编辑  （序列化类型）
public struct Boundary//边界类型
{
	public float xMin;
	public float xMax;
	public float zMin;
	public float zMax;
}

public class Player : MonoBehaviour
{
	public float moveSpeed;//移动速度
	Rigidbody rigidbody;//刚体组件
	

	//子弹发射
	public GameObject bulletPrefab;//子弹预制体
	public float fireSpeed;//发射频率  （每隔多长时间发射一个子弹）
	public Transform firePos;
	float fireTime;//发射时间  用于控制发射频率
	

	private void Start()
	{
		rigidbody = GetComponent<Rigidbody>();
	}

	private void Update()
	{
		if (rigidbody)
		{
			//通过输入 给刚体速度 模拟 3D物体移动
			var hor = Input.GetAxis("Horizontal");
			var ver = Input.GetAxis("Vertical");
			rigidbody.velocity = new Vector3(hor, 0, ver) * moveSpeed;


		}


		//子弹发射
		if (Time.time - fireTime > fireSpeed)
		{
			//注意：Instantiate实例化一个资源预制体对象  会同时调用Awake唤醒函数  不会调用Start函数
			var bullet = GameObject.Instantiate(bulletPrefab);//通过子弹预制体创建子弹
			bullet.transform.position = firePos.position;//赋值位置
			fireTime = Time.time;
		}

		////移动限制  出边界则置回
		Debug.Log(Screen.width + " x " + Screen.height);
		var posX = Mathf.Clamp(transform.position.x, GameControl.Instance.boundary.xMin, GameControl.Instance.boundary.xMax);
		var posZ = Mathf.Clamp(transform.position.z, GameControl.Instance.boundary.zMin, GameControl.Instance.boundary.zMax);
		transform.position = new Vector3(posX, transform.position.y, posZ);//重置位置



		if (Input.touchCount > 0)
		{
			//手机触摸控制
			float x = Input.GetTouch(0).deltaPosition.x;
			float y = Input.GetTouch(0).deltaPosition.y;
			transform.Translate(new Vector3(x, 0, y).normalized * moveSpeed * Time.deltaTime);
		}
		


	}


	public GameObject explosionPrefab;//飞机爆炸特效
	private void OnTriggerEnter(Collider other)
	{
		switch (other.tag)
		{
			case "Enemy":
			case "EnemyBullet":
			case "Asteriod":
				//创建死亡特效
				GameObject.Instantiate(explosionPrefab,transform.position,Quaternion.identity);
				//删除碰撞物体
				GameObject.Destroy(other.gameObject);
				//删除玩家
				GameObject.Destroy(this.gameObject);
				//显示游戏结束界面
				GameControl.Instance.GameOver();
				
				break;

		}
	}



}

