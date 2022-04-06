using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETCP.Application.HelloWorld
{
    public class HelloWorldService : ETCPServiceBase, IHelloWorldService
    {
        public string HelloWorld()
        {
            return "Hello World";
        }
    }
}
