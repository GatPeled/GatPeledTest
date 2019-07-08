using System.Collections.Generic;

namespace TestGat.Module
{
    public class RootOwner
    {
        public int total_count { get; set; }
        public bool incomplete_results { get; set; }
        public List<Item> items { get; set; }
    }
}
