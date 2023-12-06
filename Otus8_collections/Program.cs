using System.Collections.Generic;
using System.Collections;
using System.Diagnostics;

namespace Otus8_collections
{
    internal class Program
    {
        private const int CollectionElementCounter = 1000000;
        private const int DivisibleCriteriaValue = 777;
        private const int TargetElement = 496753;
        static void Main(string[] args)
        {
            Stopwatch myWatch = new Stopwatch();
            Console.WriteLine("<--------- LIST PERFORMANCE ---------->");
            CheckListAddInstructionPerformance(myWatch);
            Console.WriteLine("\n");
            Console.WriteLine("<--------- ARRAYLIST PERFORMANCE ---------->");
            CheckArrayListAddInstructionPerformance( myWatch);
            Console.WriteLine("\n");
            Console.WriteLine("<--------- LINKEDLIST PERFORMANCE---------->");
            CheckLinkedListAddInstructionPerformance( myWatch);
        }

        public static void DisplayElapsedTime(string message, TimeSpan ts)
        {
            Console.WriteLine(message + ": " + ts.ToString() + "ms");
        }

        private static void CheckListAddInstructionPerformance(Stopwatch myLocWatch)
        {
            var myList = new List<int>();
            var rand = new Random();

            int i = 0;
            myLocWatch.Restart();
            while (i < CollectionElementCounter)
            {
                myList.Add(rand.Next());
                i++;
            }
            DisplayElapsedTime("1. List performance after 1 000 000 Add random instruction", myLocWatch.Elapsed);
            myLocWatch.Stop();
            myLocWatch.Restart();
            //Console.WriteLine($"2. Index of value 496753 = " + myList.IndexOf(496753));
            Console.WriteLine($"2. Index of value 496753 = " + myList[TargetElement].ToString());

            DisplayElapsedTime("3. Linear search instruction in List collection need ", myLocWatch.Elapsed);
            myLocWatch.Stop();
                
            i = 0;
            myLocWatch.Restart();
            while (i < CollectionElementCounter)
            {
                if (myList[i]%DivisibleCriteriaValue == 0 && myList[i] != 0)
                    Console.Write(myList[i] + " ");
                i++;
            }
            Console.Write("\n");
            DisplayElapsedTime("4. Finding List elements mod 777 == 0  need", myLocWatch.Elapsed);
            myLocWatch.Stop();
        }

        private static void CheckArrayListAddInstructionPerformance(Stopwatch myLocWatch)
        {
            var myArrayList = new ArrayList();
            var rand = new Random();
            
            int i = 0;
            myLocWatch.Restart();
            while (i < CollectionElementCounter)
            {
                myArrayList.Add(rand.Next());
                i++;
            }
            DisplayElapsedTime("1. ArrayList performance after 1 000 000 Add instruction", myLocWatch.Elapsed);
            myLocWatch.Stop();

            myLocWatch.Restart();
            Console.WriteLine($"2. Index of value 496753 = " + myArrayList[TargetElement].ToString());
            DisplayElapsedTime("3. Linear search instruction in ArrayList collection need", myLocWatch.Elapsed);
            myLocWatch.Stop();
            
            i = 0;
            myLocWatch.Restart();
            while (i < CollectionElementCounter)
            {
                if ((int)myArrayList[i] % DivisibleCriteriaValue == 0 && (int)myArrayList[i] != 0)
                    Console.Write(myArrayList[i] + " ");
                i++;
            }
            Console.Write("\n");
            DisplayElapsedTime("4. Finding ArrayList elements mod 777 == 0  need", myLocWatch.Elapsed);
            myLocWatch.Stop();
        }

        private static void CheckLinkedListAddInstructionPerformance(Stopwatch myLocWatch)
        {
            var myLinkedList = new LinkedList<int>();
            var rand = new Random();

            int i = 0;
            myLocWatch.Restart();
            while (i < CollectionElementCounter)
            {
                myLinkedList.AddLast(rand.Next());
                i++;
            }
            DisplayElapsedTime("1. LinkedList performance after 1 000 000 Add instruction", myLocWatch.Elapsed);
            myLocWatch.Stop();
            
            myLocWatch.Restart();

            /*          //indexing in while loop
            LinkedListNode<int> currentNode = myLinkedList.First;
            var iterator = 0;
            while (currentNode!=null)
            {
                currentNode = currentNode.Next;
                if (iterator++ == TargetElement)
                {
                    Console.WriteLine($"2. Index of value 496753 = " + currentNode.Value.ToString());
                    break;
                }
            }*/

            var iterator = 0;
            foreach (var nodeVal in myLinkedList)
            {
                if (iterator == TargetElement)
                {
                    Console.WriteLine($"2. Index of value 496753 = " + nodeVal.ToString());
                    break;
                }
                iterator++;
            }
            DisplayElapsedTime("3. Linear search instruction in LinkedList collection need", myLocWatch.Elapsed);
            myLocWatch.Stop();

            LinkedListNode<int> cycleNode = myLinkedList.First;
            i = 0;
            myLocWatch.Restart();
            while (i < myLinkedList.Count)
            {
                if (cycleNode.Value % DivisibleCriteriaValue == 0 && cycleNode.Value != 0)
                    Console.Write(cycleNode.Value + " ");
                cycleNode = cycleNode.Next;
                i++;
            }
            Console.Write("\n");
            DisplayElapsedTime("4. Finding LinkedList elements mod 777 == 0  need", myLocWatch.Elapsed);
            myLocWatch.Stop();
        }
    }
}