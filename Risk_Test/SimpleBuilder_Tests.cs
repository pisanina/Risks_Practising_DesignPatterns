using NUnit.Framework;
using RiskModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Risk_Test
{
    [TestFixture]
    class SimpleBuilder_Tests
    {
        private List<Risk> listOfRisks = new List<Risk>();
        private RiskService service = new RiskService();

        [SetUp]
        public void CreateRepositoryForTests()
        {
            listOfRisks = service.GetRisks();
        }


        [Test]
        public void CheckCommand_RiskStatus()
        {
            RiskStatus notStatus = RiskStatus.Open;

            var builder = new Search_SimpleBuilder(listOfRisks);


            builder.GetListOfRisksWithDifferentStatus(notStatus);
            var result =  builder.Builded_Search();

            Assert.True(result.Count == 7);
            foreach (var i in result)
                Assert.True(i.Status != RiskStatus.Open);
        }


        [Test]
        public void CheckSimpleBuilder_WitoutStatus()
        {
            string ownerName = "Person 5";
            string title = "fire";

            var builder = new Search_SimpleBuilder(listOfRisks);
            builder.GetListOfRisksWithOwnerName(ownerName);
            builder.GetListOfRisksWithTitleContains(title);
            var result =  builder.Builded_Search();

            Assert.True(result.Count == 3);
            Assert.True(result[0].Owner.Name == ownerName);
            Assert.True(result[1].Owner.Name == ownerName);
            Assert.True(result[2].Owner.Name == ownerName);
            Assert.True(result[0].Title.Contains(title, System.StringComparison.InvariantCultureIgnoreCase));
            Assert.True(result[1].Title.Contains(title, System.StringComparison.InvariantCultureIgnoreCase));
            Assert.True(result[2].Title.Contains(title, System.StringComparison.InvariantCultureIgnoreCase));
        }


        [Test]
        public void CheckSimpleBuilder_WithoutTitle()
        {
            string ownerName = "Person 5";
            RiskStatus status = RiskStatus.Open;

            var builder = new Search_SimpleBuilder(listOfRisks);
            builder.GetListOfRisksWithOwnerName(ownerName);
            builder.GetListOfRisksWithDifferentStatus(status);
            var result =  builder.Builded_Search();

            Assert.True(result.Count == 1);
            Assert.True(result[0].Owner.Name == ownerName);
            Assert.True(result[0].Status != RiskStatus.Open);
        }


        [Test]
        public void CheckSimpleBuilder_WithoutOwnerName()
        {
            RiskStatus notStatus = RiskStatus.Open;
            string title = "fire";

            var builder = new Search_SimpleBuilder(listOfRisks);
            builder.GetListOfRisksWithTitleContains(title);
            builder.GetListOfRisksWithDifferentStatus(notStatus);
            var result =  builder.Builded_Search();

            Assert.True(result.Count == 2);
            Assert.True(result[0].Title.Contains(title));
            Assert.True(result[0].Status != RiskStatus.Open);
        }

        [Test]
        public void CheckSimpleBuilder_AllMethods()
        {
            RiskStatus notStatus = RiskStatus.Open;
            string title = "fire";
            string ownerName = "Person 5";

            var builder = new Search_SimpleBuilder(listOfRisks);
            builder.GetListOfRisksWithOwnerName(ownerName);
            builder.GetListOfRisksWithTitleContains(title);
            builder.GetListOfRisksWithDifferentStatus(notStatus);
            var result =  builder.Builded_Search();

            Assert.True(result.Count == 1);
            Assert.True(result[0].Owner.Name == ownerName);
            Assert.True(result[0].Title.Contains(title));
            Assert.True(result[0].Status != RiskStatus.Open);
        }

        [Test]
        public void CheckSimpleBuilder_TitleKeySensitive()
        {
            RiskStatus notStatus = RiskStatus.Open;
            string title = "Fire";

            var builder = new Search_SimpleBuilder(listOfRisks);
            builder.GetListOfRisksWithTitleContains(title);
            builder.GetListOfRisksWithDifferentStatus(notStatus);
            var result =  builder.Builded_Search();

            Assert.True(result.Count == 2);
            Assert.True(result[0].Title.ToLower().Contains(title.ToLower()));
            Assert.True(result[0].Status != RiskStatus.Open);
        }

        [Test]
        public void CheckSimpleBuilder_TitleMisspelled()
        {
            RiskStatus notStatus = RiskStatus.Open;
            string title = "Fire,";

            var builder = new Search_SimpleBuilder(listOfRisks);
            builder.GetListOfRisksWithTitleContains(title);
            builder.GetListOfRisksWithDifferentStatus(notStatus);
            var result =  builder.Builded_Search();

            Assert.True(result.Count == 0);
        }

        [Test]
        public void CheckSimpleBuilder_UserNameMisspelled()
        {
            string ownerName = "Jon Mooree";
            RiskStatus status = RiskStatus.Open;

            var builder = new Search_SimpleBuilder(listOfRisks);
            builder.GetListOfRisksWithOwnerName(ownerName);
            builder.GetListOfRisksWithDifferentStatus(status);
            var result =  builder.Builded_Search();

            Assert.True(result.Count == 0);
        }


        [Test]
        public void CheckSimpleBuilder_UserName_KeySensitive()
        {
            string ownerName = "Person 5";

            var builder = new Search_SimpleBuilder(listOfRisks);
            builder.GetListOfRisksWithOwnerName(ownerName);


            var result =  builder.Builded_Search();

            Assert.True(result.Count == 3);
            Assert.True(result[0].Owner.Name.ToLower() == ownerName.ToLower());
            Assert.True(result[1].Owner.Name.ToLower() == ownerName.ToLower());
            Assert.True(result[2].Owner.Name.ToLower() == ownerName.ToLower());
        }

        [Test]
        public void CheckSimpleBuilder_Title_KeySensitive()
        {
            string title = "Fire";

            var builder = new Search_SimpleBuilder(listOfRisks);
            builder.GetListOfRisksWithTitleContains(title);


            var result =  builder.Builded_Search();

            Assert.True(result.Count == 4);
            Assert.True(result[0].Title.ToLower().Contains(title.ToLower()));
            Assert.True(result[1].Title.ToLower().Contains(title.ToLower()));
            Assert.True(result[2].Title.ToLower().Contains(title.ToLower()));
            Assert.True(result[3].Title.ToLower().Contains(title.ToLower()));
        }
    }
}
