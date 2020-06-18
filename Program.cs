using LanguageExt;
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
            Seq<MyType> emptySeq = from item in LongSeq()
                                   where item.Value > 5
                                   select item;
            Seq<MyType> take5 = emptySeq.Take(5);

            Console.WriteLine("emptySeq");
            Console.WriteLine(emptySeq);

            Console.WriteLine("take5");
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
