using UnityEngine;

public class Controller_Player : MonoBehaviour
{
    public Rigidbody rb; // El rigidbody del jugador
    public int playerNumber; // Número de jugador
    public GameManager gameManager; // Referencia al GameManager

    private void Start()
    {
        rb = GetComponent<Rigidbody>(); // Obtener el Rigidbody del jugador
        gameManager = FindObjectOfType<GameManager>(); // Buscar GameManager en la escena
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Verificar si colisionamos con el objetivo
        if (collision.gameObject.CompareTag("Target"))
        {
            // Indicar al GameManager que el jugador está en el objetivo
            gameManager.PlayerReachedTarget(playerNumber);
        }
    }
}
