﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Overall_App_task
{
    class Goat : LiveStock
    {
        protected double amtMilk;
        public Goat(int id, double amtWater, double dailyCost, double weight, int age, string color, double amtMilk, string type) : base(id, amtWater, dailyCost, weight, age, color, type) 
        {
            this.amtMilk = amtMilk;
            
        } //create constructor
       
        public override string displayInfo() //override the LiveStock displayInfo()
        {
            //get each value into string type
            string ID = id.ToString();
            string AmtWater = amtWater.ToString();
            string DailyCost = dailyCost.ToString();
            string Weight = weight.ToString();
            string Age = age.ToString();
            string AmtMilk = amtMilk.ToString();
            string color = this.color;

            string fmt = String.Format("{0,-3} {1,23} {2,20} {3,22} {4,15} {5,29} {6,21}\r\n",
                            "ID", "Amount of water", "Daily cost", "Weight", "Age", "Amount of milk", "Color");
            string datafmt = String.Format("{0,-2} {1,20} {2,19} {3,33} {4,15} {5,28} {6,27} \r\n",
                                        ID, AmtWater, DailyCost, Weight, Age, color, AmtMilk);
            return fmt+datafmt; //return the information
        }
        
        public override string getType() //override the LiveStock getType()
        {
            return type; //return type
        }

        public override double getMilk() //override the LiveStock getMilk()
        {
            return (amtMilk); //return the amount of milk value
        }

        public override double calculateProfit() //override the LiveStock claculateProfit()
        {
            double profit = 0;

            profit = (amtMilk * Prices.goat_milk)-(dailyCost+((amtWater*Prices.water)/1000)+(weight*Prices.tax));  //calculate the profit 

            return profit; //return the profit value
        }

        public override double calculateTax() //override the LiveStock calculateTax()
        {
            double tax = 0;
            tax = weight* Prices.tax*30; //calculate tax for month
            return tax; //return the tax value
        }

        public override int getAge() //override the LiveStock getAge()
        {
            return age; //return the age value
        }
    }
}