using System;
using System.Collections.Generic;
using System.Text;

namespace System.Quests
{
    public class ObjectiveEventArgs : EventArgs
    {
        public ObjectiveEventArgs()
        {

        }

        public string Type { get; set; }
        public Guid Data { get; set; }
        public double Amount { get; set; }
    }
}
