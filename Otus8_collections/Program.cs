using System.Collections.Generic;
using System.Collections;
using System.Diagnostics;

namespace Otus8_collections
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stopwatch myWatch = new Stopwatch();
//            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("<--------- LIST PERFORMANCE ---------->");
//            Console.ForegroundColor = ConsoleColor.White;
            CheckListAddInstructionPerformance(ref myWatch);
            Console.WriteLine("\n");
//            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("<--------- ARRAYLIST PERFORMANCE ---------->");
//            Console.ForegroundColor = ConsoleColor.White;
            CheckArrayListAddInstructionPerformance(ref myWatch);
            Console.WriteLine("\n");
//            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("<--------- LINKEDLIST PERFORMANCE---------->");
//            Console.ForegroundColor = ConsoleColor.White;
            CheckLinkedListAddInstructionPerformance(ref myWatch);
        }

        public static void DisplayElapsedTime(string message, TimeSpan ts)
        {
            // Format and display the TimeSpan value.
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
            Console.WriteLine(message + ": " + elapsedTime);
        }
        public static void CheckListAddInstructionPerformance(ref Stopwatch myLocWatch)
        {
            var myList = new List<int>();
            var rand = new Random();

            int i = 0;
            myLocWatch.Restart();
            while (i < 1000000)
            {
                myList.Add(rand.Next());
                i++;
            }
            DisplayElapsedTime("1. List performance after 1 000 000 Add random instruction", myLocWatch.Elapsed);

            myLocWatch.Restart();
            Console.WriteLine($"2. Index of value 496753 = " + myList.IndexOf(496753));
            DisplayElapsedTime("3. Linear search instruction in List collection need ", myLocWatch.Elapsed);

            i = 0;
            myLocWatch.Restart();
            while (i < 1000000)
            {
                if (myList[i]%777 == 0 && myList[i] != 0)
                    Console.Write(myList[i] + " ");
                i++;
            }
            Console.Write("\n");
            DisplayElapsedTime("4. Finding List elements mod 777 == 0  need", myLocWatch.Elapsed);
        }

        public static void CheckArrayListAddInstructionPerformance(ref Stopwatch myLocWatch)
        {
            var myArrayList = new ArrayList();
            var rand = new Random();
            
            int i = 0;
            myLocWatch.Restart();
            while (i < 1000000)
            {
                myArrayList.Add(rand.Next());
                i++;
            }
            DisplayElapsedTime("1. ArrayList performance after 1 000 000 Add instruction", myLocWatch.Elapsed);

            myLocWatch.Restart();
            Console.WriteLine($"2. Index of value 496753 = " + myArrayList.IndexOf(496753));
            DisplayElapsedTime("3. Linear search instruction in ArrayList collection need", myLocWatch.Elapsed);

            i = 0;
            myLocWatch.Restart();
            while (i < 1000000)
            {
                if (Convert.ToInt32(myArrayList[i]) % 777 == 0 && Convert.ToInt32(myArrayList[i]) != 0)
                    Console.Write(myArrayList[i] + " ");
                i++;
            }
            Console.Write("\n");
            DisplayElapsedTime("4. Finding ArrayList elements mod 777 == 0  need", myLocWatch.Elapsed);
        }

        public static void CheckLinkedListAddInstructionPerformance(ref Stopwatch myLocWatch)
        {
            var myLinkedList = new LinkedList<int>();
            var rand = new Random();

            int i = 0;
            myLocWatch.Restart();
            while (i < 1000000)
            {
                myLinkedList.AddLast(rand.Next());
                i++;
            }
            DisplayElapsedTime("1. LinkedList performance after 1 000 000 Add instruction", myLocWatch.Elapsed);

            myLocWatch.Restart();
            LinkedListNode<int> searchNode = myLinkedList.Find(496753);
            if (searchNode!=null)
                Console.WriteLine($"2. Index of value 496753 = " + searchNode.Value);
            else
                Console.WriteLine("2. Index of value 496753 not found");
            DisplayElapsedTime("3. Linear search instruction in LinkedList collection need", myLocWatch.Elapsed);

            LinkedListNode<int> cycleNode = myLinkedList.First;
            i = 0;
            myLocWatch.Restart();
            //while (i < myLinkedList.Count && cycleNode.Next != null)
            while (i < myLinkedList.Count)
            {
                if (cycleNode.Value % 777 == 0 && cycleNode.Value != 0)
                    Console.Write(cycleNode.Value + " ");
                cycleNode = cycleNode.Next;
                i++;
            }
            Console.Write("\n");
            DisplayElapsedTime("4. Finding LinkedList elements mod 777 == 0  need", myLocWatch.Elapsed);
        }

    }
}