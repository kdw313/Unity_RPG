using System.Collections; 
using System.Collections.Generic; 
using UnityEngine; 

public class Wizard:Player {

    public static int power = 100;

    public delegate void PlayerDied(int a, int b);
    public static event PlayerDied playerDied;

    void Start () {
        StartCoroutine(CallFunction());
    }

    public Wizard () {

    }

    IEnumerator CallFunction(){
        yield return new WaitForSeconds(2f);
        if(playerDied != null) {
            playerDied(5, 6);
        }
    }

    public Wizard(string name, float health) {
        this.PlayerName = name; 
        this.Health = health; 
    }

    public static void WizardInfo() {
        Debug.Log ("The po is " + power); 
    }


    public override void Attack() {
        Debug.Log("Wizard Attack");
    }


}