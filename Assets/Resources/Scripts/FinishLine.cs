using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    private AssetBundle SceneAssetBundle;
    private string[] scenePaths;
    public int currentScene;

    // Use this for initialization
    void Start()
    {
        // SceneAssetBundle = AssetBundle.LoadFromFile("../Scenes");
        // Debug.Log(SceneAssetBundle);
        // scenePaths = SceneAssetBundle.GetAllScenePaths();
        // Debug.Log(scenePaths);
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Player")){
            // Debug.Log("Scene2 loading: " + scenePaths[currentScene]);
            // SceneManager.LoadScene(scenePaths[currentScene], LoadSceneMode.Single);
        }
    }


}
