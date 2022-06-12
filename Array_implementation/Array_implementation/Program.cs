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
        GrowIfIsFull();
        this.arr[this.count]=item;
        this.count++;
    }
    ///<summary>Inserts the specified element at given position in this list</summary>
    /// <param name="index">
    /// index , at which the specified element is to be inserted</param>
    /// <param name="item">Element to be inserted</param>
    /// <exception cref=" cref="System.IndexOutOfRangeException">Index is invalid</exception>
    public void Insert(int index , T item)
    {
        if(index > this.count || index< 0)
        {
            throw new IndexOutOfRangeException("Invalid index" +index);

        }
    }



}