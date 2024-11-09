using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pass : MonoBehaviour
{   
    public GameObject imageObject;

    [SerializeField]
    private float imageDisplayTime = 2f;

    // Start is called before the first frame update
    void Start()
    {
        imageObject.SetActive(false);
    }

    void OnMouseDown() {
        StartCoroutine(DisplayImageAndProceed());
    }

    private IEnumerator DisplayImageAndProceed()
    {
 
        imageObject.SetActive(true);
        yield return new WaitForSeconds(imageDisplayTime);
        imageObject.SetActive(false);
        LoadNextScene();
    }

    private void LoadNextScene()
    {
        //SceneManager.LoadScene("SampleScene");  
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }


    // Update is called once per frame
    // void Update()
    // {
        
    // }
}
