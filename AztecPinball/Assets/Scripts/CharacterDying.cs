using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterDying : MonoBehaviour {

    public int hitpoints = 100;
    public Slider sliderHealth;

    public GameObject particleDeath;
    public GameObject explodeWoman;


    void Start () {
        hitpoints = 100;
        sliderHealth.value = 100;
    }
	
	// Update is called once per frame
	void Update () {
        sliderHealth.value = hitpoints;
        if(hitpoints < 0)
        {
            hitpoints = -10;
            Instantiate(particleDeath, transform.position, transform.rotation);
            Instantiate(explodeWoman, transform.position, transform.rotation);
            Destroy(this.gameObject);
        }
	}



    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "obstacle")
        {
            hitpoints -= 5;
        }
        else if(collision.gameObject.tag == "stairs")
        {
            hitpoints -= 1;
        }
            
    }
}
