using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour{

    public GameObject[] spawnPoints;

    public List<PlayerInput> playerList = new List<PlayerInput>();

    [SerializedField] InputAction joinAction;
    [SerializedField] InputAction leaveAction;
    public static GameManager instance = null;

    public event System.Action<PlayerInput> PlayerJoinedGame;
    public event System.Action<PlayerInput> PlayerLeftGame;

    private void Awake(){
        if (instance == null){
            instance = this;
        }
        else if (instance != null){
            Destroy(gameObject);
        }

        spawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoints");
        joinAction.Enable();
        joinAction.performed += context => JoinAction(context);

        leaveAction.Enable();
        leaveAction.performed += context => LeaveAction(context);
    }

    private void Start(){
        PlayerInputManager.instance.JoinPlayer(0, -1, null);
    }

    void OnPlayerJoined(PlayerInput playerInput){
        playerList.Add(playerInput);
        if (PlayerJoinedGame != null){
            PlayerJoinedGame(playerInput);

        }
    }
    void OnPlayerLeft(PlayerInput playerInput){

    }

    void JoinAction(InputAction.CallbackContext context){
        PlayerInputManager.instance.JoinPlayerFromActionNotAlreadyJoined(context);
    }

    void LeaveAction(InputAction.CallbackContext context){

    }

}