using UnityEngine;
using UnityEngine.SceneManagement;

public class PressToRestartScene : MonoBehaviour
{
    public KeyCode buttonToPress;

    private void Update()
    {
        if (Input.GetKey(buttonToPress))
        {
            var currentScene = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentScene);
        }
    }
}
