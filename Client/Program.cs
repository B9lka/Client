using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class MainClass
{

    public static void Main(string[] args)
    {

        // Check to see if the user don`t enter three arguments 
        if (args.Length != 2)
        {
            Console.WriteLine("ERROR: Incorrect number of arguments\n\n");
            DisplayUsage();
            return;
        }

        // Create instance of AutoSvr

        try
        {
            AutoSvrLib.SvcControlComponent SvcControl = new AutoSvrLib.SvcControlComponent();
            
            // QueryInterface for the ISvcControl interface:
            AutoSvrLib.ISvcControl mc = (AutoSvrLib.ISvcControl)SvcControl;

            string szCommand = args[0];
            string szSvcName = args[1];

            if (szCommand.Equals("start"))
                mc.DoStartSvc(szSvcName);
            else if (szCommand.Equals("stop"))
                mc.DoStopSvc(szSvcName);
            else
            {
                Console.WriteLine("Unknown command: " + szCommand + "\n");
                DisplayUsage();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Unexpected COM exception:" + ex.Message);
        }

        //Wait for completion
        //Console.WriteLine("Press Enter to continue.");
        //Console.ReadLine();
    }

    private static void DisplayUsage()
    {
        // User did not provide enough parameters. 
        // Display usage: 
        Console.WriteLine("Description:\n");
        Console.WriteLine("\tCommand-line tool that controls a service.\n");
        Console.WriteLine("Usage:\n");
        Console.WriteLine("\tClient [command] [service_name]\n");
        Console.WriteLine("\t[command]");
        Console.WriteLine("\t  start");
        Console.WriteLine("\t  stop");
    }
}