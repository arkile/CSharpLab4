using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CSharp_Lab4.Model;
using CSharp_Lab4.Tools.Manager;

namespace CSharp_Lab4.Tools.DataStorage
{
    internal class SerializedDataStorage : IDataStorage
    {
        private readonly List<Person> _persons;

        internal SerializedDataStorage()
        {
            try
            {
                _persons = SerializationManager.Deserialize<List<Person>>(FileFolderHelper.StorageFilePath);

            }
            catch (FileNotFoundException)
            {
                _persons = new List<Person>();
                AddPersonsToInitialize();
            }
        }

        public void AddPerson(Person person)
        {
            _persons.Add(person);
            SaveChanges();
        }

        public void DeletePerson(Person person)
        {
            _persons.Remove(person);
            SaveChanges();
        }

        public List<Person> PersonsList => _persons.ToList();


        public void SaveChanges()
        {
            SerializationManager.Serialize(_persons, FileFolderHelper.StorageFilePath);
        }



        private void AddPersonsToInitialize()
        {
            AddPerson(new Person("Kostya", "Pavlov", "kostik@gmail.com", new DateTime(2003, 10, 17)));
            AddPerson(new Person("Vovan", "Lenin", "welcome@mavsolei.com", new DateTime(1999, 4, 10)));
            AddPerson(new Person("Winston", "Churchill", "no@comments.uk", new DateTime(1977, 11, 15)));
            AddPerson(new Person("Kim", "Jong", "lollypop@bomb.dushka", new DateTime(1966, 3, 20)));
            AddPerson(new Person("Victor", "Frankenstein", "elctro@monster.rise", new DateTime(1955, 8, 30)));
            AddPerson(new Person("Galileo", "Galiley", "suniscenter@zemlya.com", new DateTime(2003, 10, 17)));
            AddPerson(new Person("Ernest", "Rutherford", "radio@active.ruth", new DateTime(1960, 1, 30)));
            AddPerson(new Person("James", "Watt", "rozetka@elctro.zzzz", new DateTime(1978, 10, 7)));
            AddPerson(new Person("Nikola", "Tesla", "edisson@sucks.kek", new DateTime(1924, 4, 23)));
            AddPerson(new Person("Thomas", "Edison", "tesla@sucks.lol", new DateTime(1967, 5, 31)));
            AddPerson(new Person("Elon", "Mask", "howdoyou@like_it.musk", new DateTime(1983, 6, 5)));
            AddPerson(new Person("Steve", "Jobs", "whoruletheworld@pple.yabloko", new DateTime(1991, 8, 18)));
            AddPerson(new Person("Charles", "Darwin", "monkey@human.evo", new DateTime(1992, 12, 1)));
            AddPerson(new Person("Niels", "Bor", "quantum@physics.com", new DateTime(1931, 7, 4)));
            AddPerson(new Person("Marie", "SkadovskaCurie", "toxic@uran.rad", new DateTime(1945, 8, 7)));
            AddPerson(new Person("Amadeo", "Avogadro", "602@1023.mol", new DateTime(1997, 10, 29)));
            AddPerson(new Person("Alexander", "Bell", "dzindzin@text.me", new DateTime(1984, 2, 28)));
            AddPerson(new Person("Rene", "Descarts", "abscissa@oridanta.xy", new DateTime(1978, 3, 4)));
            AddPerson(new Person("Eratosphen", "Eratosphenovich", "zemlyabig@resheto.greece", new DateTime(2015, 8, 11)));
            AddPerson(new Person("Michael", "Faraday", "magnetic@elektric.anod", new DateTime(2018, 7, 12)));
            AddPerson(new Person("Fibonacci", "Fibonaccicus", "asdsad@58.13", new DateTime(2004, 11, 18)));
            AddPerson(new Person("Galileo", "Galiley", "asdsad@zemlya.com", new DateTime(2003, 10, 17)));
            AddPerson(new Person("Nicolaus", "Copernicus", "asdasdasd@astronomia.com", new DateTime(1976, 5, 12)));
            AddPerson(new Person("Isaac", "Newton", "appleIsaac@vovan.com", new DateTime(2005, 1, 13)));
            AddPerson(new Person("Albert", "Einstein", "fdgfd@squared.com", new DateTime(1940, 7, 9)));
            AddPerson(new Person("Victor", "Frankenstein", "elctro@monster.rise", new DateTime(1955, 8, 30)));
            AddPerson(new Person("Benito", "Musollini", "hitler@one.love", new DateTime(1944, 9, 1)));
            AddPerson(new Person("Julius", "Cesar", "fdhfd@brutus.gr", new DateTime(1933, 11, 5)));
            AddPerson(new Person("Volodymyr", "Boublik", "dfgfdg@sdfsdgg.vvidu", new DateTime(1956, 10, 9)));
            AddPerson(new Person("John", "Kennedy", "snipers@sucks.com", new DateTime(1978, 5, 8)));
            AddPerson(new Person("Neil", "Armstrong", "dude@its.moon", new DateTime(1990, 6, 1)));
            AddPerson(new Person("Steve", "Jobs", "dfghfdg@pple.yabloko", new DateTime(1991, 8, 18)));
            AddPerson(new Person("Gottfried", "von", "integral@different.omg", new DateTime(2009, 9, 11)));
            AddPerson(new Person("Blaise", "Pascal", "programme@begin.end", new DateTime(1952, 5, 14)));
            AddPerson(new Person("Archimedes", "Archim", "eurekaaaa@lamp.bath", new DateTime(1996, 3, 13)));
            AddPerson(new Person("Wilhelm", "Conrad", "fdgdsf@bone.hihihi", new DateTime(1945, 12, 8)));
            AddPerson(new Person("Leonardo", "DaVinci", "genius@jaconda.me", new DateTime(1967, 2, 24)));
            AddPerson(new Person("Charles", "Coulomb", "sdgf@merica.new", new DateTime(1994, 5, 21)));
            AddPerson(new Person("David", "Gamayun", "gamaundavid23@gmail.com", new DateTime(2000, 6, 23)));
            AddPerson(new Person("Victor", "Frankenstein", "elctro@monster.rise", new DateTime(1955, 8, 30)));
            AddPerson(new Person("Galileo", "Galiley", "fdsf@zemlya.com", new DateTime(2003, 10, 17)));
            AddPerson(new Person("Ernest", "Rutherford", "radio@active.ruth", new DateTime(1960, 1, 30)));
            AddPerson(new Person("James", "Watt", "rozetka@elctro.zzzz", new DateTime(1978, 10, 7)));
            AddPerson(new Person("Nikola", "Tesla", "edisson@sucks.kek", new DateTime(1924, 4, 23)));
            AddPerson(new Person("Thomas", "Edison", "tesla@sucks.lol", new DateTime(1967, 5, 31)));
            AddPerson(new Person("Charles", "Darwin", "monkey@human.evo", new DateTime(1992, 12, 1)));
            AddPerson(new Person("Niels", "Bor", "quantum@physics.com", new DateTime(1931, 7, 4)));
            AddPerson(new Person("Marie", "Skadovska", "toxic@uran.rad", new DateTime(1945, 8, 7)));
            AddPerson(new Person("Marie", "Skadovska", "toxic@uran.rad", new DateTime(1945, 8, 7)));
            AddPerson(new Person("Amadeo", "Avogadro", "sdfsdf@dfgfdhdf.mol", new DateTime(1997, 10, 29)));
            AddPerson(new Person("Alexander", "Bell", "dzin_dzin@text.me", new DateTime(1984, 2, 28)));
        }
    }
}