using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practice12
{
    class TreeNode
    {
        public int info { get; set; }
        public TreeNode left { get; set; }
        public TreeNode right { get; set; }
        public TreeNode father { get; set; }
        public TreeNode(int info, TreeNode father = null)
        {
            this.info = info;
            this.father = father;
        }
    }
}
