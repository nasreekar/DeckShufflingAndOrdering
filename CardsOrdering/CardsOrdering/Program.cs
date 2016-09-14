using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// Author:       Abhijith Sreekar N
// Language:     C#
// Created Date: 14.09.2016, 12:13 AM

namespace CardsOrdering
{
    class Program
    {
        static void Main(string[] args)
        {
            int cardNo;
            Console.WriteLine("Enter the number of cards in deck");
            cardNo = Convert.ToInt32(Console.ReadLine());
            
            if(cardNo>0){
                int rounds = shuffle(cardNo);
                Console.WriteLine("Number of rounds required to shuffle are: {0}", rounds);
                Console.Read();
            }
            else
            {
                Console.WriteLine("Enter a valid number of cards for shuffling");
            }
        }

        public static int shuffle(int number)
        {
            int sRound = 1;
            int[] shuffArr = new int[number];
            int[] origArr = new int[number];
            List<int> shuffList = new List<int>();
            List<int> origList = new List<int>();

            //adding cards to the original deck starting from 1 to deck size
            for(int j=1; j<=number;j++){
                origList.Add(j);
                shuffList.Add(j);
            }

            //converting the list elements to array's
            origArr = origList.ToArray(); 
            shuffArr = shuffList.ToArray();

            //first shuffle
            shuffArr = loopFunc(shuffArr);

            //checking if shuffle array sequence is same as original array
            while(!shuffArr.SequenceEqual(origArr))
            {
                shuffArr = loopFunc(shuffArr);
                sRound++;
            }

            return sRound;
        }

        //looping and ordering
        public static int[] loopFunc(int[] array)
        {
            int size = array.Length;
            int[] dummy = new int[size];
            List<int> dummyList = new List<int>();
            List<int> arrayList = array.ToList();
            Queue<int> q = new Queue<int>(arrayList); //tried using stack but it follows LIFO, so using queue

            while (q.Count > 0)
            {
                int i = q.Dequeue();
                dummyList.Add(i);

                if (q.Count != 0)
                {
                    int j = q.Dequeue();
                    q.Enqueue(j);
                }
            }

            dummy = dummyList.ToArray();
            return dummy;
        }
    }
}
