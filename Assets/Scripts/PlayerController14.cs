using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class PlayerController14 : MonoBehaviour
{
    public Animator playerAnim;
    public GameObject healthText;
    public float Speed;
    public float rotateSpeed;
    public float damageRate;
    public float Health;
	private void OnTriggerStay(Collider other)
	{
		if (other.gameObject.tag == "Fire")
		{
            Health -= damageRate * Time.deltaTime;
            healthText.GetComponent<Text>().text = ("Health = " + Health);
		}
        if (Health <= 0)
		{
            Health = 0;
            playerAnim.SetTrigger("DeadTrigger");
		}
	}
	// Start is called before the first frame update
	void Start()
    {
        Speed = 5;
        rotateSpeed = 5;
        damageRate = 50;
        Health = 100;
        playerAnim.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        healthText.GetComponent<Text>().text = ("Health = " + Health);
        if (Input.GetKey(KeyCode.W) || (Input.GetKey(KeyCode.DownArrow)))
		{
            playerAnim.SetBool("WalkingBool", true);
            transform.Translate(Vector3.forward * Time.deltaTime * Speed);
            transform.rotation = Quaternion.Euler(0, 0, 0);
		}
        if (Input.GetKey(KeyCode.A) || (Input.GetKey(KeyCode.LeftArrow)))
		{
            playerAnim.SetBool("WalkingBool", true);
            transform.Translate(Vector3.forward * Time.deltaTime * Speed);
            transform.rotation = Quaternion.Euler(0, 270, 0);
		}
        if (Input.GetKey(KeyCode.S) || (Input.GetKey(KeyCode.DownArrow)))
		{
            playerAnim.SetBool("WalkingBool", true);
            transform.Translate(Vector3.forward * Time.deltaTime * Speed);
            transform.rotation = Quaternion.Euler(0, 180, 0);
		}
        if (Input.GetKey(KeyCode.D) || (Input.GetKey(KeyCode.RightArrow)))
		{
            playerAnim.SetBool("WalkingBool", true);
            transform.Translate(Vector3.forward * Time.deltaTime * Speed);
            transform.rotation = Quaternion.Euler(0, 90, 0);
		}
        if (Input.anyKey == false)
		{
            playerAnim.SetBool("WalkingBool", false);
		}
        if (Input.GetKeyDown(KeyCode.Space))
		{
            playerAnim.SetTrigger("AttackTrigger");
		}
    }
}
