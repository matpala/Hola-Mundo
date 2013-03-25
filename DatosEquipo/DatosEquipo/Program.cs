using System;
using System.Management;

namespace DatosEquipo
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			int p = (int) Environment.OSVersion.Platform;
			if(p==4 || p==6 || p==128)
			{
				Console.WriteLine("Los sistemas derivados de unix todavia no estan soportados");
				return;
			}

			string SO = "No detectado";
			int memoriaRam;
			string arquitectura = "";
			string procesador = "";

			double totalCapacity = 0;
			ObjectQuery objectQuery = new ObjectQuery("select * from Win32_PhysicalMemory");
			ManagementObjectSearcher searcher = new
				ManagementObjectSearcher(objectQuery);
			ManagementObjectCollection vals = searcher.Get();
			
			foreach(ManagementObject val in vals)
			{
				totalCapacity += System.Convert.ToDouble(val.GetPropertyValue("Capacity"));
			}

			Console.WriteLine("Total Machine Memory = " + (totalCapacity / 1048576) + "    MegaBytes");
			Console.WriteLine("Total Machine Memory = " + (totalCapacity / 1073741824 )    + " GigaBytes");

			memoriaRam = (int)totalCapacity / 1048576;
			Console.ReadLine();
			/**
			Windows 8	6.2
				Windows Server 2012	6.2
					Windows 7	6.1
					Windows Server 2008 R2	6.1
					Windows Server 2008	6.0
					Windows Vista	6.0
					Windows Server 2003 R2	5.2
					Windows Server 2003	5.2
					Windows XP 64-Bit Edition	5.2
					Windows XP	5.1
					Windows 2000	5.0
			**/

			Console.WriteLine(Environment.OSVersion.Version);
			string osVersion = Environment.OSVersion.Version.ToString().Substring(0,3);
			//if(osVersion == "6.2")//"6.2.9200.0")
			//	SO= "Windows 8";
			switch (osVersion) {
			case "6.2":
				SO = "Windows 8";
				break;
			case "6.1":
				SO = "Windows 7";
				break;
			case "6.0":
				SO = "Windows Vista";
				break;
			default:
				break;
			}

			//Console.WriteLine(Environment.OSVersion.Platform.ToString());
			//Console.WriteLine(Environment.MachineName.ToString());
			//Console.WriteLine(Environment.OSVersion.ServicePack.ToString());
			//Console.WriteLine(Environment.Is64BitProcess.ToString());

			Console.WriteLine(string.Format("Sistema Operativo: {0} Memoria Ram: {1} Mb",SO,memoriaRam));



			Console.WriteLine ("Hello World!");
			Console.ReadLine();
		}
	}
}
