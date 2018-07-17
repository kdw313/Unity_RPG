using System.Collections; 
using System.Collections.Generic; 
using UnityEngine; 

public class Player:MonoBehaviour {

    private float health = 100f;
    private string playerName = "Default";

    public Player (){
        
    }

    public Player(string name, float health){
        this.playerName = name;
        this.health = health;
    }

    public float Health{
        get{
            return health;
        }
        set {
            health = value;
        }
    }

    public string PlayerName {
        get {
            return playerName;

        }
        set {
            playerName = value;
        }
    }

    public virtual void Attack(){
        Debug.Log("Player:Attack");
    }

    public void PlayerInfo(){
        Debug.Log("Player Name Is: " + playerName + " Health " + health);
    }

}