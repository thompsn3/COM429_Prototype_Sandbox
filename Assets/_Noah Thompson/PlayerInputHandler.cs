using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour{
    public GameObject playerPrefab;
    PlayerController playerController;

    Vector3 startPos = new Vector3(0, 0, 0);

    private void Awake(){
        if (playerPrefab != null){
            playerController = GameObject.Instantiate(playerPrefab, GameManager.instance.spawnPoints[0].transform.position, transform.rotation).GetComponent<playerController>();
            transform.parent = playerController.transform;
            transform.position = playerController.position;
        }
    }
    public void OnMove(InputAction.CallbackContext context){
        playerController.OnMove(context);
    }
}