using UnityEngine;
using UnityEngine.UI; // Required for UI components

public class QuitGame : MonoBehaviour
{
    // This method can be linked to a button's OnClick event
    public void Quit()
    {
        Debug.Log("Quit button clicked. Exiting game...");

        // If running in the editor, stop play mode
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // If running as a standalone application, quit the application
        Application.Quit();
#endif
    }
}