﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Lab9_4StringBuilderCreatingDynamicHTML
{

    class HtmlPageBuilder
    {

        #region Fields and Properties

        private StringBuilder htmlText = new StringBuilder();

        private string bodyOpen { get; set; } = "<body>";
        private string bodyClose { get; set; } = "</body>";
        private string htmlParaOpen { get; set; } = "<p>";
        private string htmlParaClose { get; set; } = "</p>";
        private string htmlHeader1Open { get; set; } = "<h1>";
        private string htmlHeader1Close { get; set; } = "</h1>";
        private string htmlUnorderedOpen { get; set; } = "<ul>";
        private string htmlUnorderedClose { get; set; } = "</ul>";
        private string htmlLIOpen { get; set; } = "<li>";
        private string htmlLIClose { get; set; } = "</li>";
        private string dynamicHtml { get; set; } = string.Empty;

        #endregion

        #region Constructors

        public HtmlPageBuilder()
        {

        }

        public HtmlPageBuilder(string bodyOpen, string bodyClose, string htmlParaOpen,
                                string htmlParaClose, string htmlHeader1Open, string htmlHeader1Close,
                                string htmlUnorderedOpen, string htmlUnorderedClose,
                                string htmlLIOpen, string htmlLIClose)
        {

            this.bodyOpen = bodyOpen;
            this.bodyClose = bodyClose;
            this.htmlParaOpen = htmlParaOpen;
            this.htmlParaClose = htmlParaClose;
            this.htmlUnorderedOpen = htmlUnorderedOpen;
            this.htmlUnorderedClose = htmlUnorderedClose;
            this.htmlLIOpen = htmlLIOpen;
            this.htmlLIClose = htmlLIClose;

        }

        #endregion

        #region Methods

        public void CollectThenCreateHTML()
        {

            // htmlText = new StringBuilder();

            htmlText.Append(bodyOpen);

            htmlText.Append(htmlHeader1Open);
            Console.WriteLine("Enter text for the HTML header.");
            dynamicHtml = Console.ReadLine();
            htmlText.Append(dynamicHtml);
            htmlText.Append(htmlHeader1Close);

            Console.WriteLine("Time to build our unordered list...");

            int liCount = 0;

            Console.WriteLine("Enter the number of items in your list?");
            liCount = Convert.ToInt32(Console.ReadLine());

            // Create the Unordered List. Start with <ul>.
            htmlText.Append(htmlUnorderedOpen);

            // Refactored code from Lab9_4; See old version below 
            //  failing to adhere to DRY - Don't Repeat Yourself

            for (int li = 0; li < liCount; li++)
            {

                htmlText.Append(htmlLIOpen);

                if (li == 0)
                {
                    Console.WriteLine("Add the first item to the list.");
                }
                else if (li == (liCount - 1))
                {
                    Console.WriteLine("Add the last item to the list.");
                }
                else
                {
                    Console.WriteLine("Add another item to the list.");
                }

                dynamicHtml = Console.ReadLine();
                htmlText.Append(dynamicHtml);
                htmlText.Append(htmlLIClose);

            }

            // Refactored since Lab9_4 to adhere to DRY

            // htmlText.Append(htmlLIOpen);
            // Console.WriteLine("Add an item to the list.");
            // dynamicHtml = Console.ReadLine();
            // htmlText.Append(dynamicHtml);
            // htmlText.Append(htmlLIClose);

            // htmlText.Append(htmlLIOpen);
            // Console.WriteLine("Add another item to the list.");
            // dynamicHtml = Console.ReadLine();
            // htmlText.Append(dynamicHtml);
            // htmlText.Append(htmlLIClose);

            // htmlText.Append(htmlLIOpen);
            // Console.WriteLine("Add another item to the list.");
            // dynamicHtml = Console.ReadLine();
            // htmlText.Append(dynamicHtml);
            // htmlText.Append(htmlLIClose);

            // End the Unordered List with </ul>.
            htmlText.Append(htmlUnorderedClose);

            htmlText.Append(bodyClose);

            if (htmlText.ToString().Length > 0)
            {
                WriteFile();
            }

        }

        public void WriteFile()
        {
            // Folder must be created off of the c drive prior to writing the file to the FSO.
            // On the other hand if the file is saved amongst the users logged in profile the
            // file folder doesn't need to be created before it is written...added by th 07132020
            FileWriter fw = new FileWriter(@"C:\CSharpLabs\Lab9_4.html", htmlText.ToString());
            fw.WriteThisFile();
        }

        #endregion

    }
}