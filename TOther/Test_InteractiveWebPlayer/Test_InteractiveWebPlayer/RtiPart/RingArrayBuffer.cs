using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test_InteractiveWebPlayer.RtiPart
{
    /// <summary>
    /// 环形缓冲区
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class RingArrayBuffer<T>
    {
        T[] array;
        //List<T> array;
        private int size;
	    private int fullSize;
	    private int firstIndex;
	    private int lastIndex;
        private int elementCount;
        /// <summary>
        /// 元素个数.
        /// </summary>
        public int ElementCount
        {
            get { return elementCount; }

        }

        private object tag;
        /// <summary>
        /// Gets or sets the tag.
        /// </summary>
        /// <value>
        /// The tag.
        /// </value>
        public object Tag
        {
            get { return tag; }
            set { tag = value; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RingArrayBuffer&lt;T&gt;"/> class.
        /// </summary>
        /// <param name="size">元素个数.</param>
        public RingArrayBuffer(int size)
        {
            array = new T[size];
            //array = new List<T>();
            this.size = size;
            this.firstIndex = 0;
            this.lastIndex = 0;
            this.fullSize = size - 1;
        }

        private int UseCount()
        {
            if (firstIndex == lastIndex)
            {
                return 0;
            }
            else if (firstIndex > lastIndex)
            {

                return size - firstIndex + lastIndex;
            }
            else
            {
                return lastIndex - firstIndex;
            }
        }
        /// <summary>
        /// 数据加入.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <returns></returns>
        public bool PutData(T element)
		{
            if (!IsFull())
            {
                if (element.Equals(default(T)))
                { 

                }
                array[lastIndex++] = element;
                if (lastIndex > fullSize)
                  lastIndex %= size;
                elementCount = UseCount();
                return true;
            }
            else
            {
                return false;
            }
            
			
		}

        /// <summary>
        /// 取出数据.
        /// </summary>
        /// <returns></returns>
		public T GetData()
		{
            if (IsEmpty())
            {
                return default(T);
            }
            else
            {
                T e = array[firstIndex++];
                array[firstIndex-1] = default(T);
                if (firstIndex > fullSize)
                  firstIndex %= size;
                elementCount = UseCount();
                return e;
            }
		}

        bool IsFull()
        {
            return UseCount() == fullSize;
        }

        /// </returns>
        public bool IsEmpty()
        {
            return UseCount() == 0;
        }


        public override string ToString()
        {
            return string.Format("列表{0}:元素个数{1}",tag.ToString(),elementCount);
        }
    }
}
