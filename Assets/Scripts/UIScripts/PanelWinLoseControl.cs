using UnityEngine;
using UnityEngine.SceneManagement;

public class PanelWinLoseControl : MonoBehaviour
{
    [SerializeField] private GameObject panelWin;

    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && this.CompareTag("EndGame"))
        {
            panelWin.SetActive(true);
        }
    }
}
