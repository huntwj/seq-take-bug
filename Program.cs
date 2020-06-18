using LanguageExt;
using static LanguageExt.Prelude;
using System;

namespace seq_take_bug
{
    class Program
    {
        static Seq<MyType> LongSeq()
        {
            return LanguageExt.Seq.generate<MyType>(5, idx => new MyType(idx));
        }

        static void Main(string[] args)
        {
            Console.WriteLine("\nSimple Construction:");
            Seq<MyType> empty = Seq<MyType>();
            Console.WriteLine("emptyr:1");
            Console.WriteLine(empty);
            Console.WriteLine(empty.Take(5));

            Seq<MyType> emptyAfterLinq = from item in LongSeq()
                                   where item.Value > 5
                                   select item;
            Seq<MyType> take5 = emptyAfterLinq.Take(5);

            Console.WriteLine("\nConstructing Empty With Linq/where:");
            Console.WriteLine("emptyAfterLinq");
            Console.WriteLine(emptyAfterLinq);

            Console.WriteLine("emptyAfterLinq.Take(5)");
            Console.WriteLine(take5);
        }
    }

    class MyType
    {
        public int Value { get; }

        public MyType(int value)
        {
            Value = value;
        }
    }
}
