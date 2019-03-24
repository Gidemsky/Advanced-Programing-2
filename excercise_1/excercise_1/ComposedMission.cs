using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excercise_1
{
    public class ComposedMission : IMission
    {
        private const string MISSION_NAME = "Composed";
        private ICollection<funcDelegate> funcs_list;

        //Constructor
        public ComposedMission(string name)
        {
            this.funcs_list = new List<funcDelegate>();
            this.Name = name;
        }

        public event EventHandler<double> OnCalculate;
        public String Name { get; }
        public String Type
        {
            get { return MISSION_NAME; }
        }
        /*
         * adds the fuctions all together
         */
        public ComposedMission Add(funcDelegate func)
        {
            this.funcs_list.Add(func);
            return this;
        }
        /*
         * calculates the value of the function
         */
        public double Calculate(double value)
        {
            if (this.funcs_list.Count() == 0)
            {
                throw new Exception("There is no function to calculate!");
            }
            foreach (var function in this.funcs_list)
            {
                if (function != null)
                {
                    value = function(value);
                }
            }
            OnCalculate?.Invoke(this, value);
            return value;
        }
    }
}
