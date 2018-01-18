using System;
using System.Collections.Generic;
using DbConnection;

namespace crudsql_proj
{
    class Program
    {
        static void Main(string[] args)
        {
            //while the program is running
            while (true)
            {

                System.Console.WriteLine("what would you like to do? create, read, update, or destroy?");
                string line = Console.ReadLine();
                if (line == "create")
                {
                    System.Console.WriteLine("type 'first name', 'last name', and fave number (separated by commas)"); //prompt
                    string create = Console.ReadLine(); //receives client input
                    DbConnector.Execute($"INSERT INTO users (first_name, last_name, faveNumber) VALUES ({create})"); //SQL query to create in db 
                    System.Console.WriteLine("user created!"); //confirmation
                }
                if (line == "read")
                {
                    List<Dictionary<string, object>> usersdb = new List<Dictionary<string, object>>(); //creates compatible structure as db rows
                    usersdb = DbConnector.Query("select * from users"); //SQL query to read all rows from db

                    foreach (var dictionary in usersdb) //grabs the dictionaries from the List
                    {
                        foreach (var x in dictionary) //grabs each key value pair from the dictionary
                        {
                            System.Console.WriteLine(x.Key + " - " + x.Value); //displays the rows
                        }
                    }
                }
                if (line == "update")
                {
                    System.Console.WriteLine("which row would you like to update? (input id)");
                    string updateId = Console.ReadLine(); //saves id inputted
                    System.Console.WriteLine("update the first name");
                    string updateFirst = Console.ReadLine(); //saves first name inputted
                    System.Console.WriteLine("update the last name");
                    string updateLast = Console.ReadLine(); //saves last name inputted
                    System.Console.WriteLine("update the fave number");
                    string updateNum = Console.ReadLine(); //saves fave num inputted
                    DbConnector.Execute($"UPDATE users SET first_name='{updateFirst}', last_name='{updateLast}', faveNumber='{updateNum}' WHERE id={updateId}"); //SQL query to update specific row with saved inputs
                    System.Console.WriteLine("user updated!"); //confirmation
                }
                if (line == "destroy")
                {
                    System.Console.WriteLine("input the id that you would like to delete");
                    string deleteId = Console.ReadLine();
                    System.Console.WriteLine($"are you sure you want to delete user with id: {deleteId}?");
                    string yesno = Console.ReadLine();
                    if (yesno == "yes") //if no, this if-statement will exit
                    {
                        DbConnector.Execute($"DELETE FROM users WHERE id = {deleteId}"); //SQL query to delete row 
                    }
                }
                if (line == "exit") //ends program
                {
                    break;
                }

            }
        }
    }
}
