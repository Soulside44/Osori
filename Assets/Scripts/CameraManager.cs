using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] GameObject gameoverPanel;
    public void Shake()
    {
        GetComponent<Animator>().SetTrigger("shake");
    }
        public void OnGameoverPanel()
    {
        gameoverPanel.SetActive(true);
    }
}
