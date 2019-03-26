using NUnit.Framework;
using RiskModel;
using RiskModel.Command;
using RiskModel.Decorator;
using System.Collections.Generic;
using System.Linq;

namespace Risk_Test
{
    [TestFixture]
    class Decorator_Tests
    {

        [Test]
        public void CheckDecorator_RiskStatus()
        {
            RiskStatus notStatus = RiskStatus.Open;

            IDecoratorSolution riskList = new DecoratorSolutionBase();
            riskList = new DiffrentStatesOfRiskDecorator(riskList, notStatus);

            var result = riskList.GetRisks().ToList();

            Assert.True(result.Count == 7);
            foreach (var i in result)
                Assert.True(i.Status != RiskStatus.Open);
        }

        [Test]
        public void CheckDecorator_WitoutStatus()
        {
            string ownerName = "Person 5";
            string title = "fire";
            
            IDecoratorSolution riskList = new DecoratorSolutionBase();
            riskList = new ByOwnerNameDecorator(riskList, ownerName);
            riskList = new ByRiskTitleDecorator(riskList, title);

            var result = riskList.GetRisks().ToList();

            Assert.True(result.Count == 3);
            Assert.True(result[0].Owner.Name == ownerName);
            Assert.True(result[1].Owner.Name == ownerName);
            Assert.True(result[2].Owner.Name == ownerName);
            Assert.True(result[0].Title.Contains(title, System.StringComparison.InvariantCultureIgnoreCase));
            Assert.True(result[1].Title.Contains(title, System.StringComparison.InvariantCultureIgnoreCase));
            Assert.True(result[2].Title.Contains(title, System.StringComparison.InvariantCultureIgnoreCase));
        }


        [Test]
        public void CheckDecorator_WithoutTitle()
        {
            string ownerName = "Person 5";
            RiskStatus notStatus = RiskStatus.Open;

            IDecoratorSolution riskList = new DecoratorSolutionBase();
            riskList = new ByOwnerNameDecorator(riskList, ownerName);
            riskList = new DiffrentStatesOfRiskDecorator(riskList, notStatus);
            

            var result = riskList.GetRisks().ToList();

            Assert.True(result.Count == 1);
            Assert.True(result[0].Owner.Name == ownerName);
            Assert.True(result[0].Status != RiskStatus.Open);
        }


        [Test]
        public void CheckDecorator_WithoutOwnerName()
        {
            RiskStatus notStatus = RiskStatus.Open;
            string title = "fire";

            IDecoratorSolution riskList = new DecoratorSolutionBase();
            riskList = new DiffrentStatesOfRiskDecorator(riskList, notStatus);
            riskList = new ByRiskTitleDecorator(riskList, title);

            var result = riskList.GetRisks().ToList();

            Assert.True(result.Count == 2);
            Assert.True(result[0].Title.Contains(title));
            Assert.True(result[0].Status != RiskStatus.Open);
        }

        [Test]
        public void CheckDecorator_AllMethods()
        {
            RiskStatus notStatus = RiskStatus.Open;
            string title = "fire";
            string ownerName = "Person 5";

            IDecoratorSolution riskList = new DecoratorSolutionBase();
            riskList = new ByOwnerNameDecorator(riskList, ownerName);
            riskList = new DiffrentStatesOfRiskDecorator(riskList, notStatus);
            riskList = new ByRiskTitleDecorator(riskList, title);

            var result = riskList.GetRisks().ToList();

            Assert.True(result.Count == 1);
            Assert.True(result[0].Owner.Name.ToLower() == ownerName.ToLower());
            Assert.True(result[0].Title.Contains(title));
            Assert.True(result[0].Status != RiskStatus.Open);
        }



        [Test]
        public void CheckCommand_RiskStatus()
        {
            RiskStatus notStatus = RiskStatus.Open;

            IDecoratorSolution riskList = new DecoratorSolutionBase();
            riskList = new DiffrentStatesOfRiskDecorator(riskList, notStatus);

            var result = riskList.GetRisks().ToList();

            Assert.True(result.Count == 7);
            foreach (var r in result)
                Assert.True(r.Status != notStatus);
        }



        [Test]
        public void CheckDecorator_WrongUserName()
        {
            string ownerName = "James Bond";

            IDecoratorSolution riskList = new DecoratorSolutionBase();
            riskList = new ByOwnerNameDecorator(riskList, ownerName);

            var result = riskList.GetRisks().ToList();

            Assert.True(result.Count == 0);
        }


        [Test]
        public void CheckDecorator_UserName_KeySensitive()
        {
            string ownerName = "Person 5";

            IDecoratorSolution riskList = new DecoratorSolutionBase();
            riskList = new ByOwnerNameDecorator(riskList, ownerName);

            var result = riskList.GetRisks().ToList();

            Assert.True(result.Count == 3);
            Assert.True(result[0].Owner.Name.ToLower() == ownerName.ToLower());
            Assert.True(result[1].Owner.Name.ToLower() == ownerName.ToLower());
            Assert.True(result[2].Owner.Name.ToLower() == ownerName.ToLower());
        }

        [Test]
        public void CheckDecorator_Title_KeySensitive()
        {
            string title = "Fire";

            IDecoratorSolution riskList = new DecoratorSolutionBase();
            riskList = new ByRiskTitleDecorator(riskList, title);

            var result = riskList.GetRisks().ToList();

            Assert.True(result.Count == 4);
            Assert.True(result[0].Title.ToLower().Contains(title.ToLower()));
            Assert.True(result[1].Title.ToLower().Contains(title.ToLower()));
            Assert.True(result[2].Title.ToLower().Contains(title.ToLower()));
            Assert.True(result[3].Title.ToLower().Contains(title.ToLower()));
        }

        [Test]
        public void CheckDecorator_Title_Misspelled()
        {
            string title = "Fire,";

            IDecoratorSolution riskList = new DecoratorSolutionBase();
            riskList = new ByRiskTitleDecorator(riskList, title);

            var result = riskList.GetRisks().ToList();

            Assert.True(result.Count == 0);
        }

    }
}
