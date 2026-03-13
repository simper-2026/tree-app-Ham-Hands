public class BinaryTree
{
    public List<Node> Tree;

    public BinaryTree()
    {
        Tree = new List<Node>{};
    }
    public void Insert(int value)
    {
        if(!Tree.Any())
        {
            Tree.Add(new Node(value));
            return;
        }
        
        AddNode(new Node(value), Tree[0]);
    }
    private void AddNode(Node child, Node parent)
    {
        if(child.Value < parent.Value)
        {
            if(parent.Left == null)
            {
                parent.Left = child;
                return;
            }
            else if(parent.Left.Value != child.Value)
            {
                AddNode(child, parent.Left);
            }
        }
        else if(child.Value > parent.Value)
        {
            if(parent.Right == null)
            {
                parent.Right = child;
                return;
            }
            else if(parent.Right.Value != child.Value)
            {
                AddNode(child, parent.Right);
            }
        }
    }
    public string InOrder()
    {
        return "";
    }
    public int Height()
    {
        return 0;
    }
    public string ToMermaid()
    {
        string toReturn = "graph TD\n";
        
        if (Tree.Count < 1)
        {
            toReturn += " empty[\"(empty tree)\"]";
            return toReturn;
        }
        else if(Tree[0].Left == null && Tree[0].Right == null && Tree.Count == 1)
        {
            toReturn += $" {Tree[0].Value}";
            return toReturn;
        }
        else
        {
            toReturn += MermaidNodeString(Tree[0]);
        }

        return toReturn;
    }
    private string MermaidNodeString(Node node)
    {
        string toReturn = "";

        if(node.Left != null)
        {
            toReturn += $" {node.Value} --> {node.Left.Value}";
        }

        return toReturn;
    }
}