﻿using KattisUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeKattisRSS
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = new KattisProblemPageGrabber();
            s.GrabbedPage += S_GrabbedPage;
            s.GrabPages();
            KattisHTMLScraper khtml = new KattisHTMLScraper();
           
            int i = 1;
            foreach (var page in s.HTMLPages)
            {
        
                khtml.AppendProblemsOnPage(page);
                Console.WriteLine($"Scraping Page {i++}/{s.HTMLPages.Count} {khtml.Count} total problems downloaded");
            }
            foreach (KeyValuePair<string,KattisFromHTMLProblem> kvp in khtml)
            {
                Console.WriteLine($'{kvp.Value.Title}','{kvp.Value.ID}','{kvp.Value.Link}'");

            
            
            
            }
            Console.ReadKey();
        }

        private static void S_GrabbedPage(object sender, PageGrabbedEventArgs e)
        {
            Console.WriteLine($"Downloaded {e.Size} bytes from {e.Url} in {e.Time} seconds");
        }
    }
}
