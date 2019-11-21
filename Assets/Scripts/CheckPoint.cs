using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    
    GameObject gameManager;

    private void OnTriggerExit2D(Collider2D collision)
    {
        gameManager.SendMessage("IncreaseScore", SendMessageOptions.DontRequireReceiver);
    }
    void Start()
    {
        gameManager = GameObject.FindWithTag("GameManager");

    }


}
