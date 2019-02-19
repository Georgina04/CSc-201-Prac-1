using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Towers_of_Hanoi
{
    

    class Tower
    {
        
        
        private int[] disks;
        private int numDisks;
        private char ID;

        public Tower(char ID)
        {
            this.ID = ID;
            disks = new int[64];
            numDisks = 0;
        }

        public void Add(int disk)
        {
            if (numDisks == 0)
            {
                //there are no disks on the tower, just add the disk to the 
                //first index.
                disks[numDisks] = disk;
                //increment numDisks.
                numDisks++;
            }
            else if (disks[numDisks - 1] > disk)
            {
                //the disk you are trying to add is smaller than the one on top of
                //the tower, add the disk to the next index.
                disks[numDisks] = disk;
                //increment numDisks.
                numDisks++;
            }
            else
            {
                //tried to add a bigger disk on a smaller one
                Console.WriteLine("You tried to add a bigger disk on top of a smaller one.");
            }



        }

        public int Remove()
        {
            if (numDisks == 0)
            {
                //there is no disk to remove.
                Console.WriteLine("You cannot remove a disk that is not there.");
                return -1;
            }
            else
            {
                //assign the value of the top disk to topDisk
                int topDisk = disks[numDisks - 1];
                //make the top disk in the array 0 (it is removed)
                disks[numDisks - 1] = 0;
                //decrement numDisks
                numDisks--;
                return topDisk;
            }

        }

        public void move(Tower Source, Tower Destination)
        {
            int temp = Source.Remove();

            Destination.Add(temp);

        }

        public void solveTowers(int numDisks, Tower startPeg, Tower endPeg, Tower tempPeg)
        {
            if (numDisks == 1)
            {
                move(startPeg, endPeg);
            }
            else
            {
                solveTowers(numDisks - 1, startPeg, tempPeg, endPeg);
                move(startPeg, endPeg);
                Console.WriteLine("Move disk from " + startPeg + ' ' + endPeg);
                solveTowers(numDisks - 1, tempPeg, endPeg, startPeg);

            }
        }
        

        static void Main(string[] args)
        {

            
            Console.WriteLine("How many disks do you want to move?");
            int n = Console.Read();

            

            Tower startPeg = new Tower('A');
            Tower tempPeg = new Tower('B');
            Tower endPeg = new Tower('C');

            Stopwatch sw = Stopwatch.StartNew();
            solveTowers(n, startPeg, endPeg, tempPeg);// The task to be timed goes here. . .
            sw.Stop();
            Console.WriteLine("Time taken: " + sw.ElapsedMilliseconds + "ms.");

            

        }


    }
}
