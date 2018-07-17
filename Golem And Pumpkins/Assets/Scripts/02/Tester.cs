using System.Collections; 
using System.Collections.Generic; 
using UnityEngine; 

public class Tester:MonoBehaviour {

    [SerializeField]
    private Player player;

    public enum GameState
    {
        Started,
        Paused,
        Ended,
        PlayerDied,
        MainMenu
    }

    GameState gameState = GameState.MainMenu;

    [SerializeField]
    private GameObject[] items;
    private List<GameObject> itemsList;
    private int[] nums = new int[10];


    // O rder of the MonoBehaviour function call 
    // Awake() -> OneEnable() -> Start()

    void Start () {
        
        if( gameState == GameState.MainMenu){
            gameState = GameState.Started;
        }

        Debug.Log(gameState);

    }


    // when the object is activated
    void OnEnable() {
        
        Wizard.playerDied += ExecutedAfterEventCall;

    }

    // when the object is deactivated
    void OnDisable(){
        
        // after subscribe the event, its important to unsubscribe it
        Wizard.playerDied -= ExecutedAfterEventCall;
    }

    void ExecutedAfterEventCall (int a, int b) {
        print("printed after event was called" + a + ", " + b);
    }

}