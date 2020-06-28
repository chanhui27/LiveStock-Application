using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms.VisualStyles;

namespace Application_Overall_App_task //self marking: 70
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            staticData.callDatabase(); //call database() from staticData Class
        }

        Dictionary<int, LiveStock> myFarm = staticData.myFarm; //get dictionary from staticData class

        //report 1
        private void bt_searchID_Click(object sender, EventArgs e) //display the information by id
        {
            try
            {
                int id = Convert.ToInt32(tb_id.Text); //convert string type of id into int type

                if (myFarm.ContainsKey(id)) //check if dictionary contains the key
                {
                    for (int count = 0; count < myFarm.Count; count++)
                    {
                        //create variable to get element from the dictionary
                        var element = this.myFarm.ElementAt(count);
                        if (element.Key == id)
                        {
                            //call displayInfo method to display the information
                            tb_result.Text = element.Value.displayInfo();
                        }
                    }
                }
                else //if dictionary doesn't have the id
                {
                    //display the message
                    MessageBox.Show("Can't find the " + id);
                }
            }catch(Exception error) //if any error caught
            {
                //show error message
                MessageBox.Show(error.Message);
            }
        }
                
        //report2
        private double totalProfit() 
        {
            double total_profit =0.0;//initialize total_profit

            //iterate througth the hash table
            for (int count = 0; count < myFarm.Count; count++)
            {
                //create variable to get element from the dictionary
                var element = this.myFarm.ElementAt(count);
                total_profit += element.Value.calculateProfit();//call calculateProfit method to find the total profitability
            }
            return Math.Round(total_profit, 2); //return the total profit using Round method to round up to 2 decimal 
        }
        //button for report 2
        private void bt_calculateProfit_Click(object sender, EventArgs e)
        {
            double total_profit;
            total_profit = totalProfit(); //get profit from totalProfit()
            tb_tProfit.Text = total_profit.ToString(); //display the profit
        }

        //report3
        private double totalTax() //calculate total tax (exclude dog)
        {
            double total_tax = 0.0;
            //iterate througth the hash table
            for (int count = 0; count < myFarm.Count; count++)
            {
                //create variable to get element from the dictionary
                var element = this.myFarm.ElementAt(count);
                if(element.Value.getType() == "Dog") //if dictionary value's type is dog
                {
                    continue; //ignore and continue 
                }
                total_tax += element.Value.calculateTax();//call calculateProfit method to find the total profitability
            }
            return Math.Round(total_tax, 2); //return the total profit using Round method to round up to 2 decimal 
        }
        //button for report 3
        private void bt_calculateTax_Click(object sender, EventArgs e)
        {
            double total_tax;
            total_tax = totalTax(); //get tax value from totalTax()
            tb_tTax.Text = total_tax.ToString(); //display the tax 
        }

        //report4
        private double totalAmtMilkGoatCow()//claculate total amount of milk goat and cow (exclude Jersy cow)
        {
            double total_amtMilk = 0.0;
            
            //iterate througth the hash table
            for (int count = 0; count < myFarm.Count; count++)
            {
                //create variable to get element from the dictionary
                var element = this.myFarm.ElementAt(count);
                if (element.Value.getType() == "Goat" || element.Value.getType() == "Cow") //check whether the type is goat or cow
                {
                    total_amtMilk += element.Value.getMilk(); //get amount of milk from goat adn cow class and add it to total_amtMilk
                }                
            }   
            return Math.Round(total_amtMilk,2); //return the total amount of milk (round up to decimal 2)
        }
        //button for report 4
        private void bt_calculateTotalMilk_Click(object sender, EventArgs e)
        {
            double total_amtMilk;
            total_amtMilk = totalAmtMilkGoatCow(); //get total amount of milk from the method
            tb_tMilk_gc.Text = total_amtMilk.ToString(); //display the value
        }

        //report5
        private int averageAge() //calculate average age (exclude dog)
        {
            //initialize variables
            int total_age = 0;
            int num = 0; //count the number of animals in the dictionary
            int avgAge;

            //iterate through hash table
            for (int count = 0; count < myFarm.Count; count++)
            {                
                //create variable to get element from the dictionary
                var element = this.myFarm.ElementAt(count);
                if(element.Value.getType() == "Dog") //if value's type is dog
                {
                    continue; //ignore and continue
                }
                else
                {
                    //call method to get total age of the animal
                    total_age += element.Value.getAge(); 
                    num++;//count++;
                }                    
            }            
            avgAge = total_age / num; //calculate average age
            
            return avgAge; //return average age
        }

        //button for report 5
        private void bt_avgAge_Click(object sender, EventArgs e)
        {
            int avgAge;
            avgAge = averageAge(); //call method to get average age 
            tb_avgAge.Text = avgAge.ToString(); //display the value
        }

        //report6
        private void averageProfitGoatCowVsSheep() //this method won't include Jersy cow
        {
            //initialize the variables
            double total_profit_goat_cow = 0.0;
            double total_profit_sheep = 0.0;
            double avg_profit_goat_cow;
            double avg_profit_sheep;
            int count_Goat_Cow = 0;
            int count_sheep = 0;
            string fmt1 = "                   ";
            string fmt2 = "                       ";

            //iterate througth the hash table
            for (int count = 0; count < myFarm.Count; count++)
            {
                //create variable to get element from the dictionary
                var element = this.myFarm.ElementAt(count);
                if (element.Value.getType() == "Goat" || element.Value.getType() == "Cow")
                {
                    //call calculateProfit() when type is goat or cow
                    total_profit_goat_cow += element.Value.calculateProfit();
                    count_Goat_Cow++; //count the number of goat and cow
                }
                if(element.Value.getType()=="Sheep")
                {
                    //call calculateProfit() when type is sheep
                    total_profit_sheep += element.Value.calculateProfit();
                    count_sheep++; //count the number of sheep
                }               
            }
            //calculate both average profit of "goat and cow" and sheep
            avg_profit_goat_cow = Math.Round(total_profit_goat_cow / count_Goat_Cow,2);
            avg_profit_sheep = Math.Round(total_profit_sheep / count_sheep,2);

            if(avg_profit_goat_cow > avg_profit_sheep) //check which average profit is bigger
            {
                //display both average profit of "goat and cow" and sheep 
                tb_avgProfitGCS.Text = "Avg Profit of Goat and Cow: "+avg_profit_goat_cow.ToString()+fmt1+
                                       "Avg Profit of Sheep: "+avg_profit_sheep.ToString()+fmt2+
                                       " Goat and Cow are more profitable";
            }
            else if (avg_profit_goat_cow < avg_profit_sheep)//check which average profit is bigger
            {
                //display both average profit of "shee" and "goat and cow"
                tb_avgProfitGCS.Text= "Avg Profit of sheep: " + avg_profit_sheep.ToString() + fmt1+
                                      "Avg Profit of Goat and Cow: "+avg_profit_goat_cow.ToString()+fmt2+
                                      "Sheep is more profitable";
            }
            else //if both has the same profit
            {
                //display both average profit
                tb_avgProfitGCS.Text = "Avg Profit of Goat and Cow: " + avg_profit_goat_cow.ToString() +fmt1+
                                       "Avg Profit of Sheep: " + avg_profit_sheep.ToString() + fmt2+
                                       "None of them are profitable. Both are same..";
            }
        }
        //button for report 6
        private void bt_avgProfitGCS_Click(object sender, EventArgs e)
        {
            averageProfitGoatCowVsSheep(); //call the method
        }

        //report7
        private double ratioOfDogCost()
        {
            //initialize variables
            double total_cost = 0.0;
            double total_dog_cost = 0.0;
            double ratio = 0.0;

            for (int count = 0; count < myFarm.Count; count++) //iterate througth the hash table
            {
                //create variable to get element from the dictionary
                var element = this.myFarm.ElementAt(count);
                                
                if(element.Value.getType() == "Dog") //check the type of animal is dog
                {
                    total_dog_cost += element.Value.calculateProfit(); //calculate the profit of dog
                }
                total_cost += element.Value.calculateProfit();//calculate the profit of total 
            }
            ratio = (double)total_dog_cost / (double)total_cost; //calculate the ratio

            return Math.Round(ratio,2); //return the value (round up to decimal 2)
        }
        //button for report 7
        private void bt_calculateRatioD_Click(object sender, EventArgs e)
        {
            double total_ratioDog;
            total_ratioDog = ratioOfDogCost(); //call the method to get ration of dog value
            tb_ratioD.Text = total_ratioDog.ToString(); //display the value
        }

        //report8
        private Boolean saveToFile(string path) 
        {
            //initialize variables and create an array to store the each animal's id
            string text = "";
            int temp=0;
            int[] array = new int[myFarm.Count];

            for (int count=0;count<this.myFarm.Count;count++) //iterate througth the hash table
            {
                var element = myFarm.ElementAt(count); //create variable to get element from the dictionary

                if (element.Value.getType() == "Dog") //check the type of animal is dog
                {
                    continue; //ignore and continue
                }
                array[count] = element.Key;
            }

            //bubble sort : it will compare the first index with second index
            //and second index with thrid index and continue until (n-1) index with n index
            for (int i = 0; i < array.Length - 1; i++)
            { //iterate 0 to array size -1
                for (int j = 0; j < array.Length-i-1; j++)
                { //iterate 0 to array size -i -1
                    double p1 = myFarm[array[j]].calculateProfit(); //set p1 to get the profit of array[i]
                    double p2 = myFarm[array[j + 1]].calculateProfit(); //set p2 to get the profit of array[j]

                    //if j index(p1) is less then j+1 index (p2) swap the value using temp
                    if (p1 < p2)//descending order
                    {
                        temp = array[j]; //temp get array[j]
                        array[j] = array[j + 1]; //arra[j] get array[j+1]
                        array[j + 1] = temp; //array[j+1] get temp 
                    }
                }
            }
            int[] arrayKey = array.Distinct().ToArray(); //create arrayKey to get array without duplicate data
            for (int i = 0; i < arrayKey.Length; i++)
            {
                //insert into text with arrayKey data and profit of arrayKey[i]
                text += arrayKey[i].ToString() + ": " + Math.Round(myFarm[arrayKey[i]].calculateProfit(),2).ToString() + "\r\n";
            }
            tb_displayID.Text = text; //display the text into textbox
  
            File.WriteAllText(path, text); //write a text file with above text
            if (text != null) //check if text is not null
                return true; //return true
            else
                return false; //if not, return false
        }
        //button for report 8
        private void bt_saveFile_Click(object sender, EventArgs e)
        {
            //set path of the file
            string path = @"C:\Users\ann27\OneDrive - Wintec\Application_Overall_App_task\Application_Overall_App_task\FarmID.txt";
            saveToFile(path); //call the method to save and write a text file
            if (saveToFile(path) == true) //if the method return true
            {
                MessageBox.Show("Succeed \n File saved in: "+ path); //display succeed message
            }
            else
                MessageBox.Show("Failed"); //display failed message
        }

        //report9
        private double ratioOfRed()
        {
            //initalize variables
            int count_red = 0;
            int total_count = 0;
            double ratio;

            for (int count = 0; count < myFarm.Count; count++) //iterate througth the hash table
            {
                //create variable to get element from the dictionary
                var element = this.myFarm.ElementAt(count);

                if (element.Value.displayInfo().Contains("Red")) //check whether information has "Red"
                {
                    count_red++; //count up
                }
                total_count++; //count up for total number of animal in the dictionary
            }
            ratio = (double)count_red / (double)total_count; //calculate the ratio

            return Math.Round(ratio,2); //return the value
        }
        //button for report 9
        private void bt_calculateRatioRed_Click(object sender, EventArgs e)
        {
            double total_ratioRed;
            total_ratioRed = ratioOfRed(); // call the method to get ratio of red value
            tb_ratioRed.Text = total_ratioRed.ToString(); //display the value
        }

        //report10
        private double taxJersy()
        {
            double total = 0.0;

            for (int count = 0; count < myFarm.Count; count++) //iterate througth the hash table
            {
                //create variable to get element from the dictionary
                var element = this.myFarm.ElementAt(count);

                //cehck the type of animal
                if (element.Value.getType() != "Jersy Cow") //if not Jersy cow 
                {
                    continue; //ignore and continue
                }
                else
                {
                    total += element.Value.calculateTax(); //calculate the Jersy cow tax
                }
            }            
            return Math.Round(total, 2); //return value
        }
        //button for report 10
        private void bt_calculateTotalTaxJ_Click(object sender, EventArgs e)
        {
            double tax_jersy;
            tax_jersy = taxJersy(); //call the method to get tax of Jersy cow
            tb_tTax_j.Text = tax_jersy.ToString(); //display the value
        }

        //report11
        private double displayAboveThreshold(int max)
        {
            int num = 0;
            int total_num = 0;
            double ratio;

            for (int count = 0; count < myFarm.Count; count++) //iterate througth the hash table
            {
                //create variable to get element from the dictionary
                var element = this.myFarm.ElementAt(count);

                if (element.Value.getAge() > max ) //if the age is bigger than max
                {
                    num++; //count up
                }
                total_num++; //count up for total number of animal in the dictionary
            }
            ratio = (double)num / (double)total_num; //calculate the ratio

            return Math.Round(ratio,2); //return the value
        }
        //button for report 11
        private void bt_calculateThreshold_Click(object sender, EventArgs e)
        {
            double threshold;
            try 
            {
                int max = Convert.ToInt32(tb_threshold.Text); //get userinput value into int type
                threshold = displayAboveThreshold(max); //call the method to get the ratio
                tb_resultThreshold.Text = threshold.ToString(); //display the value
            }
            catch (Exception error) //catch any exception occurs while running this code
            {
                MessageBox.Show(error.Message); //display message
            }
        }

        //report12
        private double displayProfitJersy()
        {
            double total = 0.0;
            
            for (int count = 0; count < myFarm.Count; count++) //iterate througth the hash table
            {
                //create variable to get element from the dictionary
                var element = this.myFarm.ElementAt(count);

                if (element.Value.getType().Equals("Jersy Cow")) //if the type of animal is equals to Jersy cow
                {
                    total +=element.Value.calculateProfit(); //calculate the profit
                }                
            }       
            return Math.Round(total,2); //return the value
        }
        //button for report 12
        private void bt_calculateProfitJ_Click(object sender, EventArgs e)
        {
            double total_profit_jersy;
            total_profit_jersy = displayProfitJersy(); //call the method to get total profit of Jersy cow
            tb_tProfit_j.Text = total_profit_jersy.ToString(); //display the value
        }
    }
}