using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwinCAT.Ads;
using System.IO;

namespace TC3_ADS_OnlineChangeAutomate
{
    class Program
    {
        static TcAdsClient tcClient;

        static void Main(string[] args)
        {
            tcClient = new TcAdsClient();


            string moduleValue = "C++ Module Vendor|CPPVP1|0.0.0.1";
            System.UInt32 indexGroup = 0x1010010;
            System.UInt32 indexOffset = 0x3002119;


            try
            {
                tcClient.Connect("5.50.154.204.1.1", 10);


            }
            catch(Exception ex)
            {
                Console.WriteLine("Error with ADS Connection: " + ex);
            }
            tcClient.WriteAnyString(indexGroup, indexOffset, moduleValue, 127, Encoding.Default);


        }


    }
}
