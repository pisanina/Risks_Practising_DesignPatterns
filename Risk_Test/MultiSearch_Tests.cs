using NUnit.Framework;
using RiskModel;
using RiskModel.Command;
using RiskModel.Decorator;
using System.Collections.Generic;
using System.Linq;

namespace Risk_Test
{
    class MultiSearch_Tests
    {
        private MultiSearch mSearch = new MultiSearch();

        [SetUp]
        public void CreateRepositoryForTests()
        {
            mSearch = new MultiSearch();
        }

        [Test]
        public void CheckMultiSearch_WitoutOwnerName()
        {
            string ownerName = null;
            RiskStatus status = RiskStatus.Open;
            string title = "Fire";

            var result = mSearch.GetListOfRisksByOwnerStatusTitle(ownerName, status, title);
            Assert.True(result.Count == 2);
            Assert.True(result[0].Status != RiskStatus.Open);
            Assert.True(result[1].Status != RiskStatus.Open);
        }


   
        [Test]
        public void CheckMultiSearch_AllArguments()
        {
            string ownerName = "Person 1"; ;
            RiskStatus status = RiskStatus.Open;
            string title = null;

            var result = mSearch.GetListOfRisksByOwnerStatusTitle(ownerName, status, title);
            Assert.True(result.Count == 2);
            Assert.True(result[0].Owner.Name == ownerName);
        }


        [Test]
        public void CheckMultiSearch_WithoutArguments()
        {
            var result = mSearch.GetListOfRisksByOwnerStatusTitle();
            Assert.True(result.Count == 10);
            
        }

        [Test]
        public void CheckMultiSearch_WitoutStatus()
        {
            string ownerName = "Person 5";
            string title = "fire";

            var result = mSearch.GetListOfRisksByOwnerStatusTitle(ownerName, null, title);

            Assert.True(result.Count == 3);
            Assert.True(result[0].Owner.Name == ownerName);
            Assert.True(result[1].Owner.Name == ownerName);
            Assert.True(result[2].Owner.Name == ownerName);
            Assert.True(result[0].Title.Contains(title, System.StringComparison.InvariantCultureIgnoreCase));
            Assert.True(result[1].Title.Contains(title, System.StringComparison.InvariantCultureIgnoreCase));
            Assert.True(result[2].Title.Contains(title, System.StringComparison.InvariantCultureIgnoreCase));
        }


        [Test]
        public void CheckMultiSearch_WithoutTitle()
        {
            string ownerName = "Person 5";
            RiskStatus notStatus = RiskStatus.Open;

            var result = mSearch.GetListOfRisksByOwnerStatusTitle(ownerName, notStatus);

            Assert.True(result.Count == 1);
            Assert.True(result[0].Owner.Name == ownerName);
            Assert.True(result[0].Status != RiskStatus.Open);
        }

        [Test]
        public void CheckMultiSearch_TitleKeySensitive()
        {
            string title = "Fire";

            var result = mSearch.GetListOfRisksByOwnerStatusTitle(null, null, title);

            Assert.True(result.Count == 4);
            Assert.True(result[0].Title.ToLower().Contains(title.ToLower()));
            Assert.True(result[1].Title.ToLower().Contains(title.ToLower()));
            Assert.True(result[2].Title.ToLower().Contains(title.ToLower()));
            Assert.True(result[3].Title.ToLower().Contains(title.ToLower()));
        }

        [Test]
        public void CheckMultiSearch_TitleMisspelled()
        {
            string title = "Fire,";

            var result = mSearch.GetListOfRisksByOwnerStatusTitle(null, null, title);

            Assert.True(result.Count == 0);
        }


        [Test]
        public void CheckMultiSearch_WrongUserName()
        {
            string ownerName = "James Bond";

            var result = mSearch.GetListOfRisksByOwnerStatusTitle(ownerName);

            Assert.True(result.Count == 0);
        }


        [Test]
        public void CheckMultiSearch_UserName_KeySensitive()
        {
            string ownerName = "Person 5";


            var result = mSearch.GetListOfRisksByOwnerStatusTitle(ownerName);


            Assert.True(result.Count == 3);
            Assert.True(result[0].Owner.Name.ToLower() == ownerName.ToLower());
            Assert.True(result[1].Owner.Name.ToLower() == ownerName.ToLower());
            Assert.True(result[2].Owner.Name.ToLower() == ownerName.ToLower()); 
        }

       
    }
}
