using MfLibrary;
using GusLibrary;
using System;
using DataLayerLibrary;
using System.Linq;

namespace ConsoleTestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //var nip = GusApiHelper.DataSearchSubjects("5260211469");
            var mf = MfApiHelper.SearchNip("5260211469");
            var gus = GusApiHelper.DataSearchSubjects("5260211469");
            var db = new Context();
            //var res = db.GusDomain.FirstOrDefault(e => e.Nip == "5260211469" && e.AddedDate == DateTime.Today);
            //db.GusDomain.Add(gus);
            db.MfDomain.Add(mf);
            db.SaveChanges();
            // Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.
            Console.WriteLine("Hello World!");
            Console.ReadKey();

            // Go to http://aka.ms/dotnet-get-started-console to continue learning how to build a console app! 
        }
    }
}
