using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour {
    bool load;
    GameObject cam;

	// Use this for initialization
	void Start () {
        load = false;
        cam = GameObject.Find("MainCamera");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter2D(Collider2D other)
    {
        print("Collide");
        if(other.tag == "Player"){
            if(!load){
                load = true; 
                StartCoroutine(changeScene(other.gameObject));
            }
        }
    }
    IEnumerator changeScene(GameObject player){
        Scene curScene = SceneManager.GetActiveScene();
        if (name == "loadShipPt1")
        {
            SceneManager.LoadScene("ShipPt1", LoadSceneMode.Additive);
            SceneManager.MoveGameObjectToScene(player, SceneManager.GetSceneByName("ShipPt1"));
            SceneManager.MoveGameObjectToScene(cam, SceneManager.GetSceneByName("ShipPt1"));
            player.transform.position = new Vector3(88, 42, 0);
        }
        else if (name == "loadShipPt2")
        {
            SceneManager.LoadScene("ShipPt2", LoadSceneMode.Additive);
            SceneManager.MoveGameObjectToScene(player, SceneManager.GetSceneByName("ShipPt2"));
            SceneManager.MoveGameObjectToScene(cam, SceneManager.GetSceneByName("ShipPt2"));
            player.transform.position = new Vector3(-12f, 1.5f, 0);
        } else if (name == "loadStart"){
            SceneManager.LoadScene("ShipPt1", LoadSceneMode.Additive);
            SceneManager.MoveGameObjectToScene(player, SceneManager.GetSceneByName("ShipPt1"));
            SceneManager.MoveGameObjectToScene(cam, SceneManager.GetSceneByName("ShipPt1"));
            player.transform.position = new Vector3(-1f, 1.03f, 0);
        }

        yield return null;
        SceneManager.UnloadSceneAsync(curScene);
    }

}
