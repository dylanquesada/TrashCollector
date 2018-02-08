using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrashCollector.Helpers
{
    public class Purse
    {
        // Member Variables
        private decimal RubbishRemover3KFunds;
        private decimal StartupCash = 300;
        private object thisLock = new object();
        // Constructor
        public Purse()
        {
            RubbishRemover3KFunds = StartupCash;
        }
        // Member Methods
        public void CollectFromCustomer(decimal AmountPayed)
        {
            lock (thisLock)
            {
                RubbishRemover3KFunds += AmountPayed;
            }
        }
    }
}