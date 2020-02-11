using System;

namespace lab2_linearTable
{
	public class UnorderedTable
	{
		public int[] _storage;
		

		public UnorderedTable()
		{

		}

		public static UnorderedTable FillRandom(int size) {
			var arr = new UnorderedTable();
			Random rnd = new Random();
			for (int i = 0; i < size; i++)
			{
				arr.Add(rnd.Next(0, 1000));
			}

			return arr;

		}
      

		public static UnorderedTable FillSize(int size) {
			var arr = new UnorderedTable();
			for (int i = 0; i < size; i++)
			{
				arr.Add(i + 1);
			}
			return arr;

		}

		public static int FindElement(UnorderedTable arr, int number, int size) {
			for (int i = 0; i < size; i++)
			{
				if (i == number) {
					return arr[i];
				}
			}
			return -1;
		}

		public static int SetElement(UnorderedTable arr, int number, int size, int value)
		{
			for (int i = 0; i < size; i++)
			{
				if (i == number)
				{
					arr[i] = value;
					return value;
				}
			}
			return -1;
		}

		public void Add(int value)
		{
			if (_storage == null) _storage = new int[] { value };
			else
			{
				Array.Resize(ref _storage, _storage.Length + 1);
				_storage[_storage.Length - 1] = value;
			}
		}

		public void Delete()
		{
				Array.Resize(ref _storage, _storage.Length - 1);
		}

		public static UnorderedTable Add_For_Index(int value, int index, UnorderedTable table, int size)
		{
			table.Add(value);
			int Forsize = Math.Abs(index);
			for (int i = size; i > Forsize; i--)
			{
				int temp;
				temp = table[i-2];
				table[i - 2] = table[i-1];
				table[i-1] = temp;
			}

			return table;
			//_storage[_storage.Length - 1] = value;
		}

		public static UnorderedTable Delete_element(int index, UnorderedTable table, int size)
		{
			size++;
			var arr = new UnorderedTable();
			for (int i = 0; i < size; i++)
			{
				if (i < index-1)
				{
					arr.Add(table[i]);
				}
				else if (i == index-1 )
				{
				}
				else
					arr.Add(table[i]);
			}

			arr.Add(-1);
			arr.Delete();
			return arr;
		}

		public static int FindValue(UnorderedTable table, int size, int value) {
			for (int i = 0; i < size; i++)
			{
				if (table[i] == value)
					return i;
			}
			return -1;
		}

		public void Clear() {
			Array.Clear(_storage,0,_storage.Length);
		}

		public int this[int index]
		{
			get
			{
				return _storage[index];
			}
			set
			{
				_storage[index] = value;
			}
		}

		public UnorderedTable Clone()
		{
			var table = new UnorderedTable();
			if (_storage != null)
			{
				table._storage = (int[])_storage.Clone();
			}
			return table;
		}


		public static UnorderedTable Join(UnorderedTable item1, UnorderedTable item2,int size)
		{
			//var result = new UnorderedTable();
			for (int i = 0; i < size; i++)
			{
				if (i < size / 2)
				{
					item1.Add(item2[i]);
				}
				else
					item1.Add(item2[i - size / 2]);
			}
			return item1;
			//throw new NotImplementedException();
		}

		public static UnorderedTable CutTable1(UnorderedTable t1, int size, int halfsize) {
			var arr = new UnorderedTable();
			for (int i = 0; i < halfsize; i++)
			{
					arr.Add(t1[i]);
			}

			return arr;
		}

		public static UnorderedTable CutTable2(UnorderedTable t2, int size, int halfsize)
		{
			var arr = new UnorderedTable();
			for (int i = halfsize; i < size; i++)
			{
					arr.Add(t2[i]);
			}

			return arr;
		}

		public static UnorderedTable ClearTable() {
			var arr = new UnorderedTable();
			return arr;
		}
	}

}
