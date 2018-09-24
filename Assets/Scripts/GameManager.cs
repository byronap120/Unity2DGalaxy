using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject uiGameCanvas;
    public GameObject spawnManagerPrefab;
    public GameObject playerPrefab;
    private bool gameOVer = true;

    private UIManager uiManager;
    private GameObject player;
    private GameObject spawManager;

    // Use this for initialization
    void Start()
    {
        uiManager = uiGameCanvas.GetComponent<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOVer)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                startNewGalaxyGame();
                gameOVer = false;
            }
        }
    }

    public void gameOverGalaxyGame()
    {
        gameOVer = true;

        // Hide score and lives images
        uiManager.gameOVer();

        // destroy player
        Destroy(player);

        // destroy spawn Manager
        Destroy(spawManager);
    }

    private void startNewGalaxyGame()
    {
        gameOVer = false;

        // restart uiManager
        uiManager.startNewGame();

        //new player 
        player = Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);

        // new spawnManager
        spawManager = Instantiate(spawnManagerPrefab, Vector3.zero, Quaternion.identity);
    }
}
