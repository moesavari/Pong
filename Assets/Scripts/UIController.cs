using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Text _gameOverText;

    void Start()
    {
        _gameOverText.gameObject.SetActive(false);
    }

    public void ShowGameOver()
    {
        _gameOverText.gameObject.SetActive(true);
    }
}