using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Overall_App_task
{
    class Jersey_Cow : Cow //inherite from Cow class
    {
        public Jersey_Cow(int id, double amtWater, double dailyCost, double weight, int age, string color, double amtMilk, bool isJersy, string type) : base(id, amtWater, dailyCost, weight, age, color, amtMilk, isJersy, type)
        {  } //create construtor

        public override string displayInfo() //override the LiveStock displayInfo()
        {
            //get each value into string type
            string ID = id.ToString();
            string AmtWater = amtWater.ToString();
            string DailyCost = dailyCost.ToString();
            string Weight = weight.ToString();
            string Age = age.ToString();
            string AmtMilk = amtMilk.ToString();
            string IsJersy = isJersy.ToString();
            string color = this.color;
            string fmt = String.Format("{0,-3} {1,23} {2,20} {3,22} {4,15} {5,29} {6,21},{7,17}\r\n",
                            "ID", "Amount of water", "Daily cost", "Weight", "Age", "Amount of milk", "Is Jersy", "Color");
            string datafmt = String.Format("{0,-2} {1,20} {2,19} {3,33} {4,15} {5,28} {6,27} {7,18}\r\n",
                                        ID, AmtWater, DailyCost, Weight, Age, AmtMilk, IsJersy, color);
            return fmt + datafmt; //return the information
        }
       
        public override string getType() //override the LiveStock getType()
        {
            return type; //return type
        }

        public override double calculateProfit() //override the LiveStock claculateProfit()
        {
            double profit;
            profit = ((amtMilk * Prices.cow_milk) - (dailyCost + ((amtWater * Prices.water)/1000)) + (weight*Prices.jersy_tax)); //calculate the profit 

            return profit; //return the profit value
        }

        public override double calculateTax() //override the LiveStock calculateTax()
        {
            double tax = 0;
            tax = weight*Prices.jersy_tax*30; //calculate tax for month
            return tax; //return the tax value
        }

        public override int getAge() //override the LiveStock getAge()
        {
            return age;//return the age value
        }
    }
}
