﻿#region ======================== Namespaces

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;

#endregion

namespace mxd.ChangelogMaker
{
	class Program
	{
		#region ======================== Constants

		private const string SEPARATOR = "--------------------------------------------------------------------------------";

		#endregion

		#region ======================== Main

		static int Main(string[] args)
		{
			Console.WriteLine("Changelog Maker v03 by MaxED");
			if(args.Length != 4)
			{
				return Fail("USAGE: ChangelogMaker.exe input output author revision_number\n" +
							"input: xml file generated by MakeRelese.bat\\MakeGITRelese.bat\n" +
							"output: directory to store Changelog.txt in\n" +
							"renameauthor: commit authors rename scheme. For example, \"m-x-d>MaxED|biwa>Boris\"\n" +
							"revision_number: latest revision number", 1);
			}

			string input = args[0];
			string output = args[1];
			string renameauthor = args[2]; // m-x-d>MaxED|biwa>Boris
			int revnum;
			if(!int.TryParse(args[3], out revnum)) return Fail("Unable to parse revision number from string '" + revnum + "'.", 4);

			if(!File.Exists(input)) return Fail("Input file '" + input + "' does not exist.", 2);
			if(!Directory.Exists(output)) return Fail("Output folder '" + output + "' does not exist.", 3);

			// Create author rename array, because git log can't decide how to call me...
			Dictionary<string, string> authorrename = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
			string[] parts = renameauthor.Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
			foreach(string ren in parts)
			{
				string[] rename = ren.Split(new[] { '>' }, StringSplitOptions.RemoveEmptyEntries);
				if(rename.Length == 2 && !string.IsNullOrEmpty(rename[0].Trim()) && !string.IsNullOrEmpty(rename[1].Trim()))
				{
					authorrename[rename[0].Trim()] = rename[1].Trim();
				}
				else
				{
					Console.WriteLine("Invalid rename scheme: \"" + ren + "\"");
				}
			}

			//Replace bracket placeholders, because git log command doesn't escape xml-unfriendly chars like < or >...
			string inputtext = File.ReadAllText(input);
			inputtext = inputtext.Replace("<", "&lt;").Replace(">", "&gt;").Replace("&", "&amp;").Replace("[OB]", "<").Replace("[CB]", ">");
			
			XmlDocument log = new XmlDocument();
			using(MemoryStream stream = new MemoryStream(Encoding.ASCII.GetBytes(inputtext)))
			{
				log.Load(stream);
			}

			StringBuilder result = new StringBuilder(1000);
			char[] messagetrim = {' ', '\r', '\n' };
			foreach(XmlNode node in log.ChildNodes) 
			{
				if(node.ChildNodes.Count == 0) continue;

				foreach (XmlNode logentry in node.ChildNodes)
				{
					string commit = (logentry.Attributes != null ? logentry.Attributes.GetNamedItem("commit").Value : "unknown");
					DateTime date = DateTime.Now;
					string message = string.Empty;
					string author = string.Empty;

					// Add revision info...
					if(logentry.Attributes != null)
					{
						var revinfo = log.CreateAttribute("revision");
						revinfo.Value = revnum.ToString();
						logentry.Attributes.SetNamedItem(revinfo);
					}

					foreach(XmlNode value in logentry.ChildNodes)
					{
						switch(value.Name)
						{
							case "author":
								if(authorrename.ContainsKey(value.InnerText))
								{
									author = authorrename[value.InnerText];
									value.InnerText = author; // save author
								}
								else
								{
									author = value.InnerText;
								}
								break;

							case "date":
								date = Convert.ToDateTime(value.InnerText); 
								break;

							case "msg":
								message = value.InnerText.Trim(messagetrim);
								value.InnerText = message; // also save trimmed message
								break;
						}
					}

					result.Append("R" + revnum)
					      .Append(" | ")
						  .Append(commit)
						  .Append(" | ")
						  .Append(author)
						  .Append(" | ")
					      .Append(date.ToShortDateString())
					      .Append(", ")
					      .Append(date.ToShortTimeString())
					      .Append(Environment.NewLine)
						  .AppendLine(SEPARATOR)
					      .Append(message)
					      .Append(Environment.NewLine)
                          .Append(Environment.NewLine)
						  .Append(Environment.NewLine);

					// Decrease revision number...
					revnum--;
				}
				break;
			}

			// Save modified xml
			log.Save(input);

			//Save result
			string outputpath = Path.Combine(output, "Changelog.txt");
			File.WriteAllText(outputpath, result.ToString());
			Console.WriteLine("Saved '" + outputpath + "'");

			//All done
			return 0;
		}

		#endregion

		private static int Fail(string message, int exitcode)
		{
			Console.WriteLine(message + "\nPress any key to quit");
			Console.ReadKey();
			return exitcode;
		}
	}
}
