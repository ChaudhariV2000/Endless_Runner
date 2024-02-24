using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaeManager : MonoBehaviour


{
    public static bool gameover;
    public static bool isgamestarted;
    public GameObject startstring;
    public GameObject gameoverpanel;
    // Start is called before the first frame update
    void Start()
    {
        gameover = false;
        Time.timeScale = 1;
        isgamestarted = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (gameover)
        {
            Time.timeScale = 0;
            gameoverpanel.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            isgamestarted = true;
            Destroy(startstring);
        }
    }
}
