using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICSharpCode.TreeView;
using JustAssembly.Nodes;

namespace JustAssembly.Exporters
{
	class ExportNodes: IExportData
	{
		private ItemNodeBase[] nodes;

		public ExportNodes(ItemNodeBase[] nodes)
		{
			this.nodes = nodes;
		}

		public IEnumerable<ItemNodeBase> GetNodes()
		{
			return nodes;
		}
	}
}
