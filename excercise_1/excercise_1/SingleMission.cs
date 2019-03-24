using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excercise_1
{
    public class SingleMission : IMission
    {
        private const string MISSION_SINGLE_NAME = "Single";
        public funcDelegate single_mission;

        public SingleMission(funcDelegate func, string name)
        {
            this.single_mission = func;
            this.Name = name;
        }

        public event EventHandler<double> OnCalculate;

        public String Name { get; }

        public String Type
        {
            get { return MISSION_SINGLE_NAME; }
        }

        /*
         * returns the function single result
         */
        public double Calculate(double value)
        {
            if (single_mission != null)
            {
                double result = single_mission(value);
                OnCalculate?.Invoke(this, result);
                return result;
            }
            throw new Exception("there is no single mission");
        }
    }
}