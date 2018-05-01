using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LoadOnClick : MonoBehaviour {

    //public GameObject loadingImage;

    public void LoadScene(int Level)
    {
        //loadingImage.SetActive(true);
        SceneManager.LoadScene(Level);
    }
}
