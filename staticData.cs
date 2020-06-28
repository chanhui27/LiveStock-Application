using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace Application_Overall_App_task
{
    public static class staticData
    {
        //set static variable: OleDbConnection, OleDbCommand, query, strcon and dictionary 
        public static OleDbConnection myConn;
        public static OleDbCommand cmd;
        public static Dictionary<int, LiveStock> myFarm = new Dictionary<int, LiveStock>();
        public static string query;
        public static string strcon = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source =
                                    C:\Users\ann27\OneDrive - Wintec\Application_Overall_App_task\Application_Overall_App_task\FarmInfomation.accdb;
                                    Persist Security Info = False"; //database pathway
        public static void callDatabase() //calling each tables from database
        {
            //receive database pathway to connect to the right database
            myConn = new OleDbConnection(strcon);
            myConn.Open(); //open database

            callCows(); //call cows' information
            callGoats(); //call goats' information
            callDogs(); //call dogs' information
            callSheep(); //call sheeps' information
            callPrices(); //call prices' table information
        }

        public static void callCows()
        {
            //set query statement
            query = "SELECT * FROM Cows";
            //set command
            cmd = new OleDbCommand(query, myConn);

            using (OleDbDataReader reader = cmd.ExecuteReader()) //OleDbDataReader will read the command
            {
                while (reader.Read()) //while reader reads the command
                {
                    //get all the data from the table and convert it to correct format type
                    string ID = reader["ID"].ToString();
                    int id = Convert.ToInt32(ID);
                    string AmtWater = reader["Amount of water"].ToString();
                    double amtWater = Convert.ToDouble(AmtWater);
                    string DailyCost = reader["Daily cost"].ToString();
                    double dailyCost = Convert.ToDouble(DailyCost);
                    string Weight = reader["Weight"].ToString();
                    double weight = Convert.ToDouble(Weight);
                    string Age = reader["Age"].ToString();
                    int age = Convert.ToInt32(Age);
                    string color = reader["Color"].ToString();
                    string AmountMilk = reader["Amount of milk"].ToString();
                    double amtMilk = Convert.ToDouble(AmountMilk);
                    string IsJersy = reader["Is jersy"].ToString();
                    bool isJersy = Convert.ToBoolean(IsJersy);
                    string type="Cow"; //set type as "Cow"

                    if (isJersy == true) //when isJersy is true 
                    {
                        //set this data into Jersy_Cow class
                        //and add it to dictionary
                        type = "Jersy Cow";
                        LiveStock ls = new Jersey_Cow(id, amtWater, dailyCost, weight, age, color, amtMilk, isJersy, type);
                        myFarm.Add(id, ls);
                    }
                    else
                    {
                        //if not, add it to Cow class
                        //and add it to dictionary
                        LiveStock ls1 = new Cow(id, amtWater, dailyCost, weight, age, color, amtMilk, isJersy, type);
                        myFarm.Add(id, ls1);
                    }
                }
            }
        }

        public static void callGoats()
        { 
            //set query statement
            query = "SELECT * FROM Goats";
            //set command
            cmd = new OleDbCommand(query, myConn);

            using (OleDbDataReader reader = cmd.ExecuteReader()) //OleDbDataReader will read the command
            {
                while (reader.Read()) //while reader reads the command
                {
                    //get all the data from the table and convert it to correct format type
                    string ID = reader["ID"].ToString();
                    int id = Convert.ToInt32(ID);
                    string AmtWater = reader["Amount of water"].ToString();
                    double amtWater = Convert.ToDouble(AmtWater);
                    string DailyCost = reader["Daily cost"].ToString();
                    double dailyCost = Convert.ToDouble(DailyCost);
                    string Weight = reader["Weight"].ToString();
                    double weight = Convert.ToDouble(Weight);
                    string Age = reader["Age"].ToString();
                    int age = Convert.ToInt32(Age);
                    string color = reader["Color"].ToString();
                    string AmountMilk = reader["Amount of milk"].ToString();
                    double amtMilk = Convert.ToDouble(AmountMilk);
                    string type = "Goat"; //set type as "Goat"

                    LiveStock ls2 = new Goat(id, amtWater, dailyCost, weight, age, color, amtMilk, type); //call Goat class to get the data
                    myFarm.Add(id, ls2); //and add it to dictionary
                }
            }
        }

        public static void callDogs()
        {
            //set query statement
            query = "SELECT * FROM Dogs";
            //set command
            cmd = new OleDbCommand(query, myConn);

            using (OleDbDataReader reader = cmd.ExecuteReader())//OleDbDataReader will read the command
            {
                while (reader.Read()) //while reader reads the command
                {
                    //get all the data from the table and convert it to correct format type
                    string ID = reader["ID"].ToString();
                    int id = Convert.ToInt32(ID);
                    string AmtWater = reader["Amount of water"].ToString();
                    double amtWater = Convert.ToDouble(AmtWater);
                    string DailyCost = reader["Daily cost"].ToString();
                    double dailyCost = Convert.ToDouble(DailyCost);
                    string Weight = reader["Weight"].ToString();
                    double weight = Convert.ToDouble(Weight);
                    string Age = reader["Age"].ToString();
                    int age = Convert.ToInt32(Age);
                    string color = reader["Color"].ToString();
                    string type = "Dog";

                    LiveStock ls3 = new Dog(id, amtWater, dailyCost, weight, age, color, type); //call Dog class to get the data
                    myFarm.Add(id, ls3); //and add it to dictionary
                }
            }
        }

        public static void callSheep()
        {
            //set query statement
            query = "SELECT * FROM Sheep";
            //set command
            cmd = new OleDbCommand(query, myConn);

            using (OleDbDataReader reader = cmd.ExecuteReader())//OleDbDataReader will read the command
            {
                while (reader.Read())//while reader reads the command
                {
                    //get all the data from the table and convert it to correct format type
                    string ID = reader["ID"].ToString();
                    int id = Convert.ToInt32(ID);
                    string AmtWater = reader["Amount of water"].ToString();
                    double amtWater = Convert.ToDouble(AmtWater);
                    string DailyCost = reader["Daily cost"].ToString();
                    double dailyCost = Convert.ToDouble(DailyCost);
                    string Weight = reader["Weight"].ToString();
                    double weight = Convert.ToDouble(Weight);
                    string Age = reader["Age"].ToString();
                    int age = Convert.ToInt32(Age);
                    string color = reader["Color"].ToString();
                    string AmountWool = reader["Amount of wool"].ToString();
                    double amtWool = Convert.ToDouble(AmountWool);
                    string type = "Sheep";

                    LiveStock ls4 = new Sheep(id, amtWater, dailyCost, weight, age, color, amtWool, type);//call Sheep class to get the data
                    myFarm.Add(id, ls4);//and add it to dictionary
                }
            }
        }

        public static void callPrices()
        {
            string table = "Rates and prices";
            query = "SELECT * FROM " + "[" + table + "]";  //set query statement
            cmd = new OleDbCommand(query, myConn); //set command
            using (OleDbDataReader reader = cmd.ExecuteReader())//OleDbDataReader will read the command
            {
                while (reader.Read())//while reader reads the command
                {
                    //get all the prices from the table and convert it to correct format type
                    Prices.goat_milk = Convert.ToDouble(reader["Goat milk price"]);
                    Prices.cow_milk = Convert.ToDouble(reader["Cow milk price"]);
                    Prices.sheep_wool = Convert.ToDouble(reader["Sheep wool price"]);
                    Prices.water = Convert.ToDouble(reader["Water price"]);
                    Prices.tax = Convert.ToDouble(reader["Tax"]);
                    Prices.jersy_tax = Convert.ToDouble(reader["Jersy cow tax"]);
                }
            }
        }
    }
}