using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;

public class SQLiteDB : MonoBehaviour
{
    public static SQLiteDB instance;
    private string dbName = "URI=file:Assets/Database.db";

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Para que el GameObject no se destruya al cambiar de escena
            CreateTable(); // Llama a CreateTable() solo cuando se crea la instancia por primera vez
        }
        else
        {
            Destroy(gameObject); // Si ya hay una instancia, destruye este GameObject para evitar duplicados
        }
    }

    private void CreateTable()
    {
        using (var connection = new SqliteConnection(dbName))
        {
            connection.Open();

            using (var command = connection.CreateCommand())
            {
                command.CommandText = "CREATE TABLE IF NOT EXISTS Player (idPlayer INTEGER PRIMARY KEY AUTOINCREMENT, " +
                    "username TEXT UNIQUE, email TEXT UNIQUE, password TEXT, date TEXT);";
                command.ExecuteNonQuery();
            }

            connection.Close();
        }
    }

    public void InsertPlayer(string username, string email, string password, string date)
    {
        using (var connection = new SqliteConnection(dbName))
        {
            connection.Open();

            using (var command = connection.CreateCommand())
            {
                command.CommandText = "INSERT INTO Player (username, email, password, date) VALUES (@username, @email, @password, @date)";
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@email", email);
                command.Parameters.AddWithValue("@password", password);
                command.Parameters.AddWithValue("@date", date);
                command.ExecuteNonQuery();
            }

            connection.Close();
        }
    }

}
