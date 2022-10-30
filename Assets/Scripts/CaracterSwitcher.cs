using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
/* https://www.youtube.com/watch?v=3fzX-BX8hlI&ab_channel=RyanLindemulder */

public class CaracterSwitcher : MonoBehaviour
{
    [SerializeField] List<GameObject> spirits = new List<GameObject>();
    private PlayerInputManager manager;
    private void Start()
    {
        manager = GetComponent<PlayerInputManager>();
        manager.playerPrefab = spirits[0]; 
        spirits.RemoveAt(0);  
        Debug.Log(spirits[0]); 
        Debug.Log("---");    
    }

    public void SwitchNextSpawnCharacter(PlayerInput input){
        Debug.Log(spirits[0]);
        manager.playerPrefab = spirits[0]; 
        spirits.RemoveAt(0);
        Debug.Log(manager.playerPrefab);
    }

}
