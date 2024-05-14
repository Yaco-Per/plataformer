using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool gameOver = false;
    public static bool winCondition = false;
    public static int actualPlayer = 0;

    public GameObject player1Prefab; // Prefab del jugador 1
    public GameObject player2Prefab; // Prefab del jugador 2
    public Controller_Target target1;
    public Controller_Target target2;

    private Controller_Player player1;
    private Controller_Player player2;

    void Start()
    {
        Physics.gravity = new Vector3(0, -30, 0);
        gameOver = false;
        winCondition = false;
        SpawnPlayers();
        SetConstraits();
    }

    void Update()
    {
        GetInput();
        CheckWin();
    }

    private void CheckWin()
    {
        if (target1.playerOnTarget && target2.playerOnTarget)
        {
            winCondition = true;
        }
    }

    private void GetInput()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            actualPlayer = actualPlayer == 1 ? 0 : 1;
            SetConstraits();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            actualPlayer = actualPlayer == 0 ? 1 : 0;
            SetConstraits();
        }
    }

    public void PlayerReachedTarget(int playerNumber)
    {
        if (playerNumber == 1)
        {
            target1.playerOnTarget = true;
        }
        else if (playerNumber == 2)
        {
            target2.playerOnTarget = true;
        }
    }

    private void SetConstraits()
    {
        if (actualPlayer == 0)
        {
            player1.rb.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
            player2.rb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
        }
        else
        {
            player2.rb.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
            player1.rb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
        }
    }

    private void SpawnPlayers()
    {
        // Spawn del jugador 1
        GameObject player1GO = Instantiate(player1Prefab, Vector3.zero, Quaternion.identity);
        player1 = player1GO.GetComponent<Controller_Player>();

        // Spawn del jugador 2
        GameObject player2GO = Instantiate(player2Prefab, Vector3.zero, Quaternion.identity);
        player2 = player2GO.GetComponent<Controller_Player>();
    }
}
