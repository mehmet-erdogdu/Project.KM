using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
namespace Project.Test
{

    [TestClass]
    public class PersonalTest
    {

        Domain.PersonalDataService Service = new Domain.PersonalDataService();

        [TestMethod]
        public void InsertScalar()
        {
            Domain.Personal p = new Domain.Personal();
            p.Name = "d";
            p.Lastname = "2";
            int result = Service.InsertCommandScalar(p);
            Debug.WriteLine(result);
        }

        [TestMethod]
        public void FastInsert() // Data id geri döner
        {
            Domain.Personal p = new Domain.Personal();
            p.Name = "Hesap";
            p.Lastname = "1";
            int result = Service.FastInsert(p);
            Debug.WriteLine(result);
        }

        [TestMethod]
        public void GetDataList()
        {
            var result = Service.PersonalGetDataList();
            foreach (var item in result)
            {
                Debug.WriteLine(item.Name);
            }
        }

        [TestMethod]
        public void GetData()
        {
            var result = Service.PersonalGetData();
            Debug.WriteLine(result.Name);
        }

        [TestMethod]
        public void Insert()
        {
            Domain.Personal p = new Domain.Personal();
            p.Name = "Mehmet";
            p.Lastname = "Erdoğdu";
            int result = Service.InsertCommand(p);
            Debug.WriteLine(result);
        }
    }
}
