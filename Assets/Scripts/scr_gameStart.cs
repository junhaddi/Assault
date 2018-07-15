using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scr_gameStart : MonoBehaviour {

	public void goto_next_room()
    {
        SceneManager.LoadScene("inGame");
    }
}
