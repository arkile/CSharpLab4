using System.Collections.Generic;
using CSharp_Lab4.Model;

namespace CSharp_Lab4.Tools.DataStorage
{
    internal interface IDataStorage
    {
        void AddPerson(Person person);

        void DeletePerson(Person person);

        List<Person> PersonsList { get; }



    }
}