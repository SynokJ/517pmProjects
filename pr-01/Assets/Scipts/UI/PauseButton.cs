using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButton : MonoBehaviour
{

    [SerializeField] private GameObject _pusePanel;

    public void OnPauseButtonClicked()
    {
        if (Time.timeScale == 1)
            OnPaused();
        else
            OnResume();
    }

    private void OnPaused()
    {
        Time.timeScale = 0;
        _pusePanel.SetActive(true);
    }

    private void OnResume()
    {
        Time.timeScale = 1;
        _pusePanel.SetActive(false);
    }
}
