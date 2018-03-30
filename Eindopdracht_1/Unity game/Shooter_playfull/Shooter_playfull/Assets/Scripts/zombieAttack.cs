﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class zombieAttack : MonoBehaviour {

	public Transform player;
	Animator anim;
	Rigidbody rigidbody;
	public CapsuleCollider capCol;
	Vector3 spawnPoint;
	//public GameObject healthBar;
	public int currentHealth = 3;


	//private UnityEngine.AI.NavMeshAgent navComponent;

	public void Damage(int damageAmount)
	{
		//subtract damage amount when Damage function is called
		currentHealth -= damageAmount;

		//Check if health has fallen below zero
		if (currentHealth <= 0) 
		{
			//if health has fallen below zero, deactivate it 
			StartCoroutine (dead ());


		}

	}

	// Use this for initialization
	void Start () 
	{
		anim = GetComponent<Animator>();
		rigidbody = GetComponent<Rigidbody>();
		capCol = GetComponent<CapsuleCollider>();
		//navComponent = this.gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();

		GameObject spawnObject = GameObject.FindGameObjectWithTag("Enemy");
		spawnPoint = spawnObject.transform.position;
	}

	// Update is called once per frame
	void Update ()
	{
		if (currentHealth <= 0) return;

		Vector3 direction = player.position - this.transform.position;
		float angle = Vector3.Angle(direction, this.transform.forward);
		if(Vector3.Distance(player.position, this.transform.position) < 80 && angle < 140) 
		{

			direction.y = 0;

			this.transform.rotation = Quaternion.Slerp(this.transform.rotation,
				Quaternion.LookRotation (direction), 0.2f);

			anim.SetBool ("isIdle", false);
			if (direction.magnitude > 2) 
			{
				//Speed
				this.transform.Translate (0, 0, 0.01f);
				//navComponent.SetDestination(player.position);

				anim.SetBool ("isRunning", true);
				anim.SetBool ("isAttacking", false);
				anim.SetBool ("isCrying", true);

			} 
			else 
			{
				anim.SetBool ("isRunning", false);
				anim.SetBool ("isAttacking", true);
				anim.SetBool ("isCrying", false);
			}

		} 
		else 
		{
			//navComponent.SetDestination (this.transform.position);
			anim.SetBool ("isIdle", true);
			anim.SetBool ("isRunning", false);
			anim.SetBool ("isAttacking", false);
			anim.SetBool ("isCrying", false);

		}

	}

	IEnumerator dead()
	{
		//navComponent.SetDestination (this.transform.position);
		capCol.enabled = false;
		anim.SetBool ("isDeath", true);
		anim.SetBool ("isIdle", false);
		anim.SetBool ("isRunning", false);
		anim.SetBool ("isCrying", false);
		anim.SetBool ("isAttacking", false);
		rigidbody.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;
		yield return new WaitForSeconds(4);
		Destroy(gameObject);
		//healthbar.value = 100;
		//transform.position = spawnPoint;
		//capCol.enabled = true;
		//rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
		//rigidbody.constraints = RigidbodyConstraints.None;
		//anim.SetBool("isDeath", false);
		//anim.SetBool("isIdle", true);
		//anim.SetBool ("isRunning", false);
		//anim.SetBool ("isCrying", false);
		//anim.SetBool ("isAttacking", false);
		StopCoroutine (dead ());
		GameObject.FindGameObjectsWithTag ("Enemy");
	}

}

