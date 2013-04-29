using UnityEngine;

using System.Collections;

 

public class Donut : MonoBehaviour {

 
	static public int score = 0;
    public Transform target;
	
	void Update (){
		
	print (score);
	}
    void OnCollisionEnter(Collision target){

        score += 10;
		
		
        Destroy(gameObject);

    }
	

}