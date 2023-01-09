using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAS_040
{
    class Node
    {
        public int noMhs;
        public string name;
        public string kelas;
        public Node next;
        public Node prev;
    }

    class DoubleLinkedList
    {
        Node START;

        //Constructor
        public DoubleLinkedList()
        {
            START = null;
        }
        public void addNote()
        {
            int nim;
            string nm;
            string kl;
            Console.Write("\nMasukkan Nomor Induk Siswa: ");
            nim = Convert.ToInt32(Console.ReadLine());
            Console.Write("\nMasukkan Nama Siswa: ");
            nm = Console.ReadLine();
            Console.Write("\nMasukan Kelas Siswa: ");
            kl = Console.ReadLine();
            Node newNode = new Node();
            newNode.noMhs = nim;
            newNode.name = nm;
            newNode.kelas = kl;

            //Check if the list empty
            if ((START == null || nim <= START.noMhs))
            {
                if ((START != null) && (nim == START.noMhs))
                {
                    Console.WriteLine("\nDuplicate number not Allowed");
                    return;
                }
                newNode.next = START;
                if (START != null)
                    START.prev = newNode;
                newNode.prev = null;
                START = newNode;
                return;
            }
            // if the node is to be inserted at between two node
            Node previous, current;
            for (current = previous = START;
                current != null && nim >= current.noMhs;
                previous = current, current = current.next)
            {
                if (nim == current.noMhs)
                {
                    Console.WriteLine("\nDuplicate roll numbers not allowed");
                    return;
                }
            }
            /*On the execution of the above for loop, prev and
             * * current will point to those nodes
             * * between wich the new node is to be inserted.*/
            newNode.next = current;
            newNode.prev = previous;

            //if the node is to be inserted at the end of the list
            if (current == null)
            {
                newNode.next = null;
                previous.next = newNode;
                return;
            }
            current.prev = newNode;
            previous.next = newNode;
        }
        public bool search(int rollNo, ref Node previous, ref Node current)
        {
            for (previous = current = START; current != null &&
                rollNo != current.noMhs; previous = current,
                current = current.next) { }
            return (current != null);
        }
        public bool dellNote(int rollNo)
        {
            Node previous, current;
            previous = current = null;
            if (search(rollNo, ref previous, ref current) == false)
                return false;
            //the begining of data
            if (current.next == null)
            {
                previous.next = null;
                return true;
            }
            //Node between two nodes in the list
            if (current == START)
            {
                START = START.next;
                if (START != null)
                    START.prev = null;
                return true;
            }

            /* if the to be deleted is in between the list then the
             following lines of is executed. */
            previous.next = current.next;
            current.next.prev = previous;
            return true;
        }

        public bool listEmpty()
        {
            if (START == null)
                return true;
            else
                return false;
        }

        public void ascending()
        {
            if (listEmpty())
                Console.WriteLine("\nList is Empty");
            else
            {
                Console.WriteLine("\nRecord in the ascending order of" + "roll number are :\n");
                Node currentNode;
                for (currentNode = START; currentNode != null; currentNode = currentNode.next)
                    Console.Write(currentNode.noMhs + "     " + currentNode.name + "    " + currentNode.kelas + "\n");
            }
        }

        public void descending()
        {
            if (listEmpty())
                Console.WriteLine("\nList is empty");
            else
            {
                Console.WriteLine("\nRecord in the Descending order of" + "roll number are:\n");
                Node currentNode;
                for (currentNode = START; currentNode != null; currentNode = currentNode.next)
                { }

                while (currentNode != null)
                {
                    Console.Write(currentNode.noMhs + "     " + currentNode.name + "    " + currentNode.kelas + "\n");
                    currentNode = currentNode.prev;
                }
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            DoubleLinkedList obj = new DoubleLinkedList();
            while (true)
            {
                try
                {
                    Console.WriteLine("\nMENU");
                    Console.WriteLine("1. Add a Record to the List");
                    Console.WriteLine("2. Delete a Record From the List");
                    Console.WriteLine("3. View all Records in the Order Ascending of Roll Numbers");
                    Console.WriteLine("4. View all Records in the Descending Order of Roll Numbers");
                    Console.WriteLine("5. Search for a Record in the List");
                    Console.WriteLine("6. EXIT\n");
                    Console.Write("Enter Your Choice (1-6): ");
                    char ch = Convert.ToChar(Console.ReadLine());
                    switch (ch)
                    {
                        case '1':
                            {
                                obj.addNote();
                            }
                            break;
                        case '2':
                            {
                                if (obj.listEmpty())
                                {
                                    Console.WriteLine("\nList is empty");
                                    break;
                                }
                                Console.Write("\nEnter the roll number of the student" +
                        " Whose record is to be deleted: ");
                                int rollNo = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine();
                                if (obj.dellNote(rollNo) == false)
                                    Console.WriteLine("Record not found");
                                else
                                    Console.WriteLine("Record with roll number " + rollNo + " deleted \n");
                            }
                            break;
                        case '3':
                            {
                                obj.ascending();
                            }
                            break;
                        case '4':
                            {
                                obj.descending();
                            }
                            break;
                        case '5':
                            {
                                if (obj.listEmpty() == true)
                                {
                                    Console.WriteLine("\nList is empty");
                                    break;
                                }
                                Node prev, curr;
                                prev = curr = null;
                                Console.Write("\nEnter the roll number of the student whose record you want to search: ");
                                int num = Convert.ToInt32(Console.ReadLine());
                                if (obj.search(num, ref prev, ref curr) == false)
                                    Console.WriteLine("\nRecord not found");
                                else
                                {
                                    Console.WriteLine("\nRecord found");
                                    Console.WriteLine("\nRoll number: " + curr.noMhs);
                                    Console.WriteLine("\nName: " + curr.name);
                                }
                            }
                            break;
                        case '6':
                            return;
                        default:
                            {
                                Console.WriteLine("\nInvalid option");
                            }
                            break;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Check For the Values Entered.");
                }
            }
        }
    }
}

/*  2. Double Linked List
 *  3. Menurut saya TOP pada algortima stack yaitu Data Yang Masuk Pertama akan keluar di akhir dan data yang masuk terakhir akan keluar pertama
 *  4. STACK dan QUEUE
 *  5. (A) Memiliki 5 kedalaman yang dimiliki struktur tersebut
 *     (B) Inorder = 15, 25, 20, 31, 35, 32, 30, 48, 50, 65, 66, 69, 67, 94, 99, 98, 90,70
 *     (Cara Membacanya = Anak Kiri, Anak Kanan, Ibu)
 */