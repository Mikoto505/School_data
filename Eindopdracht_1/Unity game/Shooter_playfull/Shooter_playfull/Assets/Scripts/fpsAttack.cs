using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class fpsAttack : MonoBehaviour
{

    public int currentHealth = 10;
    public Slider healthbar;
    public Transform respawnPosition;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("zombie hit");
        currentHealth -= 1;
        healthbar.value -= 1;

        if (currentHealth <= 0)
        {
            transform.position = respawnPosition.position;
            healthbar.value = 10;
            currentHealth = 10;
            //Destroy(gameObject);
        }
    }


    // Use this for initialization
    void Start()
    {
        respawnPosition = GameObject.FindGameObjectWithTag("Respawn").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0) return;

    }

    /*
	IEnumerator dead()
	{
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
	}
	*/

}

