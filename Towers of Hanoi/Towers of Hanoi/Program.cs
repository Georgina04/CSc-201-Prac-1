using System;
using System.Collections.Generic;
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

        public Tower (char ID)
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
            
            

    }

    class Program
    {
        static void Main(string[] args)
        {
            
            Tower towerA = new Tower('A');
            for (int i = 4; i > 0; i--)
            {
                towerA.Add(i);
            }
            Tower towerB = new Tower('B');
            Tower towerC = new Tower('C');

            
        }
    }
}
