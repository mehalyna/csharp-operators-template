using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Test_Task1
{
    [TestClass]
    public class UnitTest1
    {
        #region Initialize

        #endregion

        #region TestMethod1




        [TestMethod, TestCategory("CategoryA")]
        [TestCategory("InOut")]
        [TestProperty("GSO-DevGroup", "Kander")]
        [DataRow(100, 5,5)]

        public void Test_InOut2(double value_1, double value_2, double value_3)
        {
            // Arrange
            var writer = new StringWriter();
            Console.SetOut(writer);


            var textReader = new StringReader(@$"{value_1}
{value_2}");

            Console.SetIn(textReader);

            // Act
            Aufgabe_1.Aufgabe1();


            // Assert

            List<string> lines_list_check = new List<string> { $"Ihre Zinsen belaufen sich auf:{value_3,10:F2} EUR" };

            var sb = writer.GetStringBuilder();
            var lines = sb.ToString().Split(Environment.NewLine, StringSplitOptions.TrimEntries);

            List<string> lines_list = new List<string>();

            //Bedingung nötig da 'Enviroment.NewLine' in Git Actions nicht funktioniert.
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i] != "")
                {
                    lines_list.Add(lines[i]);
                    Debug.WriteLine($"{lines[i]}");
                }
            }





            lines_list = lines_list.Intersect(lines_list_check).ToList();


            for (int i = 0; i < lines_list_check.Count; i++)
            {

                try
                {
                    if (lines_list[i] != lines_list_check[i]) Trace.WriteLine($"\nFehler: '{lines_list_check[i]}' nicht gefunden");
                    Assert.AreEqual(lines_list[i], lines_list_check[i]);
                }
                catch
                {
                    Trace.WriteLine($"Fehler: Zeile fehlt");
                    Trace.WriteLine($"{lines_list_check[i]}");
                    Assert.Fail(); ;

                }

            }

        }


        #endregion

    }
}