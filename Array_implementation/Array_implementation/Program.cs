// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
public class CustomArrayList<T>
{
    private T[] arr;
    private int count;
    //<summary> Returns the actual list Length<summary>
    public int Count
    {
        get
        {
            return this.count;
        }
    }
    private const int INITIAL_CAPACITY = 4;
    ///<summary>
    ///initializes the array-based list - allocate memory
    ///</summary>
    public CustomArrayList(int capacity = INITIAL_CAPACITY)
    {
        this.arr = new T[capacity];
        this.count = 0;
    }
    ///<summary>Adds element to the list</summary>
    ///<param name ="item">The element you want to add</param>
    public void Add(T item)
    {
        GrowIfArrIsFull();
        this.arr[this.count]=item;
        this.count++;
    }

    ///<summary>Inserts the specified element at given position in this list</summary>
    /// <param name="index">
    /// index , at which the specified element is to be inserted</param>
    /// <param name="item">Element to be inserted</param>
    /// <exception  cref="System.IndexOutOfRangeException">Index is invalid</exception>
    public void Insert(int index , T item)
    {
        if(index > this.count || index< 0)
        {
            throw new IndexOutOfRangeException("Invalid index" +index);
        }
        GrowIfArrIsFull();
        Array.Copy(this.arr,   index,this.arr,index + 1, this.count - index);
        this.arr[index] = item;
        this.count++;
    }
    ///<summary>
    ///Double the size of this array if its full
    ///</summary>
    private void GrowIfArrIsFull()
    {
        if(this.count + 1 > this.arr.Length)
        {
            T[] extentedArr = new T[this.arr.Length * 2];
            Array.Copy(this.arr, extentedArr, this.count);
            this.arr = extentedArr;
        }

    }
    ///<summary>Clear the list </summary>
    public void Clear()
    {
        this.arr = new T[INITIAL_CAPACITY];
        this.count = 0;
    }
    ///summary>
    ///return the index of the first occurrence of the specified 
    ///element in this list (or -1 if it does not exist ).
    ///</summary>
    ///<typeparam name="item">the element you are serching</param>
    ///<returns>
    ///the index of a given element or -1     if not   found
    ///</returns>
    public int IndexOf(T item)
    {
        for (int i = 0; i < this.arr.Length; i++)
        {
            if (object.Equals(item, this.arr[i]))
            {
                return i;
            }
        }
        return -1;

    }
    ///<summary>Checks if an element exists </summary>
    ///<param name="item">The item to be checked param>
    ///<returns> If thre item exist</returns>
    public bool Contains(T item)
 
    {
        int index = IndexOf(item);
        bool found = (index != -1);
        return found;
    }
    ///<summary>Indexer:access to element at a given position </summary>
    ///<param name="index">Index of the element</param>
    ///<returns> the element the specified position</returns>
    public T this[int index]
    {
        get
        {
            if(index >= this.count || index < 0)
            {
                throw new ArgumentOutOfRangeException("invalid index" + index);
            }
            return this.arr[index];
        }
        set
        {
            if (index >= this.count || index < 0 )
            {
                throw new ArgumentOutOfRangeException("invalid index" + index);
            }
            this.arr[index] = value;
        }
    }
    ///<summary>Remove the elemennt at the specified index </summary>
    ///<param name="index">the index of the element to be removed</param>
    ///<returns>the removed item</returns>
    public T RemoveAt(int index)
    {
            if(index>= this.count || index < 0)
            {
                throw new ArgumentOutOfRangeException("invalid index" + index);
            }
            T item = this.arr[index];
            Array.Copy(this.arr, index + 1, this.arr, index, this.count - index - 1);
            this.arr[this.count - 1] = default(T);
            this.count--;
            return item; 
    }
    /// <summary>Removes the specified item</summary>
    /// <param name="item">The item to be removed</param>
    /// <returns>The removed item's index or -1 if the item does not exist</returns>
    public int Remove(T item)
    {
        int index = IndexOf(item);
        if(index != -1)
        {
            this.RemoveAt(index);
        }
        return index;
    }


}