using System;
using System.Collections.Generic;

namespace OGE_Tests
{
    public class TestInstance
    {
        public int id { get; set; }

        public DateTime dateBeg { get; set; }

        public Dictionary<int, TaskInstance> tasks { get; set; }

    }
}
