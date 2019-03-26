using RiskModel;
using System;
using System.Collections.Generic;

namespace RiskSolution
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            InitializeCollection();
            MultiSearch Msearch = new MultiSearch();

            string ownerName;
            RiskStatus status;
            string title;

            Console.WriteLine("We will start search please enter owner name");
            ownerName = Console.ReadLine();

            Console.WriteLine("Please enter risk status");
            // status = Console.ReadLine();

            Console.WriteLine("Please enter title");
            title = Console.ReadLine();

            // PrintSelectedRisc(Msearch.GetListOfRisksByOwnerStatusTitle(ownerName, status, title));
        }

        public static void InitializeCollection()
        {
            RiskService data = new RiskService();
            var ListOfRiscs =  data.GetRisks();

            //foreach (var item in ListOfRiscs)
            //{
            //    Console.WriteLine(item.Owner.Name+ "  --" + item.Title);

            //}
            List<Risk>  resultOwned =  ListOfRiscs.FindAll(x => x.Owner.Name == "Matt Sharpe");
            PrintSelectedRisc(resultOwned);

            List<Risk> resultStatus = ListOfRiscs.FindAll(x => x.Status.ToString() !="Unapproved");
            PrintSelectedRisc(resultStatus);

            List<Risk> resultInTitle = ListOfRiscs.FindAll(x => x.Title.Contains("fire"));
            PrintSelectedRisc(resultInTitle);
            Console.ReadLine();
        }

        public static void PrintSelectedRisc(List<Risk> risk)
        {
            Console.WriteLine();

            foreach (var item in risk)
            {
                Console.WriteLine(item.Title + "  " + item.Owner.Name + " " + item.Status.ToString() + " " + item.RiskScore);
            }
        }
    }
}