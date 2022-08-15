using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Button))]
public class LoadSceneButton : MonoBehaviour
{
    [SerializeField] private string _sceneName;

    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(LoadScene);
    }

    private void OnDestroy()
    {
        _button.onClick.RemoveListener(LoadScene);
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(_sceneName);
    }
}
