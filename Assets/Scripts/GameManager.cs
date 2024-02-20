using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TMP_InputField usernameInput;
    public TMP_InputField emailInput;
    public TMP_InputField passwordInput;
    public TMP_InputField dateInput;

    private void Start()
    {
        // No necesitas inicializar SQLiteDB aquí, ya que se inicializará automáticamente en Awake si no existe una instancia
    }

    public void RegisterButtonClicked()
    {
        string username = usernameInput.text;
        string email = emailInput.text;
        string password = passwordInput.text;
        string date = dateInput.text; // Obtén el valor del campo de entrada de fecha

        // Asegúrate de que los campos no estén vacíos antes de insertarlos
        if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(password) && !string.IsNullOrEmpty(date))
        {
            SQLiteDB.instance.InsertPlayer(username, email, password, date);
        }
        else
        {
            Debug.LogError("One or more input fields are empty.");
        }
    }
}
