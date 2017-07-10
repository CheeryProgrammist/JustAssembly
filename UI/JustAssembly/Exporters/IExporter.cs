using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustAssembly.Exporters
{
	interface IExporter
	{
		void SaveTo(string path);
	}
}
