using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ClientTEST
{
    internal class ConnectToAPI
    {
        public string Address { get; set; } = "https://localhost:7223/api/";
        public string Controller { get; set; } = "";
        public string Results { get; set; } = "";
            
        public ConnectToAPI SetController (string controller)
        {
            Controller = Address + controller;

            return this;
        }

        public ConnectToAPI MakeRequest()
        {
            Results = new WebClient().DownloadString(Controller);

            return this;
        }

        public ConnectToAPI SetParameter(string parameter)
        {
            Controller += "/" + parameter;

            return this;
        }
    }
}
