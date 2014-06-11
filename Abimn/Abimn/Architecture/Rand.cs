using System;

namespace Abimn
{
    public static class Rand
    {
        private static Random _rand;

        public static void Init() { _rand = new Random(); }
        public static void Init(int seed) { _rand = new Random(seed); }

        public static bool Bool() { return _rand.Next(2) == 1; }
        public static int Int(int max) { return _rand.Next(max); }
        public static int Int(int min, int max) { return _rand.Next(min, max); }
    }
}
