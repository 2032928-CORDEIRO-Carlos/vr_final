using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject[] foodItems; // Tableau des aliments
    public GameObject player; // Le joueur
    public float gameTimer = 500.0f; // Temps en secondes
    public int totalFoodItems = 5; // Nombre total d'aliments
    public int foodEaten = 0; // Nombre d'aliments mangés
    public bool gameStarted = false;
    public bool gameEnded = false;  // Pour empêcher que la victoire et la défaite se fassent en même temps
    public GameObject gameoverMenu; // Menu de Game Over
    public GameObject victoryMenu; // Menu de Victoire

    void Start()
    {
        InitializeGame();
    }

    void Update()
    {
        if (gameStarted && !gameEnded)
        {
            if (gameTimer > 0)
            {
                gameTimer -= Time.deltaTime;
            }

            if (foodEaten >= totalFoodItems)
            {
                ShowVictory();
                gameEnded = true;
            }
            else if (gameTimer <= 0)
            {
                ShowGameOver();
                gameEnded = true;
            }
        }
    }

    /**
     * Méthode permettant de démarrer le jeu.
     */
    public void StartGame()
    {
        Debug.Log("StartGame called");
        gameStarted = true;
        gameEnded = false;
        gameTimer = 500.0f;  // On reset le timer
        foodEaten = 0; // Pareil pour la nourriture mangée
        foreach (GameObject food in foodItems)
        {
            food.SetActive(true);
        }
    }

    /**
     * Méthode permettant d'initialiser le jeu.
     */
    void InitializeGame()
    {
        foreach (GameObject food in foodItems)
        {
            food.SetActive(false);
        }
        gameoverMenu.SetActive(false);
        victoryMenu.SetActive(false);
        gameTimer = 500.0f;  // Reset du timer
    }

    /**
     * Méthode permettant de compter le nombre d'aliments mangés.
     */
    public void FoodEaten()
    {
        if (gameStarted && !gameEnded && foodEaten < totalFoodItems)
        {
            foodEaten++;
            Debug.Log("Food eaten: " + foodEaten);
        }
    }

    /**
     * Méthode permettant d'afficher le menu de Game Over.
     */
    void ShowGameOver()
    {
        gameStarted = false;
        PositionMenuInFrontOfPlayer(gameoverMenu);
        gameoverMenu.SetActive(true);
        Debug.Log("Game Over");
    }

    /**
     * Méthode permettant d'afficher le menu de Victoire.
     */
    void ShowVictory()
    {
        gameStarted = false;
        PositionMenuInFrontOfPlayer(victoryMenu);
        victoryMenu.SetActive(true);
        Debug.Log("Victory");
    }

    /**
     * Méthode permettant de positionner un menu devant le joueur.
     * @param menu: le menu à positionner en face du joueur.
     */
    void PositionMenuInFrontOfPlayer(GameObject menu)
    {
        Transform cameraTransform = Camera.main.transform;
        Vector3 menuPosition = cameraTransform.position + cameraTransform.forward * 2f + cameraTransform.up * 0.5f;
        menu.transform.position = menuPosition;
        menu.transform.rotation = Quaternion.Euler(0, cameraTransform.eulerAngles.y, 0);
    }

    /**
     * Méthode permettant de redémarrer le jeu.
     */
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    /**
     * Méthode permettant de quitter le jeu.
     */
    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
