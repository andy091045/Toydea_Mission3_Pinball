using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReStart : MonoBehaviour
{
    private void Start()
    {
        GameInput.Instance.onReStartEvent.AddListener(ReStartFunc);
    }
    public void ReStartFunc()
    {
        GameInput.Instance.TotalScore = 0;
        GameInput.Instance.Lifetimes = 5;
        SceneManager.LoadScene(1);
    }
}
