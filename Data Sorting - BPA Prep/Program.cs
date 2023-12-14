using System.Collections.Generic;
using System.Linq;
using System.IO;

string[] lines = System.IO.File.ReadAllLines(@"C:\Users\mays_jacobj\Downloads\Sample_Data_Age.csv");

IEnumerable<string> sortedLines =
   from line in lines
   let x = line.Split(',')
   orderby x[0] 
   select line;

System.IO.File.WriteAllLines(@"path\to\sorted\file.csv", sortedLines.ToArray());

var groupedLines = sortedLines
   .Select(line => new
   {
       AgeGroup = int.Parse(line.Split(',')[1]),
       Line = line
   })
   .GroupBy(x => x.AgeGroup < 25 ? "18-24" : x.AgeGroup < 36 ? "25-35" : x.AgeGroup < 56 ? "36-55" : "55+")
   .SelectMany(g => g.Select(x => x.Line));

System.IO.File.WriteAllLines(@"path\to\grouped\file.csv", groupedLines.ToArray());