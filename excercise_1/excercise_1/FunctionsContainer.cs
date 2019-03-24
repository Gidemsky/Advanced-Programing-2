using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excercise_1
{
    public delegate double funcDelegate(double val);
    //public delegate double culcFunc(double val);
    public class FunctionsContainer
    {
        private Dictionary<string, funcDelegate> dic_func;
        public FunctionsContainer()
        {
            this.dic_func = new Dictionary<string, funcDelegate>();
        }
        //private Dictionary<string, funcDelegate> dic_func = new Dictionary<string, funcDelegate>();
        /*
         * creates the indexer whitch gets a string that represents a function
         */
        public funcDelegate this[string functionName]
        {
            get
            {
                if (!dic_func.ContainsKey(functionName))
                {
                    dic_func[functionName] = val => val;
                }
                return dic_func[functionName];
            }

            set
            {
                //funcDelegate func += new funcDelegate(value);
                dic_func[functionName] = value;
            }
        }

        public List<string> getAllMissions()//TODO: check changeing to collection
        {
            return new List<string>(this.dic_func.Keys);//return this.funcsMap.Keys;
        }

    }
}
