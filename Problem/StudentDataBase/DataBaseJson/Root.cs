using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem.StudentDataBase.DataBaseJson
{
    internal class Root<T> where T : IDataModel
    {
        public T Data { get; set; }

        public Root(T model)
        {
            Data = model;
        }
    }
}
