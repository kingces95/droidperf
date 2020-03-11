using System;
using System.IO;
using System.Linq;

namespace XFShellUp.Droid
{
	struct CpuUsage
	{

		const string ProcStatPath = "/proc/stat";

		struct TotalIdle
		{
			/**
			 From SO: e.g cpu 79242 0 74306 842486413 756859 6140 67701 0
			 - 1st column : user = normal processes executing in user mode
			 - 2nd column : nice = niced processes executing in user mode
			 - 3rd column : system = processes executing in kernel mode
			 - 4th column : idle = twiddling thumbs
			 - 5th column : iowait = waiting for I/O to complete
			 - 6th column : irq = servicing interrupts
			 - 7th column : softirq = servicing softirqs
			**/
			const int ProcStatColumns = 7;
			const int ProcStatIdleColumn = 3;

			public int Total;
			public int Idle;

			public TotalIdle(string procStat)
			{
				var splits = procStat.Split(' ', StringSplitOptions.RemoveEmptyEntries);
				var counts = splits.Skip(1).Select(o => int.Parse(o)).Take(ProcStatColumns).ToArray();
				Total = counts.Sum();
				Idle = counts.Skip(ProcStatIdleColumn).First();
			}
		}

		public static int operator -(CpuUsage lhs, CpuUsage rhs)
		{
			var rhsValue = rhs._totalIdle.Value;
			var lhsValue = lhs._totalIdle.Value;

			var idle = (double)(lhsValue.Idle - rhsValue.Idle);
			var total = (double)(lhsValue.Total - rhsValue.Total);

			var idlePercentage = (int)(idle * 100 / total);
			return 100 - idlePercentage;
		}

		internal static CpuUsage Now
			=> new CpuUsage(File.ReadLines(ProcStatPath).First());

		Lazy<TotalIdle> _totalIdle;

		public CpuUsage(string procStat)
		{
			_totalIdle = new Lazy<TotalIdle>(() => new TotalIdle(procStat));
		}

		public override string ToString()
			=> $"Total={_totalIdle.Value.Total}, Idle={_totalIdle.Value.Idle}";
	}
}