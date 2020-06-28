using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Overall_App_task
{
    class Sheep : LiveStock
    {
        protected double amtWool;
        public Sheep(int id, double amtWater, double dailyCost, double weight, int age, string color, double amtWool, string type) : base(id, amtWater, dailyCost, weight, age, color, type) 
        {  
            this.amtWool = amtWool; 
        }//create construtor

        public override string displayInfo() //override the LiveStock displayInfo()
        {
            //get each value into string type
            string ID = id.ToString();
            string AmtWater = amtWater.ToString();
            string DailyCost = dailyCost.ToString();
            string Weight = weight.ToString();
            string Age = age.ToString();
            string color = this.color;
            string AmtWool = amtWool.ToString();
            string fmt = String.Format("{0,-3} {1,23} {2,20} {3,22} {4,25} {5,19} {6,33}\r\n",
                                        "ID", "Amount of water", "Daily cost", "Weight", "Age", "Color","Amount of Wool");
            string datafmt = String.Format("{0,-3} {1,20} {2,21} {3,33} {4,25} {5,22} {6,33}\r\n",
                                        ID, AmtWater, DailyCost, Weight, Age, color,AmtWool);
            return fmt+datafmt; //return the information
        }
       
        public override string getType() //override the LiveStock getType()
        {
            return type; //return type
        }

        public override double calculateProfit() //override the LiveStock claculateProfit()
        {
            double profit = 0;
            profit = (amtWool * Prices.sheep_wool)-(dailyCost+((amtWater*Prices.water)/1000)+(weight*Prices.tax)); //calculate the profit 
            return profit; //return the profit value
        }

        public override double calculateTax() //override the LiveStock calculateTax()
        {
            double tax = 0;
            tax = Prices.tax*weight*30; //calculate tax for month
            return tax; //return the tax value
        }
       
        public override int getAge() //override the LiveStock getAge()
        {
            return age; //return the age value
        }
    }
}