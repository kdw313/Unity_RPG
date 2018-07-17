using System.Collections; 
using System.Collections.Generic; 
using UnityEngine; 

public class CoroutinesTest:MonoBehaviour {

	private IEnumerator coroutine; 

	// Use this for initialization
	void Start () {
		
		// cannot call parameter
		StartCoroutine("PrintSomething"); 
		StopCoroutine("PrintSomething"); 

		print("Starting " + Time.time); 

		// cannot be stopped
		StartCoroutine(PrintAfteDelay()); 
		StopCoroutine(PrintAfteDelay()); 


		// can be stopped & call parameter
		coroutine = PrintAfteDelay(2f); 

		StartCoroutine (coroutine); 
		StopCoroutine(coroutine); 

		print ("Before PrintSomething Finishes " + Time.time); 
	}
	
	void PrintSomething() {
		print ("Coroutines practice"); 
	}


	// dependent on real time
	IEnumerator PrintAfterDelay2() {
		yield return new WaitForSecondsRealtime(2f); 
		print ("Printed after 2 seconds"); 
	}

	// waitforseconds dependent on Time.timescale
	// if Time.timeScale = 0, WaitForSeconds can't work
	IEnumerator PrintAfteDelay() {
		yield return new WaitForSeconds (2f); 
		print ("Printed after 2 seconds"); 
	}

	IEnumerator PrintAfteDelay(float seconds) {
		while (true) {
		
			yield return new WaitForSeconds (seconds); 
			print ("Printed after 2 seconds"); 
		}
	}
}
