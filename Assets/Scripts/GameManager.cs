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
        // No necesitas inicializar SQLiteDB aqu�, ya que se inicializar� autom�ticamente en Awake si no existe una instancia
    }

    public void RegisterButtonClicked()
    {
        string username = usernameInput.text;
        string email = emailInput.text;
        string password = passwordInput.text;
        string date = dateInput.text; // Obt�n el valor del campo de entrada de fecha

        // Aseg�rate de que los campos no est�n vac�os antes de insertarlos
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
