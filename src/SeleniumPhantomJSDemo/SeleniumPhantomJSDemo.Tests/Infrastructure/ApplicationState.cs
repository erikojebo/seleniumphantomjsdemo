using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace SeleniumPhantomJSDemo.Tests.Infrastructure
{
    public class ApplicationState
    {
        private readonly IList<string> _addedCustomerEmails = new List<string>();

        public string LastAddedCustomerEmail
        {
            get { return _addedCustomerEmails.Last(); }
            set { _addedCustomerEmails.Add(value); }
        }
    }
}