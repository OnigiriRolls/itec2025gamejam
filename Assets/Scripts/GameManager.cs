using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Animator transitionAnim;
    public string sceneName;

    public void Exit()
    {
        Application.Quit();
    }

    public void ChangeScene()
    {
        StartCoroutine(LoadScene());
    }

    IEnumerator LoadScene()
    {
        if (!transitionAnim.gameObject.activeInHierarchy)
            transitionAnim.gameObject.SetActive(true);
        transitionAnim.SetTrigger("fadeIn");
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(sceneName);
    }
}
