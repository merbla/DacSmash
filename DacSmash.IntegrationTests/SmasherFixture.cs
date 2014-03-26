using System.Collections.Generic;
using NUnit.Framework;

namespace DacSmash.IntegrationTests
{
    [TestFixture]
    public class SmasherFixture
    {
        [Test]
        public void SmashDeploysDb()
        {
            const string connectionString = @"Data Source=.\sql2k12;Integrated Security=True;Pooling=False";
            const string dacPacFile = @"C:\Source\Reference Projects\DacSmash\DacSmash.Database\bin\Debug\DacSmash.Database.dacpac";
            const string targetDatabase = "DacSmashTest";
            
            
            var sut = new Smasher(connectionString,dacPacFile,targetDatabase,new Dictionary<string, string>());

            sut.Smash();



        }
    }
}