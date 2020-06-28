using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Overall_App_task
{
    class Dog : LiveStock
    {
        public Dog(int id, double amtWater, double dailyCost, double weight, int age, string color, string type) : base(id, amtWater, dailyCost, weight, age, color, type)
        { } //create construtor

        public override string displayInfo() //override the LiveStock displayInfo()
        {
            string ID = id.ToString();
            string AmtWater = amtWater.ToString();
            string DailyCost = dailyCost.ToString();
            string Weight = weight.ToString();
            string Age = age.ToString();
            string color = this.color;
            string fmt = String.Format("{0,-3} {1,23} {2,20} {3,22} {4,25} {5,19}\r\n",
                                        "ID", "Amount of water", "Daily cost","Weight", "Age", "Color");
            string datafmt = String.Format("{0,-3} {1,20} {2,21} {3,33} {4,25} {5,22}\r\n",
                                        ID,AmtWater,DailyCost,Weight,Age,color);
            return fmt+datafmt;
        }
        
        public override string getType() //override the LiveStock getType()
        {
            return type; //return type
        }

        public override double calculateProfit() //override the LiveStock claculateProfit()
        {
            double profit = 0;
            profit = 0-(((amtWater * Prices.water)/1000)+dailyCost); //calculate the profit
            return profit; //return the profit value
        }
    }
}