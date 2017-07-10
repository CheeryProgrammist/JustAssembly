using System.Collections.Generic;
using JustAssembly.Nodes;

namespace JustAssembly.Exporters
{
	interface IExportData
	{
		IEnumerable<ItemNodeBase> GetNodes();
	}
}
