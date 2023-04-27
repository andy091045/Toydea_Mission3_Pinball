using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Testtt : MonoBehaviour
{
    private void Start()
    {
        GameInput.Instance.onReStartEvent.AddListener(ReStart);
    }

    public void ReStart()
    {
        GameInput.Instance.TotalScore = 0;
        GameInput.Instance.Lifetimes = 5;
        SceneManager.LoadScene(0);
    }

    private void OnDestroy()
    {
        GameInput.Instance.onReStartEvent.RemoveListener(ReStart);
    }
}
