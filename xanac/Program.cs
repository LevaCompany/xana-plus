/*
By InnieSharp(ix4/i#)
*/
using System;
using System.IO;
using System.Threading;
using System.Diagnostics;
using Microsoft.Win32;
using System.Linq;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Text;
using System.Security.Principal;
using System.Globalization;
using System.Web;
using System.Net;
using System.Windows.Forms;
using System.Drawing;
using System.Media;

namespace xanac
{
	class Program
	{
		public static string path;
        public static List<string> vars;
        public static bool logs;
        public static string logf;
		
        
		public static void Main(string[] args)
		{
			vars = new List<string>
            {
            	"curdir=" + Environment.CurrentDirectory,
            	"sysdir=" + Environment.SystemDirectory,
            	"machinename=" + Environment.MachineName,
            	"username=" + Environment.UserName,
            	"osver=" + Environment.OSVersion,
            	""
            };
			
			bool have = false;
            foreach(string l in args)
            {
            	string s = l;
            	if(!have)
            	{
            		if(s.StartsWith("file:"))
            		{
            			s = s.Remove(0, 5);
	            		if(File.Exists(s))
	            		{
		        			path = s;
		        			have = true;
	            		}
	            		else
	            		{
	            			Console.WriteLine("Not found file " + s);
	            			Console.ReadKey();
        					Environment.Exit(0);
	            		}
	            		break;
            		}
            		else if(s == "ver")
            		{
            			Console.WriteLine("Xana by ix4Software");
            			Console.ReadKey();
    					Environment.Exit(0);
            		}
            		else
            		{
            			Console.WriteLine("Wrong argument " + s);
            			Console.ReadKey();
    					Environment.Exit(0);
            		}
            	}
            }
            if(!have)
            {
	            if(File.Exists("main.x"))
	        		path = "main.x";
	        	else
	        	{
	        		Console.WriteLine("Not found main.x");
	            	Console.ReadKey();
	        		Environment.Exit(0);
	        	}
            }

            //other
            logs = false;
            logf = "logs.txt";
            
            // Вызываем основной метод
            oth();
		}
		
		[STAThread]
		public static void oth()
		{
			string[] l = File.ReadAllLines(path);
			for(int i = 0; i < l.Length; i++)
			{
				try
				{
					if(l[i].StartsWith("print "))
					{
						string str = l[i].Remove(0, 6);
						string[] splitstr = { "&&&" };
						string[] splitres = str.Split(splitstr, StringSplitOptions.None);
						string result = "";
						for(int ch = 0; ch < splitres.Length; ch++)
						{
							string str2 = splitres[ch];
							if(str2.StartsWith("/"))
							{
								str2 = str2.Remove(0, 1);
								result += str2;
							}
							else if(str2.StartsWith("$"))
							{
								string var = str2.Remove(0, 1);
								bool act = false;
								for(int ln = 0; ln < vars.Count; ln++)
								{
									if(vars[ln].StartsWith(var + "="))
									{
										result += vars[ln].Substring(vars[ln].IndexOf("=") + 1);
										act = true;
										break;
									}
								}
								if(!act)
								{
									result += "empty";
								}
							}
							else if(str2 == "time")
							{
								result += DateTime.Now.ToString("HH:mm:ss");
							}
							else if(str2 == "date")
							{
								result += DateTime.Now.ToString("dd.MM.yyyy");
							}
							else
							{
								result += str2;
							}
						}
						str = result;
						Console.WriteLine(str);
					}
					else if(l[i].StartsWith("color "))
					{
						string stra = l[i].Remove(0, 6);
						string[] splitstra = { " " };
						string[] splitresa = stra.Split(splitstra, StringSplitOptions.None);
						string bg = splitresa[1];
						string fg = splitresa[0];
						string[] splitstr = { "&&&" };
						string[] splitres = fg.Split(splitstr, StringSplitOptions.None);
						string result = "";
						for(int ch = 0; ch < splitres.Length; ch++)
						{
							string str2 = splitres[ch];
							if(str2.StartsWith("/"))
							{
								str2 = str2.Remove(0, 1);
								result += str2;
							}
							else if(str2.StartsWith("$"))
							{
								string var = str2.Remove(0, 1);
								bool act = false;
								for(int ln = 0; ln < vars.Count; ln++)
								{
									if(vars[ln].StartsWith(var + "="))
									{
										result += vars[ln].Substring(vars[ln].IndexOf("=") + 1);
										act = true;
										break;
									}
								}
								if(!act)
								{
									result += "empty";
								}
							}
							else if(str2 == "time")
							{
								result += DateTime.Now.ToString("HH:mm:ss");
							}
							else if(str2 == "date")
							{
								result += DateTime.Now.ToString("dd.MM.yyyy");
							}
							else
							{
								result += str2;
							}
						}
						fg = result;
						splitres = bg.Split(splitstr, StringSplitOptions.None);
						result = "";
						for(int ch = 0; ch < splitres.Length; ch++)
						{
							string str2 = splitres[ch];
							if(str2.StartsWith("/"))
							{
								str2 = str2.Remove(0, 1);
								result += str2;
							}
							else if(str2.StartsWith("$"))
							{
								string var = str2.Remove(0, 1);
								bool act = false;
								for(int ln = 0; ln < vars.Count; ln++)
								{
									if(vars[ln].StartsWith(var + "="))
									{
										result += vars[ln].Substring(vars[ln].IndexOf("=") + 1);
										act = true;
										break;
									}
								}
								if(!act)
								{
									result += "empty";
								}
							}
							else if(str2 == "time")
							{
								result += DateTime.Now.ToString("HH:mm:ss");
							}
							else if(str2 == "date")
							{
								result += DateTime.Now.ToString("dd.MM.yyyy");
							}
							else
							{
								result += str2;
							}
						}
						bg = result;
						switch (fg)
						{
							case "gray":
								Console.ForegroundColor = ConsoleColor.Gray;
								break;
							case "black":
								Console.ForegroundColor = ConsoleColor.Black;
								break;
							case "red":
								Console.ForegroundColor = ConsoleColor.Red;
								break;
							case "yellow":
								Console.ForegroundColor = ConsoleColor.Yellow;
								break;
							case "green":
								Console.ForegroundColor = ConsoleColor.Green;
								break;
							case "blue":
								Console.ForegroundColor = ConsoleColor.Blue;
								break;
							case "white":
								Console.ForegroundColor = ConsoleColor.White;
								break;
							case "cyan":
								Console.ForegroundColor = ConsoleColor.Cyan;
								break;
							default:
								Console.ForegroundColor = ConsoleColor.Gray;
								break;
						}
						switch (bg)
						{
							case "gray":
								Console.BackgroundColor = ConsoleColor.Gray;
								break;
							case "black":
								Console.BackgroundColor = ConsoleColor.Black;
								break;
							case "red":
								Console.BackgroundColor = ConsoleColor.Red;
								break;
							case "yellow":
								Console.BackgroundColor = ConsoleColor.Yellow;
								break;
							case "green":
								Console.BackgroundColor = ConsoleColor.Green;
								break;
							case "blue":
								Console.BackgroundColor = ConsoleColor.Blue;
								break;
							case "white":
								Console.BackgroundColor = ConsoleColor.White;
								break;
							case "cyan":
								Console.BackgroundColor = ConsoleColor.Cyan;
								break;
							default:
								Console.BackgroundColor = ConsoleColor.Black;
								break;
						}
					}
					else if(l[i].StartsWith("caption "))
					{
						string str = l[i].Remove(0, 8);
						string[] splitstr = { "&&&" };
						string[] splitres = str.Split(splitstr, StringSplitOptions.None);
						string result = "";
						for(int ch = 0; ch < splitres.Length; ch++)
						{
							string str2 = splitres[ch];
							if(str2.StartsWith("/"))
							{
								str2 = str2.Remove(0, 1);
								result += str2;
							}
							else if(str2.StartsWith("$"))
							{
								string var = str2.Remove(0, 1);
								bool act = false;
								for(int ln = 0; ln < vars.Count; ln++)
								{
									if(vars[ln].StartsWith(var + "="))
									{
										result += vars[ln].Substring(vars[ln].IndexOf("=") + 1);
										act = true;
										break;
									}
								}
								if(!act)
								{
									result += "empty";
								}
							}
							else if(str2 == "time")
							{
								result += DateTime.Now.ToString("HH:mm:ss");
							}
							else if(str2 == "date")
							{
								result += DateTime.Now.ToString("dd.MM.yyyy");
							}
							else
							{
								result += str2;
							}
						}
						str = result;
						Console.Title = str;
					}
					else if(l[i].StartsWith("var "))
					{
						string stra = l[i].Remove(0, 4);
						string var1 = stra.Substring(0, stra.IndexOf("="));
						string str = stra.Substring(stra.IndexOf("=") + 1);
						string[] splitstr = { "&&&" };
						string[] splitres = str.Split(splitstr, StringSplitOptions.None);
						string result = "";
						for(int ch = 0; ch < splitres.Length; ch++)
						{
							string str2 = splitres[ch];
							if(str2.StartsWith("/"))
							{
								str2 = str2.Remove(0, 1);
								result += str2;
							}
							else if(str2.StartsWith("$"))
							{
								string var = str2.Remove(0, 1);
								bool act = false;
								for(int ln = 0; ln < vars.Count; ln++)
								{
									if(vars[ln].StartsWith(var + "="))
									{
										result += vars[ln].Substring(vars[ln].IndexOf("=") + 1);
										act = true;
										break;
									}
								}
								if(!act)
								{
									result += "empty";
								}
							}
							else if(str2 == "time")
							{
								result += DateTime.Now.ToString("HH:mm:ss");
							}
							else if(str2 == "date")
							{
								result += DateTime.Now.ToString("dd.MM.yyyy");
							}
							else
							{
								result += str2;
							}
						}
						str = result;
						bool d = false;
						for (int ch = 0; ch < vars.Count; ch++)
	                    {
	                        if (vars[ch].StartsWith(var1 + "="))
	                        {
	                        	vars[ch] = var1 + "=" + str;
	                        	d = true;
	                            break;
	                        }
	                    }
	                    if(!d)
	                    	vars.Add(var1 + "=" + str);
					}
					else if(l[i].StartsWith("set "))
					{
						string stra = l[i].Remove(0, 4);
						string var1 = stra.Substring(0, stra.IndexOf("="));
						string str = stra.Substring(stra.IndexOf("=") + 1);
						string[] splitstr = { "&&&" };
						string[] splitres = str.Split(splitstr, StringSplitOptions.None);
						string result = "";
						for(int ch = 0; ch < splitres.Length; ch++)
						{
							string str2 = splitres[ch];
							if(str2.StartsWith("/"))
							{
								str2 = str2.Remove(0, 1);
								result += str2;
							}
							else if(str2.StartsWith("$"))
							{
								string var = str2.Remove(0, 1);
								bool act = false;
								for(int ln = 0; ln < vars.Count; ln++)
								{
									if(vars[ln].StartsWith(var + "="))
									{
										result += vars[ln].Substring(vars[ln].IndexOf("=") + 1);
										act = true;
										break;
									}
								}
								if(!act)
								{
									result += "empty";
								}
							}
							else if(str2 == "time")
							{
								result += DateTime.Now.ToString("HH:mm:ss");
							}
							else if(str2 == "date")
							{
								result += DateTime.Now.ToString("dd.MM.yyyy");
							}
							else
							{
								result += str2;
							}
						}
						str = result;
						Console.Write(str); string va = Console.ReadLine();
						bool d = false;
						for (int ch = 0; ch < vars.Count; ch++)
	                    {
	                        if (vars[ch].StartsWith(var1 + "="))
	                        {
	                        	vars[ch] = var1 + "=" + va;
	                        	d = true;
	                            break;
	                        }
	                    }
	                    if(!d)
	                    	vars.Add(var1 + "=" + va);
					}
					else if(l[i] == "clear")
						Console.Clear();
					else if(l[i] == "pause")
						Console.ReadKey(true);
					else if(l[i] == "exit")
						Environment.Exit(0);
					else if(l[i].StartsWith("if "))
					{
						string def = l[i].Remove(0, 3);
						string[] splita = { " " };
						string[] st = def.Split(splita, StringSplitOptions.None);
						string vara = st[0];
						string actu = st[1];
						string txt = st[2];
						string func = st[3];
						bool act1 = false;
						for(int ln = 0; ln < vars.Count; ln++)
						{
							if(vars[ln].StartsWith(vara + "="))
							{
								vara = vars[ln].Substring(vars[ln].IndexOf("=") + 1);
								act1 = true;
								break;
							}
						}
						if(!act1)
						{
							vara = "empty";
						}
						string[] splitstr = { "&&&" };
						string[] splitres = txt.Split(splitstr, StringSplitOptions.None);
						string result = "";
						for(int ch = 0; ch < splitres.Length; ch++)
						{
							string str2 = splitres[ch];
							if(str2.StartsWith("/"))
							{
								str2 = str2.Remove(0, 1);
								result += str2;
							}
							else if(str2.StartsWith("$"))
							{
								string var = str2.Remove(0, 1);
								bool act = false;
								for(int ln = 0; ln < vars.Count; ln++)
								{
									if(vars[ln].StartsWith(var + "="))
									{
										result += vars[ln].Substring(vars[ln].IndexOf("=") + 1);
										act = true;
										break;
									}
								}
								if(!act)
								{
									result += "empty";
								}
							}
							else if(str2 == "time")
							{
								result += DateTime.Now.ToString("HH:mm:ss");
							}
							else if(str2 == "date")
							{
								result += DateTime.Now.ToString("dd.MM.yyyy");
							}
							else
							{
								result += str2;
							}
						}
						txt = result;
						if(actu == "=")
						{
							if(txt != "$stringempty")
							{
								if(vara == txt)
								{
									for(int ab = 0; ab < l.Length; ab++)
									{
										if(l[ab] == "[" + func + "]")
										{
											i = ab;
											break;
										}
									}
								}
							}
							else
							{
								if(string.IsNullOrEmpty(vara) || string.IsNullOrWhiteSpace(vara))
								{
									for(int ab = 0; ab < l.Length; ab++)
									{
										if(l[ab] == "[" + func + "]")
										{
											i = ab;
											break;
										}
									}
								}
							}
						}
						if(actu == ">")
						{
							double a = double.Parse(vara);
							double b = double.Parse(txt);
							if(a > b)
							{
								for(int ab = 0; ab < l.Length; ab++)
								{
									if(l[ab] == "[" + func + "]")
									{
										i = ab;
										break;
									}
								}
							}
						}
						if(actu == "<")
						{
							double a = double.Parse(vara);
							double b = double.Parse(txt);
							if(a < b)
							{
								for(int ab = 0; ab < l.Length; ab++)
								{
									if(l[ab] == "[" + func + "]")
									{
										i = ab;
										break;
									}
								}
							}
						}
						if(actu == "!")
						{
							if(txt != "$stringempty")
							{
								if(vara != txt)
								{
									for(int ab = 0; ab < l.Length; ab++)
									{
										if(l[ab] == "[" + func + "]")
										{
											i = ab;
											break;
										}
									}
								}
							}
							else
							{
								if(!string.IsNullOrEmpty(vara) || !string.IsNullOrWhiteSpace(vara))
								{
									for(int ab = 0; ab < l.Length; ab++)
									{
										if(l[ab] == "[" + func + "]")
										{
											i = ab;
											break;
										}
									}
								}
							}
						}
						if(actu == "?")
						{
							if(vara.Contains(txt))
							{
								for(int ab = 0; ab < l.Length; ab++)
								{
									if(l[ab] == "[" + func + "]")
									{
										i = ab;
										break;
									}
								}
							}
						}
						if(actu == "(")
						{
							if(vara.StartsWith(txt))
							{
								for(int ab = 0; ab < l.Length; ab++)
								{
									if(l[ab] == "[" + func + "]")
									{
										i = ab;
										break;
									}
								}
							}
						}
						if(actu == ")")
						{
							if(vara.EndsWith(txt))
							{
								for(int ab = 0; ab < l.Length; ab++)
								{
									if(l[ab] == "[" + func + "]")
									{
										i = ab;
										break;
									}
								}
							}
						}
					}
					else if(l[i].StartsWith("go "))
					{
						string func = l[i].Remove(0, 3);
						for(int ab = 0; ab < l.Length; ab++)
						{
							if(l[ab] == "[" + func + "]")
							{
								i = ab;
								break;
							}
						}
					}
					else if(l[i].StartsWith("math "))
					{
						string def = l[i].Remove(0, 5);
						string[] splita = { " " };
						string[] st = def.Split(splita, StringSplitOptions.None);
						string one = st[0];
						string actu = st[1];
						string two = st[2];
						string res = st[3];
						string[] splitstr = { "&&&" };
						string[] splitres = one.Split(splitstr, StringSplitOptions.None);
						string result = "";
						for(int ch = 0; ch < splitres.Length; ch++)
						{
							string str2 = splitres[ch];
							if(str2.StartsWith("/"))
							{
								str2 = str2.Remove(0, 1);
								result += str2;
							}
							else if(str2.StartsWith("$"))
							{
								string var = str2.Remove(0, 1);
								bool act = false;
								for(int ln = 0; ln < vars.Count; ln++)
								{
									if(vars[ln].StartsWith(var + "="))
									{
										result += vars[ln].Substring(vars[ln].IndexOf("=") + 1);
										act = true;
										break;
									}
								}
								if(!act)
								{
									result += "empty";
								}
							}
							else if(str2 == "time")
							{
								result += DateTime.Now.ToString("HH:mm:ss");
							}
							else if(str2 == "date")
							{
								result += DateTime.Now.ToString("dd.MM.yyyy");
							}
							else
							{
								result += str2;
							}
						}
						one = result;
						splitres = two.Split(splitstr, StringSplitOptions.None);
						result = "";
						for(int ch = 0; ch < splitres.Length; ch++)
						{
							string str2 = splitres[ch];
							if(str2.StartsWith("/"))
							{
								str2 = str2.Remove(0, 1);
								result += str2;
							}
							else if(str2.StartsWith("$"))
							{
								string var = str2.Remove(0, 1);
								bool act = false;
								for(int ln = 0; ln < vars.Count; ln++)
								{
									if(vars[ln].StartsWith(var + "="))
									{
										result += vars[ln].Substring(vars[ln].IndexOf("=") + 1);
										act = true;
										break;
									}
								}
								if(!act)
								{
									result += "empty";
								}
							}
							else if(str2 == "time")
							{
								result += DateTime.Now.ToString("HH:mm:ss");
							}
							else if(str2 == "date")
							{
								result += DateTime.Now.ToString("dd.MM.yyyy");
							}
							else
							{
								result += str2;
							}
						}
						two = result;
						if(actu == "+")
						{
							double a = double.Parse(one);
							double b = double.Parse(two);
							double resa = a + b;
							bool d = false;
							for (int ch = 0; ch < vars.Count; ch++)
		                    {
		                        if (vars[ch].StartsWith(res + "="))
		                        {
		                        	vars[ch] = res + "=" + resa;
		                        	d = true;
		                            break;
		                        }
		                    }
		                    if(!d)
		                    	vars.Add(res + "=" + resa);
						}
						else if(actu == "-")
						{
							double a = double.Parse(one);
							double b = double.Parse(two);
							double resa = a - b;
							bool d = false;
							for (int ch = 0; ch < vars.Count; ch++)
		                    {
		                        if (vars[ch].StartsWith(res + "="))
		                        {
		                        	vars[ch] = res + "=" + resa;
		                        	d = true;
		                            break;
		                        }
		                    }
		                    if(!d)
		                    	vars.Add(res + "=" + resa);
						}
						else if(actu == "*")
						{
							double a = double.Parse(one);
							double b = double.Parse(two);
							double resa = a * b;
							bool d = false;
							for (int ch = 0; ch < vars.Count; ch++)
		                    {
		                        if (vars[ch].StartsWith(res + "="))
		                        {
		                        	vars[ch] = res + "=" + resa;
		                        	d = true;
		                            break;
		                        }
		                    }
		                    if(!d)
		                    	vars.Add(res + "=" + resa);
						}
						else if(actu == "/")
						{
							double a = double.Parse(one);
							double b = double.Parse(two);
							double resa = a / b;
							bool d = false;
							for (int ch = 0; ch < vars.Count; ch++)
		                    {
		                        if (vars[ch].StartsWith(res + "="))
		                        {
		                        	vars[ch] = res + "=" + resa;
		                        	d = true;
		                            break;
		                        }
		                    }
		                    if(!d)
		                    	vars.Add(res + "=" + resa);
						}
						else if(actu == "%")
						{
							double a = double.Parse(one);
							double b = double.Parse(two);
							double resa = a % b;
							bool d = false;
							for (int ch = 0; ch < vars.Count; ch++)
		                    {
		                        if (vars[ch].StartsWith(res + "="))
		                        {
		                        	vars[ch] = res + "=" + resa;
		                        	d = true;
		                            break;
		                        }
		                    }
		                    if(!d)
		                    	vars.Add(res + "=" + resa);
						}
					}
					else if(l[i].StartsWith("start "))
					{
						string def = l[i].Remove(0, 6);
						string[] splita = { " " };
						string[] st = def.Split(splita, StringSplitOptions.None);
						string type = st[0];
						if(type == "default" || type == "admin")
						{
							string paths = st[1];
							string[] splitstr = { "&&&" };
							string[] splitres = paths.Split(splitstr, StringSplitOptions.None);
							string result = "";
							for(int ch = 0; ch < splitres.Length; ch++)
							{
								string str2 = splitres[ch];
								if(str2.StartsWith("/"))
								{
									str2 = str2.Remove(0, 1);
									result += str2;
								}
								else if(str2.StartsWith("$"))
								{
									string var = str2.Remove(0, 1);
									bool act = false;
									for(int ln = 0; ln < vars.Count; ln++)
									{
										if(vars[ln].StartsWith(var + "="))
										{
											result += vars[ln].Substring(vars[ln].IndexOf("=") + 1);
											act = true;
											break;
										}
									}
									if(!act)
									{
										result += "empty";
									}
								}
								else if(str2 == "time")
								{
									result += DateTime.Now.ToString("HH:mm:ss");
								}
								else if(str2 == "date")
							{
								result += DateTime.Now.ToString("dd.MM.yyyy");
							}
								else
								{
									result += str2;
								}
							}
							paths = result;
							if(type == "admin")
							{
								Process p = new Process();
								p.StartInfo.FileName = paths;
								p.StartInfo.UseShellExecute = true;
								p.Start();
							}
							else
							{
								Process p = new Process();
								p.StartInfo.FileName = paths;
								p.StartInfo.UseShellExecute = false;
								p.Start();
							}
						}
						else if(type == "args" || type == "argsadmin")
						{
							string paths = st[1];
							string arg = st[2];
							string[] splitstr = { "&&&" };
							string[] splitres = paths.Split(splitstr, StringSplitOptions.None);
							string result = "";
							for(int ch = 0; ch < splitres.Length; ch++)
							{
								string str2 = splitres[ch];
								if(str2.StartsWith("/"))
								{
									str2 = str2.Remove(0, 1);
									result += str2;
								}
								else if(str2.StartsWith("$"))
								{
									string var = str2.Remove(0, 1);
									bool act = false;
									for(int ln = 0; ln < vars.Count; ln++)
									{
										if(vars[ln].StartsWith(var + "="))
										{
											result += vars[ln].Substring(vars[ln].IndexOf("=") + 1);
											act = true;
											break;
										}
									}
									if(!act)
									{
										result += "empty";
									}
								}
								else if(str2 == "time")
								{
									result += DateTime.Now.ToString("HH:mm:ss");
								}
								else if(str2 == "date")
								{
									result += DateTime.Now.ToString("dd.MM.yyyy");
								}
								else
								{
									result += str2;
								}
							}
							paths = result;
							splitres = arg.Split(splitstr, StringSplitOptions.None);
							result = "";
							for(int ch = 0; ch < splitres.Length; ch++)
							{
								string str2 = splitres[ch];
								if(str2.StartsWith("/"))
								{
									str2 = str2.Remove(0, 1);
									result += str2;
								}
								else if(str2.StartsWith("$"))
								{
									string var = str2.Remove(0, 1);
									bool act = false;
									for(int ln = 0; ln < vars.Count; ln++)
									{
										if(vars[ln].StartsWith(var + "="))
										{
											result += vars[ln].Substring(vars[ln].IndexOf("=") + 1);
											act = true;
											break;
										}
									}
									if(!act)
									{
										result += "empty";
									}
								}
								else if(str2 == "time")
								{
									result += DateTime.Now.ToString("HH:mm:ss");
								}
								else if(str2 == "date")
								{
									result += DateTime.Now.ToString("dd.MM.yyyy");
								}
								else
								{
									result += str2;
								}
							}
							arg = result;
							if(type == "argsadmin")
							{
								Process p = new Process();
								p.StartInfo.FileName = paths;
								p.StartInfo.UseShellExecute = true;
								p.StartInfo.Arguments = arg;
								p.Start();
							}
							else
							{
								Process p = new Process();
								p.StartInfo.FileName = paths;
								p.StartInfo.UseShellExecute = false;
								p.StartInfo.Arguments = arg;
								p.Start();
							}
						}
					}
					else if(l[i].StartsWith("kill "))
					{
						string def = l[i].Remove(0, 5);
						string[] splitstr = { "&&&" };
						string[] splitres = def.Split(splitstr, StringSplitOptions.None);
						string result = "";
						for(int ch = 0; ch < splitres.Length; ch++)
						{
							string str2 = splitres[ch];
							if(str2.StartsWith("/"))
							{
								str2 = str2.Remove(0, 1);
								result += str2;
							}
							else if(str2.StartsWith("$"))
							{
								string var = str2.Remove(0, 1);
								bool act = false;
								for(int ln = 0; ln < vars.Count; ln++)
								{
									if(vars[ln].StartsWith(var + "="))
									{
										result += vars[ln].Substring(vars[ln].IndexOf("=") + 1);
										act = true;
										break;
									}
								}
								if(!act)
								{
									result += "empty";
								}
							}
							else if(str2 == "time")
							{
								result += DateTime.Now.ToString("HH:mm:ss");
							}
							else if(str2 == "date")
							{
								result += DateTime.Now.ToString("dd.MM.yyyy");
							}
							else
							{
								result += str2;
							}
						}
						def = result;
						Process[] ps = Process.GetProcessesByName(def);
						foreach(Process p in ps)
						{
							p.Kill();
						}
					}
					else if(l[i].StartsWith("wait "))
					{
						string def = l[i].Remove(0, 5);
						string type = def.Substring(0, def.IndexOf(" "));
						string val = def.Substring(def.IndexOf(" ") + 1);
						string[] splitstr = { "&&&" };
						string[] splitres = val.Split(splitstr, StringSplitOptions.None);
						string result = "";
						for(int ch = 0; ch < splitres.Length; ch++)
						{
							string str2 = splitres[ch];
							if(str2.StartsWith("/"))
							{
								str2 = str2.Remove(0, 1);
								result += str2;
							}
							else if(str2.StartsWith("$"))
							{
								string var = str2.Remove(0, 1);
								bool act = false;
								for(int ln = 0; ln < vars.Count; ln++)
								{
									if(vars[ln].StartsWith(var + "="))
									{
										result += vars[ln].Substring(vars[ln].IndexOf("=") + 1);
										act = true;
										break;
									}
								}
								if(!act)
								{
									result += "empty";
								}
							}
							else if(str2 == "time")
							{
								result += DateTime.Now.ToString("HH:mm:ss");
							}
							else if(str2 == "date")
							{
								result += DateTime.Now.ToString("dd.MM.yyyy");
							}
							else
							{
								result += str2;
							}
						}
						val = result;
						int it = int.Parse(val);
						if(type == "s")
						{
							Thread.Sleep(it * 1000);
						}
						else
						{
							Thread.Sleep(it);
						}
					}
					else if(l[i].StartsWith("crdir "))
					{
						string def = l[i].Remove(0, 6);
						string[] splitstr = { "&&&" };
						string[] splitres = def.Split(splitstr, StringSplitOptions.None);
						string result = "";
						for(int ch = 0; ch < splitres.Length; ch++)
						{
							string str2 = splitres[ch];
							if(str2.StartsWith("/"))
							{
								str2 = str2.Remove(0, 1);
								result += str2;
							}
							else if(str2.StartsWith("$"))
							{
								string var = str2.Remove(0, 1);
								bool act = false;
								for(int ln = 0; ln < vars.Count; ln++)
								{
									if(vars[ln].StartsWith(var + "="))
									{
										result += vars[ln].Substring(vars[ln].IndexOf("=") + 1);
										act = true;
										break;
									}
								}
								if(!act)
								{
									result += "empty";
								}
							}
							else if(str2 == "time")
							{
								result += DateTime.Now.ToString("HH:mm:ss");
							}
							else if(str2 == "date")
							{
								result += DateTime.Now.ToString("dd.MM.yyyy");
							}
							else
							{
								result += str2;
							}
						}
						def = result;
						Directory.CreateDirectory(def);
					}
					else if(l[i].StartsWith("rmdir "))
					{
						string def = l[i].Remove(0, 6);
						string[] splitstr = { "&&&" };
						string[] splitres = def.Split(splitstr, StringSplitOptions.None);
						string result = "";
						for(int ch = 0; ch < splitres.Length; ch++)
						{
							string str2 = splitres[ch];
							if(str2.StartsWith("/"))
							{
								str2 = str2.Remove(0, 1);
								result += str2;
							}
							else if(str2.StartsWith("$"))
							{
								string var = str2.Remove(0, 1);
								bool act = false;
								for(int ln = 0; ln < vars.Count; ln++)
								{
									if(vars[ln].StartsWith(var + "="))
									{
										result += vars[ln].Substring(vars[ln].IndexOf("=") + 1);
										act = true;
										break;
									}
								}
								if(!act)
								{
									result += "empty";
								}
							}
							else if(str2 == "time")
							{
								result += DateTime.Now.ToString("HH:mm:ss");
							}
							else if(str2 == "date")
							{
								result += DateTime.Now.ToString("dd.MM.yyyy");
							}
							else
							{
								result += str2;
							}
						}
						def = result;
						if(Directory.Exists(def))
							Directory.Delete(def, true);
					}
					else if(l[i].StartsWith("crfile "))
					{
						string def = l[i].Remove(0, 7);
						string[] splitstr = { "&&&" };
						string[] splitres = def.Split(splitstr, StringSplitOptions.None);
						string result = "";
						for(int ch = 0; ch < splitres.Length; ch++)
						{
							string str2 = splitres[ch];
							if(str2.StartsWith("/"))
							{
								str2 = str2.Remove(0, 1);
								result += str2;
							}
							else if(str2.StartsWith("$"))
							{
								string var = str2.Remove(0, 1);
								bool act = false;
								for(int ln = 0; ln < vars.Count; ln++)
								{
									if(vars[ln].StartsWith(var + "="))
									{
										result += vars[ln].Substring(vars[ln].IndexOf("=") + 1);
										act = true;
										break;
									}
								}
								if(!act)
								{
									result += "empty";
								}
							}
							else if(str2 == "time")
							{
								result += DateTime.Now.ToString("HH:mm:ss");
							}
							else if(str2 == "date")
							{
								result += DateTime.Now.ToString("dd.MM.yyyy");
							}
							else
							{
								result += str2;
							}
						}
						def = result;
						File.WriteAllText(def, "");
					}
					else if(l[i].StartsWith("rmfile "))
					{
						string def = l[i].Remove(0, 7);
						string[] splitstr = { "&&&" };
						string[] splitres = def.Split(splitstr, StringSplitOptions.None);
						string result = "";
						for(int ch = 0; ch < splitres.Length; ch++)
						{
							string str2 = splitres[ch];
							if(str2.StartsWith("/"))
							{
								str2 = str2.Remove(0, 1);
								result += str2;
							}
							else if(str2.StartsWith("$"))
							{
								string var = str2.Remove(0, 1);
								bool act = false;
								for(int ln = 0; ln < vars.Count; ln++)
								{
									if(vars[ln].StartsWith(var + "="))
									{
										result += vars[ln].Substring(vars[ln].IndexOf("=") + 1);
										act = true;
										break;
									}
								}
								if(!act)
								{
									result += "empty";
								}
							}
							else if(str2 == "time")
							{
								result += DateTime.Now.ToString("HH:mm:ss");
							}
							else if(str2 == "date")
							{
								result += DateTime.Now.ToString("dd.MM.yyyy");
							}
							else
							{
								result += str2;
							}
						}
						def = result;
						if(File.Exists(def))
							File.Delete(def);
					}
					else if(l[i].StartsWith("movedir "))
					{
						string def = l[i].Remove(0, 8);
						string froma = def.Substring(0, def.IndexOf(" "));
						string toa = def.Substring(def.IndexOf(" ") + 1);
						string[] splitstr = { "&&&" };
						string[] splitres = froma.Split(splitstr, StringSplitOptions.None);
						string result = "";
						for(int ch = 0; ch < splitres.Length; ch++)
						{
							string str2 = splitres[ch];
							if(str2.StartsWith("/"))
							{
								str2 = str2.Remove(0, 1);
								result += str2;
							}
							else if(str2.StartsWith("$"))
							{
								string var = str2.Remove(0, 1);
								bool act = false;
								for(int ln = 0; ln < vars.Count; ln++)
								{
									if(vars[ln].StartsWith(var + "="))
									{
										result += vars[ln].Substring(vars[ln].IndexOf("=") + 1);
										act = true;
										break;
									}
								}
								if(!act)
								{
									result += "empty";
								}
							}
							else if(str2 == "time")
							{
								result += DateTime.Now.ToString("HH:mm:ss");
							}
							else if(str2 == "date")
							{
								result += DateTime.Now.ToString("dd.MM.yyyy");
							}
							else
							{
								result += str2;
							}
						}
						froma = result;
						splitres = toa.Split(splitstr, StringSplitOptions.None);
						result = "";
						for(int ch = 0; ch < splitres.Length; ch++)
						{
							string str2 = splitres[ch];
							if(str2.StartsWith("/"))
							{
								str2 = str2.Remove(0, 1);
								result += str2;
							}
							else if(str2.StartsWith("$"))
							{
								string var = str2.Remove(0, 1);
								bool act = false;
								for(int ln = 0; ln < vars.Count; ln++)
								{
									if(vars[ln].StartsWith(var + "="))
									{
										result += vars[ln].Substring(vars[ln].IndexOf("=") + 1);
										act = true;
										break;
									}
								}
								if(!act)
								{
									result += "empty";
								}
							}
							else if(str2 == "time")
							{
								result += DateTime.Now.ToString("HH:mm:ss");
							}
							else if(str2 == "date")
							{
								result += DateTime.Now.ToString("dd.MM.yyyy");
							}
							else
							{
								result += str2;
							}
						}
						toa = result;
						Directory.Move(froma, toa);
					}
					else if(l[i].StartsWith("movefile "))
					{
						string def = l[i].Remove(0, 9);
						string froma = def.Substring(0, def.IndexOf(" "));
						string toa = def.Substring(def.IndexOf(" ") + 1);
						string[] splitstr = { "&&&" };
						string[] splitres = froma.Split(splitstr, StringSplitOptions.None);
						string result = "";
						for(int ch = 0; ch < splitres.Length; ch++)
						{
							string str2 = splitres[ch];
							if(str2.StartsWith("/"))
							{
								str2 = str2.Remove(0, 1);
								result += str2;
							}
							else if(str2.StartsWith("$"))
							{
								string var = str2.Remove(0, 1);
								bool act = false;
								for(int ln = 0; ln < vars.Count; ln++)
								{
									if(vars[ln].StartsWith(var + "="))
									{
										result += vars[ln].Substring(vars[ln].IndexOf("=") + 1);
										act = true;
										break;
									}
								}
								if(!act)
								{
									result += "empty";
								}
							}
							else if(str2 == "time")
							{
								result += DateTime.Now.ToString("HH:mm:ss");
							}
							else if(str2 == "date")
							{
								result += DateTime.Now.ToString("dd.MM.yyyy");
							}
							else
							{
								result += str2;
							}
						}
						froma = result;
						splitres = toa.Split(splitstr, StringSplitOptions.None);
						result = "";
						for(int ch = 0; ch < splitres.Length; ch++)
						{
							string str2 = splitres[ch];
							if(str2.StartsWith("/"))
							{
								str2 = str2.Remove(0, 1);
								result += str2;
							}
							else if(str2.StartsWith("$"))
							{
								string var = str2.Remove(0, 1);
								bool act = false;
								for(int ln = 0; ln < vars.Count; ln++)
								{
									if(vars[ln].StartsWith(var + "="))
									{
										result += vars[ln].Substring(vars[ln].IndexOf("=") + 1);
										act = true;
										break;
									}
								}
								if(!act)
								{
									result += "empty";
								}
							}
							else if(str2 == "time")
							{
								result += DateTime.Now.ToString("HH:mm:ss");
							}
							else if(str2 == "date")
							{
								result += DateTime.Now.ToString("dd.MM.yyyy");
							}
							else
							{
								result += str2;
							}
						}
						toa = result;
						File.Move(froma, toa);
					}
					else if(l[i].StartsWith("copyfile "))
					{
						string def = l[i].Remove(0, 9);
						string froma = def.Substring(0, def.IndexOf(" "));
						string toa = def.Substring(def.IndexOf(" ") + 1);
						string[] splitstr = { "&&&" };
						string[] splitres = froma.Split(splitstr, StringSplitOptions.None);
						string result = "";
						for(int ch = 0; ch < splitres.Length; ch++)
						{
							string str2 = splitres[ch];
							if(str2.StartsWith("/"))
							{
								str2 = str2.Remove(0, 1);
								result += str2;
							}
							else if(str2.StartsWith("$"))
							{
								string var = str2.Remove(0, 1);
								bool act = false;
								for(int ln = 0; ln < vars.Count; ln++)
								{
									if(vars[ln].StartsWith(var + "="))
									{
										result += vars[ln].Substring(vars[ln].IndexOf("=") + 1);
										act = true;
										break;
									}
								}
								if(!act)
								{
									result += "empty";
								}
							}
							else if(str2 == "time")
							{
								result += DateTime.Now.ToString("HH:mm:ss");
							}
							else if(str2 == "date")
							{
								result += DateTime.Now.ToString("dd.MM.yyyy");
							}
							else
							{
								result += str2;
							}
						}
						froma = result;
						splitres = toa.Split(splitstr, StringSplitOptions.None);
						result = "";
						for(int ch = 0; ch < splitres.Length; ch++)
						{
							string str2 = splitres[ch];
							if(str2.StartsWith("/"))
							{
								str2 = str2.Remove(0, 1);
								result += str2;
							}
							else if(str2.StartsWith("$"))
							{
								string var = str2.Remove(0, 1);
								bool act = false;
								for(int ln = 0; ln < vars.Count; ln++)
								{
									if(vars[ln].StartsWith(var + "="))
									{
										result += vars[ln].Substring(vars[ln].IndexOf("=") + 1);
										act = true;
										break;
									}
								}
								if(!act)
								{
									result += "empty";
								}
							}
							else if(str2 == "time")
							{
								result += DateTime.Now.ToString("HH:mm:ss");
							}
							else if(str2 == "date")
							{
								result += DateTime.Now.ToString("dd.MM.yyyy");
							}
							else
							{
								result += str2;
							}
						}
						toa = result;
						File.Copy(froma, toa);
					}
					else if(l[i].StartsWith("readfile "))
					{
						string def = l[i].Remove(0, 9);
						string[] splitstra = { " " };
						string[] splitresa = def.Split(splitstra, StringSplitOptions.None);
						string paths = splitresa[0];
						string line = splitresa[1];
						string var1 = splitresa[2];
						string[] splitstr = { "&&&" };
						string[] splitres = paths.Split(splitstr, StringSplitOptions.None);
						string result = "";
						for(int ch = 0; ch < splitres.Length; ch++)
						{
							string str2 = splitres[ch];
							if(str2.StartsWith("/"))
							{
								str2 = str2.Remove(0, 1);
								result += str2;
							}
							else if(str2.StartsWith("$"))
							{
								string var = str2.Remove(0, 1);
								bool act = false;
								for(int ln = 0; ln < vars.Count; ln++)
								{
									if(vars[ln].StartsWith(var + "="))
									{
										result += vars[ln].Substring(vars[ln].IndexOf("=") + 1);
										act = true;
										break;
									}
								}
								if(!act)
								{
									result += "empty";
								}
							}
							else if(str2 == "time")
							{
								result += DateTime.Now.ToString("HH:mm:ss");
							}
							else if(str2 == "date")
							{
								result += DateTime.Now.ToString("dd.MM.yyyy");
							}
							else
							{
								result += str2;
							}
						}
						paths = result;
						splitres = line.Split(splitstr, StringSplitOptions.None);
						result = "";
						for(int ch = 0; ch < splitres.Length; ch++)
						{
							string str2 = splitres[ch];
							if(str2.StartsWith("/"))
							{
								str2 = str2.Remove(0, 1);
								result += str2;
							}
							else if(str2.StartsWith("$"))
							{
								string var = str2.Remove(0, 1);
								bool act = false;
								for(int ln = 0; ln < vars.Count; ln++)
								{
									if(vars[ln].StartsWith(var + "="))
									{
										result += vars[ln].Substring(vars[ln].IndexOf("=") + 1);
										act = true;
										break;
									}
								}
								if(!act)
								{
									result += "empty";
								}
							}
							else if(str2 == "time")
							{
								result += DateTime.Now.ToString("HH:mm:ss");
							}
							else if(str2 == "date")
							{
								result += DateTime.Now.ToString("dd.MM.yyyy");
							}
							else
							{
								result += str2;
							}
						}
						line = result;
						if(File.Exists(paths))
						{
							int ln = int.Parse(line);
							string[] filsa = File.ReadAllLines(paths);
							string va = filsa[ln];
							bool d = false;
							for (int ch = 0; ch < vars.Count; ch++)
		                    {
		                        if (vars[ch].StartsWith(var1 + "="))
		                        {
		                        	vars[ch] = var1 + "=" + va;
		                        	d = true;
		                            break;
		                        }
		                    }
		                    if(!d)
		                    	vars.Add(var1 + "=" + va);
						}
					}
					else if(l[i].StartsWith("writefile "))
					{
						string def = l[i].Remove(0, 10);
						string[] splitstra = { " " };
						string[] splitresa = def.Split(splitstra, StringSplitOptions.None);
						string paths = splitresa[0];
						string text = splitresa[1];
						string line = splitresa[2];
						string[] splitstr = { "&&&" };
						string[] splitres = paths.Split(splitstr, StringSplitOptions.None);
						string result = "";
						for(int ch = 0; ch < splitres.Length; ch++)
						{
							string str2 = splitres[ch];
							if(str2.StartsWith("/"))
							{
								str2 = str2.Remove(0, 1);
								result += str2;
							}
							else if(str2.StartsWith("$"))
							{
								string var = str2.Remove(0, 1);
								bool act = false;
								for(int ln = 0; ln < vars.Count; ln++)
								{
									if(vars[ln].StartsWith(var + "="))
									{
										result += vars[ln].Substring(vars[ln].IndexOf("=") + 1);
										act = true;
										break;
									}
								}
								if(!act)
								{
									result += "empty";
								}
							}
							else if(str2 == "time")
							{
								result += DateTime.Now.ToString("HH:mm:ss");
							}
							else if(str2 == "date")
							{
								result += DateTime.Now.ToString("dd.MM.yyyy");
							}
							else
							{
								result += str2;
							}
						}
						paths = result;
						splitres = line.Split(splitstr, StringSplitOptions.None);
						result = "";
						for(int ch = 0; ch < splitres.Length; ch++)
						{
							string str2 = splitres[ch];
							if(str2.StartsWith("/"))
							{
								str2 = str2.Remove(0, 1);
								result += str2;
							}
							else if(str2.StartsWith("$"))
							{
								string var = str2.Remove(0, 1);
								bool act = false;
								for(int ln = 0; ln < vars.Count; ln++)
								{
									if(vars[ln].StartsWith(var + "="))
									{
										result += vars[ln].Substring(vars[ln].IndexOf("=") + 1);
										act = true;
										break;
									}
								}
								if(!act)
								{
									result += "empty";
								}
							}
							else if(str2 == "time")
							{
								result += DateTime.Now.ToString("HH:mm:ss");
							}
							else if(str2 == "date")
							{
								result += DateTime.Now.ToString("dd.MM.yyyy");
							}
							else
							{
								result += str2;
							}
						}
						line = result;
						splitres = text.Split(splitstr, StringSplitOptions.None);
						result = "";
						for(int ch = 0; ch < splitres.Length; ch++)
						{
							string str2 = splitres[ch];
							if(str2.StartsWith("/"))
							{
								str2 = str2.Remove(0, 1);
								result += str2;
							}
							else if(str2.StartsWith("$"))
							{
								string var = str2.Remove(0, 1);
								bool act = false;
								for(int ln = 0; ln < vars.Count; ln++)
								{
									if(vars[ln].StartsWith(var + "="))
									{
										result += vars[ln].Substring(vars[ln].IndexOf("=") + 1);
										act = true;
										break;
									}
								}
								if(!act)
								{
									result += "empty";
								}
							}
							else if(str2 == "time")
							{
								result += DateTime.Now.ToString("HH:mm:ss");
							}
							else if(str2 == "date")
							{
								result += DateTime.Now.ToString("dd.MM.yyyy");
							}
							else
							{
								result += str2;
							}
						}
						text = result;
						if(File.Exists(paths))
						{
							int ln = int.Parse(line);
							if(ln != -1)
							{
								string[] filsa = File.ReadAllLines(paths);
								filsa[ln] = text;
								File.WriteAllLines(paths, filsa);
							}
							else
							{
								File.WriteAllText(paths, text);
							}
						}
					}
					else if(l[i].StartsWith("addfile "))
					{
						string def = l[i].Remove(0, 8);
						string[] splitstra = { " " };
						string[] splitresa = def.Split(splitstra, StringSplitOptions.None);
						string paths = splitresa[0];
						string text = splitresa[1];
						string[] splitstr = { "&&&" };
						string[] splitres = paths.Split(splitstr, StringSplitOptions.None);
						string result = "";
						for(int ch = 0; ch < splitres.Length; ch++)
						{
							string str2 = splitres[ch];
							if(str2.StartsWith("/"))
							{
								str2 = str2.Remove(0, 1);
								result += str2;
							}
							else if(str2.StartsWith("$"))
							{
								string var = str2.Remove(0, 1);
								bool act = false;
								for(int ln = 0; ln < vars.Count; ln++)
								{
									if(vars[ln].StartsWith(var + "="))
									{
										result += vars[ln].Substring(vars[ln].IndexOf("=") + 1);
										act = true;
										break;
									}
								}
								if(!act)
								{
									result += "empty";
								}
							}
							else if(str2 == "time")
							{
								result += DateTime.Now.ToString("HH:mm:ss");
							}
							else if(str2 == "date")
							{
								result += DateTime.Now.ToString("dd.MM.yyyy");
							}
							else
							{
								result += str2;
							}
						}
						paths = result;
						splitres = text.Split(splitstr, StringSplitOptions.None);
						result = "";
						for(int ch = 0; ch < splitres.Length; ch++)
						{
							string str2 = splitres[ch];
							if(str2.StartsWith("/"))
							{
								str2 = str2.Remove(0, 1);
								result += str2;
							}
							else if(str2.StartsWith("$"))
							{
								string var = str2.Remove(0, 1);
								bool act = false;
								for(int ln = 0; ln < vars.Count; ln++)
								{
									if(vars[ln].StartsWith(var + "="))
									{
										result += vars[ln].Substring(vars[ln].IndexOf("=") + 1);
										act = true;
										break;
									}
								}
								if(!act)
								{
									result += "empty";
								}
							}
							else if(str2 == "time")
							{
								result += DateTime.Now.ToString("HH:mm:ss");
							}
							else if(str2 == "date")
							{
								result += DateTime.Now.ToString("dd.MM.yyyy");
							}
							else
							{
								result += str2;
							}
						}
						text = result;
						if(File.Exists(paths))
						{
							File.AppendAllText(paths, Environment.NewLine + text);
						}
					}
					else if (l[i].StartsWith("removechars "))
	                {
	                	string ofas3 = l[i].Remove(0, 12);
	                	string strt = ofas3.Substring(0, ofas3.IndexOf(" "));
	                	string ana = ofas3.Substring(ofas3.IndexOf(" ") + 1);
	                	string valuef = ana.Substring(0, ana.IndexOf("="));
	                	string varvf = ana.Substring(ana.IndexOf("=") + 1);
	                	string[] splitstring = { "&&&" };
	                    string[] ofas2 = valuef.Split(splitstring, StringSplitOptions.None);
	                    string result = "";
	                    for(int ch = 0; ch < ofas2.Length; ch++)
						{
							string str2 = ofas2[ch];
							if(str2.StartsWith("/"))
							{
								str2 = str2.Remove(0, 1);
								result += str2;
							}
							else if(str2.StartsWith("$"))
							{
								string var = str2.Remove(0, 1);
								bool act = false;
								for(int ln = 0; ln < vars.Count; ln++)
								{
									if(vars[ln].StartsWith(var + "="))
									{
										result += vars[ln].Substring(vars[ln].IndexOf("=") + 1);
										act = true;
										break;
									}
								}
								if(!act)
								{
									result += "empty";
								}
							}
							else if(str2 == "time")
							{
								result += DateTime.Now.ToString("HH:mm:ss");
							}
							else if(str2 == "date")
							{
								result += DateTime.Now.ToString("dd.MM.yyyy");
							}
							else
							{
								result += str2;
							}
						}
	                    string da = result;
	                    ofas2 = strt.Split(splitstring, StringSplitOptions.None);
	                    result = "";
	                    for(int ch = 0; ch < ofas2.Length; ch++)
						{
							string str2 = ofas2[ch];
							if(str2.StartsWith("/"))
							{
								str2 = str2.Remove(0, 1);
								result += str2;
							}
							else if(str2.StartsWith("$"))
							{
								string var = str2.Remove(0, 1);
								bool act = false;
								for(int ln = 0; ln < vars.Count; ln++)
								{
									if(vars[ln].StartsWith(var + "="))
									{
										result += vars[ln].Substring(vars[ln].IndexOf("=") + 1);
										act = true;
										break;
									}
								}
								if(!act)
								{
									result += "empty";
								}
							}
							else if(str2 == "time")
							{
								result += DateTime.Now.ToString("HH:mm:ss");
							}
							else if(str2 == "date")
							{
								result += DateTime.Now.ToString("dd.MM.yyyy");
							}
							else
							{
								result += str2;
							}
						}
	                    string fa = result;
	                    string va = "";
	                    bool abs = false;
	                    for (int ch = 0; ch < vars.Count; ch++)
	                    {
	                        if (vars[ch].StartsWith(varvf + "="))
	                        {
	                            string txt2 = vars[ch].Substring(vars[ch].IndexOf("=") + 1);
	                            va = txt2;
	                            abs = true;
	                            break;
	                        }
	                    }
	                    if (abs == false)
	                    {
	                    	va = "null";
	                    }
	                    try
	                    {
	                    	int chfr = Convert.ToInt32(da);
	                    	int chfr2 = Convert.ToInt32(fa);
	                    	va = va.Remove(chfr2, chfr);
		                    bool d = false;
		                    for (int ch = 0; ch < vars.Count; ch++)
		                    {
		                        if (vars[ch].StartsWith(varvf + "="))
		                        {
		                        	vars[ch] = varvf + "=" + va;
		                        	d = true;
		                            break;
		                        }
		                        
		                    }
		                    if(!d)
		                    {
		                    	vars.Add(varvf + "=" + va);
		                    }
	                    }
	                    catch
	                    {
	                    	
	                    }
	                }
					else if (l[i].StartsWith("substring "))
	                {
	                	string ofas3 = l[i].Remove(0, 10);
	                	string strt = ofas3.Substring(0, ofas3.IndexOf(" "));
	                	string ana = ofas3.Substring(ofas3.IndexOf(" ") + 1);
	                	string valuef = ana.Substring(0, ana.IndexOf("="));
	                	string varvf = ana.Substring(ana.IndexOf("=") + 1);
	                	string[] splitstring = { "&&&" };
	                    string[] ofas2 = valuef.Split(splitstring, StringSplitOptions.None);
	                    string result = "";
	                    for(int ch = 0; ch < ofas2.Length; ch++)
						{
							string str2 = ofas2[ch];
							if(str2.StartsWith("/"))
							{
								str2 = str2.Remove(0, 1);
								result += str2;
							}
							else if(str2.StartsWith("$"))
							{
								string var = str2.Remove(0, 1);
								bool act = false;
								for(int ln = 0; ln < vars.Count; ln++)
								{
									if(vars[ln].StartsWith(var + "="))
									{
										result += vars[ln].Substring(vars[ln].IndexOf("=") + 1);
										act = true;
										break;
									}
								}
								if(!act)
								{
									result += "empty";
								}
							}
							else if(str2 == "time")
							{
								result += DateTime.Now.ToString("HH:mm:ss");
							}
							else if(str2 == "date")
							{
								result += DateTime.Now.ToString("dd.MM.yyyy");
							}
							else
							{
								result += str2;
							}
						}
	                    string da = result;
	                    ofas2 = strt.Split(splitstring, StringSplitOptions.None);
	                    result = "";
	                    for(int ch = 0; ch < ofas2.Length; ch++)
						{
							string str2 = ofas2[ch];
							if(str2.StartsWith("/"))
							{
								str2 = str2.Remove(0, 1);
								result += str2;
							}
							else if(str2.StartsWith("$"))
							{
								string var = str2.Remove(0, 1);
								bool act = false;
								for(int ln = 0; ln < vars.Count; ln++)
								{
									if(vars[ln].StartsWith(var + "="))
									{
										result += vars[ln].Substring(vars[ln].IndexOf("=") + 1);
										act = true;
										break;
									}
								}
								if(!act)
								{
									result += "empty";
								}
							}
							else if(str2 == "time")
							{
								result += DateTime.Now.ToString("HH:mm:ss");
							}
							else if(str2 == "date")
							{
								result += DateTime.Now.ToString("dd.MM.yyyy");
							}
							else
							{
								result += str2;
							}
						}
	                    string fa = result;
	                    string va = "";
	                    bool abs = false;
	                    for (int ch = 0; ch < vars.Count; ch++)
	                    {
	                        if (vars[ch].StartsWith(varvf + "="))
	                        {
	                            string txt2 = vars[ch].Substring(vars[ch].IndexOf("=") + 1);
	                            va = txt2;
	                            abs = true;
	                            break;
	                        }
	                    }
	                    if (abs == false)
	                    {
	                    	va = "null";
	                    }
	                    try
	                    {
	                    	int chfr = Convert.ToInt32(da);
	                    	int chfr2 = Convert.ToInt32(fa);
	                    	va = va.Substring(chfr2, chfr);
		                    bool d = false;
		                    for (int ch = 0; ch < vars.Count; ch++)
		                    {
		                        if (vars[ch].StartsWith(varvf + "="))
		                        {
		                        	vars[ch] = varvf + "=" + va;
		                        	d = true;
		                            break;
		                        }
		                        
		                    }
		                    if(!d)
		                    {
		                    	vars.Add(varvf + "=" + va);
		                    }
	                    }
	                    catch
	                    {
	                    	
	                    }
	                }
					else if (l[i].StartsWith("//"))
	                {
	                	//
	                	//
	                }
					else if (l[i].StartsWith("exists "))
	                {
	                	string ofas3 = l[i].Remove(0, 7);
	                	string type = ofas3.Substring(0, ofas3.IndexOf(" "));
	                	string ana = ofas3.Substring(ofas3.IndexOf(" ") + 1);
	                	string paths = ana.Substring(0, ana.IndexOf("="));
	                	string varvf = ana.Substring(ana.IndexOf("=") + 1);
	                	string[] splitstring = { "&&&" };
	                    string[] ofas2 = paths.Split(splitstring, StringSplitOptions.None);
	                    string result = "";
	                    for(int ch = 0; ch < ofas2.Length; ch++)
						{
							string str2 = ofas2[ch];
							if(str2.StartsWith("/"))
							{
								str2 = str2.Remove(0, 1);
								result += str2;
							}
							else if(str2.StartsWith("$"))
							{
								string var = str2.Remove(0, 1);
								bool act = false;
								for(int ln = 0; ln < vars.Count; ln++)
								{
									if(vars[ln].StartsWith(var + "="))
									{
										result += vars[ln].Substring(vars[ln].IndexOf("=") + 1);
										act = true;
										break;
									}
								}
								if(!act)
								{
									result += "empty";
								}
							}
							else if(str2 == "time")
							{
								result += DateTime.Now.ToString("HH:mm:ss");
							}
							else if(str2 == "date")
							{
								result += DateTime.Now.ToString("dd.MM.yyyy");
							}
							else
							{
								result += str2;
							}
						}
	                    string da = result;
	                    string va = "false";
	                    try
	                    {
	                    	if(type == "file")
	                    	{
	                    		if(File.Exists(paths))
	                    		{
	                    			va = "true";
	                    		}
	                    		bool d = false;
			                    for (int ch = 0; ch < vars.Count; ch++)
			                    {
			                        if (vars[ch].StartsWith(varvf + "="))
			                        {
			                        	vars[ch] = varvf + "=" + va;
			                        	d = true;
			                            break;
			                        }
			                        
			                    }
			                    if(!d)
			                    {
			                    	vars.Add(varvf + "=" + va);
			                    }
		                    }
	                    	if(type == "dir")
	                    	{
	                    		if(Directory.Exists(paths))
	                    		{
	                    			va = "true";
	                    		}
	                    		bool d = false;
			                    for (int ch = 0; ch < vars.Count; ch++)
			                    {
			                        if (vars[ch].StartsWith(varvf + "="))
			                        {
			                        	vars[ch] = varvf + "=" + va;
			                        	d = true;
			                            break;
			                        }
			                        
			                    }
			                    if(!d)
			                    {
			                    	vars.Add(varvf + "=" + va);
			                    }
		                    }
	                    }
	                    catch
	                    {
	                    	
	                    }
	                }
					else if(l[i].StartsWith("lineslength "))
					{
						string def = l[i].Remove(0, 12);
						string file = def.Substring(0, def.IndexOf(" "));
						string var1 = def.Substring(def.IndexOf(" ") + 1);
						string[] splitstr = { "&&&" };
						string[] splitres = file.Split(splitstr, StringSplitOptions.None);
						string result = "";
						for(int ch = 0; ch < splitres.Length; ch++)
						{
							string str2 = splitres[ch];
							if(str2.StartsWith("/"))
							{
								str2 = str2.Remove(0, 1);
								result += str2;
							}
							else if(str2.StartsWith("$"))
							{
								string var = str2.Remove(0, 1);
								bool act = false;
								for(int ln = 0; ln < vars.Count; ln++)
								{
									if(vars[ln].StartsWith(var + "="))
									{
										result += vars[ln].Substring(vars[ln].IndexOf("=") + 1);
										act = true;
										break;
									}
								}
								if(!act)
								{
									result += "empty";
								}
							}
							else if(str2 == "time")
							{
								result += DateTime.Now.ToString("HH:mm:ss");
							}
							else if(str2 == "date")
							{
								result += DateTime.Now.ToString("dd.MM.yyyy");
							}
							else
							{
								result += str2;
							}
						}
						file = result;
						if(File.Exists(file))
						{
							string[] fa = File.ReadAllLines(file);
							bool d = false;
							for (int ch = 0; ch < vars.Count; ch++)
		                    {
		                        if (vars[ch].StartsWith(var1 + "="))
		                        {
		                        	vars[ch] = var1 + "=" + fa.Length;
		                        	d = true;
		                            break;
		                        }
		                    }
		                    if(!d)
		                    	vars.Add(var1 + "=" + fa.Length);
						}
					}
					else if(l[i].StartsWith("stringlength "))
					{
						string def = l[i].Remove(0, 13);
						string str = def.Substring(0, def.IndexOf(" "));
						string var1 = def.Substring(def.IndexOf(" ") + 1);
						string[] splitstr = { "&&&" };
						string[] splitres = str.Split(splitstr, StringSplitOptions.None);
						string result = "";
						for(int ch = 0; ch < splitres.Length; ch++)
						{
							string str2 = splitres[ch];
							if(str2.StartsWith("/"))
							{
								str2 = str2.Remove(0, 1);
								result += str2;
							}
							else if(str2.StartsWith("$"))
							{
								string var = str2.Remove(0, 1);
								bool act = false;
								for(int ln = 0; ln < vars.Count; ln++)
								{
									if(vars[ln].StartsWith(var + "="))
									{
										result += vars[ln].Substring(vars[ln].IndexOf("=") + 1);
										act = true;
										break;
									}
								}
								if(!act)
								{
									result += "empty";
								}
							}
							else if(str2 == "time")
							{
								result += DateTime.Now.ToString("HH:mm:ss");
							}
							else if(str2 == "date")
							{
								result += DateTime.Now.ToString("dd.MM.yyyy");
							}
							else
							{
								result += str2;
							}
						}
						str = result;
						bool d = false;
						for (int ch = 0; ch < vars.Count; ch++)
	                    {
	                        if (vars[ch].StartsWith(var1 + "="))
	                        {
	                        	vars[ch] = var1 + "=" + str.Length;
	                        	d = true;
	                            break;
	                        }
	                    }
	                    if(!d)
	                    	vars.Add(var1 + "=" + str.Length);
					}
					else if(l[i].StartsWith("screenshot "))
					{
						string pathe = l[i].Remove(0, 11);
						string[] splitstr = { "&&&" };
						string[] splitres = pathe.Split(splitstr, StringSplitOptions.None);
						string result = "";
						for(int ch = 0; ch < splitres.Length; ch++)
						{
							string str2 = splitres[ch];
							if(str2.StartsWith("/"))
							{
								str2 = str2.Remove(0, 1);
								result += str2;
							}
							else if(str2.StartsWith("$"))
							{
								string var = str2.Remove(0, 1);
								bool act = false;
								for(int ln = 0; ln < vars.Count; ln++)
								{
									if(vars[ln].StartsWith(var + "="))
									{
										result += vars[ln].Substring(vars[ln].IndexOf("=") + 1);
										act = true;
										break;
									}
								}
								if(!act)
								{
									result += "empty";
								}
							}
							else if(str2 == "time")
							{
								result += DateTime.Now.ToString("HH:mm:ss");
							}
							else if(str2 == "date")
							{
								result += DateTime.Now.ToString("dd.MM.yyyy");
							}
							else
							{
								result += str2;
							}
						}
						pathe = result;
	                    Bitmap printscreen = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
 						Graphics graphics = Graphics.FromImage(printscreen as Image);
 						graphics.CopyFromScreen(0, 0, 0, 0, printscreen.Size);
 						printscreen.Save(pathe, System.Drawing.Imaging.ImageFormat.Png);
					}
					else if (l[i].StartsWith("download "))
	                {
	                    string ofas3 = l[i].Remove(0, 9);
	                    string froms = ofas3.Substring(0, ofas3.IndexOf(" "));
	                    string tos = ofas3.Substring(ofas3.IndexOf(" ") + 1);
	                    string[] splitstr = { "&&&" };
						string[] splitres = froms.Split(splitstr, StringSplitOptions.None);
						string result = "";
						for(int ch = 0; ch < splitres.Length; ch++)
						{
							string str2 = splitres[ch];
							if(str2.StartsWith("/"))
							{
								str2 = str2.Remove(0, 1);
								result += str2;
							}
							else if(str2.StartsWith("$"))
							{
								string var = str2.Remove(0, 1);
								bool act = false;
								for(int ln = 0; ln < vars.Count; ln++)
								{
									if(vars[ln].StartsWith(var + "="))
									{
										result += vars[ln].Substring(vars[ln].IndexOf("=") + 1);
										act = true;
										break;
									}
								}
								if(!act)
								{
									result += "empty";
								}
							}
							else if(str2 == "time")
							{
								result += DateTime.Now.ToString("HH:mm:ss");
							}
							else if(str2 == "date")
							{
								result += DateTime.Now.ToString("dd.MM.yyyy");
							}
							else
							{
								result += str2;
							}
						}
	                    froms = result;
	                    splitres = tos.Split(splitstr, StringSplitOptions.None);
	                    result = "";
	                    for(int ch = 0; ch < splitres.Length; ch++)
						{
							string str2 = splitres[ch];
							if(str2.StartsWith("/"))
							{
								str2 = str2.Remove(0, 1);
								result += str2;
							}
							else if(str2.StartsWith("$"))
							{
								string var = str2.Remove(0, 1);
								bool act = false;
								for(int ln = 0; ln < vars.Count; ln++)
								{
									if(vars[ln].StartsWith(var + "="))
									{
										result += vars[ln].Substring(vars[ln].IndexOf("=") + 1);
										act = true;
										break;
									}
								}
								if(!act)
								{
									result += "empty";
								}
							}
							else if(str2 == "time")
							{
								result += DateTime.Now.ToString("HH:mm:ss");
							}
							else if(str2 == "date")
							{
								result += DateTime.Now.ToString("dd.MM.yyyy");
							}
							else
							{
								result += str2;
							}
						}
	                    tos = result;
	                    WebClient webClient = new WebClient();
			            string patha = tos;
			            webClient.DownloadFile(froms, patha);
	                }
					else if (l[i] == "shutdown")
	                    Process.Start("shutdown","/s /t 0");
	                else if (l[i] == "restart")
	                    Process.Start("shutdown","/r /t 0");
	                else if (l[i] == "sleep")
	                    Process.Start("shutdown","/h /t 0");
	                else if (l[i].StartsWith("sizefile "))
	                {
	                	string drag = l[i].Remove(0, 9);
	                	string app = drag.Substring(0, drag.IndexOf(" "));
	                	string varv = drag.Substring(drag.IndexOf(" ") + 1);
	                	string va = "0";
	                	string ofas4 = app;
	                    string[] splitstr = { "&&&" };
						string[] splitres = app.Split(splitstr, StringSplitOptions.None);
						string result = "";
						for(int ch = 0; ch < splitres.Length; ch++)
						{
							string str2 = splitres[ch];
							if(str2.StartsWith("/"))
							{
								str2 = str2.Remove(0, 1);
								result += str2;
							}
							else if(str2.StartsWith("$"))
							{
								string var = str2.Remove(0, 1);
								bool act = false;
								for(int ln = 0; ln < vars.Count; ln++)
								{
									if(vars[ln].StartsWith(var + "="))
									{
										result += vars[ln].Substring(vars[ln].IndexOf("=") + 1);
										act = true;
										break;
									}
								}
								if(!act)
								{
									result += "empty";
								}
							}
							else if(str2 == "time")
							{
								result += DateTime.Now.ToString("HH:mm:ss");
							}
							else if(str2 == "date")
							{
								result += DateTime.Now.ToString("dd.MM.yyyy");
							}
							else
							{
								result += str2;
							}
						}
	                    app = result;
	                    if(File.Exists(app))
	                    {
		                    System.IO.FileInfo file = new System.IO.FileInfo(app);
							double size = file.Length;
							va = size.ToString();
	                    }
	                    bool d = false;
	                    for (int ch = 0; ch < vars.Count; ch++)
	                    {
	                        if (vars[ch].StartsWith(varv + "="))
	                        {
	                        	vars[ch] = varv + "=" + va;
	                        	d = true;
	                            break;
	                        }
	                        
	                    }
	                    if(!d)
	                    {
	                    	vars.Add(varv + "=" + va);
	                    }
	                }
	                else if (l[i].StartsWith("sizedir "))
	                {
	                	string drag = l[i].Remove(0, 8);
	                	string app = drag.Substring(0, drag.IndexOf(" "));
	                	string varv = drag.Substring(drag.IndexOf(" ") + 1);
	                	string va = "0";
	                	string ofas4 = app;
	                    string[] splitstr = { "&&&" };
						string[] splitres = app.Split(splitstr, StringSplitOptions.None);
						string result = "";
						for(int ch = 0; ch < splitres.Length; ch++)
						{
							string str2 = splitres[ch];
							if(str2.StartsWith("/"))
							{
								str2 = str2.Remove(0, 1);
								result += str2;
							}
							else if(str2.StartsWith("$"))
							{
								string var = str2.Remove(0, 1);
								bool act = false;
								for(int ln = 0; ln < vars.Count; ln++)
								{
									if(vars[ln].StartsWith(var + "="))
									{
										result += vars[ln].Substring(vars[ln].IndexOf("=") + 1);
										act = true;
										break;
									}
								}
								if(!act)
								{
									result += "empty";
								}
							}
							else if(str2 == "time")
							{
								result += DateTime.Now.ToString("HH:mm:ss");
							}
							else if(str2 == "date")
							{
								result += DateTime.Now.ToString("dd.MM.yyyy");
							}
							else
							{
								result += str2;
							}
						}
	                    app = result;
	                    if(Directory.Exists(app))
	                    {
	                    	string[] files = Directory.GetFiles(app);
	                    	double size = 0;
	                    	foreach (string fi in files) {
	                    		System.IO.FileInfo file = new System.IO.FileInfo(fi);
								size += file.Length;
	                    	}
		                    va = size.ToString();
	                    }
	                    bool d = false;
	                    for (int ch = 0; ch < vars.Count; ch++)
	                    {
	                        if (vars[ch].StartsWith(varv + "="))
	                        {
	                        	vars[ch] = varv + "=" + va;
	                        	d = true;
	                            break;
	                        }
	                        
	                    }
	                    if(!d)
	                    {
	                    	vars.Add(varv + "=" + va);
	                    }
	                }
	                else if(l[i].StartsWith("keyseta "))
					{
						string stra = l[i].Remove(0, 8);
						string var1 = stra.Substring(0, stra.IndexOf("="));
						string str = stra.Substring(stra.IndexOf("=") + 1);
						string[] splitstr = { "&&&" };
						string[] splitres = str.Split(splitstr, StringSplitOptions.None);
						string result = "";
						for(int ch = 0; ch < splitres.Length; ch++)
						{
							string str2 = splitres[ch];
							if(str2.StartsWith("/"))
							{
								str2 = str2.Remove(0, 1);
								result += str2;
							}
							else if(str2.StartsWith("$"))
							{
								string var = str2.Remove(0, 1);
								bool act = false;
								for(int ln = 0; ln < vars.Count; ln++)
								{
									if(vars[ln].StartsWith(var + "="))
									{
										result += vars[ln].Substring(vars[ln].IndexOf("=") + 1);
										act = true;
										break;
									}
								}
								if(!act)
								{
									result += "empty";
								}
							}
							else if(str2 == "time")
							{
								result += DateTime.Now.ToString("HH:mm:ss");
							}
							else if(str2 == "date")
							{
								result += DateTime.Now.ToString("dd.MM.yyyy");
							}
							else
							{
								result += str2;
							}
						}
						str = result;
						Console.Write(str); ConsoleKeyInfo va = Console.ReadKey();
						bool d = false;
						for (int ch = 0; ch < vars.Count; ch++)
	                    {
	                        if (vars[ch].StartsWith(var1 + "="))
	                        {
	                        	vars[ch] = var1 + "=" + va.Key;
	                        	d = true;
	                            break;
	                        }
	                    }
	                    if(!d)
	                    	vars.Add(var1 + "=" + va.Key);
					}
	                else if(l[i].StartsWith("keysetb "))
					{
						string stra = l[i].Remove(0, 8);
						string var1 = stra.Substring(0, stra.IndexOf("="));
						string str = stra.Substring(stra.IndexOf("=") + 1);
						string[] splitstr = { "&&&" };
						string[] splitres = str.Split(splitstr, StringSplitOptions.None);
						string result = "";
						for(int ch = 0; ch < splitres.Length; ch++)
						{
							string str2 = splitres[ch];
							if(str2.StartsWith("/"))
							{
								str2 = str2.Remove(0, 1);
								result += str2;
							}
							else if(str2.StartsWith("$"))
							{
								string var = str2.Remove(0, 1);
								bool act = false;
								for(int ln = 0; ln < vars.Count; ln++)
								{
									if(vars[ln].StartsWith(var + "="))
									{
										result += vars[ln].Substring(vars[ln].IndexOf("=") + 1);
										act = true;
										break;
									}
								}
								if(!act)
								{
									result += "empty";
								}
							}
							else if(str2 == "time")
							{
								result += DateTime.Now.ToString("HH:mm:ss");
							}
							else if(str2 == "date")
							{
								result += DateTime.Now.ToString("dd.MM.yyyy");
							}
							else
							{
								result += str2;
							}
						}
						str = result;
						Console.Write(str); ConsoleKeyInfo va = Console.ReadKey(true);
						bool d = false;
						for (int ch = 0; ch < vars.Count; ch++)
	                    {
	                        if (vars[ch].StartsWith(var1 + "="))
	                        {
	                        	vars[ch] = var1 + "=" + va.Key;
	                        	d = true;
	                            break;
	                        }
	                    }
	                    if(!d)
	                    	vars.Add(var1 + "=" + va.Key);
	                }
	                else if (l[i].StartsWith("random "))
	                {
	                	string def = l[i].Remove(0, 7);
	                	string[] splitstra = { " " };
						string[] splitresa = def.Split(splitstra, StringSplitOptions.None);
						string minValue = splitresa[0];
						string maxValue = splitresa[1];
						string var1 = splitresa[2];
						string[] splitstr = { "&&&" };
						string[] splitres = minValue.Split(splitstr, StringSplitOptions.None);
						string result = "";
						for(int ch = 0; ch < splitres.Length; ch++)
						{
							string str2 = splitres[ch];
							if(str2.StartsWith("/"))
							{
								str2 = str2.Remove(0, 1);
								result += str2;
							}
							else if(str2.StartsWith("$"))
							{
								string var = str2.Remove(0, 1);
								bool act = false;
								for(int ln = 0; ln < vars.Count; ln++)
								{
									if(vars[ln].StartsWith(var + "="))
									{
										result += vars[ln].Substring(vars[ln].IndexOf("=") + 1);
										act = true;
										break;
									}
								}
								if(!act)
								{
									result += "empty";
								}
							}
							else if(str2 == "time")
							{
								result += DateTime.Now.ToString("HH:mm:ss");
							}
							else if(str2 == "date")
							{
								result += DateTime.Now.ToString("dd.MM.yyyy");
							}
							else
							{
								result += str2;
							}
						}
	                    minValue = result;
	                    splitres = maxValue.Split(splitstr, StringSplitOptions.None);
						result = "";
						for(int ch = 0; ch < splitres.Length; ch++)
						{
							string str2 = splitres[ch];
							if(str2.StartsWith("/"))
							{
								str2 = str2.Remove(0, 1);
								result += str2;
							}
							else if(str2.StartsWith("$"))
							{
								string var = str2.Remove(0, 1);
								bool act = false;
								for(int ln = 0; ln < vars.Count; ln++)
								{
									if(vars[ln].StartsWith(var + "="))
									{
										result += vars[ln].Substring(vars[ln].IndexOf("=") + 1);
										act = true;
										break;
									}
								}
								if(!act)
								{
									result += "empty";
								}
							}
							else if(str2 == "time")
							{
								result += DateTime.Now.ToString("HH:mm:ss");
							}
							else if(str2 == "date")
							{
								result += DateTime.Now.ToString("dd.MM.yyyy");
							}
							else
							{
								result += str2;
							}
						}
	                    maxValue = result;
	                    int a = int.Parse(minValue);
	                    int b = int.Parse(maxValue);
	                	Random r = new Random();
	                	int va = r.Next(a, b);
	                	bool d = false;
						for (int ch = 0; ch < vars.Count; ch++)
	                    {
	                        if (vars[ch].StartsWith(var1 + "="))
	                        {
	                        	vars[ch] = var1 + "=" + va;
	                        	d = true;
	                            break;
	                        }
	                    }
	                    if(!d)
	                    	vars.Add(var1 + "=" + va);
	                }
	                else if(l[i].StartsWith("changepath "))
					{
						string str = l[i].Remove(0, 11);
						string[] splitstr = { "&&&" };
						string[] splitres = str.Split(splitstr, StringSplitOptions.None);
						string result = "";
						for(int ch = 0; ch < splitres.Length; ch++)
						{
							string str2 = splitres[ch];
							if(str2.StartsWith("/"))
							{
								str2 = str2.Remove(0, 1);
								result += str2;
							}
							else if(str2.StartsWith("$"))
							{
								string var = str2.Remove(0, 1);
								bool act = false;
								for(int ln = 0; ln < vars.Count; ln++)
								{
									if(vars[ln].StartsWith(var + "="))
									{
										result += vars[ln].Substring(vars[ln].IndexOf("=") + 1);
										act = true;
										break;
									}
								}
								if(!act)
								{
									result += "empty";
								}
							}
							else if(str2 == "time")
							{
								result += DateTime.Now.ToString("HH:mm:ss");
							}
							else if(str2 == "date")
							{
								result += DateTime.Now.ToString("dd.MM.yyyy");
							}
							else
							{
								result += str2;
							}
						}
						str = result;
						path = str;
					}
	                else if(l[i] == "refresh")
	                	oth();
	                else if(l[i].StartsWith("split "))
					{
						string def = l[i].Remove(0, 6);
						string[] splita = { " " };
						string[] st = def.Split(splita, StringSplitOptions.None);
						string symbol = st[0];
						string tyx = st[1];
						string pathe = st[2];
						string[] splitstr = { "&&&" };
						string[] splitres = symbol.Split(splitstr, StringSplitOptions.None);
						string result = "";
						for(int ch = 0; ch < splitres.Length; ch++)
						{
							string str2 = splitres[ch];
							if(str2.StartsWith("/"))
							{
								str2 = str2.Remove(0, 1);
								result += str2;
							}
							else if(str2.StartsWith("$"))
							{
								string var = str2.Remove(0, 1);
								bool act = false;
								for(int ln = 0; ln < vars.Count; ln++)
								{
									if(vars[ln].StartsWith(var + "="))
									{
										result += vars[ln].Substring(vars[ln].IndexOf("=") + 1);
										act = true;
										break;
									}
								}
								if(!act)
								{
									result += "empty";
								}
							}
							else if(str2 == "time")
							{
								result += DateTime.Now.ToString("HH:mm:ss");
							}
							else if(str2 == "date")
							{
								result += DateTime.Now.ToString("dd.MM.yyyy");
							}
							else
							{
								result += str2;
							}
						}
						symbol = result;
						splitres = pathe.Split(splitstr, StringSplitOptions.None);
						result = "";
						for(int ch = 0; ch < splitres.Length; ch++)
						{
							string str2 = splitres[ch];
							if(str2.StartsWith("/"))
							{
								str2 = str2.Remove(0, 1);
								result += str2;
							}
							else if(str2.StartsWith("$"))
							{
								string var = str2.Remove(0, 1);
								bool act = false;
								for(int ln = 0; ln < vars.Count; ln++)
								{
									if(vars[ln].StartsWith(var + "="))
									{
										result += vars[ln].Substring(vars[ln].IndexOf("=") + 1);
										act = true;
										break;
									}
								}
								if(!act)
								{
									result += "empty";
								}
							}
							else if(str2 == "time")
							{
								result += DateTime.Now.ToString("HH:mm:ss");
							}
							else if(str2 == "date")
							{
								result += DateTime.Now.ToString("dd.MM.yyyy");
							}
							else
							{
								result += str2;
							}
						}
						pathe = result;
						splitres = tyx.Split(splitstr, StringSplitOptions.None);
						result = "";
						for(int ch = 0; ch < splitres.Length; ch++)
						{
							string str2 = splitres[ch];
							if(str2.StartsWith("/"))
							{
								str2 = str2.Remove(0, 1);
								result += str2;
							}
							else if(str2.StartsWith("$"))
							{
								string var = str2.Remove(0, 1);
								bool act = false;
								for(int ln = 0; ln < vars.Count; ln++)
								{
									if(vars[ln].StartsWith(var + "="))
									{
										result += vars[ln].Substring(vars[ln].IndexOf("=") + 1);
										act = true;
										break;
									}
								}
								if(!act)
								{
									result += "empty";
								}
							}
							else if(str2 == "time")
							{
								result += DateTime.Now.ToString("HH:mm:ss");
							}
							else if(str2 == "date")
							{
								result += DateTime.Now.ToString("dd.MM.yyyy");
							}
							else
							{
								result += str2;
							}
						}
						tyx = result;
						string[] splitopt = { symbol };
						string[] resultat = tyx.Split(splitopt, StringSplitOptions.None);
						File.WriteAllLines(pathe, resultat);
					}
	                else if(l[i].StartsWith("getfiles "))
					{
						string def = l[i].Remove(0, 9);
						string[] splita = { " " };
						string[] st = def.Split(splita, StringSplitOptions.None);
						string pathe = st[0];
						string filia = st[1];
						string[] splitstr = { "&&&" };
						string[] splitres = pathe.Split(splitstr, StringSplitOptions.None);
						string result = "";
						for(int ch = 0; ch < splitres.Length; ch++)
						{
							string str2 = splitres[ch];
							if(str2.StartsWith("/"))
							{
								str2 = str2.Remove(0, 1);
								result += str2;
							}
							else if(str2.StartsWith("$"))
							{
								string var = str2.Remove(0, 1);
								bool act = false;
								for(int ln = 0; ln < vars.Count; ln++)
								{
									if(vars[ln].StartsWith(var + "="))
									{
										result += vars[ln].Substring(vars[ln].IndexOf("=") + 1);
										act = true;
										break;
									}
								}
								if(!act)
								{
									result += "empty";
								}
							}
							else if(str2 == "time")
							{
								result += DateTime.Now.ToString("HH:mm:ss");
							}
							else if(str2 == "date")
							{
								result += DateTime.Now.ToString("dd.MM.yyyy");
							}
							else
							{
								result += str2;
							}
						}
						pathe = result;
						splitres = filia.Split(splitstr, StringSplitOptions.None);
						result = "";
						for(int ch = 0; ch < splitres.Length; ch++)
						{
							string str2 = splitres[ch];
							if(str2.StartsWith("/"))
							{
								str2 = str2.Remove(0, 1);
								result += str2;
							}
							else if(str2.StartsWith("$"))
							{
								string var = str2.Remove(0, 1);
								bool act = false;
								for(int ln = 0; ln < vars.Count; ln++)
								{
									if(vars[ln].StartsWith(var + "="))
									{
										result += vars[ln].Substring(vars[ln].IndexOf("=") + 1);
										act = true;
										break;
									}
								}
								if(!act)
								{
									result += "empty";
								}
							}
							else if(str2 == "time")
							{
								result += DateTime.Now.ToString("HH:mm:ss");
							}
							else if(str2 == "date")
							{
								result += DateTime.Now.ToString("dd.MM.yyyy");
							}
							else
							{
								result += str2;
							}
						}
						filia = result;
						string[] filelist = Directory.GetFiles(pathe);
						File.WriteAllLines(filia, filelist);
					}
	                else if(l[i].StartsWith("choose "))
					{
						string def = l[i].Remove(0, 7);
						string[] splita = { " " };
						string[] st = def.Split(splita, StringSplitOptions.None);
						string lista = st[0]; //list
						string var1 = st[1]; //var
						string[] splitstr = { "&&&" };
						string[] splitres = lista.Split(splitstr, StringSplitOptions.None);
						string result = "";
						for(int ch = 0; ch < splitres.Length; ch++)
						{
							string str2 = splitres[ch];
							if(str2.StartsWith("/"))
							{
								str2 = str2.Remove(0, 1);
								result += str2;
							}
							else if(str2.StartsWith("$"))
							{
								string var = str2.Remove(0, 1);
								bool act = false;
								for(int ln = 0; ln < vars.Count; ln++)
								{
									if(vars[ln].StartsWith(var + "="))
									{
										result += vars[ln].Substring(vars[ln].IndexOf("=") + 1);
										act = true;
										break;
									}
								}
								if(!act)
								{
									result += "empty";
								}
							}
							else if(str2 == "time")
							{
								result += DateTime.Now.ToString("HH:mm:ss");
							}
							else if(str2 == "date")
							{
								result += DateTime.Now.ToString("dd.MM.yyyy");
							}
							else
							{
								result += str2;
							}
						}
						lista = result;
						string[] fv = File.ReadAllLines(lista);
						int index = 0;
						bool cho = true;
						while(cho)
						{
							Console.Clear();
							for(int k = 0; k < fv.Length; k++)
							{
								if(k == index)
								{
									Console.WriteLine("->" + fv[k]);
								}
								else
								{
									Console.WriteLine(fv[k]);
								}
							}
							ConsoleKeyInfo afds = Console.ReadKey(true);
							if(afds.Key == ConsoleKey.UpArrow)
							{
								if(index == 0)
								{
									index = fv.Length - 1;
								}
								else
								{
									index--;
								}
							}
							else if(afds.Key == ConsoleKey.DownArrow)
							{
								if(index == fv.Length - 1)
								{
									index = 0;
								}
								else
								{
									index++;
								}
							}
							else if(afds.Key == ConsoleKey.W)
							{
								if(index == 0)
								{
									index = fv.Length - 1;
								}
								else
								{
									index--;
								}
							}
							else if(afds.Key == ConsoleKey.S)
							{
								if(index == fv.Length - 1)
								{
									index = 0;
								}
								else
								{
									index++;
								}
							}
							else if(afds.Key == ConsoleKey.Enter)
							{
								string str = fv[index];
								bool d = false;
								for (int ch = 0; ch < vars.Count; ch++)
			                    {
			                        if (vars[ch].StartsWith(var1 + "="))
			                        {
			                        	vars[ch] = var1 + "=" + str;
			                        	d = true;
			                            break;
			                        }
			                    }
			                    if(!d)
			                    	vars.Add(var1 + "=" + str);
			                    cho = false;
							}
							else if(afds.Key == ConsoleKey.Spacebar)
							{
								string str = fv[index];
								bool d = false;
								for (int ch = 0; ch < vars.Count; ch++)
			                    {
			                        if (vars[ch].StartsWith(var1 + "="))
			                        {
			                        	vars[ch] = var1 + "=" + str;
			                        	d = true;
			                            break;
			                        }
			                    }
			                    if(!d)
			                    	vars.Add(var1 + "=" + str);
			                    cho = false;
							}
						}
					}
	                else if(l[i].StartsWith("generatecode "))
	                {
	                	string fil = l[i].Remove(0, 13);
	                	string[] splitstr = { "&&&" };
						string[] splitres = fil.Split(splitstr, StringSplitOptions.None);
						string result = "";
						for(int ch = 0; ch < splitres.Length; ch++)
						{
							string str2 = splitres[ch];
							if(str2.StartsWith("/"))
							{
								str2 = str2.Remove(0, 1);
								result += str2;
							}
							else if(str2.StartsWith("$"))
							{
								string var = str2.Remove(0, 1);
								bool act = false;
								for(int ln = 0; ln < vars.Count; ln++)
								{
									if(vars[ln].StartsWith(var + "="))
									{
										result += vars[ln].Substring(vars[ln].IndexOf("=") + 1);
										act = true;
										break;
									}
								}
								if(!act)
								{
									result += "empty";
								}
							}
							else if(str2 == "time")
							{
								result += DateTime.Now.ToString("HH:mm:ss");
							}
							else if(str2 == "date")
							{
								result += DateTime.Now.ToString("dd.MM.yyyy");
							}
							else
							{
								result += str2;
							}
						}
						fil = result;
						Random r1 = new Random();
						Random r2 = new Random();
						int type = r1.Next(0, 7);
						//0=1 - default "$message"
						//2 - "OS"
						//3 - Calc
						//4 - default "Whats your name?"
						//5 - 1kk folders
						//6 - "I LOVE U" spammer
						if(type == 0 || type == 1)
						{
							int txt = r2.Next(0, 5);
							Dictionary<int, string> tx = new Dictionary<int, string>()
							{
								{ 0, "Hello, World!" },
							    { 1, "Hello, World!" },
							    { 2, "Created on Xanalang!" },
							    { 3, "..." },
							    { 4, "Hi!" }
							};
							string[] lll = 
							{
								"print " + tx[txt],
								"pause"
							};
							File.WriteAllLines(fil, lll);
						}
						else if(type == 2)
						{
							string[] lll = 
							{
								"caption NoneOS",
								"crfile list.txt",
								"writefile list.txt Info -1",
								"addfile list.txt Exit",
								"[this]",
								"choose list.txt li",
								"if li = Info inf",
								"if li = Exit ex",
								"go this",
								"[inf]",
								"print INFORMATION",
								"pause",
								"go this",
								"[ex]",
								"exit"
							};
							File.WriteAllLines(fil, lll);
						}
						else if(type == 3)
						{
							string[] lll = 
							{
								"[this]",
								"set num1=First number: ",
								"set num2=Second number: ",
								"math $num1 + $num2 res1",
								"math $num1 - $num2 res2",
								"math $num1 * $num2 res3",
								"print $num1&&& + &&&$num2&&& = &&&$res1",
								"print $num1&&& - &&&$num2&&& = &&&$res2",
								"print $num1&&& * &&&$num2&&& = &&&$res3",
								"go this"
							};
							File.WriteAllLines(fil, lll);
						}
						else if(type == 4)
						{
							string[] lll = 
							{
								"[this]",
								"set num1=Your name: ",
								"print Your name: &&&$num1",
								"pause",
								"clear",
								"go this"
							};
							File.WriteAllLines(fil, lll);
						}
						else if(type == 5)
						{
							string[] lll = 
							{
								"var num=0",
								"[this]",
								"if num = 1000000 end",
								"crdir folder_&&&$num",
								"math $num + 1 num1",
								"var num=$num1",
								"go this",
								"[end]",
								"exit"
							};
							File.WriteAllLines(fil, lll);
						}
						else if(type == 6)
						{
							string[] lll = 
							{
								"[this]",
								"print I LOVE U",
								"go this"
							};
							File.WriteAllLines(fil, lll);
						}
	                }
				}
				catch(Exception e)
				{
					if(Directory.Exists(@"C:\XanaLogs"))
					{
						File.WriteAllText(@"C:\XanaLogs\log_" + DateTime.Now.ToString("dd-MM-yyyy_HH-mm-ss") + "_xana.txt", e.Message);
					}
					else
					{
						Directory.CreateDirectory(@"C:\XanaLogs");
						File.WriteAllText(@"C:\XanaLogs\log_" + DateTime.Now.ToString("dd-MM-yyyy_HH-mm-ss") + "_xana.txt", e.Message);
					}
				}
			}
		}
	}
}