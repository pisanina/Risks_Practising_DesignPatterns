using NUnit.Framework;
using RiskModel;
using RiskModel.Command;
using System.Collections.Generic;
using System.Linq;

namespace Risk_Test
{
    [TestFixture]
    internal class Command_Tests
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

            ICommand byDiffrentStatus = new ByDiffrentStatusCommand(notStatus);

            var riskProvider = new RiskProvider(listOfRisks);
            riskProvider.ExecCommand(byDiffrentStatus);
            var result = riskProvider.GetResults().ToList();

            Assert.True(result.Count == 7);
            foreach (var i in result)
                Assert.True(i.Status != RiskStatus.Open);
        }

        [Test]
        public void CheckCommand_WrongUserName()
        {
            string ownerName = "James Bond";
            RiskStatus notStatus = RiskStatus.Open;

            ICommand byOwnerName = new ByOnwerNameCommand(ownerName);
            ICommand byDiffrentStatus = new ByDiffrentStatusCommand(notStatus);

            var riskProvider = new RiskProvider(listOfRisks);
            riskProvider.ExecCommand(byOwnerName);
            riskProvider.ExecCommand(byDiffrentStatus);

            var result = riskProvider.GetResults().ToList();

            Assert.True(result.Count == 0);
        }

        [Test]
        public void CheckCommand_UserNameMisspelled()
        {
            string ownerName = "Jon Mooree";
            RiskStatus notStatus = RiskStatus.Open;

            ICommand byOwnerName = new ByOnwerNameCommand(ownerName);
            ICommand byDiffrentStatus = new ByDiffrentStatusCommand(notStatus);

            var riskProvider = new RiskProvider(listOfRisks);
            riskProvider.ExecCommand(byOwnerName);
            riskProvider.ExecCommand(byDiffrentStatus);

            var result = riskProvider.GetResults().ToList();

            Assert.True(result.Count == 0);
        }

        [Test]
        public void CheckCommand_UserName_KeySensitive()
        {
            string ownerName = "Jon moore";

            ICommand byOwnerName = new ByOnwerNameCommand(ownerName);

            var riskProvider = new RiskProvider(listOfRisks);
            riskProvider.ExecCommand(byOwnerName);


            var result = riskProvider.GetResults().ToList();

            Assert.True(result.Count == 3);
            Assert.True(result[0].Owner.Name.ToLower() == ownerName.ToLower());
            Assert.True(result[1].Owner.Name.ToLower() == ownerName.ToLower());
            Assert.True(result[2].Owner.Name.ToLower() == ownerName.ToLower());
           
        }

        [Test]
        public void CheckCommand_Title_KeySensitive()
        {
            string title = "Fire";
            ICommand byTitle = new ByTitleCommand(title);

            var riskProvider = new RiskProvider(listOfRisks);

            riskProvider.ExecCommand(byTitle);
            var result = riskProvider.GetResults().ToList();

                Assert.True(result.Count == 4);
            foreach (var i in result)
            Assert.True(i.Title.ToLower().Contains(title.ToLower()));
        }

        [Test]
        public void CheckCommand_WitoutStatus()
        {
            string ownerName = "Jon Moore";
            string title = "fire";

            ICommand byOwnerName = new ByOnwerNameCommand(ownerName);

            ICommand byTitle = new ByTitleCommand(title);

            var riskProvider = new RiskProvider(listOfRisks);
            riskProvider.ExecCommand(byOwnerName);
            riskProvider.ExecCommand(byTitle);
            var result = riskProvider.GetResults().ToList();

            Assert.True(result.Count == 3);
            Assert.True(result[0].Owner.Name == ownerName);
            Assert.True(result[1].Owner.Name == ownerName);
            Assert.True(result[2].Owner.Name == ownerName);
            Assert.True(result[0].Title.Contains(title, System.StringComparison.InvariantCultureIgnoreCase));
            Assert.True(result[1].Title.Contains(title, System.StringComparison.InvariantCultureIgnoreCase));
            Assert.True(result[2].Title.Contains(title, System.StringComparison.InvariantCultureIgnoreCase));
        }

        [Test]
        public void CheckCommand_WithoutTitle()
        {
            string ownerName = "Jon Moore";
            RiskStatus notStatus = RiskStatus.Open;

            ICommand byOwnerName = new ByOnwerNameCommand(ownerName);
            ICommand byDiffrentStatus = new ByDiffrentStatusCommand(notStatus);

            var riskProvider = new RiskProvider(listOfRisks);
            riskProvider.ExecCommand(byOwnerName);
            riskProvider.ExecCommand(byDiffrentStatus);

            var result = riskProvider.GetResults().ToList(); ;

            Assert.True(result.Count == 1);
            Assert.True(result[0].Owner.Name == ownerName);
            Assert.True(result[0].Status != RiskStatus.Open);
        }

        [Test]
        public void CheckSimpleBuilder_WithoutOwnerName()
        {
            RiskStatus notStatus = RiskStatus.Open;
            string title = "fire";

            ICommand byDiffrentStatus = new ByDiffrentStatusCommand(notStatus);
            ICommand byTitle = new ByTitleCommand(title);

            var riskProvider = new RiskProvider(listOfRisks);

            riskProvider.ExecCommand(byDiffrentStatus);
            riskProvider.ExecCommand(byTitle);
            var result = riskProvider.GetResults().ToList();

            Assert.True(result.Count == 2);
            Assert.True(result[0].Title.Contains(title));
            Assert.True(result[0].Status != RiskStatus.Open);
        }

        [Test]
        public void CheckCommand_AllMethods()
        {
            RiskStatus notStatus = RiskStatus.Open;
            string title = "fire";
            string ownerName = "Jon Moore";

            ICommand byOwnerName = new ByOnwerNameCommand(ownerName);
            ICommand byDiffrentStatus = new ByDiffrentStatusCommand(notStatus);
            ICommand byTitle = new ByTitleCommand(title);

            var riskProvider = new RiskProvider(listOfRisks);
            riskProvider.ExecCommand(byOwnerName);
            riskProvider.ExecCommand(byDiffrentStatus);
            riskProvider.ExecCommand(byTitle);
            var result = riskProvider.GetResults().ToList();

            Assert.True(result.Count == 1);
            Assert.True(result[0].Owner.Name == ownerName);
            Assert.True(result[0].Title.Contains(title));
            Assert.True(result[0].Status != RiskStatus.Open);
        }


    }
}