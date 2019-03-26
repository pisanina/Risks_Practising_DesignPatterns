using NUnit.Framework;
using RiskModel;
using System.Collections.Generic;

namespace Risk_Test
{
    public class Risk_tests
    {
        [TestFixture]
        internal class Risk_Tests
        {
            private RiskService service = new RiskService();
            private List<Risk> listOfRisks = new List<Risk>();
            private Search search= new Search();

            [SetUp]
            public void CreateRepositoryForTests()
            {
                listOfRisks = service.GetRisks();
            }


            [Test]
            public void CheckSearchByOwnerName()
            {
                string ownerName = "Jon Moore";
                var result = search.GetListOfRisksWithOwnerName(ownerName);
                Assert.True(result.Count == 3);
                Assert.True(result[0].Owner.Name == "Jon Moore");
                Assert.True(result[1].Owner.Name == "Jon Moore");
                Assert.True(result[2].Owner.Name == "Jon Moore");
            }

            [Test]
            public void CheckSearchByOwnerName_NoCaseSensitive()
            {
                string ownerName = "jon moore";
                var result = search.GetListOfRisksWithOwnerName(ownerName);
                Assert.True(result.Count == 3);
                Assert.True(result[0].Owner.Name == "Jon Moore");
                Assert.True(result[1].Owner.Name == "Jon Moore");
                Assert.True(result[2].Owner.Name == "Jon Moore");
            }

            [Test]
            public void CheckSearchByOwnerName_NoResults()
            {
                string ownerName = "jon";
                var result = search.GetListOfRisksWithOwnerName(ownerName);
                Assert.True(result.Count == 0);
            }

            [Test]
            public void CheckSearchByOwnerId()
            {
                int ownerId = 1;
                var result = search.GetListOfRisksWithOwnerId(ownerId);
                Assert.True(result.Count == 2);
                Assert.True(result[0].Owner.Id == ownerId);
                Assert.True(result[1].Owner.Id == ownerId);
            }

            [Test]
            public void CheckSearchByOwnerId_NoResults()
            {
                int ownerId = 15;
                var result = search.GetListOfRisksWithOwnerId(ownerId);
                Assert.True(result.Count == 0);
            }

            [Test]
            public void CheckSearchByRiskId()
            {
                int riskId = 1;
                var result = search.GetListOfRisksWithRiskId(riskId);
                Assert.True(result.Count == 1);
                Assert.True(result[0].Id == riskId);
            }

            [Test]
            public void CheckSearchByRiskId_NoResults()
            {
                int riskId = 15;
                var result = search.GetListOfRisksWithRiskId(riskId);
                Assert.True(result.Count == 0);
            }

            [Test]
            public void CheckSearchByRiskScore()
            {
                int riskScore = 5;
                var result = search.GetListOfRisksWithRiskScore(riskScore);
                Assert.True(result.Count == 1);
                Assert.True(result[0].RiskScore == riskScore);
            }

            [Test]
            public void CheckSearchByRiskScore_NoResults()
            {
                int riskScore = 554;
                var result = search.GetListOfRisksWithRiskScore(riskScore);
                Assert.True(result.Count == 0);
            }

            [Test]
            public void CheckSearchByRiskStatus()
            {
                RiskStatus status = RiskStatus.Closed;
                var result = search.GetListOfRisksWithStatus(status);
                Assert.True(result.Count == 1);
                Assert.True(result[0].Status == status);
            }

            [Test]
            public void CheckSearchByDiffrentRiskStatus()
            {
                RiskStatus notStatus = RiskStatus.Approved;
                var result = search.GetListOfRisksWithDifferentStatus(notStatus);
                Assert.True(result.Count == 7);
                Assert.True(result[0].Status != notStatus);
                Assert.True(result[1].Status != notStatus);
                Assert.True(result[2].Status != notStatus);
                Assert.True(result[3].Status != notStatus);
                Assert.True(result[4].Status != notStatus);
                Assert.True(result[5].Status != notStatus);
                Assert.True(result[6].Status != notStatus);
            }

            [Test]
            public void CheckSearchByTitle()
            {
                string title = "Fire";
                var result = search.GetListOfRisksWithTitleContains(title);
                Assert.True(result.Count == 4);
                Assert.True(result[0].Title.Contains(title, System.StringComparison.InvariantCultureIgnoreCase));
                Assert.True(result[1].Title.Contains(title, System.StringComparison.InvariantCultureIgnoreCase));
                Assert.True(result[2].Title.Contains(title, System.StringComparison.InvariantCultureIgnoreCase));
                Assert.True(result[3].Title.Contains(title, System.StringComparison.InvariantCultureIgnoreCase));
            }
        }
    }
}