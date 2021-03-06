using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneController : Singleton<SceneController>
{

    private bool loadScene = false;
    //private bool gameStarted = false;

    [SerializeField]
    private int scene;
    public Image transitionImage;

    [ArrayElementTitle("name")]
    public GameScene[] scenes;


    [System.Serializable]
    public class GameScene
    {
        public int id = 0;
        public string name = "-";
        public bool inTransition = true;
        public bool outTransition = true;
        public Material skyboxMaterial;
    }

    private void Awake()
    {

        AudioManager.Instance.UpdateSceneTheme(0);

    }

    // Updates once per frame
    void Update()
    {


        // If the player has pressed the space bar and a new scene is not loading yet...
        if (Input.GetKeyUp(KeyCode.Tab) && loadScene == false)
        {

            LoadScene(scene);

        }

        // If the new scene has started loading...
        if (loadScene == true)
        {

            // ...then pulse the transparency of the loading text to let the player know that the computer is still working.

        }

    }

    public void LoadScene(int sceneIndex)
    {


        //if (sceneIndex == 1)
        //{
        //    if (!gameStarted)
        //    {
        //        gameStarted = true;

        //    }
        //    else
        //    {
        //        return;
        //    }
        //}




        //    // ...set the loadScene boolean to true to prevent loading a new scene more than once...
        //    loadScene = true;

        //    // ...change the instruction text to read "Loading..."

        //    // ...and start a coroutine that will load the desired scene.

        //    Scene scene = SceneManager.GetActiveScene();

        //    if (scene.buildIndex <= scenes.Length - 1)
        //    {
        //        if (scenes[scene.buildIndex].outTransition)
        //        {
        //            fadingOut = true;

        //            StartCoroutine(FadeOut());
        //        }
        //    }



            StartCoroutine(LoadNewScene(sceneIndex));
        
    }

    //bool fadingOut = false;
    //bool fadingIn = false;

    private IEnumerator FadeOut()
    {
        transitionImage.enabled = true;

        transitionImage.color = new Color(transitionImage.color.r, transitionImage.color.g, transitionImage.color.b, 0);

        float multiplier = 0f;

        while (multiplier < 2f)
        {
            multiplier += Time.deltaTime * 2f;

            transitionImage.color = new Color(transitionImage.color.r, transitionImage.color.g, transitionImage.color.b, multiplier);

            yield return null;
        }

        //fadingOut = false;
    }

    private IEnumerator FadeIn()
    {
        transitionImage.enabled = true;
        transitionImage.color = new Color(transitionImage.color.r, transitionImage.color.g, transitionImage.color.b, 1.5f);

        float multiplier = 2f;

        while (loadScene)
        {
            yield return null;
        }

        while (multiplier > 0)
        {
            multiplier -= Time.deltaTime * 1.3f;
            transitionImage.color = new Color(transitionImage.color.r, transitionImage.color.g, transitionImage.color.b, multiplier);
            yield return null;
        }

        //fadingIn = false;
    }

    // The coroutine runs on its own at the same time as Update() and takes an integer indicating which scene to load.
    private IEnumerator LoadNewScene(int sceneIndex)
    {
        //while (fadingOut)
        //{
        //    yield return null;
        //}


        AudioManager.Instance.StopAllSounds();

        //// Start an asynchronous operation to load the scene that was passed to the LoadNewScene coroutine.
        //AsyncOperation asyncLoadingScreen = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(2);

        //while (!asyncLoadingScreen.isDone)
        //{
        //    yield return null;
        //}

        //transitionImage.enabled = false;

        //yield return new WaitForSeconds(1);

        AsyncOperation asyncLoadScene = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(sceneIndex);

        // While the asynchronous operation to load the new scene is not yet complete, continue waiting until it's done.
        while (!asyncLoadScene.isDone)
        {
            yield return null;
        }
        //loadScene = false;

        //FindObjectOfType<AudioManager>().UpdateSceneTheme(sceneIndex);

        //if (scenes[sceneIndex].inTransition)
        //{
        //    fadingIn = true;
        //    StartCoroutine(FadeIn());

        //    while (fadingIn)
        //    {
        //        yield return null;
        //    }
        //}

        if (scenes[sceneIndex].skyboxMaterial != null)
        {
            RenderSettings.skybox = scenes[sceneIndex].skyboxMaterial;
        }
    }
}
