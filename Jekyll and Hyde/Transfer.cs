using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class Transfer : MonoBehaviour 
{
    private ElectronicsV2 input;
    [SerializeField] private Object sceneAsset = null;
    bool IsValidSceneAsset
    {
        get
        {
            if (sceneAsset == null)
                return false;
            return sceneAsset.GetType().Equals(typeof(SceneAsset));
        }
    }

    void Start()
    {
        input = gameObject.GetComponent<ElectronicsV2>();
    }
    // Update is called once per frame
    void Update () 
    {
        if (input.Output == true)
        {
            //Scene sceneToLoad = SceneManager.GetSceneByName(nextScene.name);
            SceneManager.LoadScene(sceneAsset.name, LoadSceneMode.Single);
        }
    }
}
