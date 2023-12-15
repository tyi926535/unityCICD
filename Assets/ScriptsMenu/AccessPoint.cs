using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System;
using System.Data;
using System.IO;
using Unity.VisualScripting;

public class AccessPoint : MonoBehaviour
{
    static SqliteConnection dbconect;
    SqliteConnection unconect;
    private SqliteCommand command=new SqliteCommand();
    string sqlQuery;
    IDbCommand dbcmd;
    private IDbConnection dbconn;
    static string pathsql;
    static string fn1 = "/compoundBD/db.bytes";
    // Start is called before the first frame update
    void Start()
    {
        string filepath = "C:\\pro" + fn1;
        pathsql = "URI=file:" + filepath;
        dbconect = new SqliteConnection(pathsql);
        ReadTable();
    }

    public void ReadTable()
    {
        using (dbconect = new SqliteConnection(pathsql))
        {
            dbconect.Open();
            if (dbconect.State == ConnectionState.Open)
            {
                command.Connection = dbconect;

                
                string scoreboard = ("SELECT * FROM bd");
                string sqlQuery2 ="SELECT name FROM usernow WHERE idbd = 0;" + ";"
                    + "SELECT password FROM usernow WHERE idbd = 0;";

                command.CommandText = scoreboard;
                SqliteDataReader r= command.ExecuteReader();
                List<string> str = new List<string>();
                while(r.Read())
                {
                    str.Add(String.Format("{1},{2},{3},{4};", r[0], r[1], r[2], r[3], r[4])) ;
                }
                foreach (string str2 in str)
                {
                    Debug.Log(str2);
                }

                //Debug.Assert(r.Read());
                //string idBestPlayer = r.ToString();


               // dbconn.Close();
            }
            else { Debug.Log("Error"); }
            /*
            // ѕолучаем полный список пользователей
            DataTable scoreboard = DataBase.GetTable("SELECT * FROM BDUsers ORDER BY BD DESC;");

            int idBestPlayer = int.Parse(scoreboard.Rows[0][1].ToString());
            string nickname = DataBase.ExecuteQueryWithoutAnswer($"SELECT name FROM UserNow WHERE password = {idBestPlayer};");
            Debug.Log($"ƒействующий пользователь {nickname} пароль: {scoreboard.Rows[0][2].ToString()}");
            */
        }
    }

    static void CopyStart()
    {
        string filepath = "C:\\pro" + fn1;
        pathsql = "URI=file:" + filepath;
        dbconect = new SqliteConnection(pathsql);
    }
    internal static string[] UserSearch(string nameBC,string passwordBC) //MainEntrance
    {
        string[] fil = new string[4];
        SqliteCommand command1 = new SqliteCommand();
        CopyStart();
        using (SqliteConnection dbconect1 = new SqliteConnection(pathsql))
        {
            dbconect1.Open();
            if (dbconect1.State == ConnectionState.Open)
            {
                command1.Connection = dbconect1;
                string scoreboard = ("SELECT password,active,length FROM bd WHERE name LIKE '"+ nameBC +"'");
                command1.CommandText = scoreboard;
                SqliteDataReader r = command1.ExecuteReader();
                if (r.HasRows)
                {
                    fil[0] = nameBC;
                    fil[1] = r[0].ToString();
                    fil[2] = r[1].ToString();
                    fil[3]= r[2].ToString();
                }
                else { Debug.Log("Error"); }

            }
            else { Debug.Log("Error"); }
        }
        return fil;
    }

    internal static void AUusernow(string[] catalog) //MainEntrance FirstEnt
    {
        SqliteCommand command2 = new SqliteCommand();
        CopyStart();
        using (SqliteConnection dbconect2 = new SqliteConnection(pathsql))
        {
            dbconect2.Open();
            if (dbconect2.State == ConnectionState.Open)
            {
                command2.Connection = dbconect2;
                
                string scoreboard = ("UPDATE usernow SET name='" + catalog[0] +"', password='"+ catalog[1] + "', active='"+ catalog[2] + "', length='"+ catalog[3] + "' WHERE id = 0;");
                command2.CommandText = scoreboard;
                command2.ExecuteNonQuery();
            }
            else { Debug.Log("Error"); }
        }
    }
    internal static void AUbd(string[] catalog) //MainEntrance
    {
        SqliteCommand command2 = new SqliteCommand();
        CopyStart();
        using (SqliteConnection dbconect2 = new SqliteConnection(pathsql))
        {
            dbconect2.Open();
            if (dbconect2.State == ConnectionState.Open)
            {
                command2.Connection = dbconect2;

                string scoreboard = ("UPDATE bd SET name='" + catalog[0] + "', password='" + catalog[1] + "', active='" + catalog[2] + "', length='" + catalog[3] + "' WHERE id = 0;");
                command2.CommandText = scoreboard;
                command2.ExecuteNonQuery();
            }
            else { Debug.Log("Error"); }
        }
    }

    internal static int chekingNull() //MainEntrance
    {
        SqliteCommand command0 = new SqliteCommand();
        CopyStart();
        int zn = 0;
        using (SqliteConnection dbconect0 = new SqliteConnection(pathsql))
        {
            dbconect0.Open();
            if (dbconect0.State == ConnectionState.Open)
            {
                command0.Connection = dbconect0;
             
                string scoreboard = ("SELECT COUNT(*) FROM bd;");
                command0.CommandText = scoreboard;
                object r = command0.ExecuteScalar();
                int f = Convert.ToInt32(r);
                if (f>0)
                {
                    zn = f;
                }
            }
            else { Debug.Log("Error"); }
        }
        return zn;
    }
    internal static string[] UserSearch2(int idBC) //ListUsers
    {
        string[] fil = new string[4];
        SqliteCommand command1 = new SqliteCommand();
        CopyStart();
        using (SqliteConnection dbconect1 = new SqliteConnection(pathsql))
        {
            dbconect1.Open();
            if (dbconect1.State == ConnectionState.Open)
            {
                command1.Connection = dbconect1;
                string scoreboard = ("SELECT name,password,length,active FROM bd WHERE id LIKE '" + idBC + "';");
                command1.CommandText = scoreboard;
                SqliteDataReader r = command1.ExecuteReader();
                if (r.HasRows)
                {
                    fil[0] = r[0].ToString();
                    fil[1] = r[1].ToString();
                    fil[2] = r[2].ToString();
                    fil[3] = r[3].ToString();
                }
                else { Debug.Log("Error"); }

            }
            else { Debug.Log("Error"); }
        }
        return fil;
    }

    internal static void AUbd2(string[] catalog) //ListUser2
    {
        SqliteCommand command2 = new SqliteCommand();
        CopyStart();
        using (SqliteConnection dbconect2 = new SqliteConnection(pathsql))
        {
            dbconect2.Open();
            if (dbconect2.State == ConnectionState.Open)
            {
                command2.Connection = dbconect2;

                string scoreboard = ("UPDATE bd SET active='" + catalog[2] + "', length='" + catalog[1] + "' WHERE name = '"+ catalog[0] + "';");
                command2.CommandText = scoreboard;
                command2.ExecuteNonQuery();
            }
            else { Debug.Log("Error"); }
        }
    }
    internal static string[] UserGet() //ChangePassword
    {
        string[] fil = new string[3];
        SqliteCommand command1 = new SqliteCommand();
        CopyStart();
        using (SqliteConnection dbconect1 = new SqliteConnection(pathsql))
        {
            dbconect1.Open();
            if (dbconect1.State == ConnectionState.Open)
            {
                command1.Connection = dbconect1;
                string scoreboard = ("SELECT name,password,length FROM usernow WHERE id=0;");
                command1.CommandText = scoreboard;
                SqliteDataReader r = command1.ExecuteReader();
                if (r.HasRows)
                {
                    fil[0] = r[0].ToString();
                    fil[1] = r[1].ToString();
                    fil[2] = r[2].ToString();
                }
                else { Debug.Log("Error"); }

            }
            else { Debug.Log("Error"); }
        }
        return fil;
    }
    internal static void AUusernow2(string passw) //ChangePassword
    {
        SqliteCommand command2 = new SqliteCommand();
        CopyStart();
        using (SqliteConnection dbconect2 = new SqliteConnection(pathsql))
        {
            dbconect2.Open();
            if (dbconect2.State == ConnectionState.Open)
            {
                command2.Connection = dbconect2;

                string scoreboard = ("UPDATE usernow SET password='" + passw + "' WHERE id = 0;");
                command2.CommandText = scoreboard;
                command2.ExecuteNonQuery();
            }
            else { Debug.Log("Error"); }
        }
    }
    internal static void AUbd3(string namenow,string passw) //ChangePassword
    {
        SqliteCommand command2 = new SqliteCommand();
        CopyStart();
        using (SqliteConnection dbconect2 = new SqliteConnection(pathsql))
        {
            dbconect2.Open();
            if (dbconect2.State == ConnectionState.Open)
            {
                command2.Connection = dbconect2;
                string scoreboard = ("UPDATE bd SET password='" + passw + "' WHERE name ='"+namenow+"';");
                command2.CommandText = scoreboard;
                command2.ExecuteNonQuery();
            }
            else { Debug.Log("Error"); }
        }
    }

    internal static int UserSearch2(string nameBC) //AddUsers
    {
        SqliteCommand command1 = new SqliteCommand();
        CopyStart();
        int zn=0;
        using (SqliteConnection dbconect1 = new SqliteConnection(pathsql))
        {
            dbconect1.Open();
            if (dbconect1.State == ConnectionState.Open)
            {
                command1.Connection = dbconect1;
                string scoreboard = ("SELECT id FROM bd WHERE name= '" + nameBC + "'");
                command1.CommandText = scoreboard;
                SqliteDataReader r = command1.ExecuteReader();
                if (r.HasRows)
                {
                    zn = 1;
                }

            }
            else { Debug.Log("Error"); }
        }
        return zn;
    }
    internal static void addUser(string[] fil) //AddUsers
    {
        SqliteCommand command2 = new SqliteCommand();
        CopyStart();
        int idbr=chekingNull();
        using (SqliteConnection dbconect2 = new SqliteConnection(pathsql))
        {
            dbconect2.Open();
            if (dbconect2.State == ConnectionState.Open)
            {
                command2.Connection = dbconect2;
                string scoreboard = ("INSERT INTO bd (id,name,password,length,active) VALUES ("+idbr+",'" + fil[0] + "','" + fil[1] + "','0',1);");
                command2.CommandText = scoreboard;
                command2.ExecuteNonQuery();
            }
            else { Debug.Log("Error"); }
        }
    }

    internal static void DeleteBD() //formatData
    {
        SqliteCommand command2 = new SqliteCommand();
        CopyStart();
        int idbr = chekingNull();
        using (SqliteConnection dbconect2 = new SqliteConnection(pathsql))
        {
            dbconect2.Open();
            if (dbconect2.State == ConnectionState.Open)
            {
                command2.Connection = dbconect2;
                string scoreboard = ("DELETE FROM bd WHERE id!=0;");
                command2.CommandText = scoreboard;
                command2.ExecuteNonQuery();
            }
            else { Debug.Log("Error"); }
        }
    }


}
