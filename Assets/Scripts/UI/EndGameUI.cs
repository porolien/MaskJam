using UnityEngine;

public class EndGameUI : MonoBehaviour
{
    public void StartAnim()
    {
        GetComponent<Animator>().SetTrigger("Start");
    }

    public void EndTheGame()
    {
        Application.Quit();
    }
}