using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heap<T> where T : IHeapItem<T>
{
    private T[] _items;
    private int _currentItemsCount;

    public int Count
    {
        get { return _currentItemsCount; }
    }

    public Heap(int maxHeapSize)
    {
        _items = new T[maxHeapSize];
    }

    public void Add(T item)
    {
        item.HeapIndex = _currentItemsCount;
        _items[_currentItemsCount] = item;
        SortUp(item);
        _currentItemsCount++;
    }

    public T PullOffFirst()
    {
        T item = _items[0];
        _currentItemsCount--;
        _items[0] = _items[_currentItemsCount];
        _items[0].HeapIndex = 0;
        SortDown(_items[0]);

        return item;
    }

    public bool Contains(T item)
    {
        return Equals(_items[item.HeapIndex], item);
    }

    public void UpdateItem(T item)
    {
        SortUp(item);
    }

    private void SortUp(T item)
    {
        int parentIndex = (item.HeapIndex - 1) / 2;
        T parentItem = _items[parentIndex];

        while (item.CompareTo(parentItem) > 0)
        {
            Swap(item, parentItem);
            parentIndex = (item.HeapIndex - 1) / 2;
            parentItem = _items[parentIndex];
        }

    }

    private void SortDown(T item)
    {
        while (true)
        {
            int childIndexLeft = item.HeapIndex * 2 + 1;
            int childIndexRight = item.HeapIndex * 2 + 2;
            int swapIndex = 0;

            if (childIndexLeft < _currentItemsCount)
            {
                swapIndex = childIndexLeft;

                if (childIndexRight < _currentItemsCount)
                {
                    if (_items[childIndexLeft].CompareTo(_items[childIndexRight]) < 0)
                    {
                        swapIndex = childIndexRight;
                    }
                }

                if (item.CompareTo(_items[swapIndex]) < 0)
                {
                    Swap(item, _items[swapIndex]);
                }
                else
                {
                    return;
                }

            }
            else
            {
                return;
            }

        }

    }

    private void Swap(T item1, T item2)
    {
        _items[item1.HeapIndex] = item2;
        _items[item2.HeapIndex] = item1;

        int item1Index = item1.HeapIndex;
        item1.HeapIndex = item2.HeapIndex;
        item2.HeapIndex = item1Index;
        
    }
}
