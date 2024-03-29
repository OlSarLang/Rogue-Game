﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace LRogue
{
    public class LimitedList<T> : IEnumerable<T>
    {
        private readonly int capacity;
        private readonly List<T> list;

        public LimitedList(int capacity)
        {
            this.capacity = Math.Max(0, capacity);
            list = new List<T>(capacity);
        }

        public int Count => list.Count;
        public bool IsFull => capacity <= Count;

        public bool Add(T item)
        {
            if (IsFull) return false;
            list.Add(item);
            return true;
        
        }

        public bool Remove(T item) => list.Remove(item);


        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in list)
            {
                yield return item;
            }
        }
        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }
}
