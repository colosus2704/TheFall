using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;

public static class ScoresDB
{

    public static string dbName = "URI=file:Leaderboard.db";
    public static void CreateDB()
    {
        using(var connection = new SqliteConnection(dbName))
        {
            connection.Open();

            using (var command = connection.CreateCommand())
            {
                command.CommandText = "CREATE TABLE IF NOT EXISTS scores (score INT);";
                command.ExecuteNonQuery();
            }
            connection.Close();
        }
    }

    public static void AddScore(int Score)
    {
        using (var connection = new SqliteConnection(dbName))
        {
            connection.Open();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "INSERT INTO scores (score) VALUES ('" + Score + "');";
                command.ExecuteNonQuery();
            }
            connection.Close();
        }
        
    }

    public static string LeaderBoardPrint()
    {
        string a = "";
        using (var connection = new SqliteConnection(dbName))
        {
            connection.Open();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "SELECT * FROM scores ORDER BY score DESC;";
                using (var reader = command.ExecuteReader())
                {
                    
                    int counter = 0;

                    while(reader.Read())
                    {
                        a += reader["score"] + "\n";
                        counter += 1;
                        if(counter >= 10)
                        {
                            break;
                        }
                    }
                }
            }
            connection.Close();
        }
        return a;
    }
    
}
