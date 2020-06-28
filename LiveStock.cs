using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Application_Overall_App_task
{
    abstract public class LiveStock //create abstract class for Animal 
    {
        //make the variable as protected type 
        protected int id;
        protected double amtWater;
        protected double dailyCost;
        protected double weight;
        protected int age;
        protected string color;
        protected string type;

        public LiveStock(int id, double amtWater, double dailyCost, double weight, int age, string color, string type) //create construtor to get the data from the file
        {
            this.id = id;
            this.amtWater = amtWater;
            this.dailyCost = dailyCost;
            this.weight = weight;
            this.age = age;
            this.color = color;
            this.type = type;
        }       

        //create an abstract method so that other inherited class can overrid this function
        public abstract string getType(); 
        public abstract string displayInfo();
        public abstract double calculateProfit();

        //create virtual method so that other inhertied class doesn't have to override this method. Only the class which needs this method can override it
        public virtual double calculateTax()  
        { //exclude dog class
            return 0;
        }
        public virtual int getAge()
        { //exclude dog class
            return age;
        }
        public virtual double getMilk ()
        { //only goat and cow class
            return 0;
        }
    }
}
