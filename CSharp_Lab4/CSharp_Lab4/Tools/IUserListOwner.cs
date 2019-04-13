using System.Collections.ObjectModel;
using CSharp_Lab4.Model;

namespace CSharp_Lab4.Tools
{
interface IUserListOwner
{
ObservableCollection<Person> Users { set; get; }
}
}