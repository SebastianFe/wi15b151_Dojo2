using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wi15b151_Dojo2
{
    class Program
    {
        static void Main(string[] args)
        {
            //testing the stack

            //initialize the stack:
            customStack<int> myStack = new customStack<int>();

            //pushing:
            for (int i = 0; i < 10; i++)
            {
                myStack.Push(i);
                Console.WriteLine(myStack.Peek());
            }

            //popping:
            for (int i = 0; i < myStack.Size - 1; i++)
            {
                myStack.Pop();
                Console.WriteLine(myStack.Peek());
            }

            Console.ReadKey();

        }
    }

    //Represents a variable size last-in-first-out (LIFO) collection of instances of the same specified type.
    class customStack<T>
    {

        //size of the stack
        int size;

        //size property
        public int Size
        {
            get { return size; }
            set { size = value; }
        }

        //pointer to the last object
        int pointer;

        //the array of objects (the stack)
        T[] stack;

        //default constructor; the stack has an initial size of 0:
        public customStack()
        {
            pointer = -1;
            size = 0;
            stack = new T[0];
        }

        //Returns the object at the top of the stack without removing it. Throws an exception if stack is empty.
        public T Peek()
        {
            //throw invalid operation exception if the stack is empty:
            if (pointer == -1)
                throw new InvalidOperationException();
            return stack[pointer];
        }

        //Removes and returns the object at the top of the stack.
        public T Pop()
        {
            if (pointer >= 0)
                pointer--;
            return stack[pointer + 1];
        }

        //Inserts an object at the top of the stack.
        public void Push(T item)
        {
            //check if we need to resize
            if (pointer == size -1)
            {
                stack = Resize(stack);
            }
            pointer++;
            stack[pointer] = item;
        }

        //resizes the array and returns the new one
        T[] Resize(T[] inputArray)
        {
            T[] returnArray = new T[inputArray.Length + 1];
            for (int i = 0; i < inputArray.Length; i++)
            {
                returnArray[i] = inputArray[i];
            }
            size++;
            return returnArray;
        }

    }
}
