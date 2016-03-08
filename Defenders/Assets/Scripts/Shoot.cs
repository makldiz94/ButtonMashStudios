using UnityEngine;
using System.Collections;

/*
    Handles player
        Input
        Weapons
        Cooldowns
*/
public class Shoot : MonoBehaviour {

    public GameObject bulletPrefab;
    public GameObject bombPrefab;

    private GameObject bomb;
    private bool bombCD;
    public int bombCDLength = 10;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("space"))
        {
            Debug.Log("Space pressed");
            Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        }

        if (Input.GetKeyDown("g") && bombCD == false)
        {
            bombCD = true;
            bomb = Instantiate(bombPrefab, this.transform.position, Quaternion.identity) as GameObject;
            StartCoroutine(CoolDown());
        }
    }


    IEnumerator CoolDown()
    {
        yield return new WaitForSeconds(bombCDLength);
        bombCD = false;
    }

}
